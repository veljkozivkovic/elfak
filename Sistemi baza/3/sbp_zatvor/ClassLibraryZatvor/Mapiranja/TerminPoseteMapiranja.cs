namespace ZatvorLibrary.Mapiranja;

internal class TerminPoseteMapiranja : ClassMap<TerminPosete>
{
    public TerminPoseteMapiranja()
    {
        Table("TERMIN_POSETE");

        Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

        Map(x => x.Dan, "DAN");
        Map(x => x.TerminOd, "TERMIN_OD");
        Map(x => x.TerminDo, "TERMIN_DO");

        References(x => x.ZatvorskaJedinica, "SIFRA_ZATVORSKE_JEDINICE");
    }
}