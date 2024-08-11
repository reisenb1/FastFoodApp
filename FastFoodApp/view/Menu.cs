using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using FastFoodApp.model;

namespace FastFoodApp.view;

public class Menu
{
        
    private List<FastFoodItem> _menuItems;
    
    public List<FastFoodItem> MenuItems
    {
        get { return _menuItems; }
        set { _menuItems = value;  }
    }
    
    public void loadItems()
    {
        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            Delimiter = "|",
        };
        using (var reader = new StreamReader("vendingmachine.csv"))
        using (var csv = new CsvReader(reader, configuration))
        {
            _menuItems = csv.GetRecords<FastFoodItem>().ToList();
        }
    }
    
    public void displayMenu()
    {
        foreach (FastFoodItem item in _menuItems)
        {
            Console.WriteLine(item.Id + ": " + item.Name + "    $" + item.Price);
        }
    }

    public FastFoodItem selectedItem(int selectedNum)
    {
        FastFoodItem item = _menuItems[selectedNum - 1];
        return _menuItems[selectedNum - 1];
    }
}