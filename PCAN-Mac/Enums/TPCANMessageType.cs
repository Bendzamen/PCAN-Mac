namespace PCAN_Mac.Enums;

public enum TPCANMessageType : uint
{
    PCAN_MESSAGE_STANDARD = 0x00U, //!< The PCAN message is a CAN Standard Frame (11-bit identifier)
    PCAN_MESSAGE_RTR = 0x01U, //!< The PCAN message is a CAN Remote-Transfer-Request Frame
    PCAN_MESSAGE_EXTENDED = 0x02U, //!< The PCAN message is a CAN Extended Frame (29-bit identifier)
    PCAN_MESSAGE_FD = 0x04U, //!< The PCAN message represents a FD frame in terms of CiA Specs
    PCAN_MESSAGE_BRS = 0x08U, //!< The PCAN message represents a FD bit rate switch (CAN data at a higher bit rate)
    PCAN_MESSAGE_ESI = 0x10U, //!< The PCAN message represents a FD error state indicator(CAN FD transmitter was error active)
    PCAN_MESSAGE_ECHO = 0x20U, //!< The PCAN message represents an echo CAN Frame
    PCAN_MESSAGE_ERRFRAME = 0x40U, //!< The PCAN message represents an error frame
    PCAN_MESSAGE_STATUS = 0x80U //!< The PCAN message represents a PCAN status message
}