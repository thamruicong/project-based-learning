from telegram import Update
from telegram.ext import ContextTypes
import utils.utils as utils
from handlers.util_handler import decorator_help

async def _start_game(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.START_GAME_TEXT)

    return utils.GAME

@decorator_help
async def _game_help(update: Update, context: ContextTypes.DEFAULT_TYPE):
    pass

async def _game(update: Update, context: ContextTypes.DEFAULT_TYPE):
    text = 'Game'
    await context.bot.send_message(chat_id=update.effective_chat.id, text=text)