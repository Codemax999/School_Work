// 0. Abstract Character 
class Character {

  constructor(charType, charName, charWeapon) {

    this.charType = charType;
    this.charName = charName;
    this.charWeapon = charWeapon;
  }
}

// 1. Concrete Spy
class Spy extends Character {

  constructor(...args) {

    super(...args);
    this.catchPhrase = `The name is ${this.charName}, ${this.charName}`;
  }
}

// 2. Concrete Programmer
class Programmer extends Character {

  constructor(...args) {

    super(...args);
    this.catchPhrase = 'I\'m invincible!';
  }
}

// 3. Concrete Engineer 
class Engineer extends Character {

  constructor(...args) {

    super(...args);
    this.catchPhrase = 'Grow up, Bond.';
  }
}