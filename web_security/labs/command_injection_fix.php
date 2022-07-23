<?php
$newarg = escapeshellarg($_POST['pic']);
$fileloc = 'pictures/'.end(explode('/', $_POST['pic']));
$fileloc_esc = escapeshellarg($fileloc);
exec("wget -O {$fileloc_esc} {$newarg}");
?>
