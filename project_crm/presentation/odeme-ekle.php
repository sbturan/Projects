


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
		FROM ".DB_SCHEMA_NAME.".firmalar;";

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
	<button id="filtreTemizle" style="margin-left:5%">Filtreyi Temizle</button>

</div>
<div>
	<table>
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
					<label >FATURA TARİHİ</label>
				</td>

				<td> 
					<p><input id="datepicker1"  name="ftarihi" disabled></p> 
				</td>
			</tr>
			<tr>
				<td>
					<label >FATURA TUTARI</label>
				</td>

				<td> 
					<input class="tutar" type="text" id="tutar" name="tutar" disabled>
				</td>
			</tr>
			<tr>
				<td>
					<label >ÖDEME TUTARI</label>
				</td>

				<td> 
					<input class="otutar" type="text" id="otutar" name="faturano">   
					<td> 
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
						<label >ÖDEME TİPİ</label>
					</td>
					<td> 
						<select id="odemetip" name="odemetip" >
							<option value="" disabled selected></option>
							<?php 
							$sqlb = "SELECT * FROM ".DB_SCHEMA_NAME.".odeme_tipler";

							$resultb = $conn->query($sqlb);


							if ($resultb->num_rows > 0) {

								while($row = $resultb->fetch_assoc()) {

									echo '<option value='.$row['id'].'>'.$row['odme_tipi'].'</option>';
								}
							}
							?>
						</select>
						


					</td>
				</tr>

			</table>
			<span style="margin-left: 53%;  color: red; display:none;" >* Tüm Alanları Doldurunuz</span>
			<button id="odeme-kaydet" class="save-button" style="margin-left: 34%;" >KAYDET</button>
		</div>
		<script type="text/javascript">
		
		$('#projeler').on('change',function(){
			projeId= this.value;
			
			$('#butceler tr').show();
			$('.butceId').each(function(){

				var p_id=$(this).parent().children(' .projeId').text();

				if(projeId==p_id){
					$(this).parent().show();
				} else {
					$(this).parent().hide();
				}



			});
			$('#total').show();
			addEmptyLine();
			calTotal();



		});
		var projeId="0";
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
					$('#projeler option').hide();
						$('#projeler .'+firmaId).each(function(){

							$(this).show();



						});

						



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
						$('#odeme-kaydet').click(function(){
							if(projeId=="0"){
								alert("Butçenin ekleneceği projeyi seçin");
								return false;

							}
							var validated=validateInputs($(this));
							if(validated){
								$.ajax({
									url: '/dao/odeme-ekleme.php',
									data: { 
										otutar : $('#otutar').val(),
										faturano : $('#faturano').val(),
										otarihi:$('#datepicker2').val(),
										odemetip: $('#odemetip option:selected').text()
										
										
									} })
								.done(function(data) { 
									alert("Ödeme Başarıyla Eklendi");
									window.location="odeme-ekle.php";

								})
								.fail(function() { alert("Hata Oluştu"+data); });


							}

						});
					/*$('#faturano').blur(function(){
                         var fatura = this.value;
					// kanka buraya faturano girdiğinde  toplam fatura miktarı ve fatura tarihi gelecek dolacak yani ekran yapamadım

						

						

				});*/

$('#filtreTemizle').click(function(){
	$('tr:not(:first)').hide();      
	$('select').val('');
	
}); 
</script>

</body>
</html>
