from calc.quadratic_equation import solve
from file_utils.csv import from_csv, generate_csv
from file_utils.json import save_to_json

CSV_COLUMNS = 3
CSV_ROWS = 100

if __name__ == "__main__":
    generate_csv("data/input.csv", CSV_COLUMNS, CSV_ROWS)

    @from_csv
    @save_to_json
    def process_quadratic_equation(a, b, c):
        return solve(a, b, c)


    process_quadratic_equation("data/input.csv")
