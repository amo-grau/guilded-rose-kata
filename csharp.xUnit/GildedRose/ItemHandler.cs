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
}