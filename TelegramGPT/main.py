import logging
from telegram.ext import ApplicationBuilder

from handlers import getHandlers
from utils import getAPIKey

logging.basicConfig(
    format='%(asctime)s : %(name)s : %(levelname)s : %(message)s',
    level=logging.INFO
)

if __name__ == '__main__':
    application = ApplicationBuilder().token(getAPIKey()).build()
    application.add_handlers(getHandlers())

    application.run_polling()