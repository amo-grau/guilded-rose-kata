using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

public class GildedRose
{
    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }
 
    IList<Item> Items { get; }
    private List<DefaultHandler> Handlers { get => Items.Select(DefaultHandler.CreateFor).ToList(); }

    public void Update()
    {
        Handlers.ForEach(h => h.Update());
    }
}