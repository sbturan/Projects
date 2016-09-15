<!DOCTYPE html>
<html>
<meta http-equiv="Content-Type" content="text/HTML; charset=utf-8" />

<title>Çalışan Tanımlama</title>
<link rel="stylesheet" type="text/css" href="/style/style.css">
<script src="/js/jquery-2.1.4.min.js"></script>
<?php 
include("topMenu.php");
?>

<body>

	<div id="firmalar" style=" width: 2000px;;">
		<label>ÇALIŞANLAR:</label> <br><br><br>
		<a href="calisan-ekle.php">Yeni Çalışan Tanımlamak İçin Tıklayınız</a> 
		<div style=" margin-left: 450px;">

			<label>GÖREVLER:</label>
			<select id="selectgorev" >
				<option value="" disabled selected></option>
				<?php
				require_once("config/config.php");

				$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
				if (!$conn) {
					die("Connection failed: " . mysqli_connect_error());
				}

				$conn ->set_charset("utf8");
				$sqlKategori = "SELECT * FROM ".DB_SCHEMA_NAME.".calisan_gorev";

				$resultKategori = $conn->query($sqlKategori);

				if ($resultKategori->num_rows > 0) {

					while($row = $resultKategori->fetch_assoc()) {

						echo "<option>".$row['calisan_gorev']."</option>";

					} 
				}
				?>
			</select>
			<label>AD-SOYAD:</label>
			<select id="selectad" >
				<option value="" disabled selected></option>
				<?php
				require_once("config/config.php");

				$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
				if (!$conn) {
					die("Connection failed: " . mysqli_connect_error());
				}

				$conn ->set_charset("utf8");
				$sqlKategori = "SELECT adsoyad FROM ".DB_SCHEMA_NAME.".calisan";

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


		<div class="datagrid">

			<table id="firmaTable">
				<tr>
					<th>
					</th>
					<th style="display:none" class='icon-div'>
					</th>
					
					<th>
						AD-SOYAD
					</th>
					<th>
						TCKN
					</th>
					<th>
						DOĞUM TARİHİ
					</th>
					<th>
						KAN GRUBU
					</th>
					
					<th>
						TELEFON
					</th>
					<th>
						EMAİL
					</th>
					<th>
						GÖREV
					</th>
					<th>
						ADRES
					</th>
					<th>
						ÇALIŞAN TİPİ
					</th>
					<th>
						BANKA
					</th>
				    <th>
						IBAN
					</th>
					
					<th>
						SINIF
					</th>
					<th>
						MEZUN OLDUĞU OKUL
					</th>
					<th>
						SABIKA KAYDI
					</th>
					<th>
						ASKERLİK
					</th>
					<th>
						İKAMETGAH
					</th>
					
					<th>
						FOTOĞRAF
					</th>

				</tr>

				<?php 


				$sql = "SELECT * FROM ".DB_SCHEMA_NAME.".calisan_gorev cg,".DB_SCHEMA_NAME.".calisan c ,".DB_SCHEMA_NAME.".bankalar b where c.gorev_id = cg.id and b.banka_id=c.banka_id order by adsoyad";

				$result = $conn->query($sql);

				if ($result->num_rows > 0) {

					while($row = $result->fetch_assoc()) {
						echo "<tr>";
						echo "<td><div style='  width: 80px;' class='icon-div'><a class='view' href=''><img src='/img/view.png' title='görüntüle'></img></a><a class='delete' href=''><img src='/img/delete.png' title='sil'></a></div></td>";
						echo "<td class='icon-div' style='display:none'>".$row['personel_id']."</td>";
						echo "<td class='adsoyad' style=' width: 9%;'>".$row['adsoyad']."</td>";
						echo "<td>".$row['tckn']."</td>";
						echo "<td>".$row['dogum_tarihi']."</td>";
						echo "<td>".$row['kan_grubu']."</td>";
						echo "<td>".$row['tel_no']."</td>";
						echo "<td>".$row['email']."</td>";
						echo "<td class='gorev'>".$row['calisan_gorev']."</td>";
						echo "<td style='width:12%;' >".$row['adres']."</td>";
						echo "<td>".$row['personel_tip']."</td>";
						echo "<td>".$row['banka_adi']."</td>";
						echo "<td>".$row['iban']."</td>";
						echo "<td>".$row['sinif']."</td>";
						echo "<td>".$row['okul']."</td>";
						echo "<td>".$row['sabıka']."</td>";
						echo "<td>".$row['askerlik']."</td>";
						echo "<td>".$row['ikametgah']."</td>";
						
						if(strcmp(trim($row['foto_path']),"")==0){
							echo "<td>YOK</td>";
						} else{
							echo "<td>VAR</td>";
						}
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
		var adfiltre = "";
		var gorevfiltre ="";

		$('#selectad').on('change',function(){
			adfiltre= this.value;
			filtre ();
            

			
		});
		$('#selectgorev').on('change',function(){
			gorevfiltre= this.value;
			
            filtre ();
         

		});
		function filtre () {


			$('.adsoyad').each(function(i,obj){

				if(adfiltre != ""){
					if($(this).text()!=adfiltre){
						$(this).parent().hide();

					} else{
						if(gorevfiltre == ""){
							$(this).parent().show();
						}
						else
						{

							if($(this).parent().children("td:nth-child(11)").text()!=gorevfiltre){
								$(this).parent().hide();
							}
							else
							{
								$(this).parent().show();
							}
						}                    	
					} 
				}
				else{
					if(gorevfiltre != ""){
                       $('.gorev').each(function(i,obj){

				if($(this).text()!=gorevfiltre){
					$(this).parent().hide();

				} else{
					$(this).parent().show();                    	
				} 

			});

					}
				}
			});
		}
		$('#filtreTemizle').click(function(){

			$('tr').show();      
			$('select').val('');
			 adfiltre = "";
		 gorevfiltre ="";

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

			if (confirm("Çalışan Silinecek ")) {
				$.ajax({
					url: '/dao/calisansil.php',
					data: { id: id } })
				.done(function(data) { 
					if(data=="success"){
						alert("Çalışan Silindi."); 
						par.remove();}
						else{
							alert("Hata Oluştu, Çalışan Silinemedi:");
						}
					})
				.fail(function() { alert("Hata Oluştu, Çalışan Silinemedi"); });
				

				
			}
			return false;

		});

		$('.view').click(function(){

			var par = $(this).parent().parent().parent();
			var id=par.children("td:nth-child(2)").html();
			var link="calisan-duzenle.php?cid="+id;
			$(this).removeAttr('href');
			window.location.href=link;			
           

		});

	</script>
	
</body>
</html>	