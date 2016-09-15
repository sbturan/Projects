<?php 

require_once("../config/config.php");
$id=$_REQUEST['id'];
$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
if (!$conn) {
	die("Connection failed: " . mysqli_connect_error());
}

$conn ->set_charset("utf8");
$sql  = "DELETE  FROM ".DB_SCHEMA_NAME.".faturalar where fatura_no='".$id."';";
$sql1 = "DELETE  FROM ".DB_SCHEMA_NAME.".odemeler where fatura_no='".$id."';";

if ($conn->query($sql) === TRUE) {
	if ($conn->query($sql1) === TRUE) {
	  echo "success";
	} else {
	  error_log("Firma Silme Hatası : " . $conn->error, 0);
	  echo "Error deleting record: " . $conn->error;
	}
} else {
	 error_log("Firma Silme Hatası : " . $conn->error, 0);
	echo "Error deleting record: " . $conn->error;
}
?>
