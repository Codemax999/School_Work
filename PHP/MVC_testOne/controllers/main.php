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
    $random = substr(md5(rand()), 0, 7);
    $this->getView('contact',array('cap'=>$random));
  }

  public function contactRecv() {

    $this->getView('navigation');

    if ($_REQUEST['captcha'] == $_SESSION['testCaptcha']) {

      if (!filter_var($_POST['email'],FILTER_VALIDATE_EMAIL)) {

        echo '<p>Email invalid</p>';
        echo "<br><a href='/main/contact'>Click here to go back</a>";

      } else echo '<p>Email valid</p>';

    } else {

      echo 'Invalid captcha';
      echo "<br><a href='/main/contact'>Click here to go back</a>";
    }
  }

  public function ajaxPars() {

    if (@$_REQUEST['password'] == 'abc123') echo 'Welcome';
    else echo 'Incorrect Password';
  }
}

?>