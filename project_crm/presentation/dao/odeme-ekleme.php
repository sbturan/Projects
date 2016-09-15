<?php 
require_once("../config/config.php");
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
$query="insert into  ".DB_SCHEMA_NAME.".fatura_takip (fatura_no,odenen_tutar,odeme_tarihi,odeme_tipi) values ?,?,?,?)";
$statement = $mysqli->prepare($query);


$results =  $statement->bind_param('sssi', $_REQUEST['fatura_no'],$_REQUEST['otutar'],$_REQUEST['otarihi'],$_REQUEST['odemetip']);

$statement->execute();
if($results){
	echo 'success'; 
}else{
	error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
	echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}
?>
