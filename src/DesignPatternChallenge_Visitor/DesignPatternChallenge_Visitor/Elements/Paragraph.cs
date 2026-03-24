using DesignPatternChallenge_Visitor.Visitors;

namespace DesignPatternChallenge_Visitor.Elements;

internal class Paragraph(string text) : DocumentElement
{
    public string Text { get; set; } = text;
    public string FontFamily { get; set; } = "Arial";
    public int FontSize { get; set; } = 12;

    public override void Render()
    {
        Console.WriteLine($"[Parágrafo] {Text}");
    }

    public override void Accept(IDocumentElementVisitor visitor)
    {
        visitor.Visit(this);
    }
}