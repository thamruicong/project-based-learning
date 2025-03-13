@echo off
REM TO BE RUN BY TASKSCHEDULER
cd /d "%~dp0"

python -m venv venv
call venv\Scripts\activate.bat
pip install -r requirements.txt
python main.py
call venv\Scripts\deactivate.bat

REM OPEN LOG FOLDER IN EXPLORER
start explorer "%CD%\log"

exit