<?

class Main extends AppController {

  public function __construct() { }

  public function index() {

    // Header, Body and Footer
    $this->getView('navigation', array('pagename' => 'Welcome'));
    $this->getView('welcome');
    $this->getView('footer');
  }

  public function contact() {

    // Header, Body and Footer
    $this->getView('navigation', array('pagename' => 'Contact'));
    $this->getView('contact');
    $this->getView('footer');
  }

  public function contactRecv() {

    if (!filter_var($_POST['email'], FILTER_VALIDATE_EMAIL)) echo 'Email Invalid';
    else if ($_POST['description'] == NULL) echo 'Description Invalid';
    else echo 'Email and Description Valid';
  }

  public function ajaxPars() {

    if (@$_REQUEST['password'] == 'abc123') echo 'Welcome';
    else echo 'Incorrect Password';
  }
}

?>