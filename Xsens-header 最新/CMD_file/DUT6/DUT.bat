c:\\tools\\DUT6\\vdt.exe com46 core unlock > c:\\tools\\DUT6\\log.txt
c:\\tools\\DUT6\\vdt.exe com46 core unique >> c:\\tools\\DUT6\\log.txt
echo GetID >> c:\\tools\\DUT6\\log.txt
c:\\tools\\DUT6\\vdt.exe com46 power batteryvoltage >> c:\\tools\\DUT6\\log.txt
c:\\tools\\DUT6\\vdt.exe com46 Bluetooth btaddress >> c:\\tools\\DUT6\\log.txt
c:\\tools\\DUT6\\vdt.exe com46 flash writedata 0x100 /S "Test123" >> c:\\tools\\DUT6\\log.txt
c:\\tools\\DUT6\\vdt.exe com46 flash readdata 0x100 7 >> c:\\tools\\DUT6\\log.txt
