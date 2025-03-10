# MH Script

Date Started: 08/03/2025

Date Completed:

This is a project that attempts to create a Mousehunt script that automatically gifts 25 gifts and 20 raffle tickets to the top most active friends.

I am running this script in _Windows command-line_ on _Google Chrome_.

Dependencies:

- selenium 4.29.0
- webdriver-manager 4.0.2

References:

-

## Setup Instructions

From root directory, perform these commands:

```bash
cd src/MH_Script

python -m venv venv # OR
python3 -m venv venv

venv\Scripts\Activate     # Windows
source venv/bin/activate  # Mac/Linux/bash

pip install -r requirements.txt
```

Then, add `.env` file according to `.env.example` and run

```bash
python main.py # OR
python3 main.py
```
