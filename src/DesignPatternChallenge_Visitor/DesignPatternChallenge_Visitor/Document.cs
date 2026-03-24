using DesignPatternChallenge_Visitor.Elements;
using DesignPatternChallenge_Visitor.Visitors;

namespace DesignPatternChallenge;

internal class Document(string title)
{
    public string Title { get; set; } = title;
    public List<DocumentElement> Elements { get; set; } = [];

    public void AddElement(DocumentElement element)
    {
        Elements.Add(element);
    }

    public void Accept(IDocumentElementVisitor visitor)
    {
        foreach (var element in Elements)
        {
            element.Accept(visitor);
        }
    }
}