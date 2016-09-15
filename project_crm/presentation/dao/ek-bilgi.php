
<!DOCTYPE html>
<html>
<meta http-equiv="Content-Type" content="text/HTML; charset=utf-8" />

<title>KULLANICILAR</title>
<link rel="stylesheet" type="text/css" href="/style/style.css">
<script src="/js/jquery-2.1.4.min.js"></script>
<script src="/js/jquery-2.1.4.min.js"></script>
<script src="/js/jquery.maskedinput.min.js"></script>
<head>

<?php 
include("topMenu.php");
include("utils/utils.php");
require_once("config/config.php");

$conn1 = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
if (!$conn1) {
	die("Connection failed: " . mysqli_connect_error());
}

$conn1 ->set_charset("utf8");


$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
if (!$conn) {
	die("Connection failed: " . mysqli_connect_error());
}

$conn ->set_charset("utf8");


$conn3 = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
if (!$conn3) {
	die("Connection failed: " . mysqli_connect_error());
}

$conn3 ->set_charset("utf8");

$conn2 = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
if (!$conn2) {
	die("Connection failed: " . mysqli_connect_error());
}

$conn2 ->set_charset("utf8");

$conn4 = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
if (!$conn4) {
	die("Connection failed: " . mysqli_connect_error());
}

$conn4 ->set_charset("utf8");

$conn5 = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
if (!$conn5) {
	die("Connection failed: " . mysqli_connect_error());
}

$conn5 ->set_charset("utf8");

?>


<body>

<label>COMBOBOXLAR</label> <br><br><br>
		<div style="  margin-left: 30%;">

			<label>Ek Bilgiler</label>
			<select id="cmbMake" name="Make" >
				<option value=""></option>
				<option value="1">Kategoriler</option>
				<option value="2">Calışan Görevler</option>
				<option value="3">Harcama Tipleri</option>
				<option value="4">Ödeme Tipleri</option>
				<option value="5">Yetkili Görevler</option>
				<option value="6">Bankalar</option>
			</select>
			<button id="filtreTemizle" style="margin-left:5%">Filtreyi Temizle</button>
			
		</div> </br> </br> 
		<div id="login" style="  margin-left: 3%;">
		<h3>Ek Bilgi EKLEME</h3>
		<label>Adı  :</label>
		<input type="text" name="username" id="name" placeholder="Adını Giriniz"><br><br>
		<input id="ek-kaydet" type="submit" value=" EKLE " name="submit"><br>




	</div> </br></br>

	<div id="datagrid1" class="datagrid" >
		<table id="firmaTable1">
				<tr id="firstRow">
					<th>DURUM DEĞİŞTİR
					</th>
					<th style="display:none" >
					</th>
					<th>
						ADI
					</th>
					<th>
						DURUMU
					</th>
				</tr>
				<?php 


				$sql = "SELECT  ktg_id id ,kategori_ad ad,aktif,
					CASE aktif WHEN '1' THEN 'AKTIF'
								WHEN '0' THEN 'PASİF'
								ELSE NULL END durum FROM ".DB_SCHEMA_NAME.".kategoriler";

				$result = $conn->query($sql);

				if ($result->num_rows > 0) {
                $c = "";

					while($row = $result->fetch_assoc()) {
						
						

						echo "<tr>";
						if($row['aktif'] == 99 )
						  {	  
						    echo "<td></td>";
						  }
						if($row['aktif'] == 1 )
						  {	  
						    echo "<td><a class='icon-div' id='delete'  href=''><img src='/img/delete.png' title='Pasifleştir'></a></td>";
						  }
						  
						 if($row['aktif'] == 0 ) 
						  {
						    echo "<td><a class='icon-div' id='delete'  href=''><img src='/img/delete.png' title='Aktifleştir'></a></td>";
						  } 
						echo "<td class='icon-div' style='display:none'>".$row['id']."</td>";
						echo "<td>".$row['ad']."</td>";
						echo "<td>".$row['durum']."</td>";
						echo "</tr>";  




					}
				} else {
					echo "0 results";
				}
				$conn->close();
				?>
				</table>
	</div>	
  	<div id="datagrid2" class="datagrid">
		<table id="firmaTable2">
				<tr id="firstRow">
					<th>DURUM DEĞİŞTİR
					</th>
					<th style="display:none" >
					</th>
					<th>
						ADI
					</th>
					<th>
						DURUMU
					</th>
				</tr>
				<?php 


				$sql1 = "SELECT  id id ,calisan_gorev ad,aktif,
					CASE aktif WHEN '1' THEN 'AKTIF'
								WHEN '0' THEN 'PASİF'
								ELSE NULL END durum FROM ".DB_SCHEMA_NAME.".calisan_gorev";

				$result1 = $conn1->query($sql1);

				if ($result1->num_rows > 0) {
                $c = "";

					while($row1 = $result1->fetch_assoc()) {
						
						

						echo "<tr>";
						if($row1['aktif'] == 99 )
						  {	  
						    echo "<td></td>";
						  }
						if($row1['aktif'] == 1 )
						  {	  
						    echo "<td><a class='icon-div' id='delete' href=''><img src='/img/delete.png' title='Pasifleştir'></a></td>";
						  }
						  
						 if($row1['aktif'] == 0 ) 
						  {
						    echo "<td><a class='icon-div' id='delete' href=''><img src='/img/delete.png' title='Aktifleştir'></a></td>";
						  } 
						echo "<td class='icon-div' style='display:none'>".$row1['id']."</td>";
						echo "<td>".$row1['ad']."</td>";
						echo "<td>".$row1['durum']."</td>";
						echo "</tr>";  




					}
				} else {
					echo "0 results";
				}
				$conn1->close();
				?>
				</table>
	</div>	
	<div id="datagrid3" class="datagrid" >
		<table id="firmaTable3">
				<tr id="firstRow">
					<th>DURUM DEĞİŞTİR
					</th>
					<th style="display:none" >
					</th>
					<th>
						ADI
					</th>
					<th>
						DURUMU
					</th>
				</tr>
				<?php 


				$sql = "SELECT  id id ,harcama_tip ad,aktif,
					CASE aktif WHEN '1' THEN 'AKTIF'
								WHEN '0' THEN 'PASİF'
								ELSE NULL END durum FROM ".DB_SCHEMA_NAME.".harcama_tipler";

				$result = $conn2->query($sql);

				if ($result->num_rows > 0) {
                $c = "";

					while($row = $result->fetch_assoc()) {
						
						

						echo "<tr>";
						if($row['aktif'] == 99 )
						  {	  
						    echo "<td></td>";
						  }
						if($row['aktif'] == 1 )
						  {	  
						    echo "<td><a class='icon-div' href=''><img src='/img/delete.png' title='Pasifleştir'></a></td>";
						  }
						  
						 if($row['aktif'] == 0 ) 
						  {
						    echo "<td><a class='icon-div' href=''><img src='/img/delete.png' title='Aktifleştir'></a></td>";
						  } 
						echo "<td class='icon-div' style='display:none'>".$row['id']."</td>";
						echo "<td>".$row['ad']."</td>";
						echo "<td>".$row['durum']."</td>";
						echo "</tr>";  




					}
				} else {
					echo "0 results";
				}
				$conn2->close();
				?>
				</table>
	</div>	
	<div id="datagrid4" class="datagrid" >
		<table id="firmaTable4">
				<tr id="firstRow">
					<th>DURUM DEĞİŞTİR
					</th>
					<th style="display:none" >
					</th>
					<th>
						ADI
					</th>
					<th>
						DURUMU
					</th>
				</tr>
				<?php 


				$sql = "SELECT  id id ,odme_tipi ad,aktif,
					CASE aktif WHEN '1' THEN 'AKTIF'
								WHEN '0' THEN 'PASİF'
								ELSE NULL END durum FROM ".DB_SCHEMA_NAME.".odeme_tipler";

				$result = $conn3->query($sql);

				if ($result->num_rows > 0) {
                $c = "";

					while($row = $result->fetch_assoc()) {
						
						

						echo "<tr>";
						if($row['aktif'] == 99 )
						  {	  
						    echo "<td></td>";
						  }
						if($row['aktif'] == 1 )
						  {	  
						    echo "<td><a class='icon-div' href=''><img src='/img/delete.png' title='Pasifleştir'></a></td>";
						  }
						  
						 if($row['aktif'] == 0 ) 
						  {
						    echo "<td><a class='icon-div' href=''><img src='/img/delete.png' title='Aktifleştir'></a></td>";
						  } 
						echo "<td class='icon-div' style='display:none'>".$row['id']."</td>";
						echo "<td>".$row['ad']."</td>";
						echo "<td>".$row['durum']."</td>";
						echo "</tr>";  




					}
				} else {
					echo "0 results";
				}
				$conn3->close();
				?>
				</table>
	</div>	
	<div id="datagrid5" class="datagrid" >
		<table id="firmaTable5">
				<tr id="firstRow">
					<th>
					DURUM DEĞİŞTİR
					</th>
					<th style="display:none" >
					</th>
					<th>
						ADI
					</th>
					<th>
						DURUMU
					</th>
				</tr>
				<?php 


				$sql = "SELECT  id id ,gorev ad,aktif,
					CASE aktif WHEN '1' THEN 'AKTIF'
								WHEN '0' THEN 'PASİF'
								ELSE NULL END durum FROM ".DB_SCHEMA_NAME.".personel_gorev";

				$result = $conn4->query($sql);

				if ($result->num_rows > 0) {
                $c = "";

					while($row = $result->fetch_assoc()) {
						
						

						echo "<tr>";
						if($row['aktif'] == 99 )
						  {	  
						    echo "<td></td>";
						  }
						if($row['aktif'] == 1 )
						  {	  
						    echo "<td><a class='icon-div' href=''><img src='/img/delete.png' title='Pasifleştir'></a></td>";
						  }
						  
						 if($row['aktif'] == 0 ) 
						  {
						    echo "<td><a class='icon-div' href=''><img src='/img/delete.png' title='Aktifleştir'></a></td>";
						  } 
						echo "<td class='icon-div' style='display:none'>".$row['id']."</td>";
						echo "<td>".$row['ad']."</td>";
						echo "<td>".$row['durum']."</td>";
						echo "</tr>";  




					}
				} else {
					echo "0 results";
				}
				$conn4->close();
				?>
				</table>
	</div>	  
		<div id="datagrid6" class="datagrid" >
		<table id="firmaTable6">
				<tr id="firstRow">
					<th>
					DURUM DEĞİŞTİR
					</th>
					<th style="display:none" >
					</th>
					<th>
						ADI
					</th>
					<th>
						DURUMU
					</th>
				</tr>
				<?php 


				$sql = "SELECT  banka_id id ,banka_adi ad,aktif,
					CASE aktif WHEN '1' THEN 'AKTIF'
								WHEN '0' THEN 'PASİF'
								ELSE NULL END durum FROM ".DB_SCHEMA_NAME.".personel_gorev";

				$result = $conn5->query($sql);

				if ($result->num_rows > 0) {
                $c = "";

					while($row = $result->fetch_assoc()) {
						
						

						echo "<tr>";
						if($row['aktif'] == 99 )
						  {	  
						    echo "<td></td>";
						  }
						if($row['aktif'] == 1 )
						  {	  
						    echo "<td><a class='icon-div' href=''><img src='/img/delete.png' title='Pasifleştir'></a></td>";
						  }
						  
						 if($row['aktif'] == 0 ) 
						  {
						    echo "<td><a class='icon-div' href=''><img src='/img/delete.png' title='Aktifleştir'></a></td>";
						  } 
						echo "<td class='icon-div' style='display:none'>".$row['id']."</td>";
						echo "<td>".$row['ad']."</td>";
						echo "<td>".$row['durum']."</td>";
						echo "</tr>";  




					}
				} else {
					echo "0 results";
				}
				$conn5->close();
				?>
				</table>
	</div>	  

	<script type="text/javascript">
	var kontrol;
	kontrol = '0';
		$('#cmbMake').on('change',function(){
		
		var id= this.value;
		kontrol = id;
		$("#login").show();
		$('tr').show();      
       
		if(id == '1')
		{   
			
			$("#datagrid1").show();
			$("#datagrid2").hide();
			$("#datagrid3").hide();
			$("#datagrid4").hide();
			$("#datagrid5").hide();
			$("#datagrid6").hide();
		}
		if(id == '2')
		{
			
			$("#datagrid2").show();
			$("#datagrid1").hide();
			$("#datagrid3").hide();
			$("#datagrid4").hide();
			$("#datagrid5").hide();
			$("#datagrid6").hide();
		}
		if(id =='3')
		{
			
			$("#datagrid3").show();
			$("#datagrid1").hide();
			$("#datagrid2").hide();
			$("#datagrid4").hide();
			$("#datagrid5").hide();
			$("#datagrid6").hide();
		}
		if(id =='4')
		{
			
			$("#datagrid4").show();
			$("#datagrid1").hide();
			$("#datagrid2").hide();
			$("#datagrid3").hide();
			$("#datagrid5").hide();
			$("#datagrid6").hide();
		}
		if(id =='5')
		{
			
			$("#datagrid5").show();
			$("#datagrid1").hide();
			$("#datagrid2").hide();
			$("#datagrid4").hide();
			$("#datagrid3").hide();
			$("#datagrid6").hide();
		}
		if(id =='6')
		{
			
			$("#datagrid6").show();
			$("#datagrid1").hide();
			$("#datagrid2").hide();
			$("#datagrid4").hide();
			$("#datagrid3").hide();
			$("#datagrid5").hide();
		}
		
		

	});
	$(window).load(function(){
			
		hideAll();
		});
		function hideAll(){
			$("#datagrid5").hide();
			$("#datagrid1").hide();
			$("#datagrid2").hide();
			$("#datagrid4").hide();
			$("#datagrid3").hide();
			$("#datagrid6").hide();
			$("#login").hide();
			
		}
    
		$('#filtreTemizle').click(function(){

					$('tr').hide();      
					$('select').val('');
					$("#login").hide();
					

		});


		$('#ek-kaydet').click(function(){	

		var name;
		var control;
		control = 0;
		name = $('#name').val();
		
		if(!($('#name')).val()||($.trim($('#name').val())=="")){
			
			control=1;
		}
		
		
		if(control == 1) 
		{
			alert("Tüm Alanları Girmek Zorundasınız");
		}
		else 
		{				
			
			  if(kontrol == 0) {
                 alert("Öncelikle Eklenmesi gerekcek alanı seçiniz");
			  }
			  else  {
				$.ajax({
					url: '/dao/ekbilgi-ekleme.php',
					data: { 

						u_name : name,
						choose : kontrol,
						aktif : 1
					} })
				.done(function(data) { 
					
					alert("Kullanıcı Başarıyla Eklendi");
					window.location="ek-bilgi.php";

				})
				.fail(function() { alert("Hata Oluştu"+data); });

			   }
		}
	});

	$('.icon-div').click(function(){
		
			var par = $(this).parent().parent();
			
			var id=par.children("td:nth-child(2)").html();
			
			var durum =par.children("td:nth-child(4)").html();
			
			if(durum == 'AKTIF')
			{
				durum = 0;
			}
			else 
			{
				durum = 1;
			}
		  
			
			if (confirm("Bilginin Durumu Değişecek ")) {
				$.ajax({
					url: '/dao/ekbilgi-aktif.php',
					data: { id: id, durum : durum , choose :kontrol  } })
				.done(function(data) { 
				
					
						alert("Durum değişti"); 
						window.location="ek-bilgi.php";
					})
				.fail(function() { alert("Hata Oluştu, Durum Değişmedi"); });
				

				
			}
			return false;

		});
	</script>
</body>
</html>