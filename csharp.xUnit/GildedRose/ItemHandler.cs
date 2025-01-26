using GildedRoseKata;

public class ItemHandler
{
    protected ItemHandler(Item item)
    {
        Item = item;
    }

    private Item Item { get; set; }

    protected virtual string Name { get => Item.Name; }

    public void Update(){
        UpdateSellIn();
        UpdateQuality();
    }

    private void UpdateSellIn()
    {
        if (Is("Sulfuras, Hand of Ragnaros")) 
        {
            // do nothing
        }
        else
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

    private void DefaultQualityUpdate()
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
        else if (Is("Sulfuras, Hand of Ragnaros"))
        {
        }
        else
        {
            IncreaseQuality(-1); // that's the normal case!!
        }
    }

    private void PassedDateUpdate()
    {
        if (Is("Aged Brie"))
        {
            IncreaseQuality(2);
        }
        else if (Is("Backstage passes to a TAFKAL80ETC concert"))
        {
            IncreaseQuality(-Item.Quality); // quality = 0 for outdated tickets
        }
        else if (Is("Sulfuras, Hand of Ragnaros"))
        {
            // do nothing
        }
        else
        {
            IncreaseQuality(-2);
        }
    }

    private void SetQualityInRange()
    {
        if (Is("Sulfuras, Hand of Ragnaros"))
        {
            if (Item.Quality != 80)
                Item.Quality = 80;
        }
        else
        {
            if (Item.Quality > 50)
                Item.Quality = 50;

            if (Item.Quality < 0)
                Item.Quality = 0;
        }
    }

    private bool SellInDateLowerThan(int treshold){
        return Item.SellIn < treshold;
    }

    private bool SellDatePassed(){
        return SellInDateLowerThan(0);
    }

    private bool Is(string type){
        return Item.Name == type;
    }

    private Item IncreaseQuality(int amount)
    {
        Item.Quality += amount;
        return Item;
    }

    public static ItemHandler CreateFor(Item item)
    {
        return new ItemHandler(item);
    }
}