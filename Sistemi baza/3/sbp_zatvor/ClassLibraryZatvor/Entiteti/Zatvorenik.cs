namespace ZatvorLibrary.Entiteti;

internal class Zatvorenik
{
    protected internal virtual int Id { get; set; }
    protected internal virtual string? Ime { get; set; }
    protected internal virtual string? Prezime { get; set; }
    protected internal virtual string? Adresa { get; set; }
    protected internal virtual char? Pol { get; set; }
    protected internal virtual string? StatusUslovnogOtpusta { get; set; }
    protected internal virtual DateTime? DatumSledecegSaslusanja{ get; set; }
    protected internal virtual DateTime? AdvokatDatum { get; set; }
    protected internal virtual DateTime? AdvokatPoslednjiKontakt { get; set; }

    protected internal virtual ZatvorskaJedinica? ZatvorskaJedinica { get; set; }

    protected internal virtual IList<IzvrsenPrestup>? IzvrseniPrestupi { get; set; }
    protected internal virtual IList<Poseta>? Posete { get; set; }

    protected internal virtual Firma? Firma { get; set; }
    protected internal virtual Advokat? Advokat { get; set; }

    internal Zatvorenik()
    {
        IzvrseniPrestupi = new List<IzvrsenPrestup>();
        Posete = new List<Poseta>();
    }

}
