


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
			$("#tutar").keydown(function (e) {
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
		$(document).ready(function() {
			$("#kdvtutar").keydown(function (e) {
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

	
<div style="margin-top:50px;">
	<table>
		<tr>
			<td>
				<label >FATURA TARİHİ</label>
			</td>

			<td> 
				<p><input id="datepicker1"  name="ftarihi"></p> 
			</td>
		</tr>
		<tr>
			<td>
				<label >FATURA TUTARI</label>
			</td>

			<td> 
				<input class="tutar" type="text" id="tutar" name="tutar">
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
					<label >DÜZENLEME TARİHİ</label>
				</td>

				<td> 
					<p><input id="datepicker2"  name="dtarihi"></p> 
				</td>
			</tr>
			<tr>
				<td>
					<label >KDV TUTARI</label>
				</td>

				<td> 
					<input class="kdvtutar" type="text" id="kdvtutar" name="kdvtutar">   
					
				</td>
			</tr>
			<tr>
				<td>
					<label >ÖDEME TARİHİ</label>
				</td>

				<td> 
					<p><input id="datepicker3"  name="otarihi"></p> 
				</td>
			</tr>
		</table>
		<span style="margin-left: 53%;  color: red; display:none;" >* Tüm Alanları Doldurunuz</span>
		<button id="fatura-kaydet" class="save-button" style="margin-left: 34%;" >KAYDET</button>
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
			



		});
		var projeId="<?=$_REQUEST['pid']?>";
		var firmaIdd="<?=$_REQUEST['fid']?>";
		
				var emptyAdded="0";//
			

				 
				$('#firmalar').on('change',function(){

					
					$('#projeler').prop("disabled",false);
					projeId="0";
					$('#projeler').val('');

					
					firmaId=this.value;
					
						$('#projeler option').hide();
						$('#projeler .'+firmaId).each(function(){

							$(this).show();



						});

					/*$('.butceId').each(function(){

						var f_id=$(this).parent().children('.firmaId').text();

						if(firmaId==f_id){
							$(this).parent().show();
						} else {
							$(this).parent().hide();
						}



					}); */
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
					$('#fatura-kaydet').click(function(){
						if(projeId=="0"){
							alert("Butçenin ekleneceği projeyi seçin");
							return false;

						}
						var validated=validateInputs($(this));
						if(validated){
							$.ajax({
								url: '/dao/fatura-ekleme.php',
								data: { 
									tutar : $('#tutar').val(),
									fatura_no : $('#faturano').val(),
									kdvtutar:$('#kdvtutar').val(),
									proje_id: projeId,
									firma_id: firmaIdd,
									ftarihi:$('#datepicker1').val(),
									dtarihi:$('#datepicker2').val(),
									otarihi:$('#datepicker3').val()

								} })
							.done(function(data) { 
							
								alert("Fatura Başarıyla Eklendi");
								window.location="fatura-liste.php?fid="+firmaIdd+"&pid="+projeId;

							})
							.fail(function() { alert("Hata Oluştu"+data); });


						}

					});
					$('#filtreTemizle').click(function(){
						$('tr').val('');     
						$('select').val('');

					}); 



				</script>

			</body>
			</html>
