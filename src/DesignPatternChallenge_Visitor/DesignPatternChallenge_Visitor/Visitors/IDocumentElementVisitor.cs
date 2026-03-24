using DesignPatternChallenge_Visitor.Elements;

namespace DesignPatternChallenge_Visitor.Visitors
{
    internal interface IDocumentElementVisitor
    {
        void Visit(Paragraph paragraph);

        void Visit(Image image);

        void Visit(Table table);
    }
}
