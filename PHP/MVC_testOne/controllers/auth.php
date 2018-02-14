<?

class Auth extends AppController {

  public function __construct() { }

  public function login() {

    if (
      $_REQUEST['username'] && 
      $_REQUEST['password'] &&
      $_REQUEST['username'] == 'mike@aol.com' &&
      $_REQUEST['password'] == 'password') {

        $_SESSION['loggedin'] = 1;
        header('Location:/main');

    } else header('Location:/main?msg=Bad Login');
  }

  public function logout() {

    session_destroy();
    header('Location:/main');
  }
}

?>