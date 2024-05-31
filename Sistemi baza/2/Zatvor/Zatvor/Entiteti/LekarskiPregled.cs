namespace Zatvor.Entiteti;

public class LekarskiPregled
{
    public virtual int Id { get; protected set; }
    public virtual DateTime Datum { get; set; }
    public virtual required string NazivUstanove { get; set; }
    public virtual required string AdresaUstanove { get; set; }
    public virtual required string Lekar { get; set; }
    public virtual required Zaposleni Zaposleni { get; set; }
}
