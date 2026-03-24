using DesignPatternChallenge_Visitor.Visitors;

namespace DesignPatternChallenge_Visitor.Elements;

internal class Image(string url, int width, int height) : DocumentElement
{
    public string Url { get; set; } = url;
    public int Width { get; set; } = width;
    public int Height { get; set; } = height;
    public string Alt { get; set; } = "";

    public override void Render()
    {
        Console.WriteLine($"[Imagem] {Url} ({Width}x{Height})");
    }

    public override void Accept(IDocumentElementVisitor visitor)
    {
        visitor.Visit(this);
    }
}