<?

class Root extends AppController {

  public function __construct() {

    // Header Links 
    $menuLabels = array(
      'welcome' => 'Welcome',
      'about' => 'About',
      'team' => 'Team',
      'contact' => 'Contact'
    );

    // Header, Body and Footer
    $this->getView('navigation', $menuLabels);
    $this->getView('body');
    $this->getView('footer');
  }
}

?>