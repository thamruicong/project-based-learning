import openai
from utils import getOpenAIAPIKey

openai.api_key = getOpenAIAPIKey()

# response = openai.Completion.create(model='text-davinci-003', prompt='This is a test')

# print(response.choices[0].text.strip())