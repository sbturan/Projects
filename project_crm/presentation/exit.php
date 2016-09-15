<?php

session_start(); 
unset($_SESSION['logedIn']);


header("location: login.php");
?>