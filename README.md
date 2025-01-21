# Smart-Calculator-CS-and-PY

## Description
The Smart Calculator is an advanced application designed for performing various mathematical calculations efficiently. Implemented in both C# and Python, it offers a wide range of features, including basic arithmetic operations, square root calculations, and a comprehensive history of previous calculations saved in a JSON file. This project emphasizes accuracy, user-friendliness, and robust error handling to enhance the user's experience.

## Project Goals and Purpose
The primary goal of the Smart Calculator is to provide a reliable and easy-to-use tool for performing calculations while also teaching fundamental programming concepts such as file handling, data persistence, and user input validation. The program stores calculation history, enabling users to review past operations, which can aid in learning and reference.

## Key Features

- **Basic Arithmetic Operations**- The calculator supports addition, subtraction, multiplication, and division. Users can input calculations in the format:

    operand (space) operator (space) operand
  
    Example: 5 + 3

- **Square Root Calculation**- The calculator allows users to find the square root of any non-negative number.
- **History Management**- Every calculation is saved to a JSON file. If the JSON file does not exist at the specified path, the program will automatically create it. Users can view their complete calculation history, including the input expression and the result.
- **Robust Error Handling**- Handles invalid input formats for calculations. Prevents division by zero. Ensures that square root calculations are only performed on non-negative numbers.
- **Cross-Platform Availability**- The project is implemented in C# and Python, allowing users to explore the same functionality in two different programming environments.

## Technologies Used

1. C#: Developed using the .NET framework, leveraging libraries such as System.IO and Newtonsoft.Json for file handling and JSON processing.
2. Python: Uses built-in libraries like json and os for similar functionality.

## Instructions for Running the Project

1. Verify Prerequisites

   For C#: Ensure you have Visual Studio installed.
   
   For Python: Ensure Python 3.x is installed, along with any required libraries like json (pre-installed with Python).
   
   Download Files

   C# Implementation: SmartCalculator.cs
   
   Python Implementation: smart_calculator.py
   
2. Run the Program

   C#: Open the smartCalculator.cs file in Visual Studio. Run the program.
   
   Python: Open a terminal and navigate to the directory containing smartCalculator.py. Run the program using python smartCalculator.py.
   
3. JSON File Management

   Both versions save calculation history to a JSON file. They save the file to the specified path, creating a JSON file in it, if none exists.
   
4. Enjoy the Features
    
   Perform calculations.
   
   View history.
   
   Explore and learn from the JSON history file.
