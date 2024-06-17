namespace ZatvorLibrary.Mapiranja;

internal class AdvokatMapiranja : ClassMap<Advokat>
{
    public AdvokatMapiranja()
    {
        Table("ADVOKAT");

        Id(x => x.JMBG, "JMBG").GeneratedBy.Assigned();

        Map(x => x.Ime, "IME");
        Map(x => x.Prezime, "PREZIME");

        HasMany(x => x.Posete)
            .KeyColumn("ADVOKAT_JMBG")
            .Cascade.All()
            .Inverse();

        HasMany(x => x.Zatvorenici)
            .KeyColumn("ADVOKAT_JMBG")
            .Inverse();
    }

}
