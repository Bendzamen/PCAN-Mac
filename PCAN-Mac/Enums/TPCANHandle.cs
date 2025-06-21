namespace PCAN_Mac.Enums;

public enum TPCANHandle : uint
{
  PCAN_NONEBUS = 0x00U,  //!< Undefined/default value for a PCAN bus
  PCAN_USBBUS1 = 0x51U,  //!< PCAN-USB interface, channel 1
  PCAN_USBBUS2 = 0x52U,  //!< PCAN-USB interface, channel 2
  PCAN_USBBUS3 = 0x53U,  //!< PCAN-USB interface, channel 3
  PCAN_USBBUS4 = 0x54U,  //!< PCAN-USB interface, channel 4
  PCAN_USBBUS5 = 0x55U,  //!< PCAN-USB interface, channel 5
  PCAN_USBBUS6 = 0x56U,  //!< PCAN-USB interface, channel 6
  PCAN_USBBUS7 = 0x57U,  //!< PCAN-USB interface, channel 7
  PCAN_USBBUS8 = 0x58U,  //!< PCAN-USB interface, channel 8
  PCAN_USBBUS9 = 0x509U, //!< PCAN-USB interface, channel 9
  PCAN_USBBUS10 = 0x50AU, //!< PCAN-USB interface, channel 10
  PCAN_USBBUS11 = 0x50BU, //!< PCAN-USB interface, channel 11
  PCAN_USBBUS12 = 0x50CU, //!< PCAN-USB interface, channel 12
  PCAN_USBBUS13 = 0x50DU, //!< PCAN-USB interface, channel 13
  PCAN_USBBUS14 = 0x50EU, //!< PCAN-USB interface, channel 14
  PCAN_USBBUS15 = 0x50FU, //!< PCAN-USB interface, channel 15
  PCAN_USBBUS16 = 0x510U //!< PCAN-USB interface, channel 16
}