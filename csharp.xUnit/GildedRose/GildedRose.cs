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
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (HasPositiveQuality(item))
                {
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        IncreaseQuality(item, -1);
                    }
                }
            }
            else
            {
                if (HasQualityLowerThan(50, item))
                {
                    IncreaseQuality(item, 1);

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            if (HasQualityLowerThan(50, item))
                            {
                                IncreaseQuality(item, 1);
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (HasQualityLowerThan(50, item))
                            {
                                IncreaseQuality(item, 1);
                            }
                        }
                    }
                }
            }

            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (HasPositiveQuality(item))
                        {
                            if (item.Name != "Sulfuras, Hand of Ragnaros")
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

    private bool HasPositiveQuality(Item item)
    {
        return item.Quality > 0;
    }

    private bool HasQualityLowerThan(int treshold, Item item)
    {
        return item.Quality < treshold;
    }

    private Item IncreaseQuality(Item item, int amount)
    {
        var result = item;
        result.Quality += amount;
        return result;
    }
}