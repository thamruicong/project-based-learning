import handlers.util_handler as utilh
import utils.utils as utils
from handlers.util_handler import decorator_help
from telegram import Update
from telegram.ext import ContextTypes
from utils.chatbot import ChatBot


async def _start_chat(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.START_CHAT_TEXT)

    if (ChatBot.has_chatbot()):
        await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.START_CHAT_LOAD_TEXT)

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


async def _chat_cancel(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.CHAT_CANCEL_TEXT)

    return utils.CHAT_CANCEL


# Use this to save the chatbot history, if any
async def _chat_save(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.CHAT_SAVE_TEXT)

    ChatBot.save_chatbot()
    return await utilh._cancel(update, context)


# Use this to load the chatbot history, if any
async def _chat_load(update: Update, context: ContextTypes.DEFAULT_TYPE):
    if (ChatBot.has_chatbot()):
        await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.CHAT_LOAD_TEXT)

        ChatBot.load_chatbot()
        return utils.CHAT_MODE
    else:
        await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.CHAT_LOAD_ERROR_TEXT)
