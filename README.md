# PCAN Mac Viewer

App for an ARM based MACs.

Uses PCBUSB Library to communicate with PCAN-USB interface.

## Instalation

1. ### Instalation of PCBUSB Library
    
    This needs to be setup first, as the app will crash without it (missing library detection is not implemented yet).

    Download the latest release from [MAC CAN Webpage](https://www.mac-can.com).

    In terminal opened at the folder with the downloaded compressed archive, perform either:

    `tar -xvf ~/path/to/file/macOS_Library_for_PCANUSB_vx.xx.tar`

    or:

    `tar -xzvf ~/path/to/file/macOS_Library_for_PCANUSB_vx.xx.tar.gz`

    to uncompresses the archive.

    Install the dylib:

    `cd PCBUSB`

    `sudo ./install.sh`

    and thats all, the library should be set up.

    (Btw all this commands are in the install.txt file in the library archive)

2. ### Install the PCAN_Mac viewer app
   
    Download the latest release of the app or build it yourself (you can find a tutorial for it [here](https://docs.avaloniaui.net/docs/reference/jetbrains-rider-ide/jetbrains-rider-setup))

    Double click the file or run `./PCAN_Mac` in the terminal.

    At first you will need to allow the execution of the app as it is not signed with Apple Developer accound and it will flag it as dangerous. Just go to the Settings -> Privacy & Security -> Security, find request of the app wanting to open and click Open anyway.

    There's a chance that the same procedure of allowing the program execution will be needed for the PCBUSB Library so just follow the same approach.

    After this initial setup, the app should start normally any time it is opened.

</br>
</br>
</br>

![Baudrate setup](/images/baudrate.png)
</br>

![CAN messages view](/images/viewer.png)


Created by Benjamin Lapos 2025