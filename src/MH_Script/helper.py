from logger import log, log_success
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.support.ui import WebDriverWait


def wait_for(driver: webdriver.Chrome, condition, locator=None):
    """Generic wait function to handle different conditions."""
    return WebDriverWait(driver, 20).until(condition(locator) if locator else condition)


def wait_and_click(driver: webdriver.Chrome, locator):
    """Waits for an element (or WebElement) to be clickable and clicks it."""
    button = wait_for(driver, EC.element_to_be_clickable, locator)
    button.click()


def wait_and_find_elements(driver: webdriver.Chrome, locator):
    """
    Waits for all elements matching the given locator to be present in the DOM.
    """
    return wait_for(driver, EC.presence_of_all_elements_located, locator)


def wait_and_find_element(driver: webdriver.Chrome, locator):
    """
    Waits for the first element matching the given locator to be present in the DOM.
    """
    return wait_for(driver, EC.presence_of_element_located, locator)


def click_all_gift_and_ticket(driver: webdriver.Chrome):
    """Clicks all enabled gift and ticket buttons."""
    buttons = {
        "gift": (By.CLASS_NAME, "sendGift"),
        "ticket": (By.CLASS_NAME, "sendTicket"),
    }

    log("Clicking all gift and ticket buttons...")

    for _, locator in buttons.items():
        for button in wait_and_find_elements(driver, locator):
            if "disabled" not in button.get_attribute("class"):
                wait_and_click(driver, button)

    log_success("All gift and ticket buttons clicked.")


def click_all_accept_gifts(driver: webdriver.Chrome):
    """Clicks all enabled accept gift buttons."""
    buttons = {
        "accept": (By.CLASS_NAME, "claim"),
    }

    log("Clicking all accept gift buttons...")

    for _, locator in buttons.items():
        for button in wait_and_find_elements(driver, locator):
            if "disabled" not in button.get_attribute("class"):
                wait_and_click(driver, button)

    log_success("All accept gift buttons clicked.")
