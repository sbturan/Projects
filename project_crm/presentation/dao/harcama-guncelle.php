<?php 
require_once("../config/config.php");

//$mysqli = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
$query="Update ".DB_SCHEMA_NAME.".harcamalar set harcama_tipi=?,fatura_tarih=?,harcama_tutar=?,fatura_no=?,harcama_yapanid=?,harcama_durum=?,aciklama=?,odeme_tarih=?,sirket_tipi=?,is_harici=?,kdv=?  where harcama_id=?";

$statement = $mysqli->prepare($query);


//bind parameters for markers, where (s = string, i = integer, d = double,  b = blob)
$results =  $statement->bind_param('isssissssssi',$_REQUEST['harcamatip'],$_REQUEST['ftarihi'],$_REQUEST['tutar'],$_REQUEST['faturano'],$_REQUEST['harcamayap'],$_REQUEST['durum'],$_REQUEST['aciklama'],$_REQUEST['otarihi'],$_REQUEST['firma_tur'],$_REQUEST['is_harici'],$_REQUEST['kdv'],$_REQUEST['id']);
$statement->execute();
if($results){
    echo 'success'; 
}else{
	 error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
    echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}


?>