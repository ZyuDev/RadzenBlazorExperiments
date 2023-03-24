namespace RadzenBlazorExperiments.Client.Models;

public class SheetCell
{
    public Guid Uid { get; } = Guid.NewGuid();
    public int Row { get; set; }
    public int Column { get; set; }
    public string Text { get; set; }

    public override bool Equals(object? obj)
    {
        var item = obj as SheetCell;

        if (item == null)
        {
            return false;
        }

        return item.Uid == this.Uid;
    }

    protected bool Equals(SheetCell other)
    {
        return Uid.Equals(other.Uid);
    }

    public override int GetHashCode()
    {
        return Uid.GetHashCode();
    }

    public override string ToString()
    {
        return $"R{Row}C{Column}";
    }
}