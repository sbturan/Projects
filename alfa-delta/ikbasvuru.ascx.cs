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
using System.Text;


public partial class kutuphane_ikbasvuru : System.Web.UI.UserControl
{
   
    public IkInfo ikINFO = new IkInfo();
    string dosyaYolu;
    public Button Gonder
    {
        get { return btn_Gonder; }
        set { btn_Gonder = value; }

    }

    public Button Vazgec
    {
        get { return btn_Vazgec; }
        set { btn_Vazgec = value; }

    }

    public RequiredFieldValidator ZorunluAd
    {
        get { return rqf_Adi; }
        set { rqf_Adi = value; }

    }

    public RequiredFieldValidator ZorunluSoyAd
    {
        get { return rqf_Soyadi; }
        set { rqf_Soyadi = value; }

    }

    public RequiredFieldValidator ZorunluTelefon
    {
        get { return rqf_Telefon; }
        set { rqf_Telefon = value; }

    }

    public RequiredFieldValidator ZorunluEmail
    {
        get { return rqf_Email; }
        set { rqf_Email = value; }

    }

    public RegularExpressionValidator GecerliEmail
    {
        get { return rge_Email; }
        set { rge_Email = value; }

    }

    
    public RequiredFieldValidator ZorunluDosya
    {
        get { return rqf_Dosya; }
        set { rqf_Dosya = value; }
    }

    public Label Adi
    {
        get { return lbl_Adi; }
        set { lbl_Adi = value; }

    }

    public Label SoyAdi
    {
        get { return lbl_Soyadi; }
        set { lbl_Soyadi = value; }

    }
    public Label Telefon
    {
        get { return lbl_Telefon; }
        set { lbl_Telefon = value; }

    }

    public Label Email
    {
        get { return lbl_Email; }
        set { lbl_Email = value; }

    }


   


    public Label Dosya
    {
        get { return lbl_Dosya; }
        set { lbl_Dosya = value; }

    }
    public string RastgeleKelime()
    {


        string kelime = "";
        Random rnd = new Random();
        for (int i = 0; i <= 6; i++)
        {

            kelime += ((char)rnd.Next('A', 'Z')).ToString();

        }
        return kelime;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Session["abcdef"] = RastgeleKelime();
            panpi.Text = Session["abcdef"].ToString();
        }
        if (Session["dil"] == "en")
        {
            lbl_Adi.Text = "Name";
            lbl_Soyadi.Text="Surname";
            lbl_Telefon.Text="Phone Number";
            lbl_Email.Text="Email";
            lbl_Dosya.Text="Upload File";
            lbl_Dosya0.Text = "Security Code";
            lbl_Dosya1.Text = "Verify Code";
            btn_Gonder.Text = "Send";
            btn_Vazgec.Text = "Cancel";
            Label1.Text = "What is the questions?";
        }
       
        
        
        if (Session["KullaniciID"] != null)
        {
           int userid = Convert.ToInt32(Session["KullaniciID"].ToString());
            UsersInfo info = new UsersBLL().BulByID(userid);
            txt_Adi.Text = info.Adi;
            txt_Soyadi.Text = info.Soyadi;
            txt_Email.Text = info.Email;
            if (info.Telefon != null)
            {
                txt_Telefon.Text = info.Telefon;
            }
            
        }



      
            Adi.Text = "Ad (*) : ";
            SoyAdi.Text = "Soyadi (*) : ";
            Telefon.Text = "Telefon (*): ";
            Email.Text = "Email (*): ";

            Dosya.Text = "Yüklenecek Dosya (*): ";
            Gonder.Text = "Gonder";
            Vazgec.Text = "İptal";
            rqf_Adi.ErrorMessage = "Adı alanı zorunlu";

            rqf_Soyadi.ErrorMessage = "Soyadı alanı zorunlu";
            rqf_Telefon.ErrorMessage = "Telefon alanı zorunlu";
            rqf_Email.ErrorMessage = "Email alanı zorunlu";
            rge_Email.ErrorMessage = "Email formatı hatalı";
            rqf_Dosya.ErrorMessage = "Dosya alanı zorunlu";
            lbl_Bilgi.Text = "Tüm alanlar zorunludur.";


        

            int idd;
        if (Request.QueryString["ID"] != null)
        {
            idd = Convert.ToInt32(Request.QueryString["ID"]);
            IkBLL ikBLL = new IkBLL();
            ikINFO = ikBLL.GetBilgiByID(idd, 1);



        }

        this.Page.Title = ConfigurationManager.AppSettings.Get("title").ToString() + "  " + "Özel Çizim Formu";

    }
    protected void btn_Gonder_Click(object sender, EventArgs e)
    {


        if (Session["abcdef"].ToString() != txtCaptcha.Text)
        {

            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "webformdesigner", "alert('Güvenlik Kodunu Kontrol Ediniz  ');", true);
        }
        else
        {
            try
            {

                IkDetayBLL ikdetayBLL = new IkDetayBLL();

                IkDetayInfo ikdetayINFO = new IkDetayInfo();

                string dosya = "";

                string zaman = DateTime.Now.ToString();

                //if (uplDosya.HasFile)
                //{
                //   uplDosya.SaveAs(Server.MapPath("Files") + "\\" + uplDosya.FileName);
                //}
                //else
                //    Response.Write("Upload edilecek dosya yok");



                if (flp_Dosya.HasFile)
                {
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(flp_Dosya.PostedFile.FileName);
                    int dosyaBoyut = flp_Dosya.PostedFile.ContentLength;

                    string uzanti = "";
                    uzanti = fileInfo.Name.Substring(fileInfo.Name.LastIndexOf(".") + 1);
                    string dosyaadi = "d:\\websites\\mysun\\alfa-delta.com\\wwwroot\\yonetim\\" +flp_Dosya.FileName.ToString();
                    dosyaYolu = "yonetim\\dosyalar" + "\\" + flp_Dosya.FileName;
                 //   flp_Dosya.SaveAs(Server.MapPath("yonetim") + "\\" + flp_Dosya.FileName);

                    if (dosyaBoyut < 10000000)
                    {

                        // bool validformat = (flp_Dosya.PostedFile.ContentType == "application/msword");

                        //if (validformat == true)
                        //{

                        FileUploadHelper fuHelper = new FileUploadHelper(dosyaadi, flp_Dosya);

                        // Maksimum dosya boyutu 1MB :
                        int maxUpload = 300 * 1024;
                        fuHelper.MaxUploadSize = maxUpload;

                        fuHelper.UploadFile();
                        dosya = dosyaadi;

                        ikdetayINFO.ADI = SqlInject.InjectionManager.RejectInjection(txt_Adi.Text);
                        ikdetayINFO.SOYADI = SqlInject.InjectionManager.RejectInjection(txt_Soyadi.Text);
                        ikdetayINFO.EMAIL = SqlInject.InjectionManager.RejectInjection(txt_Email.Text);
                        ikdetayINFO.SORU = SqlInject.InjectionManager.RejectInjection(TextBox1.Text);
                        ikdetayINFO.DOSYA = dosya;

                        ikdetayINFO.TELEFON = SqlInject.InjectionManager.RejectInjection(txt_Telefon.Text);


                        ikdetayBLL.Insert(ikdetayINFO);


                        lbl_Mesaj.Text = "Kaydınız başarı ile alındı.";




                    }


                        //else
                    //{

                          //      lbl_Mesaj.Text = "Dosya yüklenemedi. ";
                    //    lbl_Mesaj.Text += "Dosya bozuk veya dosya doc formatında değil";



                        //}



                   // }
                    else
                    {

                        dosya = "";


                        lbl_Mesaj.Text = "Yüklenen dosya 300 KB dan küçük olmalı";


                    }

                }
            }
            catch (Exception ex) {
                lbl_Mesaj.Visible = true;
                lbl_Mesaj.Text = ex.ToString();
                MessageBox.Show(ex.ToString());
            
            }
        }
    }
}
