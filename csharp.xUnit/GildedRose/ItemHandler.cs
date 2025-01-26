using GildedRoseKata;

public class ItemHandler
{
    public ItemHandler(Item item)
    {
        Item = item;
    }

    public Item Item { get; set; }
    
    public void SetQualityInRange()
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

    public bool SellInDateLowerThan(int treshold){
        return Item.SellIn < treshold;
    }

    public bool SellDatePassed(){
        return SellInDateLowerThan(0);
    }

    public bool Is(string type){
        return Item.Name == type;
    }

    public Item IncreaseQuality(int amount)
    {
        Item.Quality += amount;
        return Item;
    }
}