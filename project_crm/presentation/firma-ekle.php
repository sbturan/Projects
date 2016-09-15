

<!DOCTYPE html>
<html>
<meta http-equiv="Content-Type" content="text/HTML; charset=utf-8" />

<title>Firma Tanımlama</title>
<link rel="stylesheet" type="text/css" href="/style/style.css">
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
	
	
	<div><label class="baslik">FİRMA TANIMLAMA</label></div><br>
	<div id="first">
		<table style="width: 418px;  margin-bottom: 10px;">
			<tr>
				<td>
					<label >FİRMA TİPİ</label>
				</td>

				<td> 
					<input style="width:10%!important" type="radio" id="sahis" name="sahis" value="sahis" checked="checked">ŞAHIS
					<input style="width:10%!important" type="radio" id="tuzel" name="tuzel" value="tuzel">TÜZEL
				</td>
			</tr>
			<tr style="border-top: 2px inset;">
				<td>
					<label for="unvan" class="form-label">FİRMA UNVANI</label>
				</td>
				<td>
					<input type="text" id="unvan" name="unvan">
				</td>
			</tr>
			<tr>
				<td>
					<label for="kategoriler" class="form-label">KATEGORİ</label>
				</td>
				<td>
					<select id="kategoriler" >
						<option value="" disabled selected></option>
						<?php 
						$sqlb = "SELECT * FROM ".DB_SCHEMA_NAME.".kategoriler where aktif = 1";

						$resultb = $conn->query($sqlb);


						if ($resultb->num_rows > 0) {

							while($row = $resultb->fetch_assoc()) {

								echo '<option value='.$row['ktg_id'].'>'.$row['kategori_ad'].'</option>';
							}
						}
						?>

					</select>
				</td>
			</tr>
			<tr>
				<td>
					<label for="email">E-MAİL ADRESİ</label>
				</td>
				<td>
					<input type="text" id="email" name="unvan">
				</td>

			</tr>

			<tr>
				<td>
					<label for="tel">TELEFON NUMARASI</label>
				</td>
				<td>
					<input class="phone-number" type="text" id="tel" name="tel">
				</td>

			</tr>

			<tr>
				<td>
					<label for="faks">FAKS NUMARASI</label>
				</td>
				<td>
					<input class="phone-number" type="text" id="faks" name="faks">
				</td>

			</tr>
			<tr >
				<td>
					<label for="adres">AÇIK ADRESİ</label>
				</td>
				<td style="height:55px;">
					<textarea style="height:100%;" id="adres"></textarea>
				</td>
			</tr>

			<tr >
				<td class="uzunluk">
					<label for="vergi-bil">VERGİ BİLGİLERİ</label>
				</td>
				<td style="  padding-top: 10px;" >
					<div>
						<div class="vergi">
							<input type="text" value="V.D" style="width:20%!important;  " readonly><input type="text" id="vergi-bil" name="vergi-bil"></div>
							<div style="  position: absolute; margin-left: 20px;" class="vergi">	
								<input type="text" value="V.NO" style="width:50px!important;" readonly><input style="  width: 150px !important;" type="text" id="vergi-bil2" maxlength="11" name="vergi-bil2">&nbsp;<span style="  color: red;  font-size: 11px;" id="errmsg"></span> </div>
							</div>
						</td>
					</tr>
					<tr>
						<td style="width:500px;">
							<label for="banka" style="  width: 50%;">BANKA BİLGİLERİ</label>
</td>
						<td s>
							<select id="banka" style=" width: 122%;">
								<option value="" disabled selected></option>
								<?php 
								$sqlb = "SELECT * FROM ".DB_SCHEMA_NAME.".bankalar where aktif = 1";

								$resultb = $conn->query($sqlb);


								if ($resultb->num_rows > 0) {

									while($row = $resultb->fetch_assoc()) {

										echo '<option value='.$row['banka_id'].'>'.$row['banka_adi'].'</option>';
									}
								}
								?>
							</select>
						
							<input style="  position: absolute; width: 205px;   left: 495px;  top: 449px;" type="text" id="iban" name="iban" value="TR" maxlength="26" placeholder="IBAN"><span style=" position:absolute; display:none; font-size:12px;  color: red;" id="ibanErr"> Iban No 26 Hane Olmalıdır</span>
						</td>
					</tr>
				</table>
				<span id="all" style="margin-left: 250px;  color: red; display:none;" >* Tüm Alanları Doldurunuz</span> <br>
				<button id="firma-kaydet" style="  margin-left:450px;" class="save-button">KAYDET</button>
			</div>

			
			<script type="text/javascript">


				$('#firma-kaydet').click(function(){	
					var validated= validateInputs($(this));
					if(validated){
						var firma_tur="";
						if($("#sahis").is(':checked')){
							firma_tur='SAHIS';
						}else{
							firma_tur='TUZEL';
						}
						$.ajax({
							url: '/dao/firma-ekleme.php',
							data: { 
								firma_tur:firma_tur,
								email:$('#email').val(),
								firma_unvani:$('#unvan').val(),
								tel_no: $('#tel').val(),
								fax:$('#faks').val(),
								adres:$('#adres').val(),
								vergi_no:$('#vergi-bil2').val(),
								vergi_dairesi: $('#vergi-bil').val(),
								ktg_id : $('#kategoriler option:selected').val(),
								banka_id :$('#banka option:selected').val() ,
								iban_no :$('#iban').val()

							} })
						.done(function(data) { 
							
							alert("Firma Başarıyla Eklendi");
							window.location="firma-liste.php";

						})
						.fail(function() { alert("Hata Oluştu"+data); });


					}
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
						var personelMail=$('#personel-email').val();
						var cepTel=$('#personel-mobile-tel').val();
						var istel=$('#personel-is-tel').val();
						var not=$('#not').val();
						personelEkleme(fullname,gorev,personelMail,cepTel,istel,not);
						$("#personel-ekleme-tablo input").val(" ");
						$("#personel-ekleme-tablo").hide();
						$("#personeller").show();
					}

				});

				function validateInputs(button){
					var divID=button.parent().attr("id");
					var spanSelector="#all";
					var inputSelector="#"+divID+" input";
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
					function personelEkleme(fullname,gorev,personelMail,cepTel,istel,not){
						var deleteButton="<td><button class='deleteRow'>sil</button></td>";
						$('#personeller tbody').append('<tr>'+deleteButton+'<td>'+fullname+'</td><td>'+gorev+'</td><td>'+personelMail+'</td><td>'+cepTel+'</td><td>'
							+istel+'</td><td>'+not+'</td></tr>');
						$(".deleteRow").bind("click",deleteRow);

					}

					$( ".phone-number" ).each(function( index ) { 
						$(this).mask("+90 (888) 888 88 88");

					});


					$('#tuzel').click(function(){

						$(this).attr('checked',true);
						$('#sahis').attr('checked',false);
						$('#vergi-bil2').attr("maxlength","10");
						$('#vergi-bil2').val(' ');
						$("#errmsg").hide();

					});

					$('#sahis').click(function(){

						$(this).attr('checked',true);
						$('#tuzel').attr('checked',false);
						$('#vergi-bil2').attr("maxlength","11");
						$('#vergi-bil2').val(' ');
						$("#errmsg").hide();

					});
					$('#vergi-bil2').keypress(function (e) { 
						if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
							return false;
						}
					});

					$('#vergi-bil2').blur(function(){

						var maxlengthVergi=parseInt($('#vergi-bil2').attr('maxlength'));
						var input=$('#vergi-bil2').val().length ;

						if(input<maxlengthVergi){

							$("#errmsg").html("*Vergi No "+maxlengthVergi+" Hane Olmalıdır").show();
							$('#vergi-bil2').val(' ');
						}
						else{
							$("#errmsg").hide();
						}
					});

					function deleteRow(){

						var par = $(this).parent().parent();
						var ad=par.children("td:nth-child(2)").html();
						var eMail= par.children("td:nth-child(4)").html();	
						if (confirm(ad+" Silinecek ")) {

							par.remove();
						}
						return false;



					}


					$('#iban').blur(function(){
					if($(this).val().length<26){
						$('#ibanErr').show();
					} else{$('#ibanErr').hide();}
					
					});



				</script>
			</body>
			</html>