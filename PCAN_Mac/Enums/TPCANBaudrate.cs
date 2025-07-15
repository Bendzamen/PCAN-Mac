namespace PCAN_Mac.Enums;

public enum TPCANBaudrate : uint
{
    PCAN_BAUD_1M = 0x0014U,  //!<   1 MBit/s
    PCAN_BAUD_800K = 0x0016U,  //!< 800 kBit/s
    PCAN_BAUD_500K = 0x001CU,  //!< 500 kBit/s
    PCAN_BAUD_250K = 0x011CU,  //!< 250 kBit/s
    PCAN_BAUD_125K = 0x031CU,  //!< 125 kBit/s
    PCAN_BAUD_100K = 0x432FU,  //!< 100 kBit/s
    PCAN_BAUD_95K = 0xC34EU,  //!<  95,238 kBit/s
    PCAN_BAUD_83K = 0x852BU,  //!<  83,333 kBit/s
    PCAN_BAUD_50K = 0x472FU,  //!<  50 kBit/s
    PCAN_BAUD_47K = 0x1414U,  //!<  47,619 kBit/s
    PCAN_BAUD_33K = 0x8B2FU,  //!<  33,333 kBit/s
    PCAN_BAUD_20K = 0x532FU,  //!<  20 kBit/s
    PCAN_BAUD_10K = 0x672FU,  //!<  10 kBit/s
    PCAN_BAUD_5K = 0x7F7FU  //!<   5 kBit/s
}