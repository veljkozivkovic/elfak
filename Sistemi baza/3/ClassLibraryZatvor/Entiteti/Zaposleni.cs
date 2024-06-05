namespace Zatvor.Entiteti;

public abstract class Zaposleni
{
    public virtual required string JMBG { get; set; }
    public virtual required string Ime { get; set; }
    public virtual required string Prezime { get; set; }
    public virtual DateTime DatumObuke { get; set; }

    public virtual IList<RadiU> RadnaMesta { get; set; } = [];

}

public class ZaposleniAdministracija : Zaposleni
{
    public virtual string? Zanimanje { get; set; }
    public virtual string? StrucnaSprema { get; set; }

    public virtual ZatvorskaJedinica? ZatvorskaJedinica { get; set; }
}

public class Psiholog : Zaposleni
{
    public virtual IList<LekarskiPregled> LekarskiPregledi { get; set; } = [];
}

public class RadnikObezbedjenja : Zaposleni
{
    public virtual IList<LekarskiPregled> LekarskiPregledi { get; set; } = [];
    public virtual IList<ObukaVatrenoOruzje> ObukeVatrenoOruzje { get; set; } = [];
}
