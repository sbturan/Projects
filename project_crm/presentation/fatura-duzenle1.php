


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
	
	$sql="select f.*,IFNULL(f.fatura_tutar,0) - IFNULL(sum(o.tutar),0) kala from ".DB_SCHEMA_NAME.".faturalar f LEFT JOIN  ".DB_SCHEMA_NAME.".odemeler o on o.fatura_no = f.fatura_no where f.proje_id = '".$_REQUEST['pid']."' and f.fatura_no='".$_REQUEST['fid']."'";
	$result = $conn->query($sql);

				if ($result->num_rows > 0) {

				$row = $result->fetch_assoc(); 
					



					
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
		$(function() {
			$.datepicker.setDefaults( $.datepicker.regional[ "tr" ] );
			$( "#odeme_tarihi" ).datepicker({
				changeMonth: true, 
				changeYear: true, 
				yearRange: '1930:2020'});
		});
		
		$(document).ready(function() {
			$("#odeme_tutari").keydown(function (e) {
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
	<table id="proje-table">
		<tr>
			<td>
				<label >FATURA TARİHİ</label>
			</td>

			<td> 
				<p><input  id="datepicker1"  name="ftarihi" disabled="true" value="<?=$row['fatura_tarihi']?>"></p> 
			</td>
		</tr>
		<tr>
			<td>
				<label >FATURA TUTARI</label>
			</td>

			<td> 
				<input class="tutar tutarInput" type="text" id="tutar" name="tutar" disabled="true" value="<?=$row['fatura_tutar']?>">
			</td>
		</tr>
		<tr>
			<td>
				<label >FATURA NO</label>
			</td>

			<td> 
				<input class="faturano" type="text" id="faturano" name="faturano" disabled="true" value="<?=$row['fatura_no']?>">   
				<td> 
				</td>
			</tr>
			<tr>
				<td>
					<label >DÜZENLEME TARİHİ</label>
				</td>

				<td> 
					<p><input id="datepicker2"  name="dtarihi" disabled="true" value="<?=$row['duzenlenme_tarihi']?>"></p> 
				</td>
			</tr>
			<tr>
				<td>
					<label >KDV TUTARI</label>
				</td>

				<td> 
					<input class="kdvtutar tutarInput" type="text" id="kdvtutar" name="kdvtutar" disabled="true" value="<?=$row['kdvtutar']?>">   
					
				</td>
			</tr>
		    <tr>
				<td>
					<label >ÖDEME TARİHİ</label>
				</td>

				<td> 
					<p><input id="datepicker3"  name="otarihi" disabled="true" value="<?=$row['odenme_tarihi']?>"></p> 
				</td>
			
		</table>
		<span style="margin-left: 53%;  color: red; display:none;" >* Tüm Alanları Doldurunuz</span>
		<div class="bottom-right-button">
					<button id="firma-duzenle" class="edit-button" >DUZENLE</button>
					<button id="firma-kaydet" class="save-button" disabled="true">KAYDET</button>
					<button id="iptal" class="cancel-button" disabled="true">IPTAL</button>
		</div>

		<div id="eHtml" ></div>
		</br></br></br>
		
		</br></br>
		
		
		
		
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
		
		var faturaNo="<?=$_REQUEST['fid']?>";
		var pid = "<?=$_REQUEST['pid']?>";
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
					$('.save-button').click(function(){
						
						var validated=true;
						
						if(validated){
						
						    
							
							$.ajax({
								url: '/dao/fatura-guncelle1.php',
								data: { 
									faturatarihi : $('#datepicker1').val(),
									fatura_no : faturaNo,
									pid : pid,
									fid : $('#faturano').val(),
									faturatutar:$('#tutar').val().replace(".",""),
									odemetarih : $('#datepicker3').val(),
									duzenlemetarihi : $('#datepicker2').val(),
									kdv_tutar : $('#kdvtutar').val().replace(".","")
								} })
							.done(function(data) { 
							
								alert("Fatura Güncelleme Başarı Oldu");
								window.location="fatura-duzenle1.php?fid="+$('#faturano').val()+"&pid="+pid;

							})
							.fail(function() { alert("Hata Oluştu"+data); });


						}

					});
					

				$('.edit-button').click(function(){
                     
					enableInputs("proje-table");

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
				$(function(){
				  
				    $('.tutar').each(function(){
					if($(this).text()!="")
					 $(this).text(formatCurrency($(this).text()));
					 
					 
					
					});
					
					 $('.tutarInput').each(function(){
					if($(this).val()!="")
					 $(this).val(formatCurrency($(this).val()));
					 
					 
					
					});
				     
				  });
				  
				  function formatCurrency(total) {
						var neg = false;
						if(total < 0) {
							neg = true;
							total = Math.abs(total);
						}
						return total.toString().replace(/(\d)(?=(\d{3})+$)/g, '$1'+".");
				}
				function formatCurrency(total) {
						var neg = false;
						if(total < 0) {
							neg = true;
							total = Math.abs(total);
						}
						return total.toString().replace(/(\d)(?=(\d{3})+$)/g, '$1'+".");
				}
				</script>

			</body>
			</html>
