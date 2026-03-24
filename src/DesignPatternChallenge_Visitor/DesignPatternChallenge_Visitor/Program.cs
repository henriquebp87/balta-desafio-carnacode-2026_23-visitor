// DESAFIO: Sistema de Relatórios para Estrutura de Documentos
// PROBLEMA: Um sistema de documentos tem diferentes tipos de elementos (Parágrafo, Imagem, Tabela)
// e precisa realizar múltiplas operações (exportar HTML, PDF, contar palavras, validar).
// O código anterior adicionava cada operação como método em cada classe, violando Open/Closed Principle.

using DesignPatternChallenge_Visitor.Elements;
using DesignPatternChallenge_Visitor.Visitors;

namespace DesignPatternChallenge;

internal class Program
{
    // Contexto: Sistema de documentos onde novos tipos de operações precisam ser
    // adicionados frequentemente, mas tipos de elementos são relativamente estáveis

    static void Main(string[] args)
    {
        Console.WriteLine("=== Sistema de Documentos ===\n");

        var doc = new Document("Relatório Anual");

        doc.AddElement(new Paragraph("Este é o relatório anual da empresa."));
        doc.AddElement(new Image("grafico.png", 800, 600));
        doc.AddElement(new Paragraph("Abaixo os resultados financeiros do ano:"));
        doc.AddElement(new Table(3, 4));
        doc.AddElement(new Paragraph("Conclusão do relatório com recomendações."));

        Console.WriteLine($"Documento: {doc.Title}");
        Console.WriteLine($"Elementos: {doc.Elements.Count}\n");

        Console.WriteLine("=== Operações no Documento ===");

        var wordCounterVisitor = new WordCounterVisitor();
        doc.Accept(wordCounterVisitor);
        var totalWords = wordCounterVisitor.GetResult();
        Console.WriteLine($"Total de palavras: {totalWords}");

        var validatorVisitor = new ValidatorVisitor();
        doc.Accept(validatorVisitor);
        var isValid = validatorVisitor.GetResult();
        Console.WriteLine($"Documento válido: {isValid}");

        Console.WriteLine("\n=== Exportação HTML (amostra) ===");
        var htmlExporter = new HtmlExporterVisitor();
        doc.Accept(htmlExporter);
        var html = htmlExporter.GetResult();
        Console.WriteLine(html[..Math.Min(300, html.Length)] + "...");

        Console.WriteLine("\n=== Exportação PDF (amostra) ===");
        var pdfExporter = new PdfExporterVisitor();
        doc.Accept(pdfExporter);
        var pdf = pdfExporter.GetResult();
        Console.WriteLine(pdf[..Math.Min(150, pdf.Length)] + "...");

        Console.WriteLine("\n=== Tempo restante de leitura ===");
        var readingTimeVisitor = new ReadingTimeCalculatorVisitor();
        doc.Accept(readingTimeVisitor);
        var readingTime = readingTimeVisitor.GetResult();
        Console.WriteLine($"Tempo restante estimado de leitura: {readingTime:F2} minutos");
    }
}