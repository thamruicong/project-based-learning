import logging
from telegram import Update
from telegram.ext import filters, ApplicationBuilder, CommandHandler, MessageHandler, ContextTypes

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

async def _echo(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=update.message.text)

if __name__ == '__main__':
    application = ApplicationBuilder().token(getAPIKey()).build()

    start_handler = CommandHandler('start', _start)
    echo_handler = MessageHandler(filters.TEXT & ~filters.COMMAND, _echo)

    application.add_handlers([start_handler, echo_handler])

    application.run_polling()