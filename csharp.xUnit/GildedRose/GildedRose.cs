﻿using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata;

public class GildedRose
{
    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }
 
    IList<Item> Items { get; }
    private List<ItemHandler> Handlers { get => Items.Select(HandlerFactory.CreateFor).ToList(); }

    public void Update()
    {
        Handlers.ForEach(h => h.Update());
    }
}