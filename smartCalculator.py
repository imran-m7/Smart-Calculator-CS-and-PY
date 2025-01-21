import json
import os

# file path where the json file will be saved
json_path = r"C:\Users\a\source\repos\homework\homework\bin\Debug\section_C_task2.json"


# checking if there is json file already
def checking_history_exists():
    if not os.path.exists(json_path):
        # if there is not, creating an empty file
        with open(json_path, 'w') as file:
            json.dump([], file)


# saving history to the json file
def saving_history(expression, result):
    checking_history_exists()
    with open(json_path, 'r') as file:
        history = json.load(file)
    
    history.append({'expression': expression, 'result': result})
    
    with open(json_path, 'w') as file:
        json.dump(history, file, indent=4)


# first option for basic calculation
def first_option():
    user_input = input("Enter your calculation: ")
    
    try:
        tokens_of_input = user_input.split(' ')

        if len(tokens_of_input) != 3:
            raise ValueError("You did not enter the valid format.")

        first_number = float(tokens_of_input[0])
        operator = tokens_of_input[1]
        second_number = float(tokens_of_input[2])
        result = 0

        # Checking user's wanted operation and updating history
        if operator == "+":
            result = first_number + second_number
            print(f"Result: {result}")
            saving_history(user_input, result)
        elif operator == "-":
            result = first_number - second_number
            print(f"Result: {result}")
            saving_history(user_input, result)
        elif operator == "*":
            result = first_number * second_number
            print(f"Result: {result}")
            saving_history(user_input, result)
        elif operator == "/":
            if second_number != 0:
                result = first_number / second_number
                print(f"Result: {result}")
                saving_history(user_input, result)
            else:
                print("Error: You cannot divide by zero.")
        else:
            print("Invalid operator. Use +, -, *, or /.")
    
    except ValueError:
        print("Invalid input format. Please use the format: operand (space) operator (space) operand.")


# second option for calculating square root
def second_option():
    user_input = input("Please enter a number to calculate its square root: ")

    try:
        user_number = float(user_input)

        if user_number < 0:
            raise ValueError("No calculations of the square root of a negative number.")

        result = user_number ** 0.5
        print(f"Square Root: √{user_number} = {result}")
        saving_history(f"√{user_number}", result)
    
    except ValueError as e:
        print(f"Error: {e}")


# option for viewing history
def third_option():
    checking_history_exists()
    with open(json_path, 'r') as file:
        history = json.load(file)

    if not history:
        print("No history available.")
    else:
        print("Calculation History:")
        for count, record in enumerate(history, start=1):
            print(f"{count}: {record['expression']} = {record['result']}")


# main function for menu and user choice
def main():
    while True:
        # starting menu
        print("Calculator Menu:")
        print("1. Perform Basic Calculation")
        print("2. Calculate Square Root")
        print("3. View History")
        print("4. Exit")
        option = input("Enter your choice: ")

        # checking if the user input is a valid number
        if option.isdigit():
            option = int(option)
            print(f"You selected option number {option}.")
        else:
            print("Invalid input. Please enter a valid number.")
            continue

        if option == 1:
            first_option()
        elif option == 2:
            second_option()
        elif option == 3:
            third_option()
        elif option == 4:
            print("Exiting the calculator.")
            break
        else:
            print("You did not enter a valid option. Try again.")


# run the calculator
main()
