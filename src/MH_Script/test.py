import os
import shutil
from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.chrome.service import Service as ChromeService
from webdriver_manager.chrome import ChromeDriverManager
from util import get_windows_cwd

options = Options()

dir_path = os.path.join(get_windows_cwd(), "selenium")

# Delete the existing directory if it exists
if os.path.exists(dir_path):
    shutil.rmtree(dir_path)

options.add_argument(f"user-data-dir={dir_path}")
options.binary_location = "/mnt/c/Program Files/Google/Chrome/Application/chrome.exe"  # Path to Chrome on Windows in WSL

driver = webdriver.Chrome(
    service=ChromeService(ChromeDriverManager().install()), options=options
)

driver.get("https://www.google.com")

driver.quit()
