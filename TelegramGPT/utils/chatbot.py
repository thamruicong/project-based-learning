# Static class that represents a class instance of the chatbot
# Only one chatbot can be built at a time

# Features:
    # 1. Create the chatbot (this simply creates a new instance of the chatbot)
    # 2. Build the chatbot with the given prompt
    # 3. Generate a response from the chatbot
    # 4. Chatbot remembers chat history
    # 5. Chatbot can be saved and loaded (to save on tokens) TODO

import logging
from utils.generate import chat

log = logging.getLogger(__name__)

class ChatBot():
    chathistory = None

    def __init__(self):
        raise Exception('ChatBot is a static class and should not be instantiated')

    @classmethod
    def build(cls, prompt):
        ChatBot.chathistory = []

        ChatBot.chathistory.append({
            'role': 'system',
            'content': prompt,
        })

        return ChatBot

    @classmethod
    def generate_response(cls, input):
        if ChatBot.chathistory is None:
            raise Exception('Chatbot has not been built yet')
        
        ChatBot.chathistory.append({
            'role': 'user',
            'content': input,
        })

        response = chat(ChatBot.chathistory)

        ChatBot.chathistory.append({
            'role': 'assistant',
            'content': response,
        })

        return response
    
    @classmethod
    def save_chatbot(cls):
        pass

    @classmethod
    def load_chatbot(cls):
        pass
