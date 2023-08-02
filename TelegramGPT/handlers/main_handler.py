from telegram.ext import CommandHandler, MessageHandler, filters, ConversationHandler
import utils.utils as utils
import handlers.chat_handler as chath
import handlers.game_handler as gameh
import handlers.google_handler as googleh
import handlers.util_handler as utilh

def getHandlers():
    utils.init_states()

    chat_handler = ConversationHandler(
        entry_points=[CommandHandler('girl1', chath._chat_girl_1), CommandHandler('custom', chath._chat_custom)],
        states={
            utils.CHAT_CUSTOM_CONFIG: [MessageHandler(filters.TEXT & ~filters.COMMAND, chath._chat_custom_config)],
            utils.CHAT_MODE: [MessageHandler(filters.TEXT & ~filters.COMMAND, chath._chat)],
        },
        fallbacks=[CommandHandler('cancel', utilh._cancel)],
        map_to_parent={
            ConversationHandler.END : ConversationHandler.END
        }
    )

    entry_points = [CommandHandler('google', googleh._start_google), CommandHandler('chat', chath._start_chat), CommandHandler('game', gameh._start_game)]
    main_handler = ConversationHandler(
        entry_points=entry_points,
        states={
            utils.GOOGLE: [MessageHandler(filters.TEXT & ~filters.COMMAND, googleh._google), CommandHandler('help', googleh._google_help)],
            utils.CHAT: [chat_handler, CommandHandler('help', chath._chat_help)],
            utils.GAME: [MessageHandler(filters.TEXT & ~filters.COMMAND, gameh._game), CommandHandler('help', gameh._game_help)],
        },
        fallbacks=[CommandHandler('cancel', utilh._cancel)] + entry_points
    )

    ignore_handler = MessageHandler(filters.UpdateType.EDITED, utilh._ignore)
    help_command_handler = CommandHandler('help', utilh._help)
    invalid_command_handler = MessageHandler(filters.COMMAND, utilh._invalid_command)
    invalid_input_handler = MessageHandler(filters.ALL, utilh._invalid_input)

    return [ignore_handler, main_handler, help_command_handler, invalid_command_handler, invalid_input_handler]