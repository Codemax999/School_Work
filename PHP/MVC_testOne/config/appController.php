<?  

class AppController {

  public function __construct($urlPathParts, $config) {

    // db information
    $this->urlPathParts = $urlPathParts;

    if ($urlPathParts[0]) {

      // new view
      include "./controllers/{$urlPathParts[0]}.php";
      $appcon = new $urlPathParts[0]($this);

      if (isset($urlPathParts[1])) $appcon->$urlPathParts[1]();
      else {

        // default method
        $methodVariable = array($appcon, 'index');
        if (is_callable($methodVariable, false, $call_name)) $appcon->index($this);
      }

    } else {
       
      // default view
      include "./controllers/{$config['defaultController']}.php";
      $appcon = new $config['defaultController']($this);

      if (isset($urlPathParts[1])) $appcon->config['defaultController'][1]();
      else {

        // default method
        $methodVariable = array($appcon, 'index');
        if (is_callable($methodVariable, false, $call_name)) $appcon->index($this);
      }
    }
  }

  public function getView($page, $data=array()) {

    require_once "./views/{$page}.php";
  }

  public function getModel() {

    // add this later
    // get then pass data to that page (view)
  }
}

?>