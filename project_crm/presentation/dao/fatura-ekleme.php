<?php 
require_once("../config/config.php");
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
$query="insert into  ".DB_SCHEMA_NAME.".faturalar (fatura_no,proje_id,firma_id,fatura_tutar,fatura_tarihi,kdvtutar,duzenlenme_tarihi,odenme_tarihi,kalan_tutar) values (?,?,?,?,?,?,?,?,?)";
$statement = $mysqli->prepare($query);


$results =  $statement->bind_param('siissssss', $_REQUEST['fatura_no'],$_REQUEST['proje_id'],$_REQUEST['firma_id'],$_REQUEST['tutar'],$_REQUEST['ftarihi'],$_REQUEST['kdvtutar'],$_REQUEST['dtarihi'],$_REQUEST['otarihi'],$_REQUEST['tutar']);

$statement->execute();
echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
if($results){
	echo 'success'; 
}else{
	error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
	echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}
?>
