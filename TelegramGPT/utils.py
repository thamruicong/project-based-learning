import os
from dotenv import load_dotenv

load_dotenv()

HELP_TEXT = 'Valid commands:\n/help - Show this help message\n/google - Ask me a question\n/chat - Chat with me\n/game - Play a game with me'
INVALID_COMMAND_TEXT = 'Invalid command!'
INVALID_INPUT_TEXT = 'Invalid input!'
CANCELLED_TEXT = 'Cancelled!'

START_GOOGLE_TEXT = 'Welcome to Google 2.0!\nI will try my best to answer all your questions here!\n\nType /cancel to cancel.'
GOOGLE_HELP_TEXT = 'Start by typing a question!\n\nEg. "What is the meaning of life?" or "Why is the sky blue?"\n\nType /cancel to cancel.'

START_CHAT_TEXT ='Welcome to Chat feature!\n\n/girl1 - basic girl chatbot\n/custom - custom chatbot\n\nType /cancel to cancel.'
CHAT_HELP_TEXT = 'Start by striking up a conversation!\n\nEg. "How are you?" or "What is your name?"\n\nType /cancel to cancel.'
START_CHAT_GIRL_1_TEXT = 'You have selected preset Chat Girl 1. Happy chatting!\n\nType /cancel to cancel.'

START_GAME_TEXT = 'Welcome game'

def init_states():
    states = ['GOOGLE', 'CHAT', 'GAME']
    chat_states = ['CHAT_GIRL_1', 'CHAT_CUSTOM']
    
    for val, state in enumerate(states):
        globals()[state] = val
    
    for val, chat_state in enumerate(chat_states):
        globals()[chat_state] = val

def getTelegramToken():
    return os.getenv('TELEGRAM_TOKEN')

def getOpenAIAPIKey():
    return os.getenv('OPENAI_API_KEY')