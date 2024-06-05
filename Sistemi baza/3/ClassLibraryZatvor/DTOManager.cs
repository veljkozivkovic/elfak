using ClassLibraryZatvor;
using NHibernate;
using System.Threading.Tasks;
using Zatvor.Entiteti;

namespace Zatvor;

public static class DTOManager
{

    #region ZatvorskeJedinice

    //nzm da l treba ovo
    public static string VratiTipZatvora(ZatvorskaJedinica z)
    {
        if (z is OtvorenaZatvorskaJedinica)
        {
            return "Otvorena";
        }
        else if (z is PoluotvorenaZatvorskaJedinica)
        {
            return "Poluotvorena";
        }
        else if (z is ZatvorenaZatvorskaJedinica)
        {
            return "Zatvorena";
        }
        else if (z is OPZatvorskaJedinica)
        {
            return "Otvorena-Poluotvorena";
        }
        else if (z is OZZatvorskaJedinica)
        {
            return "Otvorena-Zatvorena";
        }
        else
        {
            return "Poluotvorena-Zatvorena";
        }
    }

    public static ZatvorskaJedinica? KreirajZatvorskuJedinicu(ZatvorskaJedinicaPregled zatvorskaJedinica)
    {
        if (zatvorskaJedinica is OtvorenaZatvorskaJedinicaBasic)
        {
            return new OtvorenaZatvorskaJedinica
            {
                Naziv = zatvorskaJedinica.Naziv!,
                Kapacitet = zatvorskaJedinica.Kapacitet,
                Adresa = zatvorskaJedinica.Adresa!,
                PeriodZabraneOd = zatvorskaJedinica!.PeriodZabraneOd,
                PeriodZabraneDo = zatvorskaJedinica!.PeriodZabraneDo
            };
        }
        else if (zatvorskaJedinica is PoluotvorenaZatvorskaJedinicaBasic)
        {
            return new PoluotvorenaZatvorskaJedinica
            {
                Naziv = zatvorskaJedinica.Naziv!,
                Kapacitet = zatvorskaJedinica.Kapacitet,
                Adresa = zatvorskaJedinica.Adresa!,
                PeriodZabraneOd = zatvorskaJedinica!.PeriodZabraneOd,
                PeriodZabraneDo = zatvorskaJedinica!.PeriodZabraneDo
            };
        }
        else if (zatvorskaJedinica is ZatvorenaZatvorskaJedinicaBasic)
        {
            return new ZatvorenaZatvorskaJedinica
            {
                Naziv = zatvorskaJedinica.Naziv!,
                Kapacitet = zatvorskaJedinica.Kapacitet,
                Adresa = zatvorskaJedinica.Adresa!
            };
        }
        else if (zatvorskaJedinica is OPZatvorskaJedinicaBasic)
        {
            return new OPZatvorskaJedinica
            {
                Naziv = zatvorskaJedinica.Naziv!,
                Kapacitet = zatvorskaJedinica.Kapacitet,
                Adresa = zatvorskaJedinica.Adresa!,
                PeriodZabraneOd = zatvorskaJedinica!.PeriodZabraneOd,
                PeriodZabraneDo = zatvorskaJedinica!.PeriodZabraneDo
            };
        }
        else if (zatvorskaJedinica is OZZatvorskaJedinicaBasic)
        {
            return new OZZatvorskaJedinica
            {
                Naziv = zatvorskaJedinica.Naziv!,
                Kapacitet = zatvorskaJedinica.Kapacitet,
                Adresa = zatvorskaJedinica.Adresa!,
                PeriodZabraneOd = zatvorskaJedinica!.PeriodZabraneOd,
                PeriodZabraneDo = zatvorskaJedinica!.PeriodZabraneDo
            };
        }
        else if (zatvorskaJedinica is PZZatvorskaJedinicaBasic)
        {
            return new PZZatvorskaJedinica
            {
                Naziv = zatvorskaJedinica.Naziv!,
                Kapacitet = zatvorskaJedinica.Kapacitet,
                Adresa = zatvorskaJedinica.Adresa!,
                PeriodZabraneOd = zatvorskaJedinica!.PeriodZabraneOd,
                PeriodZabraneDo = zatvorskaJedinica!.PeriodZabraneDo
            };
        }

        return null;
    }
    //OVU KORISTIMO ZA API POZIVE
    public static ZatvorskaJedinica? KreirajZatvorskuJedinicu(string tip, ZatvorskaJedinicaPregled zatvorskaJedinica)
    {
        switch (tip)
        {
            case "Otvorena":
                return new OtvorenaZatvorskaJedinica
                {
                    Naziv = zatvorskaJedinica.Naziv!,
                    Kapacitet = zatvorskaJedinica.Kapacitet,
                    Adresa = zatvorskaJedinica.Adresa!,
                    PeriodZabraneOd = zatvorskaJedinica!.PeriodZabraneOd,
                    PeriodZabraneDo = zatvorskaJedinica!.PeriodZabraneDo
                };
            case "Poluotvorena":
                return new PoluotvorenaZatvorskaJedinica
                {
                    Naziv = zatvorskaJedinica.Naziv!,
                    Kapacitet = zatvorskaJedinica.Kapacitet,
                    Adresa = zatvorskaJedinica.Adresa!,
                    PeriodZabraneOd = zatvorskaJedinica!.PeriodZabraneOd,
                    PeriodZabraneDo = zatvorskaJedinica!.PeriodZabraneDo
                };
            case "Zatvorena":
                return new ZatvorenaZatvorskaJedinica
                {
                    Naziv = zatvorskaJedinica.Naziv!,
                    Kapacitet = zatvorskaJedinica.Kapacitet,
                    Adresa = zatvorskaJedinica.Adresa!
                };
            case "OP":
                return new OPZatvorskaJedinica
                {
                    Naziv = zatvorskaJedinica.Naziv!,
                    Kapacitet = zatvorskaJedinica.Kapacitet,
                    Adresa = zatvorskaJedinica.Adresa!,
                    PeriodZabraneOd = zatvorskaJedinica!.PeriodZabraneOd,
                    PeriodZabraneDo = zatvorskaJedinica!.PeriodZabraneDo
                };
            case "OZ":
                return new OZZatvorskaJedinica
                {
                    Naziv = zatvorskaJedinica.Naziv!,
                    Kapacitet = zatvorskaJedinica.Kapacitet,
                    Adresa = zatvorskaJedinica.Adresa!,
                    PeriodZabraneOd = zatvorskaJedinica!.PeriodZabraneOd,
                    PeriodZabraneDo = zatvorskaJedinica!.PeriodZabraneDo
                };
            case "PZ":
                return new PZZatvorskaJedinica
                {
                    Naziv = zatvorskaJedinica.Naziv!,
                    Kapacitet = zatvorskaJedinica.Kapacitet,
                    Adresa = zatvorskaJedinica.Adresa!,
                    PeriodZabraneOd = zatvorskaJedinica!.PeriodZabraneOd,
                    PeriodZabraneDo = zatvorskaJedinica!.PeriodZabraneDo
                };
            default:
                return null;
        }
    }

    public static ZatvorskaJedinicaBasic? KreirajZatvorskuJedinicuBasic(ZatvorskaJedinica zatvorskaJedinica)
    {
        if (zatvorskaJedinica is OtvorenaZatvorskaJedinica)
        {
            return new OtvorenaZatvorskaJedinicaBasic
            {
                Id = zatvorskaJedinica.Id,
                Naziv = zatvorskaJedinica.Naziv,
                Kapacitet = zatvorskaJedinica.Kapacitet,
                Adresa = zatvorskaJedinica.Adresa,
                PeriodZabraneOd = (zatvorskaJedinica as OtvorenaZatvorskaJedinica)!.PeriodZabraneOd,
                PeriodZabraneDo = (zatvorskaJedinica as OtvorenaZatvorskaJedinica)!.PeriodZabraneDo
            };
        }
        else if (zatvorskaJedinica is PoluotvorenaZatvorskaJedinica)
        {
            return new PoluotvorenaZatvorskaJedinicaBasic
            {
                Id = zatvorskaJedinica.Id,
                Naziv = zatvorskaJedinica.Naziv,
                Kapacitet = zatvorskaJedinica.Kapacitet,
                Adresa = zatvorskaJedinica.Adresa,
                PeriodZabraneOd = (zatvorskaJedinica as PoluotvorenaZatvorskaJedinica)!.PeriodZabraneOd,
                PeriodZabraneDo = (zatvorskaJedinica as PoluotvorenaZatvorskaJedinica)!.PeriodZabraneDo
            };
        }
        else if (zatvorskaJedinica is ZatvorenaZatvorskaJedinica)
        {
            return new ZatvorenaZatvorskaJedinicaBasic
            {
                Id = zatvorskaJedinica.Id,
                Naziv = zatvorskaJedinica.Naziv,
                Kapacitet = zatvorskaJedinica.Kapacitet,
                Adresa = zatvorskaJedinica.Adresa
            };
        }
        else if (zatvorskaJedinica is OPZatvorskaJedinica)
        {
            return new OPZatvorskaJedinicaBasic
            {
                Id = zatvorskaJedinica.Id,
                Naziv = zatvorskaJedinica.Naziv,
                Kapacitet = zatvorskaJedinica.Kapacitet,
                Adresa = zatvorskaJedinica.Adresa,
                PeriodZabraneOd = (zatvorskaJedinica as OPZatvorskaJedinica)!.PeriodZabraneOd,
                PeriodZabraneDo = (zatvorskaJedinica as OPZatvorskaJedinica)!.PeriodZabraneDo
            };
        }
        else if (zatvorskaJedinica is OZZatvorskaJedinica)
        {
            return new OZZatvorskaJedinicaBasic
            {
                Id = zatvorskaJedinica.Id,
                Naziv = zatvorskaJedinica.Naziv,
                Kapacitet = zatvorskaJedinica.Kapacitet,
                Adresa = zatvorskaJedinica.Adresa,
                PeriodZabraneOd = (zatvorskaJedinica as OZZatvorskaJedinica)!.PeriodZabraneOd,
                PeriodZabraneDo = (zatvorskaJedinica as OZZatvorskaJedinica)!.PeriodZabraneDo
            };
        }
        else if (zatvorskaJedinica is PZZatvorskaJedinica)
        {
            return new PZZatvorskaJedinicaBasic
            {
                Id = zatvorskaJedinica.Id,  
                Naziv = zatvorskaJedinica.Naziv,
                Kapacitet = zatvorskaJedinica.Kapacitet,
                Adresa = zatvorskaJedinica.Adresa,
                PeriodZabraneOd = (zatvorskaJedinica as PZZatvorskaJedinica)!.PeriodZabraneOd,
                PeriodZabraneDo = (zatvorskaJedinica as PZZatvorskaJedinica)!.PeriodZabraneDo
            };
        }

        return null;
    }


    //odavde krecem sa gas
    public static Result<List<ZatvorskaJedinicaPregled>, ErrorMessage> VratiSveZatvore()
    {
        List<ZatvorskaJedinicaPregled> zatvorskeJedinice = new List<ZatvorskaJedinicaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
               
            }

            IEnumerable<ZatvorskaJedinica> sveZatvorskeJedinice = session.Query<ZatvorskaJedinica>().ToList();

            foreach (ZatvorskaJedinica z in sveZatvorskeJedinice)
            {
                string periodZabraneOd = "";
                string periodZabraneDo = "";

                if (z is ZatvorZabranaInterface zInterface)
                {
                   periodZabraneOd = zInterface.PeriodZabraneOd!;
                   periodZabraneDo = zInterface.PeriodZabraneDo!;
                }

                zatvorskeJedinice.Add(new ZatvorskaJedinicaPregled(z.Id, z.Naziv, z.Kapacitet, z.Adresa, VratiTipZatvora(z), periodZabraneOd, periodZabraneDo));
            }
        }
        catch (Exception ex)
        {
            ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return zatvorskeJedinice;
    }

    public static Result<List<ZatvorskaJedinicaPregled>, ErrorMessage> VratiZatvoreZaFirmu(int firmaPIB)
    {
        List<ZatvorskaJedinicaPregled> zatvorskeJedinice = new List<ZatvorskaJedinicaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            Firma firma = session.Load<Firma>(firmaPIB);

            if (firma == null)
            {
                return "Došlo je do greške!".ToError(404);
                
            }

            IList<ZatvorskaJedinica> lista = firma.ZatvorskeJedinice;

            foreach (ZatvorskaJedinica z in lista)
            {
                string periodZabraneOd = "";
                string periodZabraneDo = "";

                if (z is ZatvorZabranaInterface zInterface)
                {
                    periodZabraneOd = zInterface.PeriodZabraneOd!;
                    periodZabraneDo = zInterface.PeriodZabraneDo!;
                }

                zatvorskeJedinice.Add(new ZatvorskaJedinicaPregled(z.Id, z.Naziv, z.Kapacitet, z.Adresa, VratiTipZatvora(z), periodZabraneOd, periodZabraneDo));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return zatvorskeJedinice;
    }


    //sranje nebitno NEMAM OVO
    public static  Result<List<ZatvorskaJedinicaPregled>, ErrorMessage> VratiPotencijalneZatvoreZaFirmu(int firmaPIB)
    {
        List<ZatvorskaJedinicaPregled> zatvorskeJedinice = new List<ZatvorskaJedinicaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
                
            }

            Firma firma = session.Load<Firma>(firmaPIB);

            if (firma == null)
            {
                return "Došlo je do greške!".ToError(404);
                
            }

            IList<ZatvorskaJedinica> lista = firma.ZatvorskeJedinice;

            IEnumerable<ZatvorskaJedinica> otvoreniZatvori = session.Query<OtvorenaZatvorskaJedinica>()
                                                                     .Where(x => !lista.Contains(x))
                                                                     .ToList();

            IEnumerable<ZatvorskaJedinica> opZatvori = session.Query<OPZatvorskaJedinica>()
                                                                     .Where(x => !lista.Contains(x))
                                                                     .ToList();

            IEnumerable<ZatvorskaJedinica> ozZatvori = session.Query<OZZatvorskaJedinica>()
                                                         .Where(x => !lista.Contains(x))
                                                         .ToList();

            IEnumerable<ZatvorskaJedinica> sviZatvori = otvoreniZatvori.Concat(opZatvori).Concat(ozZatvori);  


            foreach (ZatvorskaJedinica z in sviZatvori)
            {
                string periodZabraneOd = "";
                string periodZabraneDo = "";

                if (z is ZatvorZabranaInterface zInterface)
                {
                    periodZabraneOd = zInterface.PeriodZabraneOd!;
                    periodZabraneDo = zInterface.PeriodZabraneDo!;
                }

                zatvorskeJedinice.Add(new ZatvorskaJedinicaPregled(z.Id, z.Naziv, z.Kapacitet, z.Adresa, VratiTipZatvora(z), periodZabraneOd, periodZabraneDo));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return zatvorskeJedinice;
    }

    public static async Task<Result<bool, ErrorMessage>> ObrisiZatvor(int id)
    {
        
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
                
            }

            ZatvorskaJedinica z = await session.Query<ZatvorskaJedinica>().Where(x => x.Id == id).FirstOrDefaultAsync();

            IList<Firma> firme = [];

            if (z is OtvorenaZatvorskaJedinica o)
                firme = o.Firme;
            else if (z is OPZatvorskaJedinica op)
                firme = op.Firme;
            else if (z is OZZatvorskaJedinica oz)
                firme = oz.Firme;

            foreach (Firma firma in firme)
            {
                firma.ZatvorskeJedinice.Remove(z);
                firme.Remove(firma);
                await session.UpdateAsync(z);
                await session.UpdateAsync(firma);
            }

            await session.DeleteAsync(z);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }
    //=================================================================================================
    public static Result<bool, ErrorMessage> DodajZatvorskuJedinicu(string tip, ZatvorskaJedinicaPregled zatvorskaJedinica)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            ZatvorskaJedinica? z = KreirajZatvorskuJedinicu(tip, zatvorskaJedinica);

            if (z == null)
            {
                return "Došlo je do greške!".ToError(404);
            }

             session.SaveOrUpdate(z);
             session.Flush();
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

    public static async Task<Result<bool, ErrorMessage>> IzmeniZatvorskuJedinicu(ZatvorskaJedinicaPregled zatvorskaJedinica)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            ZatvorskaJedinica z = await session.Query<ZatvorskaJedinica>().Where(x => x.Id == zatvorskaJedinica.Id).FirstOrDefaultAsync();

            if (z == null)
            {
                return "Došlo je do greške!".ToError(404);
            }

            z.Naziv = zatvorskaJedinica.Naziv!;
            z.Kapacitet = zatvorskaJedinica.Kapacitet;
            z.Adresa = zatvorskaJedinica.Adresa!;

            if (z is ZatvorZabranaInterface zInterface)
            {
                zInterface.PeriodZabraneOd = zatvorskaJedinica.PeriodZabraneOd;
                zInterface.PeriodZabraneDo = zatvorskaJedinica.PeriodZabraneDo;
            }

            await session.UpdateAsync(z);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

    public static  Result<ZatvorskaJedinicaBasic?, ErrorMessage> VratiZatvorskuJedinicu(int id, string tip)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
                
            }

            ZatvorskaJedinica z;

            if (tip == "Otvorena")
                z = session.Load<OtvorenaZatvorskaJedinica>(id);
            else if (tip == "Poluotvorena")
                z = session.Load<PoluotvorenaZatvorskaJedinica>(id);
            else if (tip == "Zatvorena")
                z =  session.Load<ZatvorenaZatvorskaJedinica>(id);
            else if (tip == "Otvorena-Zatvorena")
                z =  session.Load<OZZatvorskaJedinica>(id);
            else if (tip == "Poluotvorena-Zatvorena")
                z =  session.Load<PZZatvorskaJedinica>(id);
            else
                z = session.Load<OPZatvorskaJedinica>(id);

            return KreirajZatvorskuJedinicuBasic(z);

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

    }

    public static Result<bool, ErrorMessage> DodeliUpravnika(string zaposleniJMBG, int zatvorskaJedinicaId)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            ZaposleniAdministracija z =  session.Load<ZaposleniAdministracija>(zaposleniJMBG);

            if (z == null)
            {
                return "Došlo je do greške!".ToError(404);
            }

            ZatvorskaJedinica zatvor =  session.Load<ZatvorskaJedinica>(zatvorskaJedinicaId);
            
            if (zatvor == null)
            {
                return "Došlo je do greške!".ToError(404);
            }

            zatvor.Upravnik = z;
            z.ZatvorskaJedinica = zatvor;
            
            session.SaveOrUpdate(zatvor);
            session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

    public static  Result<List<ZaposleniPregled>, ErrorMessage> VratiMoguceUpravnike(int zatvorskaJedinicaId)
    {
        List<ZaposleniPregled> zaposleni = new List<ZaposleniPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            ZatvorskaJedinica zatvor = session.Load<ZatvorskaJedinica>(zatvorskaJedinicaId);

            if (zatvor == null)
            {
                return "Došlo je do greške!".ToError(404);
            }

            List<RadiU> sviZaposleni = zatvor.Zaposleni.ToList();
            Zaposleni z;

            foreach (RadiU r in sviZaposleni)
            {
                z = r.Zaposleni;

                if (z is ZaposleniAdministracija a)
                {
                    if (a.ZatvorskaJedinica == null)
                        zaposleni.Add(new ZaposleniPregled(a.JMBG, a.Ime, a.Prezime, a.DatumObuke, "Administracija", a.Zanimanje!, a.StrucnaSprema!, r.NazivRadnogMesta, r.DatumPocetkaRada));
                }

                
            }

            return zaposleni;

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
    }

    public static Result<ZaposleniPregled?, ErrorMessage> VratiUpravnika(int zatvorskaJedinicaId)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
                
            }

            ZatvorskaJedinica zatvor = session.Load<ZatvorskaJedinica>(zatvorskaJedinicaId);

            if (zatvor == null)
            {
                return "Došlo je do greške!".ToError(404);
            }

            ZaposleniAdministracija? upravnik = zatvor.Upravnik;

            if (upravnik == null)
            {
                return "Došlo je do greške!".ToError(404);
            }

            RadiU? radiU = upravnik?.RadnaMesta.Where(x => x.ZatvorskaJedinica.Id == zatvorskaJedinicaId).FirstOrDefault();

            ZaposleniPregled? upravnikPregled = new ZaposleniPregled
            {
                JMBG = upravnik.JMBG,
                Ime = upravnik.Ime,
                Prezime = upravnik.Prezime,
                DatumObuke = upravnik.DatumObuke,
                Zanimanje = upravnik.Zanimanje,
                StrucnaSprema = upravnik.StrucnaSprema,
                RadnoMesto = radiU.NazivRadnogMesta,
                DatumPocetka = radiU.DatumPocetkaRada
            };

            return upravnikPregled;

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
    }

    #endregion

    #region TerminiPosete

    public static Result<List<TerminPosetePregled>?, ErrorMessage> VratiTerminePosete(int id)
    {
        List<TerminPosetePregled> terminiPosete = new List<TerminPosetePregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
                
            }

            ZatvorskaJedinica zatvorskaJedinica = session.Load<ZatvorskaJedinica>(id);

            IList<TerminPosete>? termini = zatvorskaJedinica.getTerminiPosete();

            if (termini == null)
            {
                return "Zatvorska jedinica nema termine za posete!".ToError(404);
                
            }

            foreach (TerminPosete t in termini)
            {
                terminiPosete.Add(new TerminPosetePregled(t.Id, t.Dan, t.TerminOd, t.TerminDo));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return terminiPosete;
    }

    public static async Task<Result<bool, ErrorMessage>> DodajTerminPoseteAsync(TerminPoseteBasic terminPoseteBasic, int idZatvorskeJedinice)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            ZatvorskaJedinica zatvorskaJedinica = await session.LoadAsync<ZatvorskaJedinica>(idZatvorskeJedinice);

            if(zatvorskaJedinica == null)
            {
                return "Ne postoji zatvorska jedinica za zadatim ID-em".ToError(404);
            }

            TerminPosete t = new TerminPosete
            {  
                Dan = terminPoseteBasic.Dan!, 
                TerminOd = terminPoseteBasic.TerminOd!, 
                TerminDo = terminPoseteBasic.TerminDo!,
                ZatvorskaJedinica = zatvorskaJedinica
            };

            await session.SaveOrUpdateAsync(t);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;

    }

    public static Result<bool, ErrorMessage> IzmeniTerminPosete(TerminPoseteBasic terminPoseteBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            TerminPosete termin = session.Load<TerminPosete>(terminPoseteBasic.Id);

            termin.Dan = terminPoseteBasic.Dan!;
            termin.TerminOd = terminPoseteBasic.TerminOd!;
            termin.TerminDo = terminPoseteBasic.TerminDo!;

            session.Update(termin);
            session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

    public static Result<TerminPoseteBasic?, ErrorMessage> VratiTerminPosete(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            TerminPosete termin = session.Load<TerminPosete>(id);

            TerminPoseteBasic terminPosete = new TerminPoseteBasic(id, termin.Dan, termin.TerminOd, termin.TerminDo);

            return terminPosete;

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

    }

    public static Result<bool, ErrorMessage> ObrisiTerminPosete(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            TerminPosete t = session.Load<TerminPosete>(id);

            session.Delete(t);
            session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

    #endregion

    #region TerminiSetnje

    public static Result<List<TerminSetnjePregled>?, ErrorMessage> VratiTermineSetnje(int id)
    {
        List<TerminSetnjePregled> terminiSetnje = new List<TerminSetnjePregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            ZatvorskaJedinica zatvorskaJedinica =  session.Load<ZatvorskaJedinica>(id);

            IList<TerminSetnje>? termini = zatvorskaJedinica.getTerminiSetnje();

            if (termini == null)
            {
                return "Zatvorska jedinica nema termine za šetnju!".ToError(404);
                
            }

            foreach (TerminSetnje t in termini)
            {
                terminiSetnje.Add(new TerminSetnjePregled(t.Id, t.TerminOd, t.TerminDo));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

        return terminiSetnje;
    }

    public static async Task<Result<bool, ErrorMessage>> DodajTerminSetnjeAsync(TerminSetnjeBasic terminSetnjeBasic, int idZatvorskeJedinice)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            ZatvorskaJedinica zatvorskaJedinica = await session.LoadAsync<ZatvorskaJedinica>(idZatvorskeJedinice);

            TerminSetnje t = new TerminSetnje
            {
                TerminOd = terminSetnjeBasic.TerminOd!,
                TerminDo = terminSetnjeBasic.TerminDo!,
                ZatvorskaJedinica = zatvorskaJedinica
            };

            await session.SaveOrUpdateAsync(t);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<bool, ErrorMessage> IzmeniTerminSetnje(TerminSetnjeBasic terminSetnjeBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            TerminSetnje termin = session.Load<TerminSetnje>(terminSetnjeBasic.Id);

            termin.TerminOd = terminSetnjeBasic.TerminOd!;
            termin.TerminDo = terminSetnjeBasic.TerminDo!;

            session.Update(termin);
            session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

    public static Result<TerminSetnjeBasic?, ErrorMessage> VratiTerminSetnje(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            TerminSetnje termin = session.Load<TerminSetnje>(id);

            TerminSetnjeBasic terminSetnje = new TerminSetnjeBasic(id, termin.TerminOd, termin.TerminDo);

            return terminSetnje;

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

    }

    public static async Task<Result<bool, ErrorMessage>> ObrisiTerminSetnjeAsync(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            TerminSetnje t = session.Load<TerminSetnje>(id);

            await session.DeleteAsync(t);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

    public static Result<List<TerminSetnjeBasic>, ErrorMessage> VratiSveTermineSetnje()
    {
        ISession? session = null;
        List<TerminSetnjeBasic> terminiSetnjeBasic = new List<TerminSetnjeBasic>();

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            IList<TerminSetnje> termini = session.Query<TerminSetnje>().ToList();

            if (termini == null || !termini.Any())
            {
                return "Nema dostupnih termina šetnje.".ToError(404);
            }

            foreach (var termin in termini)
            {
                terminiSetnjeBasic.Add(new TerminSetnjeBasic(termin.Id, termin.TerminOd, termin.TerminDo));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return terminiSetnjeBasic;
    }


    #endregion

    #region Zatvorenici

    public static Result<List<ZatvorenikPregled>, ErrorMessage> VratiZatvorenikeZaZatvorskuJedinicu(int idZatvorskeJedinice)
    {
        List<ZatvorenikPregled> zatvoreniciPregled = new List<ZatvorenikPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
                
            }

            ZatvorskaJedinica zatvorskaJedinica = session.Load<ZatvorskaJedinica>(idZatvorskeJedinice);


            IEnumerable<Zatvorenik> zatvorenici = session.Query<Zatvorenik>().Where(x => x.ZatvorskaJedinica.Id == idZatvorskeJedinice).ToList();

            foreach (Zatvorenik z in zatvorenici)
            {
                string advokat = z.Advokat?.Ime + " " + z.Advokat?.Prezime;
                zatvoreniciPregled.Add(new ZatvorenikPregled(z.Id, z.Ime, z.Prezime, z.Adresa, z.Pol, z.StatusUslovnogOtpusta, z.DatumSledecegSaslusanja, advokat, z.AdvokatDatum, z.AdvokatPoslednjiKontakt));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return zatvoreniciPregled;
    }

    public static Result<List<ZatvorenikPregled>, ErrorMessage> VratiZatvorenikeZaAdvokata(string advokatJMBG)
    {
        List<ZatvorenikPregled> zatvoreniciPregled = new List<ZatvorenikPregled>();
        ISession? session = null;
        
        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
                
            }

            IEnumerable<Zatvorenik> zatvorenici = session.Query<Zatvorenik>().Where(x => x.Advokat != null && x.Advokat.JMBG == advokatJMBG).ToList();

            foreach (Zatvorenik z in zatvorenici)
            {
                ZatvorenikPregled pregled = new ZatvorenikPregled(z.Id, z.Ime, z.Prezime, z.Adresa!, z.Pol, z.StatusUslovnogOtpusta!, z.DatumSledecegSaslusanja, "", z.AdvokatDatum, z.AdvokatPoslednjiKontakt);
                pregled.NazivZatvorskeJedinice = z.ZatvorskaJedinica.Naziv;
                zatvoreniciPregled.Add(pregled);
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

        return zatvoreniciPregled;
    }

    public static Result<List<ZatvorenikPregled>, ErrorMessage> VratiMoguceZatvorenikeZaAdvokata(string advokatJMBG)
    {
        List<ZatvorenikPregled> zatvoreniciPregled = new List<ZatvorenikPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            IEnumerable<Zatvorenik> zatvorenici = session.Query<Zatvorenik>().Where(x => (x.Advokat != null && x.Advokat.JMBG != advokatJMBG) || x.Advokat == null).ToList();

            foreach (Zatvorenik z in zatvorenici)
            {
                ZatvorenikPregled pregled = new ZatvorenikPregled(z.Id, z.Ime, z.Prezime, z.Adresa!, z.Pol, z.StatusUslovnogOtpusta!, z.DatumSledecegSaslusanja, z.Advokat?.Ime + " " + z.Advokat?.Prezime, z.AdvokatDatum, z.AdvokatPoslednjiKontakt);
                pregled.NazivZatvorskeJedinice = z.ZatvorskaJedinica.Naziv;
                zatvoreniciPregled.Add(pregled);
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

        return zatvoreniciPregled;
    }

    public static Result<List<ZatvorenikPregled>, ErrorMessage> VratiZatvorenikeZaFirmu(int firmaPIB)
    {
        List<ZatvorenikPregled> zatvoreniciPregled = new List<ZatvorenikPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            IEnumerable<Zatvorenik> zatvorenici = session.Query<Zatvorenik>().Where(x => x.Firma != null && x.Firma.PIB == firmaPIB).ToList();

            foreach (Zatvorenik z in zatvorenici)
            {
                ZatvorenikPregled pregled = new ZatvorenikPregled(z.Id, z.Ime, z.Prezime, z.Adresa!, z.Pol, z.StatusUslovnogOtpusta!, z.DatumSledecegSaslusanja, "", z.AdvokatDatum, z.AdvokatPoslednjiKontakt);
                pregled.NazivZatvorskeJedinice = z.ZatvorskaJedinica.Naziv;
                zatvoreniciPregled.Add(pregled);
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

        return zatvoreniciPregled;
    }

    public static Result<List<ZatvorenikPregled>, ErrorMessage> VratiPotencijalneRadnike(int firmaPIB)
    {
        List<ZatvorenikPregled> zatvoreniciPregled = new List<ZatvorenikPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            Firma firma =  session.Load<Firma>(firmaPIB);

            if (firma == null)
            {
                return "Došlo je do greške!".ToError(404);
            }

            IEnumerable<Zatvorenik> zatvorenici = session.Query<Zatvorenik>()
                                                                .Where(x => firma.ZatvorskeJedinice.Contains(x.ZatvorskaJedinica) 
                                                                            && ((x.Firma != null && x.Firma.PIB != firmaPIB) || x.Firma == null))
                                                                .ToList();

            foreach (Zatvorenik z in zatvorenici)
            {
                ZatvorenikPregled pregled = new ZatvorenikPregled(z.Id, z.Ime, z.Prezime, z.Adresa!, z.Pol, z.StatusUslovnogOtpusta!, z.DatumSledecegSaslusanja, "", z.AdvokatDatum, z.AdvokatPoslednjiKontakt);
                pregled.NazivZatvorskeJedinice = z.ZatvorskaJedinica.Naziv;
                zatvoreniciPregled.Add(pregled);
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

        return zatvoreniciPregled;
    }

    public static async Task<Result<bool, ErrorMessage>> DodajZatvorenikaAsync(ZatvorenikBasic zatvorenikBasic, int idZatvorskeJedinice)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            ZatvorskaJedinica zatvorskaJedinica = await session.LoadAsync<ZatvorskaJedinica>(idZatvorskeJedinice);
            Advokat advokat = await session.LoadAsync<Advokat>(zatvorenikBasic.Advokat!.JMBG);

            Zatvorenik z = new Zatvorenik
            {
                Ime = zatvorenikBasic.Ime!,
                Prezime = zatvorenikBasic.Prezime!,
                Adresa = zatvorenikBasic.Adresa!,
                Pol = zatvorenikBasic.Pol!,
                StatusUslovnogOtpusta = zatvorenikBasic.StatusUslovnogOtpusta!,
                DatumSledecegSaslusanja = zatvorenikBasic.DatumSledecegSaslusanja,
                AdvokatDatum = zatvorenikBasic.AdvokatDatum,
                AdvokatPoslednjiKontakt = zatvorenikBasic.AdvokatPoslednjiKontakt,
                ZatvorskaJedinica = zatvorskaJedinica,
                Advokat = advokat
            };

            await session.SaveOrUpdateAsync(z);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

    public static Result<bool, ErrorMessage> IzmeniZatvorenika(ZatvorenikBasic zatvorenikBasic, int idZatvorskeJedinice)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Zatvorenik zatvorenik = session.Load<Zatvorenik>(zatvorenikBasic.Id);

            zatvorenik.Ime = zatvorenikBasic.Ime!;
            zatvorenik.Prezime = zatvorenikBasic.Prezime!;
            zatvorenik.Adresa = zatvorenikBasic.Adresa!;
            zatvorenik.Pol = zatvorenikBasic.Pol!;
            zatvorenik.StatusUslovnogOtpusta = zatvorenikBasic.StatusUslovnogOtpusta!;
            zatvorenik.DatumSledecegSaslusanja = zatvorenikBasic.DatumSledecegSaslusanja;
            zatvorenik.AdvokatDatum = zatvorenikBasic.AdvokatDatum;
            zatvorenik.AdvokatPoslednjiKontakt = zatvorenikBasic.AdvokatPoslednjiKontakt;

            ZatvorskaJedinica zatvorskaJedinica = session.Load<ZatvorskaJedinica>(idZatvorskeJedinice);
            Advokat advokat =  session.Load<Advokat>(zatvorenikBasic.Advokat!.JMBG);

            zatvorenik.ZatvorskaJedinica = zatvorskaJedinica;
            if (advokat != null)
                zatvorenik.Advokat = advokat;

            session.Update(zatvorenik);
            session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<ZatvorenikBasic?, ErrorMessage> VratiZatvorenika(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Zatvorenik zatvorenik =  session.Load<Zatvorenik>(id);

            string jmbg = "";
            string ime = "";
            string prezime = "";
            if (zatvorenik.Advokat != null)
            {
                jmbg = zatvorenik.Advokat.JMBG!;
                ime = zatvorenik.Advokat.Ime!;
                prezime = zatvorenik.Advokat.Prezime!;
            }

            AdvokatBasic advokat = new AdvokatBasic(jmbg, ime, prezime);

            ZatvorskaJedinicaBasic zatvorskaJedinica = new ZatvorskaJedinicaBasic(zatvorenik.ZatvorskaJedinica.Id, zatvorenik.ZatvorskaJedinica.Naziv, zatvorenik.ZatvorskaJedinica.Kapacitet, zatvorenik.ZatvorskaJedinica.Adresa);

            ZatvorenikBasic zatvorenikBasic = new ZatvorenikBasic(id, zatvorenik.Ime, zatvorenik.Prezime, zatvorenik.Adresa, zatvorenik.Pol, zatvorenik.StatusUslovnogOtpusta, zatvorenik.DatumSledecegSaslusanja, zatvorenik.AdvokatDatum, zatvorenik.AdvokatPoslednjiKontakt);

            zatvorenikBasic.Advokat = advokat;
            zatvorenikBasic.ZatvorskaJedinica = zatvorskaJedinica;

            return zatvorenikBasic;

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

    }

    public static Result<bool, ErrorMessage> ObrisiZatvorenika(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Zatvorenik z = session.Load<Zatvorenik>(id);

            session.Delete(z);
             session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
        }
        return true;
    }

    public static Result<List<ZatvorenikPregled>, ErrorMessage> VratiSveZatvorenike()
    {
        List<ZatvorenikPregled> zatvorenici = new List<ZatvorenikPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            IEnumerable<Zatvorenik> sviZatvorenici = session.Query<Zatvorenik>().ToList();

            foreach (Zatvorenik z in sviZatvorenici)
            {
                ZatvorenikPregled pregled = new ZatvorenikPregled(z.Id, z.Ime, z.Prezime, z.Adresa, z.Pol, z.StatusUslovnogOtpusta, z.DatumSledecegSaslusanja, z.Advokat?.Ime + " " + z.Advokat?.Prezime, z.AdvokatDatum, z.AdvokatPoslednjiKontakt);
                pregled.NazivZatvorskeJedinice = z.ZatvorskaJedinica.Naziv;
                zatvorenici.Add(pregled);
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

        return zatvorenici;
    }

    #endregion

    #region Advokati

    public static Result<List<AdvokatPregled>?, ErrorMessage> VratiSveAdvokate()
    {
        List<AdvokatPregled> advokati = new List<AdvokatPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }


            IEnumerable<Advokat> sviAdvokati = session.Query<Advokat>().ToList();

            foreach (Advokat a in sviAdvokati)
            {
                advokati.Add(new AdvokatPregled(a.JMBG, a.Ime, a.Prezime));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

        return advokati;
    }

    public static Result<AdvokatBasic?, ErrorMessage> VratiAdvokata(string jmbg)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            Advokat advokat = session.Load<Advokat>(jmbg);

            AdvokatBasic advokatBasic = new AdvokatBasic(jmbg, advokat.Ime, advokat.Prezime);

            return advokatBasic;

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

    }

    public static async Task<Result<bool, ErrorMessage>> DodajAdvokataAsync(AdvokatBasic advokatBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            Advokat advokat = new Advokat
            { 
                JMBG = advokatBasic.JMBG!, 
                Ime = advokatBasic.Ime!, 
                Prezime = advokatBasic.Prezime!
            };

            await session.SaveOrUpdateAsync(advokat);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<bool, ErrorMessage> IzmeniAdvokata(AdvokatBasic advokatBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }


            Advokat advokat = session.Load<Advokat>(advokatBasic.JMBG);

            if (advokat == null)
            {
                return "Došlo je do greške!".ToError(404);
            }

            advokat.Ime = advokatBasic.Ime!;
            advokat.Prezime = advokatBasic.Prezime!;

            session.Update(advokat);
             session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
   }

    public static Result<bool, ErrorMessage> ObrisiAdvokata(string advokatJMBG)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Advokat advokat =  session.Load<Advokat>(advokatJMBG);

            IList<Zatvorenik> zatvorenici = advokat.Zatvorenici.ToList();
            
            foreach(Zatvorenik z in zatvorenici)
            {
                z.Advokat = null;
                advokat.Zatvorenici.Remove(z);
                session.Update(z);
                session.Update(advokat);
            }

            session.Delete(advokat);
            session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

    public static Result<bool, ErrorMessage> OtkaziZastupanje(int zatvorenikId)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Zatvorenik zatvorenik =  session.Load<Zatvorenik>(zatvorenikId);

            zatvorenik.Advokat = null;

            session.SaveOrUpdate(zatvorenik);
            session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

    public static Result<bool, ErrorMessage> DodajZastupanje(int zatvorenikId, string advokatJMBG)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Zatvorenik zatvorenik =  session.Load<Zatvorenik>(zatvorenikId);

            if (zatvorenik == null)
            {
                return "Došlo je do greške!".ToError(404);
            }

            Advokat advokat = session.Load<Advokat>(advokatJMBG);

            if (advokat == null)
            {
                return "Došlo je do greške!".ToError(404);
            }

            zatvorenik.Advokat = advokat;

            session.SaveOrUpdate(zatvorenik);
            session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

    #endregion

    #region Zaposleni

    public static Zaposleni? KreirajZaposlenog(ZaposleniBasic zaposleni, ISession session)
    {

        Zaposleni? z = null;

        if (zaposleni is ZaposleniAdministracijaBasic)
        {
            z = new ZaposleniAdministracija
            {
                JMBG = zaposleni.JMBG,
                Ime = zaposleni.Ime,
                Prezime = zaposleni.Prezime,
                DatumObuke = zaposleni.DatumObuke,
                StrucnaSprema = (zaposleni as ZaposleniAdministracijaBasic)!.StrucnaSprema,
                Zanimanje = (zaposleni as ZaposleniAdministracijaBasic)!.Zanimanje
            };
        }
        else if (zaposleni is PsihologBasic)
        {
            z = new Psiholog
            {
                JMBG = zaposleni.JMBG,
                Ime = zaposleni.Ime,
                Prezime = zaposleni.Prezime,
                DatumObuke = zaposleni.DatumObuke
            };
        }
        else if (zaposleni is RadnikObezbedjenjaBasic)
        {
            z = new RadnikObezbedjenja
            {
                JMBG = zaposleni.JMBG,
                Ime = zaposleni.Ime,
                Prezime = zaposleni.Prezime,
                DatumObuke = zaposleni.DatumObuke
            };
        }

        if (zaposleni.RadiU != null)
        {
            //ZatvorskaJedinica zatvor = session.Load<ZatvorskaJedinica>(zaposleni.RadiU.ZatvorskaJedinicaId);
            //RadiU radiU = new RadiU
            //{
            //    Zaposleni = z,
            //    ZatvorskaJedinica = zatvor,
            //    NazivRadnogMesta = zaposleni.RadiU.NazivRadnogMesta,
            //    DatumPocetkaRada = zaposleni.RadiU.DatumPocetkaRada
            //};
            //z?.RadnaMesta.Add(radiU);
        }


        return z;
    }

    //treba nam ovako za api verziju, gotovo
    public static Zaposleni? KreirajZaposlenogAPI(string tipZaposlenog, ZaposleniBasic zaposleni, ISession session)
    {
        Zaposleni? z = null;

        switch (tipZaposlenog.ToLower())
        {
            case "administracija":
                z = new ZaposleniAdministracija
                {
                    JMBG = zaposleni.JMBG,
                    Ime = zaposleni.Ime,
                    Prezime = zaposleni.Prezime,
                    DatumObuke = zaposleni.DatumObuke,
                    StrucnaSprema = zaposleni.StrucnaSprema,
                    Zanimanje = zaposleni.Zanimanje
                };
                break;

            case "psiholog":
                z = new Psiholog
                {
                    JMBG = zaposleni.JMBG,
                    Ime = zaposleni.Ime,
                    Prezime = zaposleni.Prezime,
                    DatumObuke = zaposleni.DatumObuke
                };
                break;

            case "obezbedjenje":
                z = new RadnikObezbedjenja
                {
                    JMBG = zaposleni.JMBG,
                    Ime = zaposleni.Ime,
                    Prezime = zaposleni.Prezime,
                    DatumObuke = zaposleni.DatumObuke
                };
                break;

            default:
                return null;
        }

        if (zaposleni.RadiU != null)
        {
            ZatvorskaJedinica zatvor = session.Load<ZatvorskaJedinica>(zaposleni.RadiU.FirstOrDefault().ZatvorskaJedinicaId);
            RadiU radiU = new RadiU
            {
                Zaposleni = z,
                ZatvorskaJedinica = zatvor,
                NazivRadnogMesta = zaposleni.RadiU.FirstOrDefault().NazivRadnogMesta,
                DatumPocetkaRada = zaposleni.RadiU.FirstOrDefault().DatumPocetkaRada
            };
            z?.RadnaMesta.Add(radiU);
        }

        return z;
    }


    //public static ZaposleniBasic? KreirajZaposlenogBasic(Zaposleni zaposleni, int idZatvorskeJedinice, string radnoMesto)
    //{

    //    ZaposleniBasic? z = null;
    //    string tip = VratiTipZaposlenog(zaposleni);
    //    if (zaposleni is ZaposleniAdministracija a)
    //    {
    //        z = new ZaposleniAdministracijaBasic
    //        {
    //            JMBG = zaposleni.JMBG,
    //            Ime = zaposleni.Ime,
    //            Prezime = zaposleni.Prezime,
    //            DatumObuke = zaposleni.DatumObuke,
    //            StrucnaSprema = a.StrucnaSprema,
    //            Zanimanje = a.Zanimanje,
    //        };
    //    }
    //    else if (zaposleni is Psiholog)
    //    {
    //        z = new PsihologBasic
    //        {
    //            JMBG = zaposleni.JMBG,
    //            Ime = zaposleni.Ime,
    //            Prezime = zaposleni.Prezime,
    //            DatumObuke = zaposleni.DatumObuke
    //        };
    //    }
    //    else if (zaposleni is RadnikObezbedjenja)
    //    {
    //        z = new RadnikObezbedjenjaBasic
    //        {
    //            JMBG = zaposleni.JMBG,
    //            Ime = zaposleni.Ime,
    //            Prezime = zaposleni.Prezime,
    //            DatumObuke = zaposleni.DatumObuke
    //        };
    //    }

    //    if (idZatvorskeJedinice != 0)
    //    {
    //        RadiU? radiU = zaposleni.RadnaMesta.Where(x => x.ZatvorskaJedinica.Id == idZatvorskeJedinice && x.NazivRadnogMesta == radnoMesto).FirstOrDefault();
    //        RadiUBasic radiUBasic = new RadiUBasic(radiU!.DatumPocetkaRada, radiU!.NazivRadnogMesta, radiU!.ZatvorskaJedinica.Id);
    //        z!.RadiU = radiUBasic;
    //    }

    //    return z;
    //}
    public static ZaposleniBasic? KreirajZaposlenogBasicAPI(Zaposleni zaposleni, int idZatvorskeJedinice, string radnoMesto,string tip)
    {

        ZaposleniBasic? z = null;
        
        if (zaposleni is ZaposleniAdministracija a)
        {
            z = new ZaposleniAdministracijaBasic
            {
                JMBG = zaposleni.JMBG,
                Ime = zaposleni.Ime,
                Prezime = zaposleni.Prezime,
                DatumObuke = zaposleni.DatumObuke,
                StrucnaSprema = a.StrucnaSprema,
                Zanimanje = a.Zanimanje,
            };
        }
        else if (zaposleni is Psiholog)
        {
            z = new PsihologBasic
            {
                JMBG = zaposleni.JMBG,
                Ime = zaposleni.Ime,
                Prezime = zaposleni.Prezime,
                DatumObuke = zaposleni.DatumObuke
            };
        }
        else if (zaposleni is RadnikObezbedjenja)
        {
            z = new RadnikObezbedjenjaBasic
            {
                JMBG = zaposleni.JMBG,
                Ime = zaposleni.Ime,
                Prezime = zaposleni.Prezime,
                DatumObuke = zaposleni.DatumObuke
            };
        }

        if (idZatvorskeJedinice != 0)
        {
            RadiU? radiU = zaposleni.RadnaMesta.Where(x => x.ZatvorskaJedinica.Id == idZatvorskeJedinice && x.NazivRadnogMesta == radnoMesto).FirstOrDefault();
            RadiUBasic radiUBasic = new RadiUBasic(radiU!.DatumPocetkaRada, radiU!.NazivRadnogMesta, radiU!.ZatvorskaJedinica.Id);
            z!.RadiU.Add( radiUBasic);
        }

        return z;
    }
    public static string VratiTipZaposlenog(Zaposleni z)
    {
        if (z is ZaposleniAdministracija)
        {
            return "Administracija";
        }
        else if (z is Psiholog)
        {
            return "Psiholog";
        }
        else if (z is RadnikObezbedjenja)
        {
            return "Obezbeđenje";
        }
        return String.Empty;
    }

    //=========================================
    public static  Result<List<ZaposleniPregled>, ErrorMessage> VratiZaposleneZaZatvorskuJedinicu(int idZatvorskeJedinice)
    {
        List<ZaposleniPregled> zaposleni = new List<ZaposleniPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            ZatvorskaJedinica zatvor = session.Load<ZatvorskaJedinica>(idZatvorskeJedinice);

            IList<RadiU> radiULista = zatvor.Zaposleni;
            Zaposleni z;

            foreach (RadiU r in radiULista)
            {
                z = r.Zaposleni;

                string zanimanje = "";
                string strucnaSprema = "";

                if (z is ZaposleniAdministracija a)
                {
                    zanimanje = a.Zanimanje!;
                    strucnaSprema = a.StrucnaSprema!;
                }

                zaposleni.Add(new ZaposleniPregled(z.JMBG, z.Ime, z.Prezime, z.DatumObuke, VratiTipZaposlenog(z), zanimanje, strucnaSprema, r.NazivRadnogMesta, r.DatumPocetkaRada));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return zaposleni;
    }

    public static async Task<Result<bool, ErrorMessage>> DodajZaposlenogAsync(ZaposleniBasic zaposleniBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            Zaposleni z = KreirajZaposlenog(zaposleniBasic, session)!;

            if (z == null)
            {
                return "Došlo je do greške!".ToError(404);
            }

           session.SaveOrUpdate(z);
           session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }
    //ovo treba za api , gotovo
    public static async Task<Result<bool, ErrorMessage>> DodajZaposlenogAsyncAPI(string tipZaposlenog, ZaposleniBasic zaposleniBasic)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            Zaposleni? z = KreirajZaposlenogAPI(tipZaposlenog, zaposleniBasic, session);

            if (z == null)
            {
                return "Došlo je do greške!".ToError(404);
            }

            await session.SaveOrUpdateAsync(z);
            await session.FlushAsync();
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }


    public static Result<bool, ErrorMessage> IzmeniZaposlenog(ZaposleniPregled zaposleniBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }


            Zaposleni z;

            if (zaposleniBasic.TipZaposlenog == "administracija")
                z =  session.Load<ZaposleniAdministracija>(zaposleniBasic.JMBG);
            else if (zaposleniBasic.TipZaposlenog == "psiholog")
                z = session.Load<Psiholog>(zaposleniBasic.JMBG);
            else
                z =  session.Load<RadnikObezbedjenja>(zaposleniBasic.JMBG);

            if (z == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            z.Ime = zaposleniBasic.Ime!;
            z.Prezime = zaposleniBasic.Prezime!;
            z.DatumObuke = zaposleniBasic.DatumObuke;

            if (zaposleniBasic.TipZaposlenog == "administracija")
            {
                (z as ZaposleniAdministracija)!.Zanimanje = zaposleniBasic.Zanimanje!;
                (z as ZaposleniAdministracija)!.StrucnaSprema = zaposleniBasic.StrucnaSprema!;
            }

            session.Update(z);

            //if (zaposleniBasic.RadiU != null)
            //{
            //    RadiU radiU = session.Query<RadiU>().Where(x => x.Zaposleni.JMBG == z.JMBG && x.ZatvorskaJedinica.Id == zaposleniBasic.RadiU.ZatvorskaJedinicaId && x.NazivRadnogMesta == staroRadnoMesto).FirstOrDefault();

            //    radiU.DatumPocetkaRada = zaposleniBasic.RadiU.DatumPocetkaRada;
            //    radiU.NazivRadnogMesta = zaposleniBasic.RadiU.NazivRadnogMesta;

            //    session.Update(radiU);
            //}

           session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    //public static Result<ZaposleniBasic?, ErrorMessage> VratiZaposlenog(string id,  int idZatvorskeJedinice)
    //{

    //    ISession? session = null;

    //    try
    //    {
    //        session = DataLayer.GetSession();


    //        if (session == null)
    //        {
    //            return "Veza ka bazi nije uspostavljena.".ToError(403);
    //        }

    //        //Zaposleni? z = null;

    //        //if (tip == "Administracija")
    //        //    z =  session.Load<ZaposleniAdministracija>(id);
    //        //else if (tip == "Psiholog")
    //        //    z =  session.Load<Psiholog>(id);
    //        //else if (tip == "Radnik obezbeđenja")
    //        //    z =  session.Load<RadnikObezbedjenja>(id);

    //        Zaposleni? z = session.Load<Zaposleni>(id);

    //        Type actualType = NHibernateUtil.GetClass(z);

    //        string tip = actualType.Name.ToString();
    //        //kako da izvucem id zatvorske jedinice uz id zaposlenog

    //        string radnoMestoZaposlenog = z.RadnaMesta.Where(x => x.ZatvorskaJedinica.Id == idZatvorskeJedinice).FirstOrDefault().NazivRadnogMesta;




    //        return KreirajZaposlenogBasicAPI(z!, idZatvorskeJedinice, radnoMestoZaposlenog, actualType);

    //    }
    //    catch (Exception ex)
    //    {
    //        return ex.Message.ToError(400);
    //    }
    //    finally
    //    {
    //        session?.Close();
    //        session?.Dispose();
    //    }

    //}

    //gotovo 
    public static Result<ZaposleniBasic?, ErrorMessage> VratiZaposlenogAPI(string id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            Zaposleni original = session.Load<Zaposleni>(id);

            Type actualType = NHibernateUtil.GetClass(original);

            string tip = actualType.Name.ToString();


            Zaposleni ? zaposleni = null;
            ZaposleniBasic? z = null;

            if (tip == "ZaposleniAdministracija")
            {
                zaposleni = session.Load<ZaposleniAdministracija>(id);
                z = new ZaposleniAdministracijaBasic
                {
                    JMBG = zaposleni.JMBG,
                    Ime = zaposleni.Ime,
                    Prezime = zaposleni.Prezime,
                    DatumObuke = zaposleni.DatumObuke,
                    StrucnaSprema = (zaposleni as ZaposleniAdministracija).StrucnaSprema,
                    Zanimanje = (zaposleni as ZaposleniAdministracija).Zanimanje,
                    RadiU = new List<RadiUBasic>()
                };

            }
            else if (tip == "Psiholog")
            {
                zaposleni = session.Load<Psiholog>(id);
                z = new PsihologBasic
                {
                    JMBG = zaposleni.JMBG,
                    Ime = zaposleni.Ime,
                    Prezime = zaposleni.Prezime,
                    DatumObuke = zaposleni.DatumObuke,
                    RadiU = new List<RadiUBasic>()

                };
            }
            else if (tip == "RadnikObezbedjenja")
            {
                zaposleni = session.Load<RadnikObezbedjenja>(id);
                z = new RadnikObezbedjenjaBasic
                {
                    JMBG = zaposleni.JMBG,
                    Ime = zaposleni.Ime,
                    Prezime = zaposleni.Prezime,
                    DatumObuke = zaposleni.DatumObuke,
                    RadiU = new List<RadiUBasic>()

                };
            
            }

            var radnoMesto = zaposleni.RadnaMesta.FirstOrDefault(x => x.Zaposleni.JMBG == id);
            if (radnoMesto != null)
            {
                int idZatvorskeJedinice = radnoMesto.ZatvorskaJedinica.Id;
                // Sada možete nastaviti sa korišćenjem idZatvorskeJedinice
            }

            //if (idZatvorskeJedinice != 0)
            //{
            //    RadiU? radiU = zaposleni.RadnaMesta.Where(x => x.ZatvorskaJedinica.Id == idZatvorskeJedinice).FirstOrDefault();
            //    IList<RadiU> lista;

            //    RadiUBasic radiUBasic = new RadiUBasic(radiU!.DatumPocetkaRada, radiU!.NazivRadnogMesta, radiU!.ZatvorskaJedinica.Id);
            //    z!.RadnaMesta.Add(radiUBasic);
            //}

            if (zaposleni.RadnaMesta.Count > 0)
            {
                IList<RadiU> lista = zaposleni.RadnaMesta;
                foreach(RadiU r in lista)
                {
                    if(r!=null)
                    {
                        RadiUBasic radiUBasic = new RadiUBasic(r.DatumPocetkaRada, r.NazivRadnogMesta, r.ZatvorskaJedinica.Id);
                        z!.RadiU.Add(radiUBasic);
                    }
                }
            }

            return z;

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

    }
    //gotovo
    public static Result<bool, ErrorMessage> ObrisiZaposlenog(string id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Zaposleni z =  session.Query<Zaposleni>().Where(x => x.JMBG == id).FirstOrDefault();

            if (z is ZaposleniAdministracija a)
            {
                if (a.ZatvorskaJedinica != null)
                {
                    a.ZatvorskaJedinica!.Upravnik = null;
                    session.Update(a.ZatvorskaJedinica);
                    a.ZatvorskaJedinica = null;
                     session.Update(a);
                }
            }

             session.Delete(z);
             session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

    //gotovo
    public static Result<List<ZaposleniBasic>, ErrorMessage> VratiSveZaposlene()
    {
        List<ZaposleniBasic> zaposleni = new List<ZaposleniBasic>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            IEnumerable<Zaposleni> sviZaposleni =  session.Query<Zaposleni>().ToList();

            foreach (Zaposleni z in sviZaposleni)
            {
                
                string zanimanje = "";
                string strucnaSprema = "";

                if (z is ZaposleniAdministracija a)
                {
                    zanimanje = a.Zanimanje!;
                    strucnaSprema = a.StrucnaSprema!;
                }

                //zaposleni.Add(new ZaposleniPregled(z.JMBG, z.Ime, z.Prezime, z.DatumObuke, VratiTipZaposlenog(z), zanimanje, strucnaSprema, "", DateTime.Now));
                ZaposleniBasic zb;
                if(z is ZaposleniAdministracija)
                {
                    zb = new ZaposleniAdministracijaBasic
                    {
                        JMBG = z.JMBG,
                        Ime = z.Ime,
                        Prezime = z.Prezime,
                        DatumObuke = z.DatumObuke,
                        StrucnaSprema = (z as ZaposleniAdministracija).StrucnaSprema,
                        Zanimanje = (z as ZaposleniAdministracija).Zanimanje,
                        RadiU = new List<RadiUBasic>()
                    };
                }
                else if(z is Psiholog)
                {
                    zb = new PsihologBasic
                    {
                        JMBG = z.JMBG,
                        Ime = z.Ime,
                        Prezime = z.Prezime,
                        DatumObuke = z.DatumObuke,
                        RadiU = new List<RadiUBasic>()
                    };
                }
                else
                {
                    zb = new RadnikObezbedjenjaBasic
                    {
                        JMBG = z.JMBG,
                        Ime = z.Ime,
                        Prezime = z.Prezime,
                        DatumObuke = z.DatumObuke,
                        RadiU = new List<RadiUBasic>()
                    };
                }   


                if(z.RadnaMesta.Count > 0)
                {
                       IList<RadiU> lista = z.RadnaMesta;
                    foreach(RadiU r in lista)
                    {
                        if(r!=null)
                        {
                            RadiUBasic radiUBasic = new RadiUBasic(r.DatumPocetkaRada, r.NazivRadnogMesta, r.ZatvorskaJedinica.Id);
                            zb.RadiU.Add(radiUBasic);
                        }
                    }
                }
                zaposleni.Add(zb);



            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
        }

        return zaposleni;
    }

    //gotovo
    public static Result<bool, ErrorMessage> ZaposliRadnika(string idZaposlenog, RadiUBasic radiU)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            Zaposleni z =  session.Load<Zaposleni>(idZaposlenog);

            if (z == null)
            {
                return "Došlo je do greške!".ToError(404);
            }

            ZatvorskaJedinica zatvor = session.Load<ZatvorskaJedinica>(radiU.ZatvorskaJedinicaId);

            RadiU test = session.Query<RadiU>().Where(x => x.Zaposleni.JMBG == idZaposlenog && x.ZatvorskaJedinica.Id == radiU.ZatvorskaJedinicaId && x.NazivRadnogMesta == radiU.NazivRadnogMesta).FirstOrDefault();

            if (test != null)
            {
                return "Zaposleni je već zapošljen u toj zatvorskoj jedinici na tom radnom mestu!".ToError(401);
                
            }

            RadiU r = new RadiU
            {
                Zaposleni = z,
                ZatvorskaJedinica = zatvor,
                NazivRadnogMesta = radiU.NazivRadnogMesta,
                DatumPocetkaRada = radiU.DatumPocetkaRada
            };

            z.RadnaMesta.Add(r);

            session.SaveOrUpdate(r);
            session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    //gotovo
    public static Result<List<RadiUPregled>, ErrorMessage> VratiZaposlenjaZaZaposlenog(string zaposleniJMBG)
    {
        List<RadiUPregled> zaposlenja = new List<RadiUPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            List<RadiU> radiULista =  session.Query<RadiU>().Where(x => x.Zaposleni.JMBG == zaposleniJMBG).ToList();

            foreach (RadiU r in radiULista)
            {
                zaposlenja.Add(new RadiUPregled(r.Zaposleni.JMBG, r.Zaposleni.Ime, r.Zaposleni.Prezime, r.ZatvorskaJedinica.Naziv, r.NazivRadnogMesta, r.DatumPocetkaRada));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return zaposlenja;
    }

    //gotovo
    public static Result<bool, ErrorMessage> ObrisiRadnoMesto(string zaposleniJMBG, int zatvorskaJedinicaId, string radnoMestoNaziv)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            RadiU radiU =  session.Query<RadiU>().Where(x => x.Zaposleni.JMBG == zaposleniJMBG && x.ZatvorskaJedinica.Id == zatvorskaJedinicaId && x.NazivRadnogMesta == radnoMestoNaziv).FirstOrDefault();

            if (radiU == null)
            {
                return "Došlo je do greške!".ToError(404);
            }

            session.Delete(radiU);
            session.Flush();
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    //gotovo
    public static async Task<Result<bool, ErrorMessage>>  IzmeniRadnoMesto(string zaposleniJMBG, int zatvorskaJedinicaId, string staroRadnoMesto, string radnoMestoNaziv, DateTime datumZaposlenja)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            RadiU radiU = await session.Query<RadiU>().Where(x => x.Zaposleni.JMBG == zaposleniJMBG && x.ZatvorskaJedinica.Id == zatvorskaJedinicaId && x.NazivRadnogMesta == staroRadnoMesto).FirstOrDefaultAsync();

            if (radiU == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            radiU.NazivRadnogMesta = radnoMestoNaziv;
            radiU.DatumPocetkaRada = datumZaposlenja;

            await session.UpdateAsync(radiU);
            await session.FlushAsync();
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

    #endregion

    #region LekarskiPregledi

    public static Result<List<LekarskiPregledPregled>, ErrorMessage> VratiLekarskePreglede(string zaposleniJMBG)
    {
        List<LekarskiPregledPregled> lekarskiPregledi = new List<LekarskiPregledPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            IEnumerable<LekarskiPregled> lista =  session.Query<LekarskiPregled>().Where(x => x.Zaposleni.JMBG == zaposleniJMBG).ToList();

            foreach (LekarskiPregled l in lista)
            {
                lekarskiPregledi.Add(new LekarskiPregledPregled(l.Id, l.Datum, l.NazivUstanove, l.AdresaUstanove, l.Lekar));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

        return lekarskiPregledi;
    }
    
    public static async Task<Result<bool, ErrorMessage>> DodajLekarskiPregledAsync(LekarskiPregledBasic lp, string zaposleniJMBG)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Zaposleni zaposleni = await session.LoadAsync<Zaposleni>(zaposleniJMBG);

            if (zaposleni == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            LekarskiPregled lekarskiPregled = new LekarskiPregled
            {
                Datum = lp.Datum,
                NazivUstanove = lp.NazivUstanove,
                AdresaUstanove = lp.AdresaUstanove,
                Lekar = lp.Lekar,
                Zaposleni = zaposleni
            };


            if (zaposleni is Psiholog p)
            {
                p.LekarskiPregledi.Add(lekarskiPregled);
            }
            else if (zaposleni is RadnikObezbedjenja o)
            {
                o.LekarskiPregledi.Add(lekarskiPregled);
            }

            await session.SaveOrUpdateAsync(lekarskiPregled);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<bool, ErrorMessage> IzmeniLekarskiPregled(LekarskiPregledBasic lp)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            LekarskiPregled lekarskiPregled =  session.Load<LekarskiPregled>(lp.Id);

            if (lekarskiPregled == null)
            {
                return "Došlo je do greške!".ToError(404);
            }

            lekarskiPregled.Datum = lp.Datum;
            lekarskiPregled.NazivUstanove = lp.NazivUstanove;
            lekarskiPregled.AdresaUstanove = lp.AdresaUstanove;
            lekarskiPregled.Lekar = lp.Lekar;

             session.Update(lekarskiPregled);
            session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<bool, ErrorMessage> ObrisiLekarskiPregled(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            LekarskiPregled lp = session.Load<LekarskiPregled>(id);

           session.Delete(lp);
           session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<LekarskiPregledBasic?, ErrorMessage> VratiLekarskiPregled(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            LekarskiPregled lp =  session.Load<LekarskiPregled>(id);

            LekarskiPregledBasic lekarskiPregled = new LekarskiPregledBasic(lp.Id, lp.Datum, lp.NazivUstanove, lp.AdresaUstanove, lp.Lekar);

            return lekarskiPregled;

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

    }

    public static Result<List<LekarskiPregledBasic>, ErrorMessage> VratiSveLekarskePreglede()
    {
        List<LekarskiPregledBasic> lekarskiPregledi = new List<LekarskiPregledBasic>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            IEnumerable<LekarskiPregled> lista = session.Query<LekarskiPregled>().ToList();

            foreach (LekarskiPregled lp in lista)
            {
                LekarskiPregledBasic lekarskiPregled = new LekarskiPregledBasic(lp.Id, lp.Datum, lp.NazivUstanove, lp.AdresaUstanove, lp.Lekar);
                lekarskiPregledi.Add(lekarskiPregled);
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return lekarskiPregledi;
    }


    #endregion

    #region Obuke

    public static Result<List<ObukaVatrenoOruzjePregled>, ErrorMessage> VratiObuke(string zaposleniJMBG)
    {
        List<ObukaVatrenoOruzjePregled> obuke = new List<ObukaVatrenoOruzjePregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            IEnumerable<ObukaVatrenoOruzje> lista =  session.Query<ObukaVatrenoOruzje>().Where(x => x.Radnik.JMBG == zaposleniJMBG).ToList();

            foreach (ObukaVatrenoOruzje o in lista)
            {
                obuke.Add(new ObukaVatrenoOruzjePregled(o.Id, o.DatumIzdavanja, o.PolicijskaUprava));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

        return obuke;
    }
    
    public static async Task<Result<bool, ErrorMessage>> DodajObuku(ObukaVatrenoOruzjeBasic o, string zaposleniJMBG)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            RadnikObezbedjenja zaposleni = await session.LoadAsync<RadnikObezbedjenja>(zaposleniJMBG);

            if (zaposleni == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            ObukaVatrenoOruzje obuka = new ObukaVatrenoOruzje
            {
                DatumIzdavanja = o.DatumIzdavanja,
                PolicijskaUprava = o.PolicijskaUprava,
                Radnik = zaposleni
            };

            zaposleni.ObukeVatrenoOruzje.Add(obuka);

            await session.SaveOrUpdateAsync(obuka);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

    public static Result<bool, ErrorMessage> IzmeniObuku(ObukaVatrenoOruzjeBasic o)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            ObukaVatrenoOruzje obuka =  session.Load<ObukaVatrenoOruzje>(o.Id);

            if (obuka == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            obuka.DatumIzdavanja = o.DatumIzdavanja;
            obuka.PolicijskaUprava = o.PolicijskaUprava;

             session.Update(obuka);
             session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

    public static Result<bool, ErrorMessage> ObrisiObuku(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            ObukaVatrenoOruzje o = session.Load<ObukaVatrenoOruzje>(id);

             session.Delete(o);
             session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<ObukaVatrenoOruzjeBasic?, ErrorMessage> VratiObuku(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            ObukaVatrenoOruzje o =  session.Load<ObukaVatrenoOruzje>(id);

            ObukaVatrenoOruzjeBasic obuka = new ObukaVatrenoOruzjeBasic(o.Id, o.DatumIzdavanja, o.PolicijskaUprava);

            return obuka;

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

    }

    #endregion

    #region Prestupi

    public static Result<List<PrestupPregled>, ErrorMessage> VratiSvePrestupe()
    {
        List<PrestupPregled> prestupi = new List<PrestupPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            IEnumerable<Prestup> lista =  session.Query<Prestup>().ToList();

            foreach (Prestup prestup in lista)
            {
                prestupi.Add(new PrestupPregled(prestup.Id, prestup.Naziv, prestup.Kategorija, prestup.Opis, prestup.MinKazna, prestup.MaxKazna));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return prestupi;
    }

    public async static Task<Result<bool, ErrorMessage>> DodajPrestupAsync(PrestupBasic prestupBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Prestup prestup = new Prestup
            {
                Naziv = prestupBasic.Naziv,
                Kategorija = prestupBasic.Kategorija,
                Opis = prestupBasic.Opis,
                MinKazna = prestupBasic.MinKazna,
                MaxKazna = prestupBasic.MaxKazna
            };

             session.SaveOrUpdate(prestup);
             session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
        }
        return true;
    }

    public static Result<bool, ErrorMessage> IzmeniPrestup(PrestupBasic prestupBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Prestup prestup =  session.Load<Prestup>(prestupBasic.Id);

            prestup.Naziv = prestupBasic.Naziv;
            prestup.Kategorija = prestupBasic.Kategorija;
            prestup.Opis = prestupBasic.Opis;
            prestup.MinKazna = prestupBasic.MinKazna;
            prestup.MaxKazna = prestupBasic.MaxKazna;

            session.Update(prestup);
             session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

    public static Result<bool, ErrorMessage> ObrisiPrestup(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Prestup prestup = session.Load<Prestup>(id);

             session.Delete(prestup);
             session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<PrestupBasic?, ErrorMessage> VratiPrestup(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Prestup prestup =  session.Load<Prestup>(id);
            PrestupBasic prestupBasic = new PrestupBasic(prestup.Id, prestup.Naziv, prestup.Kategorija, prestup.Opis, prestup.MinKazna, prestup.MaxKazna);

            return prestupBasic;

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

    }

    #endregion

    #region IzvrseniPrestupi

    public static Result<List<IzvrsenPrestupPregled>, ErrorMessage> VratiIzvrsenePrestupe(int zatvorenikID)
    {
        List<IzvrsenPrestupPregled> prestupi = new List<IzvrsenPrestupPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            IEnumerable<IzvrsenPrestup> lista =  session.Query<IzvrsenPrestup>().Where(x => x.Zatvorenik.Id == zatvorenikID).ToList();

            foreach (IzvrsenPrestup prestup in lista)
            {
                prestupi.Add(new IzvrsenPrestupPregled(prestup.Id, prestup.Datum, prestup.Mesto, prestup.Prestup.Naziv, prestup.Prestup.Kategorija, prestup.Prestup.Opis, prestup.Prestup.MinKazna, prestup.Prestup.MaxKazna));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);

        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

        return prestupi;
    }

    public static async Task<Result<bool, ErrorMessage>> DodajIzvrsenPrestupAsync(IzvrsenPrestupBasic prestupBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Zatvorenik zatvorenik = await session.LoadAsync<Zatvorenik>(prestupBasic.IdZatvorenika);

            if (zatvorenik == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            Prestup prestup = await session.LoadAsync<Prestup>(prestupBasic.IdPrestupa);

            if (prestup == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            IzvrsenPrestup izvrsenPrestup = new IzvrsenPrestup
            {
                Datum = prestupBasic.Datum,
                Mesto = prestupBasic.Mesto,
                Prestup = prestup,
                Zatvorenik = zatvorenik
            };

            prestup.IzvrseniPrestupi.Add(izvrsenPrestup);
            zatvorenik.IzvrseniPrestupi.Add(izvrsenPrestup);

            await session.SaveOrUpdateAsync(izvrsenPrestup);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

        public static Result<bool, ErrorMessage> IzmeniIzvrsenPrestup(IzvrsenPrestupBasic prestupBasic)
        {

            ISession? session = null;

            try
            {
                session = DataLayer.GetSession();

                if (session == null)
                {
                    return "Veza ka bazi nije uspostavljena.".ToError(403);
                
                }

                IzvrsenPrestup izvrsenPrestup = session.Load<IzvrsenPrestup>(prestupBasic.Id);

                if (izvrsenPrestup == null)
                {
                    return "Došlo je do greške!".ToError(404);

                }

                izvrsenPrestup.Datum = prestupBasic.Datum;
                izvrsenPrestup.Mesto= prestupBasic.Mesto;

                 session.Update(izvrsenPrestup);
                 session.Flush();

            }
            catch (Exception ex)
            {
                return ex.Message.ToError(400);
            }
            finally
            {
                session?.Close();
                session?.Dispose();
            }
            return true;
        }

    public static Result<bool, ErrorMessage> ObrisiIzvrsenPrestup(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            IzvrsenPrestup izvrsenPrestup = session.Load<IzvrsenPrestup>(id);

             session.Delete(izvrsenPrestup);
             session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
        }
        return true;
    }

    public static Result<IzvrsenPrestupBasic?, ErrorMessage> VratiIzvrsenPrestup(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            IzvrsenPrestup izvrsenPrestup =  session.Load<IzvrsenPrestup>(id);

            IzvrsenPrestupBasic prestupBasic = new IzvrsenPrestupBasic(izvrsenPrestup.Id, izvrsenPrestup.Datum, izvrsenPrestup.Mesto, izvrsenPrestup.Zatvorenik.Id, izvrsenPrestup.Prestup.Id);

            return prestupBasic;

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
            
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

    }

    #endregion

    #region Firme

    public static Result<List<FirmaPregled>, ErrorMessage> VratiSveFirme()
    {
        List<FirmaPregled> firme = new List<FirmaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            IEnumerable<Firma> lista =  session.Query<Firma>().ToList();

            foreach (Firma firma in lista)
            {
                firme.Add(new FirmaPregled(firma.PIB, firma.Ime, firma.Adresa));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

        return firme;
    }

    public static Result<FirmaPregled?, ErrorMessage> VratiFirmuZatvorenika(int zatvorenikId)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Zatvorenik zatvorenik =  session.Load<Zatvorenik>(zatvorenikId);

            if (!(zatvorenik.ZatvorskaJedinica is OtvorenaZatvorskaJedinica
                || zatvorenik.ZatvorskaJedinica is OPZatvorskaJedinica
                || zatvorenik.ZatvorskaJedinica is OZZatvorskaJedinica))
            {
                return "Samo zatvorenici iz otvorenih zatvorskih jedinica mogu da rade u firmama!".ToError(405);
                
            }

            Firma? firma =  session.Query<Zatvorenik>()
                                       .Where(x => x.Id == zatvorenikId)
                                       .Select(x => x.Firma)
                                       .FirstOrDefault();


            FirmaPregled firmaPregled = new FirmaPregled(firma?.PIB, firma?.Ime, firma?.Adresa);
            return firmaPregled;
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
            
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
    }

    public static Result<List<FirmaPregled>, ErrorMessage> VratiFirmeZaZatvorenika(int zatvorenikId)
    {
        List<FirmaPregled> firme = new List<FirmaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Zatvorenik zatvorenik =  session.Load<Zatvorenik>(zatvorenikId);

            if (zatvorenik == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            ZatvorskaJedinica zatvorskaJedinica = zatvorenik.ZatvorskaJedinica;

            if (!(zatvorskaJedinica is OtvorenaZatvorskaJedinica
                || zatvorskaJedinica is OPZatvorskaJedinica
                || zatvorskaJedinica is OZZatvorskaJedinica))
            {
                return "Samo zatvorenici iz otvorenih zatvorskih jedinica mogu da rade u firmama!".ToError(405);
            }

            IEnumerable<Firma> lista =  session.Query<Firma>().Where(x => x.ZatvorskeJedinice.Contains(zatvorskaJedinica)).ToList();

            foreach (Firma firma in lista)
            {
                firme.Add(new FirmaPregled(firma.PIB, firma.Ime, firma.Adresa));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

        return firme;
    }

    public static Result<List<FirmaPregled>, ErrorMessage> VratiFirmeZaZatvorskuJedinicu(int zatvorskaJedinicaId)
    {
        List<FirmaPregled> firme = new List<FirmaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            ZatvorskaJedinica zatvorskaJedinica =  session.Query<ZatvorskaJedinica>().Where(x => x.Id == zatvorskaJedinicaId).FirstOrDefault();

            if (zatvorskaJedinica == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            if (!(zatvorskaJedinica is OtvorenaZatvorskaJedinica
                || zatvorskaJedinica is OPZatvorskaJedinica
                || zatvorskaJedinica is OZZatvorskaJedinica))
            {
                return "Samo zatvorenici iz otvorenih zatvorskih jedinica mogu da rade u firmama!".ToError(405);
                
            }

            IEnumerable<Firma> lista =  session.Query<Firma>().Where(x => x.ZatvorskeJedinice.Contains(zatvorskaJedinica)).ToList();

            foreach (Firma firma in lista)
            {
                firme.Add(new FirmaPregled(firma.PIB, firma.Ime, firma.Adresa));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return firme;
    }

    public static Result<List<FirmaPregled>, ErrorMessage> VratiSveFirmeZaSaradnju(int zatvorskaJedinicaId)
    {
        List<FirmaPregled> firme = new List<FirmaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            ZatvorskaJedinica zatvorskaJedinica =  session.Query<ZatvorskaJedinica>().Where(x => x.Id == zatvorskaJedinicaId).FirstOrDefault();

            if (zatvorskaJedinica == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            if (!(zatvorskaJedinica is OtvorenaZatvorskaJedinica
                || zatvorskaJedinica is OPZatvorskaJedinica
                || zatvorskaJedinica is OZZatvorskaJedinica))
            {
                return "Samo zatvorenici iz otvorenih zatvorskih jedinica mogu da rade u firmama!".ToError(405);
                
            }

            IEnumerable<Firma> lista =  session.Query<Firma>().Where(x => !x.ZatvorskeJedinice.Contains(zatvorskaJedinica)).ToList();

            foreach (Firma firma in lista)
            {
                firme.Add(new FirmaPregled(firma.PIB, firma.Ime, firma.Adresa));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

        return firme;
    }

    public static async Task<Result<bool, ErrorMessage>> DodajFirmu(FirmaBasic firmaBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Firma firma = new Firma
            {
                PIB = firmaBasic.PIB,
                Ime = firmaBasic.Ime,
                Adresa = firmaBasic.Adresa
            };

            await session.SaveOrUpdateAsync(firma);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<bool, ErrorMessage> IzmeniFirmu(FirmaBasic firmaBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }


            Firma firma =  session.Load<Firma>(firmaBasic.PIB);

            if (firma == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            firma.Ime = firmaBasic.Ime!;
            firma.Adresa = firmaBasic.Adresa!;

             session.Update(firma);
             session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<bool, ErrorMessage> ObrisiFirmu(int pib)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Firma firma =  session.Load<Firma>(pib);

            IList<ZatvorskaJedinica> zatvorskeJedinice = firma.ZatvorskeJedinice.ToList();

            foreach (ZatvorskaJedinica zatvorskaJedinica in zatvorskeJedinice)
            {
                if (zatvorskaJedinica is OtvorenaZatvorskaJedinica o)
                    o.Firme.Remove(firma);
                else if (zatvorskaJedinica is OPZatvorskaJedinica op)
                    op.Firme.Remove(firma);
                else if (zatvorskaJedinica is OZZatvorskaJedinica oz)
                    oz.Firme.Remove(firma);

                firma.ZatvorskeJedinice.Remove(zatvorskaJedinica);
                 session.Update(zatvorskaJedinica);
                 session.Update(firma);
            }

            IList<Zatvorenik> zatvorenici = firma.ZatvoreniciRadnici.ToList();

            foreach (Zatvorenik zatvorenik in zatvorenici)
            {
                zatvorenik.Firma = null;
                firma.ZatvoreniciRadnici.Remove(zatvorenik);
                 session.Update(zatvorenik);
                 session.Update(firma);
            }

             session.Delete(firma);
             session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<FirmaBasic?, ErrorMessage> VratiFirmu(int pib)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Firma firma =  session.Load<Firma>(pib);

            FirmaBasic firmaBasic = new FirmaBasic(firma.PIB, firma.Ime, firma.Adresa);

            return firmaBasic;

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
           
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

    }

    public static Result<bool, ErrorMessage> ZaposliZatvorenika(int zatvorenikId, int firmaPIB)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Zatvorenik zatvorenik =  session.Load<Zatvorenik>(zatvorenikId);

            if (zatvorenik == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            Firma firma =  session.Load<Firma>(firmaPIB);

            if (firma == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            zatvorenik.Firma = firma;
            firma.ZatvoreniciRadnici.Add(zatvorenik);

             session.SaveOrUpdate(zatvorenik);
             session.Flush();
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<bool, ErrorMessage> DajOtkazZatvoreniku(int zatvorenikId)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Zatvorenik zatvorenik =  session.Load<Zatvorenik>(zatvorenikId);

            if (zatvorenik == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            zatvorenik.Firma = null;

             session.SaveOrUpdate(zatvorenik);
             session.Flush();
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    //POSLEEEEEEEEEEEEEEEEEEEEEEEE
    public static Result<bool, ErrorMessage> OtkaziSaradnju(int zatvorskaJedinicaId, int firmaPIB)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            ZatvorskaJedinica zatvorskaJedinica =  session.Query<ZatvorskaJedinica>().Where(x => x.Id == zatvorskaJedinicaId).FirstOrDefault();

            if (zatvorskaJedinica == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            if (!(zatvorskaJedinica is OtvorenaZatvorskaJedinica
                || zatvorskaJedinica is OPZatvorskaJedinica
                || zatvorskaJedinica is OZZatvorskaJedinica))
            {
                return "Samo zatvorenici iz otvorenih zatvorskih jedinica mogu da rade u firmama!".ToError(405);
                
            }

            Firma firma =  session.Load<Firma>(firmaPIB);

            if (firma == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            if (zatvorskaJedinica is OtvorenaZatvorskaJedinica o)
            {
                o.Firme.Remove(firma);
            }
            else if (zatvorskaJedinica is OPZatvorskaJedinica op)
            {
                op.Firme.Remove(firma);
            }
            else if (zatvorskaJedinica is OZZatvorskaJedinica oz)
            {
                oz.Firme.Remove(firma);
            }

            firma.ZatvorskeJedinice.Remove(zatvorskaJedinica);

             session.SaveOrUpdate(zatvorskaJedinica);
             session.Flush();
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }
        return true;
    }

    public static Result<bool, ErrorMessage> ZapocniSaradnju(int zatvorskaJedinicaId, int firmaPIB)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            ZatvorskaJedinica zatvorskaJedinica =  session.Query<ZatvorskaJedinica>().Where(x => x.Id == zatvorskaJedinicaId).FirstOrDefault();

            if (zatvorskaJedinica == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            if (!(zatvorskaJedinica is OtvorenaZatvorskaJedinica
                || zatvorskaJedinica is OPZatvorskaJedinica
                || zatvorskaJedinica is OZZatvorskaJedinica))
            {
                return "Samo zatvorenici iz otvorenih zatvorskih jedinica mogu da rade u firmama!".ToError(405);
                
            }

            Firma firma =  session.Load<Firma>(firmaPIB);

            if (firma == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            if (zatvorskaJedinica is OtvorenaZatvorskaJedinica o)
            {
                o.Firme.Add(firma);
            }
            else if (zatvorskaJedinica is OPZatvorskaJedinica op)
            {
                op.Firme.Add(firma);
            }
            else if (zatvorskaJedinica is OZZatvorskaJedinica oz)
            {
                oz.Firme.Add(firma);
            }

            firma.ZatvorskeJedinice.Add(zatvorskaJedinica);

             session.SaveOrUpdate(zatvorskaJedinica);
             session.Flush();
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    #endregion

    #region Posete

    
    public static Result<List<PosetaPregled>, ErrorMessage> VratiPoseteZaZatvorenika(int zatvorenikID)
    {
        List<PosetaPregled> posete = new List<PosetaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                
               return "Veza ka bazi nije uspostavljena.".ToError(400);
                
            }

            IEnumerable<Poseta> lista = session.Query<Poseta>().Where(x => x.Zatvorenik.Id == zatvorenikID).ToList();


            foreach (Poseta p in lista)
            {
                posete.Add(new PosetaPregled(p.Id, p.Datum, p.VremeOd, p.VremeDo, p.Advokat.Ime + " " + p.Advokat.Prezime, p.Zatvorenik.Ime + " " + p.Zatvorenik.Prezime));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
        }

        return posete;
    }

    public static Result<List<PosetaPregled>, ErrorMessage> VratiPoseteZaAdvokata(string advokatJMBG)
    {
        List<PosetaPregled> posete = new List<PosetaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            IEnumerable<Poseta> lista =  session.Query<Poseta>().Where(x => x.Advokat.JMBG == advokatJMBG).ToList();

            foreach (Poseta p in lista)
            {
                posete.Add(new PosetaPregled(p.Id, p.Datum, p.VremeOd, p.VremeDo, p.Advokat.Ime + " " + p.Advokat.Prezime, p.Zatvorenik.Ime + " " + p.Zatvorenik.Prezime));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

        return posete;
    }

    public static async Task<Result<bool, ErrorMessage>> DodajPosetu(PosetaBasic posetaBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Zatvorenik zatvorenik = await session.LoadAsync<Zatvorenik>(posetaBasic.ZatvorenikId);

            if (zatvorenik == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            Advokat? advokat = zatvorenik.Advokat;

            if (advokat == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            Poseta poseta = new Poseta
            {
                Datum = posetaBasic.Datum,
                VremeOd = posetaBasic.VremeOd,
                VremeDo = posetaBasic.VremeDo,
                Advokat = advokat,
                Zatvorenik = zatvorenik
            };

            zatvorenik.Posete.Add(poseta);
            advokat.Posete.Add(poseta);

            await session.SaveOrUpdateAsync(poseta);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<bool, ErrorMessage> IzmeniPosetu(PosetaBasic posetaBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Poseta poseta =  session.Load<Poseta>(posetaBasic.Id);

            if (poseta == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            poseta.Datum = posetaBasic.Datum;
            poseta.VremeOd = posetaBasic.VremeOd;
            poseta.VremeDo = posetaBasic.VremeDo;

             session.Update(poseta);
             session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<bool, ErrorMessage> ObrisiPosetu(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Poseta poseta = session.Load<Poseta>(id);

             session.Delete(poseta);
             session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
        }
        return true;
    }

    public static Result<PosetaBasic?, ErrorMessage> VratiPosetu(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Poseta poseta =  session.Load<Poseta>(id);

            PosetaBasic posetaBasic = new PosetaBasic(poseta.Id, poseta.Datum, poseta.VremeOd, poseta.VremeDo, poseta.Zatvorenik.Id);

            return posetaBasic;

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
            
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

    }


    public static Result<List<PosetaPregled>, ErrorMessage> VratiSvePosete()
    {
        List<PosetaPregled> posete = new List<PosetaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            IEnumerable<Poseta> lista = session.Query<Poseta>().ToList();

            foreach (Poseta p in lista)
            {
                posete.Add(new PosetaPregled(
                    p.Id,
                    p.Datum,
                    p.VremeOd,
                    p.VremeDo,
                    p.Advokat.Ime + " " + p.Advokat.Prezime,
                    p.Zatvorenik.Ime + " " + p.Zatvorenik.Prezime
                ));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return posete;
    }


    #endregion

    #region OdgovornaLica

    public static Result<List<OdgovornoLicePregled>, ErrorMessage> VratiOdgovornaLicaZaFirmu(int firmaPIB)
    {
        List<OdgovornoLicePregled> odgovornaLica = new List<OdgovornoLicePregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            IEnumerable<OdgovornoLice> lista =  session.Query<OdgovornoLice>().Where(x => x.Firma.PIB == firmaPIB).ToList();

            foreach (OdgovornoLice o in lista)
            {
                odgovornaLica.Add(new OdgovornoLicePregled(o.Id, o.Ime, o.Prezime));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

        return odgovornaLica;
    }

    public static Result<OdgovornoLiceBasic?, ErrorMessage> VratiOdgovornoLice(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            OdgovornoLice odgovornoLice =  session.Load<OdgovornoLice>(id);

            OdgovornoLiceBasic odgovornoLiceBasic = new OdgovornoLiceBasic(odgovornoLice.Id, odgovornoLice.Ime, odgovornoLice.Prezime);

            return odgovornoLiceBasic;

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
            
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

    }

    public static async Task<Result<bool, ErrorMessage>> DodajOdgovornoLiceAsync(OdgovornoLiceBasic odgovornoLiceBasic, int firmaPIB)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Firma firma = await session.LoadAsync<Firma>(firmaPIB);

            if (firma == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            OdgovornoLice odgovornoLice = new OdgovornoLice
            {
                Ime = odgovornoLiceBasic.Ime,
                Prezime = odgovornoLiceBasic.Prezime,
                Firma = firma
            };

            await session.SaveOrUpdateAsync(odgovornoLice);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<bool, ErrorMessage> IzmeniOdgovornoLice(OdgovornoLiceBasic odgovornoLiceBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }


            OdgovornoLice odgovornoLice =  session.Load<OdgovornoLice>(odgovornoLiceBasic.Id);

            if (odgovornoLice == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            odgovornoLice.Ime = odgovornoLiceBasic.Ime!;
            odgovornoLice.Prezime = odgovornoLiceBasic.Prezime!;

             session.Update(odgovornoLice);
             session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<bool, ErrorMessage> ObrisiOdgovornoLice(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            OdgovornoLice odgovornoLice =  session.Load<OdgovornoLice>(id);

             session.Delete(odgovornoLice);
             session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<List<OdgovornoLiceBasic>, ErrorMessage> VratiSvaOdgovornaLica()
    {
        List<OdgovornoLiceBasic> odgovornaLica = new List<OdgovornoLiceBasic>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            IEnumerable<OdgovornoLice> lista = session.Query<OdgovornoLice>().ToList();

            foreach (OdgovornoLice o in lista)
            {
                odgovornaLica.Add(new OdgovornoLiceBasic(o.Id, o.Ime, o.Prezime));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return odgovornaLica;
    }



    #endregion

    #region FirmaTelefon

    public static Result<List<FirmaTelefonPregled>, ErrorMessage> VratiTelefoneZaFirmu(int firmaPIB)
    {
        List<FirmaTelefonPregled> telefoni = new List<FirmaTelefonPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            IEnumerable<FirmaTelefon> lista =  session.Query<FirmaTelefon>().Where(x => x.Firma.PIB == firmaPIB).ToList();

            foreach (FirmaTelefon ft in lista)
            {
                telefoni.Add(new FirmaTelefonPregled(ft.Id, ft.BrojTelefona));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

        return telefoni;
    }

    public static Result<FirmaTelefonBasic?, ErrorMessage> VratiTelefon(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            FirmaTelefon telefon =  session.Load<FirmaTelefon>(id);

            FirmaTelefonBasic telefonBasic = new FirmaTelefonBasic(telefon.Id, telefon.BrojTelefona);

            return telefonBasic;

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
            
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }

    }

    public static async Task<Result<bool, ErrorMessage>> DodajTelefonAsync(FirmaTelefonBasic telefonBasic, int firmaPIB)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            Firma firma = await session.LoadAsync<Firma>(firmaPIB);

            if (firma == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            FirmaTelefon firmaTelefon = new FirmaTelefon
            {
                BrojTelefona = telefonBasic.BrojTelefona,
                Firma = firma
            };

            await session.SaveOrUpdateAsync(firmaTelefon);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<bool, ErrorMessage> IzmeniTelefon(FirmaTelefonBasic telefonBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            FirmaTelefon telefon =  session.Load<FirmaTelefon>(telefonBasic.Id);

            if (telefon == null)
            {
                return "Došlo je do greške!".ToError(404);

            }

            telefon.BrojTelefona = telefonBasic.BrojTelefona!;

             session.Update(telefon);
             session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<bool, ErrorMessage> ObrisiTelefon(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);

            }

            FirmaTelefon firmaTelefon =  session.Load<FirmaTelefon>(id);

             session.Delete(firmaTelefon);
             session.Flush();

        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();

        }
        return true;
    }

    public static Result<List<FirmaTelefonPregled>, ErrorMessage> VratiSveTelefone()
    {
        List<FirmaTelefonPregled> telefoni = new List<FirmaTelefonPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                return "Veza ka bazi nije uspostavljena.".ToError(403);
            }

            IEnumerable<FirmaTelefon> lista = session.Query<FirmaTelefon>().ToList();

            foreach (FirmaTelefon ft in lista)
            {
                telefoni.Add(new FirmaTelefonPregled(ft.Id, ft.BrojTelefona));
            }
        }
        catch (Exception ex)
        {
            return ex.Message.ToError(400);
        }
        finally
        {
            session?.Close();
            session?.Dispose();
        }

        return telefoni;
    }


    #endregion 

}