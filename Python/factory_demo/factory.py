# import
from concrete import Spy, Programmer, Engineer


# --- Character Factory ---
class CharacterFactory:

    # instansiate character type
    @staticmethod
    def create_character(char_type, char_name, char_weapon):

        if char_type == 'spy':
            return Spy(char_type, char_name, char_weapon)

        elif char_type == 'programmer':
            return Programmer(char_type, char_name, char_weapon)

        elif char_type == 'engineer':
            return Engineer(char_type, char_name, char_weapon)

        else:
            print('Can not create this character.')
