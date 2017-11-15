// Character Factory
class CharacterFactory {

  // create spy, programmer, engineer and default
  static createCharacter(...args) {

    return new Promise((resolve, reject) => {

      switch (args[0]) {
        case 'spy': resolve(new Spy(...args));
        case 'programmer': resolve(new Programmer(...args));
        case 'engineer': resolve(new Engineer(...args));
        default: reject('Can not create this character');
      }
    });
  }
}