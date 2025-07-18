using System.Runtime.InteropServices;

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
    /// 4‐byte CAN identifier.
    /// </summary>
    public uint ID;

    /// <summary>
    /// 1‐byte message type (standard, extended, RTR…).
    /// </summary>
    public byte MSGTYPE;

    /// <summary>
    /// 1‐byte data length (0–8).
    /// </summary>
    public byte LEN;

    /// <summary>
    /// Exactly 8 bytes of data payload.
    /// </summary>
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public byte[] DATA;
}
