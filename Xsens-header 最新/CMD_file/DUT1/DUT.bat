c:\\tools\\DUT1\\vdt.exe com41 core unlock > c:\\tools\\DUT1\\log.txt
c:\\tools\\DUT1\\vdt.exe com41 core unique >> c:\\tools\\DUT1\\log.txt
echo GetID >> c:\\tools\\DUT1\\log.txt
c:\\tools\\DUT1\\vdt.exe com41 power batteryvoltage >> c:\\tools\\DUT1\\log.txt
c:\\tools\\DUT1\\vdt.exe com41 Bluetooth btaddress >> c:\\tools\\DUT1\\log.txt
c:\\tools\\DUT1\\vdt.exe com41 flash writedata 0x100 /S "Test123" >> c:\\tools\\DUT1\\log.txt
c:\\tools\\DUT1\\vdt.exe com41 flash readdata 0x100 7 >> c:\\tools\\DUT1\\log.txt
