import datetime
import logging
import os


class Logger:
    _instance = None
    _initialized = False

    @classmethod
    def get_instance(cls, log_dir="log"):
        """
        Get or create the singleton logger instance.
        """
        if cls._instance is None:
            cls._instance = cls(log_dir)
        return cls._instance

    def __init__(self, log_dir="log"):
        """
        Initialize the logger only once.
        """
        # Only initialize once, even if constructor is called multiple times
        if not Logger._initialized:
            # Create log directory if it doesn't exist
            if not os.path.exists(log_dir):
                os.makedirs(log_dir)

            # Generate a unique filename based on current timestamp
            timestamp = datetime.datetime.now().strftime("%Y%m%d_%H%M%S")
            self.log_file = os.path.join(log_dir, f"app_{timestamp}.log")

            # Configure the logger
            self.logger = logging.getLogger("my_logger")
            self.logger.setLevel(logging.INFO)
            self.logger.handlers = []  # Clear any existing handlers

            # Create file handler and set format
            file_handler = logging.FileHandler(self.log_file)
            formatter = logging.Formatter("%(message)s")
            file_handler.setFormatter(formatter)

            # Add handler to logger
            self.logger.addHandler(file_handler)

            # Log initial message
            self.log_success(f"Logger initialized with log file: {self.log_file}")

            # Mark as initialized
            Logger._initialized = True

    def log(self, status, message):
        """Log a message with timestamp and status."""
        timestamp = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")
        log_entry = f"{timestamp} - {status} - {message}"
        self.logger.info(log_entry)

    def log_success(self, message):
        """Log a success message."""
        self.log("SUCCESS", message)

    def log_error(self, message):
        """Log an error message."""
        self.log("ERROR", message)

    def log_info(self, message):
        """Log an info message."""
        self.log("INFO", message)


# Convenience static methods for easy access
def log_success(message):
    Logger.get_instance().log_success(message)


def log_error(message):
    Logger.get_instance().log_error(message)


def log(func):
    return Logger.get_instance().log_info(func)
