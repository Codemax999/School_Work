<div class="container">
  <div class="starter-template">

    <!-- Current Location -->
    <div style="display: flex; align-items: center;">
      <h3>Current Location: </h3>
      <? echo "{$data[0]}" ?>
    </div>

    <!-- Nearby Current Location -->
    <h3>Nearby Places</h3>
    <? foreach ($data[1] as $place) echo "{$place['name']}<br>"; ?>
  </div>
</div>