<!DOCTYPE html>
<html>
<meta http-equiv="Content-Type" content="text/HTML; charset=utf-8" />

<title>RAPOR EKRANI</title>
<link rel="stylesheet" type="text/css" href="/style/style.css">
<script src="/js/jquery-2.1.4.min.js"></script>
<?php 
include("topMenu.php");
?>

<body>

	<div id="faturalar" >
		<label>FATURALAR:</label> <br><br><br>
		 <a href="#" id='fatura-ekle-link'>Yeni Fatura Girişi İçin Tıklayınız</a> 
		<div style="  margin-left: 30%;">

			
			
		</div> <br>
		<div class="datagrid" >

			<table id="faturaTable">
				<tr>
					<th>
					</th>
					<th style="display:none" class='icon-div'>
					</th>
					<th>
						FATURA NO
					</th>
					<th>
						PROJE
					</th>
					<th>
						FİRMA
					</th>
					<th>
						FATURA TUTARI
					</th>
					<th>
						KALAN TUTAR
					</th>
					<th>
						FATURA TARİHİ 
					</th>
					<th>
						DÜZENLEME TARİHİ
					</th>
					<th>
						ÖDEME TARİHİ
					</th>
					<th>
						KDV TUTARI
					</th>
					

				</tr>

				<?php 
              require_once("config/config.php");
			$fid=$_REQUEST['fid'];


	                $conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
	            if (!$conn) {
                   	die("Connection failed: " . mysqli_connect_error());
	               }

	                    $conn ->set_charset("utf8");

				$sql = "SELECT fat.*,p.is_adi,f.firma_unvani,f.firma_id from ".DB_SCHEMA_NAME.".firmalar f,( SELECT fa.kdvtutar,fa.duzenlenme_tarihi,fa.odenme_tarihi,fa.fatura_no, fa.fatura_tutar, fa.fatura_tarihi, fa.firma_id, o.tutar odenen_tutar, fa.fatura_tutar - IFNULL( o.tutar,0) kalan_tutar,fa.proje_id from ".DB_SCHEMA_NAME.".faturalar fa
LEFT JOIN (

SELECT fatura_no, SUM( tutar ) tutar,proje_id
FROM ".DB_SCHEMA_NAME.".odemeler where proje_id = ".$_REQUEST['pid']."
GROUP BY fatura_no
)o ON o.fatura_no = fa.fatura_no and o.proje_id = fa.proje_id) fat,".DB_SCHEMA_NAME.".projeler p 
				where fat.proje_id=p.proje_id and fat.firma_id=f.firma_id and p.proje_id=".$_REQUEST['pid']." order by fatura_no";

				$result = $conn->query($sql);

				if ($result->num_rows > 0) {

					while($row = $result->fetch_assoc()) {
						echo "<tr>";
						echo "<td><div class='icon-div'><a class='view' href=''><img src='/img/view.png' title='görüntüle'></img></a><a class='delete' href=''><img src='/img/delete.png' title='sil'></a><a  class='butceler' href='#'> <img style='margin-right:10px;' src='/img/pricelist_icon.jpg' title='düzenle'></a></div></td>";
						
						echo "<td>".$row['fatura_no']."</td>";
						echo "<td>".$row['is_adi']."</td>";
						echo "<td class='kategori'>".$row['firma_unvani']."</td>";
						echo "<td class='tutar' >".$row['fatura_tutar']."</td>";
						echo "<td class='tutar' >".$row['kalan_tutar']."</td>";
						echo "<td>".$row['fatura_tarihi']."</td>";
						echo "<td>".$row['duzenlenme_tarihi']."</td>";
						echo "<td>".$row['odenme_tarihi']."</td>";
						echo "<td class='tutar' >".$row['kdvtutar']."</td>";
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
		$('select').on('change',function(){
			var kategori= this.value;
			$('.kategori').each(function(i,obj){

				if($(this).text()!=kategori){
					$(this).parent().hide();

				} else{
					$(this).parent().show();                    	
				} 

			});
            


		});

		$('#filtreTemizle').click(function(){

			$('tr').show();      
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

		$('.delete').click(function(){
			var par = $(this).parent().parent().parent();
			var id=par.children("td:nth-child(2)").html();

			if (confirm("Fatura Silinecek ")) {
				$.ajax({
					url: '/dao/fatura_Sil.php',
					data: { id: id } })
				.done(function(data) {
				
					if(data=="success"){
						alert("Fatura Silindi."); 
						par.remove();}
						else{
							alert("Hata Oluştu, Fatura Silinemedi:");
						}
					})
				.fail(function() { alert("Hata Oluştu, Fatura Silinemedi"); });
				

				
			}
			return false;

		});

		$('.view').click(function(){
            var pid="<?=$_REQUEST['pid']?>";
			var par = $(this).parent().parent().parent();
			var fid=par.children("td:nth-child(2)").html();
			var link="fatura-duzenle.php?fid="+fid+"&pid="+pid;
			$(this).removeAttr('href');
			window.location.href=link;			
           

		});
		$('.butceler').click(function(){
            var pid="<?=$_REQUEST['pid']?>"; 
			var par = $(this).parent().parent().parent();
			var fid=par.children("td:nth-child(2)").html();
			var link="fatura-duzenle1.php?fid="+fid+"&pid="+pid;
			$(this).removeAttr('href');
			window.location.href=link;			
           

		});
		
		$('#fatura-ekle-link').click(function(){
		  var fid="<?=$fid?>";
		 
		  var pid="<?=$_REQUEST['pid']?>";
		  window.location="fatura-ekle.php?fid="+fid+"&pid="+pid;
		});
		
		 $(function(){
				  
				    $('.tutar').each(function(){
					if($(this).text()!="")
					 $(this).text(formatCurrency($(this).text()));
					 
					 
					
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