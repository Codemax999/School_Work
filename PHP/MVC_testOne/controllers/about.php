<?

class About extends AppController {

  public function __construct($parent) {

    $this->parent = $parent;
    $this->showList();
  }

  public function showList() {

    $data = $this->parent->getModel('fruits')->select("select * from fruit_table");
    $this->getView('navigation', array('pagename' => 'about'));
    $this->getView('about', $data);

    // determine whether to show new item or update item
    if (@$_REQUEST['id']) {

      $details = array($_REQUEST['id'], $_REQUEST['name']);
      $this->getView('edit', $details);

    } else $this->getView('addform');

    $this->getView('footer');
  }

  public function addItem() {

    $this->parent->getModel('fruits')->update(
      "INSERT into fruit_table (name) VALUES(:name)", 
      array(':name' => $_REQUEST['name'])
    );

    header('Location:/about');
  }

  public function delete() {

    $this->parent->getModel('fruits')->update(
      "DELETE from fruit_table WHERE id = :id", 
      array(':id' => $_REQUEST['id'])
    );

    header('Location:/about');
  }

  public function update() {

    $this->parent->getModel('fruits')->update(
      "UPDATE fruit_table SET name = :name WHERE id = :id", 
      array(':name' => $_REQUEST['name'], ':id' => $_REQUEST['id'])
    );

    header('Location:/about');
  }
}

?>