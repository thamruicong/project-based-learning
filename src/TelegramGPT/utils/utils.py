import os

from dotenv import load_dotenv

load_dotenv()

HELP_TEXT = """Valid commands:\n
                /help - Show this help message\n
                /google - Ask me a question\n
                /chat - Chat with me\n
                /game - Play a game with me"""
INVALID_COMMAND_TEXT = "Invalid command!"
INVALID_INPUT_TEXT = "Invalid input!"
CANCELLED_TEXT = "Cancelled!"

START_GOOGLE_TEXT = """Welcome to Google 2.0!\n
                        I will try my best to answer all your questions here!\n
                        \n
                        Type /cancel to cancel."""
GOOGLE_HELP_TEXT = """Start by typing a question!\n
                        \n
                        Eg. 'What is the meaning of life?' or 'Why is the sky blue?;\n
                        \n
                        Type /cancel to cancel."""

START_CHAT_TEXT = """Welcome to Chat feature!\n
                    \n
                    /girl1 - basic girl chatbot\n
                    /custom - custom chatbot\n
                    \n
                    Type /cancel to cancel."""
CHAT_HELP_TEXT = """Start by striking up a conversation!\n
                    \n
                    Eg. 'How are you?' or 'What is your name?'\n
                    \n
                    Type /cancel to cancel."""
START_CHAT_GIRL_1_TEXT = """You have selected preset Chat Girl 1. Happy chatting!\n
                            \n
                            Type /cancel to cancel."""
CHAT_GIRL_1_PROMPT = "Act as if you are a friendly teenage girl."
START_CHAT_CUSTOM_TEXT = """You have selected custom chatbot. Type your prompt below!\n
                            \n
                            Type /cancel to cancel."""
CHAT_CUSTOM_CONFIG_TEXT = "Custom chatbot prompt initialized. Happy chatting!\n\nType /cancel to cancel."
CHAT_CANCEL_TEXT = """Confirm cancel chat?\n
                        Note that this will delete all chat history.\n
                        \n
                        Type /cancel to cancel or /save to save the chatbot history and cancel"""
CHAT_SAVE_TEXT = "Chatbot history saved!"
CHAT_LOAD_TEXT = "Chatbot history loaded!"
START_CHAT_LOAD_TEXT = "Previous chatbot history available.\n\nType /load to load."
CHAT_LOAD_ERROR_TEXT = "No previous chatbot history available."

START_GAME_TEXT = "Welcome game"

def init_states():
    states = ["GOOGLE", "CHAT", "GAME"]
    chat_states = ["CHAT_MODE", "CHAT_CUSTOM_CONFIG", "CHAT_CANCEL"]
    
    for val, state in enumerate(states):
        globals()[state] = val
    
    for val, chat_state in enumerate(chat_states):
        globals()[chat_state] = val

def getTelegramToken():
    return os.getenv("TELEGRAM_TOKEN")

def getOpenAIAPIKey():
    return os.getenv("OPENAI_API_KEY")
