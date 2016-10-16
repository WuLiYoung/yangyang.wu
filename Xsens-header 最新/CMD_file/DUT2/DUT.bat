c:\\tools\\DUT2\\vdt.exe com4 core unlock > c:\\tools\\DUT2\\log.txt
c:\\tools\\DUT2\\vdt.exe com4 core unique >> c:\\tools\\DUT2\\log.txt
echo GetID >> c:\\tools\\DUT2\\log.txt
c:\\tools\\DUT2\\vdt.exe com4 power batteryvoltage >> c:\\tools\\DUT2\\log.txt
c:\\tools\\DUT2\\vdt.exe com4 Bluetooth btaddress >> c:\\tools\\DUT2\\log.txt
c:\\tools\\DUT2\\vdt.exe com4 flash writedata 0x100 /S "Test123" >> c:\\tools\\DUT2\\log.txt
c:\\tools\\DUT2\\vdt.exe com4 flash readdata 0x100 7 >> c:\\tools\\DUT2\\log.txt
