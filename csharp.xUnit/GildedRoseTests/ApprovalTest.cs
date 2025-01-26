using GildedRoseKata;

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using VerifyXunit;

using Xunit;

namespace GildedRoseTests;

public class ApprovalTest
{
    [Fact]
    public Task Foo()
    {
        Item[] items = { 
            new Item { Name = "foo", SellIn = 0, Quality = 0 },              
            new Item { Name= "+5 Dexterity Vest", SellIn=10, Quality=20 },
            new Item { Name= "Aged Brie", SellIn=2, Quality=0 },
            new Item { Name= "Elixir of the Mongoose", SellIn=5, Quality=7 },
            new Item { Name= "Sulfuras, Hand of Ragnaros", SellIn=0, Quality=80 },
            new Item { Name= "Sulfuras, Hand of Ragnaros", SellIn=-1, Quality=80 },
            new Item { Name= "Backstage passes to a TAFKAL80ETC concert", SellIn=15, Quality=20 },
            new Item { Name= "Backstage passes to a TAFKAL80ETC concert", SellIn=10, Quality=49 },
            new Item { Name= "Backstage passes to a TAFKAL80ETC concert", SellIn=5, Quality=49 },
            new Item { Name= "Conjured Mana Cake", SellIn=3, Quality=6 }
            };
        GildedRose app = new GildedRose(items);
        app.Update();
        
        return Verifier.Verify(items);
    }
    
    [Fact]
    public Task ThirtyDays()
    {
        var fakeoutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeoutput));
        Console.SetIn(new StringReader($"a{Environment.NewLine}"));

        Program.Main(new string[] { "30" });
        var output = fakeoutput.ToString();

        return Verifier.Verify(output);
    }
}