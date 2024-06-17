namespace ZatvorLibrary.Entiteti;

internal class Advokat
{
    protected internal virtual string JMBG { get; set; }
    protected internal virtual string? Ime { get; set; }
    protected internal virtual string? Prezime { get; set; }

    protected internal virtual IList<Poseta>? Posete { get; set; }
    protected internal virtual IList<Zatvorenik>? Zatvorenici { get; set; }

    internal Advokat()
    {
        Posete = new List<Poseta>();
        Zatvorenici = new List<Zatvorenik>();
    }

}