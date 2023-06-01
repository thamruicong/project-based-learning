import logging
from telegram import Update
from telegram.ext import ApplicationBuilder, CommandHandler, ContextTypes

logging.basicConfig(
    format='%(asctime)s : %(name)s : %(levelname)s : %(message)s',
    level=logging.INFO
)

def getAPIKey():
    with open('API_KEY', 'r') as f:
        k = f.read()
    
    return k

async def _start(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text='Hello World!')

if __name__ == '__main__':
    application = ApplicationBuilder().token(getAPIKey()).build()

    startHandler = CommandHandler('start', _start)
    application.add_handler(startHandler)

    application.run_polling()