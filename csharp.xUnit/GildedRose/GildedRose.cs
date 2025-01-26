using System.Collections.Generic;
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
        this.Items = Items.ToList();
        ItemHandlers = this.Items.Select(item => new ItemHandler(item)).ToList();
    }
 
    List<Item> Items { get; }
    List<ItemHandler> ItemHandlers { get; }

    public void Update()
    {
        ItemHandlers.ForEach(UpdateSellIn);
        ItemHandlers.ForEach(UpdateQuality);
    }

    public void UpdateQuality(ItemHandler handler)
    {
        if (SellDatePassed(handler))
            PassedDateUpdate(handler);

        else
            Update(handler);

        SetQualityInRange(handler);
    }

    private void Update(ItemHandler handler)
    {
        if (Is(handler, "Backstage passes to a TAFKAL80ETC concert"))
        {
            if (SellInDateLowerThan(5, handler))
                IncreaseQuality(handler, 3);

            else if (SellInDateLowerThan(10, handler))
                IncreaseQuality(handler, 2);

            else
                IncreaseQuality(handler, 1);
        }
        else if (Is(handler, "Aged Brie"))
        {
            IncreaseQuality(handler, 1);
        }
        else if (Is(handler, "Sulfuras, Hand of Ragnaros"))
        {
        }
        else
        {
            IncreaseQuality(handler, -1); // that's the normal case!!
        }
    }

    private void PassedDateUpdate(ItemHandler handler)
    {
        if (Is(handler, "Aged Brie"))
        {
            IncreaseQuality(handler, 2);
        }
        else if (Is(handler, "Backstage passes to a TAFKAL80ETC concert"))
        {
            IncreaseQuality(handler, -handler.Item.Quality); // quality = 0 for outdated tickets
        }
        else if (Is(handler, "Sulfuras, Hand of Ragnaros"))
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
        if (Is(handler, "Sulfuras, Hand of Ragnaros")) 
        {
            // do nothing
        }
        else
            handler.Item.SellIn = handler.Item.SellIn - 1;
    }

    private void SetQualityInRange(ItemHandler handler)
    {
        if (Is(handler, "Sulfuras, Hand of Ragnaros"))
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

    private bool Is(ItemHandler handler, string type){
        return handler.Item.Name == type;
    }
    
    private bool SellDatePassed(ItemHandler handler){
        return SellInDateLowerThan(0, handler);
    }

    private bool SellInDateLowerThan(int treshold, ItemHandler handler){
        return handler.Item.SellIn < treshold;
    }

    private Item IncreaseQuality(ItemHandler handler, int amount)
    {
        var result = handler.Item;
        result.Quality += amount;
        return result;
    }
}