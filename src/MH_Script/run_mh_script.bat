@echo off
REM TO BE RUN BY TASKSCHEDULER
cd /d "%~dp0"

REM --------------------------------
REM Create fresh venv
REM --------------------------------
IF EXIST venv (
    rmdir /s /q venv
)
python -m venv venv

REM --------------------------------
REM Setup
REM --------------------------------
set "VPYTHON=venv\Scripts\python.exe"
%VPY% -m ensurepip --upgrade
%VPY% -m pip install --upgrade pip setuptools wheel
%VPY% -m pip install -r requirements.txt

%VPY% main.py

REM --------------------------------
REM OPEN LOG FOLDER IN EXPLORER
REM --------------------------------
explorer.exe /e,"%~dp0log"

exit