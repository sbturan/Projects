using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string path;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void upload_Click(object sender, EventArgs e)
        {
        
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "tiff (*.tiff,.tif)|*.tiff;*.tif";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                path = openFileDialog1.FileName;
                textBox1.Text = path;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            PdfDocument doc = new PdfDocument();
            doc.Pages.Add(new PdfPage());
            PdfSharp.Drawing.XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);
            XImage img = XImage.FromFile(path);
            string destinaton = path;
            destinaton=destinaton.Substring(0,destinaton.IndexOf('.'))+".pdf";
         
            xgr.DrawImage(img, 0, 0);
            try
            {
                string oldDestination = destinaton;
                int i = 2;
                while (File.Exists(destinaton))
                {
                    destinaton = oldDestination.Substring(0,oldDestination.IndexOf('.')) + "(" +i+")"+".pdf";
                    i++;

                }
               
                doc.Save(destinaton);
            }
            catch(Exception ex)
            {

                MessageBox.Show("Please Try Again Later");
            }
            MessageBox.Show("File Successfully Saved,"+destinaton);
            doc.Close();
        }
    }
}
