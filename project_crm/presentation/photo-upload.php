<?php

if(isset($_FILES["file"]["type"]))
{
	$validextensions = array("jpeg", "jpg", "png");
	$temporary = explode(".", $_FILES["file"]["name"]);
	$file_extension = end($temporary);
	if ((($_FILES["file"]["type"] == "image/png") || ($_FILES["file"]["type"] == "image/jpg") || ($_FILES["file"]["type"] == "image/jpeg")
) && ($_FILES["file"]["size"] < 2000000)//Approx. 2mb files can be uploaded.
		&& in_array($file_extension, $validextensions)) {
		if ($_FILES["file"]["error"] > 0)
		{
			echo "Resim boyutu maximum 2 mb olmalıdır";
		}
		else
		{

			$tckn=$_REQUEST['tckn'];
$sourcePath = $_FILES['file']['tmp_name']; // Storing source path of the file in a variable
$targetPath = "photos/".$tckn.'-'.$_FILES['file']['name']; // Target path where file is to be stored
move_uploaded_file($sourcePath,$targetPath) ; // Moving Uploaded file

echo  'success'. $tckn.'-'. $_FILES["file"]["name"];

}
}
else
{
	echo "Resim boyutu maximum 2 mb olmalıdır";
}
}else{
	echo  'file type not setted';
}
?>