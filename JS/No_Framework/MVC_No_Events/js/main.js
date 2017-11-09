/*
  Cody Maxwell
  Design Patterns for Web Programming - Online
  Assignment 3 - JavaScript MVC
  11.9.2017
*/

// --- Load Event ---
window.addEventListener('load', () => Maxwell_DPW.getInstance());


// --- Singleton ---
class Maxwell_DPW {

  // create instance of program
  constructor() {
    let newCtrl = new Controller();
  }

  // static method for singleton 
  static getInstance() {

    if (!Maxwell_DPW._instance) {

      Maxwell_DPW._instance = new Maxwell_DPW();
      return Maxwell_DPW._instance;

    } else console.error('Already instantiated');
  }
}


// --- Data Object ---
class Review {

  constructor(placeName, serviceScore, foodScore, totalScore) {
    this.placeName = placeName;
    this.serviceScore = serviceScore;
    this.foodScore = foodScore;
    this.totalScore = totalScore;
  }
}


// --- Controller ---
class Controller {

  constructor() {

    // model and view
    this.model = new Model();
    this.view = new View();

    // set form listeners
    this.inputListeners();
    this.submitForm();
  }

  // input listeners
  inputListeners() {
    document.querySelector('#form-name').addEventListener('keyup', Utils.validateForm);
    document.querySelector('#form-service').addEventListener('change', Utils.validateForm);
    document.querySelector('#form-food').addEventListener('change', Utils.validateForm);
  }

  // submit form
  submitForm() {

    // created reviews
    let allReviews = [];

    // submit listener
    document.querySelector('#reviewForm').addEventListener('submit', event => {

      // prevent page reload
      event.preventDefault();

      // form and form properties
      const reviewForm = document.forms.reviewForm;
      const placeName = reviewForm.reviewName.value.trim();
      const serviceScore = reviewForm.reviewService.value;
      const foodScore = reviewForm.reviewFood.value;

      // create Review data object
      const newReview = new Review(placeName, serviceScore, foodScore, 0);

      // process in model
      this.model.process(newReview)
        .then(res => {

          // add to reviews and sort
          allReviews.push(res);
          allReviews.sort((a, b) => b.numScore - a.numScore);

          // clear previous and apply new results
          Utils.showTable();
          Utils.clearTable();
          this.view.displayInfo(allReviews);
        })
        .then(Utils.resetForm);
    });
  }
}


// --- Model ---
class Model {

  constructor() {
    console.log('model created');
  }

  // use Utility to get total and update data
  process(data) {
    return new Promise(resolve => {
      data.numScore = Utils.calcTotal(data.serviceScore, data.foodScore);
      data.totalScore = data.numScore + ' Star';
      data.serviceScore = data.serviceScore + ' Star';
      data.foodScore = data.foodScore + ' Star';
      resolve(data);
    });
  }
}


// --- View ---
class View {

  constructor() {
    console.log('view created');
  }

  // show data in table
  displayInfo(data) {
    
    for (let x in data) {

      // create table row
      let tr = document.createElement('tr');
      tr.id = `row-${x}`;
      tr.innerHTML =
        `
          <td>${data[x].placeName}</td>
          <td>${data[x].serviceScore}</td>
          <td>${data[x].foodScore}</td>
          <td>${data[x].totalScore}</td>
        `;
      document.querySelector('tBody').appendChild(tr);
    }
  }
}


// --- Utitility ---
class Utils {

  // get total rating
  static calcTotal(service, food) {
    return (Number(service) + Number(food)) / 2;
  }

  // validate form
  static validateForm() {

    // form 
    const reviewForm = document.forms.reviewForm;
    
    // valid count
    let validCount = 0;
    validCount += reviewForm.reviewName.validity.valid ? 0 : 1;
    validCount += reviewForm.reviewName.value.trim().length !== 0 ? 0 : 1;
    validCount += reviewForm.reviewService.validity.valid ? 0 : 1;
    validCount += reviewForm.reviewService.value !== 'Choose a rating' ? 0 : 1;
    validCount += reviewForm.reviewFood.validity.valid ? 0 : 1;
    validCount += reviewForm.reviewFood.value !== 'Choose a rating' ? 0 : 1;

    // toggle submit button disabled
    const submitBtn = document.querySelector('.submit');
    if (validCount === 0) submitBtn.disabled = false;
    else submitBtn.disabled = true;
  }

  // reset form and submit button 
  static resetForm() {
    document.forms.reviewForm.reset();
    document.querySelector('.submit').disabled = true;
  }

  // show table
  static showTable() {
    document.querySelector('.empty').classList.add('hidden');
    document.querySelector('.table').classList.remove('hidden');
  }

  // clear table
  static clearTable() {
    document.querySelector('tBody').innerHTML = '';
  }
}