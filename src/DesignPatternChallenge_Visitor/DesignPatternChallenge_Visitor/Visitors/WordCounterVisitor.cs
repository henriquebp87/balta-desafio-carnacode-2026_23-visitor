using DesignPatternChallenge_Visitor.Elements;

namespace DesignPatternChallenge_Visitor.Visitors
{
    internal class WordCounterVisitor : IDocumentElementVisitor
    {
        private int _result;

        public void Visit(Paragraph paragraph)
        {
            _result += paragraph?.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length ?? 0;
        }

        public void Visit(Image image)
        {
            _result += 0;
        }

        public void Visit(Table table)
        {
            var total = 0;
            var cells = table?.Cells ?? throw new InvalidOperationException();

            foreach (var row in cells)
            {
                foreach (var cell in row)
                {
                    total += cell.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
                }
            }

            _result += total;
        }

        public int GetResult() => _result;
    }
}
