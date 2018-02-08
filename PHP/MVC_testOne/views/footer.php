<footer class="footer">
  <div class="container">

    <!-- Modal -->
    <button type="button" 
      class="btn btn-primary" 
      id="modalBtn"
      data-toggle="modal" 
      data-target="#exampleModal">
      Launch demo modal
    </button>

    <!-- Popover -->
    <button type="button" 
      class="btn btn-lg btn-danger" 
      data-toggle="popover" 
      title="Popover title" 
      data-content="And here's some amazing content. It's very engaging. Right?">
        Click to toggle popover
    </button>
  </div>
</footer>

<!-- Modal -->
<div class="modal fade" 
  id="myModal" 
  tabindex="-1" 
  role="dialog" 
  aria-labelledby="exampleModalLabel" 
  aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>

<!-- JS -->
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script>window.jQuery || document.write('<script src="../assets/js/jquery.slim.min.js"><\/script>')</script>
<script src="../assets/js/popper.min.js"></script>
<script>
  $(document).ready(() => {  

    // Modal show & Hide
    $('#modalBtn').click(() => $('#myModal').modal('show'))

    //
    $('[data-toggle="popover"]').popover()
  });
</script>