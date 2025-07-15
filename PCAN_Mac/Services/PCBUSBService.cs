using System;
using PCAN_Mac.Enums;
using PCAN_Mac.Interfaces;
using PCAN_Mac.NativeLibrary;
using PCAN_Mac.Structs;

namespace PCAN_Mac.Services;

public class PCBUSBService : IPCBUSBInterface
{
    private TPCANHandle? _channel;
    private TPCANBaudrate? _baudrate;

    public bool IsInitialized { get; private set; } = false;

    public TPCANHandle Channel => _channel ?? throw new ObjectDisposedException(nameof(PCBUSBService));
    public TPCANBaudrate Baudrate => _baudrate ?? throw new ObjectDisposedException(nameof(PCBUSBService));

    public TPCANStatus CAN_Initialize(TPCANHandle channel, TPCANBaudrate baud, TPCANType hwType = TPCANType.PCAN_USB, uint ioPort = 0, ushort interrupt = 0)
    {
        _channel = channel;
        _baudrate = baud;
        TPCANStatus ret = PCBUSBLibrary.LCAN_Initialize(_channel.Value, _baudrate.Value);
        if (ret == TPCANStatus.PCAN_ERROR_OK)
        {
            Console.WriteLine("PCBUSB Initialize success");
            IsInitialized = true;
        }
        else
        {
            Console.WriteLine("PCBUSB Initialize failed");
        }
        return ret;
    }

    public TPCANStatus CAN_Uninitialize(TPCANHandle channel)
    {
        TPCANStatus ret = TPCANStatus.PCAN_ERROR_UNKNOWN;
        if (IsInitialized && _channel is not null)
        {
            ret = PCBUSBLibrary.LCAN_Uninitialize(_channel.Value);    
        }
        IsInitialized = false;
        _channel = null;
        _baudrate = null;
        return ret;
    }

    public TPCANStatus CAN_GetStatus(TPCANHandle channel)
    {   
        if (IsInitialized && _channel is not null)
            return PCBUSBLibrary.LCAN_GetStatus(_channel.Value);
        return TPCANStatus.PCAN_ERROR_BUSOFF;
    }
    
    public TPCANStatus CAN_Read(TPCANHandle channel, out TPCANMsg messageBuffer, out TPCANTimestamp timestampBuffer)
    {
        if (IsInitialized && _channel is not null)
            return PCBUSBLibrary.LCAN_Read(_channel.Value, out messageBuffer, out timestampBuffer);
        messageBuffer = new TPCANMsg();
        timestampBuffer = new TPCANTimestamp();
        return TPCANStatus.PCAN_ERROR_BUSOFF;
    }

    public TPCANStatus CAN_Write(TPCANHandle channel, in TPCANMsg messageBuffer)
    {
        throw new NotImplementedException();
    }

    public void Close()
    {
        if (IsInitialized && _channel is not null)
        {
            PCBUSBLibrary.LCAN_Uninitialize(_channel.Value);
        }
        IsInitialized = false;
    }

    public void Dispose() => Close();
}