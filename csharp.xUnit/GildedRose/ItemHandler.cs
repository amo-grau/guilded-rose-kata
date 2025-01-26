using System.Diagnostics.CodeAnalysis;
using GildedRoseKata;

public class ItemHandler
{
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

    protected virtual void DefaultQualityUpdate()
    {
        if (Is("Backstage passes to a TAFKAL80ETC concert"))
        {
            if (SellInDateLowerThan(5))
                IncreaseQuality(3);

            else if (SellInDateLowerThan(10))
                IncreaseQuality(2);

            else
                IncreaseQuality(1);
        }
        else if (Is("Aged Brie"))
        {
            IncreaseQuality(1);
        }
        else
        {
            IncreaseQuality(-1); // that's the normal case!!
        }
    }

    protected virtual void PassedDateUpdate()
    {
        if (Is("Aged Brie"))
        {
            IncreaseQuality(2);
        }
        else if (Is("Backstage passes to a TAFKAL80ETC concert"))
        {
            IncreaseQuality(-Item.Quality); // quality = 0 for outdated tickets
        }
        else
        {
            IncreaseQuality(-2);
        }
    }

    protected virtual void SetQualityInRange()
    {
        if (Item.Quality > 50)
            Item.Quality = 50;

        if (Item.Quality < 0)
            Item.Quality = 0;
    }

    private bool SellInDateLowerThan(int treshold){
        return Item.SellIn < treshold;
    }

    private bool SellDatePassed(){
        return SellInDateLowerThan(0);
    }

    private bool Is(string type){
        return Name == type;
    }

    private Item IncreaseQuality(int amount)
    {
        Item.Quality += amount;
        return Item;
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