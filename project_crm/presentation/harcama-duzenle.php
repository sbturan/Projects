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

      session_start();
	$harcamaId=$_GET['harcamaId'];

	$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
	if (!$conn) {
		die("Connection failed: " . mysqli_connect_error());
	}

	$conn ->set_charset("utf8");
    $sql = "SELECT * FROM ".DB_SCHEMA_NAME.".harcamalar h,".DB_SCHEMA_NAME.".harcama_tipler he where h.harcama_tipi = he.id  and  h.harcama_id=".$harcamaId;

$result = $conn->query($sql);
echo $conn->error;

if ($result->num_rows > 0) {

	while($row = $result->fetch_assoc()) {


		$harcamatip=$row['harcama_tipi'];
		$firma_id =$row['firma_id '];
		$proje_id=$row['proje_id'];
		$fatura_tarih=$row['fatura_tarih'];
		$tip=$row['harcama_tipi'];
		$harcama_tutar=$row['harcama_tutar'];
		$fatura_no=$row['fatura_no'];
		$harcama_yapanid=$row['harcama_yapanid'];
		$harcama_durum=$row['harcama_durum'];
		$aciklama=$row['aciklama'];
		$tarih=$row['odeme_tarih'];
        $sirkettip=$row['sirket_tipi'];
		$isharici=$row['is_harici'];
        $kdv=$row['KDV']; 
	} 
}


?>

    
	<script>
        
	$(function() {
		$.datepicker.setDefaults( $.datepicker.regional[ "tr" ] );
		$( "#datepicker2" ).datepicker({
			changeMonth: true, 
			changeYear: true, 
			yearRange: '1930:2020'});
	});
	$(function() {
		$.datepicker.setDefaults( $.datepicker.regional[ "tr" ] );
		$( "#datepicker1" ).datepicker({
			changeMonth: true, 
			changeYear: true, 
			yearRange: '1930:2020'});
	});
	$(function() {
		$.datepicker.setDefaults( $.datepicker.regional[ "tr" ] );
		$( "#datepicker3" ).datepicker({
			changeMonth: true, 
			changeYear: true, 
			yearRange: '1930:2020'});
	});

	$(document).ready(function() {
		$("#otutar").keydown(function (e) {
        // Allow: backspace, delete, tab, escape, enter and .
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
             // Allow: Ctrl+A, Command+A
             (e.keyCode == 65 && ( e.ctrlKey === true || e.metaKey === true ) ) || 
             // Allow: home, end, left, right, down, up
             (e.keyCode >= 35 && e.keyCode <= 40)) {
                 // let it happen, don't do anything
             return;
         }
        // Ensure that it is a number and stop the keypress
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        	e.preventDefault();
        }
    });
	});
		

</script>
</head>
<body>
	
	
	<div><label class="baslik">HARCAMA TANIMLAMA</label></div><br>
	<div id="first">
		<table id="harcama-table">
		<tr>
				<td>
					<label >ŞİRKET TİPİ</label>
				</td>

				<td> 
				    <?php    if($sirkettip=="SK"){

						echo'    <input style="width:10%!important" type="radio" id="SK" name="SK" value="SK" checked="checked" disabled="true">SK';
						echo '   <input style="width:10%!important" type="radio" id="KP" name="KP" value="KP" disabled="true">KP';
					    echo '   <input style="width:10%!important" type="radio" id="KPevent" name="KPevent" value="KPevent"  disabled="true">KPevent';
 
					} 
					
					 if($sirkettip=="KP")
					 {
					    echo '   <input style="width:10%!important" type="radio" id="SK" name="SK" value="SK" disabled="true">SK';
						echo '   <input style="width:10%!important" type="radio" id="KP" name="KP" value="KP" checked="checked"  disabled="true">KP';
					    echo '   <input style="width:10%!important" type="radio" id="KPevent" name="KPevent" value="KPevent"  disabled="true">KPevent';
 
					 }
                     if($sirkettip=="KPevent"){
						echo '   <input style="width:10%!important" type="radio" id="SK" name="SK" value="SK" >SK';
						echo '   <input style="width:10%!important" type="radio" id="KP" name="KP" value="KP"  disabled="true">KP';
					    echo '   <input style="width:10%!important" type="radio" id="KPevent" name="KPevent" disabled="true" value="KPevent" checked="checked" disabled="true">KPevent';
					 } 
					
					?>
				
				</td>
			</tr>
			
			<tr>
				<td>
					<label >İŞ/HARİCİ</label>
				</td>

				<td> 
				    <?php    if($isharici=="İş"){

						echo'    <input style="width:10%!important" type="radio" id="is" name="is" value="is" checked="checked" disabled="true">İş';
						echo'    <input style="width:10%!important" type="radio" id="harici" name="harici" value="harici"  disabled="true">Harici';
					} else{
					
					     echo'    <input style="width:10%!important" type="radio" id="is" name="is" value="is" disabled="true">İş';
						echo'    <input style="width:10%!important" type="radio" id="harici" name="harici" value="harici"  checked="checked"  disabled="true">Harici';
					
					} 
					
					?>
				
				</td>
			</tr>
			
			
		<tr>
			<td>
				<label >FATURA TARİHİ</label>
			</td>

			<td> 
				<input id="datepicker1"  name="ftarihi" disabled="true" value="<?= $fatura_tarih?>">
			</td>
		</tr>

		<tr>
			<td>
				<label >FATURA NO</label>
			</td>

			<td> 
				<input class="faturano" type="text" id="faturano" disabled="true" name="faturano" value="<?= $fatura_no?>">   
				<td> 
				</td>
			</tr>
			<tr>
				<td>
					<label >HARCAMA TİPİ</label>
				</td>
				<td> 
					<select id="harcamatip" disabled="true" name="harcamatip" >
						<option value="" disabled disabled value=<?=$ktg_id?> selected><?=$kategori_ad?>></option>
						<?php 
						$sqlb = "SELECT * FROM ".DB_SCHEMA_NAME.".harcama_tipler";

						$resultb = $conn->query($sqlb);


						if ($resultb->num_rows > 0) {

							while($row = $resultb->fetch_assoc()) {
                              
							  iF( $row['id'] == $tip){
								  echo '<option selected value='.$row['id'].'>'.$row['harcama_tip'].'</option>';
							  }else{
								echo '<option value='.$row['id'].'>'.$row['harcama_tip'].'</option>';
							  }	
							}
						}
						
							
							
						?>
					</select>
					


				</td>
			</tr>
			<tr>
				<td>
					<label >HARCAMA YAPAN</label>
				</td>
				<td> 
					<select id="harcamayap" disabled="true" name="harcamayap" >
						<option value="" disabled selected></option>
						<?php 
						$sqlb = "SELECT * FROM ".DB_SCHEMA_NAME.".calisan";

						$resultb = $conn->query($sqlb);


						if ($resultb->num_rows > 0) {

							while($row = $resultb->fetch_assoc()) {
                               iF( $row['personel_id'] == $harcama_yapanid){
							   echo '<option selected value='.$row['personel_id'].'>'.$row['adsoyad'].'</option>';}
								else{
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
					<label >HARCAMA TUTARI</label>
				</td>

				<td> 
					<input class="tutar" type="text" disabled="true" id="tutar" name="tutar" value="<?= $harcama_tutar?>" >
				</td>
			</tr>
			<tr>
				<td>
					<label >KDV</label>
				</td>

				<td> 
					<input class="tutar" type="text" disabled="true" id="kdv" name="kdv" value="<?= $kdv?>" >
				</td>
			</tr>
			
			<tr>
				<td>
					<label >HARCAMA DURUMU</label>
				</td>
				<td>
				    <select  id="cmbMake" name="Make" disabled="true"  >
						<option value="" disabled selected></option>
						<?php 
						$sqlb = "SELECT * FROM ".DB_SCHEMA_NAME.".harcama_durum";

						$resultb = $conn->query($sqlb);


						if ($resultb->num_rows > 0) {

							while($row = $resultb->fetch_assoc()) {
                               iF( $row['id'] == $harcama_durum){
							   echo '<option selected value='.$row['id'].'>'.$row['harcama_adi'].'</option>';}
								else{
									echo '<option value='.$row['id'].'>'.$row['harcama_adi'].'</option>';
									
								}
							}
						}
						?>
					</select>
				    
					
				</td>
			</tr>
			<tr>
				<td>
					<label >ÖDEME TARİHİ</label>
				</td>

				<td> 
					<input id="datepicker2"  name="otarihi" disabled="true" value="<?= $tarih?>"
				</td>
			</tr>
			<tr>
				<td>
					<label >AÇIKLAMA</label>
				</td>

				<td> 
					<textarea id="aciklama" disabled="true" value="<?= $aciklama?>"><?=$aciklama?></textarea> 
				</td>
			</tr>
			

		</table>
			<span style="margin-left: 53%;  color: red; display:none;" >* Tüm Alanları Doldurunuz</span>
			<div class="bottom-right-button">
				<button id="harcama-duzenle" class="edit-button" >DUZENLE</button>
				<button id="harcama-kaydet" class="save-button" disabled="true">KAYDET</button>
				<button id="iptal" class="cancel-button" disabled="true">IPTAL</button>
			</div>
		</div>
		<div style="  border: 2px solid;  position: absolute;  top: 200px;  left: 75%;" id="image_preview"><img  <?php if(!is_null($foto_path)&&strcmp(trim($foto_path),"")!=0){echo 'src="photos/'.$foto_path.'"' ;}  ?> id="previewing" /></div>

		<script type="text/javascript">

			var fileName="<?php echo $foto_path; ?>";

			$('#harcama-duzenle').click(function(){
				enableInputs('harcama-table');

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

			




	
           

	$('#harcama-kaydet').click(function(){
							
							var validated=validateInputs($(this));
				
							if(validated){
								var firma_tur="";
								var is_harici="";
								if($("#SK").is(':checked')){
									firma_tur='SK';
								}
								if($("#KP").is(':checked')){
									firma_tur='KP';
								}
								if($("#KPevent").is(':checked')){
									firma_tur='KPevent';
								}
								if($("#is").is(':checked')){
									is_harici='İş';
								}
								
								if($("#harici").is(':checked')){
									is_harici='Harici';
								}
								
								$.ajax({
									url: '/dao/harcama-guncelle.php',
									data: { 
									    firma_tur : firma_tur,
										tutar : $('#tutar').val().replace(",","."),
										kdv  :   $('#kdv').val().replace(",","."),
										faturano : $('#faturano').val(),
										otarihi:$('#datepicker2').val(),
										ftarihi:$('#datepicker1').val(),
										odemetip: $('#odemetip option:selected').text(),
										harcamatip: $('#harcamatip option:selected').val(),
										harcamayap: $('#harcamayap option:selected').val(),
										aciklama:$('#aciklama').val(), 
										durum:$('#cmbMake').val(),
										is_harici:is_harici,
										id: "<?php echo $harcamaId; ?>"
									} }) 
								.done(function(data) { 
								
						if(data.indexOf("success")>-1){
							alert("Harcama Güncellendi."); 
							location.reload();}
							else{
								alert("Hata Oluştu, Harcama Güncellenemedi "+data);
							}

						})
					.fail(function() { alert("Hata Oluştu"+data); });


							}

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

             $('#SK').click(function(){
			    $('#SK').attr("checked",true);
				$('#KP').attr("checked",false);
				$('#KPevent').attr("checked",false);
			  });
			  $('#KP').click(function(){
			    $('#KP').attr("checked",true);
				$('#SK').attr("checked",false);
				$('#KPevent').attr("checked",false);
			  });	
			  $('#KPevent').click(function(){
			    $('#KPevent').attr("checked",true);
				$('#SK').attr("checked",false);
				$('#KP').attr("checked",false);
			  });


               $('#is').click(function(){
			    $('#is').attr("checked",true);
				$('#harici').attr("checked",false);
				
			  });

			$('#harici').click(function(){
			    $('#is').attr("checked",false);
				$('#harici').attr("checked",true);
				
			  });			  


</script>
</body>
</html>