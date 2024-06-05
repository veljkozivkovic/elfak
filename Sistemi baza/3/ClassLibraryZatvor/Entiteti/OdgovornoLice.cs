namespace Zatvor.Entiteti;

public class OdgovornoLice
{

    public virtual int Id { get; protected set; }
    public virtual required string Ime { get; set; }
    public virtual required string Prezime { get; set; }

    public virtual required Firma Firma { get; set; }

}
