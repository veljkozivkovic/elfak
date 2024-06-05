namespace Zatvor.Entiteti;

public class Firma
{
    public virtual int PIB { get; set; }
    public virtual required string Ime { get; set; }
    public virtual required string Adresa { get; set; }

    public virtual IList<OdgovornoLice> OdgovornaLica { get; set; } = [];

    public virtual IList<ZatvorskaJedinica> ZatvorskeJedinice { get; set; } = [];

    public virtual IList<FirmaTelefon> Telefoni { get; set; } = [];

    public virtual IList<Zatvorenik> ZatvoreniciRadnici { get; set; } = [];
}
