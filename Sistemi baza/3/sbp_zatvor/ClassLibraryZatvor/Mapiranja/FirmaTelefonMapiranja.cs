namespace ZatvorLibrary.Mapiranja;

internal class FirmaTelefonMapiranja : ClassMap<FirmaTelefon>
{
    public FirmaTelefonMapiranja()
    {
        Table("FIRMA_TELEFON");

        Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

        Map(x => x.BrojTelefona, "BROJ_TELEFONA");
        References(x => x.Firma, "PIB").Not.LazyLoad();
    }
}
