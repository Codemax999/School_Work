<!-- Body -->
<body style="margin: 0; font-family: monospace;">

<!-- Header -->
<header 
  style="
  align-items: center;
  background: #f9f9f9;
  box-shadow: 0 3px 6px rgba(0,0,0,0.16), 0 3px 6px rgba(0,0,0,0.23);
  display: flex;
  height: 70px;
  justify-content: space-between;
  padding: 0 25px;">


<!-- Logo -->
<h2>Header Logo</h2>


<!-- Links -->
<section
  style="
    display: flex;
    justify-content: space-around;
    width: 30%;">

<? 
  
  foreach ($data as $item) {

    echo "
      <a href=''
        style='color: #808080;'>
        {$item}
      </a>
    ";
  } 

?>

</section>
</header>
</body>

