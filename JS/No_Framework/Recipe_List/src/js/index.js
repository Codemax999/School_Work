$(function() {

  // --- Get Data  ---
  // load initial data
  $.get('https://api.myjson.com/bins/f4ayd', (data, status) => {

    // full data (localStorage + API)
    // add to all recipes
    // sort by recipeID
    let allRecipes = [];
    let savedItems = JSON.parse(localStorage.getItem('newRecipes'));
    if (savedItems) savedItems.map(x => { allRecipes.push(x); });
    if (status === 'success') data.recipes.map(x => { allRecipes.push(x); });
    allRecipes.sort((a, b) => b.recipeID - a.recipeID).map(x => displayData(x));

  }, 'json');
});


// --- Display Data ---
// append to recipe list
const displayData = data => {

  // update data for displaying
  data.photoUrl = data.photoUrl.replace('https://drive.google.com/open?id=', 'https://docs.google.com/uc?id=');

  // create li element with recipe card
  const li = document.createElement('li');
  li.id = `recipe-item-${data.recipeID}`;
  li.innerHTML = `
    <div class="recipe-card">
      <div class="recipe-card-top">
        <div>
          <h4>${data.title}</h4>
          <img src="dist/assets/icons/remove_circle.svg" class="remove-${data.recipeID}" id="${data.recipeID}">
        </div>
        <h6>${data.category}</h6>
      </div>
      <div class="recipe-card-media">
        <img src="${data.photoUrl}">
      </div>
      <div class="recipe-card-rating rating-card-${data.recipeID}"></div>
      <div class="recipe-card-description">${data.description}</div>
    </div>
  `;
  $('.recipe-list').append(li);
  $(`.remove-${data.recipeID}`).click(e => removeItem(e));

  // apply star rating
  for (let i = data.starRating; i > 0; i--) {
    const img = document.createElement('img');
    img.src = 'dist/assets/icons/star.svg';
    $(`.rating-card-${data.recipeID}`).append(img);
  }
}


// --- Toggle Recipe Form ---
// keep track of recipe toggle
let showNewRecipe = false;

// toggle in form listeners
$('.toggle-recipe-btn').click(() => toggleNewRecipe());
$('.toggle-recipe-lrg-btn').click(() => toggleNewRecipe());

// update styles and recipe toggle
const toggleNewRecipe = () => {

  // change styles
  if (showNewRecipe) {
    $('.recipe-form').css('display', 'none');
    $('.toggle-recipe-btn-hide').css('display', 'none');
    $('.toggle-recipe-btn-show').css('display', 'flex');
    $('.toggle-recipe-lrg-btn-label').html('New Recipe');
  } else {
    $('.recipe-form').css('display', 'flex');
    $('.toggle-recipe-btn-show').css('display', 'none');
    $('.toggle-recipe-btn-hide').css('display', 'flex');
    $('.toggle-recipe-lrg-btn-label').html('Hide Recipe');
  }

  // update show recipe bool
  showNewRecipe = !showNewRecipe;
}


// --- New Recipe Form ---
// get form data
const getFormData = () => document.forms.recipeForm;

// reset form 
const resetForm = () => {

  // form
  const form = getFormData();
  form.name.value = '';
  form.description.value = '';
  form.category.value = '';
}

// listeners
const title = $('#name');
title.keyup(() => validateForm());
title.blur(() => validateForm());

const description = $('#description');
description.keyup(() => validateForm());
description.blur(() => validateForm());

const category = $('#category');
category.keyup(() => validateForm());
category.blur(() => validateForm());

const rating = $('.star');
rating.click(e => updateStars(Number(e.target.id)));

// stars 
let starCount = 1;
const updateStars = ratingId => {

  // update counter
  starCount = ratingId;

  // update active stars
  if (ratingId >= 1 && ratingId <= 5) changeStar(1, 'none', 'flex');
  else changeStar(1, 'flex', 'none');

  if (ratingId >= 2 && ratingId <= 5) changeStar(2, 'none', 'flex');
  else changeStar(2, 'flex', 'none');

  if (ratingId >= 3 && ratingId <= 5) changeStar(3, 'none', 'flex');
  else changeStar(3, 'flex', 'none');

  if (ratingId >= 4 && ratingId <= 5) changeStar(4, 'none', 'flex');
  else changeStar(4, 'flex', 'none');

  if (ratingId === 5) changeStar(5, 'none', 'flex');
  else changeStar(5, 'flex', 'none');
}

// star change 
const changeStar = (id, displayOne, displayTwo) => {
  $(`.rating-${id}`).css('display', displayOne);
  $(`.rating-active-${id}`).css('display', displayTwo);
}

// validate form 
const validateForm = () => {

  // form
  const form = getFormData();

  // validate form
  let formCount = 0;
  formCount += form.name.validity.valid ? 0 : 1;
  formCount += form.name.value.trim().length !== 0 ? 0 : 1;
  formCount += form.description.validity.valid ? 0 : 1;
  formCount += form.description.value.trim().length !== 0 ? 0 : 1;
  formCount += form.category.validity.valid ? 0 : 1;
  formCount += form.category.value.trim().length !== 0 ? 0 : 1;

  // enable and disable submit button
  if (formCount === 0) document.querySelector('#submit').disabled = false;
  else document.querySelector('#submit').disabled = true;
}


// --- Items ---
// add new
$('#submit').click(e => {
  e.preventDefault();
  addNewRecipe();
});

// new item
const addNewRecipe = () => {

  // form
  const form = getFormData();

  // ul child count
  const idCount = $('.recipe-list').children().length + 1;

  // create li element with recipe card
  const li = document.createElement('li');
  li.id = `recipe-item-${idCount}`;
  li.innerHTML = `
    <div class="recipe-card">
      <div class="recipe-card-top">
        <div>
          <h4>${form.name.value}</h4>
          <img src="dist/assets/icons/remove_circle.svg" class="remove-${idCount}" id="${idCount}">
        </div>
        <h6>${form.category.value}</h6>
      </div>
      <div class="recipe-card-media">
        <img src="dist/assets/images/food.jpg">
      </div>
      <div class="recipe-card-rating rating-card-${idCount}"></div>
      <div class="recipe-card-description">${form.description.value}</div>
    </div>
  `;
  $('.recipe-list').prepend(li);
  $(`.remove-${idCount}`).click(e => removeItem(e));

  // apply star rating
  for (let i = starCount; i > 0; i--) {
    const img = document.createElement('img');
    img.src = 'dist/assets/icons/star.svg';
    $(`.rating-card-${idCount}`).append(img);
  }

  // update local storage
  const payload = {
    recipeID: idCount,
    title: form.name.value,
    category: form.category.value,
    photoUrl: 'dist/assets/images/food.jpg',
    starRating: starCount
  }
  addToLocalStorage(payload);

  // clear + validate form, reset stars
  resetForm();
  validateForm();
  updateStars(1);
}

// remove item and update local storage
const removeItem = item => {
  $(`#recipe-item-${item.target.id}`).remove();
  removeFromLocalStorage(Number(item.target.id));
}


// --- Save Data ---
// add
const addToLocalStorage = payload => {

  // get any data in local storage
  let storage = JSON.parse(localStorage.getItem('newRecipes'));

  if (storage) {

    // add new item to array and save new data
    storage.push(payload);
    storage.sort((a, b) => a.recipeID - b.recipeID);
    localStorage.setItem('newRecipes', JSON.stringify(storage));

  } else {

    // set initial data
    let savedRecipes = [payload];
    localStorage.setItem('newRecipes', JSON.stringify(savedRecipes));
  }
}

// remove
const removeFromLocalStorage = id => {

  // get any data in local storage
  let storage = JSON.parse(localStorage.getItem('newRecipes'));

  if (storage) {

    // remove item by recipeID
    let newStorage = storage.filter(x => x.recipeID !== id);
    localStorage.setItem('newRecipes', JSON.stringify(newStorage));
  }
}