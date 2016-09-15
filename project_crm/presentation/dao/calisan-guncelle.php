<?php 
require_once("../config/config.php");
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
$query="update ".DB_SCHEMA_NAME.".calisan set 
	personel_tip=?,adsoyad=?,tckn=?,okul=?,email=?,gorev_id=?,dogum_tarihi=?,	kan_grubu=?,tel_no=?,foto_path=?,
	adres=?,askerlik=?,sabıka=?,ikametgah=?,banka_id=?,iban=?,sinif=? where personel_id=?  ";
$statement = $mysqli->prepare($query);
echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;

$results =  $statement->bind_param('sssssissssssssissi', $_REQUEST['personel_tip'],$_REQUEST['adsoyad'],$_REQUEST['tckn'],
	$_REQUEST['okul'],$_REQUEST['email'],
	$_REQUEST['gorev_id'],$_REQUEST['dogum_tarihi'],$_REQUEST['kan_grubu'],
	$_REQUEST['tel_no'],$_REQUEST['foto_path'],$_REQUEST['adres'],
	$_REQUEST['askerlik'],$_REQUEST['sabika'],$_REQUEST['ikametgah'],$_REQUEST['banka_id'],$_REQUEST['iban'],$_REQUEST['sinif'],$_REQUEST['id']);

$statement->execute();
if($results){
	echo 'success'; 
}else{
	error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
	echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}
?>

