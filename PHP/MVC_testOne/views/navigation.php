<header>

  <!-- Fixed navbar -->
  <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-dark">

    <a class="navbar-brand" href="#">LOGO</a>

    <button class="navbar-toggler" 
      type="button" 
      data-toggle="collapse" 
      data-target="#navbarCollapse" 
      aria-controls="navbarCollapse" 
      aria-expanded="false" 
      aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>

    <div class="collapse navbar-collapse" id="navbarCollapse">
      <ul class="navbar-nav mr-auto">

        <!-- Links -->
        <? 

          // current url
          $str = "http://127.0.0.1/{$_SERVER['REQUEST_URI']}";
          $urlPathParts = explode('/', ltrim(parse_url($str, PHP_URL_PATH), '/'));
          $sanitize = $urlPathParts[0] == '' ? 'Welcome' : $urlPathParts[0];

          // link items
          foreach ($data as $item) {

            if ($item == $sanitize) {

              // selected
              echo "
                <li class='nav-item active'>
                  <a class='nav-link' href=''>{$item}</a>
                </li>
              ";

            } else {

              // other
              echo "
                <li class='nav-item'>
                  <a class='nav-link' href=''>{$item}</a>
                </li>
              ";
            }
          } 
        ?>
      </ul>
      
      <form class="form-inline mt-2 mt-md-0">
        <input class="form-control mr-sm-2" type="text" placeholder="Search" aria-label="Search">
        <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
      </form>
    </div>
  </nav>
</header>
