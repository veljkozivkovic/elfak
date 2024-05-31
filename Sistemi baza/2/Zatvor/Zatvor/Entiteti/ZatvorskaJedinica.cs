namespace Zatvor.Entiteti;

public abstract class ZatvorskaJedinica
{
    public virtual int Id { get; protected set; }
    public virtual required string Naziv { get; set; }
    public virtual int Kapacitet { get; set; }
    public virtual required string Adresa { get; set; }

    public virtual int OtvoreniRezim { get; protected set; }
    public virtual int PoluotvoreniRezim { get; protected set; }
    public virtual int StrogiRezim { get; protected set; }

    public virtual IList<Zatvorenik> Zatvorenici { get; set; } = [];

    public virtual IList<RadiU> Zaposleni { get; set; } = [];
    public virtual ZaposleniAdministracija? Upravnik { get; set; }

    public virtual IList<TerminPosete>? getTerminiPosete()
    {
        return null;
    }

    public virtual IList<TerminSetnje>? getTerminiSetnje()
    {
        return null;
    }

}

public class OtvorenaZatvorskaJedinica : ZatvorskaJedinica, ZatvorZabranaInterface
{
    public virtual string? PeriodZabraneOd { get; set; }
    public virtual string? PeriodZabraneDo { get; set; }

    public virtual IList<Firma> Firme { get; set; } = [];

    public OtvorenaZatvorskaJedinica() : base()
    {
        OtvoreniRezim = 1;
        PoluotvoreniRezim = 0;
        StrogiRezim = 0;
    }

    public override IList<TerminPosete>? getTerminiPosete()
    {
        return null;
    }

    public override IList<TerminSetnje>? getTerminiSetnje()
    {
        return null;
    }

}

public class PoluotvorenaZatvorskaJedinica : ZatvorskaJedinica, ZatvorZabranaInterface
{
    public virtual string? PeriodZabraneOd { get; set; }
    public virtual string? PeriodZabraneDo { get; set; }

    public PoluotvorenaZatvorskaJedinica() : base()
    {
        OtvoreniRezim = 0;
        PoluotvoreniRezim = 1;
        StrogiRezim = 0;
    }

    public override IList<TerminPosete>? getTerminiPosete()
    {
        return null;
    }

    public override IList<TerminSetnje>? getTerminiSetnje()
    {
        return null;
    }

}

public class ZatvorenaZatvorskaJedinica : ZatvorskaJedinica
{
    public virtual IList<TerminSetnje> TerminiSetnje { get; set; } = [];
    public virtual IList<TerminPosete> TerminiPosete { get; set; } = [];

    public ZatvorenaZatvorskaJedinica() : base()
    {
        OtvoreniRezim = 0;
        PoluotvoreniRezim = 0;
        StrogiRezim = 1;
    }

    public override IList<TerminPosete>? getTerminiPosete()
    {
        return TerminiPosete;
    }

    public override IList<TerminSetnje>? getTerminiSetnje()
    {
        return TerminiSetnje;
    }

}

public class OPZatvorskaJedinica : ZatvorskaJedinica, ZatvorZabranaInterface
{
    public virtual string? PeriodZabraneOd { get; set; }
    public virtual string? PeriodZabraneDo { get; set; }

    public virtual IList<Firma> Firme { get; set; } = [];

    public OPZatvorskaJedinica() : base()
    {
        OtvoreniRezim = 1;
        PoluotvoreniRezim = 1;
        StrogiRezim = 0;
    }

    public override IList<TerminPosete>? getTerminiPosete()
    {
        return null;
    }

    public override IList<TerminSetnje>? getTerminiSetnje()
    {
        return null;
    }

}

public class OZZatvorskaJedinica : ZatvorskaJedinica, ZatvorZabranaInterface
{
    public virtual string? PeriodZabraneOd { get; set; }
    public virtual string? PeriodZabraneDo { get; set; }

    public virtual IList<Firma> Firme { get; set; } = [];

    public virtual IList<TerminSetnje> TerminiSetnje { get; set; } = [];
    public virtual IList<TerminPosete> TerminiPosete { get; set; } = [];

    public OZZatvorskaJedinica() : base()
    {
        OtvoreniRezim = 1;
        PoluotvoreniRezim = 0;
        StrogiRezim = 1;
    }

    public override IList<TerminPosete>? getTerminiPosete()
    {
        return TerminiPosete;
    }

    public override IList<TerminSetnje>? getTerminiSetnje()
    {
        return TerminiSetnje;
    }

}

public class PZZatvorskaJedinica : ZatvorskaJedinica, ZatvorZabranaInterface
{
    public virtual string? PeriodZabraneOd { get; set; }
    public virtual string? PeriodZabraneDo { get; set; }

    public virtual IList<TerminSetnje> TerminiSetnje { get; set; } = [];
    public virtual IList<TerminPosete> TerminiPosete { get; set; } = [];

    public PZZatvorskaJedinica() : base()
    {
        OtvoreniRezim = 0;
        PoluotvoreniRezim = 1;
        StrogiRezim = 1;
    }

    public override IList<TerminPosete>? getTerminiPosete()
    {
        return TerminiPosete;
    }

    public override IList<TerminSetnje>? getTerminiSetnje()
    {
        return TerminiSetnje;
    }

}