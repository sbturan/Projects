<!DOCTYPE html>
<html>
<meta http-equiv="Content-Type" content="text/HTML; charset=utf-8" />

<title>RAPOR EKRANI</title>
<link rel="stylesheet" type="text/css" href="/style/style.css">
<script src="/js/jquery-2.1.4.min.js"></script>
<?php 
include("topMenu.php");
require_once("config/config.php");



$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
if (!$conn) {
	die("Connection failed: " . mysqli_connect_error());
}

$conn ->set_charset("utf8");


$conn1 = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
if (!$conn1) {
	die("Connection failed: " . mysqli_connect_error());
}

$conn1 ->set_charset("utf8");
$conn2 = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
if (!$conn2) {
	die("Connection failed: " . mysqli_connect_error());
}

$conn2 ->set_charset("utf8");
?>


<body>

	<div id="firmalar" >
		<label>RAPORLAR</label> <br><br><br>
		<div style="  margin-left: 30%;">

			<label>RAPORLAR:</label>
			<select style="width:250px" id="cmbMake" name="Make" >
				<option value=""></option>
				<option value="2">İŞ BAZLI KARLILIK RAPORU</option>
				<option value="3">FİRMA BAZLI KARLILIK RAPORU</option>
				<option value="4">NAKİT AKIŞ RAPORU</option>
				<option value="5">PERSONELLER</option>
				<option value="6">PROJE BAZINDA ÇALIŞANLAR</option>
				<option value="7">ÖDEME DETAY RAPORU</option>
				<option value="8">BÜTÇE ve ÇALIŞANLAR RAPORU</option>
			</select>
			<button id="filtreTemizle" style="margin-left:5%">Filtreyi Temizle</button>
			<button id="indir" onclick="raporIndir()" style="margin-left:5%">İNDİR</button>
		</div> <br>
		<div class="datagrid" id="datagrid1">

			<table id="firmaTable">
				<tr>
					
					<th>
						FİRMA UNVANI
					</th>
					<th>
						ŞİRKET TİPİ
					</th>
					<th>
						İŞİN ADI
					</th>
					<th>
						BÜTÇE TOPLAMI

					</th>
					<th>
						HARCAMALAR TOPLAMI 
					</th>
					<th>
						KAR 
					</th>
					<th>
						FATURA TUTARI
					</th>
					<th>
						ÖDEMELER TOPLAMI
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
				$sql = "select d.firma_unvani,c.is_adi,c.kaynak,FORMAT(IFNULL(e.maliyet,0),1,'de_DE') maliyet,FORMAT(IFNULL(a.harcama_tutar,0),1,'de_DE') harcama_tutar,FORMAT(IFNULL(e.maliyet,0) - IFNULL(a.harcama_tutar,0),1,'de_DE') fark,FORMAT(IFNULL(b.odenen_tutar,0),1,'de_DE') odenen_tutar,FORMAT(b.kalan ,1,'de_DE') kalan,FORMAT(b.fatura_tutar,1,'de_DE') fatura_tutar from
                 (SELECT proj.proje_id,harcama_tutar
FROM ".DB_SCHEMA_NAME.".projeler proj
LEFT JOIN (

SELECT h.proje_id, SUM( harcama_tutar ) harcama_tutar
FROM ".DB_SCHEMA_NAME.".harcamalar h
GROUP BY h.proje_id
)sele ON sele.proje_id = proj.proje_id
)a,
                 (
SELECT pro.proje_id,se.odenen_tutar,se.kalan,se.fatura_tutar
FROM ".DB_SCHEMA_NAME.".projeler pro
LEFT JOIN (
SELECT fatu.proje_id, SUM( odem.tutar ) odenen_tutar,IFNULL(fatu.fatura_tutar,0)- IFNULL(SUM( odem.tutar ),0) kalan,fatu.fatura_tutar
FROM ".DB_SCHEMA_NAME.".faturalar fatu
LEFT JOIN ".DB_SCHEMA_NAME.".odemeler odem ON fatu.fatura_no = odem.fatura_no  and  fatu.proje_id = odem.proje_id
GROUP BY fatu.proje_id

)se ON se.proje_id = pro.proje_id
)b,

                 (SELECT proje_id,firma_id,is_adi,kaynak
                 FROM ".DB_SCHEMA_NAME.".projeler) c,
                 (SELECT firma_unvani,firma_id
                 FROM ".DB_SCHEMA_NAME.".firmalar) d,
                 (

SELECT firm.proje_id, SUM( bu.teklif ) maliyet
FROM ".DB_SCHEMA_NAME.".projeler firm
LEFT JOIN 
".DB_SCHEMA_NAME.".butceler bu on bu.proje_id = firm.proje_id
GROUP BY firm.proje_id                     
)e
                 where a.proje_id = b.proje_id and c.proje_id = b.proje_id and d.firma_id = c.firma_id and c.proje_id = e.proje_id order by firma_unvani";
                       
				$result1 = $conn->query($sql);
                

				if ($result1->num_rows > 0) {

					while($row = $result1->fetch_assoc()) {
						echo "<tr>";
						echo "<td style='width:19%;'>".$row['firma_unvani']."</td>";
						echo "<td style='width:10%;' >".$row['kaynak']."</td>";
						echo "<td style='width:19%;' >".$row['is_adi']."</td>";
						echo "<td  style='text-align:right;'>".$row['maliyet']."</td>";
						echo "<td  style='text-align:right;' >".$row['harcama_tutar']."</td>";
						echo "<td  style='text-align:right;'> ".$row['fark']."</td>";
						echo "<td  style='text-align:right;'>".$row['fatura_tutar']."</td>";
						echo "<td  style='text-align:right;'>".$row['odenen_tutar']."</td>";
						echo "<td  style='text-align:right;'>".$row['kalan']."</td>";
						echo "</tr>";  




					}
				} else {
					echo "0 results";
				}
				$conn->close();
				?>
			</table>
		</div>
		<div class="datagrid" id="datagrid2" >

			<table id="firmaTable1">
				<tr>
					
					<th>
						FİRMA UNVANI
					</th>
					
					<th>
						BÜTÇE TOPLAMI

					</th>
					<th>
						HARCAMALAR TOPLAMI 
					</th>
					<th>
						KAR 
					</th>
					<th>
						FATURA TUTARI
					</th>
					<th>
						ÖDEMELER TOPLAMI
					</th>
					<th>
						KALAN
					</th>
					

				</tr>

				<?php 

                $conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
				if (!$conn1) {
					die("Connection failed: " . mysqli_connect_error());
				}

				$conn ->set_charset("utf8");
				
				$sql = "SELECT d.firma_unvani,c.kaynak firma_turu, FORMAT(IFNULL(e.maliyet,0),1,'de_DE') maliyet,FORMAT(IFNULL(a.harcama_tutar,0),1,'de_DE') harcama_tutar, FORMAT(IFNULL(e.maliyet,0) - IFNULL(a.harcama_tutar,0),1,'de_DE') fark, FORMAT(IFNULL(b.odenen_tutar,0),1,'de_DE') odenen_tutar, FORMAT((IFNULL(u.fatura_tutar,0) - IFNULL(b.odenen_tutar,0) ),1,'de_DE') kalan,FORMAT(IFNULL(u.fatura_tutar,0),1,'de_DE') fatura_tutar
FROM (

SELECT proj.firma_id,harcama_tutar
FROM ".DB_SCHEMA_NAME.".firmalar proj
LEFT JOIN (

SELECT firma_id, SUM( harcama_tutar ) harcama_tutar
FROM ".DB_SCHEMA_NAME.".harcamalar h
GROUP BY firma_id
)sele ON sele.firma_id = proj.firma_id
)a,(
SELECT proj.firma_id,fatura_tutar
FROM ".DB_SCHEMA_NAME.".firmalar proj
LEFT JOIN (

SELECT firma_id, SUM( fatura_tutar ) fatura_tutar
FROM ".DB_SCHEMA_NAME.".faturalar 
GROUP BY firma_id
)seleu ON seleu.firma_id = proj.firma_id
)u,
(
SELECT pro.firma_id,se.odenen_tutar
FROM ".DB_SCHEMA_NAME.".firmalar pro
LEFT JOIN (
SELECT firma_id, IFNULL(sum(fatu.fatura_tutar),0)- IFNULL(SUM( odem.tutar ),0) kalan,IFNULL(SUM( odem.tutar ),0) odenen_tutar,IFNULL(sum(fatu.fatura_tutar),0) fatura_tutar
FROM ".DB_SCHEMA_NAME.".faturalar fatu
LEFT JOIN ".DB_SCHEMA_NAME.".odemeler odem ON fatu.fatura_no = odem.fatura_no and  fatu.proje_id = odem.proje_id
GROUP BY fatu.firma_id

)se ON se.firma_id = pro.firma_id
)b, 
(

SELECT proje.firma_id,proje.is_adi,proje.kaynak
FROM ".DB_SCHEMA_NAME.".projeler proje 
GROUP BY proje.firma_id
)c, (

SELECT  firma.firma_id, firma.firma_unvani,firma.firma_tur
FROM ".DB_SCHEMA_NAME.".firmalar firma
)d, (

SELECT firm.firma_id, maliyet
FROM ".DB_SCHEMA_NAME.".firmalar firm
LEFT JOIN (

SELECT pr.firma_id, SUM( bu.teklif ) maliyet
FROM ".DB_SCHEMA_NAME.".butceler bu, ".DB_SCHEMA_NAME.".projeler pr
WHERE pr.proje_id = bu.proje_id
GROUP BY pr.firma_id
)selec ON firm.firma_id = selec.firma_id

)e
WHERE a.firma_id = d.firma_id
AND b.firma_id = d.firma_id
AND d.firma_id = c.firma_id 
AND u.firma_id = c.firma_id
AND d.firma_id = e.firma_id order by firma_unvani";

				$result2 = $conn->query($sql);
               
				if ($result2->num_rows > 0) {

					while($row = $result2->fetch_assoc()) {
						echo "<tr>";
						echo "<td style='width:19%;' >".$row['firma_unvani']."</td>";
					
						echo "<td  style='text-align:right;'>".$row['maliyet']."</td>";
						echo "<td  style='text-align:right;'>".$row['harcama_tutar']."</td>";
						echo "<td  style='text-align:right;'>".$row['fark']."</td>";
						echo "<td  style='text-align:right;'>".$row['fatura_tutar']."</td>";
						echo "<td  style='text-align:right;'>".$row['odenen_tutar']."</td>";
						echo "<td  style='text-align:right;'>".$row['kalan']."</td>";
						echo "</tr>";  




					}
				} else {
					echo "0 results";
				}
				$conn1->close();
				?>
			</table>
		</div>  

		<div class="datagrid" id="datagrid3">

			<table id="firmaTable2">
				<tr>
					
					<th>
						FİRMA UNVANI
					</th>
					<th>
						ŞİRKET TİPİ
					</th>
					<th>
						PROJE
					</th>
					<th>
						FATURA NO

					</th>
					<th>
						FATURA TUTARI 
					</th>
					<th>
						FATURA TARİHİ 
					</th>
					<th>
						ÖDEMELER TOPLAMI
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

				$sql = "select p.is_adi,p.kaynak firma_turu,f.firma_unvani, k.* from
(SELECT fa.fatura_no, FORMAT(IFNULL(fa.fatura_tutar,0),1,'de_DE') fatura_tutar, fa.fatura_tarihi, fa.firma_id, FORMAT(IFNULL(o.tutar,0),1,'de_DE') odenen_tutar, FORMAT(IFNULL(fa.fatura_tutar,0) - IFNULL( o.tutar,0),1,'de_DE') kalan,fa.proje_id
FROM ".DB_SCHEMA_NAME.".faturalar fa
LEFT JOIN (

SELECT fatura_no, SUM( tutar ) tutar,proje_id
FROM ".DB_SCHEMA_NAME.".odemeler
GROUP BY fatura_no
)o ON o.fatura_no = fa.fatura_no and o.proje_id = fa.proje_id) k,
".DB_SCHEMA_NAME.".projeler p,
".DB_SCHEMA_NAME.".firmalar f
 WHERE f.firma_id = k.firma_id and p.firma_id=f.firma_id and p.proje_id = k.proje_id order by firma_unvani";
				
				$result3 = $conn2->query($sql);
                 
				if ($result3->num_rows > 0) {

					while($row = $result3->fetch_assoc()) {
						echo "<tr>";
						echo "<td style='width:19%;'>".$row['firma_unvani']."</td>";
						echo "<td style='width:10%;' >".$row['firma_turu']."</td>";
						echo "<td style='width:19%;'>".$row['is_adi']."</td>";
						echo "<td>".$row['fatura_no']."</td>";
						echo "<td  style='text-align:right;'>".$row['fatura_tutar']."</td>";
						echo "<td>".$row['fatura_tarihi']."</td>";
						echo "<td  style='text-align:right;'>".$row['odenen_tutar']."</td>";
						echo "<td  style='text-align:right;'>".$row['kalan']."</td>";
						echo "</tr>";  




					}
				} else {
					echo "0 results";
				}
				$conn2->close();
				?>
			</table>
		</div>
		 
		 <div class="datagrid" id="datagrid5">
             <div style=" margin-top:20px; margin-left: 30%;">

			<label>PROJE </label>



		<select id='projeler'  style ="margin-left: 16px; " >
			<option id="firmaSecin" value='' disabled selected ></option>
			<?php
			

			
			$sqlKategori = "SELECT *
			FROM ".DB_SCHEMA_NAME.".projeler p order by is_adi;";

			$resultKategori = $conn->query($sqlKategori);

			if ($resultKategori->num_rows > 0) {

				while($row = $resultKategori->fetch_assoc()) {

					echo "<option  value=". $row['proje_id'] ."> ".$row['is_adi']."</option>";

				} 

			}

			?>
		</select>
		<button id="filtreTemizle2" style="margin-left:5%">Filtreyi Temizle</button>
		
			
		</div> <br> 
			<table id="firmaTable4">
				<tr>
					
					<th>
						FİRMA ÜNVANI
					</th>
					<th>
								İŞİN ADI
							</th>
							<th>
								AD SOYAD
							</th>
							<th>
								TCKN
							</th>
							<th>
								DOĞUM TARİHİ
							</th>
							<th>
								TELEFON 
							</th>
							<th>
								EMAİL
							</th>
						   <th>
								GÖREVİ
							</th>
                          <th>
								BANKA ADI
							</th>
							<th>
								İBAN 
							</th>							
						
				</tr>

				<?php 
                $conn35 = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
				if (!$conn35) {
					die("Connection failed: " . mysqli_connect_error());
				}

				$conn35 ->set_charset("utf8"); 

				$sql35 = "SELECT cg.calisan_gorev as gorev, f.firma_unvani as unvan,p.is_adi as isin_adi,c.*,b.banka_adi as badi from ".DB_SCHEMA_NAME.".calisan c," .DB_SCHEMA_NAME.".projeler p," .DB_SCHEMA_NAME.".proje_calisan pc," .DB_SCHEMA_NAME.".bankalar b," .DB_SCHEMA_NAME.".firmalar f," .DB_SCHEMA_NAME.".calisan_gorev cg 
				where c.personel_id=pc.calisan_id and pc.proje_id=p.proje_id and c.banka_id=b.banka_id and 
				f.firma_id=p.firma_id and
				cg.id=c.gorev_id order by unvan" ;
				
				$result35 = $conn35->query($sql35);
                
				if ($result35->num_rows > 0) {

					while($row35 = $result35->fetch_assoc()) {
						echo "<tr>";
						echo "<td style='width:19%;' >".$row35['unvan']."</td>";
						echo "<td class='proje'>".$row35['isin_adi']."</td>";
						echo "<td>".$row35['adsoyad']."</td>";
						echo "<td>".$row35['tckn']."</td>";
						echo "<td>".$row35['dogum_tarihi']."</td>";
						echo "<td>".$row35['tel_no']."</td>";
						echo "<td>".$row35['email']."</td>";
						echo "<td>".$row35['gorev']."</td>";
						echo "<td>".$row35['badi']."</td>";
						echo "<td>".$row35['iban']."</td>";
						echo "</tr>";  




					}
				} else {
					echo "0 results";
				}
				$conn35->close();
				?>
			</table>
		</div>
		
		 <div class="datagrid" id="datagrid4">
               
		   
			<table id="firmaTable3">
				<tr>
					
					<th>
						FİRMA ÜNVANI
					</th>
					<th>
								AD SOYAD
							</th>
							<th>
								GOREV
							</th>
							<th>
								EMAİL
							</th>
							<th>
								CEP TEL
							</th>
							<th>
								İŞ TEL 
							</th>
							<th>
								NOT 
							</th>
						
				</tr>

				<?php 
                $conn34 = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
				if (!$conn34) {
					die("Connection failed: " . mysqli_connect_error());
				}

				$conn34 ->set_charset("utf8"); 

				$sql34 = "SELECT f.firma_unvani, p.* ,g.gorev  FROM ".DB_SCHEMA_NAME.".personel p, ".DB_SCHEMA_NAME.".firmalar f, ".DB_SCHEMA_NAME.".personel_gorev g WHERE f.firma_id = p.firma_id and g.id=p.gorev_id order by firma_unvani" ;
				
				$result34 = $conn34->query($sql34);
                
				if ($result34->num_rows > 0) {

					while($row34 = $result34->fetch_assoc()) {
						echo "<tr>";
						echo "<td style='width:19%;'>".$row34['firma_unvani']."</td>";
						echo "<td>".$row34['adsoyad']."</td>";
						echo "<td>".$row34['gorev']."</td>";
						echo "<td>".$row34['email']."</td>";
						echo "<td>".$row34['ceptel']."</td>";
						echo "<td>".$row34['istel']."</td>";
						echo "<td>".$row34['note']."</td>";
						echo "</tr>";  




					}
				} else {
					echo "0 results";
				}
				$conn34->close();
				?>
			</table>
		</div>
		<div class="datagrid" id="datagrid6">
               
		   
			<table id="firmaTable5">
				<tr>
							
					<th>
						FİRMA ÜNVANI
					</th>
					<th>
								ŞİRKET TİPİ
							</th>
							<th>
								PROJE
							</th>
							<th>
								FATURA NO
							</th>
							<th>
								FATURA TUTARI
							</th>
							<th>
								FATURA TARİHİ
							</th>
							<th>
								ÖDENEN TUTAR
							</th>
							<th>
								ÖDENEN TARİHİ
							</th>
						
				</tr>

				<?php 
                $conn34 = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
				if (!$conn34) {
					die("Connection failed: " . mysqli_connect_error());
				}

				$conn34 ->set_charset("utf8"); 

				$sql34 = "select f.firma_unvani,p.is_adi,p.kaynak,a.* from

(select f.*,FORMAT((IFNULL(f.fatura_tutar,0)- IFNULL(fa.tutar,0)),1,'de_DE') kala,fa.tutar,fa.odeme_tarihi
from  ".DB_SCHEMA_NAME.".faturalar f left join 
(select fa.fatura_no,fa.proje_id,IFNULL(o.tutar,0) tutar,o.odeme_tarihi from ".DB_SCHEMA_NAME.".faturalar fa LEFT JOIN ".DB_SCHEMA_NAME.".odemeler o on o.fatura_no = fa.fatura_no and o.proje_id = fa.proje_id 

)fa on fa.fatura_no = f.fatura_no and fa.proje_id = f.proje_id ) a,
".DB_SCHEMA_NAME.".firmalar f,
".DB_SCHEMA_NAME.".projeler p


where f.firma_id = p.firma_id and a.firma_id = f.firma_id and p.proje_id = a.proje_id order by f.firma_unvani  ,p.is_adi , a.odeme_tarihi" ;
				
				$result34 = $conn34->query($sql34);
                
				if ($result34->num_rows > 0) {

					while($row34 = $result34->fetch_assoc()) {
						echo "<tr>";
						echo "<td style='width:19%;'>".$row34['firma_unvani']."</td>";
						echo "<td>".$row34['kaynak']."</td>";
						echo "<td>".$row34['is_adi']."</td>";
						echo "<td>".$row34['fatura_no']."</td>";
						echo "<td>".$row34['fatura_tutar']."</td>";
						echo "<td>".$row34['fatura_tarihi']."</td>";
						echo "<td>".$row34['tutar']."</td>";
						echo "<td>".$row34['odeme_tarihi']."</td>";
						echo "</tr>";  




					}
				} else {
					echo "0 results";
				}
				$conn34->close();
				?>
			</table>
		</div>
		<div class="datagrid" id="datagrid7">
               
		   
			<table id="firmaTable6">
				<th>
						FİRMA ÜNVANI
					</th>
					<th>
								İŞ ADI
							</th>
							<th>
								KATEGORİ
							</th>
							<th>
								BAŞLANGIÇ TARİHİ
							</th>
							<th>
								BİTİŞ TARİHİ
							</th>
							<th>
								İŞİN LOKASYONU
							</th>
							<th>
								PROJE SORUMLUSU
							</th>
							<th>
								İŞİN SAHİBİ
							</th>
							<th>
								ÇALIŞACAK KİŞİLER
							</th>
							<th>
								BÜTÇE ONAYLANDI MI?
							</th>
							<th>
								BÜTÇE TEKLİFİ
							</th>
							<th>
								KAYNAK
							</th>
						
				</tr>

				<?php 
                $conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
				if (!$conn) {
					die("Connection failed: " . mysqli_connect_error());
				}

				$conn ->set_charset("utf8"); 

				$sql34 = "SELECT  f.firma_unvani, p.is_adi,k.kategori_ad, p.baslangic_tarih, p.bitis_tarihi, p.isin_lokasyonu, ps.adsoyad proje_sorumlusu, pera.adsoyad isin_Sahibi, pcer.cal, p.butce, be.teklif,p.kaynak
FROM ".DB_SCHEMA_NAME.".projeler p,".DB_SCHEMA_NAME.".kategoriler k, (select ppproj.proje_id,pce.cal from ".DB_SCHEMA_NAME.".projeler ppproj LEFT JOIN
(SELECT GROUP_CONCAT( c.adsoyad ) cal, pc.proje_id
FROM ".DB_SCHEMA_NAME.".proje_calisan pc, ".DB_SCHEMA_NAME.".calisan c
WHERE pc.calisan_id = c.personel_id
GROUP BY pc.proje_id
)pce on ppproj.proje_id= pce.proje_id) pcer, ".DB_SCHEMA_NAME.".firmalar f, (select pproj.proje_id,IFNULL(SUM( b.teklif ),0) teklif from ".DB_SCHEMA_NAME.".projeler pproj LEFT JOIN ".DB_SCHEMA_NAME.".butceler b on pproj.proje_id = b.proje_id group by pproj.proje_id) be , (select proj.proje_id,per.adsoyad from ".DB_SCHEMA_NAME.".projeler proj LEFT JOIN ".DB_SCHEMA_NAME.".personel per on per.p_id = proj.sahip ) pera, (

SELECT pe.proje_id, ca.adsoyad
FROM  ".DB_SCHEMA_NAME.".projeler pe LEFT JOIN ".DB_SCHEMA_NAME.".calisan ca on  pe.proje_sorumlusu = ca.personel_id
)ps
WHERE p.proje_id = pcer.proje_id
AND k.ktg_id = f.ktg_id
AND f.firma_id = p.firma_id
AND be.proje_id = p.proje_id
AND ps.proje_id = p.proje_id
AND pera.proje_id = p.proje_id order by f.firma_unvani";
				
				$result38 = $conn->query($sql34);
                
				if ($result38->num_rows > 0) {

					while($row38 = $result38->fetch_assoc()) {
						echo "<tr>";
						echo "<td style='width:19%;'>".$row38['firma_unvani']."</td>";
						echo "<td style='width:19%;'>".$row38['is_adi']."</td>";
						echo "<td>".$row38['kategori_ad']."</td>";
						echo "<td>".$row38['baslangic_tarih']."</td>";
						echo "<td>".$row38['bitis_tarihi']."</td>";
						echo "<td>".$row38['isin_lokasyonu']."</td>";
						echo "<td>".$row38['proje_sorumlusu']."</td>";
						echo "<td>".$row38['isin_Sahibi']."</td>";
						echo "<td>".$row38['cal']."</td>";
						echo "<td>".$row38['butce']."</td>";
						echo "<td>".$row38['teklif']."</td>";
						echo "<td>".$row38['kaynak']."</td>";
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
	$('#cmbMake').on('change',function(){
		var id= this.value;
		if(id =='2')
		{   
			hideAll();
		    $("#datagrid1").show();
		}
		if(id == '3')
		{
			
			hideAll();
		    $("#datagrid2").show();
		}
		if(id =='4')
		{
			
			hideAll();
		    $("#datagrid3").show();
		}
		
		if(id=='5'){
	         hideAll();
		    $("#datagrid4").show();
	
   		
		}
		if(id=='6'){
		     hideAll();
		    $("#datagrid5").show();
		}
        if(id=='7'){
		     hideAll();
		    $("#datagrid6").show();
		}
		if(id=='8'){
		     hideAll();
		    $("#datagrid7").show();
		}
	
		

	});

		$(window).load(function(){
			
		hideAll();
		});
		function hideAll(){
			$("#datagrid3").hide();
			$("#datagrid1").hide();
			$("#datagrid2").hide();
			$("#datagrid4").hide();
			$("#datagrid5").hide();
			$("#datagrid6").hide();
			$("#datagrid7").hide();
			$("#datagrid8").hide();
		}

		$('#filtreTemizle').click(function(){

			$('tr').show();      
			$('select').val('');
			hideAll();
		}); 
		
		$('#projeler').change(function(){
		  var proje= $('#projeler option:selected').text();
		   $('#firmaTable4 .proje').each(function(){
		     if($.trim($(this).text())==$.trim(proje)){
			   $(this).parent().show();
			 } else{
			  $(this).parent().hide();
			 }
			 
		     
		   });
		 
		
		
		});
		
		$('#filtreTemizle2').click(function(){
		$('#firmaTable4 tr').show();
		$('#firmaSecin').attr("selected",true);
		});
		
		    
		
		function exportExcel(tableId) {
			
			var tableExport = document.getElementById(tableId);
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
			
		}
		
		function raporIndir(){
		   var selected=$('#cmbMake option:selected').val();
		   if(selected=='2'){
		     exportExcel('firmaTable');
		   } else if(selected=='3'){
		     exportExcel('firmaTable1');
		   }
		   else if(selected=='4'){
		     exportExcel('firmaTable2');
		   }
		   else if(selected=='5'){
		     exportExcel('firmaTable3');
		   }
		   else if(selected=='6'){
		     exportExcel('firmaTable4');
		    
		   }
		   else if(selected=='7'){
		     exportExcel('firmaTable5');
		    
		   }
		   else if(selected=='8'){
		     exportExcel('firmaTable6');
		    
		   }
		}
		
		
		
		 $(function(){
				  
				    $('.tutar').each(function(){
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