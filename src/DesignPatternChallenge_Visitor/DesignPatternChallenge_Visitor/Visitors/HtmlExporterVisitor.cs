using System.Text;
using DesignPatternChallenge_Visitor.Elements;

namespace DesignPatternChallenge_Visitor.Visitors
{
    internal class HtmlExporterVisitor : IDocumentElementVisitor
    {
        private readonly StringBuilder _result = new();

        public void Visit(Paragraph paragraph)
        {
            _result.AppendLine($"<p style='font-family:{paragraph?.FontFamily};font-size:{paragraph?.FontSize}px'>{paragraph?.Text}</p>");
        }

        public void Visit(Image image)
        {
            _result.AppendLine($"<img src='{image?.Url}' width='{image?.Width}' height='{image?.Height}' alt='{image?.Alt}' />");
        }

        public void Visit(Table table)
        {
            _result.AppendLine("<table>");
            var cells = table?.Cells ?? throw new InvalidOperationException();

            foreach (var row in cells)
            {
                _result.AppendLine("<tr>");
                foreach (var cell in row)
                {
                    _result.AppendLine($"<td>{cell}</td>");
                }
                _result.AppendLine("</tr>");
            }

            _result.AppendLine("</table>");
        }

        public string GetResult() => _result.ToString();
    }
}
