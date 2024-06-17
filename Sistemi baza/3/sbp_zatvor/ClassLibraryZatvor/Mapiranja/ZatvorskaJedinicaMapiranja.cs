namespace ZatvorLibrary.Mapiranja;

internal class ZatvorskaJedinicaMapiranja : ClassMap<ZatvorskaJedinica>
{
    public ZatvorskaJedinicaMapiranja()
    {
        Table("ZATVORSKA_JEDINICA");

        Id(x => x.Id, "SIFRA").GeneratedBy.TriggerIdentity();

        Map(x => x.Naziv, "NAZIV");
        Map(x => x.Kapacitet, "KAPACITET");
        Map(x => x.Adresa, "ADRESA");

        Map(x => x.OtvoreniRezim, "OTVORENI_REZIM");
        Map(x => x.PoluotvoreniRezim, "POLUOTVORENI_REZIM");
        Map(x => x.StrogiRezim, "STROGI_REZIM");

        DiscriminateSubClassesOnColumn("")
            .Formula("CASE WHEN (OTVORENI_REZIM = 1 AND POLUOTVORENI_REZIM = 0 AND STROGI_REZIM = 0) THEN 'OtvoreniRezim'" +
                          " WHEN (OTVORENI_REZIM = 0 AND POLUOTVORENI_REZIM = 1 AND STROGI_REZIM = 0 ) THEN 'PoluotvoreniRezim'" +
                          " WHEN (OTVORENI_REZIM = 0 AND POLUOTVORENI_REZIM = 0 AND STROGI_REZIM = 1 ) THEN 'ZatvoreniRezim'" +
                          " WHEN (OTVORENI_REZIM = 1 AND POLUOTVORENI_REZIM = 1 AND STROGI_REZIM = 0 ) THEN 'OPRezim'" +
                          " WHEN (OTVORENI_REZIM = 1 AND POLUOTVORENI_REZIM = 0 AND STROGI_REZIM = 1 ) THEN 'OZRezim'" +
                          " WHEN (OTVORENI_REZIM = 0 AND POLUOTVORENI_REZIM = 1 AND STROGI_REZIM = 1 ) THEN 'PZRezim'" +
                          " ELSE 'Nepoznato'" +
                          " END");


        HasMany(x => x.Zatvorenici)
            .KeyColumn("SIFRA_ZATVORSKE_JEDINICE")
            .Cascade.All()
            .Inverse();

        HasMany(x => x.Zaposleni)
            .KeyColumn("SIFRA_ZATVORSKE_JEDINICE")
            .Cascade.All()
            .Inverse();

        References(x => x.Upravnik, "UPRAVNIK_JMBG");

    }
}

internal class OtvorenaZatvorskaJedinicaMapiranja : SubclassMap<OtvorenaZatvorskaJedinica>
{
    public OtvorenaZatvorskaJedinicaMapiranja()
    {
        DiscriminatorValue("OtvoreniRezim");

        Map(x => x.PeriodZabraneOd, "PERIOD_ZABRANE_OD");
        Map(x => x.PeriodZabraneDo, "PERIOD_ZABRANE_DO");

        HasManyToMany(x => x.Firme)
            .Table("SARADNJA")
            .ParentKeyColumn("SIFRA_ZATVORSKE_JEDINICE")
            .ChildKeyColumn("PIB");
    }
}

internal class PoluotvorenaZatvorskaJedinicaMapiranja : SubclassMap<PoluotvorenaZatvorskaJedinica>
{
    public PoluotvorenaZatvorskaJedinicaMapiranja()
    {
        DiscriminatorValue("PoluotvoreniRezim");

        Map(x => x.PeriodZabraneOd, "PERIOD_ZABRANE_OD");
        Map(x => x.PeriodZabraneDo, "PERIOD_ZABRANE_DO");
    }
}

internal class ZatvorenaZatvorskaJedinicaMapiranja : SubclassMap<ZatvorenaZatvorskaJedinica>
{
    public ZatvorenaZatvorskaJedinicaMapiranja()
    {
        DiscriminatorValue("ZatvoreniRezim");

        HasMany(x => x.TerminiSetnje)
            .KeyColumn("SIFRA_ZATVORSKE_JEDINICE")
            .Cascade.All()
            .Inverse();

        HasMany(x => x.TerminiPosete)
            .KeyColumn("SIFRA_ZATVORSKE_JEDINICE")
            .Cascade.All()
            .Inverse();
    }
}

internal class OPZatvorskaJedinicaMapiranja : SubclassMap<OPZatvorskaJedinica>
{
    public OPZatvorskaJedinicaMapiranja()
    {
        DiscriminatorValue("OPRezim");

        Map(x => x.PeriodZabraneOd, "PERIOD_ZABRANE_OD");
        Map(x => x.PeriodZabraneDo, "PERIOD_ZABRANE_DO");

        HasManyToMany(x => x.Firme)
            .Table("SARADNJA")
            .ParentKeyColumn("SIFRA_ZATVORSKE_JEDINICE")
            .ChildKeyColumn("PIB");
    }
}

internal class OZZatvorskaJedinicaMapiranja : SubclassMap<OZZatvorskaJedinica>
{
    public OZZatvorskaJedinicaMapiranja()
    {
        DiscriminatorValue("OZRezim");

        Map(x => x.PeriodZabraneOd, "PERIOD_ZABRANE_OD");
        Map(x => x.PeriodZabraneDo, "PERIOD_ZABRANE_DO");

        HasManyToMany(x => x.Firme)
            .Table("SARADNJA")
            .ParentKeyColumn("SIFRA_ZATVORSKE_JEDINICE")
            .ChildKeyColumn("PIB");

        HasMany(x => x.TerminiSetnje)
            .KeyColumn("SIFRA_ZATVORSKE_JEDINICE")
            .Cascade.All()
            .Inverse();

        HasMany(x => x.TerminiPosete)
            .KeyColumn("SIFRA_ZATVORSKE_JEDINICE")
            .Cascade.All()
            .Inverse();
    }
}

internal class PZZatvorskaJedinicaMapiranja : SubclassMap<PZZatvorskaJedinica>
{
    public PZZatvorskaJedinicaMapiranja()
    {
        DiscriminatorValue("PZRezim");

        Map(x => x.PeriodZabraneOd, "PERIOD_ZABRANE_OD");
        Map(x => x.PeriodZabraneDo, "PERIOD_ZABRANE_DO");

        HasMany(x => x.TerminiSetnje)
            .KeyColumn("SIFRA_ZATVORSKE_JEDINICE")
            .Cascade.All()
            .Inverse();

        HasMany(x => x.TerminiPosete)
            .KeyColumn("SIFRA_ZATVORSKE_JEDINICE")
            .Cascade.All()
            .Inverse();
    }
}