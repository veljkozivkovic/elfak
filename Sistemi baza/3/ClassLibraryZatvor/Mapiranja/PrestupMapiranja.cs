namespace Zatvor.Mapiranja;

public class PrestupMapiranja : ClassMap<Prestup>
{
    public PrestupMapiranja()
    {
        Table("PRESTUP");

        Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

        Map(x => x.Naziv, "NAZIV");
        Map(x => x.Kategorija, "KATEGORIJA");
        Map(x => x.Opis, "OPIS");
        Map(x => x.MinKazna, "MIN_KAZNA");
        Map(x => x.MaxKazna, "MAX_KAZNA");

        HasMany(x => x.IzvrseniPrestupi)
            .KeyColumn("PRESTUP_ID")
            .Cascade.All()
            .Inverse();
    }
}
