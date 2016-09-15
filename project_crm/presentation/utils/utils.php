<?php 

function phoneNumberFormatter($number){

	$tel_no=str_replace("(","",$number);
		$tel_no=str_replace(")","",$tel_no);
		$tel_no=str_replace("+","",$tel_no);
		$tel_no=str_replace(" ","",$tel_no);

		return $tel_no;
	}
	?>