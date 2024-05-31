namespace Zatvor;

#region ZatvorskeJedinice

public class ZatvorskaJedinicaBasic
{
    public int Id { get; set; }
    public string? Naziv { get; set; }
    public int Kapacitet { get; set; }
    public string? Adresa { get; set; }


    public ZatvorskaJedinicaBasic(int id, string naziv, int kapacitet, string adresa)
    {
        Id = id;
        Naziv = naziv;
        Kapacitet = kapacitet;
        Adresa = adresa;
    }

    public ZatvorskaJedinicaBasic()
    {

    }

    public override string ToString()
    {
        return base.ToString()!;
    }

}

public class OtvorenaZatvorskaJedinicaBasic : ZatvorskaJedinicaBasic, ZatvorZabranaInterface
{
    public string? PeriodZabraneOd { get; set; }
    public string? PeriodZabraneDo { get; set; }

    public OtvorenaZatvorskaJedinicaBasic(int id, string naziv, int kapacitet, string adresa, string periodZabraneOd, string periodZabraneDo) : base(id, naziv, kapacitet, adresa)
    {
        PeriodZabraneOd = periodZabraneOd;
        PeriodZabraneDo = periodZabraneDo;
    }

    public OtvorenaZatvorskaJedinicaBasic()
    {

    }

    public override string ToString()
    {
        return "Otvorena";
    }

}

public class PoluotvorenaZatvorskaJedinicaBasic : ZatvorskaJedinicaBasic, ZatvorZabranaInterface
{
    public string? PeriodZabraneOd { get; set; }
    public string? PeriodZabraneDo { get; set; }

    public PoluotvorenaZatvorskaJedinicaBasic(int id, string naziv, int kapacitet, string adresa, string periodZabraneOd, string periodZabraneDo) : base(id, naziv, kapacitet, adresa)
    {
        PeriodZabraneOd = periodZabraneOd;
        PeriodZabraneDo = periodZabraneDo;
    }

    public PoluotvorenaZatvorskaJedinicaBasic()
    {

    }

    public override string ToString()
    {
        return "Poluotvorena";
    }

}

public class ZatvorenaZatvorskaJedinicaBasic : ZatvorskaJedinicaBasic
{
    public IList<TerminPoseteBasic> TerminiPosete { get; set; } = [];

    public ZatvorenaZatvorskaJedinicaBasic(int id, string naziv, int kapacitet, string adresa) : base(id, naziv, kapacitet, adresa)
    {
    }

    public ZatvorenaZatvorskaJedinicaBasic()
    {

    }
    public override string ToString()
    {
        return "Zatvorena";
    }

}

public class OPZatvorskaJedinicaBasic : ZatvorskaJedinicaBasic, ZatvorZabranaInterface
{
    public string? PeriodZabraneOd { get; set; }
    public string? PeriodZabraneDo { get; set; }

    public OPZatvorskaJedinicaBasic(int id, string naziv, int kapacitet, string adresa, string periodZabraneOd, string periodZabraneDo) : base(id, naziv, kapacitet, adresa)
    {
        PeriodZabraneOd = periodZabraneOd;
        PeriodZabraneDo = periodZabraneDo;
    }

    public OPZatvorskaJedinicaBasic()
    {

    }

    public override string ToString()
    {
        return "Otvorena-Poluotvorena";
    }
}

public class OZZatvorskaJedinicaBasic : ZatvorskaJedinicaBasic, ZatvorZabranaInterface
{
    public string? PeriodZabraneOd { get; set; }
    public string? PeriodZabraneDo { get; set; }

    public OZZatvorskaJedinicaBasic(int id, string naziv, int kapacitet, string adresa, string periodZabraneOd, string periodZabraneDo) : base(id, naziv, kapacitet, adresa)
    {
        PeriodZabraneOd = periodZabraneOd;
        PeriodZabraneDo = periodZabraneDo;
    }

    public OZZatvorskaJedinicaBasic()
    {

    }

    public override string ToString()
    {
        return "Otvorena-Zatvorena";
    }
}

public class PZZatvorskaJedinicaBasic : ZatvorskaJedinicaBasic, ZatvorZabranaInterface
{
    public string? PeriodZabraneOd { get; set; }
    public string? PeriodZabraneDo { get; set; }

    public PZZatvorskaJedinicaBasic(int id, string naziv, int kapacitet, string adresa, string periodZabraneOd, string periodZabraneDo) : base(id, naziv, kapacitet, adresa)
    {
        PeriodZabraneOd = periodZabraneOd;
        PeriodZabraneDo = periodZabraneDo;
    }

    public PZZatvorskaJedinicaBasic()
    {

    }
    public override string ToString()
    {
        return "Poluotvorena-Zatvorena";
    }
}

public class ZatvorskaJedinicaPregled
{
    public int Id { get; set; }
    public string Naziv { get; set; }
    public int Kapacitet { get; set; }
    public string Adresa { get; set; }
    public string Tip { get; set; }
    public string? PeriodZabraneOd { get; set; }
    public string? PeriodZabraneDo { get; set; }

    public ZatvorskaJedinicaPregled(int id, string naziv, int kapacitet, string adresa, string tip, string? periodZabraneOd, string? periodZabraneDo)
    {
        Id = id;
        Naziv = naziv;
        Kapacitet = kapacitet;
        Adresa = adresa;
        Tip = tip;
        PeriodZabraneOd = periodZabraneOd;
        PeriodZabraneDo = periodZabraneDo;
    }
}


#endregion

#region TerminiPosete

public class TerminPoseteBasic
{
    public int Id { get; set; }
    public string? Dan { get; set; }
    public string? TerminOd { get; set; }
    public string? TerminDo { get; set; }

    public TerminPoseteBasic(int id, string dan, string terminOd, string terminDo)
    {
        Id = id;
        Dan = dan;
        TerminOd = terminOd;
        TerminDo = terminDo;
    }

    public TerminPoseteBasic()
    {

    }
}

public class TerminPosetePregled
{
    public int Id { get; set; }
    public string Dan { get; set; }
    public string TerminOd { get; set; }
    public string TerminDo { get; set; }

    public TerminPosetePregled(int id, string dan, string terminOd, string terminDo)
    {
        Id = id;
        Dan = dan;
        TerminOd = terminOd;
        TerminDo = terminDo;
    }

 }

#endregion

#region TerminiSetnje

public class TerminSetnjeBasic
{
    public int Id { get; set; }
    public string? TerminOd { get; set; }
    public string? TerminDo { get; set; }

    public TerminSetnjeBasic(int id, string terminOd, string terminDo)
    {
        Id = id;
        TerminOd = terminOd;
        TerminDo = terminDo;
    }

    public TerminSetnjeBasic()
    {

    }
}

public class TerminSetnjePregled
{
    public int Id { get; set; }
    public string TerminOd { get; set; }
    public string TerminDo { get; set; }

    public TerminSetnjePregled(int id, string terminOd, string terminDo)
    {
        Id = id;
        TerminOd = terminOd;
        TerminDo = terminDo;
    }

}

#endregion

#region Zatvorenici

public class ZatvorenikBasic
{
    public int Id { get; set; }
    public string? Ime { get; set; }
    public string? Prezime { get; set; }
    public string? Adresa { get; set; }
    public char Pol { get; set; }
    public string? StatusUslovnogOtpusta { get; set; }
    public DateTime DatumSledecegSaslusanja { get; set; }
    public DateTime AdvokatDatum { get; set; }
    public DateTime AdvokatPoslednjiKontakt { get; set; }
    public AdvokatBasic? Advokat { get; set; }
    public ZatvorskaJedinicaBasic? ZatvorskaJedinica { get; set; }

    public ZatvorenikBasic(int id, string ime, string prezime, string adresa, char pol, string statusUslovnogOtpusta, DateTime datumSledecegSaslusanja, DateTime advokatDatum, DateTime advokatPoslednjiKontakt)
    {
        Id = id;
        Ime = ime;
        Prezime = prezime;
        Adresa = adresa;
        Pol = pol;
        StatusUslovnogOtpusta = statusUslovnogOtpusta;
        DatumSledecegSaslusanja = datumSledecegSaslusanja;
        AdvokatDatum = advokatDatum;
        AdvokatPoslednjiKontakt = advokatPoslednjiKontakt;
    }

    public ZatvorenikBasic()
    {
    }

}

public class ZatvorenikPregled
{
    public int Id { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public string Adresa { get; set; }
    public char Pol { get; set; }
    public string StatusUslovnogOtpusta { get; set; }
    public DateTime DatumSledecegSaslusanja { get; set; }
    public string AdvokatImeIPrezime { get; set; }
    public DateTime AdvokatDatum { get; set; }
    public DateTime AdvokatPoslednjiKontakt { get; set; }
    public string NazivZatvorskeJedinice { get; set; }

    public ZatvorenikPregled(int id, string ime, string prezime, string adresa, char pol, string statusUslovnogOtpusta, DateTime datumSledecegSaslusanja, string advokatImeIPrezime, DateTime advokatDatum, DateTime advokatPoslednjiKontakt)
    {
        Id = id;
        Ime = ime;
        Prezime = prezime;
        Adresa = adresa;
        Pol = pol;
        StatusUslovnogOtpusta = statusUslovnogOtpusta;
        DatumSledecegSaslusanja = datumSledecegSaslusanja;
        AdvokatImeIPrezime = advokatImeIPrezime;
        AdvokatDatum = advokatDatum;
        AdvokatPoslednjiKontakt = advokatPoslednjiKontakt;
    }

    public ZatvorenikPregled()
    {
    }

}

#endregion

#region Advokati

public class AdvokatBasic
{
    public string? JMBG { get; set; }
    public string? Ime { get; set; }
    public string? Prezime { get; set; }

    public AdvokatBasic(string jmbg, string ime, string prezime)
    {
        JMBG = jmbg;
        Ime = ime;
        Prezime = prezime;
    }

    public AdvokatBasic()
    {
    }
}

public class AdvokatPregled
{
    public string? JMBG { get; set; }
    public string? Ime { get; set; }
    public string? Prezime { get; set; }

    public AdvokatPregled(string jmbg, string ime, string prezime)
    {
        JMBG = jmbg;
        Ime = ime;
        Prezime = prezime;
    }

    public AdvokatPregled() 
    {
    }

}

#endregion

#region Zaposleni

public class ZaposleniBasic
{
    public string JMBG { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public DateTime DatumObuke { get; set; }

    public RadiUBasic RadiU { get; set; }

    public ZaposleniBasic(string jmbg, string ime, string prezime, DateTime datumObuke)
    {
        JMBG = jmbg;
        Ime = ime;
        Prezime = prezime;
        DatumObuke = datumObuke;
    }

    public ZaposleniBasic()
    {
    }

    public override string ToString()
    {
        return base.ToString();
    }
}

public class ZaposleniPregled
{
    public string JMBG { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public DateTime DatumObuke { get; set; }
    public string TipZaposlenog { get; set; }
    public string Zanimanje { get; set; }
    public string StrucnaSprema { get; set; }
    public string RadnoMesto { get; set; }
    public DateTime DatumPocetka { get; set; }

    public ZaposleniPregled(string jmbg, string ime, string prezime, DateTime datumObuke, string tipZaposlenog, string zanimanje, string strucnaSprema, string radnoMesto, DateTime datumPocetka)
    {
        JMBG = jmbg;
        Ime = ime;
        Prezime = prezime;
        DatumObuke = datumObuke;
        TipZaposlenog = tipZaposlenog;
        Zanimanje = zanimanje;
        StrucnaSprema = strucnaSprema;
        RadnoMesto = radnoMesto;
        DatumPocetka = datumPocetka;
    }

    public ZaposleniPregled()
    {
    }

}

public class ZaposleniAdministracijaBasic : ZaposleniBasic
{
    public string? Zanimanje { get; set; }
    public string? StrucnaSprema { get; set; }

    public ZaposleniAdministracijaBasic(string jmbg, string ime, string prezime, DateTime datumObuke, string zanimanje, string strucnaSprema) : base(jmbg, ime, prezime, datumObuke)
    {
        Zanimanje = zanimanje;
        StrucnaSprema = strucnaSprema;
    }

    public ZaposleniAdministracijaBasic()
    {
    }

    public override string ToString()
    {
        return "Administracija";
    }
}

public class PsihologBasic : ZaposleniBasic
{
    public PsihologBasic(string jmbg, string ime, string prezime, DateTime datumObuke) : base(jmbg, ime, prezime, datumObuke)
    {
    }

    public PsihologBasic()
    {
    }

    public override string ToString()
    {
        return "Psiholog";
    }
}

public class RadnikObezbedjenjaBasic : ZaposleniBasic
{
    public RadnikObezbedjenjaBasic(string jmbg, string ime, string prezime, DateTime datumObuke) : base(jmbg, ime, prezime, datumObuke)
    {
    }

    public RadnikObezbedjenjaBasic()
    {
    }

    public override string ToString()
    {
        return "Radnik obezbeđenja";
    }
}

#endregion

#region RadiU

public class RadiUBasic
{
    public DateTime DatumPocetkaRada { get; set; }
    public string NazivRadnogMesta { get; set; }
    public int ZatvorskaJedinicaId { get; set; }

    public RadiUBasic(DateTime datumPocetkaRada, string nazivRadnogMesta, int zatvorskaJedinicaId)
    {
        DatumPocetkaRada = datumPocetkaRada;
        NazivRadnogMesta = nazivRadnogMesta;
        ZatvorskaJedinicaId = zatvorskaJedinicaId;
    }

    public RadiUBasic()
    {

    }
}

public class RadiUPregled
{
    public string JMBG { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public string NazivZatvorskeJedinice { get; set; }
    public string RadnoMesto { get; set; }
    public DateTime DatumPocetkaRada { get; set; }

    public RadiUPregled(string jmbg, string ime, string prezime, string nazivZatvorskeJedinice, string radnoMesto, DateTime datumPocetkaRada)
    {
        JMBG = jmbg;
        Ime = ime;
        Prezime = prezime;
        NazivZatvorskeJedinice = nazivZatvorskeJedinice;
        RadnoMesto = radnoMesto;
        DatumPocetkaRada = datumPocetkaRada;
    }

    public RadiUPregled()
    {
    }

}

#endregion

#region LekarskiPregledi

public class LekarskiPregledBasic
{
    public int Id { get; set; }
    public DateTime Datum { get; set; }
    public string NazivUstanove { get; set; }
    public string AdresaUstanove { get; set; }
    public string Lekar { get; set; }

    public LekarskiPregledBasic(int id, DateTime datum, string nazivUstanove, string adresaUstanove, string lekar)
    {
        Id = id;
        Datum = datum;
        NazivUstanove = nazivUstanove;
        AdresaUstanove = adresaUstanove;
        Lekar = lekar;
    }
    
    public LekarskiPregledBasic()
    {
    }

}

public class LekarskiPregledPregled
{
    public int Id { get; protected set; }
    public DateTime Datum { get; set; }
    public string NazivUstanove { get; set; }
    public string AdresaUstanove { get; set; }
    public string Lekar { get; set; }

    public LekarskiPregledPregled(int id, DateTime datum, string nazivUstanove, string adresaUstanove, string lekar)
    {
        Id = id;
        Datum = datum;
        NazivUstanove = nazivUstanove;
        AdresaUstanove = adresaUstanove;
        Lekar = lekar;
    }

    public LekarskiPregledPregled()
    {
    }

}

#endregion

#region Obuke

public class ObukaVatrenoOruzjeBasic
{
    public int Id { get; set; }
    public DateTime DatumIzdavanja { get; set; }
    public string PolicijskaUprava { get; set; }

    public ObukaVatrenoOruzjeBasic(int id, DateTime datumIzdavanja, string policijskaUprava)
    {
        Id = id;
        DatumIzdavanja = datumIzdavanja;
        PolicijskaUprava = policijskaUprava;
    }

    public ObukaVatrenoOruzjeBasic()
    {
    }

}

public class ObukaVatrenoOruzjePregled
{
    public int Id { get; set; }
    public DateTime DatumIzdavanja { get; set; }
    public string PolicijskaUprava { get; set; }

    public ObukaVatrenoOruzjePregled(int id, DateTime datumIzdavanja, string policijskaUprava)
    {
        Id = id;
        DatumIzdavanja = datumIzdavanja;
        PolicijskaUprava = policijskaUprava;
    }

    public ObukaVatrenoOruzjePregled()
    {
    }

}


#endregion

#region Prestup

public class PrestupBasic
{
    public int Id { get; set; }
    public string Naziv { get; set; }
    public string Kategorija { get; set; }
    public string Opis { get; set; }
    public string MinKazna { get; set; }
    public string MaxKazna { get; set; }

    public PrestupBasic(int id, string naziv, string kategorija, string opis, string minKazna, string maxKazna)
    {
        Id = id;
        Naziv = naziv;
        Kategorija = kategorija;
        Opis = opis;
        MinKazna = minKazna;
        MaxKazna = maxKazna;
    }

    public PrestupBasic()
    {
    }

}

public class PrestupPregled
{
    public int Id { get; set; }
    public string Naziv { get; set; }
    public string Kategorija { get; set; }
    public string Opis { get; set; }
    public string MinKazna { get; set; }
    public string MaxKazna { get; set; }

    public PrestupPregled(int id, string naziv, string kategorija, string opis, string minKazna, string maxKazna)
    {
        Id = id;
        Naziv = naziv;
        Kategorija = kategorija;
        Opis = opis;
        MinKazna = minKazna;
        MaxKazna = maxKazna;
    }

    public PrestupPregled()
    {
    }

}


#endregion

#region IzvrseniPrestupi

public class IzvrsenPrestupBasic
{
    public int Id { get; set; }
    public DateTime Datum { get; set; }
    public string Mesto { get; set; }
    public int IdZatvorenika{ get; set; }
    public int IdPrestupa { get; set; }

    public IzvrsenPrestupBasic(int id, DateTime datum, string mesto, int idZatvorenika, int idPrestupa)
    {
        Id = id;
        Datum = datum;
        Mesto = mesto;
        IdZatvorenika = idZatvorenika;
        IdPrestupa = idPrestupa;
    }

    public IzvrsenPrestupBasic()
    {
    }

}

public class IzvrsenPrestupPregled
{
    public int Id { get; set; }
    public DateTime Datum { get; set; }
    public string Mesto { get; set; }
    public string Naziv { get; set; }
    public string Kategorija { get; set; }
    public string Opis { get; set; }
    public string MinKazna { get; set; }
    public string MaxKazna { get; set; }

    public IzvrsenPrestupPregled(int id, DateTime datum, string mesto, string naziv, string kategorija, string opis, string minKazna, string maxKazna)
    {
        Id = id;
        Datum = datum;
        Mesto = mesto;
        Naziv = naziv;
        Kategorija = kategorija;
        Opis = opis;
        MinKazna = minKazna;
        MaxKazna = maxKazna;
    }

    public IzvrsenPrestupPregled()
    {
    }

}

#endregion

#region Firme

public class FirmaBasic
{
    public int PIB { get; set; }
    public string Ime { get; set; }
    public string Adresa { get; set; }

    public FirmaBasic(int pib, string ime, string adresa)
    {
        PIB = pib;
        Ime = ime;
        Adresa = adresa;
    }

    public FirmaBasic()
    {
    }
}

public class FirmaPregled
{
    public int? PIB { get; set; }
    public string? Ime { get; set; }
    public string? Adresa { get; set; }

    public FirmaPregled(int? pib, string? ime, string? adresa)
    {
        PIB = pib;
        Ime = ime;
        Adresa = adresa;
    }

    public FirmaPregled()
    {
    }
}

#endregion

#region Posete

public class PosetaBasic
{
    public int Id { get; set; }
    public DateTime Datum { get; set; }
    public string VremeOd { get; set; }
    public string VremeDo { get; set; }
    public int ZatvorenikId { get; set; }
    
    public PosetaBasic(int id, DateTime datum, string vremeOd, string vremeDo, int zatvorenikId)
    {
        Id = id;
        Datum = datum;
        VremeOd = vremeOd;
        VremeDo = vremeDo;
        this.ZatvorenikId = zatvorenikId;
    }

    public PosetaBasic()
    {
    }
}

public class PosetaPregled
{
    public int Id { get; set; }
    public DateTime Datum { get; set; }
    public string VremeOd { get; set; }
    public string VremeDo { get; set; }
    public string Advokat { get; set; }
    public string Zatvorenik { get; set; }

    public PosetaPregled(int id, DateTime datum, string vremeOd, string vremeDo, string advokat, string zatvorenik)
    {
        Id = id;
        Datum = datum;
        VremeOd = vremeOd;
        VremeDo = vremeDo;
        Advokat = advokat;
        Zatvorenik = zatvorenik;
    }

    public PosetaPregled()
    {
    }
}

#endregion

#region OdgovornaLica

public class OdgovornoLiceBasic
{
    public int Id { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }

    public OdgovornoLiceBasic(int id, string ime, string prezime)
    {
        Id = id;
        Ime = ime;
        Prezime = prezime;
    }

    public OdgovornoLiceBasic()
    {
    }
}

public class OdgovornoLicePregled
{
    public int Id { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }

    public OdgovornoLicePregled(int id, string ime, string prezime)
    {
        Id = id;
        Ime = ime;
        Prezime = prezime;
    }

    public OdgovornoLicePregled()
    {
    }
}

#endregion

#region FirmaTelefoni

public class FirmaTelefonBasic
{
    public int Id { get; set; }
    public string BrojTelefona { get; set; }

    public FirmaTelefonBasic(int id, string brojTelefona)
    {
        Id = id;
        BrojTelefona = brojTelefona;
    }

    public FirmaTelefonBasic()
    {
    }
}

public class FirmaTelefonPregled
{
    public int Id { get; set; }
    public string BrojTelefona { get; set; }

    public FirmaTelefonPregled(int id, string brojTelefona)
    {
        Id = id;
        BrojTelefona = brojTelefona;
    }

    public FirmaTelefonPregled()
    {
    }
}

#endregion