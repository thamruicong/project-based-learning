import logging
from telegram.ext import ApplicationBuilder

from handlers.main_handler import getHandlers
from utils.utils import getTelegramToken

logging.basicConfig(
    format='%(asctime)s : %(name)s : %(levelname)s : %(message)s',
    level=logging.INFO
)

if __name__ == '__main__':
    application = ApplicationBuilder().token(getTelegramToken()).build()
    application.add_handlers(getHandlers())

    application.run_polling()