import os
from dotenv import load_dotenv

load_dotenv()

HELP_TEXT = 'Help'
INVALID_COMMAND_TEXT = 'Invalid command!'
INVALID_INPUT_TEXT = 'Invalid input!'
CANCELLED_TEXT = 'Cancelled!'
START_GOOGLE_TEXT = 'Welcome to Google 2.0!\nThis is just a simple ChatGPT interface.\n\nType /cancel to cancel.'
START_CHAT_TEXT ='Welcome chat'
START_GAME_TEXT = 'Welcome game'

def init_states():
    states = ['GOOGLE', 'CHAT', 'GAME']
    
    for val, state in enumerate(states):
        globals()[state] = val

def getTelegramToken():
    return os.getenv('TELEGRAM_TOKEN')

def getOpenAIAPIKey():
    return os.getenv('OPENAI_API_KEY')