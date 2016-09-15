<html>
<meta http-equiv="Content-Type" content="text/HTML; charset=utf-8" />

<title>Çalışan Tanımlama</title>
<head>
	<link rel="stylesheet" type="text/css" href="/style/style.css">

	<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">


	<script src="/js/jquery-2.1.4.min.js"></script>
	<script src="/js/jquery.maskedinput.min.js"></script>



	<script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
	<script src="http://jquery-ui.googlecode.com/svn/tags/1.6rc5/ui/i18n/ui.datepicker-tr.js"></script>

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

	<script>

		$(function() {
			$.datepicker.setDefaults( $.datepicker.regional[ "tr" ] );
			$( "#datepicker" ).datepicker({
				changeMonth: true, 
				changeYear: true, 
				yearRange: '1930:2020'});
		});
		
		
	</script>
</head>
<body>
	
	
	<div><label class="baslik">ÇALIŞAN TANIMLAMA</label></div><br>
	<div id="first">
		<table style="  width: 550px;"> 
			<tr>
				<td>
					<label >ÇALIŞAN TİPİ</label>
				</td>

				<td> 
					<input style="width:5% ;  margin-left: 0; " type="radio" id="personel" name="personel" value="personel" checked="checked">PERSONEL
					<input style="width:5%" type="radio" id="sozlesmeli" name="sozlesmeli" value="sozlesmeli">SÖZLEŞMELİ
				</td>
			</tr>
			<tr style="border-top: 2px inset;">
				<td>
					<label for="unvan" class="form-label">AD SOYAD</label>
				</td>
				<td>
					<input type="text" id="adsoyad" name="adsoyad">
				</td>
			</tr>
			<tr>
				<td>
					<label for="tckn">TCKN</label>
				</td>

				<td>
					<div style="width: 100%;  padding-top: 15px;">	
						<input type="text" id="tckn" maxlength="11" name="tckn">&nbsp;<span style=" font-size:12px; color: red; display:none" id="errmsg">*TCKN 11 Basamak Olmalıdır</span> </div>
					</div>
				</td>

			</tr>
			<tr>
				<td>
					<label for="okul">MEZUN OLDUĞU OKUL</label>
				</td>
				<td>
					<input type="text" id="okul" name="okul">
				</td>

			</tr>
			<tr>
				<td>
					<label for="email">EMAİL</label>
				</td>
				<td>
					<input type="text" id="email" name="email">
				</td>

			</tr>
			<tr>
				<td>
					<label for="sinif">SINIF</label>
				</td>
				<td>
					<select name="sinif" id="sinif">
						<option value="" disabled selected></option>
						<option>Çok İyi</option>
						<option>İyi</option>
						<option>Orta</option>
						<option>Kötü</option>
						<option>Çalışılmayacak</option>
					
					
					</select>
				</td>

			</tr>
			<tr >
				<td>
					<label for="adres">ADRES</label>
				</td>
				<td>
					<textarea id="adres"></textarea>
				</td>
			</tr>
			<tr>
				<td>
					<label for="gorev" class="form-label">GÖREVİ</label>
				</td>
				<td>
					<select id="gorev" >
						<option value="" disabled selected></option>
						<?php 
						$sqlb = "SELECT * FROM ".DB_SCHEMA_NAME.".calisan_gorev where aktif = 1";

						$resultb = $conn->query($sqlb);


						if ($resultb->num_rows > 0) {

							while($row = $resultb->fetch_assoc()) {

								echo '<option value='.$row['id'].'>'.$row['calisan_gorev'].'</option>';
							}
						}
						?>

					</select>
				</td>
			</tr>
			<tr>
				<td>
					<label for="dtarihi">DOĞUM TARİHİ</label>
				</td>
				<td>
					<p><input style="width:100%" id="datepicker"  name="dtarihi"></p>
				</td>

			</tr>

			<tr>
				<td>
					<label for="kan" class="form-label">KAN GRUBU</label>
				</td>
				<td>
					<select id="kan" >
						<option value="" disabled selected></option>
						<option>0 Rh+</option>
						<option>0 Rh-</option>
						<option>A Rh+</option>
						<option>A Rh-</option>
						<option>B Rh+</option>
						<option>B Rh-</option>
						<option>AB Rh+</option>
						<option>AB Rh-</option>

					</select>
				</td>
			</tr>

			<tr>
				<td>
					<label for="tel">TELEFON</label>
				</td>
				<td>
					<input class="phone-number" type="text" id="tel" name="tel">
				</td>

			</tr>
			
			<tr>
				<td>
					<label >ASKERLİK BİLGİSİ</label>
				</td>

				<td> 
					<input style="width:10%" type="radio" id="askerlik" name="askerlik" value="tamamladi" checked="checked">YAPILDI
					<input style="width:10%" type="radio" id="askerlik2" name="askerlik2" value="tamamlamadi">YAPILMADI
				</td>
			</tr>
			<tr>
				<td>
					<label >SABIKA KAYDI</label>
				</td>

				<td> 
					<input style="width:10%" type="radio" id="sabika-kaydi" name="sabika-kaydi" value="var" checked="checked">VAR
					<input style="width:10%" type="radio" id="sabika-kaydi2" name="sabika-kaydi2" value="yok">YOK
				</td>
			</tr>
			<tr>
				<td>
					<label >IKAMETGAH</label>
				</td>

				<td> 
					<input style="width:10%" type="radio" id="ikametgah" name="ikametgah" value="verildi" checked="checked">VERİLDİ
					<input style="width:10%" type="radio" id="ikametgah2" name="ikametgah2" value="verilmedi">VERİLMEDİ
				</td>
			</tr>
			<tr>
				<td>
					<label >FOTOĞRAF</label>
				</td>

				<td> 
					<!-- <button id="resim-yukle">YÜKLE</button> -->
					<form id="target" action="" method="post" enctype="multipart/form-data">
						<input style="float:left; width:80%;" type="file" name="file" id="fileToUpload"  required >
						<input style="float:left; width:20%;" type="submit" value="Yükle" class="submit" />
					</form>			

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

							<input style="  position: absolute; width: 205px;   left: 624px;  top: 675px;" type="text" id="iban" name="iban" value="TR" maxlength="26" placeholder="IBAN"><span style=" position:absolute; display:none; font-size:12px;  color: red;" id="ibanErr"> Iban No 26 Hane Olmalıdır</span>
						</td>
					</tr>
			</table>
			<span id="errorspn" style="margin-left: 410px;  color: red; display:none;" >* Tüm Alanları Doldurunuz</span> <br>
			<button id="calisan-kaydet" style="  margin-left: 526px;" class="save-button">KAYDET</button>
		</div>
		<div style="  border: 2px solid; display: none;  position: absolute;  top: 200px;    left:650px;" id="image_preview"><img id="previewing" /></div>
		<script type="text/javascript">
			var fileName="";


			$(document).ready(function (e) {
				$(function() {
					$("#fileToUpload").change(function() {
						
						var file = this.files[0];
						var imagefile = file.type;
						var match= ["image/jpeg","image/png","image/jpg"];
						if(!((imagefile==match[0]) || (imagefile==match[1]) || (imagefile==match[2])))
							{   alert('Sadece jpeg, jpg ve png formatları desteklenmektedir');
						return false;
					}
					else
					{
						var reader = new FileReader();
						reader.onload = imageIsLoaded;
						reader.readAsDataURL(this.files[0]);
					}
				}); 
				});
				function imageIsLoaded(e) {

					$('#image_preview').css("display", "block");
					$('#previewing').attr('src', e.target.result);
					$('#previewing').attr('width', '200px');
					$('#previewing').attr('height', '230px');
				};
				$("#target").on('submit',(function(e) {
					
					e.preventDefault();
					var tckn=$('#tckn').val();
					if(!tckn||tckn==''){
						alert('Resmi kaydetmeden önce TC Kimlik Numarası Girilmelidir');
						return false;
					}
					$.ajax({
						url: "photo-upload.php?tckn="+tckn, 
						type: "POST",             
						data: new FormData(this), 
						contentType: false,       
						cache: false,             
						processData:false,        
						success: function(data)   
						{
							if(data.indexOf('success')!=-1){
								fileName=data.replace("success","");
								alert("resim yüklendi");
							}
							else{
								alert(data);
							}
						}
					});
				}));
			});



$('#personel').click(function(){

	$(this).attr('checked',true);
	$('#sozlesmeli').attr('checked',false);

});

$('#sozlesmeli').click(function(){

	$(this).attr('checked',true);
	$('#personel').attr('checked',false);

});

$('#askerlik').click(function(){

	$(this).attr('checked',true);
	$('#askerlik2').attr('checked',false);

});

$('#askerlik2').click(function(){

	$(this).attr('checked',true);
	$('#askerlik').attr('checked',false);

});

$('#sabika-kaydi').click(function(){

	$(this).attr('checked',true);
	$('#sabika-kaydi2').attr('checked',false);

});

$('#sabika-kaydi2').click(function(){

	$(this).attr('checked',true);
	$('#sabika-kaydi').attr('checked',false);

});

$('#ikametgah').click(function(){

	$(this).attr('checked',true);
	$('#ikametgah2').attr('checked',false);

});

$('#ikametgah2').click(function(){

	$(this).attr('checked',true);
	$('#ikametgah').attr('checked',false);

});

$('#tckn').keypress(function (e) { 
	if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
		return false;
	}
});

$('#tckn').blur(function(){

	var lengthTC=11;
	var input=$('#tckn').val().length ;

	if(input<lengthTC){

		$("#errmsg").show();
		$('#tckn').val('');
	}
	else{
		$("#errmsg").hide();
	}
});
$( ".phone-number" ).each(function( index ) { 
	$(this).mask("+90 (888) 888 88 88");

});

function validateInputs(button){
	var divID=button.parent().attr("id");
	var spanSelector="#errorspn";
	var inputSelector="#"+divID+" input";
	var selectSelector="#"+divID+" select";
	var validated=true;
	var span=$(spanSelector);
	$(inputSelector).each(function(i,obj){
		if($(this).attr('type')!='submit'&&$(this).attr('type')!='file'){
			if(!($(this)).val()||($.trim($(this).val())=="")){
				validated=false;
			}
		}
	});

	$(selectSelector).each(function(i,obj){
		var id=$(this).attr("id");

		var selected=$("#"+ id+" option:selected" ).text();

		if(!selected || selected==""){
			validated=false;
		}

	});

	if(!validated){
		span.show();}
		else{
			span.hide();
		}

		return validated;



	}




	$('#calisan-kaydet').click(function(){

		var validated=validateInputs($(this));
		if(validated){


			var calisan_tipi="";
			if($("#personel").is(':checked')){
				calisan_tipi='PERSONEL';
			}else{
				calisan_tipi='SOZLESMELİ';
			}

			var askerlik="";
			if($("#askerlik").is(':checked')){
				askerlik='TAMAMLANDI';
			}else{
				askerlik='TAMAMLANMADI';
			}

			var sabika="";
			if($("#sabika-kaydi").is(':checked')){
				sabika='VAR';
			}else{
				sabika='YOK';
			}


			var ikametgah="";
			if($("#ikametgah").is(':checked')){
				ikametgah='VERILDI';
			}else{
				ikametgah='VERILMEDI';
			}
               
			   if($("#iban").val().length<26) {
						alert("IBAN Numarası 26 hane olmalıdır");
						return false;
					}

			$.ajax({
				url: '/dao/calisan-ekleme.php',
				data: { 
					personel_tip:calisan_tipi,
					adsoyad : $('#adsoyad').val(),
					tckn:$('#tckn').val(),
					okul:$('#okul').val(),
					email: $('#email').val(),
					gorev_id: $('#gorev option:selected').val(),
					dogum_tarihi:$('#datepicker').val(),
					kan_grubu: $('#kan option:selected').text(),
					sinif: $('#sinif option:selected').text(),
					tel_no: $('#tel').val(),
					foto_path : fileName,
					adres :$('#adres').val() ,
					askerlik : askerlik,
					sabika : sabika,
					ikametgah : ikametgah,
					banka_id :$('#banka option:selected').val(),
					iban :  $('#iban').val()

				} })
			.done(function(data) { 
				alert("Calisan Başarıyla Eklendi");
				window.location="calisan-liste.php";

			})
			.fail(function() { alert("Hata Oluştu"+data); });


		}

	});
	$('#iban').blur(function(){
					if($(this).val().length<26){
						$('#ibanErr').show();
					} else{$('#ibanErr').hide();}
					
					});
</script>





</body>
</html>


