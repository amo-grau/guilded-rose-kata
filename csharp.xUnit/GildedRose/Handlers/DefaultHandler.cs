using GildedRoseKata;

public class DefaultHandler : ItemHandler
{
    private const int TopQualityRange = 50;
    private const int LowQualityRange = 0;

    public DefaultHandler(Item item)
    {
        Item = item;
    }

    protected Item Item { get; set; }

    protected virtual string Name { get => Item.Name; }

    public void Update(){
        UpdateSellIn();
        UpdateQuality();
    }

    protected virtual void UpdateSellIn()
    {
        Item.SellIn = Item.SellIn - 1;
    }

    private void UpdateQuality()
    {
        if (SellDatePassed())
            PassedDateUpdate();

        else
            DefaultQualityUpdate();;

        SetQualityInRange();
    }

    private bool SellDatePassed(){
        return Item.SellIn < 0;
    }

    protected virtual void DefaultQualityUpdate()
    {
        Item.Quality -= 1;
    }

    protected virtual void PassedDateUpdate()
    {
        Item.Quality -= 2;
    }

    protected virtual void SetQualityInRange()
    {
        if (Item.Quality > TopQualityRange)
            Item.Quality = TopQualityRange;

        if (Item.Quality < LowQualityRange)
            Item.Quality = LowQualityRange;
    }
}