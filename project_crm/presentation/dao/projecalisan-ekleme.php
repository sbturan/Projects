<?php 
require_once("../config/config.php");
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
$query="insert into  ".DB_SCHEMA_NAME.".proje_calisan ( proje_id,calisan_id)   values (?,?)";
if(strcmp($_REQUEST['calisacakkisiler'],"")!=0){
$ckisiler=$_REQUEST['calisacakkisiler'];
$calisacakkisiler=explode(",",$ckisiler);

for($i=0;$i<sizeof($calisacakkisiler);$i++){
$statement = $mysqli->prepare($query);

$results =  $statement->bind_param('ii',$_REQUEST['proje_id'],$calisacakkisiler[$i]);

$statement->execute();


}

}
if($results){
	echo 'success'; 
}else{
	error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
	echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}
?>