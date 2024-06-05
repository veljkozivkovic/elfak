namespace Zatvor.Mapiranja;

public class ObukaVatrenoOruzjeMapiranja : ClassMap<ObukaVatrenoOruzje>
{
    public ObukaVatrenoOruzjeMapiranja()
    {

        Table("OBUKA_VATRENO_ORUZJE");

        Id(x => x.Id, "SIFRA_SERTIFIKATA").GeneratedBy.TriggerIdentity();

        Map(x => x.DatumIzdavanja, "DATUM_IZDAVANJA");
        Map(x => x.PolicijskaUprava, "POLICIJSKA_UPRAVA");

        References(x => x.Radnik, "RADNIK_OBEZBEDJENJA_JMBG");
    }
}
