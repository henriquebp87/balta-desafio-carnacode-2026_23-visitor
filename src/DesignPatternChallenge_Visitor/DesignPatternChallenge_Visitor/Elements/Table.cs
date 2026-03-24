using DesignPatternChallenge_Visitor.Visitors;

namespace DesignPatternChallenge_Visitor.Elements;

internal class Table : DocumentElement
{
    public List<List<string>> Cells { get; set; }
    public int Rows { get; set; }
    public int Columns { get; set; }

    public Table(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Cells = [];

        for (var i = 0; i < rows; i++)
        {
            var row = new List<string>();
            for (var j = 0; j < columns; j++)
            {
                row.Add($"Cell {i},{j}");
            }
            Cells.Add(row);
        }
    }

    public override void Render()
    {
        Console.WriteLine($"[Tabela] {Rows}x{Columns}");
    }

    public override void Accept(IDocumentElementVisitor visitor)
    {
        visitor.Visit(this);
    }
}