using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Algolia.Search;
using Algolia.Search.Clients;
using Algolia.Search.Models.Search;

namespace HelloAlgolia
{
    // Define the main program class
    public class Program
    {
        // Define the main method
        static void Main(string[] args)
        {
            try
            {
                // Initialize the Algolia client
                var algoliaClient = new SearchClient(
                    "X5UUVWAB3E",
                    "b4439a7d4ff4d28f353ec11e21f81466"
                );

                // Initialize the Algolia index
                var index = algoliaClient.InitIndex("products");

                // Get the current directory
                DirectoryInfo currentDir = new DirectoryInfo(Environment.CurrentDirectory);

                // Define the path to the original JSON file
                string originalJsonPath = Path.Combine(currentDir.Parent.FullName, "data", "products.json");

                // Read the JSON file
                string json = File.ReadAllText(originalJsonPath);

                // Deserialize the JSON into a list of products
                List<Product> products = JsonSerializer.Deserialize<List<Product>>(json);

                // Loop through each product
                foreach (var product in products)
                {
                    // Check if the product belongs to the "Cameras & Camcorders" category
                    if (product.Categories.FirstOrDefault() == "Cameras & Camcorders")
                    {
                        // Adjust the price of the product
                        product.Price = Math.Floor((product.Price * 0.8));

                        // Define the maximum floor for a price range
                        int floor = 2000;

                        // Check if the product price is less than or equal to 1600
                        // floor * 0.8 = 1600
                        if (product.Price <= 1600)
                        {
                            // Split the price range into values
                            string[] rangeValues = product.PriceRange.Split(' ');

                            // If the range values are not null, parse the first value as an integer
                            if (rangeValues != null)
                            {
                                floor = int.Parse(rangeValues[0]);
                            } 
                        }

                        // Check if the product price is less than the floor price range
                        if (product.Price < floor)
                        {
                            // Adjust the price range based on the product price
                            switch (product.Price)
                            {
                                case < 1: 
                                    // Print a message if the product price is under 1
                                    Console.WriteLine($"Product {product.Name} with price under 1.");
                                    break;
                                case < 50:
                                    product.PriceRange = "1 - 50";
                                    break;
                                case < 100:
                                    product.PriceRange = "50 - 100";
                                    break;
                                case < 200:
                                    product.PriceRange = "100 - 200";
                                    break;
                                case < 500:
                                    product.PriceRange = "200 - 500";
                                    break;
                                case < 2000:
                                    product.PriceRange = "500 - 2000";
                                    break;
                                default:
                                    // Print a message if the product price is invalid
                                    Console.WriteLine($"Product {product.Name} with invalid price.");
                                    break;
                            }
                        }
                    }
                }

                // Serialize the list of products into a JSON string
                string outputJson = JsonSerializer.Serialize(products);

                // Define the path to the new JSON file
                string newJsonPath = Path.Combine(currentDir.Parent.FullName, "data", "cleanesedProducts.json");

                // Write the JSON string to the new file
                File.WriteAllText(newJsonPath, outputJson);

                // Save the products to the Algolia index
                index.SaveObjects(products).Wait(); 
            
            }
            // Catch any exceptions that occur
            catch (Exception ex)
            {
                // Print the exception message
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }


  
    /// <summary>
    /// The Product class represents a product with various attributes.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The name of the product.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The description of the product.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The brand of the product.
        /// </summary>
        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        /// <summary>
        /// The categories that the product belongs to.
        /// </summary>
        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }

        /// <summary>
        /// The hierarchical categories that the product belongs to.
        /// </summary>
        [JsonPropertyName("hierarchicalCategories")]
        public Dictionary<string, string> HierarchicalCategories { get; set; }

        /// <summary>
        /// The type of the product.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The price of the product.
        /// </summary>
        [JsonPropertyName("price")]
        public double Price { get; set; }

        /// <summary>
        /// The price range of the product.
        /// </summary>
        [JsonPropertyName("price_range")]
        public string PriceRange { get; set; }

        /// <summary>
        /// The image of the product.
        /// </summary>
        [JsonPropertyName("image")]
        public string Image { get; set; }

        /// <summary>
        /// The URL of the product.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Indicates whether the product has free shipping.
        /// </summary>
        [JsonPropertyName("free_shipping")]
        public bool FreeShipping { get; set; }

        /// <summary>
        /// The popularity of the product.
        /// </summary>
        [JsonPropertyName("popularity")]
        public int Popularity { get; set; }

        /// <summary>
        /// The rating of the product.
        /// </summary>
        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        /// <summary>
        /// The unique ID of the product.
        /// </summary>
        [JsonPropertyName("objectID")]
        public string ObjectID { get; set; }
    }

}
