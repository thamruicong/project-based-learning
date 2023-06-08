from telegram import Update
from telegram.ext import CommandHandler, MessageHandler, filters, ContextTypes, ConversationHandler
import utils

async def _help(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.HELP_TEXT)

async def _invalid_command(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.INVALID_COMMAND_TEXT)

async def _invalid_input(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.INVALID_INPUT_TEXT)

async def _cancel(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.CANCELLED_TEXT)

    return ConversationHandler.END

async def _start_google(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.START_GOOGLE_TEXT)

    return utils.GOOGLE

async def _start_chat(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.START_CHAT_TEXT)

    return utils.CHAT

async def _start_game(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.START_GAME_TEXT)

    return utils.GAME

async def _google(update: Update, context: ContextTypes.DEFAULT_TYPE):
    text = 'Google'
    await context.bot.send_message(chat_id=update.effective_chat.id, text=text)

async def _chat(update: Update, context: ContextTypes.DEFAULT_TYPE):
    text = 'Chat'
    await context.bot.send_message(chat_id=update.effective_chat.id, text=text)
    
async def _game(update: Update, context: ContextTypes.DEFAULT_TYPE):
    text = 'Game'
    await context.bot.send_message(chat_id=update.effective_chat.id, text=text)

def getHandlers():
    utils.init_states()
    entry_points = [CommandHandler('google', _start_google), CommandHandler('chat', _start_chat), CommandHandler('game', _start_game)]
    main_handler = ConversationHandler(
        entry_points=entry_points,
        states={
            utils.GOOGLE: [MessageHandler(filters.TEXT & ~filters.COMMAND, _google)],
            utils.CHAT: [MessageHandler(filters.TEXT & ~filters.COMMAND, _chat)],
            utils.GAME: [MessageHandler(filters.TEXT & ~filters.COMMAND, _game)],
        },
        fallbacks=[CommandHandler('cancel', _cancel)] + entry_points
    )

    help_command_handler = CommandHandler('help', _help)
    invalid_command_handler = MessageHandler(filters.COMMAND, _invalid_command)
    invalid_input_handler = MessageHandler(filters.ALL, _invalid_input)

    return [main_handler, help_command_handler, invalid_command_handler, invalid_input_handler]