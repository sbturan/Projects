<?php 

require_once("../config/config.php");
$id=$_REQUEST['id'];
$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
if (!$conn) {
	die("Connection failed: " . mysqli_connect_error());
}

$conn ->set_charset("utf8");
$sql = "DELETE  FROM ".DB_SCHEMA_NAME.".projeler where proje_id=".$id;

if ($conn->query($sql) === TRUE) {
	echo "success";
} else {
	 error_log("Personel Silme Hatası : " . $conn->error, 0);
	echo "Error deleting record: " . $conn->error;
}
?>