from telegram import Update
from telegram.ext import ContextTypes, ConversationHandler
import utils

async def _help(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.HELP_TEXT)

def decorator_help(func):
    async def wrapper(update: Update, context: ContextTypes.DEFAULT_TYPE):
        await func(update, context)
        await _help(update, context)
    return wrapper

@decorator_help
async def _invalid_command(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.INVALID_COMMAND_TEXT)

@decorator_help
async def _invalid_input(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.INVALID_INPUT_TEXT)

async def _cancel(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.CANCELLED_TEXT)

    return ConversationHandler.END

async def _ignore(update: Update, context: ContextTypes.DEFAULT_TYPE):
    pass