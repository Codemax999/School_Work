// --- MAIN SECTION ---

// --- TWO ARRAYS ---

//hardcode two arrays of numbers
const firstArray = [4,20,60,150];
const secondArray = [5,40.5,65.4,145.98];

//array totals
const arrayTotalOne = firstArray[0] + firstArray[1] + firstArray[2] + firstArray[3];
const arrayTotalTwo = secondArray[0] + secondArray[1] + secondArray[2] + secondArray[3];

//display array one total
console.log('The total for array one is:', arrayTotalOne);

//display array two total
console.log('The total for array two is:', arrayTotalTwo);

//array averages
const arrayAverageOne = arrayTotalOne / 4;
const arrayAverageTwo = arrayTotalTwo / 4;

//display the average for array one
console.log('The average for array one is:', arrayAverageOne);

//display the average for array two
console.log('The average for array two is:', arrayAverageTwo);


// --- SINGLE ARRAY ---

//combine first two arrays at index for new array 
const thirdArray = [firstArray[0] + secondArray[0], firstArray[1] + secondArray[1], firstArray[2] + secondArray[2], firstArray[3] + secondArray[3]];

//display new array
console.log('The new thir array is: ', thirdArray[0], ',', thirdArray[1], ',', thirdArray[2], ',', thirdArray[3]);


// --- ORGANIZE SENTENCE ---

//array of mixed terms
const wordsArray = ['but the lighting of a', 'Education is not', 'fire.', 'the filling', 'of a bucket,'];

//combine and display correctly
console.log(wordsArray[1], wordsArray[3], wordsArray[4], wordsArray[0], wordsArray[2]);