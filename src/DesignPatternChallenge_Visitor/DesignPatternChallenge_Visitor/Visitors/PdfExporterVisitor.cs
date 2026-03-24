using System.Text;
using DesignPatternChallenge_Visitor.Elements;

namespace DesignPatternChallenge_Visitor.Visitors
{
    internal class PdfExporterVisitor : IDocumentElementVisitor
    {
        private readonly StringBuilder _result = new();

        public void Visit(Paragraph paragraph)
        {
            _result.AppendLine($"PDF_TEXT({paragraph?.Text}, {paragraph?.FontFamily}, {paragraph?.FontSize})");
        }

        public void Visit(Image image)
        {
            _result.AppendLine($"PDF_IMAGE({image?.Url}, {image?.Width}, {image?.Height})");
        }

        public void Visit(Table table)
        {
            _result.AppendLine($"PDF_TABLE({table?.Rows}, {table?.Columns}, data...)");
        }

        public string GetResult() => _result.ToString();
    }
}
