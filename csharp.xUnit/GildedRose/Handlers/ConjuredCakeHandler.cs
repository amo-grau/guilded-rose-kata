using GildedRoseKata;

public class ConjuredCakeHandler : DefaultHandler
{
    public ConjuredCakeHandler(Item item) : base(item)
    {
    }

    protected override string Name => "Conjured Mana Cake";

    protected override void DefaultQualityUpdate()
    {
        base.DefaultQualityUpdate();
        base.DefaultQualityUpdate();
    }

    protected override void PassedDateUpdate()
    {
        base.PassedDateUpdate();
        base.PassedDateUpdate();
    }
}