using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SensDut
{

    public class IMUData
    {
        public enum DataID
        {
            kItemID = 0x90,   /* 1 x uint8_t*/
            kItemIPAdress = 0x92,   /* 1 x uint32_t */
            kItemAccRaw = 0xA0,   /* 3 x int16_t */
            kItemAccRawFiltered = 0xA1,   /* 3 x int16_t */
            kItemGyoRaw = 0xB0,   /* 3 x int16_t */
            kItemGyoRawFiltered = 0xB1,   /* 3 x int16_t */
            kItemMagRaw = 0xC0,   /* 3 x int16_t */
            kItemMagRawFiltered = 0xC1,   /* 3 x int16_t */
            kItemAtdE = 0xD0,   /* 3 x int16_t */
            kItemAtdQ = 0xD1,   /* 4 x float */
            kItemTemp = 0xE0,   /* 1 x float */
            kItemPressure = 0xF0,   /* 1 x float */
            kItemEnd = 0xFF,   /*  */
        };

        public byte ID;
        public Int16[] AccRaw = new Int16[3];
        public Int16[] GyroRaw = new Int16[3];
        public Int16[] MagRaw = new Int16[3];
        public float[] AtdE = new float[3];
        public float[] AtdQ = new float[4];
        public Int32 Pressure;
        public Int32 Temperature;

        //private class ItemsLen
        //{
        //    public DataID id;
        //    public UInt16 len;
        //};

        //private ItemsLen[] len = new ItemsLen[Enum.GetNames(typeof(DataID)).Length];

        public IMUData()
        {
        }
    }
}
