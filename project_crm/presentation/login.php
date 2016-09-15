<?php 
ob_start();
session_start();

?>
<!DOCTYPE html>
<html>
<meta http-equiv="Content-Type" content="text/HTML; charset=utf-8" />

<head>

</head>
<?php 

$error ="";

if (isset($_POST['submit'])) {
if (empty($_POST['username']) || empty($_POST['password'])) {
$error = "Username or Password is invalid";
  }

else{

$username=$_POST['username'];
$password=$_POST['password'];


require_once("config/config.php");



	$conn = mysqli_connect(DB_SERVERNAME, DB_USER_NAME, DB_PASSwORD);
	if (!$conn) {
		die("Connection failed: " . mysqli_connect_error());
	}

	$conn ->set_charset("utf8");

	$sql = "SELECT * FROM ".DB_SCHEMA_NAME.".users where is_admin <> 3 and u_name='".$username."'and password='".$password."';";
    
	$result = $conn->query($sql);
	

     
	 if ($result->num_rows > 0) {
       
		$row = $result->fetch_assoc();
			 
			 
		  $_SESSION['logedIn']=$username;
		  $_SESSION['isAdmin']=$row['is_admin'];
		 $url='index.php';
		echo '<script type="text/javascript"> window.location.href="'.$url.'"; </script>' ; 
			
		}

		else{
  			$error = "Username or Password is invalid";

		}


}

}

?>

<body>
<div id="login" style="  margin-left: 37%;">
<h2>Kullanıcı Girişi</h2>
<hr>
<form action="" method="post">
<label>Kullanıcı Adı  :</label>
<input type="text" name="username" id="name" placeholder="Kullanıcı Adı"><br><br>
<label>Şifre  :</label>
<input type="password" name="password" id="password" placeholder="**********"><br><br>
<input type="submit" value=" Giriş " name="submit"><br>
<?php if($error!=""){ echo '<span style="color: red;">Kullanıcı Adı/Şifre Hatalı</span>'; } ?>

</form>

</div>


<style type="text/css">

#main{
width:960px;
margin:50px auto;
font-family:raleway;
}

span{
color:red;
}

h2{
background-color: #FEFFED;
text-align:center;
border-radius: 10px 10px 0 0;
margin: -10px -40px;
padding: 15px;
}

hr{
border:0;
border-bottom:1px solid #ccc;
margin: 10px -40px;
margin-bottom: 30px;
}

#login{
width:300px;
float: left;
border-radius: 10px;
font-family:raleway;
border: 2px solid #ccc;
padding: 10px 40px 25px;
margin-top: 70px;
}
 
input[type=text],input[type=password]{
width:99.5%;
padding: 10px;
margin-top: 8px;
border: 1px solid #ccc;
padding-left: 5px;
font-size: 16px;
font-family:raleway;
} 

input[type=submit]{
width: 100%;
background-color:#FFBC00;
color: white;
border: 2px solid #FFCB00;
padding: 10px;
font-size:20px;
cursor:pointer;
border-radius: 5px;
margin-bottom: 15px;
}
#profile{
padding:50px;
border:1px dashed grey;
font-size:20px;
background-color:#DCE6F7;
}

#logout{
float:right;
padding:5px;
border:dashed 1px gray;
}

a{
text-decoration:none;
color: cornflowerblue;
}

i{
color: cornflowerblue;
}#note{
clear: left;
padding-top: 20px;
margin-left: 20px;
}
/*-----------------------------------------------------------------
css settings for right side advertisement
------------------------------------------------------------------*/
#formget{
float:right;
}	
</style>
</body>


</html>
