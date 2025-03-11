# MH Script

Date Started: 08/03/2025

Date Completed: 10/03/2025

This is a project that attempts to create a Mousehunt script that automatically gifts 25 gifts and 20 raffle tickets to the top most active friends.

I am running this script in _Windows command-line_ on _Google Chrome_.

**NOTE: Currently linked to Windows Task Scheduler with properties:**

- Run whether user is logged on or not
- Trigger at _8:00pm_ daily
- Starts the `run_mh_script.bat` program

Dependencies:

- selenium 4.29.0
- webdriver-manager 4.0.2

References:

- https://stackoverflow.com/questions/68289474/selenium-headless-how-to-bypass-cloudflare-detection-using-selenium

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
