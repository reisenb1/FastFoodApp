using System.Globalization;
using FastFoodApp.view;
using CsvHelper;
using CsvHelper.Configuration;
using FastFoodApp.model;
using Microsoft.VisualBasic.CompilerServices;

namespace FastFoodApp;

public class FastFoodCLI
{

    private Menu menu;

    private Boolean selectingItem = false;

    private List<FastFoodItem> menuItems;

    private Cart cart;

    private FastFoodItem selectedItem;

    private SelectedFoodItem purchasedItem;

    private string selectedSize;

    private Bank bank;

    public FastFoodCLI(Menu menu, Cart cart, Bank bank)
    {
        this.menu = menu;
        this.cart = cart;
        this.bank = bank;
    }

    public void run()
    {
        Console.WriteLine("Welcome to Eric's Fast Food!");
        
        //Load items into app/machine.
        menu.loadItems();
        //Ask Customer if they would like to select an item
        Console.WriteLine("Would you like to select an item? (Y/N)");
        string initialResponse = Console.ReadLine();
        if (initialResponse == "Y" || initialResponse == "y")
        {
            selectingItem = true;
        }
        

        //if they continue to say they want to select item keep running.
        while (selectingItem == true)
        {
            menu.displayMenu();

            Console.WriteLine("Please select your item by number:");
            int selectedNum = Int32.Parse(Console.ReadLine());
            selectedItem = new FastFoodItem();
            selectedItem = menu.selectedItem(selectedNum);
            Console.WriteLine("Small (S), Medium (M), or Large (L) ?");
            selectedSize = Console.ReadLine();
            selectedItem.Size = selectedSize;
            selectedItem.setPrice(selectedSize);
            purchasedItem = selectCondiments(selectedItem);
            
            
            
            cart.addItem(purchasedItem);
            selectingItem = false;
            Console.WriteLine("Would you like to select another item? (Y/N)");
            string repeatResponse = Console.ReadLine();
            if (repeatResponse == "Y" || repeatResponse == "y")
            {
                selectingItem = true;
            }
        }

        decimal total = cart.totalCost();
        Console.WriteLine("Your total is $" + total);
        
        Console.WriteLine("Please insert cash and coins - we accept nickels through $20 bills");
        Boolean enteringCash = true;
        while (enteringCash)
        {
            Console.WriteLine("Enter N for nickel, D for Dime, Q for quarter, and 1, 5, 10, or 20 for bills.");
            string input = Console.ReadLine();
            bank.add(input);
            Console.WriteLine("Your have added $" + bank.Balance);
            Console.WriteLine("Would you like to add more money? (Y/N)");
            string continueInput = Console.ReadLine();
            if (continueInput == "N" || continueInput == "n")
            {
                enteringCash = false;
                if (bank.Balance < total)
                {
                    Console.WriteLine("You have not put in enough money yet!!");
                    enteringCash = true;
                }
            }

            
        }
        
        Console.WriteLine("Thank you! Your change is $" + bank.giveChange(total));

        cart.serve();


    }

    public SelectedFoodItem selectCondiments(FastFoodItem fastFoodItem)
    {
        SelectedFoodItem purchasedItem2 = new SelectedFoodItem();
        purchasedItem2.Name = fastFoodItem.Name;
        purchasedItem2.Price = fastFoodItem.Price;
        int totalNumOfCondiment = 0;
        foreach (string condiment in fastFoodItem.listOfCondiments())
        {
            int numOfCondiment = 0;
            Console.WriteLine("How many servings of " + condiment + " would you like?");
            numOfCondiment = Int32.Parse(Console.ReadLine());
            while (numOfCondiment > 3)
            {
                Console.WriteLine("Sorry, there is a limit of 3 servings per condiment!!");
                Console.WriteLine("How many servings of " + condiment + " would you like?");
                numOfCondiment = Int32.Parse(Console.ReadLine());
            }

            purchasedItem2.CondimentQuantity = new Dictionary<string, int>();
            purchasedItem2.CondimentQuantity.Add(condiment, numOfCondiment);
            totalNumOfCondiment += numOfCondiment;
        }
        Console.WriteLine("Total Condiments: " + totalNumOfCondiment);
        purchasedItem2.TotalNumOfCondiments = totalNumOfCondiment;
        return purchasedItem2;
    }
    
}