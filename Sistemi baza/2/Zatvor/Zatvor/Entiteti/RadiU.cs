namespace Zatvor.Entiteti;

public class RadiU
{
    public virtual int Id { get; protected set; }
    public virtual DateTime DatumPocetkaRada { get; set; }
    public virtual required string NazivRadnogMesta { get; set; }

    public virtual required Zaposleni Zaposleni { get; set; }
    public virtual required ZatvorskaJedinica ZatvorskaJedinica { get; set; }

}
