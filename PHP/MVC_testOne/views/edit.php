<div class="container">
  <div class="starter-template">

    <!-- Selected Fruit to Update -->
    <? 

      echo"
        <h3>Edit '{$data[1]}'</h3>
        <form action='/about/update?id={$data[0]}>' method='POST'>
          <input type='text' name='name' placeholder='New name'/>
          <input type='submit'/>
        </form>
      "; 

    ?>

  </div>
</div>