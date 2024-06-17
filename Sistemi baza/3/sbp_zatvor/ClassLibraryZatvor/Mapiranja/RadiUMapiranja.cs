namespace ZatvorLibrary.Mapiranja;

internal class RadiUMapiranja : ClassMap<RadiU>
{
    public RadiUMapiranja()
    {
        Table("RADI_U");

        Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

        Map(x => x.DatumPocetkaRada, "DATUM_POCETKA_RADA");
        Map(x => x.NazivRadnogMesta, "NAZIV_RADNOG_MESTA");

        References(x => x.Zaposleni, "ZAPOSLENI_JMBG").Not.LazyLoad();
        References(x => x.ZatvorskaJedinica, "SIFRA_ZATVORSKE_JEDINICE");
    }
}
