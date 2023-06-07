from telegram import Update
from telegram.ext import CommandHandler, MessageHandler, filters, ContextTypes

async def _start(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text='Hello World!')

async def _echo(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=update.message.text)

def getHandlers():
    start_handler = CommandHandler('start', _start)
    echo_handler = MessageHandler(filters.TEXT & ~filters.COMMAND, _echo)

    return [start_handler, echo_handler]