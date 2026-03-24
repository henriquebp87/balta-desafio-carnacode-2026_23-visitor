using DesignPatternChallenge_Visitor.Visitors;

namespace DesignPatternChallenge_Visitor.Elements
{
    internal interface IDocumentElement
    {
        void Accept(IDocumentElementVisitor visitor);
    }
}
