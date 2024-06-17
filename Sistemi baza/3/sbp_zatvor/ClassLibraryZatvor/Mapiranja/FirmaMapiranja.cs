namespace ZatvorLibrary.Mapiranja;

internal class FirmaMapiranja : ClassMap<Firma>
{
    public FirmaMapiranja()
    {
        Table("FIRMA");

        Id(x => x.PIB, "PIB").GeneratedBy.Assigned();

        Map(x => x.Ime, "IME");
        Map(x => x.Adresa, "ADRESA");

        HasMany(x => x.OdgovornaLica)
            .KeyColumn("PIB")
            .Cascade.All()
            .Inverse();

        HasManyToMany(x => x.ZatvorskeJedinice)
            .Table("SARADNJA")
            .ParentKeyColumn("PIB")
            .ChildKeyColumn("SIFRA_ZATVORSKE_JEDINICE")
            .Inverse();

        HasMany(x => x.Telefoni)
            .KeyColumn("PIB")
            .Cascade.All()
            .Inverse();

        HasMany(x => x.ZatvoreniciRadnici)
            .KeyColumn("PIB_FIRME")
            .Inverse();

    }
}
