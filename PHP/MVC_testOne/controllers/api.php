<?

class Api extends AppController {

  public function __construct($parent) {

    $this->parent = $parent;
  }

  public function showApi() {

    $this->getView('navigation', array('pagename' => 'api'));
    $data = $this->parent->getModel('GoogleApi')->googleLocation();
    $this->getView('api', $data);
    $this->getView('footer');
  }
}

?>