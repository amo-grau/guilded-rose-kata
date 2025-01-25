using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime;
using System.Runtime.CompilerServices;

namespace GildedRoseKata;

public class GildedRose
{
    IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach(var item in Items)
        {
            UpdateSellIn(item);

            UpdateQualityForPositiveSellInDate(item);

            if (SellDateExpired(item))
            {
                UpdateQualityForExpiredSellDates(item);
            }

            SetQualityInRange(item);
        }

    }

    private void UpdateQualityForExpiredSellDates(Item item)
    {
        if (Is(item, "Aged Brie"))
        {
            IncreaseQuality(item, 1);
        }
        else if (Is(item, "Backstage passes to a TAFKAL80ETC concert"))
        {
            IncreaseQuality(item, -item.Quality); // quality = 0 for outdated tickets
        }
        else if (Is(item, "Sulfuras, Hand of Ragnaros"))
        {
            // do nothing
        }
        else
        {
            IncreaseQuality(item, -1);
        }
    }

    private void UpdateSellIn(Item item)
    {
        if (!Is(item, "Sulfuras, Hand of Ragnaros"))
            item.SellIn = item.SellIn - 1; // normal case
    }

    private void SetQualityInRange(Item item)
    {
        if (Is(item, "Sulfuras, Hand of Ragnaros"))
        {
            if (item.Quality != 80)
                item.Quality = 80;
        }
        else
        {
            if (item.Quality > 50)
                item.Quality = 50;
            if (!HasPositiveQuality(item))
                item.Quality = 0;
        }
    }

    private void UpdateQualityForPositiveSellInDate(Item item)
    {
        if (Is(item, "Backstage passes to a TAFKAL80ETC concert"))
        {
            if (SellInDateLowerThan(5, item))
                IncreaseQuality(item, 3);

            else if (SellInDateLowerThan(10, item))
                IncreaseQuality(item, 2);

            else
                IncreaseQuality(item, 1);
        }
        else if (Is(item, "Aged Brie"))
        {
            IncreaseQuality(item, 1);
        }
        else if (Is(item, "Sulfuras, Hand of Ragnaros"))
        {
        }
        else
        {
            IncreaseQuality(item, -1); // that's the normal case!!
        }
    }

    private bool Is(Item item, string type){
        return item.Name == type;
    }

    private bool HasPositiveQuality(Item item)
    {
        return item.Quality > 0;
    }

    private bool HasQualityLowerThan(int treshold, Item item)
    {
        return item.Quality < treshold;
    }

    private bool SellDateExpired(Item item){
        return SellInDateLowerThan(0, item);
    }

    private bool SellInDateLowerThan(int treshold, Item item){
        return item.SellIn < treshold;
    }

    private Item IncreaseQuality(Item item, int amount)
    {
        var result = item;
        result.Quality += amount;
        return result;
    }
}