<?

class Auth extends AppController {

  public function __construct() { }

  public function login() {

    // read file
    $lines = file("./assets/test.txt");

    // get each email and password
    foreach ($lines as $line) {

      // get email and password from line
      list($email, $password) = explode('|', $line);

      // validate email then password
      if ($_REQUEST['email'] == 'Mike@aol.com') {

        if ($_REQUEST['password'] == 'password') {

          // log in Mike
          $_SESSION['loggedin'] = 1;
          $_SESSION['currentUser'] = $_REQUEST['email'];
          header('Location:/main');

        } else header('Location:/main?msg=Incorrect Password');

      } else if ($_REQUEST['email'] == 'Joe@aol.com') {

        if ($_REQUEST['password'] == 'password') {

          // log in Joe
          $_SESSION['loggedin'] = 1;
          $_SESSION['currentUser'] = $_REQUEST['email'];
          header('Location:/main');

        } else header('Location:/main?msg=Incorrect Password');
        
      } else header('Location:/main?msg=Bad Login');
    }
  }

  public function logout() {

    session_destroy();
    header('Location:/main');
  }
}

?>