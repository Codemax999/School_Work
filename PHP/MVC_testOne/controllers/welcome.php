<?

class Welcome extends AppController {

  public function __construct() {

    $this->setHeader();
    $this->setBody();
    $this->setFooter();
  }

  public function setHeader() {

    $menuLabels = array(
      'about' => 'About',
      'hisoty' => 'History',
      'team' => 'Team',
      'contact' => 'Contact'
    );

    $this->getView('navigation', $menuLabels);
  }

  public function setBody() {

    $this->getView('body');
  }

  public function setFooter() {

    $this->getView('footer');
  }
}

?>