namespace ZatvorLibrary.Mapiranja;

internal class TerminSetnjeMapiranja : ClassMap<TerminSetnje>
{
    public TerminSetnjeMapiranja()
    {
        Table("TERMIN_SETNJE");

        Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

        Map(x => x.TerminOd, "TERMIN_OD");
        Map(x => x.TerminDo, "TERMIN_DO");

        References(x => x.ZatvorskaJedinica, "SIFRA_ZATVORSKE_JEDINICE");
    }
}
