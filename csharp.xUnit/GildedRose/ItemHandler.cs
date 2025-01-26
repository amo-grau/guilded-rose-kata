using System.Diagnostics.CodeAnalysis;
using GildedRoseKata;

public class ItemHandler
{
    private const int TopQualityRange = 50;
    private const int LowQualityRange = 0;

    protected ItemHandler(Item item)
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

    public static ItemHandler CreateFor(Item item)
    {
        switch(item.Name){
            case "Aged Brie":
                return new AgedBrieHandler(item);
            case "Sulfuras, Hand of Ragnaros":
                return new SulfurasHandler(item);
            case "Backstage passes to a TAFKAL80ETC concert":
                return new BackstageTicketsHandler(item);
            default:
                return new ItemHandler(item);
        }
    }
}