using System;
using System.Runtime.InteropServices;

/// <summary>
/// Timestamp of a received PCAN message.
/// Total microseconds = micros + 1000 * millis + 0x100000000 * 1000 * millis_overflow.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TPCANTimestamp
{
    /// <summary>Milliseconds since start (0..2^32-1).</summary>
    public uint Millis;               // DWORD → UInt32

    /// <summary>Number of times <see cref="Millis"/> rolled over.</summary>
    public ushort MillisOverflow;     // WORD  → UInt16

    /// <summary>Additional microseconds (0..999).</summary>
    public ushort Micros;             // WORD  → UInt16

    /// <summary>
    /// Computes the full timestamp in microseconds, accounting for overflow.
    /// </summary>
    public ulong TotalMicroseconds =>
        (ulong)Micros
        + (ulong)Millis * 1_000UL
        + (ulong)0x1_0000_0000 * 1_000UL * MillisOverflow;
}