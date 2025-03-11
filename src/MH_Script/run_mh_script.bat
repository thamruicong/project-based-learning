@echo off
REM TO BE RUN BY TASKSCHEDULER
cd /d "src\MH_Script"
python -m venv venv
call venv\Scripts\activate.bat
pip install -r requirements.txt
python main.py
deactivate
pause