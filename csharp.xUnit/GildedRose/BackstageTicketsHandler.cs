using GildedRoseKata;

public class BackstageTicketsHandler : ItemHandler
{
    public BackstageTicketsHandler(Item item) : base(item)
    {
    }

    protected override string Name { get => "Backstage passes to a TAFKAL80ETC concert"; }
}