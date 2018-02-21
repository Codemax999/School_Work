<?

class Users {

  public function __construct($parent) {

    $this->db = $parent->db;
  }

  public function select($sql, $value = array()) {

    $this->sql = $this->db->prepare($sql);
    $this->sql->execute($value);
    return $this->sql->fetchAll();
  }

  public function add($sql, $value = array()) {

    $this->sql = $this->db->prepare($sql);
    $this->sql->execute($value);
  }
}


?>