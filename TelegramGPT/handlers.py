from telegram import Update
from telegram.ext import CommandHandler, MessageHandler, filters, ContextTypes, ConversationHandler
import logging

log = logging.getLogger(__name__)

async def _start(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text='Hello World!')

async def _echo(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=update.message.text)

async def _invalid_command(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text='Invalid command!')

async def _invalid_input(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text='Invalid input!')

GOOGLE = 0
async def _start_google(update: Update, context: ContextTypes.DEFAULT_TYPE):
    text = 'Welcome to Google 2.0!\nThis is just a simple ChatGPT interface.\n\nType /cancel to cancel.'
    await context.bot.send_message(chat_id=update.effective_chat.id, text=text)

    return GOOGLE

async def _google(update: Update, context: ContextTypes.DEFAULT_TYPE):
    text = 'Google'
    await context.bot.send_message(chat_id=update.effective_chat.id, text=text)

    return GOOGLE

async def _cancel(update: Update, context: ContextTypes.DEFAULT_TYPE):
    log.info('User %s stopped Google 2.0', update.effective_user.username)
    text = 'Google 2.0 Shutting down...'
    await context.bot.send_message(chat_id=update.effective_chat.id, text=text)

    return ConversationHandler.END

def getHandlers():
    start_handler = CommandHandler('start', _start)
    echo_handler = MessageHandler(filters.TEXT & ~filters.COMMAND, _echo)

    # Does not work correctly, need to disable all other handlers while in google_handler mode
    google_handler = ConversationHandler(
        entry_points=[CommandHandler('google', _start_google)],
        states={
            GOOGLE: [MessageHandler(filters.TEXT, _google)]
        },
        fallbacks=[CommandHandler('cancel', _cancel), MessageHandler(filters.ALL, _invalid_input)]
    )

    invalid_command_handler = MessageHandler(filters.COMMAND, _invalid_command)

    return [start_handler, echo_handler, invalid_command_handler]