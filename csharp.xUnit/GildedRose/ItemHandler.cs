using GildedRoseKata;

public class ItemHandler
{
    public ItemHandler(Item item)
    {
        Item = item;
    }

    public Item Item { get; set; }
    
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