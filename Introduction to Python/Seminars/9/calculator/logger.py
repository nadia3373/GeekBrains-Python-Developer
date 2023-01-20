import csv, json, os.path


def save_to_log(data, format):
    if format == 1:
        if not os.path.isfile('log.csv'):
            with open("log.csv", "w") as f:
                writer = csv.writer(f)
                writer.writerow([x for x in data.keys()])
                writer.writerow([x for x in data.values()])
        else:
            with open("log.csv", "a") as f:
                writer = csv.writer(f)
                writer.writerow([x for x in data.values()])
    elif format == 2:
        if not os.path.isfile('log.json'):
            with open("log.json", "w") as f:
                s = json.dumps(data)
                f.write("[" + s + "]\n")
        else:
            with open("log.json", "rb+") as f:
                f.seek(-2, 2)
                f.truncate()
            with open("log.json", "a+") as f:
                s = json.dumps(data)
                f.write(",\n" + s + "]\n")
