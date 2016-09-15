<!DOCTYPE html>
<html>
<meta http-equiv="Content-Type" content="text/HTML; charset=utf-8" />

<title>Proje Tanımlama</title>
<head>
<link rel="stylesheet" type="text/css" href="/style/style.css">

	<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
	<script src="/js/jquery-2.1.4.min.js"></script>
	<script src="/js/jquery.maskedinput.min.js"></script>



	<script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
	<script src="http://jquery-ui.googlecode.com/svn/tags/1.6rc5/ui/i18n/ui.datepicker-tr.js"></script>
	<script>

		$(function() {
			$.datepicker.setDefaults( $.datepicker.regional[ "tr" ] );
			$( "#datepicker" ).datepicker({
				
				changeMonth: true, 
				changeYear: true, 
				yearRange: '1930:2020'});
		});</script>
</head>
<?php 
include("topMenu.php");
?>

<body>

	<div id="projeler" >
		<label>PROJELER:</label> <br><br><br>
		<a href="proje-ekle.php">Yeni Proje Tanımlamak İçin Tıklayınız</a> 
		<div style="  margin-left: 30%;">

			<label>KATEGORİLER:</label>
			<select id='selectkategori' style ="margin-left: 61px;" >
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
			</select>
			</br></br>
			<label>FİRMA UNVANI:</label>
			<select id='selectunvan' style ="margin-left: 62px;" >
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
			</br></br>
			<label>İŞ BAŞLANGIÇ TARİHİ:</label>

			
			<input  id="datepicker" style ="margin-left: 6px;"  name="datepicker">
			</br></br>


			<label>PROJE SORUMLUSU:</label>
			<select id='selectsorumlu' style ="margin-left: 16px; padding-right: 103px;" >
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
			<button id="filtreTemizle" style="margin-left:5%">Filtreyi Temizle</button>
			<button onclick="exportExcel()" style="margin-left:5%">İNDİR</button>
		</div> <br>
		<div class="datagrid" style="width:1500px;">

			<table id="ProjeTable">
				<tr id="firstRow">
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
					<th>
						KATEGORİ
					</th>
					<th>
						BASLANGIÇ TARİHİ
					</th>
					<th>
						BİTİŞ TARİHİ
					</th>
					<th>
						İŞİN LOKASYONU 
					</th>
					<th>
						PROJE SORUMLUSU
					</th>
					<th>
						İŞİN SAHİBİ
					</th>
					<th>
						BUTCE ONAYLANDI MI?
					</th>
					<th>
						İŞİN KAYNAĞI
					</th>
					

				</tr>

				<?php 


				$sql = "SELECT p.butce,p.kaynak,p.proje_id,f.firma_id,f.firma_unvani,k.kategori_ad,p.is_adi,p.baslangic_tarih,p.bitis_tarihi,p.isin_lokasyonu,c.adsoyad,pe.adsoyad sahip  FROM ".DB_SCHEMA_NAME.".projeler p left join ".DB_SCHEMA_NAME.".personel  pe on pe.p_id = p.sahip  , ".DB_SCHEMA_NAME.".firmalar f,".DB_SCHEMA_NAME.".kategoriler k,".DB_SCHEMA_NAME.".calisan c WHERE p.proje_sorumlusu = c.personel_id and p.firma_id = f.firma_id  and k.ktg_id = f.ktg_id order by firma_unvani;";

				$result = $conn->query($sql);

				if ($result->num_rows > 0) {

					while($row = $result->fetch_assoc()) {
						echo "<tr>";
						echo "<td style='width: 13%;'><div class='icon-div'><a href='#' ><img class='view 'src='/img/view.png' title='görüntüle'></img></a><a class='delete' href=''><img style='margin-right:8px;' src='/img/delete.png' title='sil'></a><a  class='butceler' href='#'> <img style='margin-right:10px;' src='/img/pricelist_icon.jpg' title='bütçeler'></a><a  class='faturalar' href='#'> <img style='margin-right:10px;' src='/img/invoice-list.png' title='Faturalar'></a></div></td>";
						echo "<td class='icon-div' style='display:none'>".$row['proje_id']."</td>";
						echo "<td style='width:14%;' class='firma_unvani'>".$row['firma_unvani']."</td>";
						echo "<td style='width:14%;'>".$row['is_adi']."</td>";
						echo "<td class='kategori'>".$row['kategori_ad']."</td>";
						echo "<td class='bastarih'>".$row['baslangic_tarih']."</td>";
						echo "<td class='bittarih'>".$row['bitis_tarihi']."</td>";
						echo "<td>".$row['isin_lokasyonu']."</td>";
						echo "<td>".$row['adsoyad']."</td>";
						echo "<td>".$row['sahip']."</td>";
						echo "<td>".$row['butce']."</td>";
						echo "<td>".$row['kaynak']."</td>";
						echo "<td class='icon-div' style='display:none'>".$row['firma_id']."</td>";
						echo "</tr>";  




					}
				} else {
					echo "0 results";
				}
				$conn->close();
				?>
			</table>
		</div>
		<form method="POST" action="butce-ekleme.php" id="butceler">
			<input id="pid" type="hidden" name="pid"  />
			<input id="padi" type="hidden" name="padi"  />
			<input id="firma" type="hidden" name="firma"  />
				</form>
	</div>
	<script>

    var unvanfiltre1 = "";
	var kategorifiltre1 ="";
	var sorumlufiltre1 ="";
	var tarih1 =  "";
	var unvanfiltre = "";
	var kategorifiltre ="";
	var sorumlufiltre ="";
	var tarih =  "";
	var i=0 ;
	var say=0;
	var dizi = new Array();
	var rowCount;
	var say1;
	var say2;
	var say3;
	var say4;
	var ik = 0;
	
	$('#selectunvan').on('change',function(){
		unvanfiltre= this.value;
          if( say1 == "1"){
			     temizle("1");
			  }
			  else{
			   say1 = "1";
			  }
		filtre ();



	});
	$('#selectsorumlu').on('change',function(){
		sorumlufiltre= this.value;
    if( say1 == "2"){
			     temizle("1");
			  }
			  else{
			   say1 = "2";
			  }

		filtre ();


	});
	$('#selectkategori').on('change',function(){
		    if( say1 == "3"){
			     temizle("1");
			  }
			  else{
			   say1 = "3";
			  }
		kategorifiltre= this.value;

		filtre ();


	});

$(function() {
  $( "#datepicker" ).datepicker( { 
      onSelect: function(date, picker){


   	  
       if( say1 == "4"){
			     temizle("1");
			  }
			  else{
			   say1 = "4";
			  }
		tarih= date;
       
		filtre ();

	  }
    } );
} )
	$('.butceler').click(function(){
	
	    var isadi= $(this).parent().parent().parent().children('td:nth-child(4)').html();
		var firmaAdi=$(this).parent().parent().parent().children('td:nth-child(3)').html();
		var projeId=$(this).parent().parent().parent().children('td:nth-child(2)').html();
		$('#pid').val(projeId);
		$('#padi').val(isadi);
		$('#firma').val(firmaAdi);
		
		$('#butceler').submit();
		
		//alert(isadi);
	 
	
	});
	
	$('.faturalar').click(function(){
		var projeId=$(this).parent().parent().parent().children('td:nth-child(2)').html();
		var firmaId=$(this).parent().parent().parent().children('td:nth-child(13)').html();
		window.location="fatura-liste.php?fid="+firmaId+"&pid="+projeId;
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
			if( say < rowCount - 1  ) 
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
				if( say < rowCount -1  )  
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
            
			var sorumlu=row.children("td:nth-child(9)").html();
			
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
				
				if( say < rowCount -1  ) 
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
		function filtertarih(row,sayi){
          
				var tari=row.children("td:nth-child(6)").html();
		
		
		 var sira = tari.indexOf('-');
		
		 tari= tari.substr(0, sira);
		
		 tari.replace(".", "/");
		
		 
		
	//	tari = $.datepicker.formatDate('MM dd, yy', new Date(tari));
		//tarih = $.datepicker.formatDate('MM dd, yy', new Date(tarih));
	
				if( dizi[sayi] == 1){ 
					if(tarih==tari){
						dizi[sayi] = 1;
					
						row.show();
					}

					else{
						row.hide();
					} 
				}
				else{
					if(say < rowCount - 1) 
					{
						if(tarih==tari){

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
                     
                    rowCount = $('#ProjeTable tr').length;
                    
					$('#ProjeTable tr').each(function(){


						if($('tr').index(this) != 0) {
							
							if(unvanfiltre!='' && unvanfiltre1 != unvanfiltre){
							    	
									 
								filterUnvan($(this),$('tr').index(this));
								say=say+1;
							}

							if(kategorifiltre!='' && kategorifiltre1 != kategorifiltre){
								
                                
								filterkategori($(this),$('tr').index(this));
								    say=say+1;
							}
							if(sorumlufiltre!='' && sorumlufiltre1 != sorumlufiltre){
 								
								filtersorumlu($(this),$('tr').index(this));
								    say=say+1;
							} 
							if(tarih!='' && tarih != tarih1){
							  
							  filtertarih($(this),$('tr').index(this));
							  	  say=say+1;
							}	
							
							
				
		}
	});  
					 unvanfiltre1 = unvanfiltre;
					 kategorifiltre1 = kategorifiltre;	
					 sorumlufiltre1 = sorumlufiltre;
					 tarih1 = tarih; 	




				}

                function temizle(a){
					
					$('tr').show();
					$('tr').show();
					say=0;
					dizi.splice(0,dizi.length);
					ik = 0;
					
				}
				$('#filtreTemizle').click(function(){

					$('tr').show();      
					$('select').val('');
					$("#datepicker").val('');
					unvanfiltre = "";
					kategorifiltre ="";
					sorumlufiltre ="";
					tarih =  "";
					unvanfiltre1 = "";
					kategorifiltre1 ="";
					sorumlufiltre1 ="";
					tarih1 =  "";
					i=0 ;
					say=0;
					dizi.splice(0,dizi.length);

				});
				function exportExcel() {
					$('.icon-div').remove();
					var tableExport = document.getElementById('ProjeTable');
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
					location.reload();
				}

				$('.delete').click(function(){
					var par = $(this).parent().parent().parent();
					var id=par.children("td:nth-child(2)").html();
                  
					if (confirm("Proje Silinecek ")) {
						$.ajax({
							url: '/dao/projesil.php',
							data: { id: id } })
						.done(function(data) { 
							if(data=="success"){
								alert("Proje Silindi."); 
								par.remove();}
								else{
									alert("Hata Oluştu, Proje Silinemedi");
								}
							})
						.fail(function() { alert("Hata Oluştu, Proje Silinemedi"); });



					}
					return false;

				});

				$('.view').click(function(){
					var tr=$(this).parent().parent().parent().parent();
					var firma=tr.children().eq(1).text();
					
					window.location="proje-duzenle.php?sct="+firma;

				});

				</script>

			</body>
			</html>	