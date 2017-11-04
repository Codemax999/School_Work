// Cody Maxwell
// Full Sail University
// Design Patterns for Web Programming
// Assignment 2 - Prototype Design Pattern (JS - ES5)
// 11.03.2017
// line with static property: assigned at 45
// line with composition: defined at 195 and used at 290 & 291


// --- On Load ---
// instantiate singleton
window.addEventListener('load', () => AssignPrototype.getInstance());


// --- Singleton ---
class AssignPrototype {

  // create new instance of program
  constructor() {
    let startProgram = new MainProgram();
  }

  // check if instance is already created
  static getInstance() {

    if (!AssignPrototype._instance) {

      AssignPrototype._instance = new AssignPrototype();
      return AssignPrototype._instance;

    } else console.error('Already instantiated');
  }
}


// --- Main Assignment ---
// main program logic
let MainProgram = (function() {

  // player type
  let gameName, playerType;

  function MainProgram() {

    // set game name and default player type 
    gameName = 'GoldenScript';
    playerType = 'spy';

    // display game name
    this.setGameName();

    // set input listeners
    this.selectCharacter();
    this.inputListeners();
    this.submitForm();
  }

  // display game name on header
  MainProgram.prototype.setGameName = function() {
    document.querySelector('#gameName').textContent = gameName;
  }

  // select character (updated in Utility Class)
  MainProgram.prototype.selectCharacter = function() {

    // spy
    document.querySelector('#charTypeSpy').addEventListener('click', () => {
      playerType = 'spy';
      Utils.setSelectedPlayer(playerType);
    });

    // programmer
    document.querySelector('#charTypeProgrammer').addEventListener('click', () => {
      playerType = 'programmer';
      Utils.setSelectedPlayer(playerType);
    });
  }

  // input event listeners (name, weapon, game 1, 2 and 3)
  MainProgram.prototype.inputListeners = function() {
    document.querySelector('#charName').addEventListener('keyup', Utils.validateForm);
    document.querySelector('#charWeapon').addEventListener('keyup', Utils.validateForm);
    document.querySelector('#charGameOne').addEventListener('keyup', Utils.validateForm);
    document.querySelector('#charGameTwo').addEventListener('keyup', Utils.validateForm);
    document.querySelector('#charGameThree').addEventListener('keyup', Utils.validateForm);
  }

  // submit form 
  MainProgram.prototype.submitForm = function() {

    // array of created players
    let createdPlayers = [];

    // submit listener
    document.querySelector('#charForm').addEventListener('submit', event => {

      // prevent reload
      event.preventDefault();

      // create new character (updated in Utility Class)
      Utils.createCharacter(playerType)
        .then(res => Utils.calcAvg(res))
        .then(res => {

          // add new player and sort by score
          createdPlayers.push(res);
          createdPlayers.sort((a, b) => b.charAvg - a.charAvg);

          // remove previous scores and update with new
          document.querySelector('tBody').innerHTML = '';
          return Utils.displayInfo(createdPlayers);
        })
        .then(() => Utils.resetForm());
    });
  }

  return MainProgram;
})();


// --- Constructor Objects ---
// Constructor Object (abstract/super) Character
let Character = (function() {

  function Character(charName, charType, charWeapon, charScores) {
    this.charName = charName;
    this.charType = charType;
    this.charWeapon = charWeapon;
    this.charScores = charScores;
  }

  // display user's weapon
  Character.prototype.userWeapon = function() { 
    return `Player ${this.charName} weapon: ${this.charWeapon.make}`;
  }

  // display user's scres
  Character.prototype.userScores = function() {
    return `Player ${this.charName} weapon: ${this.charScores}`;
  } 

  // display type of user
  Character.prototype.userType = function() {
    return `Player ${this.charName} is a ${this.charType}`;
  }

  // display full data 
  Character.prototype.userFullData = function() {
    return `Player: ${this.charName} | 
            Weapon: ${this.charWeapon.make} | 
            Type: ${this.charType} | 
            Scores: ${this.charScores}`;
  }

  return Character;
})();


// Constructor Object (concrete/derived) Character -> Spy
let Spy = (function() {

  Spy.prototype = Object.create(Character.prototype);

  function Spy(charName, charType, charWeapon, charScores) {
    Character.call(this, charName, charType, charWeapon, charScores);
    this.catchPhrase = 'The name is Bond, James Bond.';
  }

  // say catch phrase
  Spy.prototype.sayCatchPhrase = function() {
    return this.catchPhrase;
  }

  return Spy;
})();


// Constructor Object (concrete/derived) Character -> Programmer
let Programmer = (function() {

  Programmer.prototype = Object.create(Character.prototype);

  function Programmer(charName, charType, charWeapon, charScores) {
    Character.call(this, charName, charType, charWeapon, charScores);
    this.catchPhrase = 'I\'m invincible!';
    this.charWeapon.make = this.catchPhrase;
    this.userWeapon();
  }

  // say catch phrase
  Programmer.prototype.sayCatchPhrase = function() {
    return this.catchPhrase;
  }

  // Weapon with catch phrase
  Programmer.prototype.userWeapon = function() {
    console.log('Muhahahaha!', this.sayCatchPhrase());
  }

  return Programmer;
})();


// Constructor Object (composition) Spy/Programmer -> Weapon
let Weapon = (function() {

  function Weapon(make, damage = 100) {
    this.make = make;
    this.damage = damage;
  }

  // use weapon
  Weapon.prototype.useWeapon = function() {
    return `${this.make} was used and dealt ${this.damage} damage`;
  }

  return Weapon;
})();


// --- Utility Class ---
// Class 5 (utility) 
class Utils {

  // player's average score
  static calcAvg(player) {
    return new Promise(resolve => {
      const avg = player.charScores.reduce((c, x) => c + Number(x), 0) / player.charScores.length;
      player.charAvg = Math.round(avg);
      resolve(player);
    });
  }

  // update selected player
  static setSelectedPlayer(type) {

    // spy and programmer
    const spyImg = document.querySelector('.spy-img');
    const spyName = document.querySelector('.spy-name');
    const programmerImg = document.querySelector('.programmer-img');
    const programmerName = document.querySelector('.programmer-name');

    if (type === 'spy') {
      spyImg.classList.add('char-select-img');
      spyName.classList.add('char-select-name');
      programmerImg.classList.remove('char-select-img');
      programmerName.classList.remove('char-select-name');
    } else {
      programmerImg.classList.add('char-select-img');
      programmerName.classList.add('char-select-name');
      spyImg.classList.remove('char-select-img');
      spyName.classList.remove('char-select-name');
    }
  }

  // reset form
  static resetForm() {
    document.forms.charForm.reset();
  }

  // validate form
  static validateForm() {

    // form 
    const charForm = document.forms.charForm;

    // valid count
    let validCount = 0;
    validCount += charForm.charName.validity.valid ? 0 : 1;
    validCount += charForm.charName.value.trim().length !== 0 ? 0 : 1;
    validCount += charForm.charWeapon.validity.valid ? 0 : 1;
    validCount += charForm.charWeapon.value.trim().length !== 0 ? 0 : 1;
    validCount += charForm.charGameOne.validity.valid ? 0 : 1;
    validCount += charForm.charGameOne.value.trim().length !== 0 ? 0 : 1;
    validCount += charForm.charGameTwo.validity.valid ? 0 : 1;
    validCount += charForm.charGameTwo.value.trim().length !== 0 ? 0 : 1;
    validCount += charForm.charGameThree.validity.valid ? 0 : 1;
    validCount += charForm.charGameThree.value.trim().length !== 0 ? 0 : 1;

    // toggle submit button disabled
    const submitBtn = document.querySelector('.submit');
    if (validCount === 0) submitBtn.disabled = false;
    else submitBtn.disabled = true;
  }

  static createCharacter(type) {
    return new Promise(resolve => {

      // form 
      const charForm = document.forms.charForm;
      const charName = charForm.charName.value.toUpperCase();
      const charWeapon = charForm.charWeapon.value.toUpperCase();
      const charGameOne = charForm.charGameOne.value;
      const charGameTwo = charForm.charGameTwo.value;
      const charGameThree = charForm.charGameThree.value;
      const charScores = [charGameOne, charGameTwo, charGameThree];

      // new character
      let newChar;
      if (type === 'spy') newChar = new Spy(charName, type.toUpperCase(), new Weapon(charWeapon), charScores);
      else newChar = new Programmer(charName, type.toUpperCase(), new Weapon(charWeapon), charScores);
      resolve(newChar);
    });
  }

  static displayInfo(char) {
    return new Promise(resolve => {

      // loop characters 
      for (let x in char) {

        // create table row
        let tr = document.createElement('tr');
        tr.id = `row-${x}`;
        tr.innerHTML =
          `
          <td>${char[x].charName}</td>
          <td>${char[x].charType}</td>
          <td>${char[x].charWeapon.make}</td>
          <td>${char[x].charScores}</td>
          <td>${char[x].charAvg}</td>
        `;
        document.querySelector('#tableBody').appendChild(tr);
      }

      // resolve
      resolve();
    });
  }
}
