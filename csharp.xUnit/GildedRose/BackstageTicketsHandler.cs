using GildedRoseKata;

public class BackstageTicketsHandler : ItemHandler
{
    public BackstageTicketsHandler(Item item) : base(item)
    {
    }

    protected override string Name { get => "Backstage passes to a TAFKAL80ETC concert"; }

    protected override void DefaultQualityUpdate()
    {
        if (SellInDateLowerThan(5))
            IncreaseQuality(3);

        else if (SellInDateLowerThan(10))
            IncreaseQuality(2);

        else
            IncreaseQuality(1);
    }

    protected override void PassedDateUpdate()
    {
        IncreaseQuality(-Item.Quality); // quality = 0 for outdated tickets
    }
}