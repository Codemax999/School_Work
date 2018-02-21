<?

class Auth extends AppController {

  public function __construct($parent) {
    
    $this->parent = $parent;
  }

  public function login() {

    // verify for email and password
    if ($_REQUEST['email'] && $_REQUEST['password']) {

      // check database for user
      $data = $this->parent->getModel('users')->select(
        'select * from users where email = :email and password = :password',
        array(":email" => $_REQUEST['email'], "password" => sha1($_REQUEST['password']))
      );

      // if user found and info is correct: log in
      if ($data) {

          $_SESSION['loggedin'] = 1;
          $_SESSION['currentUser'] = $_REQUEST['email'];
          header('Location:/main');

      } else header('Location:/main?msg=Bad Login');
    }
  }

  public function logout() {

    // clear session variables and go to Main
    session_destroy();
    header('Location:/main');
  }
}

?>