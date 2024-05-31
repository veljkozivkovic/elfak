namespace Zatvor.Entiteti;

public class Zatvorenik
{
    public virtual int Id { get; protected set; }
    public virtual required string Ime { get; set; }
    public virtual required string Prezime { get; set; }
    public virtual string? Adresa { get; set; }
    public virtual char Pol { get; set; }
    public virtual string? StatusUslovnogOtpusta { get; set; }
    public virtual DateTime DatumSledecegSaslusanja{ get; set; }
    public virtual DateTime AdvokatDatum { get; set; }
    public virtual DateTime AdvokatPoslednjiKontakt { get; set; }

    public virtual required ZatvorskaJedinica ZatvorskaJedinica { get; set; }

    public virtual IList<IzvrsenPrestup> IzvrseniPrestupi { get; set; } = [];
    public virtual IList<Poseta> Posete { get; set; } = [];

    public virtual Firma? Firma { get; set; }
    public virtual Advokat? Advokat { get; set; }
}
