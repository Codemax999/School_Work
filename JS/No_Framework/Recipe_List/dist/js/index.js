'use strict';

$(function () {

  // --- Get Data  ---
  // load initial data
  $.get('https://api.myjson.com/bins/f4ayd', function (data, status) {

    // full data (localStorage + API)
    // add to all recipes
    // sort by recipeID
    var allRecipes = [];
    var savedItems = JSON.parse(localStorage.getItem('newRecipes'));
    if (savedItems) savedItems.map(function (x) {
      allRecipes.push(x);
    });
    if (status === 'success') data.recipes.map(function (x) {
      allRecipes.push(x);
    });
    allRecipes.sort(function (a, b) {
      return b.recipeID - a.recipeID;
    }).map(function (x) {
      return displayData(x);
    });
  }, 'json');
});

// --- Display Data ---
// append to recipe list
var displayData = function displayData(data) {

  // update data for displaying
  data.photoUrl = data.photoUrl.replace('https://drive.google.com/open?id=', 'https://docs.google.com/uc?id=');

  // create li element with recipe card
  var li = document.createElement('li');
  li.id = 'recipe-item-' + data.recipeID;
  li.innerHTML = '\n    <div class="recipe-card">\n      <div class="recipe-card-top">\n        <div>\n          <h4>' + data.title + '</h4>\n          <img src="dist/assets/icons/remove_circle.svg" class="remove-' + data.recipeID + '" id="' + data.recipeID + '">\n        </div>\n        <h6>' + data.category + '</h6>\n      </div>\n      <div class="recipe-card-media">\n        <img src="' + data.photoUrl + '">\n      </div>\n      <div class="recipe-card-rating rating-card-' + data.recipeID + '"></div>\n      <div class="recipe-card-description">' + data.description + '</div>\n    </div>\n  ';
  $('.recipe-list').append(li);
  $('.remove-' + data.recipeID).click(function (e) {
    return removeItem(e);
  });

  // apply star rating
  for (var i = data.starRating; i > 0; i--) {
    var img = document.createElement('img');
    img.src = 'dist/assets/icons/star.svg';
    $('.rating-card-' + data.recipeID).append(img);
  }
};

// --- Toggle Recipe Form ---
// keep track of recipe toggle
var showNewRecipe = false;

// toggle in form listeners
$('.toggle-recipe-btn').click(function () {
  return toggleNewRecipe();
});
$('.toggle-recipe-lrg-btn').click(function () {
  return toggleNewRecipe();
});

// update styles and recipe toggle
var toggleNewRecipe = function toggleNewRecipe() {

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
};

// --- New Recipe Form ---
// get form data
var getFormData = function getFormData() {
  return document.forms.recipeForm;
};

// reset form 
var resetForm = function resetForm() {

  // form
  var form = getFormData();
  form.name.value = '';
  form.description.value = '';
  form.category.value = '';
};

// listeners
var title = $('#name');
title.keyup(function () {
  return validateForm();
});
title.blur(function () {
  return validateForm();
});

var description = $('#description');
description.keyup(function () {
  return validateForm();
});
description.blur(function () {
  return validateForm();
});

var category = $('#category');
category.keyup(function () {
  return validateForm();
});
category.blur(function () {
  return validateForm();
});

var rating = $('.star');
rating.click(function (e) {
  return updateStars(Number(e.target.id));
});

// stars 
var starCount = 1;
var updateStars = function updateStars(ratingId) {

  // update counter
  starCount = ratingId;

  // update active stars
  if (ratingId >= 1 && ratingId <= 5) changeStar(1, 'none', 'flex');else changeStar(1, 'flex', 'none');

  if (ratingId >= 2 && ratingId <= 5) changeStar(2, 'none', 'flex');else changeStar(2, 'flex', 'none');

  if (ratingId >= 3 && ratingId <= 5) changeStar(3, 'none', 'flex');else changeStar(3, 'flex', 'none');

  if (ratingId >= 4 && ratingId <= 5) changeStar(4, 'none', 'flex');else changeStar(4, 'flex', 'none');

  if (ratingId === 5) changeStar(5, 'none', 'flex');else changeStar(5, 'flex', 'none');
};

// star change 
var changeStar = function changeStar(id, displayOne, displayTwo) {
  $('.rating-' + id).css('display', displayOne);
  $('.rating-active-' + id).css('display', displayTwo);
};

// validate form 
var validateForm = function validateForm() {

  // form
  var form = getFormData();

  // validate form
  var formCount = 0;
  formCount += form.name.validity.valid ? 0 : 1;
  formCount += form.name.value.trim().length !== 0 ? 0 : 1;
  formCount += form.description.validity.valid ? 0 : 1;
  formCount += form.description.value.trim().length !== 0 ? 0 : 1;
  formCount += form.category.validity.valid ? 0 : 1;
  formCount += form.category.value.trim().length !== 0 ? 0 : 1;

  // enable and disable submit button
  if (formCount === 0) document.querySelector('#submit').disabled = false;else document.querySelector('#submit').disabled = true;
};

// --- Items ---
// add new
$('#submit').click(function (e) {
  e.preventDefault();
  addNewRecipe();
});

// new item
var addNewRecipe = function addNewRecipe() {

  // form
  var form = getFormData();

  // ul child count
  var idCount = $('.recipe-list').children().length + 1;

  // create li element with recipe card
  var li = document.createElement('li');
  li.id = 'recipe-item-' + idCount;
  li.innerHTML = '\n    <div class="recipe-card">\n      <div class="recipe-card-top">\n        <div>\n          <h4>' + form.name.value + '</h4>\n          <img src="dist/assets/icons/remove_circle.svg" class="remove-' + idCount + '" id="' + idCount + '">\n        </div>\n        <h6>' + form.category.value + '</h6>\n      </div>\n      <div class="recipe-card-media">\n        <img src="dist/assets/images/food.jpg">\n      </div>\n      <div class="recipe-card-rating rating-card-' + idCount + '"></div>\n      <div class="recipe-card-description">' + form.description.value + '</div>\n    </div>\n  ';
  $('.recipe-list').prepend(li);
  $('.remove-' + idCount).click(function (e) {
    return removeItem(e);
  });

  // apply star rating
  for (var i = starCount; i > 0; i--) {
    var img = document.createElement('img');
    img.src = 'dist/assets/icons/star.svg';
    $('.rating-card-' + idCount).append(img);
  }

  // update local storage
  var payload = {
    recipeID: idCount,
    title: form.name.value,
    category: form.category.value,
    photoUrl: 'dist/assets/images/food.jpg',
    starRating: starCount
  };
  addToLocalStorage(payload);

  // clear + validate form, reset stars
  resetForm();
  validateForm();
  updateStars(1);
};

// remove item and update local storage
var removeItem = function removeItem(item) {
  $('#recipe-item-' + item.target.id).remove();
  removeFromLocalStorage(Number(item.target.id));
};

// --- Save Data ---
// add
var addToLocalStorage = function addToLocalStorage(payload) {

  // get any data in local storage
  var storage = JSON.parse(localStorage.getItem('newRecipes'));

  if (storage) {

    // add new item to array and save new data
    storage.push(payload);
    storage.sort(function (a, b) {
      return a.recipeID - b.recipeID;
    });
    localStorage.setItem('newRecipes', JSON.stringify(storage));
  } else {

    // set initial data
    var savedRecipes = [payload];
    localStorage.setItem('newRecipes', JSON.stringify(savedRecipes));
  }
};

// remove
var removeFromLocalStorage = function removeFromLocalStorage(id) {

  // get any data in local storage
  var storage = JSON.parse(localStorage.getItem('newRecipes'));

  if (storage) {

    // remove item by recipeID
    var newStorage = storage.filter(function (x) {
      return x.recipeID !== id;
    });
    localStorage.setItem('newRecipes', JSON.stringify(newStorage));
  }
};