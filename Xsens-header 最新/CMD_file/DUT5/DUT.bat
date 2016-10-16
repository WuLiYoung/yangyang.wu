c:\\tools\\DUT5\\vdt.exe com49 core unlock > c:\\tools\\DUT5\\log.txt
c:\\tools\\DUT5\\vdt.exe com49 core unique >> c:\\tools\\DUT5\\log.txt
echo GetID >> c:\\tools\\DUT5\\log.txt
c:\\tools\\DUT5\\vdt.exe com49 power batteryvoltage >> c:\\tools\\DUT5\\log.txt
c:\\tools\\DUT5\\vdt.exe com49 Bluetooth btaddress >> c:\\tools\\DUT5\\log.txt
c:\\tools\\DUT5\\vdt.exe com49 flash writedata 0x100 /S "Test123" >> c:\\tools\\DUT5\\log.txt
c:\\tools\\DUT5\\vdt.exe com49 flash readdata 0x100 7 >> c:\\tools\\DUT5\\log.txt
