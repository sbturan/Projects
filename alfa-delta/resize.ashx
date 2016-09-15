    <%@ WebHandler Language="C#" Class="resize" %>

using System;
using System.Web;
using System.Drawing;
using System.IO;

public class resize : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        int yeniW = Convert.ToInt16(context.Request.QueryString["gen"]);
        int yeniH = Convert.ToInt16(context.Request.QueryString["yuk"]);

        string dosyayolu = "";
        string adres = Convert.ToString(context.Request.QueryString["adres"]);
        if (adres.ToString()!= "")
        {
        context.Response.ContentType = "image/jpg";

        if (context.Request.QueryString["tip"] == null)
            dosyayolu = @"Files\fotograflar\";
        else
            dosyayolu = @"";
        string URI =context.Server.MapPath(adres);
          
     
            using (Bitmap uploadedimage = new Bitmap(URI))
            {
                decimal genislik = uploadedimage.Width;
                decimal yukseklik = uploadedimage.Height;

                decimal gen_oran = (decimal)genislik / yeniW;
                decimal yuk_oran = (decimal)yukseklik / yeniH;

                int olacak_gen, olacak_yuk;

                if (gen_oran > yuk_oran)
                {
                    olacak_gen = (int)(genislik / yuk_oran);
                    olacak_yuk = yeniH;
                }
                else
                {
                    olacak_gen = yeniW;
                    olacak_yuk = (int)(yukseklik / gen_oran);
                }
                System.IO.Stream wClient = new System.Net.WebClient().OpenRead(URI);
                System.Drawing.Bitmap DestImage = new System.Drawing.Bitmap(uploadedimage.Width, uploadedimage.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                System.Drawing.Graphics.FromImage(DestImage).DrawImage(System.Drawing.Image.FromStream(wClient), new System.Drawing.Rectangle(0, 0, uploadedimage.Width, uploadedimage.Height), new System.Drawing.Rectangle(0, 0, uploadedimage.Width, uploadedimage.Height), System.Drawing.GraphicsUnit.Pixel);

                using (System.Drawing.Bitmap imgOutput = new System.Drawing.Bitmap(DestImage, olacak_gen, olacak_yuk))
                {
                    Graphics myresizer;
                    myresizer = Graphics.FromImage(imgOutput);
                    myresizer.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    myresizer.DrawImage(DestImage, 0, 0, olacak_gen, olacak_yuk);

                    imgOutput.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imgOutput.Dispose();
                    wClient.Close();
                    wClient.Dispose();
                }
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}