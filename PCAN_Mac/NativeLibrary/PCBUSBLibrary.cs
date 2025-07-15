using System;
using System.Runtime.InteropServices;
using PCAN_Mac.Enums;
using PCAN_Mac.Structs;

namespace PCAN_Mac.NativeLibrary;

internal static class PCBUSBLibrary
{
    /** @brief       Initializes a PCAN Channel.
     *  @param[in]   Channel    The handle of a PCAN Channel.
     *  @param[in]   Btr0Btr1   The speed for the communication (BTR0BTR1 code).
     *  @param[in]   HwType     (not used with PCAN USB devices)
     *  @param[in]   IOPort     (not used with PCAN USB devices)
     *  @param[in]   Interrupt  (not used with PCAN USB devices)
     *  @returns     A TPCANStatus error code.
     */
    [DllImport("/usr/local/lib/libPCBUSB.dylib", EntryPoint = "CAN_Initialize", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus LCAN_Initialize(
        TPCANHandle channel,
        TPCANBaudrate btr0Btr1,
        TPCANType hwType = TPCANType.PCAN_USB,
        uint ioPort = 0,
        ushort interrupt = 0);
    
    /** @brief       Uninitializes one or all PCAN Channels initialized by CAN_Initialize
     *  @remarks     Giving the TPCANHandle value "PCAN_NONEBUS", uninitializes all initialized channels.
     *  @param[in]   Channel    The handle of a PCAN Channel.
     *  @returns     A TPCANStatus error code.
     */
    [DllImport("/usr/local/lib/libPCBUSB.dylib", EntryPoint = "CAN_Uninitialize", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus LCAN_Uninitialize(TPCANHandle channel);
    
    /** @brief       Resets the receive and transmit queues of the PCAN Channel.
     *  @remarks     A reset of the CAN controller is not performed.
     *  @param[in]   Channel    The handle of a PCAN Channel.
     *  @returns     A TPCANStatus error code.
     */
    [DllImport("/usr/local/lib/libPCBUSB.dylib", EntryPoint = "CAN_Reset", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus LCAN_Reset(TPCANHandle channel);
    
    /** @brief       Gets the current status of a PCAN Channel.
     *  @param[in]   Channel    The handle of a PCAN Channel.
     *  @returns     A TPCANStatus error code.
     */
    [DllImport("/usr/local/lib/libPCBUSB.dylib", EntryPoint = "CAN_GetStatus", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus LCAN_GetStatus(TPCANHandle channel);
    
    /** @brief       Reads a CAN message from the receive queue of a PCAN Channel.
     *  @param[in]   Channel          The handle of a PCAN Channel.
     *  @param[out]  MessageBuffer    A TPCANMsg structure buffer to store the CAN message.
     *  @param[out]  TimestampBuffer  A TPCANTimestamp structure buffer to get the reception time of the message.
     *                               If this value is not desired, this parameter should be passed as NULL.
     *  @returns     A TPCANStatus error code.
     */
    [DllImport("/usr/local/lib/libPCBUSB.dylib", EntryPoint = "CAN_Read", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus LCAN_Read(
        TPCANHandle channel,
        out TPCANMsg messageBuffer,
        out TPCANTimestamp timestampBuffer);
    
    /** @brief       Transmits a CAN message.
     *  @param[in]   Channel        The handle of a PCAN Channel.
     *  @param[in]   MessageBuffer  A TPCANMsg buffer with the message to be sent.
     *  @returns     A TPCANStatus error code.
     */
    [DllImport("/usr/local/lib/libPCBUSB.dylib", EntryPoint = "CAN_Write", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus LCAN_Write(
        TPCANHandle channel,
        in TPCANMsg messageBuffer);
    
    /** @brief       Configures the reception filter.
     *  @remarks     The message filter will be expanded with every call to  this function.
     *               If it is desired to reset the filter, please use the CAN_SetValue function.
     *  @param[in]   Channel    The handle of a PCAN Channel.
     *  @param[in]   FromID     The lowest CAN ID to be received.
     *  @param[in]   ToID       The highest CAN ID to be received.
     *  @param[in]   Mode       Message type, Standard (11-bit identifier) or Extended (29-bit identifier).
     *  @returns     A TPCANStatus error code.
     */
    [DllImport("/usr/local/lib/libPCBUSB.dylib", EntryPoint = "CAN_FilterMessages", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus LCAN_FilterMessages(
        TPCANHandle channel,
        uint fromId,
        uint toId,
        TPCANMode mode);
    
    /** @brief       Retrieves a PCAN Channel value.
     *  @remarks     Parameters can be present or not according with the kind of Hardware (PCAN Channel) being used.
     *               If a parameter is not available, a PCAN_ERROR_ILLPARAMTYPE error will be returned.
     *  @param[in]   Channel       The handle of a PCAN Channel.
     *  @param[in]   Parameter     The TPCANParameter parameter to get.
     *  @param[out]  Buffer        Buffer for the parameter value.
     *  @param[in]   BufferLength  Size in bytes of the buffer.
     *  @returns     A TPCANStatus error code.
     */
    [DllImport("/usr/local/lib/libPCBUSB.dylib", EntryPoint = "CAN_GetValue", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus LCAN_GetValue(
        TPCANHandle Channel,
        TPCANParameter Parameter,
        out string Buffer,
        ushort BufferLength);
    
    /** @brief       Configures or sets a PCAN Channel value.
     *  @remarks     Parameters can be present or not according with the kind of Hardware (PCAN Channel) being used.
     *               If a parameter is not available, a PCAN_ERROR_ILLPARAMTYPE error will be returned.
     *  @param[in]   Channel       The handle of a PCAN Channel.
     *  @param[in]   Parameter     The TPCANParameter parameter to set.
     *  @param[in]   Buffer        Buffer with the value to be set.
     *  @param[in]   BufferLength  Size in bytes of the buffer.
     *  @returns     A TPCANStatus error code.
     */
    [DllImport("/usr/local/lib/libPCBUSB.dylib", EntryPoint = "CAN_SetValue", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus LCAN_SetValue(
        TPCANHandle Channel,
        TPCANParameter Parameter,
        out string Buffer,
        ushort BufferLength);
    
    /** @brief       Returns a descriptive text of a given TPCANStatus error code, in any desired language.
     *  @remarks     The current languages available for translation are:
     *               Neutral (0x00), German (0x07), English (0x09), Spanish (0x0A), Italian (0x10) and French (0x0C).
     *  @param[in]   Error     A TPCANStatus error code.
     *  @param[in]   Language  Indicates a 'Primary language ID'.
     *  @param[out]  Buffer    Buffer for a null terminated char array.
     *  @returns     A TPCANStatus error code.
     */
    [DllImport("/usr/local/lib/libPCBUSB.dylib", EntryPoint = "CAN_GetErrorText", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus LCAN_GetErrorText(
        TPCANStatus Error,
        uint Language,
        [MarshalAs(UnmanagedType.LPStr)] out string buffer);
    
    /** @brief       Finds a PCAN-Basic channel that matches with the given parameters
     *  @param[in]   Parameters    A comma separated string contained pairs of parameter-name/value
     *                             to be matched within a PCAN-Basic channel
     *  @param[out]  FoundChannel  Buffer for returning the PCAN-Basic channel, when found
     *  @returns     A TPCANStatus error code.
     */
    [DllImport("/usr/local/lib/libPCBUSB.dylib", EntryPoint = "CAN_LookUpChannel", CallingConvention = CallingConvention.Cdecl)]
    public static extern TPCANStatus LCAN_LookUpChannel(
        [MarshalAs(UnmanagedType.LPStr)] out string Parameters,
        out TPCANHandle FoundChannel);
}