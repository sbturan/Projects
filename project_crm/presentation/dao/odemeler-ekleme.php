<?php 
require_once("../config/config.php");
$mysqli = new mysqli(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD, DB_SCHEMA_NAME);
if (!$mysqli ) {
	die("Connection failed: " . mysqli_connect_error());
}
$mysqli->set_charset("utf8");
$query="insert into  ".DB_SCHEMA_NAME.".odemeler (fatura_no,tutar,odeme_tarihi,odeme_tipi,proje_id) values (?,?,?,?,?)";
$statement = $mysqli->prepare($query);


$results =  $statement->bind_param('ssssi', $_REQUEST['fatura_no'],$_REQUEST['odeme_tutari'],$_REQUEST['otarihi'],$_REQUEST['odeme_tipi'],$_REQUEST['pid']);
$kalanTutar=$_REQUEST['kalan_tutar'];
$guncelKalan=intval($kalanTutar)-intval($_REQUEST['odeme_tutari']);
$faturaNo=$_REQUEST['fatura_no'];
$statement->execute();
if($results){
        	$query2="update ".DB_SCHEMA_NAME.".faturalar set kalan_tutar='".$guncelKalan."',odenme_tarihi='".$_REQUEST['otarihi']."' where fatura_no='".$faturaNo."'" ;
			$statement2 = $mysqli->prepare($query2);
			$statement2->execute();
			
}else{
	error_log('Error : ('. $mysqli->errno .') '. $mysqli->error, 0);
	echo 'Error : ('. $mysqli->errno .') '. $mysqli->error;
}
?>
