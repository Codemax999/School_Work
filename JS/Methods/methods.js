// --- MAIN SECTION ---

// --- PROMPTS ---

//problem one: Circumference
console.log('--- PROBLEM 1 ---');

//get radius of circle
const radius = prompt('What is the radius of the circle?');

//display calculated circumference
console.log('The circumference of the circle is:', calcCirc(radius));

//problem two: Stings to kill
console.log('--- PROBLEM 2 ---');

//get animal weight
const animal = prompt('How much does the animal weigh?');

//display calculated stings to kill
console.log('It takes', calcSting(animal), 'stings to kill this animal');

//problem three: Reverse array
console.log('--- PROBLEM 3 ---');

//original array
const arrayInit = [0,1,2,3,4];

//display initial
console.log('Your original array was', arrayInit[0], arrayInit[1], arrayInit[2], arrayInit[3], arrayInit[4]);

//pass array to be reversed
const reversed = reverseArray(arrayInit);

//display new array
console.log('Now your array is', reversed[0], reversed[1], reversed[2], reversed[3], reversed[4]);


// --- FUNCTIONS ---

//calculate circumference
function calcCirc(radius)
{
  return 2 * Math.PI * radius;
}

//calculate stings
function calcSting(animal)
{
  //stings required to kill per pound
  const stingsPerPound = 8.666666667;

  //return calculation
  return Number(animal) * stingsPerPound;
}

//reverse array
function reverseArray(array)
{
  return array.reverse();
}