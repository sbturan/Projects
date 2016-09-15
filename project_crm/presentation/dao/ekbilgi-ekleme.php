<?php 
require_once("../config/config.php");
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
if($_REQUEST['choose'] == '1'){
	
$query="insert into  ".DB_SCHEMA_NAME.".kategoriler (kategori_ad,aktif)  values (?,?)  ";
}
if($_REQUEST['choose'] =='2'){
$query="insert into  ".DB_SCHEMA_NAME.".calisan_gorev (calisan_gorev,aktif)  values (?,?)  ";
}
if($_REQUEST['choose'] =='3'){

$query="insert into  ".DB_SCHEMA_NAME.".harcama_tipler (harcama_tip,aktif)  values (?,?)  ";
}
if($_REQUEST['choose'] =='4'){
$query="insert into  ".DB_SCHEMA_NAME.".odeme_tipler (odme_tipi,aktif)  values (?,?)  ";
}
if($_REQUEST['choose'] == '5'){
$query="insert into  ".DB_SCHEMA_NAME.".personel_gorev (gorev,aktif)  values (?,?)  ";

}
if($_REQUEST['choose'] == '6'){
$query="insert into  ".DB_SCHEMA_NAME.".bankalar (banka_adi,aktif)  values (?,?)  ";

}
if($_REQUEST['choose'] == '7'){
$query="insert into  ".DB_SCHEMA_NAME.".harcama_durum (harcama_adi,aktif)  values (?,?)  ";

}
$statement = $mysqli->prepare($query);
echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;

$results =  $statement->bind_param('ss', $_REQUEST['u_name'],$_REQUEST['aktif']);

$statement->execute();
if($results){
	echo 'success'; 
}else{
	error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
	echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}
?>

