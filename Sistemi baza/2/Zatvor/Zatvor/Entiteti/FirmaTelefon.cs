namespace Zatvor.Entiteti;

public class FirmaTelefon
{
    public virtual int Id { get; protected set; }
    public virtual required string BrojTelefona { get; set; }
    public virtual required Firma Firma { get; set; }
}
