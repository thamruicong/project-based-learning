from telegram import Update
from telegram.ext import CommandHandler, MessageHandler, filters, ContextTypes, ConversationHandler
import utils
from generate import query

############################ UTILS ############################
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

############################ GOOGLE ############################
async def _start_google(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.START_GOOGLE_TEXT)

    return utils.GOOGLE

@decorator_help
async def _google_help(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.GOOGLE_HELP_TEXT)

async def _google(update: Update, context: ContextTypes.DEFAULT_TYPE):
    reply = query(update.effective_message.text)
    await context.bot.send_message(chat_id=update.effective_chat.id, text=reply)

############################ CHAT ############################
async def _start_chat(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.START_CHAT_TEXT)

    return utils.CHAT

@decorator_help
async def _chat_help(update: Update, context: ContextTypes.DEFAULT_TYPE):
    pass

async def _chat_girl_1(update: Update, context: ContextTypes.DEFAULT_TYPE):
    text = 'Chat girl 1'
    await context.bot.send_message(chat_id=update.effective_chat.id, text=text)

    return utils.CHAT_GIRL_1

async def _chat_custom(update: Update, context: ContextTypes.DEFAULT_TYPE):
    text = 'Chat custom'
    await context.bot.send_message(chat_id=update.effective_chat.id, text=text)

    return utils.CHAT_CUSTOM

############################ GAME ############################
async def _start_game(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(chat_id=update.effective_chat.id, text=utils.START_GAME_TEXT)

    return utils.GAME

@decorator_help
async def _game_help(update: Update, context: ContextTypes.DEFAULT_TYPE):
    pass

async def _game(update: Update, context: ContextTypes.DEFAULT_TYPE):
    text = 'Game'
    await context.bot.send_message(chat_id=update.effective_chat.id, text=text)

def getHandlers():
    utils.init_states()

    chat_handler = ConversationHandler(
        entry_points=[CommandHandler('girl1', _chat_girl_1), CommandHandler('custom', _chat_custom)],
        states={
            utils.CHAT_GIRL_1: [],
            utils.CHAT_CUSTOM: [],
        },
        fallbacks=[CommandHandler('cancel', _cancel)],
        map_to_parent={
            ConversationHandler.END : ConversationHandler.END
        }
    )

    entry_points = [CommandHandler('google', _start_google), CommandHandler('chat', _start_chat), CommandHandler('game', _start_game)]
    main_handler = ConversationHandler(
        entry_points=entry_points,
        states={
            utils.GOOGLE: [MessageHandler(filters.TEXT & ~filters.COMMAND, _google), CommandHandler('help', _google_help)],
            utils.CHAT: [chat_handler, CommandHandler('help', _chat_help)],
            utils.GAME: [MessageHandler(filters.TEXT & ~filters.COMMAND, _game), CommandHandler('help', _game_help)],
        },
        fallbacks=[CommandHandler('cancel', _cancel)] + entry_points
    )

    ignore_handler = MessageHandler(filters.UpdateType.EDITED, _ignore)
    help_command_handler = CommandHandler('help', _help)
    invalid_command_handler = MessageHandler(filters.COMMAND, _invalid_command)
    invalid_input_handler = MessageHandler(filters.ALL, _invalid_input)

    return [ignore_handler, main_handler, help_command_handler, invalid_command_handler, invalid_input_handler]