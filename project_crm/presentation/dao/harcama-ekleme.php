<?php 
require_once("../config/config.php");
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
$query="insert into  ".DB_SCHEMA_NAME.".harcamalar (harcama_tipi,firma_id,proje_id,fatura_tarih,harcama_tutar,fatura_no,harcama_yapanid,harcama_durum,aciklama,odeme_tarih,sirket_tipi,is_harici,kdv) values (?,?,?,?,?,?,?,?,?,?,?,?,?)";
$statement = $mysqli->prepare($query);
echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;

$results =  $statement->bind_param('iiisssissssss',$_REQUEST['harcamatip'],$_REQUEST['firma_id'],$_REQUEST['proje_id'],$_REQUEST['ftarihi'],$_REQUEST['tutar'],$_REQUEST['faturano'],$_REQUEST['harcamayap'],$_REQUEST['durum'],$_REQUEST['aciklama'],$_REQUEST['otarihi'],$_REQUEST['firma_tur'],$_REQUEST['is_harici'],$_REQUEST['kdv']);

$statement->execute();
if($results){
	echo 'success'; 
}else{
	error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
	echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}
?>
