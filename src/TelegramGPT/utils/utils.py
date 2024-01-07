import os

from dotenv import load_dotenv

load_dotenv()

HELP_TEXT = """Valid commands:
/help - Show this help message
/google - Ask me a question
/chat - Chat with me
/game - Play a game with me"""
INVALID_COMMAND_TEXT = "Invalid command!"
INVALID_INPUT_TEXT = "Invalid input!"
CANCELLED_TEXT = "Cancelled!"

START_GOOGLE_TEXT = """Welcome to Google 2.0!
I will try my best to answer all your questions here!

Type /cancel to cancel."""
GOOGLE_HELP_TEXT = """Start by typing a question!

Eg. 'What is the meaning of life?' or 'Why is the sky blue?;

Type /cancel to cancel."""

START_CHAT_TEXT = """Welcome to Chat feature!

/girl1 - basic girl chatbot
/custom - custom chatbot

Type /cancel to cancel."""
CHAT_HELP_TEXT = """Start by striking up a conversation!

Eg. 'How are you?' or 'What is your name?'

Type /cancel to cancel."""
START_CHAT_GIRL_1_TEXT = """You have selected preset Chat Girl 1. Happy chatting!

Type /cancel to cancel."""
CHAT_GIRL_1_PROMPT = "Act as if you are a friendly teenage girl."
START_CHAT_CUSTOM_TEXT = """You have selected custom chatbot. Type your prompt below!

Type /cancel to cancel."""
CHAT_CUSTOM_CONFIG_TEXT = """Custom chatbot prompt initialized. Happy chatting!

Type /cancel to cancel."""
CHAT_CANCEL_TEXT = """Confirm cancel chat?
Note that this will delete all chat history.

Type /cancel to cancel or /save to save the chatbot history and cancel"""
CHAT_SAVE_TEXT = "Chatbot history saved!"
CHAT_LOAD_TEXT = "Chatbot history loaded!"
START_CHAT_LOAD_TEXT = "Previous chatbot history available.\n\nType /load to load."
CHAT_LOAD_ERROR_TEXT = "No previous chatbot history available."

START_GAME_TEXT = "Welcome game"

# States
GOOGLE = 0
CHAT = 1
GAME = 2

# Chat states
CHAT_MODE = 0
CHAT_CUSTOM_CONFIG = 1
CHAT_CANCEL = 2


def init_states():
    # states = ["GOOGLE", "CHAT", "GAME"]
    # chat_states = ["CHAT_MODE", "CHAT_CUSTOM_CONFIG", "CHAT_CANCEL"]

    # for val, state in enumerate(states):
    #     globals()[state] = val

    # for val, chat_state in enumerate(chat_states):
    #     globals()[chat_state] = val
    pass


def getTelegramToken():
    return os.getenv("TELEGRAM_TOKEN")


def getOpenAIAPIKey():
    return os.getenv("OPENAI_API_KEY")
