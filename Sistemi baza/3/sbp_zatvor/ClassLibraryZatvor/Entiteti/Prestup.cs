namespace ZatvorLibrary.Entiteti;

internal class Prestup
{
    protected internal virtual int Id { get; set; }
    protected internal virtual string? Naziv { get; set; }
    protected internal virtual string? Kategorija { get; set; }
    protected internal virtual string? Opis { get; set; }
    protected internal virtual string? MinKazna { get; set; }
    protected internal virtual string? MaxKazna { get; set; }

    protected internal virtual IList<IzvrsenPrestup>? IzvrseniPrestupi { get; set; }

    internal Prestup()
    {
        IzvrseniPrestupi = new List<IzvrsenPrestup>();
    }

}
