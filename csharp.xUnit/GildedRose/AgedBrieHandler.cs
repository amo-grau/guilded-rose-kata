using GildedRoseKata;

public class AgedBrieHandler : ItemHandler
{
    public AgedBrieHandler(Item item) : base(item)
    {
    }

    protected override string Name { get => "Aged Brie"; }
}