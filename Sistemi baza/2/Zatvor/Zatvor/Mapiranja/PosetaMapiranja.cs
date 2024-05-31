namespace Zatvor.Mapiranja;

public class PosetaMapiranja : ClassMap<Poseta>
{
    public PosetaMapiranja()
    {
        Table("POSETA");

        Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

        Map(x => x.Datum, "DATUM");
        Map(x => x.VremeOd, "VREME_OD");
        Map(x => x.VremeDo, "VREME_DO");

        References(x => x.Zatvorenik, "ZATVORENIK_BROJ");
        References(x => x.Advokat, "ADVOKAT_JMBG");
    }
}
