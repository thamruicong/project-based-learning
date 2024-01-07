import logging

import openai
from utils.utils import getOpenAIAPIKey

log = logging.getLogger(__name__)

openai.api_key = getOpenAIAPIKey()
MAX_TOKENS = 100


def query(prompt, model='text-davinci-003'):
    response = openai.Completion.create(
        model=model,
        prompt=prompt,
        max_tokens=MAX_TOKENS,
        temperature=0.3,
    )
    log.info(response)
    return response.choices[0].text.strip()


def chat(messages, model='gpt-3.5-turbo'):
    response = openai.ChatCompletion.create(
        model=model,
        messages=messages,
        max_tokens=MAX_TOKENS,
        temperature=0.8,
    )
    log.info(response)
    return response.choices[0].message.content.strip()
