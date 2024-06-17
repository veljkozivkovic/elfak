namespace ZatvorLibrary.Mapiranja;

internal class ZaposleniMapiranja : ClassMap<Zaposleni>
{
    public ZaposleniMapiranja()
    {
        Table("ZAPOSLENI");

        Id(x => x.JMBG, "JMBG").GeneratedBy.Assigned();

        DiscriminateSubClassesOnColumn("TIP_ZAPOSLENOG");

        Map(x => x.Ime, "IME");
        Map(x => x.Prezime, "PREZIME");
        Map(x => x.DatumObuke, "DATUM_OBUKE");
        
        HasMany(x=> x.RadnaMesta)
            .KeyColumn("ZAPOSLENI_JMBG")
            .Cascade.All()
            .Inverse();
    }
}

internal class ZaposleniAdministracijaMapiranja : SubclassMap<ZaposleniAdministracija>
{
    public ZaposleniAdministracijaMapiranja()
    {
        DiscriminatorValue("administracija");

        Map(x => x.Zanimanje, "ZANIMANJE");
        Map(x => x.StrucnaSprema, "STRUCNA_SPREMA");

        HasOne(x => x.ZatvorskaJedinica).PropertyRef(x => x.Upravnik);
    }
}

internal class PsihologMapiranja : SubclassMap<Psiholog>
{
    public PsihologMapiranja()
    {
        DiscriminatorValue("psiholog");

        HasMany(x => x.LekarskiPregledi)
                .KeyColumn("ZAPOSLENI_JMBG")
                .Cascade.All()
                .Inverse();
    }
}

internal class RadnikObezbedjenjaMapiranja : SubclassMap<RadnikObezbedjenja>
{
    public RadnikObezbedjenjaMapiranja()
    {
        DiscriminatorValue("obezbeđenje");

        HasMany(x => x.LekarskiPregledi)
                .KeyColumn("ZAPOSLENI_JMBG")
                .Cascade.All()
                .Inverse();

        HasMany(x => x.ObukeVatrenoOruzje)
                .KeyColumn("RADNIK_OBEZBEDJENJA_JMBG")
                .Cascade.All()
                .Inverse();
    }
}