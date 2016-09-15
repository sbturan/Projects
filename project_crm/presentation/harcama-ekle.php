


<html>
<meta http-equiv="Content-Type" content="text/HTML; charset=utf-8" />
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
		$(".tutar").keydown(function (e) {
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
<div style="  padding-top: 20px;  margin-left: 20%;   margin-bottom: 20px;">       
	<label>FİRMA</label>
	<select id='firmalar' style ="margin-left: 12px; margin-right: 12px; " >
		<option value="" disabled selected></option>
		<?php
		require_once("config/config.php");

		$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
		if (!$conn) {
			die("Connection failed: " . mysqli_connect_error());
		}

		$conn ->set_charset("utf8");
		$sqlKategori = "SELECT *
		FROM ".DB_SCHEMA_NAME.".firmalar order by firma_unvani;";

		$resultKategori = $conn->query($sqlKategori);

		if ($resultKategori->num_rows > 0) {

			while($row = $resultKategori->fetch_assoc()) {

				echo "<option  value=". $row['firma_id'] ."> ".$row['firma_unvani']."</option>";

			} 

		}

		?>
	</select>
	<label>PROJE </label>



	<select id='projeler'  style ="margin-left: 16px; " >
			<option id="firmaSecin" value='' disabled selected >Firma Seçin</option>
			<?php
			

			
			$sqlKategori = "SELECT *
			FROM ".DB_SCHEMA_NAME.".projeler p;";

			$resultKategori = $conn->query($sqlKategori);

			if ($resultKategori->num_rows > 0) {

				while($row = $resultKategori->fetch_assoc()) {

					echo "<option class=".$row['firma_id']." value=". $row['proje_id'] ."> ".$row['is_adi']."</option>";

				} 

			}

			?>
		</select>
	

</div>
<div  id="datagrid">
	<table>
	     <tr>
				<td>
					<label ></label>
				</td>

				<td> 
					<input style="width:10%!important" type="radio" id="faturali"  value="sahis" checked="checked">FATURALI
					<input style="width:10%!important" type="radio" id="faturasiz"  value="tuzel">FATURASIZ
				</td>
			</tr>
		<tr>
				<td>
					<label >ŞİRKET TİPİ</label>
				</td>

				<td> 
					<input style="width:10%!important" type="radio" id="SK"  value="SK" checked="checked">SK
					<input style="width:10%!important" type="radio" id="KP"  value="KP">KP
					<input style="width:10%!important" type="radio" id="KPevent"  value="KPevent">KPevent
				</td>
			</tr>
        <tr>
				<td>
					<label>İŞ/HARİCİ</label>
				</td>

				<td> 
					<input style="width:10%!important" type="radio" id="is"  value="SK" checked="checked">İŞ
					<input style="width:10%!important" type="radio" id="harici"  value="KP">HARİCİ
					
				</td>
			</tr>			
		<tr>
			<td>
				<label >FATURA TARİHİ</label>
			</td>

			<td> 
				<p><input id="datepicker1"  name="ftarihi" ></p> 
			</td>
		</tr>

		<tr>
			<td>
				<label >FATURA NO</label>
			</td>

			<td> 
				<input class="faturano" type="text" id="faturano" name="faturano">   
				<td> 
				</td>
			</tr>
			<tr>
				<td>
					<label >HARCAMA TİPİ</label>
				</td>
				<td> 
					<select id="harcamatip" name="harcamatip" >
						<option value="" disabled selected></option>
						<?php 
						$sqlb = "SELECT * FROM ".DB_SCHEMA_NAME.".harcama_tipler where aktif = 1";

						$resultb = $conn->query($sqlb);


						if ($resultb->num_rows > 0) {

							while($row = $resultb->fetch_assoc()) {

								echo '<option value='.$row['id'].'>'.$row['harcama_tip'].'</option>';
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
					<select id="harcamayap" name="harcamayap" >
						<option value="" disabled selected></option>
						<?php 
						$sqlb = "SELECT * FROM ".DB_SCHEMA_NAME.".calisan";

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
					<label >HARCAMA TUTARI</label>
				</td>

				<td> 
					<input class="tutar" type="text" id="tutar" name="tutar" >
				</td>
			</tr>
			<tr>
				<td>
					<label> KDV</label>
				</td>

				<td> 
					<input class="tutar" type="text" id="kdv" name="kdv" >
				</td>
			</tr>
			<tr>
				<td>
					<label >HARCAMA DURUMU</label>
				</td>
				<td>
				
				     <select id="cmbMake" name="Make" >
						<option value="" disabled selected></option>
						<?php 
						$sqlb = "SELECT * FROM ".DB_SCHEMA_NAME.".harcama_durum where aktif = 1";

						$resultb = $conn->query($sqlb);


						if ($resultb->num_rows > 0) {

							while($row = $resultb->fetch_assoc()) {

								echo '<option value='.$row['id'].'>'.$row['harcama_adi'].'</option>';
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
					<p><input id="datepicker2"  name="otarihi"></p> 
				</td>
			</tr>
			<tr>
				<td>
					<label >AÇIKLAMA</label>
				</td>

				<td> 
					<textarea id="aciklama" ></textarea> 
				</td>
			</tr>
			

		</table>
		<span id="errorspn" style="margin-left: 53%;  color: red; display:none;" >* Tüm Alanları Doldurunuz</span>
		<button id="odeme-kaydet" class="save-button" style="margin-left: 34%;" >KAYDET</button>
	</div>
	<script type="text/javascript">
	var projeId="0";
           
			$('#projeler').on('change',function(){
					projeId= this.value;
					
			//		$('#butceler tr').show();
			//		$('.faturano').each(function(){

					//	var projeId=$(this).parent().children(' .projeId').text();

				/*		if(projeId==p_id){
							$(this).parent().show();
						} else {
							$(this).parent().hide();
						}



					});*/
				



				});
				
				var firmaId="0";
				var emptyAdded="0";//
				var selectedValue="<?php  if(isset($_GET['selected'])){ echo $_GET['selected'];} else { echo'0'; } ?>";
				if(selectedValue!="0"){
					$('#projeler').val(selectedValue).change();
					$('#projeler').trigger('change');
					addEmptyLine();


				}

				$(window).load(function(){

					$('#projeler').prop("disabled",true); 

				});

				$('#firmalar').on('change',function(){


					$('#projeler').prop("disabled",false);
					projeId="0";
					$('#projeler').val('');


					firmaId=this.value;
					 
							
					$('.faturano').each(function(){

						var f_id=$(this).parent().children('.firmaId').text();

					/*	if(firmaId==f_id){
							$(this).parent().show();
						} else {
							$(this).parent().hide();
						}*/

						$('#projeler option').hide();
						$('#projeler .'+firmaId).each(function(){

							$(this).show();



						});



					}); 

					

				});    			 

					function validateInputs(button){
						var divID=button.parent().attr("id");
						var spanSelector="#errorspn";
						var inputSelector="#"+divID+" input:not(.notRequired)";
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


					$('#odeme-kaydet').click(function(){
                          
							if(projeId=="0"){
								alert("Harcamanın ekleneceği projeyi seçin");
								return false;

							}
							
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
									url: '/dao/harcama-ekleme.php',
									data: { 
									    firma_tur : firma_tur,
										tutar : $('#tutar').val().replace(",","."),
										faturano : $('#faturano').val(),
										otarihi:$('#datepicker2').val(),
										ftarihi:$('#datepicker1').val(),
										harcamatip: $('#harcamatip option:selected').val(),
										harcamayap: $('#harcamayap option:selected').val(),
										proje_id: projeId,
										firma_id: firmaId,
										aciklama:$('#aciklama').val(), 
										durum:$('#cmbMake').val(),
										is_harici:is_harici,
										kdv : $('#kdv').val().replace(",",".")
										
										
									} })
								.done(function(data) { 
									alert("Harcama Başarıyla Eklendi");
									window.location="harcama-liste.php";

								})
								.fail(function() { alert("Hata Oluştu"+data); });


							}

						});

			

				

				$('#filtreTemizle').click(function(){
					   
					$('select').val('');
					$('input').val('');
				}); 

				
				


				
              $('#faturali').click(function(){
			    $('#faturali').attr("checked",true);
				$('#faturasiz').attr("checked",false);
				$('#datepicker1').removeClass('notRequired');
				$('#faturano').removeClass('notRequired');
			  
			  });
			  
			  $('#faturasiz').click(function(){
			    $('#faturasiz').attr("checked",true);
				$('#faturali').attr("checked",false);
				$('#datepicker1').addClass('notRequired');
				$('#faturano').addClass('notRequired');
			  
			  });
			  
			  $('#is').click(function(){
			    $('#is').attr("checked",true);
				$('#harici').attr("checked",false);
			  });
			  
			  $('#harici').click(function(){
			    $('#is').attr("checked",false);
				$('#harici').attr("checked",true);
			  });
			  
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
				

			

			</script>
					</body>
					</html>
