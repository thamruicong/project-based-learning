def getAPIKey():
    with open('API_KEY', 'r') as f:
        k = f.read()
    
    return k