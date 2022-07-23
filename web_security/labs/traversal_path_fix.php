<?php
case 'competition':
		if (!empty($_REQUEST['id']) && !empty($_REQUEST['name']) ){
			view_competition($_REQUEST['id']);
		} else {
			$allowedPath = "/var/www/target/uploads/";
			$fullpath = realpath($_REQUEST['name']);
			if ((substr($fullpath, 0, strlen($allowedPath)) !== $allowedPath)
			or (substr($fullpath, -3) !== ".md")) {
				die("Path denied !!");
			}
			$_SESSION['alerts'][] = "Not enough info to display this competition";
			header("Location: ?");
			exit(0);
		}
break;
?>
// nodeJS
if (request.query.filepath.split('.').pop() !== 'md') {
				return Boom.badRequest('Invalid file extension.');
}
