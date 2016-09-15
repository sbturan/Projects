

<!DOCTYPE html>
<html>
<meta http-equiv="Content-Type" content="text/HTML; charset=utf-8" />

<title>Firma </title>
<link rel="stylesheet" type="text/css" href="/style/style.css">
<script src="/js/jquery-2.1.4.min.js"></script>
<script src="/js/jquery.maskedinput.min.js"></script>
<?php 
include("topMenu.php");
include("utils/utils.php");
require_once("config/config.php");
$firmaId=$_REQUEST['fid'];


$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
if (!$conn) {
	die("Connection failed: " . mysqli_connect_error());
}

$conn ->set_charset("utf8");
$sql = "SELECT * FROM ".DB_SCHEMA_NAME.".firmalar f,".DB_SCHEMA_NAME.".bankalar b,".DB_SCHEMA_NAME.".kategoriler k where k.ktg_id=f.ktg_id and f.banka_id=b.banka_id and f.firma_id=".$firmaId;

$result = $conn->query($sql);
echo $conn->error;

if ($result->num_rows > 0) {

	while($row = $result->fetch_assoc()) {


		$firma_tur=$row['firma_tur'];
		$firma_unvani=$row['firma_unvani'];
		$email=$row['email'];
		$tel_no= phoneNumberFormatter($row['tel_no']);
		$fax=phoneNumberFormatter($row['fax']);
		$adres=$row['adres'];
		$vergi_no=$row['vergi_no'];
		$vergi_dairesi=$row['vergi_dairesi'];
		$kategori_ad=$row['kategori_ad'];
		$banka_adi=$row['banka_adi'];
		$iban=$row['iban_no'];
		$ktg_id=$row['ktg_id'];
		$banka_id=$row['banka_id'];


	} 
}


?>

<body>
	
	
	<div><label class="baslik">FİRMA TANIMLAMA</label></div><br>
	<div id="first">
		<table id="view-edit-table" style="  width: 418px; margin-bottom:10px;">
			<tr>
				<td>
					<label >FİRMA TİPİ</label>
				</td>

				<td> 
					<?php    if($firma_tur=="SAHIS"){

						echo'    <input style="width:10%!important" type="radio" id="sahis" name="sahis" value="sahis" checked="checked" disabled="true">ŞAHIS';
						echo '   <input style="width:10%!important" type="radio" id="tuzel" name="tuzel" value="tuzel" disabled="true">TÜZEL';
					} 
					else
					{
						echo'    <input style="width:10%!important" type="radio" id="sahis" name="sahis" value="sahis"  disabled="true">ŞAHIS';
						echo '   <input style="width:10%!important" type="radio" id="tuzel" name="tuzel" value="tuzel" checked="checked" disabled="true">TÜZEL';

					}

					?>	
					
				</td>
			</tr>
			<tr style="border-top: 2px inset;">
				<td>
					<label for="unvan" class="form-label">FİRMA UNVANI</label>
				</td>
				<td>
					<input type="text" disabled="true" value="<?= $firma_unvani?>" id="unvan" name="unvan">
				</td>
			</tr>
			<tr>
				<td>
					<label for="kategoriler" class="form-label">KATEGORİ</label>
				</td>
				<td>
					<select disabled="true"  id="kategoriler" >
						<option disabled value=<?=$ktg_id?> selected><?=$kategori_ad?></option>
						<?php
						$sqlk = "SELECT * FROM ".DB_SCHEMA_NAME.".kategoriler";

						$resultk = $conn->query($sqlk);
						

						if ($resultk->num_rows > 0) {

							while($row = $resultk->fetch_assoc()) {

								echo '<option value='.$row['ktg_id'].'>'.$row['kategori_ad'].'</option>';
							}
						}

						?>
						
					</select>
				</td>
			</tr>
			<tr>
				<td>
					<label for="email">WEB ADRESİ</label>
				</td>
				<td>
					<input type="text" id="email" name="unvan" disabled="true" value=<?=$email?>>
				</td>

			</tr>

			<tr>
				<td>
					<label for="tel">TELEFON NUMARASI</label>
				</td>
				<td>
					<input class="phone-number" type="text" id="tel" disabled="true" name="tel" value=<?=$tel_no?>>
				</td>

			</tr>

			<tr>
				<td>
					<label for="faks">FAKS NUMARASI</label>
				</td>
				<td>
					<input class="phone-number" type="text" id="faks" name="faks" disabled="true" value=<?=$fax?>>
				</td>

			</tr>
			<tr >
				<td>
					<label for="adres">AÇIK ADRESİ</label>
				</td>
				<td>
					<textarea id="adres" disabled="true" ><?=$adres?></textarea>
				</td>
			</tr>

			<tr >
				<td>
					<label for="vergi-bil">VERGİ BİLGİLERİ</label>
				</td>
				<td>
					<div>
						<div class="vergi">
							<input type="text" value="V.D" style="width:20%!important;  " readonly><input type="text" id="vergi-bil" name="vergi-bil" disabled="true" value=<?=$vergi_dairesi?>></div>
							<div class="vergi" style="position:absolute; margin-left: 20px;">	
								<input type="text" value="V.NO" style="width:50px!important;" readonly><input style="width:150px !important;" type="text" id="vergi-bil2" maxlength="<?php if($firma_tur=="SAHIS"){echo "11";} else {echo "10";} ?>" name="vergi-bil2"disabled="true" value=<?=$vergi_no?>>&nbsp;<span style="font-size:12px;  color: red;" id="errmsg"></span> </div>
							</div>
						</td>
					</tr>
					<tr>
						<td style="width:500px;">
							<label for="banka" style="  width: 50%;">BANKA BİLGİLERİ</label>
</td>
						<td >
							<select id="banka" style="  width: 122%; " disabled="true">
								<option value=<?=$banka_id?> disabled selected><?=$banka_adi?></option>
								<?php 
								$sqlb = "SELECT * FROM ".DB_SCHEMA_NAME.".bankalar";

								$resultb = $conn->query($sqlb);


								if ($resultb->num_rows > 0) {

									while($row = $resultb->fetch_assoc()) {

										echo '<option value='.$row['banka_id'].'>'.$row['banka_adi'].'</option>';
									}
								}
								?>
								
							</select>
						
							<input style=" position:absolute; width: 205px; left: 495px; top: 430px;" type="text" id="iban" name="iban"  placeholder="IBAN" maxlength="26" disabled="true" value=<?=$iban?>> <span style=" display:none; font-size:12px;  color: red;" id="ibanErr"> Iban No 26 Hane Olmalıdır</span>
						</td>
					</tr>
				</table>
				<span style="margin-left: 250px;  color: red; display:none;" >* Tüm Alanları Doldurunuz</span>
				<div class="bottom-right-button">
					<button id="firma-duzenle" class="edit-button" >DUZENLE</button>
					<button id="firma-kaydet" class="save-button" disabled="true">KAYDET</button>
					<button id="iptal" class="cancel-button" disabled="true">IPTAL</button>
				</div>

			</div>
			<br>
			
			
			<div id="personeller" >
				<div class="datagrid">
					<label>YETKİLİ PERSONELLER:</label> <br>
					<table id="yetkiliPersonel" >
						<tr>
							<th class="icon-div">
							</th>
							<th class="icon-div" style="display:none">
							</th>
							<th>
								AD SOYAD
							</th>
							<th>
								GOREV
							</th>
							<th>
								EMAİL
							</th>
							<th>
								CEP TEL
							</th>
							<th>
								İŞ TEL 
							</th>
							<th>
								NOT 
							</th>

						</tr>
						<?php
						$sqlp = "SELECT * FROM ".DB_SCHEMA_NAME.".personel p,".DB_SCHEMA_NAME.".personel_gorev g where p.gorev_id=g.id and p.firma_id=".$firmaId;

						$resultp = $conn->query($sqlp);


						if ($resultp&&$resultp->num_rows > 0) {

							while($row = $resultp->fetch_assoc()) {

								echo '<tr class="yetkiliRow">';
								echo '<td class="icon-div"><button class="deleteRow">sil</button><button class="yetkiliUpdate"style="  width: 67px;">Güncelle</button><button style="display:none" class="yetkiliSave">Kaydet</button></td>';
								echo '<td class="icon-div tdId" style="display:none">'.$row['p_id'].'</td>';
								echo '<td class="ad"><input class="inputs adsoyad" style="width:120px;" disabled value="'.htmlspecialchars($row['adsoyad']).'"></td>';
								echo '<td>'; 
								echo '<select  disabled id="editgorev">';
								$sqlgo = "SELECT * FROM ".DB_SCHEMA_NAME.".personel_gorev where aktif = 1";

								$resultgo = $conn->query($sqlgo);


									if ($resultgo&&$resultgo->num_rows > 0) {

										while($row2 = $resultgo->fetch_assoc()) {
										    if(strcmp($row2['gorev'],$row['gorev'])==0){
											echo '<option selected value='.$row2['id'].'>'.$row2['gorev'].'</option>';
											}else {
											echo '<option value='.$row2['id'].'>'.$row2['gorev'].'</option>';
											 }
										}
									} 
                                echo '</select>';									
								echo'</td>';
								echo '<td><input class="inputs email" style="width:180px;" disabled value="'.htmlspecialchars($row['email']).'"></td>';
								echo '<td><input class="inputs ceptel" style="width:120px;" disabled value="'.htmlspecialchars($row['ceptel']).'"></td>';
								echo '<td><input class="inputs istel" style="width:120px;" disabled value="'.htmlspecialchars($row['istel']).'"></td>';
								echo '<td><input class="inputs note" style="width:170px;" disabled value="'.htmlspecialchars($row['note']).'"></td>';
								echo '</tr>';
							}
						}
						?>
					</table>
				</div>
				<button id="yetkili-tanimla">YETKİLİ PERSONEL TANIMLA</button>
				<button onclick="exportExcel()">Listeyi İndir</button>
			</div>
			<div id="personel-ekleme-tablo" style="display:none">
				<div id="2" style="  border-top: 2px solid;">
						<br>
					<label style="font-size:20px;">ÇALIŞAN BİLGİLERİ</label> <br> <br>
					<table style="  width: 590px;" >
						<tr>
							<td>
								<label for="fullname" class="form-label">AD SOYAD</label>
							</td>
							<td>
								<input type="text" id="fullname" name="fullname">
							</td>
						</tr>
						<tr>
							<td>
								<label for="gorev" class="form-label">GOREV</label>
							</td>
							<td>
								<select id="gorev">
									<option value="" disabled selected></option>
									<?php
									$sqlgo2 = "SELECT * FROM ".DB_SCHEMA_NAME.".personel_gorev";

									$resultgo2 = $conn->query($sqlgo2);


									if ($resultgo2&&$resultgo2->num_rows > 0) {

										while($row = $resultgo2->fetch_assoc()) {
											echo '<option value='.$row['id'].'>'.$row['gorev'].'</option>';
										}
									}
									?>
									
								</select>
							</td>
						</tr>
						<tr>
							<td>
								<label for="personel-email" class="form-label">EMAIL</label>
							</td>
							<td>
								<input type="text" id="personel-email" name="personel-email">
							</td>
						</tr>
						<tr>
							<td>
								<label for="personel-mobile-tel" class="form-label">CEP TEL</label>
							</td>
							<td>
								<input class="phone-number" type="text" id="personel-mobile-tel" name="personel-mobile-tel">
							</td>
						</tr>
						<tr>
							<td>
								<label for="personel-is-tel" class="form-label">İŞ TEL</label>
							</td>
							<td>
								<input class="phone-number" type="text" id="personel-is-tel" name="personel-is-tel"> <input class="notValid" style="position: absolute; width: 49px; margin-left: 10px;" type="text" id="dahili" maxlength="4">
							</td>
						</tr>
						<tr>
							<td>
								<label for="not" class="form-label">NOT</label>
							</td>
							<td>
								<input style="  height: 50px;" class="notValid" type="text" id="not" name="not">
							</td>
						</tr>
					</table>
					<span style="margin-left: 40%;  color: red; display:none" >* Tüm Alanları Doldurunuz</span>
					<button id="personel-kaydet" class="save-button">KAYDET</button>
					<button id="personel-iptal">İPTAL</button>
				</div>
			</div>

		</body>
		</html>

		<script type="text/javascript">

			 
			 $('.yetkiliUpdate').click(function(){
			 $row=$(this).parent().parent();
              $inputs=$row.children("td").children(".inputs").prop("disabled",false);
			  $inputs=$row.children("td").children("#editgorev").prop("disabled",false);
              $row.children("td").children(".deleteRow").hide();
			  $row.children("td").children(".yetkiliUpdate").hide();
			  $row.children("td").children(".yetkiliSave").show();
			 

				
			  
			 });
 		 
			$(".yetkiliSave").click(function(){ 
			 $row=$(this).parent().parent();
			   var firma_id="<?=$firmaId?>";
			   

			   

			  
					$.ajax({
						url: '/dao/personel-guncelle.php',
						data: { 
							adsoyad:$row.children("td").children(".adsoyad").val(),
							gorev_id:$row.children("td").children("#editgorev").children("option:selected").val(),
							email:$row.children("td").children(".email").val(),
							ceptel: $row.children("td").children(".ceptel").val(),
							istel : $row.children("td").children(".istel").val(),
							not : $row.children("td").children(".note").val(),
							firma_id:firma_id,
							pid:$row.children(".tdId").text()

						} })
					.done(function(data) { 
						 
						alert("Personel Başarıyla Güncellendi");
						location.reload();
						
					})
					.fail(function() { alert("Hata Oluştu"+data); });
			
			});
			$("#yetkili-tanimla").click(function(){
				$("#personeller").hide();
				$("#personel-ekleme-tablo").show();
			});

			$("#personel-kaydet").click(function(){
				var validated= validateInputs($(this));
				if(validated){
					var fullname=$('#fullname').val();
					var gorev=$( "#gorev option:selected" ).text();
					var gorevId=$( "#gorev option:selected" ).val();
					var personelMail=$('#personel-email').val();
					var cepTel=$('#personel-mobile-tel').val();
					var dahili='';
					if($('#dahili').val()!=''){
						dahili='/'+$('#dahili').val();
					}
					var istel=$('#personel-is-tel').val()+dahili;
					var not=$('#not').val();
					personelEkleme(fullname,gorev,personelMail,cepTel,istel,not,gorevId);
					/*$("#personel-ekleme-tablo input").val(" ");
					$("#personel-ekleme-tablo").hide();
					$("#personeller").show();*/
					

				}

			});
				$('#iban').blur(function(){
					if($(this).val().length<26){
						$('#ibanErr').show();
					} else{$('#ibanErr').hide();}
					
				});
			function validateInputs(button){
				var divID=button.parent().attr("id");
				var spanSelector="#"+divID+" span";
				var inputSelector="#"+divID+" input:not(.notValid)";
				var selectSelector="#"+divID+" select";
				var validated=true;
				var span=$(spanSelector);
				$(inputSelector).each(function(i,obj){
					if(!($(this)).val()||($.trim($(this).val())=="")){
						validated=false;
					}
				});

				$(selectSelector).each(function(i,obj){
					var id=$(this).attr("id");

					var selected=$("#"+ id+" option:selected" ).text();

					if(!selected || selected==""){
						validated=false;
					}

				});
				
				 if($('#iban').val().length<26){
					    validated=false
						
					  }

				if(!validated){
					span.show();}
					else{
						span.hide();
					}

					return validated;



				}
				$("#personel-iptal").click(function(){
					$("#personel-ekleme-tablo").hide();
					$("#personeller").show();

				});
				function personelEkleme(fullname,gorev,personelMail,cepTel,istel,not,gorevId){
					var firma_id="<?=$firmaId?>";

					$.ajax({
						url: '/dao/personel-ekleme.php',
						data: { 
							adsoyad:fullname,
							gorev_id:gorevId,
							email:personelMail,
							ceptel: cepTel,
							istel:istel,
							not:not,
							firma_id:firma_id

						} })
					.done(function(data) { 
						
						alert("Personel Başarıyla Eklendi");
						location.reload();
						
					})
					.fail(function() { alert("Hata Oluştu"+data); });

				}
				
			
				$( ".phone-number" ).each(function( index ) { 
					$(this).mask("+90 (888) 888 88 88");

				});
				$("#personel-is-tel").mask("+90 (888) 888 88 88");
				
				


				$('#tuzel').click(function(){

					$(this).attr('checked',true);
					$('#sahis').attr('checked',false);
					$('#vergi-bil2').attr("maxlength","10");
					$('#vergi-bil2').val('');
					$("#errmsg").hide();

				});

				$('#sahis').click(function(){

					$(this).attr('checked',true);
					$('#tuzel').attr('checked',false);
					$('#vergi-bil2').attr("maxlength","11");
					$('#vergi-bil2').val('');
					$("#errmsg").hide();

				});
				$('#vergi-bil2').keypress(function (e) { 
					if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
						return false;
					}
				});
				$('#dahili').keypress(function (e) { 
					if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
						return false;
					}
				});
				

				$('#vergi-bil2').blur(function(){

					var maxlengthVergi=parseInt($('#vergi-bil2').attr('maxlength'));
					
					var input=$('#vergi-bil2').val().length ;

					if(input<maxlengthVergi){

						$("#errmsg").html("*Vergi No "+maxlengthVergi+" Hane Olmalıdır").show();
						$('#vergi-bil2').val("");
					}
					else{
						$("#errmsg").hide();
					}

				});

				function deleteRow(button){
					
					var $par = button.parent().parent() ;
					
					var ad=$par.children("td:nth-child(3)").html();
					var email= $par.children("td:nth-child(5)").html();	
					if (confirm(ad+" Silinecek ")) {
						$.ajax({
							url: '/dao/personel-silme.php',
							data: { 
								email:email
							} })
						.done(function(data) { 

							
						location.reload();	

						})
						.fail(function() { alert("Hata Oluştu"+data); });

						
					}
					return false;



				}

				$('.deleteRow').click(function(){
					deleteRow($(this));
				});

				$('#firma-duzenle').click(function(){

					enableInputs("view-edit-table");

				});

				function enableInputs(tableId){

					$('#'+tableId+' input').prop('disabled', false);
					$('#'+tableId+' select').prop('disabled', false);
					$('#'+tableId+' textarea').prop('disabled', false);

					$('.edit-button').prop('disabled', true);
					$('.cancel-button').prop('disabled', false);
					$('.save-button').prop('disabled', false);

				}

				$('.cancel-button').click(function(){
					location.reload();
				});

				$('#firma-kaydet').click(function(){	
					var validated= validateInputs($(this).parent());
					if(validated){
						var firma_id="<?php echo $firmaId;?>";
						var firma_tur="";
						if($("#sahis").is(':checked')){
							firma_tur='SAHIS';
						}else{
							firma_tur='TUZEL';
						}
                        
						$.ajax({
							url: '/dao/firma-guncelle.php',
							data: { firma_id:firma_id,
								firma_unvani:$('#unvan').val(),
								email:$('#email').val(),
								tel_no: $('#tel').val(),
								fax:$('#faks').val(),
								adres:$('#adres').val(),
								vergi_no:$('#vergi-bil2').val(),
								vergi_dairesi:$('#vergi-bil').val(),
								ktg_id:$('#kategoriler option:selected').val(),
								iban_no:$('#iban').val(),
								firma_tur:firma_tur,
								banka_id:$('#banka option:selected').val()


							} })
						.done(function(data) { 

							if(data=="success"){
								
								alert("Firma Güncellendi."); 
								location.reload();}
								else{
									alert("Hata Oluştu, Firma Güncellenemedi:");
								}
							})
						.fail(function() { alert("Hata Oluştu, Firma Güncellenemedi"); });
					}
				});
				
				
				function exportExcel() {
			$('#yetkiliPersonel input').each(function(){
			 $(this).parent().text($(this).val());
			 $(this).remove();
			});	
			$('#yetkiliPersonel select').each(function(){
			  $(this).parent().text($(this).children('option:selected').text());
			  $(this).remove();
			}); 
			$('.icon-div').remove();
			var tableExport = document.getElementById('yetkiliPersonel');
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

</script>