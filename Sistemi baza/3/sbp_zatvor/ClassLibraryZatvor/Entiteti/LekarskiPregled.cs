namespace ZatvorLibrary.Entiteti;

internal class LekarskiPregled
{
    protected internal virtual int Id { get; set; }
    protected internal virtual DateTime? Datum { get; set; }
    protected internal virtual string? NazivUstanove { get; set; }
    protected internal virtual string? AdresaUstanove { get; set; }
    protected internal virtual string? Lekar { get; set; }
    protected internal virtual Zaposleni? Zaposleni { get; set; }
}
