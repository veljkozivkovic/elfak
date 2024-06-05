namespace Zatvor.Mapiranja;

public class OdgovornoLiceMapiranja : ClassMap<OdgovornoLice>
{
    public OdgovornoLiceMapiranja()
    {
        Table("ODGOVORNO_LICE");

        Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

        Map(x => x.Ime, "IME");
        Map(x => x.Prezime, "PREZIME");

        References(x => x.Firma, "PIB");
    }
}
