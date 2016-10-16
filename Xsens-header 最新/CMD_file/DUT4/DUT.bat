c:\\tools\\DUT4\\vdt.exe com44 core unlock > c:\\tools\\DUT4\\log.txt
c:\\tools\\DUT4\\vdt.exe com44 core unique >> c:\\tools\\DUT4\\log.txt
echo GetID >> c:\\tools\\DUT4\\log.txt
c:\\tools\\DUT4\\vdt.exe com44 power batteryvoltage >> c:\\tools\\DUT4\\log.txt
c:\\tools\\DUT4\\vdt.exe com44 Bluetooth btaddress >> c:\\tools\\DUT4\\log.txt
c:\\tools\\DUT4\\vdt.exe com44 flash writedata 0x100 /S "Test123" >> c:\\tools\\DUT44\\log.txt
c:\\tools\\DUT4\\vdt.exe com44 flash readdata 0x100 7 >> c:\\tools\\DUT4\\log.txt
