# --- Abstract Character ---
class Character:

    def __init__(self, char_type, char_name, char_weapon):

        self.char_type = char_type
        self.char_name = char_name
        self.char_weapon = char_weapon

    def char_data(self):

        # display all character data
        print(f'{self.char_type.upper()}: {self.char_name} uses a {self.char_weapon}')


# --- Concrete Spy ---
class Spy(Character):

    def __init__(self, char_type, char_name, char_weapon):

        super().__init__(char_type, char_name, char_weapon)
        self.catch_phrase = f'My name is {self.char_name}, {self.char_name}.'


# --- Concrete Programmer ---
class Programmer(Character):

    def __init__(self, char_type, char_name, char_weapon):

        super().__init__(char_type, char_name, char_weapon)
        self.catch_phrase = 'I\'m invincible!'


# --- Concrete Engineer ---
class Engineer(Character):

    def __init__(self, char_type, char_name, char_weapon):

        super().__init__(char_type, char_name, char_weapon)
        self.catch_phrase = 'Grow up, Bond.'
