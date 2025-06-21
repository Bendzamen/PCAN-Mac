namespace PCAN_Mac.Enums;

public enum TPCANStatus : uint
{ 
     PCAN_ERROR_OK = 0x00000U,  //!< No error
     PCAN_ERROR_XMTFULL = 0x00001U,  //!< Transmit buffer in CAN controller is full
     PCAN_ERROR_OVERRUN = 0x00002U,  //!< CAN controller was read too late
     PCAN_ERROR_BUSLIGHT = 0x00004U,  //!< Bus error: an error counter reached the 'light' limit
     PCAN_ERROR_BUSHEAVY = 0x00008U,  //!< Bus error: an error counter reached the 'heavy' limit
     PCAN_ERROR_BUSWARNING = PCAN_ERROR_BUSHEAVY, //!< Bus error: an error counter reached the 'warning' limit
     PCAN_ERROR_BUSPASSIVE = 0x40000U,  //!< Bus error: the CAN controller is error passive
     PCAN_ERROR_BUSOFF = 0x00010U,  //!< Bus error: the CAN controller is in bus-off state
     PCAN_ERROR_ANYBUSERR = (PCAN_ERROR_BUSWARNING | PCAN_ERROR_BUSLIGHT | PCAN_ERROR_BUSHEAVY | PCAN_ERROR_BUSOFF | PCAN_ERROR_BUSPASSIVE), //!< Mask for all bus errors
     PCAN_ERROR_QRCVEMPTY = 0x00020U,  //!< Receive queue is empty
     PCAN_ERROR_QOVERRUN = 0x00040U,  //!< Receive queue was read too late
     PCAN_ERROR_QXMTFULL = 0x00080U,  //!< Transmit queue is full
     PCAN_ERROR_REGTEST = 0x00100U,  //!< Test of the CAN controller hardware registers failed (no hardware found)
     PCAN_ERROR_NODRIVER = 0x00200U,  //!< Driver not loaded
     PCAN_ERROR_HWINUSE = 0x00400U,  //!< Hardware already in use by a Net
     PCAN_ERROR_NETINUSE = 0x00800U,  //!< A Client is already connected to the Net
     PCAN_ERROR_ILLHW = 0x01400U,  //!< Hardware handle is invalid
     PCAN_ERROR_ILLNET = 0x01800U,  //!< Net handle is invalid
     PCAN_ERROR_ILLCLIENT = 0x01C00U,  //!< Client handle is invalid
     PCAN_ERROR_ILLHANDLE = (PCAN_ERROR_ILLHW | PCAN_ERROR_ILLNET | PCAN_ERROR_ILLCLIENT),  //!< Mask for all handle errors
     PCAN_ERROR_RESOURCE = 0x02000U,  //!< Resource (FIFO, Client, timeout) cannot be created
     PCAN_ERROR_ILLPARAMTYPE = 0x04000U,  //!< Invalid parameter
     PCAN_ERROR_ILLPARAMVAL = 0x08000U,  //!< Invalid parameter value
     PCAN_ERROR_UNKNOWN = 0x10000U,  //!< Unknown error
     PCAN_ERROR_ILLDATA = 0x20000U,  //!< Invalid data, function, or action
     PCAN_ERROR_ILLMODE = 0x80000U,  //!< Driver object state is wrong for the attempted operation
     PCAN_ERROR_CAUTION = 0x2000000U,  //!< An operation was successfully carried out, however, irregularities were registered
     PCAN_ERROR_INITIALIZE = 0x4000000U,  //!< Channel is not initialized [Value was changed from 0x40000 to 0x4000000]
     PCAN_ERROR_ILLOPERATION = 0x8000000U  //!< Invalid operation [Value was changed from 0x80000 to 0x8000000]
}