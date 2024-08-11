namespace FastFoodApp.model;

public class SelectedFoodItem
{
    private string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    private decimal _price;

    public decimal Price
    {
        get { return _price; }
        set { _price = value;  }
    }

    private Dictionary<string, int> _condimentQuantity;

    public Dictionary<string, int> CondimentQuantity
    {
        get { return _condimentQuantity; }
        set { _condimentQuantity = value; }
    }

    private int _totalNumOfCondiments;

    public int TotalNumOfCondiments
    {
        get { return _totalNumOfCondiments; }
        set { _totalNumOfCondiments = value; }
    }

    public void writePurchasedItem()
    {
        Console.WriteLine("Here is your " + _name + " with: " );
        foreach (KeyValuePair<string, int> condiment in _condimentQuantity)
        {
            Console.WriteLine(condiment.Value + " serving(s) of " + condiment.Key);
        }
    }
}