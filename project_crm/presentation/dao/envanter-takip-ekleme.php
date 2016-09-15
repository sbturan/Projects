<?php 
require_once("../config/config.php");
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}

$mysqli->set_charset("utf8");
$query="insert into  ".DB_SCHEMA_NAME.".envanter_takip (envanter_id,adet,calisan_id,alis_tarihi,teslim_tarihi) values (?,?,?,?,?)";
$statement = $mysqli->prepare($query);


$results =  $statement->bind_param('ssiss', $_REQUEST['envanter_id'],$_REQUEST['adet'],$_REQUEST['calisan_id'],$_REQUEST['alis_tarihi'],$_REQUEST['teslim-tarihi']);

$statement->execute();
echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
if($results){
	echo 'success'; 
}else{
	error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
	echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}
?>

