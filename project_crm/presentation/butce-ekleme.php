


<html>
<meta http-equiv="Content-Type" content="text/HTML; charset=utf-8" />
<head>

	<link rel="stylesheet" type="text/css" href="/style/style.css">
	<script src="/js/jquery-2.1.4.min.js"></script>
	<title>Bütçeler</title>
	<?php 
	include("topMenu.php");
	?>
</head>
<body>

	<div style="  padding-top: 20px;  margin-left: 20%;   margin-bottom: 20px;">       
		<label>FİRMA</label>
		<select id='firmalar' style ="margin-left: 12px; margin-right: 12px; " >
			<option value='<?=$_REQUEST["firma"]?>' disabled selected><?=$_REQUEST["firma"]?></option>
			
		</select>
		<label>İŞİN ADI </label>



		<select id='projeler'  style ="margin-left: 16px; " >
			<option id="firmaSecin" value='<?=$_REQUEST["padi"]?>' disabled selected ><?=$_REQUEST["padi"]?></option>
		
		</select>
	
		<button onclick="exportExcel()" style="margin-left:5%">İNDİR</button>
	</div>
	<div class="datagrid">

		<table id="butceler">


			<tr id="firstRow">
				<th class='icon-div'>
				</th>
				<th style="display:none" class='icon-div'>
				</th>
				<th style="display:none" class='icon-div'>
				</th>
				<th style="display:none" class='icon-div'>
				</th>
				
				<th>
					BÜTÇE KALEMLERİ
				</th>
				<th>
					ADET/GÜN
				</th>
				<th>
					BİRİM FİYATI
				</th>
				<th>
					TEKLİF
				</th>
				<th>
					BİRİM FİYAT(MALİYET)
				</th>
				<th>
					MALİYET
				</th>


			</tr>


			<?php 
			require_once("config/config.php");

				$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
				if (!$conn) {
					die("Connection failed: " . mysqli_connect_error());
				}

				$conn ->set_charset("utf8");

            $projeId=$_REQUEST['pid'];
			 
			$sql = "SELECT b.*,p.*,per.adsoyad as  sahip, c.adsoyad  as sorumlu 
FROM ".DB_SCHEMA_NAME.".butceler b,".DB_SCHEMA_NAME.".projeler p, 

(select proj.proje_id,pera.adsoyad from ".DB_SCHEMA_NAME.".projeler proj left join ".DB_SCHEMA_NAME.".personel pera on pera.p_id=proj.sahip)per,
(select proje.proje_id,ca.adsoyad from ".DB_SCHEMA_NAME.".projeler proje left join ".DB_SCHEMA_NAME.".calisan ca on    ca.personel_id=proje.proje_sorumlusu)c


where b.proje_id=p.proje_id
  and p.proje_id = per.proje_id
  and p.proje_id = c.proje_id
  and b.proje_id=".$projeId;
               
              
			$result = $conn->query($sql);
               
			if ($result->num_rows > 0) {
                 $baslangic='';
				 $bitis='';
                 $sorumlu='';
                 $sahip='';				 
				while($row = $result->fetch_assoc()) {
					echo "<tr >";
					echo "<td class='icon-div'><div style='text-align:center'><button class='guncelle' onclick='butceguncelle(this)'>güncelle</button><button class='sil' onclick='butceSil(this)'>Sil</button></div></td>";
					echo "<td class='icon-div butceId' style='display:none'>".$row['id']."</td>";
					echo "<td class='icon-div projeId' style='display:none'>".$row['proje_id']."</td>";
					echo "<td class='icon-div firmaId' style='display:none'>".$row['firma_id']."</td>";
					echo "<td class='tdKalem' > <input class='kalem' style=\"width: 100%; border: none;\"  disabled value='".$row['kalem']."'></td>";
					echo "<td class='tdGun' >   <input class='numeric adet gun' style=\"width: 100%; border: none;\"  disabled value='".$row['adet_gun']."'></td>";
					echo "<td  class='tdBirimFiyat' ><input class='numeric birim birimFiyat'style=\"width: 100%; border: none;\"  disabled value='".$row['birim_fiyati']."'></td>";
					echo "<td class='dataTeklif numericTd'>".$row['teklif']."</td>";
					echo "<td class='tdBirimMaliyet'><input class='numeric birim-mal birimMaliyet' style=\"width: 100%; border: none;\"  disabled value='".$row['birim_maliyet']."'></td>";
					echo "<td class='dataMaliyet numericTd' >".$row['toplam_maliyet']."</td>"; 
					echo "</tr>";  
                    $baslangic=$row['baslangic_tarih'];
					$bitis=$row['bitis_tarihi'];
					$sorumlu=$row['sorumlu'];
					$sahip=$row['sahip'];
					
				



				}
			} 

			?>
		</table>
		
	</div>
	<div id="total"  style=" margin-left: 70%;   margin-top: 25px;">
		Toplam Teklif: <span class="numericTd" id="toplamTeklif" > </span> <br> <br>
		Toplam Maliyet: <span class="numericTd" id="toplamMaliyet" > </span> <br> <br>
		Kar: <span class="numericTd" id="kar" > </span>

		<div>
			<script type="text/javascript">
			<?php $requestProjeAdi= str_replace("'","`",$_REQUEST['padi']); ?>
			var projeId="<?=$_REQUEST['pid']?>";
				var firmaId="0";
				var firma='<?=$_REQUEST['firma']?>';
				var proje='<?=$requestProjeAdi?>';
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
				
				var emptyAdded="0";//
				var selectedValue="<?php  $_REQUEST['pid']; ?>";
				addEmptyLine();
				calTotal();
				/*if(selectedValue!="0"){
					$('#projeler').val(selectedValue).change();
					$('#projeler').trigger('change');
					


				}*/

				

				$('#firmalar').on('change',function(){


					$('#projeler').prop("disabled",false);
					projeId="0";
					$('#projeler').val('');


					firmaId=this.value;
					$('.butceId').each(function(){

						var f_id=$(this).parent().children('.firmaId').text();

						if(firmaId==f_id){
							$(this).parent().show();
						} else {
							$(this).parent().hide();
						}

						$('#projeler option').hide();
						$('#projeler .'+firmaId).each(function(){

							$(this).show();



						});



					}); 

					$('#total').show();
					addEmptyLine();
					calTotal();

				});    			 

				

				calTotal();



				function addEmptyLine(){



					if(emptyAdded=="0"){

						$('#butceler').append('<tr class="emptyLine"><td class="icon-div" style="text-align:center">'+
							'</td><td><input type="text " style="width:100%; border :none"/></td>'+
							'<td><input value="0"  class="numeric adet" type="text " style="width:100%; border :none"/></td>'+
							'<td><input value="0" class="numeric birim" type="text " style="width:100%; border :none"/></td>'+
							'<td><input value="0" class="numeric teklif" type="text " disabled="true" style="width:100%; border :none"/></td>'+
							'<td><input onblur="butcekaydet(this)" value="0" class="numeric birim-mal"  type="text " style="width:100%; border :none"/></td>'+
							'<td><input value="0" class="numeric maliyet" type="text " disabled="true" style="width:100%; border :none"/></td></tr>');
						emptyAdded="1";                    

					}

					

				}
				function butceguncelle(button){

					if($(button).text()=="güncelle"){
						


						$(button).parent().children('.sil').hide();
						$(button).text('kaydet');
						$(button).parent().parent().parent().children('.tdKalem').children('.kalem').prop('disabled',false);
                   
						$(button).parent().parent().parent().children('.tdGun').children('.gun').prop('disabled',false);
						$(button).parent().parent().parent().children('.tdBirimFiyat').children('.birimFiyat').prop('disabled',false);
						$(button).parent().parent().parent().children('.tdBirimMaliyet').children('.birimMaliyet').prop('disabled',false);
					}else{
   
     					var id=$(button).parent().parent().parent().children('.butceId').text();
     					var line=$(button).parent().parent().parent();
     					line.addClass('updateRow');

     					
						
						$.ajax({
							url: '/dao/butce-guncelle.php',
							data: { 
								kalem:$('.updateRow td:nth-child(5) input').val(),
								adet_gun:$('.updateRow td:nth-child(6) input').val(),
								birim_fiyati:$('.updateRow td:nth-child(7) input').val(),
								teklif:$('.updateRow td:nth-child(8) ').text(),
								birim_maliyet:$('.updateRow td:nth-child(9) input').val(),
								toplam_maliyet:$('.updateRow td:nth-child(10) ').text(),
								proje_id : projeId,
								id : id
							

							} })
						.done(function(data) { 
 							line.removeClass('updateRow');
							refreshPage();
							 

						})
						.fail(function() { alert("Hata Oluştu"+data); });

						
						$(button).parent().children('.sil').show();
						$(button).text('güncelle');
						$(button).parent().parent().parent().children('.tdKalem').children('.kalem').prop('disabled',true);
						$(button).parent().parent().parent().children('.tdGun').children('.gun').prop('disabled',true);
						$(button).parent().parent().parent().children('.tdBirimFiyat').children('.birimFiyat').prop('disabled',true);
						$(button).parent().parent().parent().children('.tdBirimMaliyet').children('.birimMaliyet').prop('disabled',true);
					}


				}

				function butcekaydet(button){

						if(projeId=="0"){
							alert("Butçenin ekleneceği projeyi seçin");
							return false;

						}
							 
					$.ajax({
							url: '/dao/butce-ekleme.php',
							data: { 
								kalem:$('.emptyLine td:nth-child(2) input').val(),
								adet_gun:$('.emptyLine td:nth-child(3) input').val(),
								birim_fiyati:$('.emptyLine td:nth-child(4) input').val(),
								teklif:$('.emptyLine td:nth-child(5) input').val(),
								birim_maliyet:$('.emptyLine td:nth-child(6) input').val(),
								toplam_maliyet:$('.emptyLine td:nth-child(7) input').val(),
								proje_id : projeId
							

							} })
						.done(function(data) { 
							
							refreshPage();
							 

						})
						.fail(function() { alert("Hata Oluştu"+data); });

					
				}

				function butceSil(button){

					var id=$(button).parent().parent().parent().children('.butceId').text();

					if (confirm("Butçe Silinecek ")) {
						$.ajax({
							url: '/dao/butceSil.php',
							data: { id: id } })
						.done(function(data) { 
							if(data=="success"){
								alert("Butçe Silindi."); 
								refreshPage();

								par.remove();}
								else{
									alert("Hata Oluştu, Butçe Silinemedi:");
					 			}
							})
						.fail(function() { alert("Hata Oluştu, Butçe Silinemedi"); });


					}
				}

				function refreshPage(){
					if(projeId=="0"){
						window.location="butce-ekleme.php"	
					}
					else{
						window.location="butce-ekleme.php?pid="+projeId+"&firma="+firma+"&padi="+proje;	
					}
				}

				$('#filtreTemizle').click(function(){
					$('tr:not(:first)').hide();      
					$('select').val('');
					$('.emptyLine').hide();
					$('#total').hide();
				}); 

				$('body').on('keypress','.numeric', function(e){

					var charCode = (e.which) ? e.which : event.keyCode;

					if ((charCode != 45 || $(this).val().indexOf('-') != -1) &&  (charCode != 46 || $(this).val().indexOf('.') != -1) && (charCode < 48 || charCode > 57)){
						return false;
					}
				});
				$('body').on('click','.numeric', function(e){
					if($(this).val()=='0')
						$(this).val('');
				});
				$('body').on('blur','.numeric', function(e){
					if($(this).val()=='')
						$(this).val('0');
				});

				$('body').on('keyup','.adet', function(e){
					var adet=$(this).val()?$(this).val():'0';
					var birim=$(this).parent().parent().children('td').children('.birim').val();
					birim=birim.replace(".","");
					var teklif=parseFloat(adet)*parseFloat(birim);

					$(this).parent().parent().children('td').children('.teklif').val(teklif);
					$(this).parent().parent().children('.dataTeklif').text(teklif);
					/***********/
					var birimMal=$(this).parent().parent().children('td').children('.birim-mal').val();
					birimMal=birimMal.replace(".","");
					var maliyet=parseFloat(adet)*parseFloat(birimMal);
					$(this).parent().parent().children('td').children('.maliyet').val(maliyet);
					$(this).parent().parent().children('.dataMaliyet').text(maliyet);
					/*********************/
					
					calTotal();
				});


				$('body').on('keyup','.birim', function(e){
					var birim=$(this).val()?$(this).val():'0';
					var adet=$(this).parent().parent().children('td').children('.adet').val();
					var teklif=parseFloat(adet)*parseFloat(birim);

					$(this).parent().parent().children('td').children('.teklif').val(teklif);
					$(this).parent().parent().children('.dataTeklif').text(teklif);
					calTotal();
				});


				$('body').on('keyup','.birim-mal', function(e){
					var birim=$(this).val()?$(this).val():'0';
					var adet=$(this).parent().parent().children('td').children('.adet').val();
					var maliyet=parseFloat(adet)*parseFloat(birim);

					$(this).parent().parent().children('td').children('.maliyet').val(maliyet);
					$(this).parent().parent().children('.dataMaliyet').text(maliyet);
					calTotal();
				});

				function calTotal(){

					var toplamTeklif=0;
					var toplamMaliyet=0;

					$('.teklif').each(function(){
					     var t=$(this).val().replace(".","");
						if($(this).parent().css('display')!='none')
							toplamTeklif=toplamTeklif+parseFloat(t);

					});

					$('.dataTeklif').each(function(){
					 var t=$(this).text().replace(".","");
						if($(this).parent().css('display')!='none')
							toplamTeklif=toplamTeklif+parseFloat(t);

					});


					$('.maliyet').each(function(){
					 var t=$(this).val().replace(".","");
						if($(this).parent().css('display')!='none')
							toplamMaliyet=toplamMaliyet+parseFloat(t);

					});

					$('.dataMaliyet').each(function(){
					 var t=$(this).text().replace(".","");
						if($(this).parent().css('display')!='none')
							toplamMaliyet=toplamMaliyet+parseFloat(t);

					});


					$('#toplamTeklif').text(toplamTeklif);
					$('#toplamMaliyet').text(toplamMaliyet);
					$('#kar').text(toplamTeklif-toplamMaliyet);

				}

				function exportExcel() {
			$('.icon-div').remove();

			$('td input').each(function(){
				var value=$(this).val();
				$(this).parent().text(value);
				$(this).remove();

			});
			$('.emptyLine').remove();
			var tableExport = document.getElementById('butceler');
			
			var htmlData = tableExport.outerHTML;
			var baslangic='<?=$baslangic?>';
			var firma1 ='<?=$_REQUEST['firma']?>';
			var projadi='<?=$requestProjeAdi?>'
			var bitis='<?=$bitis?>';
			var sorumlu='<?=$sorumlu?>';
			var sahip='<?=$sahip?>';
			var info='<table><tr><td>Proje Adı:</td><td>'+projadi+'</td></tr><tr><td>Firma Adı:</td><td>'+firma1+'</td></tr><tr><td>Baslangıç Tarihi :</td><td>'+baslangic+'</td></tr><tr><td>Bitiş Tarihi</td><td>'+bitis+'</td></tr><tr><td>Sorumlu:</td><td align="right" >'+sorumlu+'</td></tr><tr><td>İşin Sahibi</td><td align="right">'+sahip+'</td></tr></table>';
            var total='<table><tr><td>Toplam Teklif :</td><td>'+$('#toplamTeklif').html()+'</td></tr><tr><td>Toplam Mailyet</td><td>'+$('#toplamMaliyet').html()+'</td></tr><tr><td>Kar:</td><td align="right" >'+$('#kar').html()+'</td></tr></table>'; 
    		var html= info+'<br>'+htmlData+'<br>'+total;
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
		$('.numeric').click(function(){
		
		  $(this).val($(this).val().replace(".",""));
		
		});
		 $(function(){
				  
				    $('.numeric').each(function(){
					if($(this).val()!="")
					 $(this).val(formatCurrency($(this).val()));
					 
					 
					
					});
					$('.numericTd').each(function(){
					if($(this).text()!="")
					 $(this).text(formatCurrency($(this).text()));
					 
					 
					
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

			</script>

		</body>
		</html>
