namespace Zatvor.Mapiranja;

public class LekarskiPregledMapiranja : ClassMap<LekarskiPregled>
{
    public LekarskiPregledMapiranja()
    {
        Table("LEKARSKI_PREGLED");

        Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

        Map(x => x.Datum, "DATUM");
        Map(x => x.NazivUstanove, "NAZIV_USTANOVE");
        Map(x => x.AdresaUstanove, "ADRESA_USTANOVE");
        Map(x => x.Lekar, "LEKAR");

        References(x => x.Zaposleni, "ZAPOSLENI_JMBG");
    }
}
