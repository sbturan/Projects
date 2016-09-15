


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

   $seri_no=$_REQUEST['seri_no'];

	$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
	if (!$conn) {
		die("Connection failed: " . mysqli_connect_error());
	}

	$conn ->set_charset("utf8");
	
	 $sql="select * from ".DB_SCHEMA_NAME.".envanter e where e.seri_no='".$seri_no."'";
	 
		$result = $conn->query($sql);
                         
                   
						if ($result->num_rows > 0) {
                          
							$row = $result->fetch_assoc();
          
								
							
						}
	?>

	<script>

		$(function() {
			$.datepicker.setDefaults( $.datepicker.regional[ "tr" ] );
			$( "#giris_tarihi" ).datepicker({
				changeMonth: true, 
				changeYear: true, 
				yearRange: '1930:2020'});
		});
		
		$(document).ready(function() {
			$("#adet").keydown(function (e) {
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

	
<div id="envanterler" style="margin-top:50px;">
	<table id="envanterTable">
		
		<tr>
			<td>
				<label >CİNSİ</label>
			</td>

			<td> 
				<input  type="text" id="cinsi" disabled="true" value="<?=$row['cinsi']?>">
			</td>
		</tr>
		<tr>
			<td>
				<label >ADI</label>
			</td>

			<td> 
				<input  type="text" id="adi" disabled="true" value="<?=$row['adi']?>">   
				<td> 
				</td>
			</tr>
			<tr>
				<td>
					<label >MM</label>
				</td>

				<td> 
					<p><input id="mm" type="text" disabled="true" value="<?=$row['MM']?>"></p> 
				</td>
			</tr>
			<tr>
				<td>
					<label >adet</label>
				</td>

				<td> 
					<input  type="text" id="adet" disabled="true" value="<?=$row['adet']?>">   
					
				</td>
			</tr>
			<tr>
				<td>
					<label >GİRİŞ TARİHİ</label>
				</td>

				<td> 
					<p><input id="giris_tarihi"  disabled="true" value="<?=$row['giris_tarihi']?>"></p> 
				</td>
			</tr>
		
		</table>
		<span id="errorspn" style="  position: absolute; top: 400px; left: 250px; color: red; display:none;" >* Tüm Alanları Doldurunuz</span>
		<div style="  padding-left: 500px;" class="bottom-right-button">
					<button id="envanter-duzenle" class="edit-button" >DUZENLE</button>
					<button id="envanter-kaydet" class="save-button" disabled="true">KAYDET</button>
					<button id="iptal" class="cancel-button" disabled="true">IPTAL</button>
				</div>
	</div>
	<script type="text/javascript">
	               
				   $('#envanter-duzenle').click(function(){

					enableInputs("envanterTable");

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
					$('#envanter-kaydet').click(function(){
					    var seri_no="<?=$seri_no?>"
						var validated=validateInputs($(this));
						if(validated){
							$.ajax({
								url: '/dao/envanter-guncelle.php',
								data: { 
									seri_no : seri_no,
									cinsi : $('#cinsi').val(),
									adi:$('#adi').val(),
									MM: $('#mm').val(),
									adet: $('#adet').val(),
									giris_tarihi:$('#giris_tarihi').val(),
									dtarihi:$('#datepicker2').val()
									

								} })
							.done(function(data) { 
							    
								alert("Envanter Güncellendi");
								window.location="envanter-liste.php";

							})
							.fail(function() { alert("Hata Oluştu"+data); });


						}

					});
					



				</script>

			</body>
			</html>
