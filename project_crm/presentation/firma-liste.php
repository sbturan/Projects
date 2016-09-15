<!DOCTYPE html>
<html>
<meta http-equiv="Content-Type" content="text/HTML; charset=utf-8" />

<title>RAPOR EKRANI</title>
<link rel="stylesheet" type="text/css" href="/style/style.css">
<script src="/js/jquery-2.1.4.min.js"></script>
<?php 
include("topMenu.php");
?>

<body>

	<div id="firmalar" >
		<label>FİRMALAR:</label> <br><br><br>
		 <a href="firma-ekle.php">Yeni Firma Tanımlamak İçin Tıklayınız</a> 
		<div style="  margin-left: 30%;">

			<label>KATEGORİLER:</label>
			<select >
				<option value="" disabled selected></option>
				<?php
				require_once("config/config.php");

				$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
				if (!$conn) {
					die("Connection failed: " . mysqli_connect_error());
				}

				$conn ->set_charset("utf8");
				$sqlKategori = "SELECT * FROM ".DB_SCHEMA_NAME.".kategoriler";

				$resultKategori = $conn->query($sqlKategori);

				if ($resultKategori->num_rows > 0) {

					while($row = $resultKategori->fetch_assoc()) {

						echo "<option>".$row['kategori_ad']."</option>";

					} 
				}
				?>
			</select>
			<button id="filtreTemizle" style="margin-left:5%">Filtreyi Temizle</button>
			<button onclick="exportExcel()" style="margin-left:5%">İNDİR</button>
		</div> <br>
		<div class="datagrid" style="  width: 1700px;">

			<table id="firmaTable">
				<tr>
					<th>
					</th>
					<th style="display:none" class='icon-div'>
					</th>
					<th>
						FİRMA UNVANI
					</th>
					 <th>
						VERGİ NUMARASI
					</th>
					<th>
						VERGİ DAİRESİ
					</th>
					<th>
						BANKA ADI
					</th>
					<th>
						IBAN
					</th>
					<th>
						KATEGORİ
					</th>
					<th>
						WEB ADRESİ
					</th>
					<th>
						TELEFON NUMARASI 
					</th>
					<th>
						FAX NUMARASI
					</th>
					<th>
						AÇIK ADRES
					</th>
					
					<th>
						TUZEL/KİSİ
					</th>

				</tr>

				<?php 


				$sql = "SELECT * FROM ".DB_SCHEMA_NAME.".firmalar f,".DB_SCHEMA_NAME.".kategoriler k,".DB_SCHEMA_NAME.".bankalar b where k.ktg_id=f.ktg_id and b.banka_id = f.banka_id order by firma_unvani";

				$result = $conn->query($sql);

				if ($result->num_rows > 0) {

					while($row = $result->fetch_assoc()) {
						echo "<tr>";
						echo "<td><div class='icon-div'><a class='view' href=''><img src='/img/view.png' title='görüntüle'></img></a><a class='delete' href=''><img src='/img/delete.png' title='sil'></a></div></td>";
						echo "<td class='icon-div' style='display:none'>".$row['firma_id']."</td>";
						echo "<td style=' width: 14%;'>".$row['firma_unvani']."</td>";
						echo "<td style=' width: 5%;'>".$row['vergi_no']."</td>";
						echo "<td style='  width: 5%;'>".$row['vergi_dairesi']."</td>";
                        echo "<td style='  width: 5%;'>".$row['banka_adi']."</td>";
						echo "<td style='  width: 10%;'>".$row['iban_no']."</td>";
						echo "<td class='kategori'>".$row['kategori_ad']."</td>";
						echo "<td>".$row['email']."</td>";
						echo "<td style='  width: 9%;' >".$row['tel_no']."</td>";
						echo "<td>".$row['fax']."</td>";
						echo "<td style='  width: 15%;'>".$row['adres']."</td>";
						echo "<td style='  width: 9%;'>".$row['firma_tur']."</td>";


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


	<script type="text/javascript">
		$('select').on('change',function(){
			var kategori= this.value;
			$('.kategori').each(function(i,obj){

				if($(this).text()!=kategori){
					$(this).parent().hide();

				} else{
					$(this).parent().show();                    	
				} 

			});
            


		});

		$('#filtreTemizle').click(function(){

			$('tr').show();      
			$('select').val('');
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
			location.reload();
		}

		$('.delete').click(function(){
			var par = $(this).parent().parent().parent();
			var id=par.children("td:nth-child(2)").html();

			if (confirm("Firma Silinecek ")) {
				$.ajax({
					url: '/dao/firmaSil.php',
					data: { id: id } })
				.done(function(data) { 
					if(data=="success"){
						alert("Firma Silindi."); 
						par.remove();}
						else{
							alert("Hata Oluştu, Firma Silinemedi:");
						}
					})
				.fail(function() { alert("Hata Oluştu, Firma Silinemedi"); });
				

				
			}
			return false;

		});

		$('.view').click(function(){

			var par = $(this).parent().parent().parent();
			var id=par.children("td:nth-child(2)").html();
			var link="firma-duzenle.php?fid="+id;
			$(this).removeAttr('href');
			window.location.href=link;			
           

		});
	</script>
</body>
</html>	