<html>
<meta http-equiv="Content-Type" content="text/HTML; charset=utf-8" />

<title>Proje Tanımlama</title>
<head>
	<link rel="stylesheet" type="text/css" href="/style/style.css">

	<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
		<link rel="stylesheet" type="text/css" href="/style/jquery.datetimepicker.css">
	

   
	<script src="/js/jquery-2.1.4.min.js"></script>
	<script src="/js/jquery.maskedinput.min.js"></script>
	<script src="/js/jquery.datetimepicker.js"></script>
    


	<script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
	<script src="//code.jquery.com/ui/1.11.1/jquery-ui.js"></script>

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

		$( "#isbittarih" ).datetimepicker({
			format:'d.m.Y H:i',
		    lang:'tr'
});
	});

	$(function() {
		$( "#isbastarih" ).datetimepicker({
			format:'d.m.Y H:i',
		    lang:'tr'
});
	});


	</script>
</head>
<body>
	<div>
		<div><label class="baslik">PROJE TANIMLAMA</label></div><br>
		<div id="first">
			<table>
				<tr>
					<td>
						<label >FİRMA</label>
					</td><td> 
					<select id="unvan" >
						<option value="" disabled selected></option>
						<?php 
						$sqlb = "SELECT firma_id,firma_unvani FROM ".DB_SCHEMA_NAME.".firmalar order by firma_unvani";

						$resultb = $conn->query($sqlb);


						if ($resultb->num_rows > 0) {

							while($row = $resultb->fetch_assoc()) {

								echo '<option value='.$row['firma_id'].'>'.$row['firma_unvani'].'</option>';
							}
						}
						?>

					</select>
					

				</td>
			</tr>
			<tr>
				<td>
					İŞİN ADI
				</td>
				<td>
					<input type="text" id="is_ad" name="is_ad">
				</td>	
			</tr>
			<tr>

				<td>
					<label >BÜTÇE ONAYLANDI MI?</label>
				</td>

				<td> 
					<input style="width:10%" type="radio" id="btcevet" name="btcevet" value="btcevet" checked="checked">EVET
					<input style="width:10%" type="radio" id="btchayir" name="btchayir" value="btchayir">HAYIR
				</td>
			</tr>
			<tr>

				<td>
					<label >İŞİN KAYNAĞI</label>
				</td>

				<td> 
					<input style="width:10%" type="radio" id="kykevet" name="kykevet" value="kykevet" checked="checked">KP
					<input style="width:10%; margin-left: 23px;" type="radio" id="kykhayir" name="kykhayir" value="kykhayir">SK
				    <input style="width:10%" type="radio" id="kykevent" name="kykevent" value="kykevent" >KP-Event
					
				</td>
			</tr>
			<tr>
				<td>
					İŞ BAŞLANGIÇ TARİHİ
				</td>
				<td>
					<input type="datetime" id="isbastarih" name="isbastarih">
				</td>	
			</tr> 
			<tr>
				<td>
					İŞ BİTİŞ TARİHİ
				</td>
				<td>
					<input type="datetime" id="isbittarih" name="isbittarih">
				</td>	
			</tr>
			<tr>
				<td>
					İŞİN LOKASYONU
				</td>
				<td>
					<input type="text" id="is_lokasyon" name="is_lokasyon">
				</td>	
			</tr>
			<tr>
				<td>
					<label>PROJE SORUMLUSU</label>
				</td><td> 
				<select id="sorumlu" >
					<option value="" disabled selected></option>
					<?php 
					$sqlb = "SELECT personel_id,adsoyad FROM ".DB_SCHEMA_NAME.".calisan";

					$resultb = $conn->query($sqlb);


					if ($resultb->num_rows > 0) {

						while($row = $resultb->fetch_assoc()) {

							echo '<option value='.$row['personel_id'].'>'.$row['adsoyad'].'</option>';
						}
					}
					?>

				</select>


			</td>
		</tr>
		<tr>
		<td>
		<label>İŞİN SAHİBİ</label>
				</td><td> 
				<select id='sahip' disabled   >
		<option id="firmaSecin" value='' disabled selected >Firma Seçin</option>
		<?php



		$sqlKategori = "SELECT *
		FROM ".DB_SCHEMA_NAME.".personel ;";

		$resultKategori = $conn->query($sqlKategori);

		if ($resultKategori->num_rows > 0) {

			while($row = $resultKategori->fetch_assoc()) {

				echo "<option class=".$row['firma_id']." value=". $row['p_id'] ."> ".$row['adsoyad']."</option>";

			} 

		}

		?>
	</select>


			</td>
		</tr>
		<tr>
			<td>
				<label>ÇALIŞACAK KİŞİLER</label>
			</td><td> <div>
			<select id="sbOne" class="notValidate" style="  width: 170px;" multiple="multiple">
				<option value="" disabled selected></option>
				<?php 
				$sqlb = "SELECT personel_id,adsoyad FROM ".DB_SCHEMA_NAME.".calisan";

				$resultb = $conn->query($sqlb);


				if ($resultb->num_rows > 0) {

					while($row = $resultb->fetch_assoc()) {

						echo '<option value='.$row['personel_id'].'>'.$row['adsoyad'].'</option>';
					}
				}
				?>
				</select>
        
            <select id="sbTwo" class="notValidate" style="  width: 170px;" multiple="multiple">
 
             </select>
  
 
    <br />
 
    <input type="button" style="   margin-left: 116px; width: 25px;" id="left" value="<" />
    <input type="button"  style="  width: 25px;" id="right" value=">" />
    <input type="button"   style="  width: 25px;" id="leftall" value="<<" />
    <input type="button"  style="  width: 25px;" id="rightall" value=">>" />
            </div>
			


		</td>
	</tr>			
</table>		
<span id="errorspn" style="margin-left: 53%;  color: red; display:none;" >* Tüm Alanları Doldurunuz</span>
<button id="proje-kaydet" style="  margin-left: 61%;" class="save-button">KAYDET</button>
</div>
</div>
</div>	

<script type="text/javascript">
$('#btcevet').click(function(){
   
	$(this).attr('checked',true);
	$('#btchayir').attr('checked',false);

});

$('#btchayir').click(function(){

	$(this).attr('checked',true);
	$('#btcevet').attr('checked',false);

});
$('#kykevet').click(function(){
   
	$(this).attr('checked',true);
	$('#kykhayir').attr('checked',false);
    $('#kykevent').attr('checked',false);
});

$('#kykhayir').click(function(){

	$(this).attr('checked',true);
	$('#kykevet').attr('checked',false);
    $('#kykevent').attr('checked',false);
});
$('#kykevent').click(function(){

	$(this).attr('checked',true);
	$('#kykhayir').attr('checked',false);
	$('#kykevet').attr('checked',false);
});
var firmaId="0";

$('#unvan').on('change',function(){


					$('#sahip').prop("disabled",false);
					
					$('#sahip').val('');


					firmaId=this.value;
					

						var f_id=$(this).parent().children('.firmaId').text();

						

						$('#sahip option').hide();
						$('#sahip option').attr("disabled",true);
						$('#sahip .'+firmaId).each(function(){

							$(this).show();
                           $(this).attr("disabled",false);


						});
						$('#firmaSecin').remove();



					}); 
$('#proje-kaydet').click(function(){	
	var validated= validateInputs($(this));
	var projeid;
	if(validated){
		var butce="";
		var kaynak="";
		if($("#btcevet").is(':checked')){
			butce='EVET';
		}else{
			butce='HAYIR';
		}
		if($("#kykevet").is(':checked')){
			kaynak='KP';
		}
		if($("#kykevent").is(':checked')){
			kaynak='KP-Event';
		}
		if($("#kykhayir").is(':checked')){
			kaynak='SK';
		}
		var a1 = $('#isbastarih').val();
		a1 = a1.replace(" ", "-"); 
		var a2 = $('#isbittarih').val();
		a2 = a2.replace(" ", "-"); 
		$.ajax({
			url: '/dao/proje-ekleme.php',
			data: { 
				butce:butce,
				email:$('#email').val(),
				firma_id:$('#unvan option:selected').val(),
				is_ad:$('#is_ad').val(),
				kaynak :kaynak,
				isbastarih:a1,
				isbittarih:a2,
				is_lokasyon: $('#is_lokasyon').val(),
				sorumlu  : $('#sorumlu option:selected').val(),
				sahip  : $('#sahip option:selected').val()
                
			} }).done(function(data) {


				projeid = data;
				$('#sbTwo option').each(function(){

					$.ajax({
						url: '/dao/projecalisan-ekleme.php',
						data: { 
							proje_id :projeid,
							calisacakkisiler:$(this).val()

						} }).done(function(){

							
							

						}).fail(function(data) { alert("Hata Oluştu"+data); });

					});

				alert("Proje Başarıyla Eklendi");
				window.location="proje-liste.php";
				
			});

		}
	});
function validateInputs(button){
	var divID=button.parent().attr("id");
	var spanSelector="#"+divID+" span";
	var inputSelector="#"+divID+" input";
	var selectSelector="#"+divID+" select:not(.notValidate)";
	var validated=true;
	var span=$(spanSelector);
	$(inputSelector).each(function(i,obj){
		if(!($(this)).val()||($.trim($(this).val())=="")){
			validated=false;
		}
	});

	$(selectSelector).each(function(i,obj){
		var id=$(this).attr("id");
       if(id != "sbOne") {  
		var selected=$("#"+ id+" option:selected" ).text();
         
		if(!selected || selected==""){
			
			validated=false;
		}
	  }
	
	});

	if(!validated){
		span.show();}
		else{
			span.hide();
		}

		return validated;



	}
	 

 function moveItems(origin, dest) {
	
    $(origin).find(':selected').appendTo(dest);
}

function moveAllItems(origin, dest) {
    $(origin).children().appendTo(dest);
}
 
$('#left').click(function () {
	
    moveItems('#sbTwo', '#sbOne');
});
 
$('#right').on('click', function () {

    moveItems('#sbOne', '#sbTwo');
});
 
$('#leftall').on('click', function () {
	
    moveAllItems('#sbTwo', '#sbOne');
});
 
$('#rightall').on('click', function () {
	
    moveAllItems('#sbOne', '#sbTwo');
});

	</script>
</body>
</html>