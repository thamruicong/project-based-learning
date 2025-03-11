from helper import (
    click_all_gift_and_ticket,
    wait_and_click,
    wait_and_find_element,
    wait_and_find_elements,
)
from selenium import webdriver
from selenium_stealth import stealth
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

stealth(
    driver,
    languages=["en-US", "en"],
    vendor="Google Inc.",
    platform="Win32",
    webgl_vendor="Intel Inc.",
    renderer="Intel Iris OpenGL Engine",
    fix_hairline=True,
)

# Open a website
driver.get("https://www.mousehuntgame.com/")

try:
    if wait_and_find_elements(driver, (By.CLASS_NAME, "loginFormContainer")):
        print("Start login process...")

        # If in first login menu, click on "START NEW GAME"
        login_text = "START NEW GAME"
        xpath_expr = (
            "//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', "
            "'abcdefghijklmnopqrstuvwxyz'), '{}')]".format(login_text.lower())
        )
        if wait_and_find_elements(driver, (By.XPATH, xpath_expr)):
            wait_and_click(driver, (By.CLASS_NAME, "loginPage-signInButton"))

        username_field = wait_and_find_element(driver, (By.NAME, "username"))
        password_field = wait_and_find_element(driver, (By.NAME, "password"))

        username_field.send_keys(get_username())
        password_field.send_keys(get_password())

        # Submit the form (Either by pressing Enter or clicking a login button)
        password_field.send_keys(Keys.RETURN)  # Press Enter

        print("Login process completed.")

    print("Start main script...")

    wait_and_click(driver, (By.CLASS_NAME, "friends"))

    click_all_gift_and_ticket(driver)

    wait_and_click(driver, (By.CLASS_NAME, "pagerView-nextPageLink"))

    click_all_gift_and_ticket(driver)

    print("Main script completed.")

    driver.save_screenshot("screenshot.png")

except Exception as e:
    print(f"Error occurred: {e}")

finally:
    # Close the browser window after actions are complete
    driver.quit()
