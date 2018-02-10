<main role="main" class="container">

  <!-- Basic Form -->
  <h1 style="padding-top: 50px;">Basic Form</h1>
  <form class="col-md-10" action="/main/contactRecv" method="POST">
    <div class="form-row">

      <!-- Input -->
      <div class="form-group col-md-6">
        <label for="exampleFormControlInput1">Email address</label>
        <input type="email" 
          name="email"
          class="form-control" 
          id="exampleFormControlInput1" 
          placeholder="name@example.com">
      </div>

      <!-- Select Box -->
      <div class="form-group col-md-6">
        <label for="exampleFormControlSelect1">Example select</label>
        <select class="form-control" id="exampleFormControlSelect1">
          <option>1</option>
          <option>2</option>
          <option>3</option>
          <option>4</option>
          <option>5</option>
        </select>
      </div>
    </div>

    <!-- Text Area -->
    <div class="form-group">
      <label for="exampleFormControlTextarea1">Example textarea</label>
      <textarea class="form-control" 
        name="description"
        id="exampleFormControlTextarea1" 
        rows="3"></textarea>
    </div>

    <div class="form-row">

      <!-- Radio -->
      <div class="form-group col-md-3">

        <div class="form-check">
          <input class="form-check-input" 
            type="radio" 
            name="exampleRadios" 
            id="exampleRadios1" 
            value="option1" 
            checked>
          <label class="form-check-label" for="exampleRadios1">
            Default
          </label>
        </div>

        <div class="form-check">
          <input class="form-check-input" 
            type="radio" 
            name="exampleRadios" 
            id="exampleRadios2" 
            value="option2">
          <label class="form-check-label" for="exampleRadios2">
            Second
          </label>
        </div>
        
        <div class="form-check disabled">
          <input class="form-check-input" 
            type="radio" 
            name="exampleRadios" 
            id="exampleRadios3" 
            value="option3">
          <label class="form-check-label" for="exampleRadios3">
            Third
          </label>
        </div>
      </div>

      <!-- Check Box -->
      <div class="form-check col-md-3">
        <input class="form-check-input" type="checkbox" value="" id="defaultCheck1">
        <label class="form-check-label" for="defaultCheck1">
          Default checkbox
        </label>
      </div>

      <!-- Submit -->
      <div class="col-md-3">
        <button type="submit" class="btn btn-primary">Submit form</button>
      </div>
    </div>
  </form>


  <!-- Login -->
  <h1 style="padding-top: 50px;">Login Form</h1>
  <form class="form-inline">
    <div class="form-group mb-2">
      <label for="staticEmail2" class="sr-only">Email</label>
      <input type="text"
        class="form-control-plaintext" 
        id="staticEmail2" 
        value="test@email.com"
        readonly>
    </div>
    <div class="form-group mx-sm-3 mb-2">
      <label for="password" class="sr-only">Password</label>
      <input type="password" 
        class="form-control" 
        id="password" 
        placeholder="Password"
        required>
    </div>
    <input type="button" 
      id="ajaxButton"
      class="btn btn-primary mb-2" 
      value="Login">
  </form>
</main>


<!-- JS -->
<script src="../assets/js/jquery.min.js"></script>
<script>
  $(document).ready(() => {  

    $('#ajaxButton').click(() => {

      $.ajax({
        method: 'POST',
        url: '/main/ajaxPars',
        data: { password: $('#password').val() },
        success: msg => {

          console.log(msg)
          if (msg.includes('Welcome')) alert('Welcome')
          else alert('Wrong')
        } 
      })
    })
  });
</script>