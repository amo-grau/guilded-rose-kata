﻿using System.Collections.Generic;
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
            if (!Is(item, "Aged Brie") 
                && !Is(item, "Backstage passes to a TAFKAL80ETC concert") 
                && !Is(item, "Sulfuras, Hand of Ragnaros") 
                && HasPositiveQuality(item))
            {
                IncreaseQuality(item, -1); // that's the normal case!!
            }
            else
            {
                if (HasQualityLowerThan(50, item))
                {
                    IncreaseQuality(item, 1);

                    if (Is(item, "Backstage passes to a TAFKAL80ETC concert"))
                    {
                        if (SellInDateLowerThan(11, item))
                        {
                            if (HasQualityLowerThan(50, item))
                            {
                                IncreaseQuality(item, 1);
                            }
                        }

                        if (SellInDateLowerThan(6, item))
                        {
                            if (HasQualityLowerThan(50, item))
                            {
                                IncreaseQuality(item, 1);
                            }
                        }
                    }
                }
            }

            if (!Is(item, "Sulfuras, Hand of Ragnaros"))
            {
                item.SellIn = item.SellIn - 1;
            }

            if (SellInDateLowerThan(0, item))
            {
                if (!Is(item, "Aged Brie"))
                {
                    if (!Is(item, "Backstage passes to a TAFKAL80ETC concert"))
                    {
                        if (HasPositiveQuality(item))
                        {
                            if (!Is(item, "Sulfuras, Hand of Ragnaros"))
                            {
                                IncreaseQuality(item, -1);
                            }
                        }
                    }
                    else
                    {
                        IncreaseQuality(item, -item.Quality);
                    }
                }
                else
                {
                    if (HasQualityLowerThan(50, item))
                    {
                        IncreaseQuality(item, 1);
                    }
                }
            }
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