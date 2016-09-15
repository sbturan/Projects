

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SliderGallery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string _html = @"<div id='wrap'>
                      <ul id='mycarousel' class='jcarousel-skin-tango'>";
        if (new BannerBLL().GetTumBannerlar().Count > 0)
        {
            foreach (BannerInfo _bi in new BannerBLL().GetTumBannerlar())
            {
                if (_bi.YAYIN_DURUMU == true)
                {
                _html += string.Format(@"
					<li>
					    <div style=""width:400px;height:189px;"">
					        <table cellpadding=""0"" cellspacing=""0"" border=""0"" style=""height:189px; width:390px;background-color:#f6f5f4;"">
                               <tr>
                                <td align=""left"" valign=""top"" style=""width: 390px; heigt=189px""> <img style=""border:0"" width=""390"" height=""189"" src='resize.ashx?gen=390&yuk=189&tip=K&adres={0}' alt="""" /></td>
					                    </tr>
					                           
					                        
					        </table></div></li>", string.IsNullOrEmpty(_bi.DOSYA) ? "images/ImgLogo.png" : _bi.DOSYA, _bi.ID);
            }
            }
        }
       
        _html += "</ul></div>";
        ltHTML.Text = _html;
    }
}
