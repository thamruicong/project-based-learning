# MH Script

Date Started: 08/03/2025

Date Completed: 10/03/2025

This is a project that attempts to create a Mousehunt script that automatically gifts 25 gifts and 20 raffle tickets to the top most active friends. Then, it automatically claims latest 15 friend gifts.

Dependencies:

- selenium 4.29.0
- webdriver-manager 4.0.2
- selenium-stealth 1.0.6

References:

- [https://stackoverflow.com/questions/68289474/selenium-headless-how-to-bypass-cloudflare-detection-using-selenium](https://stackoverflow.com/questions/68289474/selenium-headless-how-to-bypass-cloudflare-detection-using-selenium)

## How to Run Manually

I am running this script in _Windows command-line_ on _Google Chrome_.

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

## Setup Windows Task Scheduler

**NOTE: Currently linked to Windows Task Scheduler with properties:**

- Starts the `run_mh_script.bat` program
- Trigger at _9:00am_ daily
- Run task as soon as possible after a scheduled start is missed

Create a Task with these configurations:

### General

![alt text](readme_assets\task_scheduler_general.png)

### Triggers

Create a new Trigger.

![alt_text](readme_assets\task_scheduler_triggers.png)
![alt text](readme_assets\task_scheduler_triggers_2.png)

### Actions

Create a new Action.

- Program/Script: This field should point to the `run_mh_script.bat` batch file in this project.
- Start in (optional): This field should point to the root of this repository `project-based-learning`.

![alt text](readme_assets\task_scheduler_actions.png)
![alt text](readme_assets\task_scheduler_actions_2.png)

### Conditions

![alt text](readme_assets\task_scheduler_conditions.png)

### Settings

![alt text](readme_assets\task_scheduler_settings.png)
