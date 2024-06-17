namespace ZatvorLibrary.Entiteti;

internal class OdgovornoLice
{

    protected internal virtual int Id { get; set; }
    protected internal virtual string? Ime { get; set; }
    protected internal virtual string? Prezime { get; set; }

    protected internal virtual Firma? Firma { get; set; }

}
