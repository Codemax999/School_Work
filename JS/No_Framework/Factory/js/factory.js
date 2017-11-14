// Character Factory
class CharacterFactory {

  // create spy, programmer, engineer and default
  static createCharacter(...args) {

    switch (args[0]) {
      case 'spy': return new Spy(...args);
      case 'programmer': return new Programmer(...args);
      case 'engineer': return new Engineer(...args);
      default: console.error('Unable to create this character');
    }
  }
}