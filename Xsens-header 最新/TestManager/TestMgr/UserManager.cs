using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStudio.Automation.TestManager.libCommon.Class;

using System.Security.Cryptography;

namespace TestMgr
{
    class UserManager
    {
        User_Infor m_CurrUser = null;

        List<User_Infor> m_UserList=new List<User_Infor>();
        CIni m_userlist = new CIni();
        
        public bool ChangeUser(User_Infor user)
        {
            return true;
        }

        public User_Infor GetCurrUser()
        {
            return m_CurrUser;
        }

        public bool AddUser(User_Infor user)
        {
            m_UserList.Add(user);
            return true;
        }

        public bool RemoveUser(string name)
        {
            return true;
        }
        public bool LoadFromFile(string filepath)
        {
            return true;
        }
        public bool SaveToFile(string filepath)
        {
            return true;
        }
        public User_Infor FindUser(string name)
        {
            foreach(User_Infor u in m_UserList)
            {
                if (name.ToUpper()==u.Name.ToUpper())
                {
                    return u;
                }
            }
            return null;
        }

        public bool CheckUser(string name,string pwd)
        {
            User_Infor u = FindUser(name);
            if (u != null)
                return true;
            return false;
        }

        public bool UpdateUser(User_Infor u)
        {
            return true;
        }

        string GetHashCode(string pwd)
        {
            //获取加密服务
            MD5CryptoServiceProvider md5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();

            //获取要加密的字段，并转化为Byte[]数组
            byte[] testEncrypt = System.Text.Encoding.Unicode.GetBytes(pwd);

            //加密Byte[]数组
            byte[] resultEncrypt = md5CSP.ComputeHash(testEncrypt);
          
            //将加密后的数组转化为字段(普通加密)
            string testResult = System.Text.Encoding.Unicode.GetString(resultEncrypt);

            return testResult;

            //作为密码方式加密 
            //string PWD = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(test, "MD5");
        }
    }
}
