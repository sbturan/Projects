<?php 
require_once("../config/config.php");
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
$query="insert into  ".DB_SCHEMA_NAME.".firmalar (firma_tur,email,firma_unvani,tel_no,fax,adres,vergi_no,vergi_dairesi,ktg_id,banka_id,iban_no) values (?,?,?,?,?,?,?,?,?,?,?)";
$statement = $mysqli->prepare($query);
echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;

$results =  $statement->bind_param('ssssssssiis', $_REQUEST['firma_tur'],$_REQUEST['email'],$_REQUEST['firma_unvani'],$_REQUEST['tel_no'],
	$_REQUEST['fax'],$_REQUEST['adres'],$_REQUEST['vergi_no'],$_REQUEST['vergi_dairesi'],$_REQUEST['ktg_id'],$_REQUEST['banka_id'],$_REQUEST['iban_no']);

$statement->execute();
if($results){
	echo 'success'; 
}else{
	error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
	echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}
?>

