namespace FastFoodApp.model;

public class Cart
{
    private List<SelectedFoodItem> _shoppingCart;
    
    public List<SelectedFoodItem> ShoppingCart
    {
        get { return _shoppingCart; }
        set { _shoppingCart = value;  }
    }

    private decimal _totalCost;

    public decimal TotalCost
    {
        get { return _totalCost; }
        set { _totalCost = value; }
    }

    public Cart(List<SelectedFoodItem> _shoppingCart)
    {
        this._shoppingCart = _shoppingCart;
        _totalCost = (decimal)0.00;
    }
    
    public void addItem(SelectedFoodItem selection)
    {
        _shoppingCart.Add(selection);
    }

    public decimal totalCost()
    {
        foreach (SelectedFoodItem item in _shoppingCart)
        {
            TotalCost = decimal.Add(TotalCost, item.Price);
            TotalCost = decimal.Add(TotalCost, decimal.Multiply(item.TotalNumOfCondiments, (decimal) 0.25));
        }

        return TotalCost;
    }

    public void serve()
    {
        foreach (SelectedFoodItem item in _shoppingCart)
        {
            Console.WriteLine("Here is your " + item.Name + "!!");
        }
    }
}