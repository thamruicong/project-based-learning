from time import sleep

from helper import wait_and_click, click_all_gift_and_ticket
from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.chrome.service import Service as ChromeService
from selenium.webdriver.common.by import By
from selenium.webdriver.common.keys import Keys
from util import get_password, get_username, init_options
from webdriver_manager.chrome import ChromeDriverManager

# Set up Chrome options
options = Options()
init_options(options)

# Initialize WebDriver with automatic driver management
driver = webdriver.Chrome(
    service=ChromeService(ChromeDriverManager().install()), options=options
)

# Open a website
driver.get("https://www.mousehuntgame.com/")

try:
    if driver.find_elements(By.CLASS_NAME, "loginFormContainer"):
        print("Start login process...")

        # If in first login menu, click on "START NEW GAME"
        login_text = "START NEW GAME"
        xpath_expr = (
            "//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', "
            "'abcdefghijklmnopqrstuvwxyz'), '{}')]".format(login_text.lower())
        )
        if driver.find_elements(
            By.XPATH,
            xpath_expr,
        ):
            wait_and_click(driver, By.CLASS_NAME, "loginPage-signInButton")

        username_field = driver.find_element(By.NAME, "username")
        password_field = driver.find_element(By.NAME, "password")

        username_field.send_keys(get_username())
        password_field.send_keys(get_password())

        # Submit the form (Either by pressing Enter or clicking a login button)
        password_field.send_keys(Keys.RETURN)  # Press Enter

        print("Login process completed.")

    print("Start main script...")

    wait_and_click(driver, By.CLASS_NAME, "friends")

    sleep(5)  # Wait for load

    click_all_gift_and_ticket(driver)

    wait_and_click(driver, By.CLASS_NAME, "pagerView-nextPageLink")

    sleep(5)  # Wait for load

    click_all_gift_and_ticket(driver)

    print("Main script completed.")

except Exception as e:
    print(f"Error occurred: {e}")

finally:
    # Close the browser window after actions are complete
    driver.quit()
