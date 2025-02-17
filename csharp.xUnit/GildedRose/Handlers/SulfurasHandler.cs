using GildedRoseKata;

public class SulfurasHandler : DefaultHandler
{
    private const int QualityValue = 80;

    public SulfurasHandler(Item item) : base(item)
    {
    }

    protected override string Name { get => "Sulfuras, Hand of Ragnaros"; }

    protected override void UpdateSellIn() { }
    protected override void PassedDateUpdate() { }
    protected override void DefaultQualityUpdate() { }
    protected override void SetQualityInRange()
    {
        if (Item.Quality != QualityValue) 
        {
            Item.Quality = QualityValue;
        }
    }
}