using FastFoodApp.model;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastFoodApp.Tests.model;

[TestClass]
[TestSubject(typeof(Bank))]
public class BankTest
{

    [TestMethod]
    public void giveChange_Should_Give_Correct_Change()
    {
        Bank bank = new Bank();
        bank.Balance = (decimal)10;

        decimal output = bank.giveChange((decimal)5.40);
        
        Assert.AreEqual((decimal) 4.60, output);
    }
}