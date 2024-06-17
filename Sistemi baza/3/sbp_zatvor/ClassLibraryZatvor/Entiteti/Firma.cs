namespace ZatvorLibrary.Entiteti;

internal class Firma
{
    protected internal virtual int PIB { get; set; }
    protected internal virtual string? Ime { get; set; }
    protected internal virtual string? Adresa { get; set; }

    protected internal virtual IList<OdgovornoLice>? OdgovornaLica { get; set; }

    protected internal virtual IList<ZatvorskaJedinica>? ZatvorskeJedinice { get; set; }

    protected internal virtual IList<FirmaTelefon>? Telefoni { get; set; }

    protected internal virtual IList<Zatvorenik>? ZatvoreniciRadnici { get; set; }

    internal Firma()
    {
        OdgovornaLica = new List<OdgovornoLice>();
        ZatvorskeJedinice = new List<ZatvorskaJedinica>();
        Telefoni = new List<FirmaTelefon>();
        ZatvoreniciRadnici = new List<Zatvorenik>();
    }

}
