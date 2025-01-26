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
            Item.Quality += 3;
        else if (SellInDateLowerThan(10))
            Item.Quality += 2;

        else
            Item.Quality += 1;
    }

    protected override void PassedDateUpdate()
    {
        Item.Quality = 0;
    }

    private bool SellInDateLowerThan(int treshold){
        return Item.SellIn < treshold;
    }
}