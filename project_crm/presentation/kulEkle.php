
<!DOCTYPE html>
<html>
<meta http-equiv="Content-Type" content="text/HTML; charset=utf-8" />

<title>KULLANICILAR</title>
<link rel="stylesheet" type="text/css" href="/style/style.css">
<script src="/js/jquery-2.1.4.min.js"></script>
<script src="/js/jquery-2.1.4.min.js"></script>
<script src="/js/jquery.maskedinput.min.js"></script>
<?php 
include("topMenu.php");
include("utils/utils.php");
require_once("config/config.php");



$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
if (!$conn) {
	die("Connection failed: " . mysqli_connect_error());
}

$conn ->set_charset("utf8");
?>
<body>
	<div id="login" style="  margin-left: 3%;">
		<h3>Kullanıcı EKLEME</h3>
		<hr>

		<label>Kullanıcı Adı  :</label>
		<input type="text" name="username" id="name" placeholder="Kullanıcı Adı"><br><br>
		<label>Şifre  :</label>
		<input type="password" name="password" style = "margin-left:61px;" id="password" placeholder="**********"><br><br>
		<label>Şifre Tekrar :</label>
		<input type="password" name="passwordt" id="passwordt" style = "margin-left:10px;" placeholder="**********"><br><br>
		<input id="kullanici-kaydet" type="submit" value=" EKLE " name="submit"><br>




	</div></br>
	</br>
	</br>
	<h3>Kullanıcılar</h3>
	<div class="datagrid">
		
		<table id="firmaTable">
				<tr>
				    <th>
					 ŞİFREYİ GÖNDER
					</th>
					<th>
					 AKTİF / PASİF 
					</th>
					<th style="display:none" class='icon-div'>
					</th>
					<th>
						KULLANICI
					</th>
					<th>
						DURUMU
					</th>
				</tr>
				<?php 


				$sql = "SELECT  id,u_name,password,is_admin,
CASE is_admin WHEN '1' THEN 'ADMIN'
								WHEN '2' THEN 'AKTİF'
								WHEN '3' THEN 'PASİF'
								ELSE NULL END durum FROM ".DB_SCHEMA_NAME.".users";

				$result = $conn->query($sql);

				if ($result->num_rows > 0) {
                $c = "";

					while($row = $result->fetch_assoc()) {
						
						

						echo "<tr>";
						if($row['is_admin'] == 1 )
						  {	  
						    echo "<td></td>";
						  }
						else {  
						 echo "<td><div style='  width: 30px;' class='icon-div'><a class='view'   href=''><img src='/img/Mail-icon.png' title='Şifreyi Mail Gönder'></img></a></div></td>";
						}
						if($row['is_admin'] == 1 )
						  {	  
						    echo "<td></td>";
						  }
						if($row['is_admin'] == 2 )
						  {	  
						    echo "<td><div style='  width: 30px;' class='icon-div'><a class='delete' href=''><img src='/img/delete.png' title='Pasifleştir'></a></div></td>";
						  }
						  
						 if($row['is_admin'] == 3 ) 
						  {
						    echo "<td><div style='  width: 80px;' class='icon-div'><a class='delete' href=''><img src='/img/delete.png' title='Aktifleştir'></a></div></td>";
						
						  }	 
						echo "<td class='icon-div' style='display:none'>".$row['id']."</td>";
						echo "<td>".$row['u_name']."</td>";
						echo "<td>".$row['durum']."</td>";
						echo "<td style='display:none'>".$row['password']."</td>";
						echo "</tr>";  




					}
				} else {
					echo "0 results";
				}
				$conn->close();
				?>
	</div>	

	<script type="text/javascript">
	$('#kullanici-kaydet').click(function(){	

		var name;
		var pass;
		var passt;
		var kontrol;
		kontrol = 0;
		name = $('#name').val();
		pass = $('#password').val();
		passt= $('#passwordt').val();
		if(!($('#name')).val()||($.trim($('#name').val())=="")){
			
			kontrol=1;
		}
		if(!($('#password')).val()||($.trim($('#password').val())=="")){
			
			kontrol=1;
		}
		if(passt == ""){
			
			kontrol=1;
		}
		
		if(kontrol == 1) 
		{
			alert("Tüm Alanları Girmek Zorundasınız");
		}
		else 
		{				
			if( pass != passt) 
			{
              alert("Şifreler Uyumsuz");
			}	
			else
			{
				$.ajax({
					url: '/dao/user-ekleme.php',
					data: { 

						u_name : name,
						password : pass,
						admin : 2

					} })
				.done(function(data) { 
					
					alert("Kullanıcı Başarıyla Eklendi");
					window.location="kulEkle.php";

				})
				.fail(function() { alert("Hata Oluştu"+data); });

			}
		}
	});
	$('.delete').click(function(){
			var par = $(this).parent().parent().parent();
			var id =par.children("td:nth-child(2)").html();
            var durum =par.children("td:nth-child(4)").html();
			if(durum == 'AKTİF')
			{
				durum = 3;
			}
			else 
			{
				durum = 2;
			}
			
			if (confirm("Kullanıcının Durumu Değişecek ")) {
				$.ajax({
					url: '/dao/user-aktif.php',
					data: { id: id, durum : durum  } })

				.done(function(data) { 
				
					
						alert("Durum değişti"); 
						window.location="kulEkle.php";
					})
				.fail(function() { alert('Hata Oluştu Durum Değişmedi'); });
				

				
			}
			return false;

		});
     $('.view').click(function(){
            
			var par = $(this).parent().parent().parent();
			var mail=par.children("td:nth-child(4)").html();
			var sifre=par.children("td:nth-child(6)").html();
			
			$.ajax({
					url: 'mail/mail.php',
					data: { mail: mail, sifre : sifre  } })

				.done(function(data) { 
				
					
						alert("Şifre Gönderildi"); 
						window.location="kulEkle.php";
					})
				.fail(function() { alert('Hata Oluştu Şifre Gönderilemedi'); });
			$(this).removeAttr('href');
			window.location.href=link;			
           

		});
	</script>
</body>
</html>