namespace Zatvor.Mapiranja;

public class IzvrsenPrestupMapiranja : ClassMap<IzvrsenPrestup>
{
    public IzvrsenPrestupMapiranja()
    {
        Table("IZVRSEN_PRESTUP");

        Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

        Map(x => x.Datum, "DATUM");
        Map(x => x.Mesto, "MESTO");

        References(x => x.Zatvorenik, "ZATVORENIK_BROJ");
        References(x => x.Prestup, "PRESTUP_ID");
    }

}
