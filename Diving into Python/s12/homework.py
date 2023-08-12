import csv


class NameDescriptor:
    """
    Дескриптор для проверки и хранения ФИО студента.
    Проверяет, что каждая часть ФИО содержит только буквы и начинается с заглавной буквы.
    """
    def __get__(self, instance, owner):
        return f'{instance._first_name} {instance._first_name} {instance._patronymic}'

    def __set__(self, instance, value):
        first_name, last_name, patronymic = value

        if not all(part.isalpha() and part.istitle() for part in [first_name, last_name, patronymic]):
            raise ValueError("Каждая часть ФИО должна содержать только буквы и начинаться с заглавной буквы")

        instance._first_name = first_name
        instance._last_name = last_name
        instance._patronymic = patronymic


class Subject:
    """
    Класс, представляющий предмет, с валидацией оценок и результатов тестов.
    """
    def __init__(self, name):
        self.name = name
        self.scores = []
        self.test_results = []

    def add_score(self, score):
        if 2 <= score <= 5:
            self.scores.append(score)
        else:
            raise ValueError("Оценка должна быть в диапазоне от 2 до 5")

    def add_test_result(self, result):
        if 0 <= result <= 100:
            self.test_results.append(result)
        else:
            raise ValueError("Результат теста должен быть в диапазоне от 0 до 100")

    def average_test_score(self):
        if self.test_results:
            return sum(self.test_results) / len(self.test_results)
        return 0

    def average_score(self):
        if self.scores:
            return sum(self.scores) / len(self.scores)
        return 0


class Student:
    """
    Класс, представляющий студента.
    """
    name = NameDescriptor()

    def __init__(self, first_name, last_name, patronymic, file):
        self.name = (first_name, last_name, patronymic)
        self.subjects = self.load_subjects(file)

    def load_subjects(self, csv_file):
        subjects = []
        with open(csv_file, 'r') as file:
            reader = csv.reader(file)
            subjects = [Subject(row[0]) for row in reader]
        return subjects

    def add_score(self, subject_name, score):
        subject = self.find_subject(subject_name)
        if subject:
            subject.add_score(score)
        else:
            raise ValueError("Предмет не найден")

    def add_test_result(self, subject_name, result):
        subject = self.find_subject(subject_name)
        if subject:
            subject.add_test_result(result)
        else:
            raise ValueError("Предмет не найден")

    def find_subject(self, subject_name):
        for subject in self.subjects:
            if subject.name == subject_name:
                return subject
        return None

    def average_test_score_per_subject(self):
        averages = {}
        for subject in self.subjects:
            averages[subject.name] = subject.average_test_score()
        return averages

    def average_score_all_subjects(self):
        total_scores = [score for subject in self.subjects for score in subject.scores]
        if total_scores:
            return sum(total_scores) / len(total_scores)
        return 0


subjects = 'subjects.csv'
student = Student('Иванов', 'Иван', 'Иванович', subjects)

student.add_score('Математика', 5)
student.add_score('Математика', 4)
student.add_test_result('Математика', 85)
student.add_test_result('Математика', 90)

student.add_score('Физика', 3)
student.add_score('Физика', 4)
student.add_test_result('Физика', 70)
student.add_test_result('Физика', 80)

print("Средний балл по тестам для каждого предмета:", student.average_test_score_per_subject())
print("Средний балл по оценкам всех предметов:", student.average_score_all_subjects())
