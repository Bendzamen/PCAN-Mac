namespace PCAN_Mac.Enums;

public enum TPCANParameter : uint
{
    PCAN_PARAMETER_OFF = 0x00U,  //!< The PCAN parameter is not set (inactive)
    PCAN_PARAMETER_ON = 0x01U,  //!< The PCAN parameter is set (active)
    PCAN_FILTER_CLOSE = 0x00U,  //!< The PCAN filter is closed. No messages will be received
    PCAN_FILTER_OPEN = 0x01U,  //!< The PCAN filter is fully opened. All messages will be received
    PCAN_FILTER_CUSTOM = 0x02U,  //!< The PCAN filter is custom configured. Only registered messages will be received
    PCAN_CHANNEL_UNAVAILABLE = 0x00U,  //!< The PCAN-Channel handle is illegal, or its associated hardware is not available
    PCAN_CHANNEL_AVAILABLE = 0x01U,  //!< The PCAN-Channel handle is available to be connected (PnP Hardware: it means furthermore that the hardware is plugged-in)
    PCAN_CHANNEL_OCCUPIED = 0x02U,  //!< The PCAN-Channel handle is valid, and is already being used
    PCAN_CHANNEL_PCANVIEW = (PCAN_CHANNEL_AVAILABLE |  PCAN_CHANNEL_OCCUPIED), //!< The PCAN-Channel handle is already being used by a PCAN-View application, but is available to connect

    LOG_FUNCTION_DEFAULT = 0x00U,  //!< Logs system exceptions / errors
    LOG_FUNCTION_ENTRY = 0x01U,  //!< Logs the entries to the PCAN-Basic API functions
    LOG_FUNCTION_PARAMETERS = 0x02U,  //!< Logs the parameters passed to the PCAN-Basic API functions
    LOG_FUNCTION_LEAVE = 0x04U,  //!< Logs the exits from the PCAN-Basic API functions
    LOG_FUNCTION_WRITE = 0x08U,  //!< Logs the CAN messages passed to the CAN_Write function
    LOG_FUNCTION_READ = 0x10U,  //!< Logs the CAN messages received within the CAN_Read function
    LOG_FUNCTION_ALL = 0xFFFFU,  //!< Logs all possible information within the PCAN-Basic API functions

    TRACE_FILE_SINGLE = 0x00U,  //!< A single file is written until it size reaches PAN_TRACE_SIZE
    TRACE_FILE_SEGMENTED = 0x01U,  //!< Traced data is distributed in several files with size PAN_TRACE_SIZE
    TRACE_FILE_DATE = 0x02U,  //!< Includes the date into the name of the trace file
    TRACE_FILE_TIME = 0x04U,  //!< Includes the start time into the name of the trace file
    TRACE_FILE_OVERWRITE = 0x80U,  //!< Causes the overwriting of available traces (same name)
    TRACE_FILE_DATA_LENGTH = 0x100U, //!< Causes using the data length column ('l') instead of the DLC column ('L') in the trace file

    FEATURE_FD_CAPABLE = 0x01U,  //!< Device supports flexible data-rate (CAN-FD)
    FEATURE_DELAY_CAPABLE = 0x02U,  //!< Device supports a delay between sending frames (FPGA based USB devices)
    FEATURE_IO_CAPABLE = 0x04U,  //!< Device supports I/O functionality for electronic circuits (USB-Chip devices)

    SERVICE_STATUS_STOPPED = 0x01U,  //!< The service is not running
    SERVICE_STATUS_RUNNING = 0x04U,  //!< The service is running

    LAN_DIRECTION_READ = 0x01U,  //!< The PCAN-Channel is limited to incoming communication only
    LAN_DIRECTION_WRITE = 0x02U,  //!< The PCAN-Channel is limited to outgoing communication only
    LAN_DIRECTION_READ_WRITE = (LAN_DIRECTION_READ | LAN_DIRECTION_WRITE) // The PCAN-Channel communication is bidirectional
}