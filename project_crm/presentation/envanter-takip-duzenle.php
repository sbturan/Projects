


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

   $etid=$_REQUEST['etid'];

	$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
	if (!$conn) {
		die("Connection failed: " . mysqli_connect_error());
	}

	$conn ->set_charset("utf8");
	
	 $sql="select * from ".DB_SCHEMA_NAME.".envanter_takip e,".DB_SCHEMA_NAME.".calisan c where c.personel_id=e.calisan_id and e.id='".$etid."'";
	 
		$result = $conn->query($sql);
                    
                   
						if ($result->num_rows > 0) {
                          
							$row = $result->fetch_assoc();
          
								
							
						}
	?>

	<script>

		$(function() {
			$.datepicker.setDefaults( $.datepicker.regional[ "tr" ] );
			$( "#alis_tarihi" ).datepicker({
				changeMonth: true, 
				changeYear: true, 
				yearRange: '1930:2020'});
		});
		
		$(function() {
			$.datepicker.setDefaults( $.datepicker.regional[ "tr" ] );
			$( "#teslim_tarihi" ).datepicker({
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
					<label for="alan-kisi" class="form-label">ALAN KİŞİ</label>
				</td>
				<td>
					<select id="alan-kisi" disabled="true">
						
						<?php 
						$sqlb = "SELECT * FROM ".DB_SCHEMA_NAME.".calisan order by adsoyad ";

						$resultb = $conn->query($sqlb);
                         

						if ($resultb->num_rows > 0) {

							while($row2 = $resultb->fetch_assoc()) {
                                  if(strcmp($row['adsoyad'],$row2['adsoyad'])==0){
								  echo '<option selected value='.$row2['personel_id'].'>'.$row2['adsoyad'].'</option>';
								  }
								  else
								  {
								  echo '<option value='.$row2['personel_id'].'>'.$row2['adsoyad'].'</option>';
								  }
								
							}
						}
						?>

					</select>
				</td>
			</tr>
				
			<tr>
				<td>
					<label >ALIŞ TARİHİ</label>
				</td>

				<td> 
					<p><input id="alis_tarihi"  disabled="true" value="<?=$row['alis_tarihi']?>"></p> 
				</td>
			</tr>
              <tr>
				<td>
					<label >TESLİM TARİHİ</label>
				</td>

				<td> 
					<p><input id="teslim_tarihi"  disabled="true" value="<?=$row['teslim_tarihi']?>"></p> 
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
					   
						var validated=validateInputs($(this));
						if(validated){
							$.ajax({
								url: '/dao/envanter-takip-guncelle.php',
								data: { 
									calisan_id :$('#alan-kisi option:selected').val(),
									alis_tarihi : $('#alis_tarihi').val(),
									teslim_tarihi : $('#teslim_tarihi').val(),
									etid : "<?php echo $etid; ?>"

								} })
							.done(function(data) { 
							    
								alert("Envanter Takibi Güncellendi");
								window.location="envanter-liste.php";

							})
							.fail(function() { alert("Hata Oluştu"+data); });


						}

					});
					



				</script>

			</body>
			</html>
