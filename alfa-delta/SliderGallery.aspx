<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SliderGallery.aspx.cs" Inherits="SliderGallery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <link href="css/ScrollableSlider.css" type="text/css" rel="stylesheet"/>
   <script type="text/javascript" src="js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="js/jquery.jcarousel.min.js"></script>

     <script type="text/javascript">
         jQuery(document).ready(function () {
             jQuery('#mycarousel').jcarousel({
                 wrap: 'circular'
             });
         });

</script>
<style type="text/css">
    .MainContainer 
    {
    	position:absolute;
    	float:left;
    	font-family:Arial;
    	font-size:1px;
    	margin:0;
    	padding:0;
    	top:0;
    	left:0;
    	width:973px;
    	height:230px !important;
    	overflow:hidden;
    	background-color:Transparent;
    	}
    	
</style>
</head>
<body style="background-color:#ffffff;font-family:Arial;font-size:1px;margin:0;padding:0;top:0;left:0;width:890px; height:215px!important;overflow:hidden;">
    <form id="form1" runat="server">
    <div class="MainContainer" style="background-image: url('images/arkaplan.jpg')">
            <asp:Literal ID="ltHTML" runat="server"></asp:Literal>
            
        </div>   
    </form>
</body>
</html>
