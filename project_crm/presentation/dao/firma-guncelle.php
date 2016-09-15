<?php 
require_once("../config/config.php");

//$mysqli = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
$query="Update ".DB_SCHEMA_NAME.".firmalar set firma_tur=?, firma_unvani=?, email=?,tel_no=?,fax=?,adres=?,vergi_no=?,vergi_dairesi=?,ktg_id=?,banka_id=?,iban_no=? where firma_id=?";

$statement = $mysqli->prepare($query);
$firma_id=intval($_REQUEST['firma_id']);
$firma_unvani=$_REQUEST['firma_unvani'];
$email=$_REQUEST['email'];
$tel_no=$_REQUEST['tel_no'];
$fax=$_REQUEST['fax'];
$vergi_no=intval($_REQUEST['vergi_no']);
$ktg_id=intval($_REQUEST['ktg_id']);
$banka_id=intval($_REQUEST['banka_id']);


//bind parameters for markers, where (s = string, i = integer, d = double,  b = blob)
$results =  $statement->bind_param('ssssssssiisi', $_REQUEST['firma_tur'], $_REQUEST['firma_unvani'], $_REQUEST['email'],$tel_no,$fax,$_REQUEST['adres'],$_REQUEST['vergi_no'],$_REQUEST['vergi_dairesi'],$ktg_id,$banka_id,$_REQUEST['iban_no'],$firma_id);
$statement->execute();
if($results){
    echo 'success'; 
}else{
	 error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
    echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}


?>