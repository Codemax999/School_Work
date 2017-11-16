// --- On Load --- 
window.addEventListener('load', () => Controller.getInstance());


// --- Data Object ---
class Movie {

  constructor(movieTitle, movieDuration, movieRating) {

    this.movieTitle = movieTitle;
    this.movieDuration = movieDuration;
    this.movieRating = movieRating;
  }
}


// --- Controller / Singleton ---
class Controller {

  constructor() {

    // Model and View
    const model = new Model();
    const view = new View();

    // listen for next index
    document.querySelector('.btn').addEventListener('click', this.loadData);

    // load initial data
    this.loadData();
  }

  static getInstance() {

    // create singleton
    if (!Controller._instance) {

      Controller._instance = new Controller();
      return Controller._instance;

    } else console.error('Already instantiated');
  }

  loadData() {

    // process in model
    const processData = new CustomEvent('processData', { 'detail': data });
    document.dispatchEvent(processData);
  }
}


// --- Model (ES5) ---
const Model = (function () {

  function Model() {

    // current movie index
    this.filmIndex = 0;

    // attach event listener
    document.addEventListener('processData', event => this.processData(event)); 
  }

  Model.prototype.processData = function(moviePayload) {

    // create data object 
    const movie = moviePayload.detail.movies[this.filmIndex];
    const newDuration = Utils.calcDuration(movie.duration);
    const payload = new Movie(movie.title, newDuration, movie.rating);

    // dispatch data to be displayed
    const displayData = new CustomEvent('displayData', { 'detail': payload });
    document.dispatchEvent(displayData);

    // update index
    if (this.filmIndex === 2) this.filmIndex = 0;
    else this.filmIndex++;
  }

  return Model;
})();


// --- View ---
class View {

  constructor() {

    // attach event listener
    document.addEventListener('displayData', this.displayData); 
  }

  displayData(payload) {

    // current film
    const film = payload.detail;

    // determine image
    let cardImg;
    cardImg = film.movieTitle === 'Star Wars' ? 'assets/starWars.jpg' : cardImg;
    cardImg = film.movieTitle === 'Matrix' ? 'assets/matrix.jpg' : cardImg;
    cardImg = film.movieTitle === 'Aliens' ? 'assets/aliens.jpg' : cardImg;

    // create card
    const currentFilm = document.querySelector('.currentFilm');
    currentFilm.innerHTML = 
      `
      <div class="card">
        <div class="card-image">
          <img src="${cardImg}" class="img-responsive">
        </div>
        <div class="card-header">
          <div class="card-title h5">
            ${film.movieTitle} (${film.movieRating})
          </div>
          <div class="card-subtitle text-gray">${film.movieDuration}</div>
        </div>
      </div>
    `
  }
}


// --- Utility ---
class Utils {

  // convert minutes to hours
  static calcDuration(minutes) {

    // get hour, min and if needed a start 0
    let hour = Math.floor(minutes / 60);
    let min = minutes % 60;
    min = min.toString().length === 1 ? `0${min}` : min;

    return `${hour}:${min}`;
  }
}
