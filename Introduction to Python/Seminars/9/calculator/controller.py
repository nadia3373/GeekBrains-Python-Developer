import logger, model, view


def start():
    format = view.get_log_format()
    data = {}
    status = True
    while status:
        data["num1"] = view.get_number()
        data["sign"] = view.get_sign()
        data["num2"] = view.get_number()
        model.calculate(data)
        data["timestamp"] = model.get_timestamp()
        data = model.stringify(data)
        logger.save_to_log(data, format)
        view.print_result(data)
        status = view.get_status()
