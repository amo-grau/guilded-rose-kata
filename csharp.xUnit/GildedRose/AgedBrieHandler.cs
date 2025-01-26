using GildedRoseKata;

public class AgedBrieHandler : ItemHandler
{
    public AgedBrieHandler(Item item) : base(item)
    {
    }

    protected override string Name { get => "Aged Brie"; }

    protected override void DefaultQualityUpdate()
    {
        Item.Quality += 1;
    }

    protected override void PassedDateUpdate()
    {
        Item.Quality += 2;
    }
}