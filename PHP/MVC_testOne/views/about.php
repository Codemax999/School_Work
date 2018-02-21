<div class="container">
  <div class="starter-template">

    <!-- Title -->
    <h1>Fruits</h1>

    <!-- List of Fruits -->
    <?

    foreach ($data as $fruit) {

      echo "
        {$fruit['name']}
        <a href='/about?id={$fruit['id']}&name={$fruit['name']}'>edit</a> /
        <a href='/about/delete?id={$fruit['id']}'>delete</a>
        <br>
      ";
    }

    ?>
  </div>
</div>