// --- MAIN SECTION ---


// --- PROBLEM 1 ---

//display problem one
console.log('--- PROBLEM 1 ---');

//hardcode email
let userEmail = 'CEMaxwell@fullsail.edu';

//print out if email is valid or not
console.log('The provided email is', emailValidator(userEmail));


// --- PROBLEM 2 ---

//display problem two
console.log('--- PROBLEM 2 ---');

//hardcode string to be separated
let listOfLetters = 'a,b,c,d';

//pass string and seperators to swapOut function
let swapped = swapOut(listOfLetters);

//display new string and list seperator 
console.log(swapped);


// --- FUNCTIONS ---

//email validator function
function emailValidator(email) 
{
  //remove any whitespaces
  email.trim();

  //ivalid if there is a space or missing @ symbol
  if (email.indexOf(' ') >= 0 || email.indexOf('@') === -1)
  {
    //invalid
    return 'not valid.';
  }
  else 
  {
    //variable for @ index
    let atIndex = email.indexOf('@');

    //Verify for . after @ symbol
    if (email.indexOf('.', atIndex) === -1) 
    {
      //invalid
      return 'not valid.' 
    }
    else 
    { 
      //valid
      return 'valid.'; 
    }
  }
}

//divider swap function
function swapOut(list) { return list.replace(/,/g, '/'); }
