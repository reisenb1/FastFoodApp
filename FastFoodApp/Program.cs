// See https://aka.ms/new-console-template for more information

using FastFoodApp;
using FastFoodApp.model;
using FastFoodApp.view;

Menu menu = new Menu();

Cart cart = new Cart(new List<SelectedFoodItem>());

Bank bank = new Bank();

FastFoodCLI fastFoodCli = new FastFoodCLI(menu, cart, bank);

fastFoodCli.run();



