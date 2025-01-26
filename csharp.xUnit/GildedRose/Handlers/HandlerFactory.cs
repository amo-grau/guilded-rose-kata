using GildedRoseKata;

public static class HandlerFactory
{
    public static ItemHandler CreateFor(Item item) // todo: use type code instead of strings and use logic to make the types more abstract e.g. conjuredHandler instead of ConjuredManaCake handler"
    {
        switch(item.Name){
            case "Aged Brie":
                return new AgedBrieHandler(item);
            case "Sulfuras, Hand of Ragnaros":
                return new SulfurasHandler(item);
            case "Backstage passes to a TAFKAL80ETC concert":
                return new BackstageTicketsHandler(item);
            case "Conjured Mana Cake":
                return new ConjuredCakeHandler(item);
            default:
                return new DefaultHandler(item);
        }
    }
}