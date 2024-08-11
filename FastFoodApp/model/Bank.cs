namespace FastFoodApp.model;

public class Bank
{
    private decimal _balance;

    public decimal Balance
    {
        get { return _balance; }
        set { _balance = value; }
    }

    public void add(String input)
    {
        if (input == "N" || input == "n")
        {
            _balance = decimal.Add(_balance, (decimal) 0.05);
        }
        
        if (input == "D" || input == "d")
        {
            _balance = decimal.Add(_balance, (decimal) 0.10);
        }
        
        if (input == "Q" || input == "q")
        {
            _balance = decimal.Add(_balance, (decimal) 0.25);
        }
        
        if (input == "1")
        {
            _balance = decimal.Add(_balance, (decimal) 1.00);
        }
        
        if (input == "5")
        {
            _balance = decimal.Add(_balance, (decimal) 5.00);
        }
        
        if (input == "10")
        {
            _balance = decimal.Add(_balance, (decimal) 10.00);
        }
        
        if (input == "20")
        {
            _balance = decimal.Add(_balance, (decimal) 20.00);
        }
    }

    public decimal giveChange(decimal totalCost)
    {
        return decimal.Subtract(_balance, totalCost);
    }
}