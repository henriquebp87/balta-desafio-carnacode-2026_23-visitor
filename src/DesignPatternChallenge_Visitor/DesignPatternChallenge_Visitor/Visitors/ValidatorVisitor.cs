using DesignPatternChallenge_Visitor.Elements;

namespace DesignPatternChallenge_Visitor.Visitors
{
    internal class ValidatorVisitor : IDocumentElementVisitor
    {
        private bool _result = true;

        public void Visit(Paragraph paragraph)
        {
            _result &= !string.IsNullOrEmpty(paragraph?.Text) && paragraph.Text.Length < 1000;
        }

        public void Visit(Image image)
        {
            _result &= !string.IsNullOrEmpty(image?.Url) && image is { Width: > 0, Height: > 0 };
        }

        public void Visit(Table table)
        {
            _result &= table is { Rows: > 0, Columns: > 0 } && table.Cells.Count == table.Rows;
        }

        public bool GetResult() => _result;
    }
}
