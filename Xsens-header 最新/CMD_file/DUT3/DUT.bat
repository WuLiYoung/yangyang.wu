c:\\tools\\DUT3\\vdt.exe com43 core unlock > c:\\tools\\DUT3\\log.txt
c:\\tools\\DUT3\\vdt.exe com43 core unique >> c:\\tools\\DUT3\\log.txt
echo GetID >> c:\\tools\\DUT3\\log.txt
c:\\tools\\DUT3\\vdt.exe com43 power batteryvoltage >> c:\\tools\\DUT3\\log.txt
c:\\tools\\DUT3\\vdt.exe com43 Bluetooth btaddress >> c:\\tools\\DUT3\\log.txt
c:\\tools\\DUT3\\vdt.exe com43 flash writedata 0x100 /S "Test123" >> c:\\tools\\DUT3\\log.txt
c:\\tools\\DUT3\\vdt.exe com43 flash readdata 0x100 7 >> c:\\tools\\DUT3\\log.txt
