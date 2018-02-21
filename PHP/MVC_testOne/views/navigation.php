<!doctype html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">
  <title>Sticky Footer Navbar Template for Bootstrap</title>

  <!-- Bootstrap core CSS -->
  <link href="../assets/css/bootstrap.min.css" rel="stylesheet">
</head>
<body style="padding-top: 70px;">

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

    <!-- Navigation Links -->
    <div class="collapse navbar-collapse" id="navbarCollapse">
      <ul class="navbar-nav mr-auto">
        <li <?=@$data['pagename'] == 'Welcome' ? "class='active'": ''?>>
          <a class='nav-link' href='/main'>Welcome</a>
        </li>
        <li <?=@$data['pagename'] == 'about' ? "class='active'": ''?>>
          <a class='nav-link' href='/about'>About</a>
        </li>
        <li <?=@$data['pagename'] == 'Contact' ? "class='active'": ''?>>
          <a class='nav-link' href='/main/contact'>Contact</a>
        </li>
      </ul>

      <!-- Error Message -->
      <span style="color: red">
        <?=@$_REQUEST['msg'] ? $_REQUEST['msg'] : '';?>
      </span>

      <!-- Session Login / Logout -->
      <? if (@$_SESSION['loggedin'] && @$_SESSION['loggedin'] == 1) { ?>

        <form class="navbar-form navbar-right">
          <a href="/profile">Profile</a>
          <a href="/auth/logout">Logout</a>
        </form>

      <? } else { ?>

        <form class="navbar-form navbar-right form-inline"
          role="search"
          method="post"
          action="/auth/login">

          <div class="form-group">
            <input type="text" 
              class="form-control"
              name="email"
              placeholder="email">
          </div>

          <div class="form-group">
            <input type="text" 
              class="form-control"
              name="password"
              placeholder="password">
          </div>

          <button type="submit" class="btn btn-default">Login</button>
        </form>

      <? } ?>
    </div>
  </nav>
</header>
