<?php 
require_once("../config/config.php");
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
$mysqli->set_charset("utf8");
if($_REQUEST['choose'] == '1'){
$query="update ".DB_SCHEMA_NAME.".kategoriler set aktif = ? where ktg_id=?  ";
}
if($_REQUEST['choose'] =='2'){
$query="update ".DB_SCHEMA_NAME.".calisan_gorev set aktif = ? where id=?  ";
}
if($_REQUEST['choose'] =='3'){
$query="update ".DB_SCHEMA_NAME.".harcama_tipler set aktif = ? where id=?  ";
}
if($_REQUEST['choose'] =='4'){
$query="update ".DB_SCHEMA_NAME.".odeme_tipler set aktif = ? where id=?  ";
}
if($_REQUEST['choose'] == '5'){
$query="update ".DB_SCHEMA_NAME.".personel_gorev set aktif = ? where id=?  ";

}
if($_REQUEST['choose'] == '6'){
$query="update ".DB_SCHEMA_NAME.".bankalar set aktif = ? where banka_id=?  ";

}
if($_REQUEST['choose'] == '7'){
$query="update ".DB_SCHEMA_NAME.".harcama_durum set aktif = ? where id=?  ";

}
$statement = $mysqli->prepare($query);
echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;

$results =  $statement->bind_param('ii', $_REQUEST['durum'],$_REQUEST['id']);

$statement->execute();
if($results){
	echo 'success'; 
}else{
	error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
	echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}
?>




