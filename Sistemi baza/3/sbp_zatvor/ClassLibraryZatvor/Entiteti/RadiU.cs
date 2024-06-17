namespace ZatvorLibrary.Entiteti;

internal class RadiU
{
    protected internal virtual int Id { get; set; }
    protected internal virtual DateTime? DatumPocetkaRada { get; set; }
    protected internal virtual string? NazivRadnogMesta { get; set; }

    protected internal virtual Zaposleni? Zaposleni { get; set; }
    protected internal virtual ZatvorskaJedinica? ZatvorskaJedinica { get; set; }

}
