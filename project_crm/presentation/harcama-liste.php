<!DOCTYPE html>
<html>
<meta http-equiv="Content-Type" content="text/HTML; charset=utf-8" />

<title>Proje Tanımlama</title>
<head>
	<link rel="stylesheet" type="text/css" href="/style/jquery.datetimepicker.css">
	<link rel="stylesheet" type="text/css" href="/style/style.css">
	<script src="/js/jquery-2.1.4.min.js"></script>
	<script src="/js/jquery.datetimepicker.js"></script>


	<script>

	$(function() {

		$( "#isbastarih" ).datetimepicker();

	});
	</script>
</head>
<?php 
include("topMenu.php");
?>

<body>

	<div id="harcamalar" >
		<label>HARCAMALAR:</label> <br><br><br>
		<a href="harcama-ekle.php">Yeni Harcama Tanımlamak İçin Tıklayınız</a> 
		<div style="  margin-left: 30%;">
			<table> <tr>
				<td> <table> <tr> <td>
					<label style="margin-left: -2px;">KATEGORİLER:</label> </td><td>
					<select id='selectkategori' style ="margin-left: 54px;" >
						<option value="" disabled selected></option>
						<?php
						require_once("config/config.php");

						$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
						if (!$conn) {
							die("Connection failed: " . mysqli_connect_error());
						}

						$conn ->set_charset("utf8");
						$sqlKategori = "SELECT k.kategori_ad
						FROM ".DB_SCHEMA_NAME.".kategoriler k order by k.kategori_ad;";

						$resultKategori = $conn->query($sqlKategori);

						if ($resultKategori->num_rows > 0) {

							while($row = $resultKategori->fetch_assoc()) {

								echo "<option>".$row['kategori_ad']."</option>";

							} 
						}
						?>
					</select></td></tr></table>
				</td>
				<td>
					<label>FİRMA:</label>
				<select id='selectunvan' style ="margin-left: 115px;" >
					<option value="" disabled selected></option>
					<?php
					require_once("config/config.php");

					$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
					if (!$conn) {
						die("Connection failed: " . mysqli_connect_error());
					}

					$conn ->set_charset("utf8");
					$sqlKategori = "SELECT f.firma_unvani
					FROM ".DB_SCHEMA_NAME.".firmalar f order by f.firma_unvani;";

					$resultKategori = $conn->query($sqlKategori);

					if ($resultKategori->num_rows > 0) {

						while($row = $resultKategori->fetch_assoc()) {

							echo "<option>".$row['firma_unvani']."</option>";

						} 
					}
					?>
				</select>
				</td>
			</tr>
			<tr> <td>
				<label>İŞİN ADI:</label>
				<select id='selectisad' style ="margin-left:110px;" >
					<option value="" disabled selected></option>
					<?php
					require_once("config/config.php");

					$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
					if (!$conn) {
						die("Connection failed: " . mysqli_connect_error());
					}

					$conn ->set_charset("utf8");
					$sqlKategori = "SELECT p.is_adi
					FROM ".DB_SCHEMA_NAME.".projeler p order by p.is_adi;";

					$resultKategori = $conn->query($sqlKategori);

					if ($resultKategori->num_rows > 0) {

						while($row = $resultKategori->fetch_assoc()) {

							echo "<option>".$row['is_adi']."</option>";

						} 
					}
					?>
				</select>
			</td>
			<td>

				<label>PROJE SORUMLUSU:</label>
				<select id='selectsorumlu' style ="margin-left: 4px; padding-right: 99px;" >
					<option value="" disabled selected></option>
					<?php
					require_once("config/config.php");

					$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
					if (!$conn) {
						die("Connection failed: " . mysqli_connect_error());
					}

					$conn ->set_charset("utf8");
					$sqlKategori = "SELECT c.adsoyad
					FROM ".DB_SCHEMA_NAME.".calisan c order by c.adsoyad;";

					$resultKategori = $conn->query($sqlKategori);

					if ($resultKategori->num_rows > 0) {

						while($row = $resultKategori->fetch_assoc()) {

							echo "<option>".$row['adsoyad']."</option>";

						} 
					}
					?>
				</select>
			</td>

		</tr>
		<tr>
			<td><label>HARCAMA DURUMU:</label>
				

					<select id='selecatdurum' name="Make" style ="margin-left: 15px; " >
					<option value="" disabled selected></option>
					<?php
					require_once("config/config.php");

					$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
					if (!$conn) {
						die("Connection failed: " . mysqli_connect_error());
					}

					$conn ->set_charset("utf8");
					$sqlKategori = "SELECT c.harcama_adi
					FROM ".DB_SCHEMA_NAME.".harcama_durum c order by c.harcama_adi;";

					$resultKategori = $conn->query($sqlKategori);

					if ($resultKategori->num_rows > 0) {

						while($row = $resultKategori->fetch_assoc()) {

							echo "<option>".$row['harcama_adi']."</option>";

						} 
					}
					?>
				</select>
				</select>
			</td>
			<td>
				<label>HARCAMA YAPAN:</label>
					<select id='selectharyap' style ="margin-left: 23px; padding-right: 103px;" >
						<option value="" disabled selected></option>
						<?php
						require_once("config/config.php");

						$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
						if (!$conn) {
							die("Connection failed: " . mysqli_connect_error());
						}

						$conn ->set_charset("utf8");
						$sqlKategori = "SELECT c.adsoyad
						FROM ".DB_SCHEMA_NAME.".calisan c order by c.adsoyad;";

						$resultKategori = $conn->query($sqlKategori);

						if ($resultKategori->num_rows > 0) {

							while($row = $resultKategori->fetch_assoc()) {

								echo "<option>".$row['adsoyad']."</option>";

							} 
						}
						?>
					</select>
			</td>
		</tr>
		<tr>
			<td>
				<label >HARCAMA TİPİ:</label>
				
				<select id="harcamatip" name="harcamatip" style ="margin-left: 57px;" >
					<option value="" disabled selected></option>
					<?php 
					$sqlb = "SELECT * FROM ".DB_SCHEMA_NAME.".harcama_tipler order by harcama_tip ";

					$resultb = $conn->query($sqlb);


					if ($resultb->num_rows > 0) {

						while($row = $resultb->fetch_assoc()) {

							echo '<option value='.$row['harcama_tip'].'>'.$row['harcama_tip'].'</option>';
						}
					}
					?>
				</select>



			</td>
			<td>
			</td>
		</tr>	

	</table>
	<br><br>
	<button id="filtreTemizle" style="margin-left:5%">Filtreyi Temizle</button>
	<button onclick="exportExcel()" style="margin-left:5%">İNDİR</button>
</div> <br>
<div class="datagrid" style="width:2000px">

	<table id="firmaTable">
		<tr id="firstRow" style="display:table-row !important;">
			<th>
			</th>
			<th style="display:none" class='icon-div'>
			</th>
			<th>
				FİRMA UNVANI
			</th>
			<th>
				İŞ ADI
			</th>
			<th style="display:none">
				KATEGORİ
			</th>
			<th>
				BASLANGIÇ TARİHİ
			</th>
			<th>
				BİTİŞ TARİHİ
			</th>
			<th>
				PROJE SORUMLUSU
			</th>
			<th>
				HARCAMA DURUMU
			</th>
			<th>
				HARCAMA YAPAN
			</th>
			<th>
				HARCAMA TİPİ
			</th>
			<th>
				FATURA TARİHİ
			</th>
			<th>
				FATURA NO
			</th>
			<th>
				HARCAMA TOPLAMI
			</th>
			<th>
				KDV
			</th>
			<th>
				ÖDEME TARİHİ
			</th>
			<th>
				AÇIKLAMA
			</th>
			<th>
				İŞ/HARİCİ
			</th>
			<th>
				ŞİRKET TİPİ
			</th>


		</tr>

		<?php 

		$sql = "SELECT y.harcama_id,y.kategori_ad,y.firma_unvani,y.is_adi,y.baslangic_tarih,y.bitis_tarihi,y.durum,
		               y.harcama_tip,y.tutar,y.harcamayapan, ca.adsoyad sorumlu,y.fatura_tarih,y.fatura_no,y.odeme_tarih,y.aciklama,y.sirket_tipi,y.is_harici,y.KDV from
		          (select x.*,c.adsoyad harcamayapan from
			        (select h.harcama_id,k.kategori_ad,f.firma_unvani,p.is_adi,p.baslangic_tarih,p.bitis_tarihi,
								CASE h.harcama_durum WHEN '2' THEN 'KASADAN ÖDENDİ'
								WHEN '3' THEN 'HESAPTAN ÖDENDİ'
								WHEN '4' THEN 'ÖDENECEK'
								WHEN '5' THEN 'ÇALIŞAN CEBİNDEN ÖDEDİ'
								WHEN '6' THEN 'MUHASEBEDEN ÖDENDİ'
								WHEN '7' THEN 'BORÇ KAPALI YAPILDI'
								ELSE NULL END durum,
								ht.harcama_tip,
								h.harcama_tutar tutar,
								h.harcama_yapanid,
								p.proje_sorumlusu,
								h.fatura_tarih,
								h.fatura_no,
								h.odeme_tarih,
								h.aciklama,
								h.sirket_tipi,
								h.is_harici,
								h.KDV
			           	from ".DB_SCHEMA_NAME.".projeler p,
							 ".DB_SCHEMA_NAME.".firmalar f,
							 ".DB_SCHEMA_NAME.".harcamalar h,
							 ".DB_SCHEMA_NAME.".kategoriler k,
							 ".DB_SCHEMA_NAME.".harcama_tipler ht
				        where p.firma_id = f.firma_id
				          and h.firma_id = p.firma_id
				          and h.proje_id = p.proje_id
				          and f.ktg_id   = k.ktg_id
				          and ht.id      = h.harcama_tipi) x left join 
				            ".DB_SCHEMA_NAME.".calisan c
				              on x.harcama_yapanid = c.personel_id) y left join 
				             ".DB_SCHEMA_NAME.".calisan ca
				             on ca.personel_id = y.proje_sorumlusu order by firma_unvani;";

$result = $conn->query($sql);

if ($result->num_rows > 0) {

	while($row = $result->fetch_assoc()) {
		echo "<tr>";
		echo "<td><div class='icon-div'><a class='view' href=''><img src='/img/view.png' title='görüntüle'></img></a><a class='delete' href=''><img src='/img/delete.png' title='sil'></a></div></td>";
		echo "<td class='icon-div' style='display:none'>".$row['harcama_id']."</td>";
		echo "<td style='width:15%;' class='firma_unvani'>".$row['firma_unvani']."</td>";
		echo "<td style='width:14%;' class='is_adi'>".$row['is_adi']."</td>";
		echo "<td class='kategori' style='display:none'>".$row['kategori_ad']."</td>";
		echo "<td class='bastarih'>".$row['baslangic_tarih']."</td>";
		echo "<td class='bittarih'>".$row['bitis_tarihi']."</td>";
		echo "<td class='sorumlu'>".$row['sorumlu']."</td>";
		echo "<td class='durum'>".$row['durum']."</td>";
		echo "<td class='harcamayapan'>".$row['harcamayapan']."</td>";
		echo "<td class='harcama_tip'>".$row['harcama_tip']."</td>";
		echo "<td class='fatura_tarih'>".$row['fatura_tarih']."</td>";
		echo "<td class='fatura_no'>".$row['fatura_no']."</td>";
		echo "<td class='tutar'>".$row['tutar']."</td>";
		echo "<td class='tutar'>".$row['KDV']."</td>";
		echo "<td class='odeme_tarih'>".$row['odeme_tarih']."</td>";
		echo "<td class='aciklama'>".$row['aciklama']."</td>";
		echo "<td class='is_harici'>".$row['is_harici']."</td>";
		echo "<td class='sirket_tipi'>".$row['sirket_tipi']."</td>";
		echo "</tr>";  




	}
} else {
	echo "0 results";
}
$conn->close();
?>
</table>
</div>
</div>
<script>

var adfiltre = "";
var unvanfiltre = "";
var kategorifiltre ="";
var sorumlufiltre ="";
var durumfiltre ="";
var hayapanfiltre =  "";
var harctipfiltre =  "";
var adfiltre1 = "";
var unvanfiltre1 = "";
var kategorifiltre1="";
var sorumlufiltre1 ="";
var durumfiltre1 ="";
var hayapanfiltre1 =  "";
var harctipfiltre1 =  "";
var i=0 ;
var say=0;
var dizi = new Array();
var rowCount;
var say1;
$('#selectkategori').on('change',function(){
	kategorifiltre= this.value;
	 if( say1 == "2"){
			     temizle("1");
			  }
			  else{
			   say1 = "2";
			  }
	filtre ();



});
$('#selectharyap').on('change',function(){
	 if( say1 == "3"){
			     temizle("1");
			  }
			  else{
			   say1 = "3";
			  }
	hayapanfiltre= this.value;


	filtre ();


});
$('#selectisad').on('change',function(){
	 if( say1 == "4"){
			     temizle("1");
			  }
			  else{
			   say1 = "4";
			  }
	adfiltre= this.value;
      
	filtre ();


});

$('#selectsorumlu').on('change',function(){
	 if( say1 == "5"){
			     temizle("1");
			  }
			  else{
			   say1 = "5";
			  }
	sorumlufiltre= this.value;
   
	filtre ();


});
$('#selecatdurum').on('change',function(){
	 if( say1 == "6"){
			     temizle("1");
			  }
			  else{
			   say1 = "6";
			  }
	durumfiltre= this.value;

	filtre ();


});
$('#selectunvan').on('change',function(){
	 if( say1 == "7"){
			     temizle("1");
			  }
			  else{
			   say1 = "7";
			  }
	unvanfiltre= this.value;

	filtre ();


});
$('#harcamatip').on('change',function(){
	 if( say1 == "8"){
			     temizle("1");
			  }
			  else{
			   say1 = "8";
			  }
	harctipfiltre= this.value;

	filtre ();


});


function filterUnvan(row,sayi){

	var unvan=row.children("td:nth-child(3)").html();

	if( dizi[sayi] == 1){ 

		if(unvanfiltre==unvan){

			dizi[sayi] = 1;
			
			row.show();
		}

		else{

			row.hide();
		} 
	}
	else{
		if( say < rowCount  ) 
		{
			if(unvanfiltre==unvan){

				dizi[sayi] = 1;
				
				row.show();
			}

			else{
				row.hide();
			} 
		}
		else
		{
			row.hide();
		}
	} 
}	
function filterkategori(row,sayi){

	var kategori=row.children("td:nth-child(5)").html();


	if( dizi[sayi] == 1){ 

		if(kategorifiltre==kategori){

			dizi[sayi] = 1;

			row.show();
		}

		else{
			row.hide();
		} 
	}
	else{
		if( say < rowCount   )  
		{

			if(kategorifiltre==kategori){

				dizi[sayi] = 1;
				row.show();
			}

			else{
				row.hide();
			} 
		}
		else
		{
			row.hide();
		}
	} 


}
function filtersorumlu(row,sayi){

	var sorumlu=row.children("td:nth-child(8)").html();

	if( dizi[sayi] == 1){ 


		if(sorumlufiltre==sorumlu){
			dizi[sayi] = 1;

			row.show();
		}

		else{
			row.hide();
		} 
	}
	else{

		if( say < rowCount   ) 
		{
			if(sorumlufiltre==sorumlu){

				dizi[sayi] = 1;

				row.show();
			}

			else{
				row.hide();
			} 
		}
		else
		{
			row.hide();
		}
	} 
}	
function filterdurum(row,sayi){

	var duru=row.children("td:nth-child(9)").html();

	if( dizi[sayi] == 1){ 


		if(durumfiltre==duru){
			dizi[sayi] = 1;

			row.show();
		}

		else{
			row.hide();
		} 
	}
	else{

		if( say < rowCount   ) 
		{
			if(durumfiltre==duru){

				dizi[sayi] = 1;

				row.show();
			}

			else{
				row.hide();
			} 
		}
		else
		{
			row.hide();
		}
	} 
}	
function filterharcama(row,sayi){

	var hyapan=row.children("td:nth-child(10)").html();

	if( dizi[sayi] == 1){ 


		if(hayapanfiltre==hyapan){
			dizi[sayi] = 1;

			row.show();
		}

		else{
			row.hide();
		} 
	}
	else{

		if( say < rowCount   ) 
		{
			if(hayapanfiltre==hyapan){

				dizi[sayi] = 1;

				row.show();
			}

			else{
				row.hide();
			} 
		}
		else
		{
			row.hide();
		}
	} 
}	
function filtertip(row,sayi){

	var htip=row.children("td:nth-child(11)").html();

	if( dizi[sayi] == 1){ 


		if(harctipfiltre==htip){
			dizi[sayi] = 1;

			row.show();
		}

		else{
			row.hide();
		} 
	}
	else{

		if( say < rowCount   ) 
		{
			if(harctipfiltre==htip){

				dizi[sayi] = 1;

				row.show();
			}

			else{
				row.hide();
			} 
		}
		else
		{
			row.hide();
		}
	} 
}	
function filterad(row,sayi){

	var ad=row.children("td:nth-child(4)").html();

	if( dizi[sayi] == 1){ 


		if(adfiltre==ad){
			dizi[sayi] = 1;

			row.show();
		}

		else{
			row.hide();
		} 
	}
	else{

		if( say < rowCount   ) 
		{
			if(adfiltre==ad){

				dizi[sayi] = 1;

				row.show();
			}

			else{
				row.hide();
			} 
		}
		else
		{
			row.hide();
		}
	} 
}	
function filtre () {

	rowCount = $('#firmaTable tr').length;
    
	$('#firmaTable tr').each(function(){

		
			
			if(unvanfiltre !='' &&  unvanfiltre != unvanfiltre1 ){
             
				filterUnvan($(this),$('tr').index(this));
				say=say+1;
			}

			if(kategorifiltre != '' &&  kategorifiltre != kategorifiltre1){

				filterkategori($(this),$('tr').index(this));
				say=say+1;
			}
			if(sorumlufiltre != '' &&  sorumlufiltre != sorumlufiltre1){

				filtersorumlu($(this),$('tr').index(this));
				say=say+1;
			} 
			if(durumfiltre != '' &&  durumfiltre!= durumfiltre1){

				filterdurum($(this),$('tr').index(this));
				say=say+1;
			}	
            if(hayapanfiltre != '' &&  hayapanfiltre != hayapanfiltre1){

				filterharcama($(this),$('tr').index(this));
				say=say+1;
			}
			
			if(harctipfiltre != '' && harctipfiltre != harctipfiltre1){

				filtertip($(this),$('tr').index(this));
				say=say+1;
			}
			
			if(adfiltre != '' &&  adfiltre != adfiltre1){
                
				filterad($(this),$('tr').index(this));
				say=say+1;
			}			
		
		
		
	});

         adfiltre1       =  adfiltre;
		 unvanfiltre1    =  unvanfiltre;
		 kategorifiltre1 =  kategorifiltre;
		 sorumlufiltre1  =  sorumlufiltre;
		 durumfiltre1    =  durumfiltre;
		 hayapanfiltre1  =  hayapanfiltre;
 		 harctipfiltre1  =  harctipfiltre;
		
		 $( "#firmaTable tr:first" ).show();

}


$('#filtreTemizle').click(function(){

	$('tr').show();      
	$('select').val('');
	unvanfiltre = "";
	kategorifiltre ="";
	sorumlufiltre ="";
	tarih =  "";
	adfiltre = "";
	durumfiltre="";
	hayapanfiltre="";
	harctipfiltre = "";
	unvanfiltre1 = "";
	kategorifiltre1 ="";
	sorumlufiltre1 ="";
	tarih1 =  "";
	adfiltre1 = "";
	durumfiltre1 ="";
	hayapanfiltre1 ="";
	harctipfiltre1 = "";
    i=0 ;
	say=0;
	dizi.splice(0,dizi.length);

});
function exportExcel() {
	
	$('.icon-div').remove();
	var tableExport = document.getElementById('firmaTable');
	var html = tableExport.outerHTML;

	while (html.indexOf('ç') != -1) html = html.replace('ç', '&ccedil;');
	while (html.indexOf('ğ') != -1) html = html.replace('ğ', '&#287;');
	while (html.indexOf('ı') != -1) html = html.replace('ı', '&#305;');
	while (html.indexOf('ö') != -1) html = html.replace('ö', '&ouml;');
	while (html.indexOf('ş') != -1) html = html.replace('ş', '&#351;');
	while (html.indexOf('ü') != -1) html = html.replace('ü', '&uuml;');

	while (html.indexOf('Ç') != -1) html = html.replace('Ç', '&Ccedil;');
	while (html.indexOf('Ğ') != -1) html = html.replace('Ğ', '&#286;');
	while (html.indexOf('İ') != -1) html = html.replace('İ', '&#304;');
	while (html.indexOf('Ö') != -1) html = html.replace('Ö', '&Ouml;');
	while (html.indexOf('Ş') != -1) html = html.replace('Ş', '&#350;');
	while (html.indexOf('Ü') != -1) html = html.replace('Ü', '&Uuml;');
    
	window.open('data:application/vnd.ms-excel,' + encodeURIComponent(html));
	
}

$('.delete').click(function(){
	var par = $(this).parent().parent().parent();
	var id=par.children("td:nth-child(2)").html();

	if (confirm("Harcama Silinecek ")) {
		$.ajax({
			url: '/dao/harcama-sil.php',
			data: { id: id } })
		.done(function(data) { 
			if(data=="success"){
				alert("Harcama Silindi."); 
				par.remove();}
				else{
					alert("Hata Oluştu, Harcama Silinemedi:");
				}
			})
		.fail(function() { alert("Hata Oluştu, Harcama Silinemedi"); });



	}
	return false;

});
	$('.view').click(function(){

			var par = $(this).parent().parent().parent();
			var id=par.children("td:nth-child(2)").html();
			var link="harcama-duzenle.php?harcamaId="+id;
			$(this).removeAttr('href');
			window.location.href=link;			
           

		});
function temizle(a){
					
					$('tr').show();
					$('tr').show();
					say=0;
					dizi.splice(0,dizi.length);
					
				}
				
				 $(function(){
				  
				    $('.tutar').each(function(){
					if($(this).text()!="")
					 $(this).text(formatCurrency($(this).text()));
					 
					 
					
					});
				     
				  });
				  
				  function formatCurrency(total) {
						var neg = false;
						if(total < 0) {
							neg = true;
							total = Math.abs(total);
						}
						return total.toString().replace(/(\d)(?=(\d{3})+$)/g, '$1'+".");
				}
</script>

</body>
</html>	