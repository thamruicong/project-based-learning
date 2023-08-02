from telegram import Update
from telegram.ext import ContextTypes
import utils.utils as utils
from handlers.util_handler import decorator_help
from utils.chatbot import ChatBot

async def _start_chat(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.START_CHAT_TEXT)

    return utils.CHAT

@decorator_help
async def _chat_help(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.CHAT_HELP_TEXT)

async def _chat_girl_1(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.START_CHAT_GIRL_1_TEXT)

    ChatBot.build(utils.CHAT_GIRL_1_PROMPT)
    return utils.CHAT_MODE

async def _chat_custom(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.START_CHAT_CUSTOM_TEXT)

    return utils.CHAT_CUSTOM_CONFIG

async def _chat_custom_config(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.CHAT_CUSTOM_CONFIG_TEXT)

    ChatBot.build(update.effective_message.text)
    return utils.CHAT_MODE

async def _chat(update: Update, context: ContextTypes.DEFAULT_TYPE):
    reply = ChatBot.generate_response(update.effective_message.text)
    await context.bot.send_message(chat_id=update.effective_chat.id, text=reply)

# Use this to save the chatbot history
# TODO
async def _chat_cancel(update: Update, context: ContextTypes.DEFAULT_TYPE):
    text = 'Confirm cancel chat\nNote that this will delete all chat history\n\nType /cancel to confirm or /save to save the chatbot history and cancel'
    await context.bot.send_message(chat_id=update.effective_chat.id, text=text)

    # return ConversationHandler.END