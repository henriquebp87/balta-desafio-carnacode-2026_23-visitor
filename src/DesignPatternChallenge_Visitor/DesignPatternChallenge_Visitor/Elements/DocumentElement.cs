using DesignPatternChallenge_Visitor.Visitors;

namespace DesignPatternChallenge_Visitor.Elements;

internal abstract class DocumentElement : IDocumentElement
{
    public abstract void Render();

    public abstract void Accept(IDocumentElementVisitor visitor);
}