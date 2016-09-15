<?php 
include "session.php";
?>

<link rel="stylesheet" type="text/css" href="/style/topMenu.css"> 

<header style="  margin-top: -35px;">
<a href="index.php">
<img id="logo" src="unnamed.png" alt="Mountain View" style="width:220px;height:100px; margin-left: -0.5cm;   margin-top: 14px; position:absolute;"> 
</a>
	<nav>
		<ul class="menu1">
			<li><a href="firma-liste.php">Firmalar</a></li>
			<li><a href="calisan-liste.php" >Çalışanlar</a></li>
			<li><a href="proje-liste.php">Projeler</a></li>
			<li><a href="harcama-liste.php">Harcamalar</a></li>
			<li><a href="raporlar-liste.php">Raporlar</a></li>
			<li><a href="envanter-liste.php">Envanterler</a></li>
			
			<?php

                 


			 if (isset($_SESSION['isAdmin']) && strcmp($_SESSION['isAdmin'],"1")==0 ){
                echo  '<li><a href="ek-bilgi.php">Paremetreler</a></li>';
			 	echo  '<li c><a href="kulEkle.php">Kullanıcı Ekle</a></li>';
			 } ?>
			<li class="lastItem"><a href="exit.php">Çıkış</a></li>
		</ul>
	</nav>
</header>

<script type="text/javascript">
	$('.menu1 a').click(function(){
        $('.menu1 a').removeClass('current');
        $(this).addClass('current');
 
	});


</script>
