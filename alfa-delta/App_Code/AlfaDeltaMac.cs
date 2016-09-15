using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Management;


/// <summary>
/// Summary description for EforMac
/// </summary>
/// 

    public class AlfaDeltaMac
    {
        public AlfaDeltaMac()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public String[] getMacAdress()
        {
            String[] macaddress = new String[2];

            macaddress[0] = "00:1A:64:C7:A9:FA";
            macaddress[1] = "00:24:8C:B8:D1:A2";

            return macaddress;
        }

        public bool maccheck()
        {
            bool durum = false;

            //MacAddresses mac = new MacAddresses();
            String[] curmaclist = new String[getMacAdress().Length];

            curmaclist = getMacAdress();

            ManagementObjectSearcher objMOS;
            ManagementObjectCollection objMOC;
            string sTR = "";

            objMOS = new ManagementObjectSearcher("Select * From Win32_NetworkAdapter");
            objMOC = objMOS.Get();

            foreach (ManagementObject objMO in objMOC)
            {

                if (objMO["MACAddress"] != null)
                {
                    for (int i = 0; i < curmaclist.Length; i++)
                    {
                        sTR = objMO["MACAddress"].ToString();
                        if (sTR == curmaclist[i])
                        {
                            durum = true;
                            break;
                        }

                    }
                    if (durum == true)
                        break;
                }




            }

            objMOS.Dispose();

            objMOS = null;

            return durum;

        }
    }
