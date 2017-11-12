/*
  Cody Maxwell
  Design Patterns for Web Programming - Online
  Assignment 4 - MVC with Events
  11.11.2017

  Static Variable on line: 145
*/

// --- Load Event ---
window.addEventListener('load', () => Assignment.getInstance());


// --- Singleton ---
class Assignment {

  constructor() {

    // create instance of program
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

    // model and view instantiation
    const model = new Model();
    const view = new View();

    // attach event listeners
    this.eventListeners();
  }

  // input listeners
  eventListeners() {

    // Controller
    const self = this;

    // form input listeners
    document.querySelector('#form-name').addEventListener('keyup', Utils.validateForm);
    document.querySelector('#form-service').addEventListener('change', Utils.validateForm);
    document.querySelector('#form-food').addEventListener('change', Utils.validateForm);

    // submit form
    document.querySelector('#reviewForm').addEventListener('submit', event => {
      event.preventDefault();
      self.submitForm();
    });

    // custom event listener for returned processed data
    document.addEventListener('dataProcessed', self.toView);
  }

  // submit form
  submitForm() {

    // form and form properties
    const reviewForm = document.forms.reviewForm;
    const placeName = reviewForm.reviewName.value.trim();
    const serviceScore = reviewForm.reviewService.value;
    const foodScore = reviewForm.reviewFood.value;

    // create Review data object
    const newReview = new Review(placeName, serviceScore, foodScore, 0);

    // process in model
    const processData = new CustomEvent('processData', { 'detail': newReview });
    document.dispatchEvent(processData);
  }

  // pass data to model
  toView(payload) {

    // clear previous, apply new results and reset form
    Utils.showTable();
    Utils.clearTable();
    Utils.resetForm();

    // dispatch event to View to display
    const displayInfo = new CustomEvent('displayInfo', { 'detail': payload.detail });
    document.dispatchEvent(displayInfo);
  }
}


// --- Model ---
class Model {

  constructor() {

    // attach event listener
    document.addEventListener('processData', this.process);
  }

  // use Utility to get total and sort data
  process(payload) {

    // new review: calculate total score 
    let data = payload.detail;
    data.numScore = Utils.calcTotal(data.serviceScore, data.foodScore);
    data.totalScore = Utils.addStar(data.numScore);
    data.serviceScore = Utils.addStar(data.serviceScore);
    data.foodScore = Utils.addStar(data.foodScore);

    // new review: add to allReviews and sort
    Model.allReviews.push(data);
    Model.allReviews = Utils.sortData(Model.allReviews);

    // dispatch data back to controller 
    const dataProcessed = new CustomEvent('dataProcessed', { 'detail': Model.allReviews });
    document.dispatchEvent(dataProcessed);
  }
}

// --- Static Variable ---
// Holds all created reviews
Model.allReviews = [];


// --- View ---
class View {

  constructor() {

    // attach event listener
    document.addEventListener('displayInfo', this.displayInfo);
  }

  // show data in table
  displayInfo(payload) {

    const data = payload.detail;
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
