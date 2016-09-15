<?php 

require_once("../config/config.php");
$email=$_REQUEST['email'];
$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
if (!$conn) {
	die("Connection failed: " . mysqli_connect_error());
}

$conn ->set_charset("utf8");
$sql = "DELETE  FROM ".DB_SCHEMA_NAME.".personel where email=?";
$statement = $conn->prepare($sql);

$statement->bind_param('s', $email);
$statement->execute(); 
$statement->close();

echo "success";
?>