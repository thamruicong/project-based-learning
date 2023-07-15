## To install all Python dependencies for any specific project:

1. cd into the project folder.
2. Ensure that the folder contains a `requirements.txt` file. This file contains all the necessary dependencies for this project to function.
3. If this file is not found, look at `Creating a requirements.txt file for your project`. Else, go to step 4.
4. Run the command `pip3 install -r requirements.txt` to generate the dependency file.

<hr>

## Creating a requirements.txt file for your project:

1. We will use two libraries to help us generate the `requirements.txt` file - pipreqs and pip-tools.
2. If not already installed, run `pip3 install pipreqs` and `pip3 install pip-tools`.
3. cd into the project folder.
4. Run the command `pipreqs --savepath=requirements.in && pip-compile`.
5. Both `requirements.in` and `requirements.txt` files should be created.