
     ﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AlfaDeltaLogin;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class Default2 : System.Web.UI.Page
{
    
    DataTable DT;
    List<KategoriInfo> info = new List<KategoriInfo>();
        KategoriBLL bur = new KategoriBLL();

        ArrayList aList = new ArrayList();
        
    protected void Page_Load(object sender, EventArgs e)
    {

        DropDownList drp = (DropDownList)form1.FindControl("drp");
        if (!Page.IsPostBack)
        {
           
            //veritabanından kategorilerimizi çekiyoruz
            SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=alfa-delta ;Integrated Security=SSPI;Pooling=false");
            baglanti.Open();
            DT = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            Adapter = new SqlDataAdapter("SELECT urun_kategoriID, ust_id, kadi FROM urun_kategori", baglanti);
            Adapter.Fill(DT);
            baglanti.Close();

            drp.Items.Clear();
            DataRow[] RootRows = DT.Select("ust_id=0 OR ust_id=-1");
            DDLDoldur(RootRows, "");
        }
    }

    //kategorileri dropdownlist'e dolduran metodumuz
    //buradaki drc, listeye doldurulacak olan kayıtları temsil ediyor.
    //girinti değişkeni ise her alt kategoride içeri girinti yapmamızı sağlayacak
    protected void DDLDoldur(DataRow[] drc, string girinti)
    {
        DropDownList drp = (DropDownList)form1.FindControl("drp");
        foreach (DataRow dr in drc)
        {
            //öncelikle listItem elemanını tanımlıyoruz
            ListItem li = new ListItem();
            //text özelliğine kategori adı
            li.Text = girinti + dr["kadi"].ToString();
            //value özelliğine kategori ID'si
            li.Value = dr["urun_kategoriID"].ToString();
            //ve elemanı listeye ekliyoruz
            drp.Items.Add(li);

            //döngüdeki her kategori (row) için alt kategoriler alınıyor.(varsa)
            DataRow[] SubRows = DT.Select("ust_id = " + dr["urun_kategoriID"].ToString());
            //ve aynı metodumuzu alt kategoriler için tekrar çağırıyoruz. Böylece alt kategorileir de listelemiş oluyoruz.
            DDLDoldur(SubRows, girinti + "---");
            //alt kategoriler bitene kadar metodun kendisini çağırma işlemi devam eder.
            //eğer alt kategori yoksa metod kesilir ve bir üst döngüye devam edilir
        }
    }
}





