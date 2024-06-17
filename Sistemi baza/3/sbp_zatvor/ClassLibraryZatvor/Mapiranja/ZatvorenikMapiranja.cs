namespace ZatvorLibrary.Mapiranja;

internal class ZatvorenikMapiranja : ClassMap<Zatvorenik>
{
    public ZatvorenikMapiranja()
    {
        Table("ZATVORENIK");

        Id(x => x.Id, "BROJ").GeneratedBy.TriggerIdentity();

        Map(x => x.Ime, "IME");
        Map(x => x.Prezime, "PREZIME");
        Map(x => x.Adresa, "ADRESA");
        Map(x => x.Pol, "POL");
        Map(x => x.StatusUslovnogOtpusta, "STATUS_USLOVNOG_OTPUSTA");
        Map(x => x.DatumSledecegSaslusanja, "DATUM_SLEDECEG_SASLUSANJA");
        Map(x => x.AdvokatDatum, "ADVOKAT_DATUM");
        Map(x => x.AdvokatPoslednjiKontakt, "ADVOKAT_POSL_KONTAKT");

        References(x => x.ZatvorskaJedinica, "SIFRA_ZATVORSKE_JEDINICE").Not.LazyLoad();

        HasMany(x => x.IzvrseniPrestupi)
            .KeyColumn("ZATVORENIK_BROJ")
            .Cascade.All()
            .Inverse();

        HasMany(x => x.Posete)
            .KeyColumn("ZATVORENIK_BROJ")
            .Cascade.All()
            .Inverse();

        References(x => x.Firma, "PIB_FIRME");
        References(x => x.Advokat, "ADVOKAT_JMBG");

    }
}
