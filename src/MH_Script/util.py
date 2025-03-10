import os
import shutil
import subprocess

from dotenv import load_dotenv
from selenium.webdriver.chrome.options import Options

load_dotenv()


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


def get_username():
    return os.getenv("MH_USERNAME")


def get_password():
    return os.getenv("MH_PASSWORD")


def init_options(options: Options):
    # Set the path to your Chrome user data directory
    dir_path = os.path.join(os.getcwd(), "selenium")
    profile_name = "Default"

    # Delete the existing directory if it exists
    if os.path.exists(dir_path):
        shutil.rmtree(dir_path)

    options.add_argument(f"user-data-dir={dir_path}")  # Path to user data
    options.add_argument(
        f"--profile-directory={profile_name}"
    )  # Specific profile folder

    # Add other options as needed
    # options.add_argument("--headless=new")  # Run Chrome in headless mode (without GUI)
    options.add_argument("--disable-gpu")  # Recommended for some environments
    options.add_argument(
        "--window-size=1920,1080"
    )  # Set a virtual screen size for consistency
    options.add_argument("--start-maximized")  # Start Chrome maximized
    options.add_argument(
        "disable-infobars"
    )  # Disable the "Chrome is being controlled by automated software" notification
    options.add_argument("--disable-extensions")  # Disable all extensions
    options.add_argument(
        "--no-sandbox"
    )  # Run Chrome without sandboxing (for some environments)
    options.add_argument(
        "--disable-dev-shm-usage"
    )  # Disable shared memory usage (for some environments)

    # Specify the location of the Chrome binary (if needed)
    options.binary_location = r"C:\Program Files\Google\Chrome\Application\chrome.exe"  # Path to Chrome on Windows
