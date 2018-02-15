<? 

class Profile extends AppController {

  public function __construct() {

    if (!@$_SESSION['loggedin'] && !@$_SESSION['loggedin'] == 1) {
      header('Location:/main');
    } 
  }

  public function index() {

    $this->getView('navigation', array('pagename' => 'Welcome'));

    // read file
    $lines = file("./assets/test.txt");

    // get each email and password
    foreach ($lines as $line) {

      // get email and password from line
      list($email, $password, $description) = explode('|', $line);

      // validate email
      if (
        $_SESSION['currentUser'] == 'Mike@aol.com' &&
        $email == 'Mike@aol.com') {

          echo $description;

      } else if (
        $_SESSION['currentUser'] == 'Joe@aol.com' &&
        $email == 'Joe@aol.com') {

          echo $description;
      }
    }
  }
}

?>