using Midterm_KandABakery;

//BAKERY ITEMS
Product product1 = new Product("Talon's Loaf of Lemon", Category.BakeryItem, "Delicious & Royal Lemony Goodness", 1.99m);
Product product2 = new Product("Agent JSmith Plain Bagel", Category.BakeryItem, "The Choice of John Smith's & Jane Doe's everywhere", 1.50m);
Product product3 = new Product("DLux Double Chocolate Brownie", Category.BakeryItem, "Pairs Well with Any & All Coffees", 2.99m);
Product product4 = new Product("The Kaige Kupkake", Category.BakeryItem, "Pairs Well with Any & All Coffees", 2.99m);
Product product5 = new Product("Christy's Boysenberry Scone", Category.BakeryItem, "Unique & Flavorful", 2.99m);
Product product6 = new Product("Hussein's Niche Quiche", Category.BakeryItem, "Tastes great & fits with any meal", 2.99m);

//COFFEE ITEMS
Product product7 = new Product("GWiz Espresso Shot", Category.CoffeeItem, "Pure Craziness in a Cup", 4.53m);
Product product8 = new Product("Bret Americano", Category.CoffeeItem, "Coffeee + Espresso", 2.19m);
Product product9 = new Product("Dominion's Decaf", Category.CoffeeItem, "Black & Bitter", 2.19m);
Product product10 = new Product("Alex's Mustachio Matcha Latte", Category.CoffeeItem, "Smooth but Different", 2.19m);
Product product11 = new Product("Karen's Kombucha", Category.CoffeeItem, "Peppy, Sweet, & Helps Ya Get Sh!t Done!", 2.19m);
Product product12 = new Product("Antonio's Somethin' Yummy", Category.CoffeeItem, "Mystery Deliciosity with Caffeine", 2.19m);

Dictionary<Product, int> ourInventory = new Dictionary<Product, int>()
{
    {product1,50},
    {product2,72},
    {product3,420},
    {product4,120},
    {product5,50},
    {product6,36},
    {product7,500},
    {product8,250},
    {product9,20},
    {product10,200},
    {product11,200},
    {product12,50}
};

Inventory inventory = new Inventory(ourInventory);
Dictionary<Product, int> userCart = new Dictionary<Product, int>();

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
                            Console.WriteLine(" You have selected Bakery Item!");
                            Console.WriteLine();
                            Console.WriteLine("Here is our menu of bakery items:");
                            Console.WriteLine("-----------------------------------------------------------");
                            foreach (var item in inventory.Products)
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
                                    if (inventory.Products.ElementAt(i).Key.Name == bakeryChoice)
                                    {
                                        itemIsPresent = true;
                                        Product selection = inventory.Products.ElementAt(i).Key;

                                        Console.WriteLine($"How many {bakeryChoice} would you like?");
                                        string userQuantity = Console.ReadLine();
                                        bool isANumber1 = int.TryParse(userQuantity, out int theQuantity);
                                        if (isANumber1)
                                        {
                                            inventory.Products.TryGetValue(selection, out int CountOnHand);
                                            if (CountOnHand >= theQuantity)
                                            {
                                                userCart.Add(selection, theQuantity);
                                                inventory.Products[selection] = CountOnHand - theQuantity;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Sorry, that doesn't seem to be a number. Please try again.");
                                            Console.WriteLine();
                                        }

                                        gettingBakeryItem = false;
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
                            if (userCart.Count != 0)
                            {
                                Console.WriteLine("Here is your cart currently");
                                foreach (var item in userCart)
                                {
                                    Console.WriteLine($"{item.Key.Name}\t\t{item.Value}");
                                }
                                
                            }
                            PauseAndClearScreen();

                            gettingBakeryChoice = false;
                        }
                        else if (orderNumber2 == 2)
                        {
                            //coffeitems
                            PauseAndClearScreen();
                            List<Product> userSelections = new List<Product>();
                            Console.WriteLine(" You have selected coffee Item!");
                            Console.WriteLine();
                            Console.WriteLine("Here is our menu of coffee items:");
                            Console.WriteLine("-----------------------------------------------------------");
                            foreach (var item in inventory.Products)
                            {
                                if (item.Key.Category == Category.CoffeeItem)
                                {
                                    Console.WriteLine($"{item.Key.Name}\t\tQuantity Available: {item.Value}");
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("Which coffee item would you like?");
                            bool gettingCoffeeItem = true;
                            while (gettingCoffeeItem)
                            {
                                Console.Write("Your coffee item choice: ");
                                string coffeeChoice = Console.ReadLine();
                                bool coffeeitemIsPresent = false;
                                for (int i = 0; i < inventory.Products.Count; i++)
                                {
                                    if (inventory.Products.ElementAt(i).Key.Name == coffeeChoice)
                                    {
                                        coffeeitemIsPresent = true;
                                        Product selection = inventory.Products.ElementAt(i).Key;

                                        Console.WriteLine($"How many cups of {coffeeChoice} would you like?");
                                        string cupQuantity = Console.ReadLine();
                                        bool isANumber3 = int.TryParse(cupQuantity, out int theCupQuantity);
                                        if (isANumber3)
                                        {
                                            inventory.Products.TryGetValue(selection, out int CountOnHand);
                                            if (CountOnHand >= theCupQuantity)
                                            {
                                                userCart.Add(selection, theCupQuantity);
                                                inventory.Products[selection] = CountOnHand - theCupQuantity;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Sorry, that doesn't seem to be a number. Please try again.");
                                            Console.WriteLine();
                                        }

                                        gettingCoffeeItem = false;

                                    }
                                }
                                if (!coffeeitemIsPresent)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Sorry, that item was not found on the menu. Please try again.");
                                    Console.WriteLine();
                                }
                            }
                            Console.WriteLine();
                            if (userCart.Count != 0)
                            {
                                Console.WriteLine("Here is your cart currently");
                                foreach (var item in userCart)
                                {
                                    Console.WriteLine($"{item.Key.Name}\t\t{item.Value}");
                                }
                            }
                            PauseAndClearScreen();

                            gettingCoffeeItem = false;
                            gettingBakeryChoice = false;
                        }
                        else if (orderNumber2 == 3)
                        {
                            PauseAndClearScreen();
                            Console.WriteLine("You have selected Pick 2!");
                            PauseAndClearScreen();
                            Console.WriteLine("First, let's choose your bakery item.");
                            Console.WriteLine("Here is our menu of bakery items:");
                            Console.WriteLine("-----------------------------------------------------------");
                            foreach (var item in inventory.Products)
                            {
                                if (item.Key.Category == Category.BakeryItem)
                                {
                                    Console.WriteLine($"{item.Key.Name}\t\tQuantity Available: {item.Value}");
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Which bakery item would you like?");
                            bool gettingPick2BakeryItem = true;
                            while (gettingPick2BakeryItem)
                            {
                                Console.Write("Your bakery item choice: ");
                                string bakeryChoice = Console.ReadLine();
                                bool bakeryItemIsPresent = false;
                                for (int i = 0; i < inventory.Products.Count; i++)
                                {
                                    if (inventory.Products.ElementAt(i).Key.Name == bakeryChoice)
                                    {
                                        bakeryItemIsPresent = true;
                                        Product bakerySelection = inventory.Products.ElementAt(i).Key;
                                        inventory.Products.TryGetValue(bakerySelection, out int CountOnHand);
                                        if (CountOnHand >= 1)
                                        {
                                            userCart.Add(bakerySelection, 1);
                                            inventory.Products[bakerySelection] = CountOnHand - 1;
                                        }

                                        gettingPick2BakeryItem = false;
                                    }
                                }
                                if (!bakeryItemIsPresent)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Sorry, that item was not found on the menu. Please try again.");
                                    Console.WriteLine();
                                }
                            }
                            PauseAndClearScreen();
                            bool gettingPick2CoffeeItem = true;
                            while (gettingPick2CoffeeItem)
                            {
                                Console.WriteLine("Next, let's choose your coffee item.");
                                Console.WriteLine("Here is our menu of coffee items:");
                                Console.WriteLine("-----------------------------------------------------------");
                                foreach (var item in inventory.Products)
                                {
                                    if (item.Key.Category == Category.CoffeeItem)
                                    {
                                        Console.WriteLine($"{item.Key.Name}\t\tQuantity Available: {item.Value}");
                                    }
                                }
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Which coffee item would you like?");
                                Console.Write("Your coffee item choice: ");
                                string coffeeChoice = Console.ReadLine();
                                bool coffeeItemIsPresent = false;
                                for (int i = 0; i < inventory.Products.Count; i++)
                                {
                                    if (inventory.Products.ElementAt(i).Key.Name == coffeeChoice)
                                    {
                                        coffeeItemIsPresent = true;
                                        Product coffeeSelection = inventory.Products.ElementAt(i).Key;
                                        inventory.Products.TryGetValue(coffeeSelection, out int CountOnHand);
                                        if (CountOnHand >= 1)
                                        {
                                            userCart.Add(coffeeSelection, 1);
                                            inventory.Products[coffeeSelection] = CountOnHand - 1;
                                        }

                                        gettingPick2CoffeeItem = false;
                                    }
                                }
                                if (!coffeeItemIsPresent)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Sorry, that item was not found on the menu. Please try again.");
                                    Console.WriteLine();
                                }

                                gettingPick2CoffeeItem = false;
                            }
                            Console.WriteLine();
                            if (userCart.Count != 0)
                            {
                                Console.WriteLine("Here is your cart currently:");
                                Console.WriteLine("Item\t\tQuantity");
                                foreach (var item in userCart)
                                {
                                    Console.WriteLine($"{item.Key.Name}\t\t{item.Value}");
                                }
                                Console.WriteLine();
                            }
                            PauseAndClearScreen();
                            gettingBakeryChoice = false;
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