import random
from tkinter import *


class Player:
    def __init__(self):  
        self.name = ""  
        self.sign = ""
        self.moves = []


def calculate_move():
    """
    Расчёт оптимального хода для компьютера
    """
    global board, combos, corners, player1, player2
    choice = None
    # Если свободен центр, занять его.
    if (1, 1) in board: choice = (1, 1)
    # Если у компьютера сделано более двух ходов, нужно проверить, нет ли комбинации, которую он может сложить следующим шагом, и выбрать этот ход.
    if len(player2.moves) > 1 and choice is None:
        for i in combos:
            if len(set(i).intersection(set(player2.moves))) == 2:
                if tuple(set(i).difference(set(player2.moves)))[0] in board: choice = tuple(set(i).difference(set(player2.moves)))[0]
    # Если у соперника сделано более двух ходов, нужно проверить, нет ли комбинации, которую он может сложить следующим шагом, и предотвратить этот ход.
    if len(player1.moves) > 1 and choice is None:
        for i in combos:
            if len(set(i).intersection(set(player1.moves))) == 2:
                if tuple(set(i).difference(set(player1.moves)))[0] in board: choice = tuple(set(i).difference(set(player1.moves)))[0]
    # Если ход не выбран, то игра в начале, но центр уже занят – нужно выбрать один из углов
    if choice is None:
        free_corners = []    
        for i in corners:
            if i in board: free_corners.append(i)
        if len(free_corners) > 0 and choice is None: choice = free_corners[random.randint(0, len(free_corners) - 1)]
    # Если ход так и не выбран, сгенерировать его рандомно из оставшихся клеток.
    if choice is None: choice = board[random.randint(0, len(board) - 1)]
    return choice


def check_combos(moves):
    """
    Проверить, не выиграл ли текущий игрок
    """
    global combos
    for i in combos:
        if set(i).intersection(set(moves)) == set(i): return True
    return False


def computer_move():
    """
    Ход компьютера
    """
    global buttons, choice, current_player, status, status_label, window
    choice = calculate_move()
    button = buttons[choice[0] * 3 + choice[1]]
    button["state"] = "disabled"
    button["text"] = current_player.sign
    board.remove(choice)
    current_player.moves.append((choice[0], choice[1]))
    status = check_combos(current_player.moves)
    if status:
        for button in buttons:
            if button["state"] != "disabled": button["state"] = "disabled"
        status_label["text"] = f"{current_player.name} ({current_player.sign}) победил"
    if len(board) > 0 and not status: current_player = player2 if current_player == player1 else player1
    if len(board) == 0: status_label["text"] = "Ничья"


def get_winning_combos(n):
    """
    Сгенерировать все выигрышные комбинации для игрового поля
    """
    rows = [[(j, i) for i in range(n)] for j in range(n)]
    columns = [[(i, j) for i in range(n)] for j in range(n)]
    d1 = [[row[i] for i, row in enumerate(rows)]]
    d2 = [[col[j] for j, col in enumerate(reversed(columns))]]
    return rows + columns + d1 + d2


def initialize_game():
    """
    Создать игровое окно
    """
    global buttons, current_player, frame, status_label, window
    window = Tk()
    window.minsize(300, 300)
    window.title("Крестики-нолики")
    status_label = Label(window, text=f"Ходит {current_player.name} ({current_player.sign})", font=('Arial', 15), bg='green', fg='snow')
    status_label.pack(fill = X)
    # Создать фрейм, добавить в него n ячеек, и каждую ячейку сделать масштабируемой
    # Каждой ячейке назначить функцию проверки хода и активное состояние
    frame = Frame(window, bg = "gray20")
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
                command=lambda row = i, col = j: move(row, col)
            )
            button.grid(row = i, column = j, sticky = "news", padx = 1, pady = 1)
            buttons.append(button)
    return window


def move(row, column):
    """
    Ход игрока
    """
    global board, choice, current_player, frame, player1, player2, status, status_label, window
    button = buttons[row * 3 + column]
    if button["state"] != "disabled":
        button["state"] = "disabled"
        button["text"] = current_player.sign
        current_player.moves.append((row, column))
        board.remove((row, column))
        status = check_combos(current_player.moves)
        if status:
            for button in buttons:
                if button["state"] != "disabled": button["state"] = "disabled"
            status_label["text"] = f"{current_player.name} ({current_player.sign}) победил"
        if len(board) > 0 and not status:
            current_player = player2 if current_player == player1 else player1
            if current_player == player2 and player2.name == "computer": computer_move()
            else: status_label["text"] = f"Ходит {current_player.name} ({current_player.sign})"
        if len(board) == 0: status_label["text"] = "Ничья"


def main():
    global board, buttons, corners, combos, current_player, player1, player2, status
    player1 = Player()
    player1.name = "player 1"
    player2 = Player()
    board = [(i, j) for i in range(3) for j in range(3)]
    corners = [i for i in [(0, 0), (0, 0 + 3 - 1), (0 + 3 - 1, 0 + 3 - 1), (0 + 3 - 1, 0)] if i in board]
    combos = get_winning_combos(3)
    buttons = []
    status = False
    while True:
        try:
            game_type = int(input("Выберите тип игры (1 – игра с компьютером, 2 – игра между двумя игроками): "))
            if game_type == 1:
                player2.name = "computer"
                break
            elif game_type == 2:
                player2.name = "player 2"
                break
        except: print("Некорректный выбор!")
    while True:
        try:
            sign = int(input("Выберите символ (1 – X, 2 – O): "))
            if sign == 1:
                player1.sign = "X"
                player2.sign = "O"
                break
            elif sign == 2:
                player1.sign = "O"
                player2.sign = "X"
                break
        except: print("Некорректный выбор!")
    while True:
        try:
            sign = int(input(f"Кто делает первый ход? 1 – {player1.name} ({player1.sign}), 2 – {player2.name} ({player2.sign}): "))
            if sign == 1:
                current_player = player1
                break
            elif sign == 2:
                current_player = player2
                break
        except: print("Некорректный выбор!")
    window = initialize_game()
    if current_player.name == "computer": computer_move()
    window.mainloop()


if __name__ == "__main__":
    main()