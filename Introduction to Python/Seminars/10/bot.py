from aiogram import Bot, Dispatcher, executor, types
import logging, models


API_TOKEN = "5833765321:AAHlrA3F6OgNk5VHYBG_4QmOsonoM5EfAOQ"

def start():
    logging.basicConfig(filename='log.csv', encoding = "UTF-8", level=logging.INFO)
    logging.info("HEADERS: date, username, expression, result\n")

    bot = Bot(token=API_TOKEN)
    dp = Dispatcher(bot)


    @dp.message_handler(commands=['start', 'help'])
    async def send_welcome(message: types.Message):
        await message.reply(
            "Привет! Я бот-калькулятор.\n"
            "Могу посчитать выражение с рациональными и комплексными числами,\n"
            "содержащее от одного до нескольких знаков +, -, *, /.\n"
            "В выражении с рациональными числами допустимы скобки.\n"
            "Чтобы посчитать выражение, начните сообщение с команды /calc.\n"
            "Например: /calc (-1+2*3/5)*3+(1-2)-(-12/5)+2"
        )


    @dp.message_handler(commands=['calc'])
    async def reply(message: types.Message):
        result = "Parse Error: Я ещё только учу математический язык и не всё понимаю. А возможно вы намеренно ввели меня в заблуждение?"
        if any((sign in message.text[5:] for sign in ("-", "+", "*", "/"))):
            try: result = models.calculate(message.text[5:].replace(" ", ""))
            except: pass
        logging.info(f"{str(message.date)}, {message.from_user.username}, {message.text}, {'Parse Error' if result.startswith('Parse Error') else result}")
        await message.reply(result)


    print("Bot is ready to receive messages")
    executor.start_polling(dp, skip_updates=True)
    print("Bot is stopped")
