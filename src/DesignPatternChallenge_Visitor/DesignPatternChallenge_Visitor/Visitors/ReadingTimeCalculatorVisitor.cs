using DesignPatternChallenge_Visitor.Elements;

namespace DesignPatternChallenge_Visitor.Visitors
{
    internal class ReadingTimeCalculatorVisitor : IDocumentElementVisitor
    {
        private readonly WordCounterVisitor _wordCounterVisitor = new();
        private double _result;

        public void Visit(Paragraph paragraph)
        {
            paragraph.Accept(_wordCounterVisitor);
            _result += _wordCounterVisitor.GetResult() / 180.0;
        }

        public void Visit(Image image)
        {
            _result += 0;
        }

        public void Visit(Table table)
        {
            table.Accept(_wordCounterVisitor);
            _result += _wordCounterVisitor.GetResult() / 250.0;
        }

        public double GetResult() => _result;
    }
}
