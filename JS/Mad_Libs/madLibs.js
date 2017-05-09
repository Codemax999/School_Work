// --- MAIN SECTION ---

// --- PROMPTS ---

//prompt user for pet
const animal = prompt('Enter an animal');

//prompt user place
const place = prompt('Enter a type of place');

//prompt user for celebrity
const celebrity = prompt('Enter a celebrity');

//prompt user for facial expression
const expression = prompt('Enter a facial expression');

//prompt user for days 
const days = prompt('Enter a random amount of days');

//prompt user for fans
const fans = prompt('Enter the number of fans your celebrity runs into');

//prompt user for cost
const cost = prompt('Enter a random amount of money');


// --- ARRAYS ---

//words and numbers array
const wordsArray = [animal, place, celebrity, expression];
const numbersArray = [days, fans, cost];


// --- DISPLAY

//console log to user
console.log("For the past " + numbersArray[0] + " days I have taken my pet " + 
            wordsArray[0] + " to the " + wordsArray[1] + "." + 
            " Each time I go, at least " + numbersArray[1] + 
            " people mistake him for " + wordsArray[2] + 
            " and ask for an autograph." + " I just " + wordsArray[3] + 
            " and say, " + numbersArray[2] + " dollars.");