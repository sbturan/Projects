<?php 
ob_start();
session_start();
?>
<!DOCTYPE html>

<html>
<meta http-equiv="Content-Type" content="text/HTML; charset=utf-8" />

<head>


<link rel="stylesheet" type="text/css" href="/style/style.css">



<script src="/js/jquery-2.1.4.min.js"></script>

<?php 

include("topMenu.php");
?>

</head>
<body>


<iframe style="width:100%; height:500px" src="fullcalendar/html/default.php">
</body>
</html>