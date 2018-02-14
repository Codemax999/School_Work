<main role="main" class="container">

  <!-- Captcha Form -->
  <h1 style="padding-top: 50px;">Captcha Form</h1>

  <?

  function create_image($cap) {

    unlink("./assets/image1.png");

    global $image;
    $image = imagecreatetruecolor(200, 50) or die("Cannot Initialize new GD image stream");
    $background_color = imagecolorallocate($image, 255, 255, 255);
    $text_color = imagecolorallocate($image, 0, 255, 255);
    $line_color = imagecolorallocate($image, 64, 64, 64);
    $pixel_color = imagecolorallocate($image, 0, 0, 255);
    imagefilledrectangle($image, 0, 0, 200, 50, $background_color);

    for ($i = 0; $i < 3; $i++) {

      imageline($image, 0, rand() % 50, 200, rand() % 50, $line_color);
    }

    for ($i = 0; $i < 1000; $i++) {

      imagesetpixel($image, rand() % 200, rand() % 50, $pixel_color);
    }

    $text_color = imagecolorallocate($image, 0, 0, 0);
    ImageString($image, 22, 30, 22, $cap, $text_color);
    $_SESSION['testCaptcha'] = $cap;
    imagepng($image, "./assets/image1.png");
  }

  create_image($data["cap"]);
  echo "<img src='../assets/image1.png'>";

  ?>

  <!-- Login -->
  <form class="navbar-form navbar-right form-inline"
    role="search"
    method="post"
    action="/main/contactRecv">

    <div class="form-group">
      <label for="exampleInputEmail1">Enter Captcha</label>
      <input class="form-control" 
        name="captcha" 
        type="captcha" 
        id="captcha">
    </div>

    <div class="form-group">
      <input type="text" 
        class="form-control"
        name="email"
        placeholder="email">
    </div>

    <button type="submit" class="btn btn-default">Login</button>
  </form>
</main>
