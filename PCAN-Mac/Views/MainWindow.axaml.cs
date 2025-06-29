using System;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using PCAN_Mac.Enums;
using PCAN_Mac.Services;
using Avalonia.Threading;
using PCAN_Mac.Structs;

namespace PCAN_Mac.Views;

public partial class MainWindow : Window
{
    private readonly PCBUSBService _canService = new();
    private CancellationTokenSource? _cts;
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private async void OnStartClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        // 1) Initialize the CAN interface (you said handle & baudrate are hard-coded)
        var status = _canService.CAN_Initialize(
            TPCANHandle.PCAN_USBBUS1,
            TPCANBaudrate.PCAN_BAUD_1M
        );

        if (status != TPCANStatus.PCAN_ERROR_OK)
        {
            Console.WriteLine($"{status} error on connecting");
            return;
        }
        Console.WriteLine($"PCAN Conected");

        StartButton.IsEnabled = false;
        StopButton!.IsEnabled = true;

        // 2) Start background loop
        _cts = new CancellationTokenSource();
        await Task.Run(() => ReadLoop(_cts.Token));
    }
    
    private void OnStopClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        // cancel the loop & uninitialize
        _cts?.Cancel();
        _canService.CAN_Uninitialize(_canService.Channel);
        Console.WriteLine("PCAN Uninitialized");
        StartButton!.IsEnabled = true;
        StopButton!.IsEnabled = false;
    }
    
    private void ReadLoop(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            var ret = _canService.CAN_Read(
                _canService.Channel,
                out TPCANMsg msg,
                out TPCANTimestamp ts
            );

            if (ret == TPCANStatus.PCAN_ERROR_OK)
            {
                // Make sure we never ask for more bytes than DATA.Length:
                int available = msg.DATA?.Length ?? 0;
                int len = Math.Min(Math.Max((byte)20, msg.LEN), available);

                // Only slice if there's actually data
                string dataHex = len > 0
                    ? BitConverter.ToString(msg.DATA, 0, len).Replace("-", " ")
                    : string.Empty;

                var line = $"[{ts.Millis}.{ts.Micros:D3}] " +
                           $"ID=0x{msg.ID:X3} Len={len} Data={dataHex}";

                Console.WriteLine(line);
            }
            else
            {
                Thread.Sleep(10);
            }
        }
    }

}