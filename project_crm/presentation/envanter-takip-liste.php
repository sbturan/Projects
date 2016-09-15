<!DOCTYPE html>
<html>
<meta http-equiv="Content-Type" content="text/HTML; charset=utf-8" />

<title>Envanterler</title>
<link rel="stylesheet" type="text/css" href="/style/style.css">
<script src="/js/jquery-2.1.4.min.js"></script>
<?php 
include("topMenu.php");
require_once("config/config.php");

   $envId=$_REQUEST['eid'];

	$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
	if (!$conn) {
		die("Connection failed: " . mysqli_connect_error());
	}

	$conn ->set_charset("utf8");
?>

<body>

	<div id="envanter" >
		<label>ENVANTER TAKİBİ:</label> <br><br><br>
		 <a href="envanter-takip-ekle.php?eid=<?php echo $envId;?>">Hareket Girişi İçin Tıklayın</a> 
		 <button onclick="exportExcel()" style="margin-left:5%">İNDİR</button>	
		<br><br><br>
		<div class="datagrid" >

			<table id="envanterTable">
				<tr>
					<th>
					</th>
					<th style="display:none" class='icon-div'>
					</th>
					<th>
						EKİPMAN CİNSİ
					</th>
					<th>
						EKİPMAN ADI
					</th>
					<th>
						SERİ NUMARASI
					</th>
					<th>
						MM
					</th>
					<th>
						ADET
					</th>
					<th>
						ALAN KİŞİ
					</th>
					<th>
						ALIŞ TARİHİ
					</th>
					<th>
						TESLİM TARİHİ
					</th>
					
				</tr>

				<?php 


				$sql = "SELECT * FROM ".DB_SCHEMA_NAME.".envanter e,".DB_SCHEMA_NAME.".envanter_takip et,".DB_SCHEMA_NAME.".calisan c where e.seri_no=et.envanter_id and et.calisan_id=c.personel_id and et.envanter_id='".$envId."' order by cinsi";
 
				$result = $conn->query($sql);
             
				if ($result->num_rows > 0) {

					while($row = $result->fetch_assoc()) {
						echo "<tr>";
						echo "<td><div class='icon-div'><a class='view' href=''><img src='/img/view.png' title='görüntüle'></img></a>
						
						<a class='delete' href=''><img src='/img/delete.png' title='sil'></img></a></div></td>";
						echo "<td style='display:none'>".$row['id']."</td>";
						echo "<td>".$row['cinsi']."</td>";
						echo "<td >".$row['adi']."</td>";
						echo "<td class='seri_no'>".$row['seri_no']."</td>";
						echo "<td>".$row['MM']."</td>";
						echo "<td>".$row['adet']."</td>";
						echo "<td>".$row['adsoyad']."</td>";
						echo "<td>".$row['alis_tarihi']."</td>";
						echo "<td>".$row['teslim_tarihi']."</td>";
					 	
						echo "</tr>";  




					}
				} 
				$conn->close();
				?>
			</table>
		</div>
	</div>


	<script type="text/javascript">
		$('.takip').click(function(){

			var par = $(this).parent().parent().parent();
			var seri_no=par.children("td:nth-child(5)").html();
			var link="envanter-takip-ekle.php?eid="+seri_no;
			$(this).removeAttr('href');
			window.location.href=link;			
           

		});


         $('.view').click(function(){

			var par = $(this).parent().parent().parent();
			var seri_no=par.children("td:nth-child(2)").html();
			var link="envanter-takip-duzenle.php?etid="+seri_no;
			$(this).removeAttr('href');
			window.location.href=link;			
           

		});



		function exportExcel() {
			$('.icon-div').remove();
			var tableExport = document.getElementById('envanterTable');
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
			var seri_no=par.children("td:nth-child(2)").html();
            
			if (confirm("Envanter Silinecek ")) {
				$.ajax({
					url: '/dao/envanter-takipSil.php',
					data: { etid: seri_no } })
				.done(function(data) { 
					if(data=="success"){
						alert("Envanter Takip Silindi."); 
						par.remove();}
						else{
							alert("Hata Oluştu, Envanter Takip Silinemedi:"+data);
						}
					})
				.fail(function() { alert("Hata Oluştu, Envanter Takip Silinemedi"); });
				

				
			}
			return false;

		});

		
	</script>
</body>
</html>	