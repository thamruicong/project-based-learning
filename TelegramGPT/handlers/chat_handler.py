from telegram import Update
from telegram.ext import ContextTypes
import utils
from handlers.util_handler import decorator_help

async def _start_chat(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.START_CHAT_TEXT)

    return utils.CHAT

@decorator_help
async def _chat_help(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.CHAT_HELP_TEXT)

async def _chat_girl_1(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.START_CHAT_GIRL_1_TEXT)

    # TODO: Need to somehow initilize the chatbot and use it for subsequent _chat methods
    # Also, need a way for chatbot to remember chat history
        # One solution is to keep track of the entire history here and send it together with the prompt
            # But this solution consumes alot of tokens

    return utils.CHAT_GIRL_1

async def _chat_custom(update: Update, context: ContextTypes.DEFAULT_TYPE):
    text = 'Chat custom'
    await context.bot.send_message(chat_id=update.effective_chat.id, text=text)

    return utils.CHAT_CUSTOM

async def _chat(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=update.effective_message.text)