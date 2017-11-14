// --- Load Event ---
window.addEventListener('load', () => Assignment.getInstance());


// --- Singleton ---
class Assignment {

  constructor() {

    // create instance of main program
    const mainProgram = new MainProgram();
  }

  // static method for singleton 
  static getInstance() {

    if (!Assignment._instance) {

      Assignment._instance = new Assignment();
      return Assignment._instance;

    } else console.error('Already instantiated');
  }
}


// --- Main Program ---
class MainProgram {

  constructor() {
    console.log('Program loaded');
  }

  eventListeners() {

  }
}


// --- Utility ---
class Utils {

}