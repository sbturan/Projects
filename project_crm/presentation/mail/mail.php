<?php

$mail->CharSet  = 'utf-8'; 
$ekbaslikbilgisi= 'sifre';
$kime = $_REQUEST['mail'];

$konu = 'Sanatli Karinca Sifreniz: ';

$mesaj= ' '.$_REQUEST['sifre'];


 
$mail = mail($kime, $konu, $mesaj, $ekbaslikbilgisi);
 

?>