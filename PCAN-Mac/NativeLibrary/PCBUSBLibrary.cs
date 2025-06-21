using System;
using System.Runtime.InteropServices;
using PCAN_Mac.Enums;
using PCAN_Mac.Structs;

namespace PCAN_Mac.NativeLibrary;

internal static class PCBUSBLibrary
{
    [DllImport("PCBUSB", EntryPoint = "CAN_Initialize", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus CAN_Initialize(
        TPCANHandle Channel,
        TPCANBaudrate Btr0Btr1,
        TPCANType HwType,
        uint IOPort,
        ushort Interrupt);
    
    [DllImport("PCBUSB", EntryPoint = "CAN_Uninitialize", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus CAN_Uninitialize(
        TPCANHandle Channel);
    
    [DllImport("PCBUSB", EntryPoint = "CAN_Reset", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus CAN_Reset(
        TPCANHandle Channel);
    
    [DllImport("PCBUSB", EntryPoint = "CAN_GetStatus", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus CAN_GetStatus(
        TPCANHandle Channel);
    
    [DllImport("PCBUSB", EntryPoint = "CAN_Read", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus CAN_Read(
        TPCANHandle Channel,
        out TPCANMsg MessageBuffer,
        out TPCANTimestamp TimestampBuffer);
    
    [DllImport("PCBUSB", EntryPoint = "CAN_Write", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus CAN_Write(
        TPCANHandle Channel,
        in TPCANMsg MessageBuffer);
    
    [DllImport("PCBUSB", EntryPoint = "CAN_FilterMessages", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus CAN_FilterMessages(
        TPCANHandle Channel,
        uint FromID,
        uint ToID,
        TPCANMode Mode);
}