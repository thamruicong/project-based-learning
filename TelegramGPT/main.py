import asyncio
import telegram

def getAPIKey():
    with open('API_KEY', 'r') as f:
        k = f.read()
    
    return k

async def main():
    bot = telegram.Bot(getAPIKey())
    async with bot:
        await bot.sendMessage(text='Hello World!', chat_id=1239260027)

if __name__ == '__main__':
    asyncio.run(main())