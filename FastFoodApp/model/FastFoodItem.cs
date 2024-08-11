using CsvHelper.Configuration.Attributes;

namespace FastFoodApp.model;

public class FastFoodItem
{
    [Index(0)] 
    private int _id;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    
    [Index(1)] 
    private string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    [Index(2)] 
    private decimal _price;

    public decimal Price
    {
        get { return _price; }
        set { _price = value; }
    }
    
    [Index(3)] 
    private string _size;

    public string Size
    {
        get { return _size; }
        set { _size = value;  }
    }
    
    [Index(4)] 
    private string _condiments;

    public string Condiments
    {
        get { return _condiments; }
        set { _condiments = value; }
    }
    

    public void setPrice(string selectedSize)
    {
        if (selectedSize == "S" || selectedSize == "s")
        {
            
        } else if (selectedSize == "M" || selectedSize == "m")
        {
            _price = Decimal.Add(_price, (decimal) 0.50);
        } else if (selectedSize == "L" || selectedSize == "l")
        {
            _price = Decimal.Add(_price, (decimal) 1.00);
        } 
    }

    public List<string> listOfCondiments()
    {
        List<string> condimentsList = Condiments.Split(", ").ToList();
    
        return condimentsList;
    }

    // public void selectCondiments()
    // {
    //     foreach (string condiment in listOfCondiments())
    //     {
    //         Console.WriteLine(How many servic);
    //     }
    //
    //     listOfCondiments()
    // }
}