import os
import tempfile
import stat
import shutil
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from webdriver_manager.chrome import ChromeDriverManager
from selenium.webdriver.chrome.service import Service as ChromeService
from util import get_windows_username, get_windows_cwd

# Set up Chrome options
options = Options()

# Set the path to your Chrome user data directory
dir_path = os.path.join(get_windows_cwd(), "selenium")
profile_name = "Default"

# Delete the existing directory if it exists
if os.path.exists(dir_path):
    shutil.rmtree(dir_path)

options.add_argument(f"user-data-dir={dir_path}")  # Path to user data
options.add_argument(f"--profile-directory={profile_name}")  # Specific profile folder

# Add other options as needed
# options.add_argument("--headless")  # Run Chrome in headless mode (without GUI)
options.add_argument("--disable-gpu")  # Recommended for some environments
options.add_argument(
    "--window-size=1920x1080"
)  # Set a virtual screen size for consistency
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
options.binary_location = "/mnt/c/Program Files/Google/Chrome/Application/chrome.exe"  # Path to Chrome on Windows in WSL

# Create a temporary directory for user data
# temp_dir = tempfile.mkdtemp()
# os.chmod(temp_dir, stat.S_IRWXU | stat.S_IRWXG | stat.S_IRWXO)
# options.add_argument(f"--user-data-dir={temp_dir}")

print("starting...")
# Initialize WebDriver with automatic driver management
driver = webdriver.Chrome(
    service=ChromeService(ChromeDriverManager().install()), options=options
)

# Open a website
driver.get("https://www.google.com/")
driver.quit()

# Example: Wait until a button is clickable and click it
# try:
#     # Wait for a button to be clickable
#     button = WebDriverWait(driver, 10).until(
#         EC.element_to_be_clickable(
#             (By.CLASS_NAME, "loginPage-signInButton")
#         )  # Change to the button's ID or selector
#     )

#     # Perform a click action
#     button.click()

#     print("Button clicked successfully!")

# except Exception as e:
#     print(f"Error occurred: {e}")

# finally:
#     # Close the browser window after actions are complete
#     driver.quit()
