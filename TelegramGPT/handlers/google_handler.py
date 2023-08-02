from telegram import Update
from telegram.ext import ContextTypes
import utils
from handlers.util_handler import decorator_help
from generate import query

async def _start_google(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.START_GOOGLE_TEXT)

    return utils.GOOGLE

@decorator_help
async def _google_help(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.GOOGLE_HELP_TEXT)

async def _google(update: Update, context: ContextTypes.DEFAULT_TYPE):
    reply = query(update.effective_message.text)
    await context.bot.send_message(chat_id=update.effective_chat.id, text=reply)
