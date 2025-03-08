import subprocess

def get_windows_username():
    return subprocess.check_output('cmd.exe /c "echo %USERNAME%"', shell=True).decode().strip()
