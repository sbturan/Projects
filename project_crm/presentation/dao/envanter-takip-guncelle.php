<?php 
require_once("../config/config.php");
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
$query="update  ".DB_SCHEMA_NAME.".envanter_takip set calisan_id=?,alis_tarihi=?,teslim_tarihi=? where id=?";
$statement = $mysqli->prepare($query);

echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
$results =  $statement->bind_param('issi', $_REQUEST['calisan_id'],$_REQUEST['alis_tarihi'],$_REQUEST['teslim_tarihi'],
	$_REQUEST['etid']);

$statement->execute();
echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
if($results){
	echo 'success'; 
}else{
	error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
	echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}
?>

