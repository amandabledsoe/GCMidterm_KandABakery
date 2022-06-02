using Midterm_KandABakery;

Product product1 = new Product("Lemon Loaf", Category.BakeryItem, "Delicious Lemony Goodness", 1.99m);
Product product2 = new Product("Plain Bagel", Category.BakeryItem, "Just a Plain Bagel", 1.50m);
Product product3 = new Product("GWiz Espresso Shot", Category.CoffeeItem, "Pure Craziness in a Cup", 4.53m);
Product product4 = new Product("Americano", Category.CoffeeItem, "Coffeee + Espresso", 2.19m);

Dictionary<Product, int> ourInventory = new Dictionary<Product, int>()
{
    {product1,48},
    {product2,36},
    {product3,500},
    {product4,250}
};

Inventory inventory = new Inventory(ourInventory);

Console.WriteLine("Welcome to the K & A Bakery!");
PauseAndClearScreen();

bool runningProgram = true;
while (runningProgram)
{
    bool gettingInput = true;
    while (gettingInput)
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Place an Order");
        Console.WriteLine("2. Complete an Order");
        Console.WriteLine("3. Exit the Program");
        Console.WriteLine();
        Console.Write("Enter the corresponding number for your choice: ");
        string userChoice = Console.ReadLine();
        bool isANumber = int.TryParse(userChoice, out int userNumber);
        if (isANumber)
        {
            if (userNumber == 1)
            {
                PauseAndClearScreen();
                Console.WriteLine("What would you like to order?");
                Console.WriteLine("1. Bakery Item");
                Console.WriteLine("2. Coffee Item");
                Console.WriteLine("3. Pick Two");
                Console.WriteLine();

                bool gettingBakeryChoice = true;
                while (gettingBakeryChoice)
                {
                    Console.Write("Enter the corresponding number for your selection: ");
                    string orderchoice = Console.ReadLine();
                    bool isaNumber2 = int.TryParse(orderchoice, out int orderNumber2);
                    if (isaNumber2)
                    {
                        if (orderNumber2 == 1)
                        {
                            PauseAndClearScreen();
                            List<Product> userSelections = new List<Product>();
                            Console.WriteLine(" You have selected Bakery Item!");
                            Console.WriteLine();
                            Console.WriteLine("Here is our menu of bakery items:");
                            Console.WriteLine("-----------------------------------------------------------");
                            foreach (var item in ourInventory)
                            {
                                if (item.Key.Category == Category.BakeryItem)
                                {
                                    Console.WriteLine($"{item.Key.Name}\t\tQuantity Available: {item.Value}");
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("Which bakery item would you like?");
                            bool gettingBakeryItem = true;
                            while (gettingBakeryItem)
                            {
                                Console.Write("Your bakery item choice: ");
                                string bakeryChoice = Console.ReadLine();
                                bool itemIsPresent = false;
                                for (int i = 0; i < inventory.Products.Count; i++)
                                {
                                    if (inventory.Products.ElementAt(i).Key.Name==bakeryChoice)
                                    {
                                        itemIsPresent = true;
                                        userSelections.Add(inventory.Products.ElementAt(i).Key);
                                        gettingBakeryItem=false;
                                    }
                                }
                                if (!itemIsPresent)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Sorry, that item was not found on the menu. Please try again.");
                                    Console.WriteLine();
                                }
                            }
                            Console.WriteLine();
                            if (userSelections.Count!=0)
                            {
                                Console.WriteLine("Here is your cart currently");
                                foreach (var item in userSelections)
                                {
                                    Console.WriteLine($"{item.Name}");
                                }
                            }
                            PauseAndClearScreen();

                            gettingBakeryChoice=false;
                        }
                        else if (orderNumber2 == 2)
                        {
                            //coffeitems
                        }
                        else if (orderNumber2 == 3)
                        {
                            //pick 2
                        }
                        else
                        {
                            Console.WriteLine("Order choice is invaid. Please try again");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Order choice is invalid. Please try again");
                    }

                }
            }
            else if (userNumber == 2)
            {

            }
            else if (userNumber == 3)
            {
                gettingInput = false;
                runningProgram = false;
            }
            else
            {
                Console.WriteLine("Sorry, that is not a number we can use. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("Sorry, that is not a number we can use. Please try again.");
            Console.WriteLine();
        }

    }
}
Console.WriteLine("Thank you for dining at the K & A Bakery!");
Console.WriteLine("Have a wonderful day!");

static void PauseAndClearScreen()
{
    Console.WriteLine();
    Console.WriteLine("Press Enter to Continue.");
    Console.ReadLine();
    Console.Clear();
}