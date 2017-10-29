# Cody Maxwell
# Full Sail University
# Design Patterns for Web Programming
# Python and OOP Review
# 10.27.2017
# line with static variable: 19
# line with static method: 90
# line with subClass method override: 70

# --- Imports ---
import math


# --- Classes ---
# Class 1 (abstract/super) Character
class Character:

    # static variable
    game = 'GoldenPython 007'

    def __init__(self, name, char_type, weapon, scores):
        self.name = name
        self.weapon = weapon
        self.scores = scores
        self.char_type = char_type

    # display user's weapon
    def userWeapon(self):
        return f'Player {self.name} weapon: {self.weapon.make}'

    # display users scores
    def userScores(self):
        return f'Player {self.name} scores: {self.scores}'

    # display type of user
    def userType(self):
        return f'Player {self.name} is a {self.char_type}'

    # display full data
    def userFullData(self):
        return f'Player: {self.name} | Weapon: {self.weapon.make} | Type: {self.char_type} | Scores: {self.scores}'


# Class 2 (concrete/derived) Character -> Spy
class Spy(Character):

    def __init__(self, name, char_type, weapon, scores, catch_phrase):
        super().__init__(name, char_type, weapon, scores)
        self.catch_phrase = catch_phrase

    # say catch phrase 
    def say_catch_phrase(self):
        print(self.catch_phrase)


# Class 3 (concrete/derived) Character -> Programmer
class Programmer(Character):

    def __init__(self, name, char_type, weapon, scores, catch_phrase):
        super().__init__(name, char_type, weapon, scores)
        self.catch_phrase = catch_phrase
        self.weapon.make = self.catch_phrase
        Programmer.userWeapon(self)

    # say catch phrase
    def say_catch_phrase(self):
        return self.catch_phrase

    # OVERRIDE weapon make
    def userWeapon(self):
        print(f'Muhahahaha! {self.say_catch_phrase()}')


# Class 4 (composition) Spy/Programmer -> Weapon
class Weapon:

    def __init__(self, make, damage=100):
        self.make = make
        self.damage = damage

    # use weapon
    def use_weapon(self):
        print(f'{self.make} was used and dealt {self.damage} damage')


# Class 5 (utility) player average and input validation
class Utils:

    # player's average score
    @staticmethod
    def calcAvg(player):
        return f'Average: {str(math.ceil(sum(player.scores) / float(len(player.scores))))}'

    # validate number input
    def validate_num(num, username):
        while True:
            try:
                return int(input(f'Enter {username}\'s score for game {num}: '))
                break
            except ValueError:
                print('Invalid number. Please try again.')

    # validate string input
    def validate_str(val):
        res = input(val)
        if res.strip():
            return res
        else:
            Utils.validate_str(val)

    # validate for spy or programmer
    def validate_str_char_type(val):
        res = input(val)
        if res.strip() and (res == 'spy' or res == 'programmer'):
            return res
        else:
            Utils.validate_str_char_type(val) 


# --- Get and Display Data ---
# list of all object
all_characters = []

# get all characters
def get_characters():
    print(f'\n[User {len(all_characters) + 1}]')
    username = Utils.validate_str(f'What is your character\'s name? ')
    char_type = Utils.validate_str_char_type(f'Is {username} a spy or programmer? ')
    game_1 = Utils.validate_num(1, username)
    game_2 = Utils.validate_num(2, username)
    game_3 = Utils.validate_num(3, username)
    weapon = Utils.validate_str(f'What weapon does {username} use most? ')

    # Add to list of characters
    if char_type == 'spy':
        new_char = Spy(username, char_type, Weapon(weapon), [game_1, game_2, game_3], 'The names Bond, James Bond.')
        all_characters.append(new_char)
    else:
        new_char = Programmer(username, char_type, Weapon(weapon), [game_1, game_2, game_3], 'I\'m invicible!')
        all_characters.append(new_char)

# display all characters
def displayInfo():
    for char in all_characters:
        print(f'{char.userFullData()} | {Utils.calcAvg(char)}')


# --- Main Program ---
# greet
print(f'\n --- Welcome to {Character.game}! ---')

# get all data
while len(all_characters) < 3:
    get_characters()

# display all data
print(f'\n ---- {Character.game.upper()} LEADERBOARD ---\n')
displayInfo()
