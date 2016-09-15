


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
	
	$sql="select f.*,FORMAT((IFNULL(f.fatura_tutar,0)- IFNULL(fa.tutar,0)),1,'de_DE') kala
from  ".DB_SCHEMA_NAME.".faturalar f left join 
(select fa.fatura_no,fa.proje_id,IFNULL(sum(o.tutar),0) tutar from ".DB_SCHEMA_NAME.".faturalar fa LEFT JOIN ".DB_SCHEMA_NAME.".odemeler o on o.fatura_no = fa.fatura_no and o.proje_id = fa.proje_id where o.fatura_no = '".$_REQUEST['fid']."'and o.proje_id = '".$_REQUEST['pid']."'

)fa on fa.fatura_no = f.fatura_no and fa.proje_id = f.proje_id


where f.proje_id='".$_REQUEST['pid']."' and f.fatura_no='".$_REQUEST['fid']."'";

$result = $conn->query($sql);

				if ($result->num_rows > 0) {

				$row = $result->fetch_assoc(); 
					



					
				} 
	?>

	<script>

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
	<table>
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
				<label >KALAN TUTAR</label>
			</td>

			<td> 
				<input  type="text" id="ktutar" name="tutar" disabled="true" value="<?=$row['kala']?>">
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
					<label >ÖDEME TUTARI</label>
				</td>

				<td> 
					<p><input id="odeme_tutari"   ></p> 
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
							$sqlb = "SELECT * FROM ".DB_SCHEMA_NAME.".odeme_tipler where aktif = 1";

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
			<tr>
				<td>
					<label >ÖDEME TARİHİ</label>
				</td>

				<td> 
					<p><input id="odeme_tarihi"   ></p> 
				</td>
			</tr>
		</table>
		<span style="margin-left: 53%;  color: red; display:none;" >* Tüm Alanları Doldurunuz</span>
		<button id="odeme-kaydet" class="save-button" style="margin-left: 34%;" >Ödemeyi Kaydet</button>
		
		<div id="eHtml" ></div>
		</br></br></br>
		<button onclick="exportExcel()" style="margin-left:5%">İNDİR</button>
		</br></br>
		<div class="datagrid" id="datagrid1">

			<table id="firmaTable">
				<tr>
					<th>
						İŞİN ADI
					</th>
					<th>
						FİRMA UNVANI
					</th>
					
					<th>
						FATURA TARİHİ

					</th>
					<th>
						FATURA NO
					</th>
					<th>
						FATURA TUTARI 
					</th>
					<th>
						ÖDENEN TUTAR
					</th>
					<th>
						ÖDEME TARİHİ
					</th>
					<th>
						KALAN
					</th>
					

				</tr>

				<?php 


				$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
				if (!$conn) {
					die("Connection failed: " . mysqli_connect_error());
				}



				$conn ->set_charset("utf8");
				$sql = "SELECT f.firma_unvani,p.is_adi,fa.fatura_no,fa.fatura_tarihi,IFNULL(fa.fatura_tutar,0) fatura_tutar,IFNULL(o.tutar,0) tutar,o.odeme_tarihi
								FROM ".DB_SCHEMA_NAME.".faturalar fa, ".DB_SCHEMA_NAME.".projeler p, ".DB_SCHEMA_NAME.".firmalar f,".DB_SCHEMA_NAME.".odemeler o

								
								WHERE f.firma_id = fa.firma_id
								AND fa.proje_id = p.proje_id
								AND fa.fatura_no = '".$_REQUEST['fid']."' 
								AND fa.proje_id='".$_REQUEST['pid']."'
								AND fa.proje_id = o.proje_id
								AND fa.fatura_no = o.fatura_no;";
                       
				$result1 = $conn->query($sql);
                

				if ($result1->num_rows > 0) {
                    
					$i=0;
					while($row = $result1->fetch_assoc()) {
					     if($i==0){
						  $kalan_tutar=intval($row['fatura_tutar']);
						  $i=1;
						 }
					    $kalan_tutar=$kalan_tutar-intval($row['tutar']);
						
						echo "<tr>";
						echo "<td>".$row['is_adi']."</td>";
						echo "<td>".$row['firma_unvani']."</td>";
						echo "<td>".$row['fatura_tarihi']."</td>";
						echo "<td>".$row['fatura_no']."</td>";
						echo "<td class='tutar' >".$row['fatura_tutar']."</td>";
						echo "<td class='tutar' >".$row['tutar']."</td>";
						echo "<td>".$row['odeme_tarihi']."</td>";
						echo "<td class='tutar' >".$kalan_tutar."</td>";
						echo "</tr>";  




					}
				} else {
					echo "0 results";
				}
				$conn->close();
				?>
			</table>
		</div>
		
		
		
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
		var pid="<?=$_REQUEST['pid']?>";
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
					$('#odeme-kaydet').click(function(){
						
						var validated=true;
						
						if(validated){
						
						    var kalan_tutar=$('#ktutar').val();
							kalan_tutar=kalan_tutar.replace(".","");
							$.ajax({
								url: '/dao/odemeler-ekleme.php',
								data: { 
									odeme_tutari : $('#odeme_tutari').val(),
									fatura_no : faturaNo,
									pid : pid,
									otarihi:$('#odeme_tarihi').val(),
									kalan_tutar : kalan_tutar,
									odeme_tipi: $('#odemetip option:selected').text()
								} })
							.done(function(data) { 
							
								alert("Odeme Başarıyla Eklendi");
								location.reload();

							})
							.fail(function() { alert("Hata Oluştu"+data); });


						}

					});
					$('#filtreTemizle').click(function(){
						$('tr').val('');     
						$('select').val('');

					}); 

                  function exportExcel() {
					$('.icon-div').remove();
					var tableExport = document.getElementById('firmaTable');
					var html = tableExport.outerHTML;

					while (html.indexOf('ç') != -1) html = html.replace('ç', '&ccedil;');
					while (html.indexOf('ğ') != -1) html = html.replace('ğ', '&#287;');
					while (html.indexOf('ı') != -1) html = html.replace('ı', '&#305;');
					while (html.indexOf('ö') != -1) html = html.replace('ö', '&ouml;');
					while (html.indexOf('ş') != -1) html = html.replace('ş', '&#351;');
					while (html.indexOf('ü') != -1) html = html.replace('ü', '&uuml;');

					while (html.indexOf('Ç') != -1) html = html.replace('Ç', '&Ccedil;');
					while (html.indexOf('Ğ') != -1) html = html.replace('Ğ', '&#286;');
					while (html.indexOf('İ') != -1) html = html.replace('İ', '&#304;');
					while (html.indexOf('Ö') != -1) html = html.replace('Ö', '&Ouml;');
					while (html.indexOf('Ş') != -1) html = html.replace('Ş', '&#350;');
					while (html.indexOf('Ü') != -1) html = html.replace('Ü', '&Uuml;');

					window.open('data:application/vnd.ms-excel,' + encodeURIComponent(html));
					location.reload();
				}

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
				        var negative=false;
						if(parseInt(total)<0){
						  negative=true;
						}
						var neg = false;
						if(total < 0) {
							neg = true;
							total = Math.abs(total);
						}
						
						var result=total.toString().replace(/(\d)(?=(\d{3})+$)/g, '$1'+".");
						if(negative){
						result="-"+result;
						}
						return result;//total.toString().replace(/(\d)(?=(\d{3})+$)/g, '$1'+".");
				}
				</script>

			</body>
			</html>
