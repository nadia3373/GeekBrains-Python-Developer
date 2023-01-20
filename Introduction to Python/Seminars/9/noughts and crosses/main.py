import random
from tkinter import *


class Game():
    def __init__(self):
        self.board = [(i, j) for i in range(3) for j in range(3)]
        self.corners = [i for i in [(0, 0), (0, 2), (2, 2), (2, 0)] if i in self.board]
        self.combos = self.get_winning_combos(3)
        self.buttons = []
        self.status = False


    def get_winning_combos(self, n):
        """
        Сгенерировать все выигрышные комбинации для игрового поля
        """
        rows = [[(j, i) for i in range(n)] for j in range(n)]
        columns = [[(i, j) for i in range(n)] for j in range(n)]
        d1 = [[row[i] for i, row in enumerate(rows)]]
        d2 = [[col[j] for j, col in enumerate(reversed(columns))]]
        return rows + columns + d1 + d2
    

    def initialize(self):
        """
        Создать игровое окно
        """
        self.window = Tk()
        self.window.minsize(300, 300)
        self.window.title("Крестики-нолики")
        self.status_label = Label(self.window, text=f"Ходит {self.current_player.name} ({self.current_player.sign})", font=('Arial', 15), bg='green', fg='snow')
        self.status_label.pack(fill = X)
        # Создать фрейм, добавить в него n ячеек, и каждую ячейку сделать масштабируемой
        # Каждой ячейке назначить функцию проверки хода и активное состояние
        frame = Frame(self.window, bg = "gray20")
        frame.pack(expand = 1, fill = BOTH)
        for i in range(3):
            frame.columnconfigure(i, weight = 1)
            frame.rowconfigure(i, weight = 1)
            for j in range(3):
                button = Button(
                    frame,
                    font=('Arial', 36),
                    highlightthickness = 0,
                    relief = "flat",
                    state = "active",
                    text = '',
                    command=lambda row = i, col = j: self.current_player.move(row, col)
                )
                button.grid(row = i, column = j, sticky = "news", padx = 1, pady = 1)
                self.buttons.append(button)


class Player:
    global game
    def __init__(self):  
        self.name = ""  
        self.sign = ""
        self.moves = []

    def check_combos(self):
        """
        Проверить, не выиграл ли текущий игрок
        """
        for i in game.combos:
            if set(i).intersection(set(self.moves)) == set(i): return True
        return False


class Computer(Player):
    def calculate_move(self):
        """
        Расчёт оптимального хода для компьютера
        """
        global game, player1
        choice = None
        # Если свободен центр, занять его.
        if (1, 1) in game.board: choice = (1, 1)
        # Если у компьютера сделано более двух ходов, нужно проверить, нет ли комбинации, которую он может сложить следующим шагом, и выбрать этот ход.
        if len(self.moves) > 1 and choice is None:
            for i in game.combos:
                if len(set(i).intersection(set(self.moves))) == 2:
                    if tuple(set(i).difference(set(self.moves)))[0] in game.board: choice = tuple(set(i).difference(set(self.moves)))[0]
        # Если у соперника сделано более двух ходов, нужно проверить, нет ли комбинации, которую он может сложить следующим шагом, и предотвратить этот ход.
        if len(player1.moves) > 1 and choice is None:
            for i in game.combos:
                if len(set(i).intersection(set(player1.moves))) == 2:
                    if tuple(set(i).difference(set(player1.moves)))[0] in game.board: choice = tuple(set(i).difference(set(player1.moves)))[0]
        # Если ход не выбран, то игра в начале, но центр уже занят – нужно выбрать один из углов
        if choice is None:
            free_corners = []    
            for i in game.corners:
                if i in game.board: free_corners.append(i)
            if len(free_corners) > 0 and choice is None: choice = free_corners[random.randint(0, len(free_corners) - 1)]
        # Если ход так и не выбран, сгенерировать его рандомно из оставшихся клеток.
        if choice is None: choice = game.board[random.randint(0, len(game.board) - 1)]
        return choice


    def move(self):
        """
        Сделать ход
        """
        choice = self.calculate_move()
        button = game.buttons[choice[0] * 3 + choice[1]]
        button["state"] = "disabled"
        button["text"] = game.current_player.sign
        game.board.remove(choice)
        game.current_player.moves.append((choice[0], choice[1]))
        status = self.check_combos()
        if status:
            for button in game.buttons:
                if button["state"] != "disabled": button["state"] = "disabled"
            game.status_label["text"] = f"{game.current_player.name} ({game.current_player.sign}) победил"
        if len(game.board) > 0 and not status: game.current_player = player2 if game.current_player == player1 else player1
        if len(game.board) == 0: game.status_label["text"] = "Ничья"


class Human(Player):
    def move(self, row, column):
        """
        Сделать ход
        """
        global game, player1, player2
        button = game.buttons[row * 3 + column]
        if button["state"] != "disabled":
            button["state"] = "disabled"
            button["text"] = self.sign
            self.moves.append((row, column))
            game.board.remove((row, column))
            game.status = self.check_combos()
            if game.status:
                for button in game.buttons:
                    if button["state"] != "disabled": button["state"] = "disabled"
                game.status_label["text"] = f"{game.current_player.name} ({game.current_player.sign}) победил"
            if len(game.board) > 0 and not game.status:
                game.current_player = player2 if game.current_player == player1 else player1
                if game.current_player == player2 and player2.name == "computer": game.current_player.move()
                else: game.status_label["text"] = f"Ходит {game.current_player.name} ({game.current_player.sign})"
            if len(game.board) == 0: game.status_label["text"] = "Ничья"


def main():
    global game, player1, player2
    game = Game()
    player1 = Human()
    player1.name = "player 1"
    while True:
        try:
            game_type = int(input("Выберите тип игры (1 – игра с компьютером, 2 – игра между двумя игроками): "))
            if game_type == 1:
                player2 = Computer()
                player2.name = "computer"
                break
            elif game_type == 2:
                player2 = Human()
                player2.name = "player 2"
                break
        except: print("Некорректный выбор!")
    while True:
        try:
            sign = int(input("Выберите символ (1 – X, 2 – O), X ходит первым: "))
            if sign == 1:
                player1.sign = "X"
                player2.sign = "O"
                game.current_player = player1
                break
            elif sign == 2:
                player1.sign = "O"
                player2.sign = "X"
                game.current_player = player2
                break
        except: print("Некорректный выбор!")
    game.initialize()
    if game.current_player.name == "computer": game.current_player.move()
    game.window.mainloop()


if __name__ == "__main__":
    main()