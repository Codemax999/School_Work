/*
  Cody Maxwell
  Design Patterns for Web Programming - Online
  Assignment 4 - MVC with Events
  11.9.2017
*/

// --- Load Event ---
window.addEventListener('load', () => Assignment.getInstance());


// --- Singleton ---
class Assignment {

  // create instance of program
  constructor() {
    let newCtrl = new Controller();
  }

  // static method for singleton 
  static getInstance() {

    if (!Assignment._instance) {

      Assignment._instance = new Assignment();
      return Assignment._instance;

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

      //
      // DISPATCH EVENT TO MODEL
      //
      // process in model
      this.model.process(newReview)
        .then(res => {

          // add to reviews and sort
          allReviews.push(res);
          allReviews.sort((a, b) => b.numScore - a.numScore);

          // clear previous and apply new results
          Utils.showTable();
          Utils.clearTable();

          //
          // DISPATCH EVENT TO VIEW
          //
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
      data.totalScore = Utils.addStar(data.numScore);
      data.serviceScore = Utils.addStar(data.serviceScore);
      data.foodScore = Utils.addStar(data.foodScore);
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
