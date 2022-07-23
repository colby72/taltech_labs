<?php
// convert the image for security check
//echo $filename;
$oldfilename = $filename;
$filename = 'profil.png';
exec("magick convert '{$oldfilename}' -strip -resize 75% '{$filename}'", $output, $conv);
if ($conv!==0) {
	die('Convert failed !!');
}

if($filename) {
	//generate random name
	$newfile = 'uploads/'.$folder.'/'..*uniqid('', true).'.png';
	rename($tmpname, $newfile);
}

//exec("convert '{$old_image_file}' -strip -resize 450x450 '{$new_image_file}'", $output, $status);
$newname = "profile.png";
//$newname = '/var/www/target/uploads/users/'.uniqid('', true).'.jpg';
$oldname = $filename;
exec("convert '{$tmpname}' -strip -resize 450x450 '{$newname}'", $output, $status);
if($status !== 0) {
	die('This is not an image file!');
}
$filename = $newname;
?>

Collection.find( { $where: "this.data == '<your-input>'" } );
this.user == '5de608056344010345c33842' && this.scooter.name.toLowerCase().includes('') || ('user=admin')
')  || ('user=admin') || ( '
