import openai
from utils.utils import getOpenAIAPIKey
import logging

log = logging.getLogger(__name__)

openai.api_key = getOpenAIAPIKey()
MAX_TOKENS = 50

def query(prompt, model='text-davinci-003'):
    response = openai.Completion.create(
        model=model,
        prompt=prompt,
        max_tokens=MAX_TOKENS,
        temperature=0.3,
    )
    log.info(response)
    return response.choices[0].text.strip()