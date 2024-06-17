namespace ZatvorLibrary.Entiteti;

internal abstract class Zaposleni
{
    protected internal virtual string JMBG { get; set; }
    protected internal virtual string? Ime { get; set; }
    protected internal virtual string? Prezime { get; set; }
    protected internal virtual DateTime? DatumObuke { get; set; }

    protected internal virtual IList<RadiU>? RadnaMesta { get; set; }

    internal Zaposleni()
    {
        RadnaMesta = new List<RadiU>();
    }

}

internal class ZaposleniAdministracija : Zaposleni
{
    protected internal virtual string? Zanimanje { get; set; }
    protected internal virtual string? StrucnaSprema { get; set; }

    protected internal virtual ZatvorskaJedinica? ZatvorskaJedinica { get; set; }

    internal ZaposleniAdministracija()
    {
    }

}

internal class Psiholog : Zaposleni
{
    protected internal virtual IList<LekarskiPregled>? LekarskiPregledi { get; set; } = [];

    internal Psiholog()
    {
        LekarskiPregledi = new List<LekarskiPregled>();
    }

}

internal class RadnikObezbedjenja : Zaposleni
{
    protected internal virtual IList<LekarskiPregled>? LekarskiPregledi { get; set; }
    protected internal virtual IList<ObukaVatrenoOruzje>? ObukeVatrenoOruzje { get; set; }

    internal RadnikObezbedjenja()
    {
        LekarskiPregledi = new List<LekarskiPregled>();
        ObukeVatrenoOruzje = new List<ObukaVatrenoOruzje>();
    }

}
