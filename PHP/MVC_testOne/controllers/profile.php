<? 

class Profile extends AppController {

  public function __construct() {

    if (!@$_SESSION['loggedin'] && !@$_SESSION['loggedin'] == 1) {
      header('Location:/main');
    } 
  }

  public function index() {

    $this->getView('navigation', array('pagename' => 'Welcome'));
    echo 'This is a protected area';
  }
}

?>