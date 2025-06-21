using System;
using System.Runtime.InteropServices;
using PCAN_Mac.Enums;

namespace PCAN_Mac.Structs;

/// <summary>
///  Corresponds to the native TPCANMsg struct:
///  typedef struct tagTPCANMsg {
///      DWORD             ID;
///      TPCANMessageType  MSGTYPE;
///      BYTE              LEN;
///      BYTE              DATA[8];
///  } TPCANMsg;
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TPCANMsg
{
    /// <summary>
    ///  11‐ or 29‐bit CAN identifier
    /// </summary>
    public uint ID;                              // DWORD → UInt32

    /// <summary>
    ///  Type of the message (standard, extended, error, etc.)
    /// </summary>
    public TPCANMessageType MSGTYPE;            // BYTE → byte-backed enum

    /// <summary>
    ///  Number of data bytes (0..8)
    /// </summary>
    public byte LEN;                             // BYTE → byte

    /// <summary>
    ///  The actual data payload
    /// </summary>
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public byte[] DATA;                          // BYTE[8] → byte[8]
}