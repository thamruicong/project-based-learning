import tempfile
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.edge.options import Options
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from webdriver_manager.microsoft import EdgeChromiumDriverManager
from selenium.webdriver.edge.service import Service as EdgeService
from util import get_windows_username

# Set up headless Chrome options
options = Options()
options.add_argument("--headless")  # Run Chrome in headless mode (without GUI)
options.add_argument("--disable-gpu")  # Recommended for some environments
options.add_argument(
    "--window-size=1920x1080"
)  # Set a virtual screen size for consistency
options.add_argument("--no-sandbox")

# Specify the location of the Microsoft Edge binary (if needed)
options.binary_location = "/mnt/c/Program Files (x86)/Microsoft/Edge/Application/msedge.exe"  # Path to Edge on Windows in WSL

# Path to the user data directory
windows_username = get_windows_username()
user_data_dir = f"/mnt/c/Users/{windows_username}/AppData/Local/Microsoft/Edge/User Data"  # Modify with your actual path
profile_name = "Default"  # Modify with the profile you want to use

# Create a temporary directory for user data
# temp_dir = tempfile.mkdtemp()
# options.add_argument(f"--user-data-dir={temp_dir}")

# Set the path to your Edge user data directory
# options.add_argument(f"--user-data-dir={user_data_dir}")  # Path to user data
# options.add_argument(f"--profile-directory={profile_name}")  # Specific profile folder

# Initialize WebDriver with automatic driver management
driver = webdriver.Edge(
    service=EdgeService(EdgeChromiumDriverManager().install()), options=options
)

# Open a website
driver.get("https://www.mousehuntgame.com/")

# Example: Wait until a button is clickable and click it
try:
    # Wait for a button to be clickable
    button = WebDriverWait(driver, 10).until(
        EC.element_to_be_clickable(
            (By.CLASS_NAME, "loginPage-signInButton")
        )  # Change to the button's ID or selector
    )

    # Perform a click action
    button.click()

    print("Button clicked successfully!")

except Exception as e:
    print(f"Error occurred: {e}")

finally:
    # Close the browser window after actions are complete
    driver.quit()
