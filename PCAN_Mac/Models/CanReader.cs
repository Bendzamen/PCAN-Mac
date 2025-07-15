using System;
using System.Threading;
using System.Threading.Tasks;
using PCAN_Mac.Enums;
using PCAN_Mac.Services;
using PCAN_Mac.Structs;

namespace PCAN_Mac.Models;

public class CanMessageEventArgs(uint id, string timestamp, byte[] data) : EventArgs
{
    public uint Id { get; } = id;
    public string Timestamp { get; } = timestamp;
    public byte[] Data { get; } = data;
}

public class CanReader
{
    private readonly PCBUSBService _service = new();
    private CancellationTokenSource? _cts;
    public bool IsRunning { get; private set; }

    /// <summary>
    /// Notify on each successfully read CAN frame.
    /// </summary>
    public event EventHandler<CanMessageEventArgs>? MessageReceived;

    /// <summary>
    /// Initialize the hardware; must be called before Start().
    /// </summary>
    public TPCANStatus Initialize()
    {
        var status = _service.CAN_Initialize(TPCANHandle.PCAN_USBBUS1, TPCANBaudrate.PCAN_BAUD_1M);
        if (status == TPCANStatus.PCAN_ERROR_OK)
            IsRunning = true;
        return status;
    }

    /// <summary>
    /// Start the async read loop
    /// </summary>
    public void Start()
    {
        if (!IsRunning) throw new InvalidOperationException("Call Initialize() first.");
        _cts = new CancellationTokenSource();
        Task.Run(() => ReadLoop(_cts.Token));
    }

    private void ReadLoop(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            var ret = _service.CAN_Read(
                _service.Channel,
                out TPCANMsg msg,
                out TPCANTimestamp ts
            );

            if (ret == TPCANStatus.PCAN_ERROR_OK)
            {
                int len = Math.Clamp(msg.LEN, 0, msg.DATA?.Length ?? 0);
                var data = new byte[len];
                if (msg.DATA is not null)
                    Array.Copy(msg.DATA, data, len);

                var when = $"{ts.Millis}.{ts.Micros:D3}";
                Console.WriteLine($"{data} {when}");
                MessageReceived?.Invoke(this,
                    new CanMessageEventArgs(msg.ID, when, data));
            }
            else
            {
                Thread.Sleep(10);
            }
        }
    }

    /// <summary>
    /// Stop the loop and uninit the caninterface.
    /// </summary>
    public void Stop()
    {
        _cts?.Cancel();
        _service.CAN_Uninitialize(_service.Channel);
        IsRunning = false;
    }
}