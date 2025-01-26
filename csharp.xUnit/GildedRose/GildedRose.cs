﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GildedRoseKata;

public class GildedRose
{
    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }
 
    IList<Item> Items { get; }
    List<ItemHandler> Handlers { get => Items.Select(item => new ItemHandler(item)).ToList(); }

    public void Update()
    {
        Handlers.ForEach(UpdateSellIn);
        Handlers.ForEach(UpdateQuality);
    }

    public void UpdateQuality(ItemHandler handler)
    {
        if (handler.SellDatePassed())
            PassedDateUpdate(handler);

        else
            Update(handler);

        SetQualityInRange(handler);
    }

    private void Update(ItemHandler handler)
    {
        if (handler.Is("Backstage passes to a TAFKAL80ETC concert"))
        {
            if (handler.SellInDateLowerThan(5))
                IncreaseQuality(handler, 3);

            else if (handler.SellInDateLowerThan(10))
                IncreaseQuality(handler, 2);

            else
                IncreaseQuality(handler, 1);
        }
        else if (handler.Is("Aged Brie"))
        {
            IncreaseQuality(handler, 1);
        }
        else if (handler.Is("Sulfuras, Hand of Ragnaros"))
        {
        }
        else
        {
            IncreaseQuality(handler, -1); // that's the normal case!!
        }
    }

    private void PassedDateUpdate(ItemHandler handler)
    {
        if (handler.Is("Aged Brie"))
        {
            IncreaseQuality(handler, 2);
        }
        else if (handler.Is("Backstage passes to a TAFKAL80ETC concert"))
        {
            IncreaseQuality(handler, -handler.Item.Quality); // quality = 0 for outdated tickets
        }
        else if (handler.Is("Sulfuras, Hand of Ragnaros"))
        {
            // do nothing
        }
        else
        {
            IncreaseQuality(handler, -2);
        }
    }

    private void UpdateSellIn(ItemHandler handler)
    {
        if (handler.Is("Sulfuras, Hand of Ragnaros")) 
        {
            // do nothing
        }
        else
            handler.Item.SellIn = handler.Item.SellIn - 1;
    }

    private void SetQualityInRange(ItemHandler handler)
    {
        if (handler.Is("Sulfuras, Hand of Ragnaros"))
        {
            if (handler.Item.Quality != 80)
                handler.Item.Quality = 80;
        }
        else
        {
            if (handler.Item.Quality > 50)
                handler.Item.Quality = 50;

            if (handler.Item.Quality < 0)
                handler.Item.Quality = 0;
        }
    }
    
    private Item IncreaseQuality(ItemHandler handler, int amount)
    {
        var result = handler.Item;
        result.Quality += amount;
        return result;
    }
}