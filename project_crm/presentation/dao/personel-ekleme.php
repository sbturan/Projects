<?php 
require_once("../config/config.php");
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
$query="insert into  ".DB_SCHEMA_NAME.".personel (adsoyad,gorev_id,email,ceptel,istel,note,firma_id) values (?,?,?,?,?,?,?)";
$statement = $mysqli->prepare($query);
echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
$gorev_id=intval($_REQUEST['gorev_id']);
$firma_id=intval($_REQUEST['firma_id']);
$results =  $statement->bind_param('sissssi', $_REQUEST['adsoyad'],$_REQUEST['gorev_id'],$_REQUEST['email'],$_REQUEST['ceptel'],$_REQUEST['istel'],$_REQUEST['not'],$firma_id);

$statement->execute();
if($results){
	echo 'success'; 
}else{
	error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
	echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}
?>
