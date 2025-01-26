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
        this.Items = Items;
    }
 
    IList<Item> Items { get; }
    List<ItemHandler> Handlers { get => Items.Select(item => new ItemHandler(item)).ToList(); }

    public void Update()
    {
        Handlers.ForEach(h => h.UpdateSellIn());
        Handlers.ForEach(UpdateQuality);
    }

    public void UpdateQuality(ItemHandler handler)
    {
        if (handler.SellDatePassed())
            handler.PassedDateUpdate();

        else
            Update(handler);

        handler.SetQualityInRange();
    }

    private void Update(ItemHandler handler)
    {
        if (handler.Is("Backstage passes to a TAFKAL80ETC concert"))
        {
            if (handler.SellInDateLowerThan(5))
                handler.IncreaseQuality(3);

            else if (handler.SellInDateLowerThan(10))
                handler.IncreaseQuality(2);

            else
                handler.IncreaseQuality(1);
        }
        else if (handler.Is("Aged Brie"))
        {
            handler.IncreaseQuality(1);
        }
        else if (handler.Is("Sulfuras, Hand of Ragnaros"))
        {
        }
        else
        {
            handler.IncreaseQuality(-1); // that's the normal case!!
        }
    }
}