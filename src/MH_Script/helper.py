from selenium import webdriver
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.by import By
from selenium.webdriver.remote.webelement import WebElement


def wait_and_click(driver: webdriver.Chrome, by: str, element_id: str):
    # Wait for a button to be clickable
    button = WebDriverWait(driver, 10).until(
        EC.element_to_be_clickable((by, element_id))
    )
    # Perform a click action
    button.click()


def wait_for_element_and_click(driver: webdriver.Chrome, web_element: WebElement):
    # Wait for a button to be clickable
    button = WebDriverWait(driver, 10).until(EC.element_to_be_clickable(web_element))
    # Perform a click action
    button.click()


def click_all_gift_and_ticket(driver: webdriver.Chrome):
    gift_buttons = driver.find_elements(By.CLASS_NAME, "sendGift")
    raffle_buttons = driver.find_elements(By.CLASS_NAME, "sendTicket")

    for gift_button, raffle_button in zip(gift_buttons, raffle_buttons):
        if "disabled" not in gift_button.get_attribute("class"):
            wait_for_element_and_click(driver, gift_button)
        if "disabled" not in raffle_button.get_attribute("class"):
            wait_for_element_and_click(driver, raffle_button)
