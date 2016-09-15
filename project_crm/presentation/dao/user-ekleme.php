<?php 
require_once("../config/config.php");
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
$query="insert into  ".DB_SCHEMA_NAME.".users (u_name,password,is_admin)   values (?,?,?)";
$statement = $mysqli->prepare($query);
echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;

$results =  $statement->bind_param('ssi', $_REQUEST['u_name'],$_REQUEST['password'],$_REQUEST['admin']);

$statement->execute();
if($results){
	echo 'success'; 
}else{
	error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
	echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}
?>

