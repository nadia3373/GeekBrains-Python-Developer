import datetime


def calculate(data):
    if data["sign"] == "*": data["result"] = data["num1"] * data["num2"]
    elif data["sign"] == "/": data["result"] =  data["num1"] / data["num2"]
    elif data["sign"] == "-": data["result"] =  data["num1"] - data["num2"]
    elif data["sign"] == "+": data["result"] =  data["num1"] + data["num2"]


def get_timestamp():
    return datetime.datetime.now()


def stringify(data):
    return {i: str(x) for i, x in data.items()}
