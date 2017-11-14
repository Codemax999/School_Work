// --- Load Event ---
window.addEventListener('load', () => Controller.getInstance());


// --- Controller / Singleton ---
class Controller {

  constructor() {

    // model and view
    this.model = new Model();
    this.view = new View();

    // form listeners
    this.eventListeners();
  }

  static getInstance() {

    // create singleton
    if (!Controller._instance) {

      Controller._instance = new Controller();
      return Controller._instance;

    } else console.error('Already instantiated');
  }

  eventListeners() {

    // Controller
    const self = this;

    // input
    document.querySelector('#charType').addEventListener('change', Utils.validateForm);
    document.querySelector('#charName').addEventListener('keyup', Utils.validateForm);
    document.querySelector('#charWeapon').addEventListener('keyup', Utils.validateForm);

    // submit
    document.querySelector('#characterForm').addEventListener('submit', event => {

      event.preventDefault();
      self.createCharacter()
        .then(self.model.saveCharacter)
        .then(Utils.updateCount)
        .then(Utils.checkCount)
        .then(Utils.resetForm);
    });

    // display info
    document.querySelector('.display').addEventListener('click', self.view.displayInfo);
  }

  createCharacter() {

    return new Promise(resolve => {

      // form 
      const charForm = document.forms.characterForm;
      const charType = charForm.charType.value;
      const charName = charForm.charName.value.trim();
      const charWeapon = charForm.charWeapon.value.trim();

      // new character
      resolve(CharacterFactory.createCharacter(charType, charName, charWeapon));
    });
  }
}


// --- Model ---
class Model {

  saveCharacter(newChar) {

    // save to list of characters
    Model.allCharacters.push(newChar);
    return newChar;
  }
}

// static variable: all created characters
Model.allCharacters = [];


// --- View ---
class View {

  displayInfo() {
    console.log(Model.allCharacters);
  }
}


// --- Utility ---
class Utils {

  // validate form
  static validateForm() {

    // form 
    const characterForm = document.forms.characterForm;

    // valid count
    let validCount = 0;
    validCount += characterForm.charType.validity.valid ? 0 : 1;
    validCount += characterForm.charType.value !== 'Choose a character' ? 0 : 1;
    validCount += characterForm.charName.validity.valid ? 0 : 1;
    validCount += characterForm.charName.value.trim().length !== 0 ? 0 : 1;
    validCount += characterForm.charWeapon.validity.valid ? 0 : 1;
    validCount += characterForm.charWeapon.value.trim().length !== 0 ? 0 : 1;

    // toggle submit button disabled
    const submitBtn = document.querySelector('.submit');

    if (validCount === 0) submitBtn.disabled = false;
    else submitBtn.disabled = true;
  }

  // reset form
  static resetForm() {

    document.forms.characterForm.reset();
    document.querySelector('.submit').disabled = true;
  }

  // character counter
  static updateCount(newChar) {

    // avatar counters
    let spy = document.querySelector('#spy');
    let prog = document.querySelector('#programmer');
    let eng = document.querySelector('#engineer');

    // current counts
    let spyCount = Number(spy.getAttribute('data-badge'));
    let progCount = Number(prog.getAttribute('data-badge'));
    let engCount = Number(eng.getAttribute('data-badge'));

    // update
    if (newChar.charType === 'spy') spy.setAttribute('data-badge', spyCount += 1);
    else if (newChar.charType === 'programmer') prog.setAttribute('data-badge', progCount += 1);
    else if (newChar.charType === 'engineer') eng.setAttribute('data-badge', engCount += 1);
  }

  // check count to toggle display info button
  static checkCount() {

    // display button
    const displayBtn = document.querySelector('.display');

    if (Model.allCharacters.length >= 3) displayBtn.disabled = false;
    else displayBtn.disabled = true;
  }
}