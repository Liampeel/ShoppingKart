using System;
using System.Collections.Generic;
using ShoppingKart;

public class Shop
{

    private Dictionary<string, decimal> prices = new Dictionary<string, decimal>()
    {
        {"A", 5.00m},
        {"B", 3.00m},
        {"C", 2.00m},
        {"D", 1.50m}
    };


    private Dictionary<string, Discount> discounts = new Dictionary<string, Discount>
    {
        {"A", new Discount { Amount = 3, Price = 13.00m } },
        {"B", new Discount { Amount = 2, Price = 4.5m } }
    };

    private decimal totalPrice = 0.00m;

    public decimal Total(List<string> scannedItems)
    {

        foreach (string item in scannedItems.Distinct())
        {
            var count = scannedItems.Count(x => x == item);
            HandleDiscount(item, count);
        }

        return totalPrice;
    }


    public async Task HandleDiscount(string item, int count)
    {

        var price = prices[item];
        Discount discount = null;

        if (discounts.ContainsKey(item))
        {
            discount = discounts[item];
        }

        if (discount != null && count >= discount.Amount)
        {
            var offerCount = count / discount.Amount;
            var regularCount = count % discount.Amount;
            totalPrice += offerCount * discount.Price;
            totalPrice += regularCount * price;
        }
        else
        {
            totalPrice += count * price;
        }
    }

}


