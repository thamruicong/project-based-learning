from pathlib import Path

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

def getAPIKey():
    path = Path(__file__).parent / 'API_KEY'

    with path.open() as f:
        k = f.read()
    
    return k