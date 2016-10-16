﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace TestMgr
{
    public class CIni
    {
        #region
        [DllImport("kernel32", EntryPoint = "GetPrivateProfileSectionNamesW", CharSet = CharSet.Unicode)]
        private extern static int getSectionNames([MarshalAs(UnmanagedType.LPWStr)] string szBuffer,
          int nlen, string filename);
        //这样的形式实际上是导入了  api  函数 

        [DllImport("kernel32", EntryPoint = "GetPrivateProfileSectionW", CharSet = CharSet.Unicode)]
        private extern static int getSectionValues(string Section,
            [
    MarshalAs
    (
    UnmanagedType
    .LPWStr)] 
string
     szBuffer,
    int
     nlen,
    string
     filename);

        #endregion

        #region



        [
        DllImport
        (
        "kernel32"
        , EntryPoint =
        "GetPrivateProfileIntW"
         , CharSet =
        CharSet
        .Unicode)]





        private

        static

        extern

        int
         getKeyIntValue(
        string
         Section,
        string
         Key,
        int
         nDefault,
        string

        FileName);



        [
        DllImport
        (
        "kernel32"
        , EntryPoint =
        "GetPrivateProfileStringW"

        ,
        CharSet
        =
        CharSet
        .Unicode)]




        private

        extern

        static

        int
         getKeyValue(
        string
         section,
        string
         key,
        int
         lpDefault,
                [
        MarshalAs
        (
        UnmanagedType
        .LPWStr)] 
string
         szValue,
        int
         nlen,
        string
         filename);





        [
        DllImport
        (
        "kernel32"
        , EntryPoint =
        "WritePrivateProfileStringW"
         , CharSet =
        CharSet
        .Unicode)]

        private

        static

        extern

        bool
         setKeyValue(
        string
         Section,
        string
         key,
        string
         szValue,
        string

        FileName);


        [
        DllImport
        (
        "kernel32"
        , EntryPoint =
        "WritePrivateProfileSectionW"
         , CharSet =
        CharSet
        .Unicode)]

        private

        static

        extern

        bool

        setSectionValue(
        string

        section,
        string

        szvalue,
        string

        filename
            );

        #endregion

        private static readonly char[] sept ={'\0'};
        private string m_Path = null;
        public string Path
        {
            set
            {
                m_Path = value;
            }
            get
            {
                return m_Path;
            }
        }

        public CIni() { }

        public CIni(string szPath)
        {
            m_Path = szPath;
        }

        public string[] SectionNames
        {
            get
            {
                string buffer = new string('\0', 32768);
                int nlen = getSectionNames(buffer, 32768 - 1, m_Path) - 1;
                if (nlen > 0)
                {
                    return buffer.Substring(0, nlen).Split(sept);
                }
                return null;
            }

        }

        public string[] SectionValues(string section,int bufferSize)
        {
            string buffer =new string('\0' , bufferSize);
            int nlen = getSectionValues(section, buffer, bufferSize, m_Path) - 1;
            if(nlen > 0)
            {
                return buffer.Substring(0, nlen).Split(sept);
            }
            return null;
        }

        public string[] SectionValues(string section)
        {
            return
             SectionValues(section, 32768);
        }

        public Dictionary<string,string> SectionValuesEx(
        string section,int bufferSize)
        {
            string[] sztmp = SectionValues(section, bufferSize);
            if(sztmp !=null)
            {
                int    ArrayLen = sztmp.Length;
                if(ArrayLen > 0)
                {
                    Dictionary
                    <
                    string
                    ,
                    string
                    > dtRet =
                    new

                    Dictionary
                    <
                    string
                    ,
                    string
                    >();

                    for
                     (
                    int
                     i = 0; i < ArrayLen; i++)
                    {

                        int
                         pos1 = sztmp[i].IndexOf(
                        '='
                        );
                        if
                         (pos1 > 1)
                        {
                            int
                             nlen = sztmp[i].Length;

                            pos1++;

                            if(pos1 < nlen)
                                dtRet.Add(sztmp[i].Substring(0, pos1 - 1), sztmp[i].Substring(pos1,nlen - pos1));
                        }
                    }

                    return dtRet;

                }

            }
            return null;
        }

        public

        Dictionary<string, string> SectionValuesEx(string section)
        {
            return SectionValuesEx(section, 32768);
        }
        public  bool setSectionValue(
        string
         section,
        string
         szValue)
        {
            return setSectionValue(section, szValue, m_Path);

        }

        public int getKeyIntValue(string section, string key)
        {
            return getKeyIntValue(section, key, -1, m_Path);

        }

        public bool setKeyIntValue(string section, string key, int dwValue)
        {

            return setKeyValue(section, key, dwValue.ToString(), m_Path);

        }

        public string getKeyValue(string section, string key)
        {
            string szBuffer = new string('0', 256);
            int nlen = getKeyValue(section, key, 0, szBuffer, 256, m_Path); 
            return szBuffer.Substring(0, nlen);
        }

        public bool setKeyValue(string Section, string key, string szValue)
        {
            return setKeyValue(Section, key, szValue, m_Path);
        }

    }
    //end class CIni  
}
