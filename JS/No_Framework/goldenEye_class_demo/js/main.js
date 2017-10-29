// --- On Load ---
$(document).ready(() => {

  // intialize Select Box
  $('select').material_select();

  // input listeners 
  const newUtil = new Utils();
  $('#charType').on('change', newUtil.validateForm);
  $('#charName').on('keyup', newUtil.validateForm);
  $('#charWeapon').on('keyup', newUtil.validateForm);
  $('#charGameOne').on('keyup', newUtil.validateForm);
  $('#charGameTwo').on('keyup', newUtil.validateForm);
  $('#charGameThree').on('keyup', newUtil.validateForm);


  // --- Update Leaderboard ---
  // array of created players
  let createdPlayers = [];

  // submit listener 
  $('#charForm').submit(event => {

    // prevent reload
    event.preventDefault();

    // create new character
    newUtil.createCharacter()
      .then(res => Utils.calcAvg(res))
      .then(res => {

        // add new player and sort by score
        createdPlayers.push(res);
        createdPlayers.sort((a, b) => b.charAvg - a.charAvg);

        // remove previous scores and update with new
        $('tbody').children().remove()
        return newUtil.displayInfo(createdPlayers)
      })
      .then(() => newUtil.resetForm());
  });
});


// --- Classes ---
// Class 1 (abstract/super) Character
class Character {

  constructor(charName, charType, charWeapon, charScores) {
    this.charName = charName;
    this.charType = charType;
    this.charWeapon = charWeapon;
    this.charScores = charScores;
  }

  // display user's weapon
  userWeapon() { 
    return `Player ${this.charName} weapon: ${this.charWeapon.make}`; 
  }

  // display user's scres
  userScores() { 
    return `Player ${this.charName} weapon: ${this.charScores}`;
  }

  // display type of user
  userType() { 
    return `Player ${this.charName} is a ${this.charType}`; 
  }

  // display full data 
  userFullData() { 
    return `Player: ${this.charName} | 
            Weapon: ${this.charWeapon.make} | 
            Type: ${this.charType} | 
            Scores: ${this.charScores}`; 
  }
}

// Class 2 (concrete/derived) Character -> Spy
class Spy extends Character {

  constructor(...args) {
    super(...args);
    this.catchPhrase = 'The name is Bond, James Bond.';
  }

  // say catch phrase
  sayCatchPhrase() { 
    return this.catchPhrase; 
  }
}

// Class 3 (concrete/derived) Character -> Programmer
class Programmer extends Character {

  constructor(...args) {
    super(...args);
    this.catchPhrase = 'I\'m invincible!';
    this.charWeapon.make = this.catchPhrase; 
    this.userWeapon();
  }

  // say catch phrase
  sayCatchPhrase() {
    return this.catchPhrase;
  }

  // Weapon with catch phrase
  userWeapon() { 
    console.log('Muhahahaha!', this.sayCatchPhrase()); 
  }
}

// Class 4 (composition) Spy/Programmer -> Weapon
class Weapon {

  constructor(make, damage=100) {
    this.make = make;
    this.damage = damage;
  }

  // use weapon
  useWeapon() { 
    return `${this.make} was used and dealt ${this.damage} damage`; 
  }
}

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

  // reset form
  resetForm() {
    document.forms.charForm.reset();
  }

  // validate form
  validateForm() {

    // form 
    const charForm = document.forms.charForm;

    // valid count
    let validCount = 0;
    validCount += charForm.charType.validity.valid ? 0 : 1;
    validCount += charForm.charType.value.trim().length !== 0 ? 0 : 1;
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

  createCharacter() {
    return new Promise(resolve => {

      // form 
      const charForm = document.forms.charForm;
      const charType = charForm.charType.value.toUpperCase();
      const charName = charForm.charName.value.toUpperCase();
      const charWeapon = charForm.charWeapon.value.toUpperCase();
      const charGameOne = charForm.charGameOne.value;
      const charGameTwo = charForm.charGameTwo.value;
      const charGameThree = charForm.charGameThree.value;
      const charScores = [charGameOne, charGameTwo, charGameThree];

      // new character
      let newChar;
      if (charType === 'SPY') newChar = new Spy(charName, charType, new Weapon(charWeapon), charScores);
      else newChar = new Programmer(charName, charType, new Weapon(charWeapon), charScores);
      console.log(newChar)
      resolve(newChar);
    });
  }

  displayInfo(char) {
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
