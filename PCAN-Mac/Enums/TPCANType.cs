namespace PCAN_Mac.Enums;

public enum TPCANType : uint
{
    PCAN_NONE = 0x00U,  //!< Undefined, unknown or not selected PCAN device value
    PCAN_PEAKCAN = 0x01U,  //!< PCAN Non-PnP devices. NOT USED WITHIN PCAN-Basic API
    PCAN_ISA = 0x02U,  //!< PCAN-ISA, PCAN-PC/104, and PCAN-PC/104-Plus
    PCAN_DNG = 0x03U,  //!< PCAN-Dongle
    PCAN_PCI = 0x04U,  //!< PCAN-PCI, PCAN-cPCI, PCAN-miniPCI, and PCAN-PCI Express
    PCAN_USB = 0x05U,  //!< PCAN-USB and PCAN-USB Pro
    PCAN_PCC = 0x06U,  //!< PCAN-PC Card
    PCAN_VIRTUAL = 0x07U,  //!< PCAN Virtual hardware. NOT USED WITHIN PCAN-Basic API
    PCAN_LAN = 0x08U  //!< PCAN Gateway devices
}