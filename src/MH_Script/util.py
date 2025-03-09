import subprocess


# Running on WSL
def get_windows_username():
    return (
        subprocess.check_output('cmd.exe /c "echo %USERNAME%"', shell=True)
        .decode()
        .strip()
    )


def get_windows_cwd():
    wsl_cwd = subprocess.check_output(["pwd"]).decode().strip()
    win_cwd = subprocess.check_output(["wslpath", "-w", wsl_cwd]).decode().strip()
    return win_cwd
