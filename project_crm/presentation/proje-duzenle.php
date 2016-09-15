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
	

	<?php 
	include("topMenu.php");
	include("utils/utils.php");
	require_once("config/config.php");



	$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
	if (!$conn) {
		die("Connection failed: " . mysqli_connect_error());
	}

	$conn ->set_charset("utf8");
	$id=$_GET['sct'];

	$sqlp = "SELECT *,f.firma_id firmid,p.is_adi isadi FROM ".DB_SCHEMA_NAME.".firmalar f,".DB_SCHEMA_NAME.".projeler p left join ".DB_SCHEMA_NAME.".personel pe on pe.p_id = p.sahip,".DB_SCHEMA_NAME.".calisan c  where p.firma_id = f.firma_id  and c.personel_id=p.proje_sorumlusu and proje_id=".$id;

	$resultp = $conn->query($sqlp);
	
	$rowProject = $resultp->fetch_assoc();

	

	?>

	<script>

	$(function() {

		$( "#isbittarih" ).datetimepicker({
			format:'d.m.Y H:i',
			lang : 'tr'
			
		});

	});

	$(function() {
		$( "#isbastarih" ).datetimepicker({
			format:'d.m.Y H:i',
			lang : 'tr'
		});

	});


	</script>
</head>
<body>
	<div>
		<div><label class="baslik">PROJE TANIMLAMA</label></div><br>
		<div id="first">
			<table id="proje-table">
				<tr>
					<td>
						<label >FİRMA</label>
					</td><td> 
					<select disabled="true" disabled="true" id="unvan" >
						
						<?php 
						$sqlb = "SELECT firma_id,firma_unvani FROM ".DB_SCHEMA_NAME.".firmalar";

						$resultb = $conn->query($sqlb);


						if ($resultb->num_rows > 0) {

							while($row = $resultb->fetch_assoc()) {
								if($rowProject['firmid']==$row['firma_id']){
									echo '<option selected value='.$row['firma_id'].'>'.$row['firma_unvani'].'</option>';
								}else{
									echo '<option value='.$row['firma_id'].'>'.$row['firma_unvani'].'</option>';		
								}
								
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
					<input disabled="true" type="text" id="is_ad" name="is_ad" value="<?php print (htmlspecialchars(stripslashes($rowProject['isadi']))) ?>">
				</td>	
			</tr>
			<tr>

				<td>
					<label >BÜTÇE ONAYLANDI MI?</label>
				</td>

				<td> 
					<input style="width:10%" disabled="true" type="radio" id="btcevet" name="btcevet" value="btcevet" 
					<?php if(strcmp($rowProject['butce'],"EVET")==0){echo 'checked="checked"';} ?> >EVET
					<input disabled="true" style="width:10%" type="radio" id="btchayir" name="btchayir" value="btchayir"
					<?php if(strcmp($rowProject['butce'],"EVET")!=0){echo 'checked="checked"';} ?>>HAYIR
				</td>
			</tr>
			<tr>

				<td>
					<label >İŞİN KAYNAĞI</label>
				</td>

				<td> 
					<input style="width:10%" disabled="true" type="radio" id="kykevet" name="kykevet" value="kykevet" 
					<?php if(strcmp($rowProject['kaynak'],"KP")==0){echo 'checked="checked"';} ?> >KP
					<input disabled="true" style="width:10%" type="radio" id="kykhayir" name="kykhayir" value="kykhayir"
					<?php if(strcmp($rowProject['kaynak'],"SK")==0){echo 'checked="checked"';} ?>>SK
					<input disabled="true" style="width:10%" type="radio" id="kykevent" name="kykevent" value="kykevent"
					<?php if(strcmp($rowProject['kaynak'],"KP-Event")==0){echo 'checked="checked"';} ?>>KP-Event
				</td>
			</tr>
			<tr>
				<td>
					İŞ BAŞLANGIÇ TARİHİ
				</td>
				<td>
					<input type="text" disabled="true" id="isbastarih" name="isbastarih" value=<?php echo $rowProject['baslangic_tarih'];?>>
				</td>	
			</tr> 
			<tr>
				<td>
					İŞ BİTİŞ TARİHİ
				</td>
				<td>
					<input type="text" disabled="true" id="isbittarih" name="isbittarih" value=<?php echo $rowProject['bitis_tarihi'];?>>
				</td>	
			</tr>
			<tr>
				<td>
					İŞİN LOKASYONU
				</td>
				<td>
					<input type="text" disabled="true" id="is_lokasyon" name="is_lokasyon" value="<?php print (htmlspecialchars(stripslashes($rowProject['isin_lokasyonu']))) ?>">
				</td>	
			</tr>
			<tr>
				<td>
					<label>PROJE SORUMLUSU</label>
				</td><td> 
				<select id="sorumlu" disabled="true">
					<option value="" disabled selected></option>
					<?php 
					$sqlb = "SELECT personel_id,adsoyad  FROM ".DB_SCHEMA_NAME.".calisan";

					$resultb = $conn->query($sqlb);


					if ($resultb->num_rows > 0) {

						while($row = $resultb->fetch_assoc()) {
							iF($rowProject['personel_id'] == $row['personel_id']){
								echo '<option selected value='.$row['personel_id'].'>'.$row['adsoyad'].'</option>';
							}else{
								echo '<option value='.$row['personel_id'].'>'.$row['adsoyad'].'</option>';
							}
							
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
			<select id="sahip" disabled="true" >
				<option value="" disabled selected></option>
				<?php  
				$sqlb = "SELECT p_id,adsoyad ad FROM ".DB_SCHEMA_NAME.".personel  where firma_id = ".$rowProject['firmid'];

				$resultb = $conn->query($sqlb);


				if ($resultb->num_rows > 0) {

					while($row = $resultb->fetch_assoc()) {
						iF($rowProject['p_id'] == $row['p_id']){
							echo '<option selected value='.$row['p_id'].'>'.$row['ad'].'</option>';
						}else{
							echo '<option value='.$row['p_id'].'>'.$row['ad'].'</option>';
						}
						
					}
				}
				?>

			</select>


		</td>
	</tr>
	<tr>
		<td>
			<label>ÇALIŞACAK KİŞİLİR</label>
		</td><td> 
		<select id="sbOne" disabled="true" style="  width: 170px;" disabled="true" multiple="multiple">
			
			<?php 
			
			$sqlpc = "SELECT calisan_id FROM ".DB_SCHEMA_NAME.".proje_calisan where proje_id=".$id;
			$resultpc = $conn->query($sqlpc);
			$i=0;
			$calisanlar=array();
			
			if ($resultpc->num_rows > 0) {

				while($rowpc = $resultpc->fetch_assoc()) {
					$calisanlar[$i]=$rowpc['calisan_id'];
					$i=$i+1;       

					
				}
			}

			$sqlb = "SELECT personel_id,adsoyad FROM ".DB_SCHEMA_NAME.".calisan";
			$resultb = $conn->query($sqlb);


			if ($resultb->num_rows > 0) {

				while($row = $resultb->fetch_assoc()) {
					
					if(in_array($row['personel_id'], $calisanlar)){
						null;
					}else{
						echo '<option value='.$row['personel_id'].'>'.$row['adsoyad'].'</option>';    		
					}

					
				}
			}
			?>

		</select>
		
		<select id="sbTwo" disabled="true" style="  width: 170px;" multiple="multiple">
			
			<?php 
			
			$sqlpc = "SELECT calisan_id FROM ".DB_SCHEMA_NAME.".proje_calisan where proje_id=".$id;
			$resultpc = $conn->query($sqlpc);
			$i=0;
			$calisanlar=array();
			
			if ($resultpc->num_rows > 0) {

				while($rowpc = $resultpc->fetch_assoc()) {
					$calisanlar[$i]=$rowpc['calisan_id'];
					$i=$i+1;       

					
				}
			}

			$sqlb = "SELECT personel_id,adsoyad FROM ".DB_SCHEMA_NAME.".calisan";
			$resultb = $conn->query($sqlb);


			if ($resultb->num_rows > 0) {

				while($row = $resultb->fetch_assoc()) {
					
					if(in_array($row['personel_id'], $calisanlar)){
						echo '<option selected value='.$row['personel_id'].'>'.$row['adsoyad'].'</option>'; 
					}else{
						null; 		
					}

					
				}
			}
			?>

		</select>
		
		<br />
		
		<input type="button" style="   margin-left: 116px; width: 25px;" id="left" value="<" />
		<input type="button"  style="  width: 25px;" id="right" value=">" />
		<input type="button"   style="  width: 25px;" id="leftall" value="<<" />
		<input type="button"  style="  width: 25px;" id="rightall" value=">>" />
	</td>
</tr>			
</table> 		
<span id="errorspn" style="margin-left: 53%;  color: red; display:none;" >* Tüm Alanları Doldurunuz</span>
<button id="proje-duzenle" style="margin-left: 468px; margin-top: 10px; "class="edit-button" >DUZENLE</button>
<button id="proje-kaydet"  class="save-button" disabled="true">KAYDET</button>
<button id="iptal" class="cancel-button" disabled="true">IPTAL</button>
</div>
</div>
</div>	

<script type="text/javascript">
$('#proje-duzenle').click(function(){
	enableInputs('proje-table');

});

$('#iptal').click(function(){

	location.reload();
}) ;

function enableInputs(tableId){

	$('#'+tableId+' input').prop('disabled', false);
	$('#'+tableId+' select').prop('disabled', false);
	$('#'+tableId+' textarea').prop('disabled', false);

	$('.edit-button').prop('disabled', true);
	$('.cancel-button').prop('disabled', false);
	$('.save-button').prop('disabled', false);

	$('#fotoTr').show();

}


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
$('#proje-kaydet').click(function(){	
	var validated=true;
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
			url: '/dao/proje-guncelle.php',
			data: {
				id : "<?php echo $id;?>" ,
				butce:butce,
				email:$('#email').val(),
				firma_id:$('#unvan option:selected').val(),
				is_ad:$('#is_ad').val(),
				isbastarih:a1,
				isbittarih:a2,
				is_lokasyon: $('#is_lokasyon').val(),
				sorumlu  : $('#sorumlu option:selected').val(),
				sahip  : $('#sahip option:selected').val(),
				kaynak :kaynak
			} }).done(function(data) {
			
			  projeid = "<?php echo $id;?>";
				
				$.ajax({
					url: '/dao/projecalisansil.php',
					data: { 
				
						id :projeid,
						

					} }).done(function(){
                        var clist="";
						$('#sbTwo option').each(function(){
                                   clist=clist+","+$(this).val();
                              });
							   clist=clist.slice(1);
								
                             
                            
							$.ajax({
								url: '/dao/projecalisan-ekleme.php',
								data: { 
							     
									proje_id :projeid,
									
									calisacakkisiler:clist

								} }).done(function(data){
                            
				                         
									

								}).fail(function(data) { alert("Hata Oluştu"+data); });
								
								
							
                                     
							
                                                           
						
						

					}).fail(function(data) { alert("Hata Oluştu"+data); });		
					 
					 

					alert("Proje Başarıyla Güncellendi");
					window.location="proje-liste.php";


				});

		}
	});


function validateInputs(button){
	var divID=button.parent().attr("id");
	var spanSelector="#"+divID+" span";
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