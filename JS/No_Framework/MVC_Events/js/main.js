/*
  Cody Maxwell
  Design Patterns for Web Programming - Online
  Assignment 4 - MVC with Events
  11.11.2017

  Static Variable declared: 132
  Static Variable updated in method at: 94
*/

// --- Load Event ---
window.addEventListener('load', () => Assignment.getInstance());


// --- Singleton ---
class Assignment {

  constructor() {

    // create instance of program
    const newCtrl = new Controller();
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

    // attach event listeners and default name
    this.eventListeners();
    this.updateName('Restaurant');
  }

  // input listeners
  eventListeners() {

    // Controller
    const self = this;

    // validate form and update static property 
    document.querySelector('#form-name').addEventListener('keyup', event => {

      Utils.validateForm();
      self.updateName(event.target.value);
    });

    // form input listeners (service and food score)
    document.querySelector('#form-service').addEventListener('change', Utils.validateForm);
    document.querySelector('#form-food').addEventListener('change', Utils.validateForm);

    // submit form
    document.querySelector('#reviewForm').addEventListener('submit', event => {

      event.preventDefault();
      self.submitForm();
      self.updateName('Restaurant');
    });

    // custom event listener for returned processed data
    document.addEventListener('dataProcessed', self.toView);
  }

  // review name (update static variable and title)
  updateName(val) {

    Controller.reviewName = val.length > 0 ? val : 'Restaurant';
    document.querySelector('#reviewName').textContent = Controller.reviewName;
  }

  // submit form
  submitForm() {

    // form and form properties
    const reviewForm = document.forms.reviewForm;
    const placeName = reviewForm.reviewName.value.trim();
    const serviceScore = reviewForm.reviewService.value;
    const foodScore = reviewForm.reviewFood.value;

    // create Review data object
    let newReview = new Review(placeName, serviceScore, foodScore, 0);

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

// Static Variable: review name
Controller.reviewName;


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

// static variable: all created reviews
Model.allReviews = [];


// --- View ---
class View {

  constructor() {

    // attach event listener
    document.addEventListener('displayInfo', this.displayInfo);
  }

  // show data in table
  displayInfo(payload) {

    // loop through reviews
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
