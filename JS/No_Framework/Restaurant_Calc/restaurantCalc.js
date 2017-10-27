// --- MAIN SECTION ---

// --- PROMPTS ---

//capture meal one
const mealOne = prompt('Enter meal one cost');

//capture meal two
const mealTwo = prompt('Enter meal two cost');

//capture meal three
const mealThree = prompt('Enter meal three cost');

//display meal total
const mealTotalNoTip = Number(mealOne) + Number(mealTwo) + Number(mealThree);
console.log('The meal total without tip is: ', mealTotalNoTip);

//ask for percent tip 
const mealTip = prompt('Enter tip percent amount');


// --- CALCULATIONS ---

//calculate total with tip
const mealTipValue = Number(mealTip) * mealTotalNoTip / 100;

//add tip to total
const mealFullTotal = mealTotalNoTip + mealTipValue;

//calculate amount each guest owes
const eachGuest = mealFullTotal / 3;


// --- DISPLAY ---

//display to console
console.log('The meal total with tip is:', mealFullTotal, 'and each guest owes:', eachGuest);