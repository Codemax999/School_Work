// Character Factory
class CharacterFactory {

  // create spy, programmer, engineer and default
  static createCharacter(type) {

    switch (type) {
      case 'spy': return new Spy();
      case 'programmer': return new Programmer();
      case 'engineer': return new Engineer();
      default: console.log('Unable to create this character type');
    }
  }
}