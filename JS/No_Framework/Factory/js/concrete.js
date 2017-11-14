// 0. Abstract Character 
class Character {

  constructor() {
    console.log('Character created');
  }
}

// 1. Concrete Spy
class Spy extends Character {

  constructor() {
    console.log('Spy created');
  }
}

// 2. Concrete Programmer
class Programmer extends Character {

  constructor() {
    console.log('Programmer created');
  }
}

// 3. Concrete Engineer 
class Engineer extends Character {

  constructor() {
    console.log('Engineer created');
  }
}