# Supporting Documentation for Technical Assignment - Part One

# Overview
The HelloAlgolia application is a simple C# console application that reads product data from a JSON file, applies a discount to products in the "Cameras & Camcorders" category, and writes the updated product data back to a new JSON file. The application uses the Algolia Search Client to interact with an Algolia index.

# Code Structure
The application is structured into two classes: Program and Product.

The Program class contains the Main method, which is the entry point of the application. The Main method: 
 * Initializes an Algolia Search Client.
 * Reads product data from a JSON file.
 * Applies a discount to products in the "Cameras & Camcorders" category.
 * Writes the cleansed product data back to a new JSON file.
 * Indexes the cleansed product data into the an Algolia index.

The Product class represents a product with various attributes. It includes the properties for the product as defined in the JSON file provided.

# Usage
To use the application, run the Main method in the Program class. The application will read product data from a JSON file, apply a discount to products in the "Cameras & Camcorders" category, and write the updated product data back to a new JSON file.

Check the hardcoded values for the location of the original and new JSON files (lines 33 & 105) to ensure it matches your folder structure.

# Assumptions
* The application applies discounts to all products in the "Cameras & Camcorders" category. If a different category is required, change the if statement on line 45 accordingly. 
Example to apply the discount only to the categories "Digital Cameras" & "Camcorders" =>  
if (product.Categories[1] == "Digital Cameras" || product.Categories[1] == "Camcorders") 
* The application assumes that the product price is a positive number.
* The application does not handle exceptions that may occur when reading from or writing to the JSON file.


