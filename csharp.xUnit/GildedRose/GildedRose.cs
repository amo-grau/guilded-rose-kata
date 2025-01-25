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
            IncreaseQualityForPositiveSellInDate(item);


            if (!Is(item, "Sulfuras, Hand of Ragnaros"))
                item.SellIn = item.SellIn - 1; // normal case

            if (SellDateExpired(item))
            {
                if (!Is(item, "Aged Brie"))
                {
                    if (!Is(item, "Backstage passes to a TAFKAL80ETC concert"))
                    {
                        if (HasPositiveQuality(item))
                        {
                            if (!Is(item, "Sulfuras, Hand of Ragnaros"))
                            {
                                IncreaseQuality(item, -1); // the normal case
                            }
                        }
                    }
                    else
                    {
                        IncreaseQuality(item, -item.Quality); // quality = 0 for outdated tickets
                    }
                }
                else
                {
                    if (HasQualityLowerThan(50, item))
                    {
                        IncreaseQuality(item, 1); // aged brie quality
                    }
                }
            }

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

    }

    private void IncreaseQualityForPositiveSellInDate(Item item)
    {
        if (Is(item, "Backstage passes to a TAFKAL80ETC concert"))
        {
            if (SellInDateLowerThan(6, item))
                IncreaseQuality(item, 3);

            else if (SellInDateLowerThan(11, item))
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