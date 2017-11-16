# import
from factory import CharacterFactory


# --- Controller ---
class Controller:

    def __init__(self):

        # model
        self.model = Model([])

    def main_program(self):

        # greet
        print('\n --- Welcome to Character Creator ---')

        # loop for 3 characters
        counter = 0
        while counter < 3:

            # capture and validte user input
            print(f'\n[User {counter + 1}]')

            char_type = ''
            while len(char_type) == 0:
                char_type = Utils.validate_type(f'Is user {counter + 1} a spy, programmer or engineer? ')

            char_name = ''
            while len(char_name) == 0:
                char_name = Utils.validate_str('What is your character\'s name? ')

            char_weapon = ''
            while len(char_weapon) == 0:
                char_weapon = Utils.validate_str(f'What weapon does {char_name} use? ')

            # new character
            new_char = CharacterFactory.create_character(char_type, char_name, char_weapon)
            self.model.save_character(new_char)
            counter += 1

        # display all results
        View.display_info(self.model.all_characters)


# --- Model ---
class Model:

    def __init__(self, all_characters):
        
        # list of all created characters
        self.all_characters = all_characters

    def save_character(self, new_char):

        #save to list of characters
        self.all_characters.append(new_char)


# --- View ---
class View:

    @staticmethod
    def display_info(all_char):

        # display all data
        print('\n --- Created Characters ---\n')
        for char in all_char:
            char.char_data()


# --- Utility ---
class Utils:

    @staticmethod
    def validate_type(val):

        # user input
        res = input(val).strip().lower()

        # validate for 'spy', 'programmer' or 'engineer'
        if res == 'spy' or res == 'programmer' or res == 'engineer':
            return res
        else:
            print('\nError: This character is not supported, please try again.\n')
            return ''

    # validate string input
    @staticmethod
    def validate_str(val):

        # user input
        res = input(val).strip()

        # validate for data
        if res:
            return res
        else:
            print('\nError: Do not leave this blank, please try again.\n')
            return ''


# --- Start Program ---
newGame = Controller()
newGame.main_program()
