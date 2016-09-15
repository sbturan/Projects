<?php 
error_reporting(0);
ob_start();
session_start();

?>
<?php 

if(!isset($_SESSION['logedIn'])){

	// header("location: login.php");
	$url='login.php';
	echo '<script type="text/javascript"> window.location.href="'.$url.'"; </script>' ; 
}




?>