using PCAN_Mac.Enums;
using PCAN_Mac.Structs;

namespace PCAN_Mac.Interfaces;

public interface IPCBUSBInterface
{
    public bool IsInitialized { get; }
    public TPCANHandle Channel { get; }
    public TPCANBaudrate Baudrate{ get;}

    public TPCANStatus CAN_Initialize(TPCANHandle channel, TPCANBaudrate baud, TPCANType hwType, uint ioPort, ushort interrupt);
    public TPCANStatus CAN_Uninitialize(TPCANHandle channel);
    //bool CAN_Reset(TPCANHandle Channel);
    public TPCANStatus CAN_GetStatus(TPCANHandle channel);
    public TPCANStatus CAN_Read(TPCANHandle channel, out TPCANMsg messageBuffer, out TPCANTimestamp timestampBuffer);
    public TPCANStatus CAN_Write(TPCANHandle channel, in TPCANMsg messageBuffer);
    //TPCANStatus CAN_FilterMessages(TPCANHandle channel, uint fromId, uint toId, TPCANMode mode);
    //TPCANStatus CAN_GetValue(TPCANHandle Channel, TPCANParameter Parameter, out string Buffer, ushort BufferLength);
    //TPCANStatus CAN_SetValue(TPCANHandle Channel, TPCANParameter Parameter, out string Buffer, ushort BufferLength);
    //TPCANStatus CAN_GetErrorText(TPCANStatus Error, uint Language, out string Parameters, out TPCANHandle FoundChannel);
    public void Close();
}