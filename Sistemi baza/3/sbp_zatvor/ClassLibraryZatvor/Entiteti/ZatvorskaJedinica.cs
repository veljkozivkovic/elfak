namespace ZatvorLibrary.Entiteti;

internal abstract class ZatvorskaJedinica
{
    protected internal virtual int Id { get; set; }
    protected internal virtual string? Naziv { get; set; }
    protected internal virtual int? Kapacitet { get; set; }
    protected internal virtual string? Adresa { get; set; }

    protected internal virtual int? OtvoreniRezim { get; set; }
    protected internal virtual int? PoluotvoreniRezim { get; set; }
    protected internal virtual int? StrogiRezim { get; set; }

    protected internal virtual IList<Zatvorenik>? Zatvorenici { get; set; }

    protected internal virtual IList<RadiU>? Zaposleni { get; set; }
    protected internal virtual ZaposleniAdministracija? Upravnik { get; set; }

    protected internal virtual IList<TerminPosete>? getTerminiPosete()
    {
        return null;
    }

    protected internal virtual IList<TerminSetnje>? getTerminiSetnje()
    {
        return null;
    }

    internal ZatvorskaJedinica()
    {
        Zatvorenici = new List<Zatvorenik>();
        Zaposleni = new List<RadiU>();
    }

}

internal class OtvorenaZatvorskaJedinica : ZatvorskaJedinica
{
    protected internal virtual string? PeriodZabraneOd { get; set; }
    protected internal virtual string? PeriodZabraneDo { get; set; }

    protected internal virtual IList<Firma>? Firme { get; set; }

    internal OtvorenaZatvorskaJedinica()
    {
        OtvoreniRezim = 1;
        PoluotvoreniRezim = 0;
        StrogiRezim = 0;
        Firme = new List<Firma>();
    }

    protected internal override IList<TerminPosete>? getTerminiPosete()
    {
        return null;
    }

    protected internal override IList<TerminSetnje>? getTerminiSetnje()
    {
        return null;
    }

}

internal class PoluotvorenaZatvorskaJedinica : ZatvorskaJedinica
{
    protected internal virtual string? PeriodZabraneOd { get; set; }
    protected internal virtual string? PeriodZabraneDo { get; set; }

    internal PoluotvorenaZatvorskaJedinica()
    {
        OtvoreniRezim = 0;
        PoluotvoreniRezim = 1;
        StrogiRezim = 0;
    }

    protected internal override IList<TerminPosete>? getTerminiPosete()
    {
        return null;
    }

    protected internal override IList<TerminSetnje>? getTerminiSetnje()
    {
        return null;
    }

}

internal class ZatvorenaZatvorskaJedinica : ZatvorskaJedinica
{
    public virtual IList<TerminSetnje>? TerminiSetnje { get; set; }
    public virtual IList<TerminPosete>? TerminiPosete { get; set; }

    internal ZatvorenaZatvorskaJedinica()
    {
        OtvoreniRezim = 0;
        PoluotvoreniRezim = 0;
        StrogiRezim = 1;
        TerminiSetnje = new List<TerminSetnje>();
        TerminiPosete = new List<TerminPosete>();
    }

    protected internal override IList<TerminPosete>? getTerminiPosete()
    {
        return TerminiPosete;
    }

    protected internal override IList<TerminSetnje>? getTerminiSetnje()
    {
        return TerminiSetnje;
    }

}

internal class OPZatvorskaJedinica : ZatvorskaJedinica
{
    protected internal virtual string? PeriodZabraneOd { get; set; }
    protected internal virtual string? PeriodZabraneDo { get; set; }

    protected internal virtual IList<Firma>? Firme { get; set; }

    internal OPZatvorskaJedinica()
    {
        OtvoreniRezim = 1;
        PoluotvoreniRezim = 1;
        StrogiRezim = 0;
        Firme = new List<Firma>();
    }

    protected internal override IList<TerminPosete>? getTerminiPosete()
    {
        return null;
    }

    protected internal override IList<TerminSetnje>? getTerminiSetnje()
    {
        return null;
    }

}

internal class OZZatvorskaJedinica : ZatvorskaJedinica
{
    protected internal virtual string? PeriodZabraneOd { get; set; }
    protected internal virtual string? PeriodZabraneDo { get; set; }

    protected internal virtual IList<Firma>? Firme { get; set; }

    protected internal virtual IList<TerminSetnje>? TerminiSetnje { get; set; }
    protected internal virtual IList<TerminPosete>? TerminiPosete { get; set; }

    internal OZZatvorskaJedinica()
    {
        OtvoreniRezim = 1;
        PoluotvoreniRezim = 0;
        StrogiRezim = 1;
        Firme = new List<Firma>();
        TerminiSetnje = new List<TerminSetnje>();
        TerminiPosete = new List<TerminPosete>();
    }

    protected internal override IList<TerminPosete>? getTerminiPosete()
    {
        return TerminiPosete;
    }

    protected internal override IList<TerminSetnje>? getTerminiSetnje()
    {
        return TerminiSetnje;
    }

}

internal class PZZatvorskaJedinica : ZatvorskaJedinica
{
    protected internal virtual string? PeriodZabraneOd { get; set; }
    protected internal virtual string? PeriodZabraneDo { get; set; }

    protected internal virtual IList<TerminSetnje>? TerminiSetnje { get; set; }
    protected internal virtual IList<TerminPosete>? TerminiPosete { get; set; }

    internal PZZatvorskaJedinica()
    {
        OtvoreniRezim = 0;
        PoluotvoreniRezim = 1;
        StrogiRezim = 1;
        TerminiSetnje = new List<TerminSetnje>();
        TerminiPosete = new List<TerminPosete>();
    }

    protected internal override IList<TerminPosete>? getTerminiPosete()
    {
        return TerminiPosete;
    }

    protected internal override IList<TerminSetnje>? getTerminiSetnje()
    {
        return TerminiSetnje;
    }

}