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
            handler.DefaultQualityUpdate();;

        handler.SetQualityInRange();
    }
}