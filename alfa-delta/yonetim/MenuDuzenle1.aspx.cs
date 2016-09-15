using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using System.Data.SqlClient;
public partial class yonetim_MenuDuzenle1 : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    DataTable DT;
    protected void Page_Load(object sender, EventArgs e)
    {
        Bind();
        if (!IsPostBack)
        {
            hdn_Deger.Value = "";
        }
        if (!Page.IsPostBack)
        {

            SqlConnection baglanti = new SqlConnection("Data Source=mssql195.win-servers.com;Initial Catalog=alfadelta;User ID=alfadelta;Password=adx9080");
            baglanti.Open();
            DT = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter();
            Adapter = new SqlDataAdapter("SELECT * FROM icerik where dil='en'", baglanti);

            Adapter.Fill(DT);
            baglanti.Close();


            //DropDownList drp = ((frm_AltSayfaDuzen.FindControl("DropDownList1") as DropDownList));
            //drp.Items.Clear();
          
            DataRow[] RootRows = DT.Select();
            foreach (DataRow dr in RootRows)
            {
                ListItem li = new ListItem();

                li.Text = dr["konu"].ToString();

                li.Value = dr["id"].ToString();

                DropDownList3.Items.Add(li);
                DropDownList2.Items.Add(li);
            }
        }

    }

    public void yazdir(int ID, TreeNode prmNode)
    {
        DataTable dtAltKategori = new DataTable();
        MenuDAL dal = new MenuDAL();
        //dtKategori.Rows.Clear();
        //dtKategori.Columns.Clear();
        dtAltKategori = dal.GetByAnaMenuGrup(ID);
        if (dtAltKategori.Rows.Count > 0)
        {
            for (int i = 0; i < dtAltKategori.Rows.Count; i++)
            {
                TreeNode bolum = new TreeNode();
                bolum.Text = Convert.ToString(dtAltKategori.Rows[i]["adi"]);
                bolum.Value = Convert.ToString(dtAltKategori.Rows[i]["menu_ID"]);
                prmNode.ChildNodes.Add(bolum);
                yazdir(Convert.ToInt32(dtAltKategori.Rows[i]["menu_ID"]), prmNode.ChildNodes[i]);
                dtAltKategori.Clear();
                dtAltKategori = dal.GetByAnaMenuGrup(ID);
            }
        }
    }

    public void Bind()
    {
        TreeView1.Nodes.Clear();

        MenuDAL bll = new MenuDAL();
        List<MenuInfo> info = new List<MenuInfo>();
        dt = bll.GetAll3();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (Convert.ToInt32(dt.Rows[i]["ana_menu_grup"].ToString()) == 0)
            {
                TreeNode dugum = new TreeNode();
                dugum.Text = Convert.ToString(dt.Rows[i]["adi"]);
                dugum.Value = Convert.ToString(dt.Rows[i]["menu_ID"]);
                TreeView1.Nodes.Add(dugum);
                yazdir(Convert.ToInt32(dt.Rows[i]["menu_ID"]), TreeView1.Nodes[i]);
                dt.Clear();
                dt = bll.GetAll3();
            }
        }
        dt.Clear();
    }

    protected void btn_Yeni_Click(object sender, EventArgs e)
    {
        if (hdn_Deger.Value != "")
        {
            MenuBLL bl = new MenuBLL();
            MenuInfo inf = new MenuInfo();
            inf = bl.MenuByID(Convert.ToInt32(hdn_Deger.Value));

            Label1.Text = "Şu anda '" + inf.ADI + "' menüsüne Ekliyorsunuz.";
            btn_Guncelle.Text = "Ekle";
        }
        else
        {
            Label1.Text = "Şu anda Ana Menü Ekliyorsunuz.";
            btn_Guncelle.Text = "Ekle";
        }
        ModalPopupExtender1.Show();
    }
    protected void sayfaGoster_Click(object sender, EventArgs e)
    {
        ModalPopupExtender1.Hide();
        ModalPopupExtender2.Show();
    }

    protected void btn_Guncelle_Click(object sender, EventArgs e)
    {
        ModalPopupExtender2.Hide();
        ModalPopupExtender1.Show();
        Label1.Text = txt_MenuAd.Text;
        //UpdatePanel1.Update();
        ModalPopupExtender1.Show();

    }
    protected void btn_Kapat2_Click(object sender, EventArgs e)
    {
        ModalPopupExtender2.Hide();
        ModalPopupExtender1.Show();
    }

    protected void GetImageBrowser(object sender, EventArgs e)
    {
        string url = "";

        if (sender.GetType().ToString().Contains("Button"))
        {
            ((Button)sender).OnClientClick = "return openFileBrowser(this, 'fotograflar" + url + "', '" + "');";
        }
        else
        {
            ((FredCK.FCKeditorV2.FCKeditor)sender).ImageBrowserURL = "../filemanager/browser/default/browser.html?Type=fotograflar" + url + "&Connector=connectors/aspx/connector.aspx";
        }

    }

    protected void GetImageBrowser2(object sender, EventArgs e)
    {
        string url = "";

       

    }

    protected void btn_Guncelle_Click1(object sender, EventArgs e)
    {
        MenuBLL menuBLL = new MenuBLL();
        MenuInfo menuINFO = new MenuInfo();
        int ustMenuGrup = 0;
        if (hdn_Deger.Value != "")
        {
            ustMenuGrup = Convert.ToInt32(hdn_Deger.Value);
            menuINFO.MENU_GRUP = 2;
        }
        else
        {
            ustMenuGrup = 0;
            menuINFO.MENU_GRUP = 0;
        }

        menuINFO.SIRA = menuBLL.GetSira(ustMenuGrup);
        menuINFO.ADI = txt_MenuAd.Text;
        menuINFO.ANA_MENU_GRUP = ustMenuGrup;
        menuINFO.LINK = "altsayfa.aspx?=" + DropDownList2.SelectedItem.Value;
        if (txt_MenuAd.Text.Length > 10 || txt_MenuAd.Text.Length <= 15)
            menuINFO.GENISLIK = 100;
        if (txt_MenuAd.Text.Length >= 5 || txt_MenuAd.Text.Length <= 10)
            menuINFO.GENISLIK = 74;
        if (txt_MenuAd.Text.Length < 5)
            menuINFO.GENISLIK = 40;
        if (txt_MenuAd.Text.Length > 15)
            menuINFO.GENISLIK = 150;
        menuINFO.YAYIN_DURUMU = 1;
        menuINFO.DIL = "en";
        menuBLL.Insert(menuINFO);
        lbl_Uyari.Visible = true;
        lbl_Uyari.Text = "Kayıt Eklenmiştir.";
        ModalPopupExtender1.Show();
    }
    protected void btn_Cancel_Click(object sender, EventArgs e)
    {
        ModalPopupExtender1.Hide();
        txt_MenuAd.Text = "";

        lbl_Uyari.Visible = false;
        Label1.Text = "";
        hdn_Deger.Value = "";
   
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //hdn_Deger.Value=
    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Sec":
                e.Item.BackColor = System.Drawing.Color.Aqua;
                hdn_Deger.Value = e.CommandArgument.ToString();
                break;
        }
    }
    protected void btn_Duzenle_Click(object sender, EventArgs e)
    {
        if (hdn_Deger.Value == "")
        {
            lbl_hata.Visible = true;
            lbl_hata.Text = "Lütfen Güncellenecek Menüyü Seçiniz.";
        }
        else
        {
            int id = Convert.ToInt32(hdn_Deger.Value);
            MenuDAL dal = new MenuDAL();
            MenuInfo inf = new MenuInfo();
            inf = dal.MenuByID(id);
            txt_MenuAdEdit.Text = inf.ADI;
            string a= inf.LINK.ToString();
            //DropDownList3.SelectedValue = inf.LINK;
            if (inf.LINK.Contains("alt") || a.Length == 0)
            {

                string abc = inf.LINK.Substring(17);
                DropDownList3.Visible = true;
                int b = int.Parse(abc);

                DropDownList3.SelectedValue = b.ToString(); 

            }
            else
            {
                DropDownList3.Visible = false;

            }
            hdn_AnaGrupID.Value = inf.ANA_MENU_GRUP.ToString();
            hdn_EditSira.Value = inf.SIRA.ToString();
           
            ModalPopupExtender3.Show();
        }
    }
    protected void btn_Sil_Click(object sender, EventArgs e)
    {
        MenuBLL bll = new MenuBLL();
        MenuDAL dal = new MenuDAL();
        MenuInfo inf = new MenuInfo();
        if (hdn_Deger.Value == "")
        {
            lbl_hata.Visible = true;
            lbl_hata.Text = "Lütfen Silinecek Menüyü Seçiniz.";
        }
        else
        {
            if (bll.AltiVarmi(Convert.ToInt32(hdn_Deger.Value)) == true) // alti var silinemez...
            {
                lbl_hata.Visible = true;
                lbl_hata.Text = "Seçilen Menünün Alt Menüleri Vardır. Silemezsiniz.";
            }
            else // altı yok silinebilir.
            {
                inf.ID = Convert.ToInt32(hdn_Deger.Value);
                bll.Delete(inf);
                lbl_hata.Visible = true;
                lbl_hata.Text = "Seçilen Menü Silinmiştir.";
                Response.Redirect(HttpContext.Current.Request.RawUrl);
            }
        }
    }
    protected void btn_CancelEdit_Click(object sender, EventArgs e)
    {
        txt_MenuAdEdit.Text = "";
        DropDownList3.Items.Add("");
       
        hdn_Deger.Value = "";
        ModalPopupExtender3.Hide();
    }
    protected void btn_GuncelleEdit_Click(object sender, EventArgs e)
    {
        MenuBLL bl = new MenuBLL();
        MenuInfo inf = new MenuInfo();
        inf = bl.MenuByID(Convert.ToInt32(hdn_Deger.Value));
        inf.ID = Convert.ToInt32(hdn_Deger.Value);

        inf.ADI = txt_MenuAdEdit.Text;
       
        if (inf.LINK.Contains("alt"))
        {
            DropDownList3.Visible = true;
            inf.LINK = "altsayfa.aspx?ID=" + DropDownList3.SelectedItem.Value;
        }
        else
        {

            inf.LINK = inf.LINK;
        }

        inf.ANA_MENU_GRUP = Convert.ToInt32(hdn_AnaGrupID.Value);
        inf.SIRA = Convert.ToInt32(hdn_EditSira.Value);

        string resim = "";
     

        bl.Update(inf);
        lbl_UyariEdit.Visible = true;
        lbl_UyariEdit.Text = "Menü Güncellenmiþtir.";
        ModalPopupExtender3.Show();
    }
    protected void btn_Yukari_Click(object sender, EventArgs e)
    {
        if (hdn_Deger.Value == "")
        {
            lbl_hata.Visible = true;
            lbl_hata.Text = "Lütfen Menü Seçiniz.";
        }
        else
        {
            MenuBLL bl = new MenuBLL();
            MenuInfo inf = new MenuInfo();

            inf = bl.MenuByID(Convert.ToInt32(hdn_Deger.Value));

            if (bl.Yukari(inf.ANA_MENU_GRUP, inf.ID))
            {
                lbl_hata.Visible = true;
                lbl_hata.Text = "İşleminiz Yapılmıştır";
                Bind();
            }
            else
            {
                lbl_hata.Visible = true;
                lbl_hata.Text = "İşleminiz Yapılmıştır";
            }

        }
    }
    protected void btn_Asagi_Click(object sender, EventArgs e)
    {
        if (hdn_Deger.Value == "")
        {
            lbl_hata.Visible = true;
            lbl_hata.Text = "Lütfen Menü Seçiniz.";
        }
        else
        {
            MenuBLL bl = new MenuBLL();
            MenuInfo inf = new MenuInfo();

            inf = bl.MenuByID(Convert.ToInt32(hdn_Deger.Value));

            if (bl.Asagi(inf.ANA_MENU_GRUP, inf.ID))
            {
                lbl_hata.Visible = true;
                lbl_hata.Text = "İşleminiz Yapılmıştır";
                Bind();
            }
            else
            {
                lbl_hata.Visible = true;
                lbl_hata.Text = "İşleminiz Yapılmıştır";
            }

        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        hdn_Deger.Value = "";
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        lbl_hata.Visible = true;
        lbl_hata.Text = this.TreeView1.SelectedNode.Text + "  (" + this.TreeView1.SelectedNode.Value + ")";
        hdn_Deger.Value = this.TreeView1.SelectedNode.Value;
    }
    protected void TreeView1_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
    {
        //lbl_hata.Visible = true;
        //lbl_hata.Text = e.Node.Text;
    }

}
