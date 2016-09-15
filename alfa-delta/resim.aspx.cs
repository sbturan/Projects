﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
public partial class resim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Bitmap bmp = new Bitmap(100, 30);
        Graphics g = Graphics.FromImage(bmp);
        g.Clear(Color.Black);

        string metin = RastgeleKelime();
        Session["gResim"] = metin;
        Font font = new Font("Arial", 12);
        g.DrawString(metin, font, Brushes.Aqua, 5, 5);
        bmp.Save(Response.OutputStream, ImageFormat.Png);
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
}