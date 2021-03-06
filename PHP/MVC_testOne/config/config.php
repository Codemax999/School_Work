<?

// defaults
$config = array(
  'defaultController' => 'main',
  'dbname' => 'fruits',
  'dbpass' => 'root',
  'dbuser' => 'root',
  'baseurl' => 'http://127.0.0.1'
);

// start session
session_start();
@$_SESSION['loggedin'];
@$_SESSION['testCaptcha'];
@$_SESSION['currentUser'];

// url and parameters
$str = "{$config['baseurl']}/{$_SERVER['REQUEST_URI']}";
$urlPathParts = explode('/', ltrim(parse_url($str, PHP_URL_PATH), '/'));

include 'router.php';
$route = new router($urlPathParts, $config);

?>