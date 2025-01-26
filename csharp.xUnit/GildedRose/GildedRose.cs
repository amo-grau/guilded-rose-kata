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
        var items = ItemHandlers.Select(handler=> handler.Item).ToList();
        items.ForEach(UpdateSellIn);
        items.ForEach(UpdateQuality);
    }

    private void UpdateQuality(Item item)
    {
        var handler = new ItemHandler(item);
        if (SellDatePassed(handler.Item))
            PassedDateUpdate(handler.Item);

        else
            Update(handler.Item);

        SetQualityInRange(handler.Item);
    }

    private void Update(Item item)
    {
        var handler = new ItemHandler(item);

        if (Is(handler.Item, "Backstage passes to a TAFKAL80ETC concert"))
        {
            if (SellInDateLowerThan(5, handler.Item))
                IncreaseQuality(handler.Item, 3);

            else if (SellInDateLowerThan(10, handler.Item))
                IncreaseQuality(handler.Item, 2);

            else
                IncreaseQuality(handler.Item, 1);
        }
        else if (Is(handler.Item, "Aged Brie"))
        {
            IncreaseQuality(handler.Item, 1);
        }
        else if (Is(handler.Item, "Sulfuras, Hand of Ragnaros"))
        {
        }
        else
        {
            IncreaseQuality(handler.Item, -1); // that's the normal case!!
        }
    }

    private void PassedDateUpdate(Item item)
    {
        var handler = new ItemHandler(item);

        if (Is(handler.Item, "Aged Brie"))
        {
            IncreaseQuality(handler.Item, 2);
        }
        else if (Is(handler.Item, "Backstage passes to a TAFKAL80ETC concert"))
        {
            IncreaseQuality(handler.Item, -item.Quality); // quality = 0 for outdated tickets
        }
        else if (Is(handler.Item, "Sulfuras, Hand of Ragnaros"))
        {
            // do nothing
        }
        else
        {
            IncreaseQuality(handler.Item, -2);
        }
    }

    private void UpdateSellIn(Item item)
    {
        var handler = new ItemHandler(item);
        if (Is(handler.Item, "Sulfuras, Hand of Ragnaros")) 
        {
            // do nothing
        }
        else
            handler.Item.SellIn = handler.Item.SellIn - 1;
    }

    private void SetQualityInRange(Item item)
    {
        var handler = new ItemHandler(item);
        if (Is(handler.Item, "Sulfuras, Hand of Ragnaros"))
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

    private bool Is(Item item, string type){
        var handler = new ItemHandler(item);
        return handler.Item.Name == type;
    }
    
    private bool SellDatePassed(Item item){
        var handler = new ItemHandler(item);
        return SellInDateLowerThan(0, handler.Item);
    }

    private bool SellInDateLowerThan(int treshold, Item item){
        var handler = new ItemHandler(item);
        return handler.Item.SellIn < treshold;
    }

    private Item IncreaseQuality(Item item, int amount)
    {
        var handler = new ItemHandler(item);
        var result = handler.Item;
        result.Quality += amount;
        return result;
    }
}