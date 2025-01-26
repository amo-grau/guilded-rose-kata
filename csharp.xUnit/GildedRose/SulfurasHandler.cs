using System.Data;
using GildedRoseKata;

public class SulfurasHandler : ItemHandler
{
    public SulfurasHandler(Item item) : base(item)
    {
    }

    protected override string Name { get => "Sulfuras, Hand of Ragnaros"; }

    protected override void UpdateSellIn() { }
    protected override void PassedDateUpdate() { }
    protected override void DefaultQualityUpdate() {}
    protected override void SetQualityInRange()
    {
        if (Item.Quality != 80) 
        {
            Item.Quality = 80;
        }
    }
}