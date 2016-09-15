using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

public partial class kutuphane_yorumlar : System.Web.UI.UserControl
{
    public string musteriYorumlar = "";
    //public int siraID = 0;
    private int _siraID;

    public int SIRA_ID
    {
        get { return _siraID; }
        set
        {
            _siraID = 0;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        #region Comment
        //List<DefterInfo> myDefterList = new List<DefterInfo>();
        //DefterBLL myDefter = new DefterBLL();
        //myDefterList = myDefter.GetList(1);

        //foreach (DefterInfo defterim in myDefterList)
        //{
        //    musteriYorumlar += "<table style=\"width: 380px; color:#7f7f7f; padding-left:10px; font-size: 15px; font-family: Myriad Pro \">";
        //    musteriYorumlar += "<tr>";
        //    musteriYorumlar += "<td style=\"width:300px\">";
        //    musteriYorumlar += "<b>" + defterim.KONU.ToString() + "</b>";
        //    musteriYorumlar += "</td>";
        //    musteriYorumlar += "</tr>";
        //    musteriYorumlar += "<tr>";
        //    musteriYorumlar += "<td style=\"width:300px\">";
        //    musteriYorumlar += defterim.ACIKLAMA;
        //    musteriYorumlar += "</td>" + "</tr>" + "</table>";
        //}
        #endregion

        DefterInfo myDefterInfo = new DefterInfo();
        DefterDAL myDefterDal = new DefterDAL();
        List<DefterInfo> myDefterList = new List<DefterInfo>();
        myDefterList = myDefterDal.GetList(1);
        Random rnd = new Random();
        Random rnd2 = new Random();


        int rndSayim = Convert.ToInt32(rnd.Next(0, myDefterList.Count));
        musteriYorumlar += "<table style=\"height:71px;width: 383px;color:#7f7f7f; padding-left:10px; font-size: 8.5pt; font-family: Arial \">";
        musteriYorumlar += "<tr>";
        musteriYorumlar += "<td style=\"\">";
        musteriYorumlar += "<a href=\"MusteriYorumDetay.aspx?ID=" + myDefterList[rndSayim].ID + "\" style=\"color:#7f7f7f;border:0px;text-decoration:none\">";
        musteriYorumlar += "<b>" + myDefterList[rndSayim].KONU.ToString() + "</b>";
        musteriYorumlar += "</a>";
        musteriYorumlar += "</td>";
        musteriYorumlar += "</tr>";
        musteriYorumlar += "<tr>";
        musteriYorumlar += "<td style=\"text-align:justify;\">";
        musteriYorumlar += myDefterList[rndSayim].ACIKLAMA;
        musteriYorumlar += "&nbsp;&nbsp;<a href=\"MusteriYorumDetay.aspx?ID=" + myDefterList[rndSayim].ID + "\" style=\"color: #7f7f7f; font-weight: normal;" +
                                            "font-family: Arial; font-size: 11px;\"><b>[Devamý]</b></a>";
        musteriYorumlar += "</td>" + "</tr>" + "</table>";


        int rndSayim2 = Convert.ToInt32(rnd2.Next(1, myDefterList.Count));
        musteriYorumlar += "<table style=\"height:70px;width: 383px;color:#7f7f7f; padding-left:10px; font-size: 8.5pt; font-family: Arial \">";
        musteriYorumlar += "<tr>";
        musteriYorumlar += "<td style=\"\">";
        musteriYorumlar += "<a href=\"MusteriYorumDetay.aspx?ID=" + myDefterList[rndSayim2].ID + "\" style=\"color:#7f7f7f;border:0px;text-decoration:none\">";
        musteriYorumlar += "<b>" + myDefterList[rndSayim2].KONU.ToString() + "</b>";
        musteriYorumlar += "</a>";
        musteriYorumlar += "</td>";
        musteriYorumlar += "</tr>";
        musteriYorumlar += "<tr>";
        musteriYorumlar += "<td style=\"text-align:justify;\">";
        musteriYorumlar += myDefterList[rndSayim2].ACIKLAMA;
        musteriYorumlar += myDefterList[rndSayim2].ACIKLAMA;
        musteriYorumlar += "&nbsp;&nbsp;<a href=\"MusteriYorumDetay.aspx?ID=" + myDefterList[rndSayim2].ID + "\" style=\"color: #7f7f7f; font-weight: normal;" +
                                            "font-family: Arial; font-size: 11px;\"><b>[Devamý]</b></a>";
        musteriYorumlar += "</td>" + "</tr>" + "</table>";

        //int rndSayim3 = Convert.ToInt32(rnd.Next(2, myDefterList.Count));
        //musteriYorumlar += "<table style=\"width: 300px;color:#7f7f7f; padding-left:10px; font-size: 15px; font-family: Arial \">";
        //musteriYorumlar += "<tr>";
        //musteriYorumlar += "<td style=\"\">";
        //musteriYorumlar += "<b>" + myDefterList[rndSayim3].KONU.ToString() + "</b>";
        //musteriYorumlar += "</td>";
        //musteriYorumlar += "</tr>";
        //musteriYorumlar += "<tr>";
        //musteriYorumlar += "<td style=\"\">";
        //musteriYorumlar += myDefterList[rndSayim3].ACIKLAMA;
        //musteriYorumlar += "</td>" + "</tr>" + "</table>";

        #region Refresh olayý iptal oldu COMMENT
        //else
        //{
        //    musteriYorumlar += "<table style=\"width: 380px; color:#7f7f7f; padding-left:10px; font-size: 15px; font-family: Myriad Pro \">";
        //    musteriYorumlar += "<tr>";
        //    musteriYorumlar += "<td style=\"width:300px\">";
        //    musteriYorumlar += "<b>" + myDefterList[siraID].KONU.ToString() + "</b>";
        //    musteriYorumlar += "</td>";
        //    musteriYorumlar += "</tr>";
        //    musteriYorumlar += "<tr>";
        //    musteriYorumlar += "<td style=\"width:300px\">";
        //    musteriYorumlar += myDefterList[siraID].ACIKLAMA;
        //    musteriYorumlar += "</td>" + "</tr>" + "</table>";
        //}

        //if (this.Page.IsCallback)
        //{
        //    Response.Write("CALL BACK ÝSE ");
        //}
        //if(!this.Page.IsCallback)
        //    Response.Write("CALL BACK DEÐÝL :: ");



        ////this.Page.Request.
        #endregion


    }
}
