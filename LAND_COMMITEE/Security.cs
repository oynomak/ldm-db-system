using System;
using System.Collections.Generic;
using System.Text;

namespace LAND_COMMITEE
{
    class Security
    {
        public string encrypt(string str,string priv,int what2do)
        {
            
            string all;
            if (what2do == 0)
            {
                str = str + priv;
            }
            str = str.ToLower();
            char[] pass;
            char[] first ={ 'a', 'b', 'c','?', 'd', 'e','$', 'f', 'g', 'h', 'i','}', 'j', 'k', 'l', 'm','+', '0', '1', '2', '3','@', '4' };
            char[] second ={ 'n', 'o', ';','p', 'q', '&','r', 's', 't', 'u', '[','v', 'w', 'x', 'y', '=','z', '5', '6', '7', '8','^', '9' };
            pass=str.ToCharArray();
            string ret="";
            int a = pass.Length;
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < 17; j++)
                { 
                    if(first[j]==pass[i])
                        ret = ret + second[j];
                    else if(second[j]==pass[i])
                        ret = ret + first[j];
                }
                    
            }
            return ret;
        }
        public bool Valid_Pass(string written, string fromDB)
        {
            fromDB = fromDB.Substring(0, written.Length);
            if (written.Equals(fromDB))
                return true;
            else
                return false;
        }
        public bool VerifyPrivilege(string written,string fromDB)
        {
            string a = encrypt(fromDB.Substring(written.Length),"",1);
            if (a == "administrator")
                return true;
            else
                return false;
        }
    }
}
