namespace Zatvor;

public static class DTOManager
{

    #region ZatvorskeJedinice

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

    public static ZatvorskaJedinica? KreirajZatvorskuJedinicu(ZatvorskaJedinicaBasic zatvorskaJedinica)
    {
        if (zatvorskaJedinica is OtvorenaZatvorskaJedinicaBasic)
        {
            return new OtvorenaZatvorskaJedinica
            {
                Naziv = zatvorskaJedinica.Naziv!,
                Kapacitet = zatvorskaJedinica.Kapacitet,
                Adresa = zatvorskaJedinica.Adresa!,
                PeriodZabraneOd = (zatvorskaJedinica as OtvorenaZatvorskaJedinicaBasic)!.PeriodZabraneOd,
                PeriodZabraneDo = (zatvorskaJedinica as OtvorenaZatvorskaJedinicaBasic)!.PeriodZabraneDo
            };
        }
        else if (zatvorskaJedinica is PoluotvorenaZatvorskaJedinicaBasic)
        {
            return new PoluotvorenaZatvorskaJedinica
            {
                Naziv = zatvorskaJedinica.Naziv!,
                Kapacitet = zatvorskaJedinica.Kapacitet,
                Adresa = zatvorskaJedinica.Adresa!,
                PeriodZabraneOd = (zatvorskaJedinica as PoluotvorenaZatvorskaJedinicaBasic)!.PeriodZabraneOd,
                PeriodZabraneDo = (zatvorskaJedinica as PoluotvorenaZatvorskaJedinicaBasic)!.PeriodZabraneDo
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
                PeriodZabraneOd = (zatvorskaJedinica as OPZatvorskaJedinicaBasic)!.PeriodZabraneOd,
                PeriodZabraneDo = (zatvorskaJedinica as OPZatvorskaJedinicaBasic)!.PeriodZabraneDo
            };
        }
        else if (zatvorskaJedinica is OZZatvorskaJedinicaBasic)
        {
            return new OZZatvorskaJedinica
            {
                Naziv = zatvorskaJedinica.Naziv!,
                Kapacitet = zatvorskaJedinica.Kapacitet,
                Adresa = zatvorskaJedinica.Adresa!,
                PeriodZabraneOd = (zatvorskaJedinica as OZZatvorskaJedinicaBasic)!.PeriodZabraneOd,
                PeriodZabraneDo = (zatvorskaJedinica as OZZatvorskaJedinicaBasic)!.PeriodZabraneDo
            };
        }
        else if (zatvorskaJedinica is PZZatvorskaJedinicaBasic)
        {
            return new PZZatvorskaJedinica
            {
                Naziv = zatvorskaJedinica.Naziv!,
                Kapacitet = zatvorskaJedinica.Kapacitet,
                Adresa = zatvorskaJedinica.Adresa!,
                PeriodZabraneOd = (zatvorskaJedinica as PZZatvorskaJedinicaBasic)!.PeriodZabraneOd,
                PeriodZabraneDo = (zatvorskaJedinica as PZZatvorskaJedinicaBasic)!.PeriodZabraneDo
            };
        }

        return null;
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

    public static async Task<List<ZatvorskaJedinicaPregled>> VratiSveZatvore()
    {
        List<ZatvorskaJedinicaPregled> zatvorskeJedinice = new List<ZatvorskaJedinicaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return zatvorskeJedinice;
            }

            IEnumerable<ZatvorskaJedinica> sveZatvorskeJedinice = await session.Query<ZatvorskaJedinica>().ToListAsync();

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
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return zatvorskeJedinice;
    }

    public static async Task<List<ZatvorskaJedinicaPregled>> VratiZatvoreZaFirmu(int firmaPIB)
    {
        List<ZatvorskaJedinicaPregled> zatvorskeJedinice = new List<ZatvorskaJedinicaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return zatvorskeJedinice;
            }

            Firma firma = await session.LoadAsync<Firma>(firmaPIB);

            if (firma == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return zatvorskeJedinice;
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
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return zatvorskeJedinice;
    }

    public static async Task<List<ZatvorskaJedinicaPregled>> VratiPotencijalneZatvoreZaFirmu(int firmaPIB)
    {
        List<ZatvorskaJedinicaPregled> zatvorskeJedinice = new List<ZatvorskaJedinicaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return zatvorskeJedinice;
            }

            Firma firma = await session.LoadAsync<Firma>(firmaPIB);

            if (firma == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return zatvorskeJedinice;
            }

            IList<ZatvorskaJedinica> lista = firma.ZatvorskeJedinice;

            IEnumerable<ZatvorskaJedinica> otvoreniZatvori = await session.Query<OtvorenaZatvorskaJedinica>()
                                                                     .Where(x => !lista.Contains(x))
                                                                     .ToListAsync();

            IEnumerable<ZatvorskaJedinica> opZatvori = await session.Query<OPZatvorskaJedinica>()
                                                                     .Where(x => !lista.Contains(x))
                                                                     .ToListAsync();

            IEnumerable<ZatvorskaJedinica> ozZatvori = await session.Query<OZZatvorskaJedinica>()
                                                         .Where(x => !lista.Contains(x))
                                                         .ToListAsync();

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
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return zatvorskeJedinice;
    }

    public static async void ObrisiZatvor(int id)
    {
        
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
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
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void DodajZatvorskuJedinicu(ZatvorskaJedinicaBasic zatvorskaJedinica)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            ZatvorskaJedinica z = KreirajZatvorskuJedinicu(zatvorskaJedinica)!;

            if (z == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            await session.SaveOrUpdateAsync(z);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void IzmeniZatvorskuJedinicu(ZatvorskaJedinicaBasic zatvorskaJedinica)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            ZatvorskaJedinica z = await session.Query<ZatvorskaJedinica>().Where(x => x.Id == zatvorskaJedinica.Id).FirstOrDefaultAsync();

            if (z == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            z.Naziv = zatvorskaJedinica.Naziv!;
            z.Kapacitet = zatvorskaJedinica.Kapacitet;
            z.Adresa = zatvorskaJedinica.Adresa!;

            if (z is ZatvorZabranaInterface zInterface)
            {
                zInterface.PeriodZabraneOd = (zatvorskaJedinica as ZatvorZabranaInterface)!.PeriodZabraneOd;
                zInterface.PeriodZabraneDo = (zatvorskaJedinica as ZatvorZabranaInterface)!.PeriodZabraneDo;
            }

            await session.UpdateAsync(z);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async Task<ZatvorskaJedinicaBasic?> VratiZatvorskuJedinicu(int id, string tip)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return null;
            }

            ZatvorskaJedinica z;

            if (tip == "Otvorena")
                z = await session.LoadAsync<OtvorenaZatvorskaJedinica>(id);
            else if (tip == "Poluotvorena")
                z = await session.LoadAsync<PoluotvorenaZatvorskaJedinica>(id);
            else if (tip == "Zatvorena")
                z = await session.LoadAsync<ZatvorenaZatvorskaJedinica>(id);
            else if (tip == "Otvorena-Zatvorena")
                z = await session.LoadAsync<OZZatvorskaJedinica>(id);
            else if (tip == "Poluotvorena-Zatvorena")
                z = await session.LoadAsync<PZZatvorskaJedinica>(id);
            else
                z = await session.LoadAsync<OPZatvorskaJedinica>(id);

            return KreirajZatvorskuJedinicuBasic(z);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void DodeliUpravnika(string zaposleniJMBG, int zatvorskaJedinicaId)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            ZaposleniAdministracija z = await session.LoadAsync<ZaposleniAdministracija>(zaposleniJMBG);

            if (z == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            ZatvorskaJedinica zatvor = await session.LoadAsync<ZatvorskaJedinica>(zatvorskaJedinicaId);
            
            if (zatvor == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            zatvor.Upravnik = z;
            z.ZatvorskaJedinica = zatvor;
            
            await session.SaveOrUpdateAsync(zatvor);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static async Task<List<ZaposleniPregled>> VratiMoguceUpravnike(int zatvorskaJedinicaId)
    {
        List<ZaposleniPregled> zaposleni = new List<ZaposleniPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return zaposleni;
            }

            ZatvorskaJedinica zatvor = await session.LoadAsync<ZatvorskaJedinica>(zatvorskaJedinicaId);

            if (zatvor == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return zaposleni;
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
            MessageBox.Show(ex.FormatExceptionMessage());
            return zaposleni;
        }
        finally
        {
            session?.Close();
        }
    }

    public static async Task<ZaposleniPregled?> VratiUpravnika(int zatvorskaJedinicaId)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return null;
            }

            ZatvorskaJedinica zatvor = await session.LoadAsync<ZatvorskaJedinica>(zatvorskaJedinicaId);

            if (zatvor == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return null;
            }

            ZaposleniAdministracija? upravnik = zatvor.Upravnik;

            if (upravnik == null)
            {
                return null;
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
            MessageBox.Show(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }
    }

    #endregion

    #region TerminiPosete

    public static async Task<List<TerminPosetePregled>?> VratiTerminePosete(int id)
    {
        List<TerminPosetePregled> terminiPosete = new List<TerminPosetePregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return terminiPosete;
            }

            ZatvorskaJedinica zatvorskaJedinica = await session.LoadAsync<ZatvorskaJedinica>(id);

            IList<TerminPosete>? termini = zatvorskaJedinica.getTerminiPosete();

            if (termini == null)
            {
                MessageBox.Show("Zatvorska jedinica nema termine za posete!");
                return null;
            }

            foreach (TerminPosete t in termini)
            {
                terminiPosete.Add(new TerminPosetePregled(t.Id, t.Dan, t.TerminOd, t.TerminDo));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return terminiPosete;
    }

    public static async void DodajTerminPosete(TerminPoseteBasic terminPoseteBasic, int idZatvorskeJedinice)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            ZatvorskaJedinica zatvorskaJedinica = await session.LoadAsync<ZatvorskaJedinica>(idZatvorskeJedinice);

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
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void IzmeniTerminPosete(TerminPoseteBasic terminPoseteBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            TerminPosete termin = await session.LoadAsync<TerminPosete>(terminPoseteBasic.Id);

            termin.Dan = terminPoseteBasic.Dan!;
            termin.TerminOd = terminPoseteBasic.TerminOd!;
            termin.TerminDo = terminPoseteBasic.TerminDo!;

            await session.UpdateAsync(termin);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async Task<TerminPoseteBasic?> VratiTerminPosete(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return null;
            }

            TerminPosete termin = await session.LoadAsync<TerminPosete>(id);

            TerminPoseteBasic terminPosete = new TerminPoseteBasic(id, termin.Dan, termin.TerminOd, termin.TerminDo);

            return terminPosete;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void ObrisiTerminPosete(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            TerminPosete t = session.Load<TerminPosete>(id);

            await session.DeleteAsync(t);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    #endregion

    #region TerminiSetnje

    public static async Task<List<TerminSetnjePregled>?> VratiTermineSetnje(int id)
    {
        List<TerminSetnjePregled> terminiSetnje = new List<TerminSetnjePregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return terminiSetnje;
            }

            ZatvorskaJedinica zatvorskaJedinica = await session.LoadAsync<ZatvorskaJedinica>(id);

            IList<TerminSetnje>? termini = zatvorskaJedinica.getTerminiSetnje();

            if (termini == null)
            {
                MessageBox.Show("Zatvorska jedinica nema termine za šetnju!");
                return null;
            }

            foreach (TerminSetnje t in termini)
            {
                terminiSetnje.Add(new TerminSetnjePregled(t.Id, t.TerminOd, t.TerminDo));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return terminiSetnje;
    }

    public static async void DodajTerminSetnje(TerminSetnjeBasic terminSetnjeBasic, int idZatvorskeJedinice)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
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
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void IzmeniTerminSetnje(TerminSetnjeBasic terminSetnjeBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            TerminSetnje termin = await session.LoadAsync<TerminSetnje>(terminSetnjeBasic.Id);

            termin.TerminOd = terminSetnjeBasic.TerminOd!;
            termin.TerminDo = terminSetnjeBasic.TerminDo!;

            await session.UpdateAsync(termin);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async Task<TerminSetnjeBasic?> VratiTerminSetnje(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return null;
            }

            TerminSetnje termin = await session.LoadAsync<TerminSetnje>(id);

            TerminSetnjeBasic terminSetnje = new TerminSetnjeBasic(id, termin.TerminOd, termin.TerminDo);

            return terminSetnje;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void ObrisiTerminSetnje(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            TerminSetnje t = session.Load<TerminSetnje>(id);

            await session.DeleteAsync(t);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    #endregion

    #region Zatvorenici

    public static async Task<List<ZatvorenikPregled>> VratiZatvorenikeZaZatvorskuJedinicu(int idZatvorskeJedinice)
    {
        List<ZatvorenikPregled> zatvoreniciPregled = new List<ZatvorenikPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return zatvoreniciPregled;
            }

            ZatvorskaJedinica zatvorskaJedinica = await session.LoadAsync<ZatvorskaJedinica>(idZatvorskeJedinice);

            IEnumerable<Zatvorenik> zatvorenici = await session.Query<Zatvorenik>().Where(x => x.ZatvorskaJedinica.Id == idZatvorskeJedinice).ToListAsync();

            foreach (Zatvorenik z in zatvorenici)
            {
                string advokat = z.Advokat?.Ime + " " + z.Advokat?.Prezime;
                zatvoreniciPregled.Add(new ZatvorenikPregled(z.Id, z.Ime, z.Prezime, z.Adresa, z.Pol, z.StatusUslovnogOtpusta, z.DatumSledecegSaslusanja, advokat, z.AdvokatDatum, z.AdvokatPoslednjiKontakt));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return zatvoreniciPregled;
    }

    public static async Task<List<ZatvorenikPregled>> VratiZatvorenikeZaAdvokata(string advokatJMBG)
    {
        List<ZatvorenikPregled> zatvoreniciPregled = new List<ZatvorenikPregled>();
        ISession? session = null;
        
        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return zatvoreniciPregled;
            }

            IEnumerable<Zatvorenik> zatvorenici = await session.Query<Zatvorenik>().Where(x => x.Advokat != null && x.Advokat.JMBG == advokatJMBG).ToListAsync();

            foreach (Zatvorenik z in zatvorenici)
            {
                ZatvorenikPregled pregled = new ZatvorenikPregled(z.Id, z.Ime, z.Prezime, z.Adresa!, z.Pol, z.StatusUslovnogOtpusta!, z.DatumSledecegSaslusanja, "", z.AdvokatDatum, z.AdvokatPoslednjiKontakt);
                pregled.NazivZatvorskeJedinice = z.ZatvorskaJedinica.Naziv;
                zatvoreniciPregled.Add(pregled);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return zatvoreniciPregled;
    }

    public static async Task<List<ZatvorenikPregled>> VratiMoguceZatvorenikeZaAdvokata(string advokatJMBG)
    {
        List<ZatvorenikPregled> zatvoreniciPregled = new List<ZatvorenikPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return zatvoreniciPregled;
            }

            IEnumerable<Zatvorenik> zatvorenici = await session.Query<Zatvorenik>().Where(x => (x.Advokat != null && x.Advokat.JMBG != advokatJMBG) || x.Advokat == null).ToListAsync();

            foreach (Zatvorenik z in zatvorenici)
            {
                ZatvorenikPregled pregled = new ZatvorenikPregled(z.Id, z.Ime, z.Prezime, z.Adresa!, z.Pol, z.StatusUslovnogOtpusta!, z.DatumSledecegSaslusanja, z.Advokat?.Ime + " " + z.Advokat?.Prezime, z.AdvokatDatum, z.AdvokatPoslednjiKontakt);
                pregled.NazivZatvorskeJedinice = z.ZatvorskaJedinica.Naziv;
                zatvoreniciPregled.Add(pregled);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return zatvoreniciPregled;
    }

    public static async Task<List<ZatvorenikPregled>> VratiZatvorenikeZaFirmu(int firmaPIB)
    {
        List<ZatvorenikPregled> zatvoreniciPregled = new List<ZatvorenikPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return zatvoreniciPregled;
            }

            IEnumerable<Zatvorenik> zatvorenici = await session.Query<Zatvorenik>().Where(x => x.Firma != null && x.Firma.PIB == firmaPIB).ToListAsync();

            foreach (Zatvorenik z in zatvorenici)
            {
                ZatvorenikPregled pregled = new ZatvorenikPregled(z.Id, z.Ime, z.Prezime, z.Adresa!, z.Pol, z.StatusUslovnogOtpusta!, z.DatumSledecegSaslusanja, "", z.AdvokatDatum, z.AdvokatPoslednjiKontakt);
                pregled.NazivZatvorskeJedinice = z.ZatvorskaJedinica.Naziv;
                zatvoreniciPregled.Add(pregled);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return zatvoreniciPregled;
    }

    public static async Task<List<ZatvorenikPregled>> VratiPotencijalneRadnike(int firmaPIB)
    {
        List<ZatvorenikPregled> zatvoreniciPregled = new List<ZatvorenikPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return zatvoreniciPregled;
            }

            Firma firma = await session.LoadAsync<Firma>(firmaPIB);

            if (firma == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return zatvoreniciPregled;
            }

            IEnumerable<Zatvorenik> zatvorenici = await session.Query<Zatvorenik>()
                                                                .Where(x => firma.ZatvorskeJedinice.Contains(x.ZatvorskaJedinica) 
                                                                            && ((x.Firma != null && x.Firma.PIB != firmaPIB) || x.Firma == null))
                                                                .ToListAsync();

            foreach (Zatvorenik z in zatvorenici)
            {
                ZatvorenikPregled pregled = new ZatvorenikPregled(z.Id, z.Ime, z.Prezime, z.Adresa!, z.Pol, z.StatusUslovnogOtpusta!, z.DatumSledecegSaslusanja, "", z.AdvokatDatum, z.AdvokatPoslednjiKontakt);
                pregled.NazivZatvorskeJedinice = z.ZatvorskaJedinica.Naziv;
                zatvoreniciPregled.Add(pregled);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return zatvoreniciPregled;
    }

    public static async void DodajZatvorenika(ZatvorenikBasic zatvorenikBasic, int idZatvorskeJedinice)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
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
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void IzmeniZatvorenika(ZatvorenikBasic zatvorenikBasic, int idZatvorskeJedinice)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Zatvorenik zatvorenik = await session.LoadAsync<Zatvorenik>(zatvorenikBasic.Id);

            zatvorenik.Ime = zatvorenikBasic.Ime!;
            zatvorenik.Prezime = zatvorenikBasic.Prezime!;
            zatvorenik.Adresa = zatvorenikBasic.Adresa!;
            zatvorenik.Pol = zatvorenikBasic.Pol!;
            zatvorenik.StatusUslovnogOtpusta = zatvorenikBasic.StatusUslovnogOtpusta!;
            zatvorenik.DatumSledecegSaslusanja = zatvorenikBasic.DatumSledecegSaslusanja;
            zatvorenik.AdvokatDatum = zatvorenikBasic.AdvokatDatum;
            zatvorenik.AdvokatPoslednjiKontakt = zatvorenikBasic.AdvokatPoslednjiKontakt;

            ZatvorskaJedinica zatvorskaJedinica = await session.LoadAsync<ZatvorskaJedinica>(idZatvorskeJedinice);
            Advokat advokat = await session.LoadAsync<Advokat>(zatvorenikBasic.Advokat!.JMBG);

            zatvorenik.ZatvorskaJedinica = zatvorskaJedinica;
            if (advokat != null)
                zatvorenik.Advokat = advokat;

            await session.UpdateAsync(zatvorenik);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async Task<ZatvorenikBasic?> VratiZatvorenika(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return null;
            }

            Zatvorenik zatvorenik = await session.LoadAsync<Zatvorenik>(id);

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
            MessageBox.Show(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void ObrisiZatvorenika(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Zatvorenik z = session.Load<Zatvorenik>(id);

            await session.DeleteAsync(z);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async Task<List<ZatvorenikPregled>> VratiSveZatvorenike()
    {
        List<ZatvorenikPregled> zatvorenici = new List<ZatvorenikPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return zatvorenici;
            }

            IEnumerable<Zatvorenik> sviZatvorenici = await session.Query<Zatvorenik>().ToListAsync();

            foreach (Zatvorenik z in sviZatvorenici)
            {
                ZatvorenikPregled pregled = new ZatvorenikPregled(z.Id, z.Ime, z.Prezime, z.Adresa, z.Pol, z.StatusUslovnogOtpusta, z.DatumSledecegSaslusanja, z.Advokat?.Ime + " " + z.Advokat?.Prezime, z.AdvokatDatum, z.AdvokatPoslednjiKontakt);
                pregled.NazivZatvorskeJedinice = z.ZatvorskaJedinica.Naziv;
                zatvorenici.Add(pregled);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return zatvorenici;
    }

    #endregion

    #region Advokati

    public static async Task<List<AdvokatPregled>?> VratiSveAdvokate()
    {
        List<AdvokatPregled> advokati = new List<AdvokatPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return advokati;
            }


            IEnumerable<Advokat> sviAdvokati = await session.Query<Advokat>().ToListAsync();

            foreach (Advokat a in sviAdvokati)
            {
                advokati.Add(new AdvokatPregled(a.JMBG, a.Ime, a.Prezime));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return advokati;
    }

    public static async Task<AdvokatBasic?> VratiAdvokata(string jmbg)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return null;
            }

            Advokat advokat = await session.LoadAsync<Advokat>(jmbg);

            AdvokatBasic advokatBasic = new AdvokatBasic(jmbg, advokat.Ime, advokat.Prezime);

            return advokatBasic;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void DodajAdvokata(AdvokatBasic advokatBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
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
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void IzmeniAdvokata(AdvokatBasic advokatBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }


            Advokat advokat = await session.LoadAsync<Advokat>(advokatBasic.JMBG);

            if (advokat == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            advokat.Ime = advokatBasic.Ime!;
            advokat.Prezime = advokatBasic.Prezime!;

            await session.UpdateAsync(advokat);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void ObrisiAdvokata(string advokatJMBG)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Advokat advokat = await session.LoadAsync<Advokat>(advokatJMBG);

            IList<Zatvorenik> zatvorenici = advokat.Zatvorenici.ToList();
            
            foreach(Zatvorenik z in zatvorenici)
            {
                z.Advokat = null;
                advokat.Zatvorenici.Remove(z);
                await session.UpdateAsync(z);
                await session.UpdateAsync(advokat);
            }

            await session.DeleteAsync(advokat);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void OtkaziZastupanje(int zatvorenikId)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Zatvorenik zatvorenik = await session.LoadAsync<Zatvorenik>(zatvorenikId);

            zatvorenik.Advokat = null;

            await session.SaveOrUpdateAsync(zatvorenik);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void DodajZastupanje(int zatvorenikId, string advokatJMBG)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Zatvorenik zatvorenik = await session.LoadAsync<Zatvorenik>(zatvorenikId);

            if (zatvorenik == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            Advokat advokat = await session.LoadAsync<Advokat>(advokatJMBG);

            if (advokat == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            zatvorenik.Advokat = advokat;

            await session.SaveOrUpdateAsync(zatvorenik);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

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
            ZatvorskaJedinica zatvor = session.Load<ZatvorskaJedinica>(zaposleni.RadiU.ZatvorskaJedinicaId);
            RadiU radiU = new RadiU
            {
                Zaposleni = z,
                ZatvorskaJedinica = zatvor,
                NazivRadnogMesta = zaposleni.RadiU.NazivRadnogMesta,
                DatumPocetkaRada = zaposleni.RadiU.DatumPocetkaRada
            };
            z?.RadnaMesta.Add(radiU);
        }


        return z;
    }
    
    public static ZaposleniBasic? KreirajZaposlenogBasic(Zaposleni zaposleni, int idZatvorskeJedinice, string radnoMesto)
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
            z!.RadiU = radiUBasic;
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

    public static async Task<List<ZaposleniPregled>> VratiZaposleneZaZatvorskuJedinicu(int idZatvorskeJedinice)
    {
        List<ZaposleniPregled> zaposleni = new List<ZaposleniPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return zaposleni;
            }

            ZatvorskaJedinica zatvor = await session.LoadAsync<ZatvorskaJedinica>(idZatvorskeJedinice);

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
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return zaposleni;
    }

    public static async void DodajZaposlenog(ZaposleniBasic zaposleniBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Zaposleni z = KreirajZaposlenog(zaposleniBasic, session)!;

            if (z == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            await session.SaveOrUpdateAsync(z);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void IzmeniZaposlenog(ZaposleniBasic zaposleniBasic, string staroRadnoMesto)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }


            Zaposleni z;

            if (zaposleniBasic is ZaposleniAdministracijaBasic)
                z = await session.LoadAsync<ZaposleniAdministracija>(zaposleniBasic.JMBG);
            else if (zaposleniBasic is PsihologBasic)
                z = await session.LoadAsync<Psiholog>(zaposleniBasic.JMBG);
            else
                z = await session.LoadAsync<RadnikObezbedjenja>(zaposleniBasic.JMBG);

            if (z == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            z.Ime = zaposleniBasic.Ime!;
            z.Prezime = zaposleniBasic.Prezime!;
            z.DatumObuke = zaposleniBasic.DatumObuke;

            if (zaposleniBasic is ZaposleniAdministracijaBasic a)
            {
                (z as ZaposleniAdministracija)!.Zanimanje = a.Zanimanje!;
                (z as ZaposleniAdministracija)!.StrucnaSprema = a.StrucnaSprema!;
            }

            await session.UpdateAsync(z);

            if (zaposleniBasic.RadiU != null)
            {
                RadiU radiU = await session.Query<RadiU>().Where(x => x.Zaposleni.JMBG == z.JMBG && x.ZatvorskaJedinica.Id == zaposleniBasic.RadiU.ZatvorskaJedinicaId && x.NazivRadnogMesta == staroRadnoMesto).FirstOrDefaultAsync();

                radiU.DatumPocetkaRada = zaposleniBasic.RadiU.DatumPocetkaRada;
                radiU.NazivRadnogMesta = zaposleniBasic.RadiU.NazivRadnogMesta;

                await session.UpdateAsync(radiU);
            }

            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async Task<ZaposleniBasic?> VratiZaposlenog(string id, string tip, int idZatvorskeJedinice, string radnoMesto)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return null;
            }

            Zaposleni? z = null;

            if (tip == "Administracija")
                z = await session.LoadAsync<ZaposleniAdministracija>(id);
            else if (tip == "Psiholog")
                z = await session.LoadAsync<Psiholog>(id);
            else if (tip == "Radnik obezbeđenja")
                z = await session.LoadAsync<RadnikObezbedjenja>(id);

            return KreirajZaposlenogBasic(z!, idZatvorskeJedinice, radnoMesto);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void ObrisiZaposlenog(string id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Zaposleni z = await session.Query<Zaposleni>().Where(x => x.JMBG == id).FirstOrDefaultAsync();

            if (z is ZaposleniAdministracija a)
            {
                if (a.ZatvorskaJedinica != null)
                {
                    a.ZatvorskaJedinica!.Upravnik = null;
                    await session.UpdateAsync(a.ZatvorskaJedinica);
                    a.ZatvorskaJedinica = null;
                    await session.UpdateAsync(a);
                }
            }

            await session.DeleteAsync(z);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async Task<List<ZaposleniPregled>> VratiSveZaposlene()
    {
        List<ZaposleniPregled> zaposleni = new List<ZaposleniPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return zaposleni;
            }

            IEnumerable<Zaposleni> sviZaposleni = await session.Query<Zaposleni>().ToListAsync();

            foreach (Zaposleni z in sviZaposleni)
            {
                
                string zanimanje = "";
                string strucnaSprema = "";

                if (z is ZaposleniAdministracija a)
                {
                    zanimanje = a.Zanimanje!;
                    strucnaSprema = a.StrucnaSprema!;
                }

                zaposleni.Add(new ZaposleniPregled(z.JMBG, z.Ime, z.Prezime, z.DatumObuke, VratiTipZaposlenog(z), zanimanje, strucnaSprema, "", DateTime.Now));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return zaposleni;
    }

    public static async void ZaposliRadnika(string idZaposlenog, RadiUBasic radiU)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Zaposleni z = await session.LoadAsync<Zaposleni>(idZaposlenog);

            if (z == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            ZatvorskaJedinica zatvor = await session.LoadAsync<ZatvorskaJedinica>(radiU.ZatvorskaJedinicaId);

            RadiU test = await session.Query<RadiU>().Where(x => x.Zaposleni.JMBG == idZaposlenog && x.ZatvorskaJedinica.Id == radiU.ZatvorskaJedinicaId && x.NazivRadnogMesta == radiU.NazivRadnogMesta).FirstOrDefaultAsync();

            if (test != null)
            {
                MessageBox.Show("Zaposleni je već zapošljen u toj zatvorskoj jedinici na tom radnom mestu!");
                return;
            }

            RadiU r = new RadiU
            {
                Zaposleni = z,
                ZatvorskaJedinica = zatvor,
                NazivRadnogMesta = radiU.NazivRadnogMesta,
                DatumPocetkaRada = radiU.DatumPocetkaRada
            };

            z.RadnaMesta.Add(r);

            await session.SaveOrUpdateAsync(r);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static async Task<List<RadiUPregled>> VratiZaposlenjaZaZaposlenog(string zaposleniJMBG)
    {
        List<RadiUPregled> zaposlenja = new List<RadiUPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return zaposlenja;
            }

            List<RadiU> radiULista = await session.Query<RadiU>().Where(x => x.Zaposleni.JMBG == zaposleniJMBG).ToListAsync();

            foreach (RadiU r in radiULista)
            {
                zaposlenja.Add(new RadiUPregled(r.Zaposleni.JMBG, r.Zaposleni.Ime, r.Zaposleni.Prezime, r.ZatvorskaJedinica.Naziv, r.NazivRadnogMesta, r.DatumPocetkaRada));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return zaposlenja;
    }

    public static async void ObrisiRadnoMesto(string zaposleniJMBG, string zatvorskaJedinicaNaziv, string radnoMestoNaziv)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            RadiU radiU = await session.Query<RadiU>().Where(x => x.Zaposleni.JMBG == zaposleniJMBG && x.ZatvorskaJedinica.Naziv == zatvorskaJedinicaNaziv && x.NazivRadnogMesta == radnoMestoNaziv).FirstOrDefaultAsync();

            if (radiU == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            await session.DeleteAsync(radiU);
            await session.FlushAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static async void IzmeniRadnoMesto(string zaposleniJMBG, string zatvorskaJedinicaNaziv, string staroRadnoMesto, string radnoMestoNaziv, DateTime datumZaposlenja)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            RadiU radiU = await session.Query<RadiU>().Where(x => x.Zaposleni.JMBG == zaposleniJMBG && x.ZatvorskaJedinica.Naziv == zatvorskaJedinicaNaziv && x.NazivRadnogMesta == staroRadnoMesto).FirstOrDefaultAsync();

            if (radiU == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            radiU.NazivRadnogMesta = radnoMestoNaziv;
            radiU.DatumPocetkaRada = datumZaposlenja;

            await session.UpdateAsync(radiU);
            await session.FlushAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    #endregion

    #region LekarskiPregledi

    public static async Task<List<LekarskiPregledPregled>> VratiLekarskePreglede(string zaposleniJMBG)
    {
        List<LekarskiPregledPregled> lekarskiPregledi = new List<LekarskiPregledPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return lekarskiPregledi;
            }

            IEnumerable<LekarskiPregled> lista = await session.Query<LekarskiPregled>().Where(x => x.Zaposleni.JMBG == zaposleniJMBG).ToListAsync();

            foreach (LekarskiPregled l in lista)
            {
                lekarskiPregledi.Add(new LekarskiPregledPregled(l.Id, l.Datum, l.NazivUstanove, l.AdresaUstanove, l.Lekar));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return lekarskiPregledi;
    }
    
    public static async void DodajLekarskiPregled(LekarskiPregledBasic lp, string zaposleniJMBG)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Zaposleni zaposleni = await session.LoadAsync<Zaposleni>(zaposleniJMBG);

            if (zaposleni == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
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
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void IzmeniLekarskiPregled(LekarskiPregledBasic lp)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            LekarskiPregled lekarskiPregled = await session.LoadAsync<LekarskiPregled>(lp.Id);

            if (lekarskiPregled == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            lekarskiPregled.Datum = lp.Datum;
            lekarskiPregled.NazivUstanove = lp.NazivUstanove;
            lekarskiPregled.AdresaUstanove = lp.AdresaUstanove;
            lekarskiPregled.Lekar = lp.Lekar;

            await session.UpdateAsync(lekarskiPregled);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void ObrisiLekarskiPregled(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            LekarskiPregled lp = session.Load<LekarskiPregled>(id);

            await session.DeleteAsync(lp);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async Task<LekarskiPregledBasic?> VratiLekarskiPregled(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return null;
            }

            LekarskiPregled lp = await session.LoadAsync<LekarskiPregled>(id);

            LekarskiPregledBasic lekarskiPregled = new LekarskiPregledBasic(lp.Id, lp.Datum, lp.NazivUstanove, lp.AdresaUstanove, lp.Lekar);

            return lekarskiPregled;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }

    }

    #endregion

    #region Obuke

    public static async Task<List<ObukaVatrenoOruzjePregled>> VratiObuke(string zaposleniJMBG)
    {
        List<ObukaVatrenoOruzjePregled> obuke = new List<ObukaVatrenoOruzjePregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return obuke;
            }

            IEnumerable<ObukaVatrenoOruzje> lista = await session.Query<ObukaVatrenoOruzje>().Where(x => x.Radnik.JMBG == zaposleniJMBG).ToListAsync();

            foreach (ObukaVatrenoOruzje o in lista)
            {
                obuke.Add(new ObukaVatrenoOruzjePregled(o.Id, o.DatumIzdavanja, o.PolicijskaUprava));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return obuke;
    }
    
    public static async void DodajObuku(ObukaVatrenoOruzjeBasic o, string zaposleniJMBG)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            RadnikObezbedjenja zaposleni = await session.LoadAsync<RadnikObezbedjenja>(zaposleniJMBG);

            if (zaposleni == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
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
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void IzmeniObuku(ObukaVatrenoOruzjeBasic o)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            ObukaVatrenoOruzje obuka = await session.LoadAsync<ObukaVatrenoOruzje>(o.Id);

            if (obuka == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            obuka.DatumIzdavanja = o.DatumIzdavanja;
            obuka.PolicijskaUprava = o.PolicijskaUprava;

            await session.UpdateAsync(obuka);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void ObrisiObuku(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            ObukaVatrenoOruzje o = session.Load<ObukaVatrenoOruzje>(id);

            await session.DeleteAsync(o);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async Task<ObukaVatrenoOruzjeBasic?> VratiObuku(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return null;
            }

            ObukaVatrenoOruzje o = await session.LoadAsync<ObukaVatrenoOruzje>(id);

            ObukaVatrenoOruzjeBasic obuka = new ObukaVatrenoOruzjeBasic(o.Id, o.DatumIzdavanja, o.PolicijskaUprava);

            return obuka;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }

    }

    #endregion

    #region Prestupi

    public static async Task<List<PrestupPregled>> VratiSvePrestupe()
    {
        List<PrestupPregled> prestupi = new List<PrestupPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return prestupi;
            }

            IEnumerable<Prestup> lista = await session.Query<Prestup>().ToListAsync();

            foreach (Prestup prestup in lista)
            {
                prestupi.Add(new PrestupPregled(prestup.Id, prestup.Naziv, prestup.Kategorija, prestup.Opis, prestup.MinKazna, prestup.MaxKazna));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return prestupi;
    }

    public static async void DodajPrestup(PrestupBasic prestupBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Prestup prestup = new Prestup
            {
                Naziv = prestupBasic.Naziv,
                Kategorija = prestupBasic.Kategorija,
                Opis = prestupBasic.Opis,
                MinKazna = prestupBasic.MinKazna,
                MaxKazna = prestupBasic.MaxKazna
            };

            await session.SaveOrUpdateAsync(prestup);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void IzmeniPrestup(PrestupBasic prestupBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Prestup prestup = await session.LoadAsync<Prestup>(prestupBasic.Id);

            prestup.Naziv = prestupBasic.Naziv;
            prestup.Kategorija = prestupBasic.Kategorija;
            prestup.Opis = prestupBasic.Opis;
            prestup.MinKazna = prestupBasic.MinKazna;
            prestup.MaxKazna = prestupBasic.MaxKazna;

            await session.UpdateAsync(prestup);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void ObrisiPrestup(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Prestup prestup = session.Load<Prestup>(id);

            await session.DeleteAsync(prestup);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async Task<PrestupBasic?> VratiPrestup(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return null;
            }

            Prestup prestup = await session.LoadAsync<Prestup>(id);
            PrestupBasic prestupBasic = new PrestupBasic(prestup.Id, prestup.Naziv, prestup.Kategorija, prestup.Opis, prestup.MinKazna, prestup.MaxKazna);

            return prestupBasic;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }

    }

    #endregion

    #region IzvrseniPrestupi

    public static async Task<List<IzvrsenPrestupPregled>> VratiIzvrsenePrestupe(int zatvorenikID)
    {
        List<IzvrsenPrestupPregled> prestupi = new List<IzvrsenPrestupPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return prestupi;
            }

            IEnumerable<IzvrsenPrestup> lista = await session.Query<IzvrsenPrestup>().Where(x => x.Zatvorenik.Id == zatvorenikID).ToListAsync();

            foreach (IzvrsenPrestup prestup in lista)
            {
                prestupi.Add(new IzvrsenPrestupPregled(prestup.Id, prestup.Datum, prestup.Mesto, prestup.Prestup.Naziv, prestup.Prestup.Kategorija, prestup.Prestup.Opis, prestup.Prestup.MinKazna, prestup.Prestup.MaxKazna));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return prestupi;
    }

    public static async void DodajIzvrsenPrestup(IzvrsenPrestupBasic prestupBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Zatvorenik zatvorenik = await session.LoadAsync<Zatvorenik>(prestupBasic.IdZatvorenika);

            if (zatvorenik == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            Prestup prestup = await session.LoadAsync<Prestup>(prestupBasic.IdPrestupa);

            if (prestup == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
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
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void IzmeniIzvrsenPrestup(IzvrsenPrestupBasic prestupBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            IzvrsenPrestup izvrsenPrestup = await session.LoadAsync<IzvrsenPrestup>(prestupBasic.Id);

            if (izvrsenPrestup == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            izvrsenPrestup.Datum = prestupBasic.Datum;
            izvrsenPrestup.Mesto= prestupBasic.Mesto;

            await session.UpdateAsync(izvrsenPrestup);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void ObrisiIzvrsenPrestup(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            IzvrsenPrestup izvrsenPrestup = session.Load<IzvrsenPrestup>(id);

            await session.DeleteAsync(izvrsenPrestup);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async Task<IzvrsenPrestupBasic?> VratiIzvrsenPrestup(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return null;
            }

            IzvrsenPrestup izvrsenPrestup = await session.LoadAsync<IzvrsenPrestup>(id);

            IzvrsenPrestupBasic prestupBasic = new IzvrsenPrestupBasic(izvrsenPrestup.Id, izvrsenPrestup.Datum, izvrsenPrestup.Mesto, izvrsenPrestup.Zatvorenik.Id, izvrsenPrestup.Prestup.Id);

            return prestupBasic;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }

    }

    #endregion

    #region Firme

    public static async Task<List<FirmaPregled>> VratiSveFirme()
    {
        List<FirmaPregled> firme = new List<FirmaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return firme;
            }

            IEnumerable<Firma> lista = await session.Query<Firma>().ToListAsync();

            foreach (Firma firma in lista)
            {
                firme.Add(new FirmaPregled(firma.PIB, firma.Ime, firma.Adresa));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return firme;
    }

    public static async Task<FirmaPregled?> VratiFirmuZatvorenika(int zatvorenikId)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return null;
            }

            Zatvorenik zatvorenik = await session.LoadAsync<Zatvorenik>(zatvorenikId);

            if (!(zatvorenik.ZatvorskaJedinica is OtvorenaZatvorskaJedinica
                || zatvorenik.ZatvorskaJedinica is OPZatvorskaJedinica
                || zatvorenik.ZatvorskaJedinica is OZZatvorskaJedinica))
            {
                MessageBox.Show("Samo zatvorenici iz otvorenih zatvorskih jedinica mogu da rade u firmama!");
                return null;
            }

            Firma? firma = await session.Query<Zatvorenik>()
                                       .Where(x => x.Id == zatvorenikId)
                                       .Select(x => x.Firma)
                                       .FirstOrDefaultAsync();


            FirmaPregled firmaPregled = new FirmaPregled(firma?.PIB, firma?.Ime, firma?.Adresa);
            return firmaPregled;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }
    }

    public static async Task<List<FirmaPregled>> VratiFirmeZaZatvorenika(int zatvorenikId)
    {
        List<FirmaPregled> firme = new List<FirmaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return firme;
            }

            Zatvorenik zatvorenik = await session.LoadAsync<Zatvorenik>(zatvorenikId);

            if (zatvorenik == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return firme;
            }

            ZatvorskaJedinica zatvorskaJedinica = zatvorenik.ZatvorskaJedinica;

            if (!(zatvorskaJedinica is OtvorenaZatvorskaJedinica
                || zatvorskaJedinica is OPZatvorskaJedinica
                || zatvorskaJedinica is OZZatvorskaJedinica))
            {
                MessageBox.Show("Samo zatvorenici iz otvorenih zatvorskih jedinica mogu da rade u firmama!");
                return firme;
            }

            IEnumerable<Firma> lista = await session.Query<Firma>().Where(x => x.ZatvorskeJedinice.Contains(zatvorskaJedinica)).ToListAsync();

            foreach (Firma firma in lista)
            {
                firme.Add(new FirmaPregled(firma.PIB, firma.Ime, firma.Adresa));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return firme;
    }

    public static async Task<List<FirmaPregled>> VratiFirmeZaZatvorskuJedinicu(int zatvorskaJedinicaId)
    {
        List<FirmaPregled> firme = new List<FirmaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return firme;
            }

            ZatvorskaJedinica zatvorskaJedinica = await session.Query<ZatvorskaJedinica>().Where(x => x.Id == zatvorskaJedinicaId).FirstOrDefaultAsync();

            if (zatvorskaJedinica == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return firme;
            }

            if (!(zatvorskaJedinica is OtvorenaZatvorskaJedinica
                || zatvorskaJedinica is OPZatvorskaJedinica
                || zatvorskaJedinica is OZZatvorskaJedinica))
            {
                MessageBox.Show("Samo zatvorenici iz otvorenih zatvorskih jedinica mogu da rade u firmama!");
                return firme;
            }

            IEnumerable<Firma> lista = await session.Query<Firma>().Where(x => x.ZatvorskeJedinice.Contains(zatvorskaJedinica)).ToListAsync();

            foreach (Firma firma in lista)
            {
                firme.Add(new FirmaPregled(firma.PIB, firma.Ime, firma.Adresa));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return firme;
    }

    public static async Task<List<FirmaPregled>> VratiSveFirmeZaSaradnju(int zatvorskaJedinicaId)
    {
        List<FirmaPregled> firme = new List<FirmaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return firme;
            }

            ZatvorskaJedinica zatvorskaJedinica = await session.Query<ZatvorskaJedinica>().Where(x => x.Id == zatvorskaJedinicaId).FirstOrDefaultAsync();

            if (zatvorskaJedinica == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return firme;
            }

            if (!(zatvorskaJedinica is OtvorenaZatvorskaJedinica
                || zatvorskaJedinica is OPZatvorskaJedinica
                || zatvorskaJedinica is OZZatvorskaJedinica))
            {
                MessageBox.Show("Samo zatvorenici iz otvorenih zatvorskih jedinica mogu da rade u firmama!");
                return firme;
            }

            IEnumerable<Firma> lista = await session.Query<Firma>().Where(x => !x.ZatvorskeJedinice.Contains(zatvorskaJedinica)).ToListAsync();

            foreach (Firma firma in lista)
            {
                firme.Add(new FirmaPregled(firma.PIB, firma.Ime, firma.Adresa));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return firme;
    }

    public static async void DodajFirmu(FirmaBasic firmaBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
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
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void IzmeniFirmu(FirmaBasic firmaBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }


            Firma firma = await session.LoadAsync<Firma>(firmaBasic.PIB);

            if (firma == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            firma.Ime = firmaBasic.Ime!;
            firma.Adresa = firmaBasic.Adresa!;

            await session.UpdateAsync(firma);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void ObrisiFirmu(int pib)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Firma firma = await session.LoadAsync<Firma>(pib);

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
                await session.UpdateAsync(zatvorskaJedinica);
                await session.UpdateAsync(firma);
            }

            IList<Zatvorenik> zatvorenici = firma.ZatvoreniciRadnici.ToList();

            foreach (Zatvorenik zatvorenik in zatvorenici)
            {
                zatvorenik.Firma = null;
                firma.ZatvoreniciRadnici.Remove(zatvorenik);
                await session.UpdateAsync(zatvorenik);
                await session.UpdateAsync(firma);
            }

            await session.DeleteAsync(firma);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async Task<FirmaBasic?> VratiFirmu(int pib)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return null;
            }

            Firma firma = await session.LoadAsync<Firma>(pib);

            FirmaBasic firmaBasic = new FirmaBasic(firma.PIB, firma.Ime, firma.Adresa);

            return firmaBasic;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void ZaposliZatvorenika(int zatvorenikId, int firmaPIB)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Zatvorenik zatvorenik = await session.LoadAsync<Zatvorenik>(zatvorenikId);

            if (zatvorenik == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            Firma firma = await session.LoadAsync<Firma>(firmaPIB);

            if (firma == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            zatvorenik.Firma = firma;
            firma.ZatvoreniciRadnici.Add(zatvorenik);

            await session.SaveOrUpdateAsync(zatvorenik);
            await session.FlushAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static async void DajOtkazZatvoreniku(int zatvorenikId)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Zatvorenik zatvorenik = await session.LoadAsync<Zatvorenik>(zatvorenikId);

            if (zatvorenik == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            zatvorenik.Firma = null;

            await session.SaveOrUpdateAsync(zatvorenik);
            await session.FlushAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static async void OtkaziSaradnju(int zatvorskaJedinicaId, int firmaPIB)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            ZatvorskaJedinica zatvorskaJedinica = await session.Query<ZatvorskaJedinica>().Where(x => x.Id == zatvorskaJedinicaId).FirstOrDefaultAsync();

            if (zatvorskaJedinica == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            if (!(zatvorskaJedinica is OtvorenaZatvorskaJedinica
                || zatvorskaJedinica is OPZatvorskaJedinica
                || zatvorskaJedinica is OZZatvorskaJedinica))
            {
                MessageBox.Show("Samo zatvorenici iz otvorenih zatvorskih jedinica mogu da rade u firmama!");
                return;
            }

            Firma firma = await session.LoadAsync<Firma>(firmaPIB);

            if (firma == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
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

            await session.SaveOrUpdateAsync(zatvorskaJedinica);
            await session.FlushAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    public static async void ZapocniSaradnju(int zatvorskaJedinicaId, int firmaPIB)
    {
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            ZatvorskaJedinica zatvorskaJedinica = await session.Query<ZatvorskaJedinica>().Where(x => x.Id == zatvorskaJedinicaId).FirstOrDefaultAsync();

            if (zatvorskaJedinica == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            if (!(zatvorskaJedinica is OtvorenaZatvorskaJedinica
                || zatvorskaJedinica is OPZatvorskaJedinica
                || zatvorskaJedinica is OZZatvorskaJedinica))
            {
                MessageBox.Show("Samo zatvorenici iz otvorenih zatvorskih jedinica mogu da rade u firmama!");
                return;
            }

            Firma firma = await session.LoadAsync<Firma>(firmaPIB);

            if (firma == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
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

            await session.SaveOrUpdateAsync(zatvorskaJedinica);
            await session.FlushAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }
    }

    #endregion

    #region Posete

    public static async Task<List<PosetaPregled>> VratiPoseteZaZatvorenika(int zatvorenikID)
    {
        List<PosetaPregled> posete = new List<PosetaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return posete;
            }

            IEnumerable<Poseta> lista = await session.Query<Poseta>().Where(x => x.Zatvorenik.Id == zatvorenikID).ToListAsync();

            foreach (Poseta p in lista)
            {
                posete.Add(new PosetaPregled(p.Id, p.Datum, p.VremeOd, p.VremeDo, p.Advokat.Ime + " " + p.Advokat.Prezime, ""));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return posete;
    }

    public static async Task<List<PosetaPregled>> VratiPoseteZaAdvokata(string advokatJMBG)
    {
        List<PosetaPregled> posete = new List<PosetaPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return posete;
            }

            IEnumerable<Poseta> lista = await session.Query<Poseta>().Where(x => x.Advokat.JMBG == advokatJMBG).ToListAsync();

            foreach (Poseta p in lista)
            {
                posete.Add(new PosetaPregled(p.Id, p.Datum, p.VremeOd, p.VremeDo, "", p.Zatvorenik.Ime + " " + p.Zatvorenik.Prezime));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return posete;
    }

    public static async void DodajPosetu(PosetaBasic posetaBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Zatvorenik zatvorenik = await session.LoadAsync<Zatvorenik>(posetaBasic.ZatvorenikId);

            if (zatvorenik == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            Advokat? advokat = zatvorenik.Advokat;

            if (advokat == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
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
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void IzmeniPosetu(PosetaBasic posetaBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Poseta poseta = await session.LoadAsync<Poseta>(posetaBasic.Id);

            if (poseta == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            poseta.Datum = posetaBasic.Datum;
            poseta.VremeOd = posetaBasic.VremeOd;
            poseta.VremeDo = posetaBasic.VremeDo;

            await session.UpdateAsync(poseta);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void ObrisiPosetu(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Poseta poseta = session.Load<Poseta>(id);

            await session.DeleteAsync(poseta);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async Task<PosetaBasic?> VratiPosetu(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return null;
            }

            Poseta poseta = await session.LoadAsync<Poseta>(id);

            PosetaBasic posetaBasic = new PosetaBasic(poseta.Id, poseta.Datum, poseta.VremeOd, poseta.VremeDo, poseta.Zatvorenik.Id);

            return posetaBasic;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }

    }

    #endregion

    #region OdgovornaLica

    public static async Task<List<OdgovornoLicePregled>> VratiOdgovornaLicaZaFirmu(int firmaPIB)
    {
        List<OdgovornoLicePregled> odgovornaLica = new List<OdgovornoLicePregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return odgovornaLica;
            }

            IEnumerable<OdgovornoLice> lista = await session.Query<OdgovornoLice>().Where(x => x.Firma.PIB == firmaPIB).ToListAsync();

            foreach (OdgovornoLice o in lista)
            {
                odgovornaLica.Add(new OdgovornoLicePregled(o.Id, o.Ime, o.Prezime));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return odgovornaLica;
    }

    public static async Task<OdgovornoLiceBasic?> VratiOdgovornoLice(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return null;
            }

            OdgovornoLice odgovornoLice = await session.LoadAsync<OdgovornoLice>(id);

            OdgovornoLiceBasic odgovornoLiceBasic = new OdgovornoLiceBasic(odgovornoLice.Id, odgovornoLice.Ime, odgovornoLice.Prezime);

            return odgovornoLiceBasic;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void DodajOdgovornoLice(OdgovornoLiceBasic odgovornoLiceBasic, int firmaPIB)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Firma firma = await session.LoadAsync<Firma>(firmaPIB);

            if (firma == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
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
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void IzmeniOdgovornoLice(OdgovornoLiceBasic odgovornoLiceBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }


            OdgovornoLice odgovornoLice = await session.LoadAsync<OdgovornoLice>(odgovornoLiceBasic.Id);

            if (odgovornoLice == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            odgovornoLice.Ime = odgovornoLiceBasic.Ime!;
            odgovornoLice.Prezime = odgovornoLiceBasic.Prezime!;

            await session.UpdateAsync(odgovornoLice);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void ObrisiOdgovornoLice(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            OdgovornoLice odgovornoLice = await session.LoadAsync<OdgovornoLice>(id);

            await session.DeleteAsync(odgovornoLice);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    #endregion

    #region FirmaTelefon

    public static async Task<List<FirmaTelefonPregled>> VratiTelefoneZaFirmu(int firmaPIB)
    {
        List<FirmaTelefonPregled> telefoni = new List<FirmaTelefonPregled>();
        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return telefoni;
            }

            IEnumerable<FirmaTelefon> lista = await session.Query<FirmaTelefon>().Where(x => x.Firma.PIB == firmaPIB).ToListAsync();

            foreach (FirmaTelefon ft in lista)
            {
                telefoni.Add(new FirmaTelefonPregled(ft.Id, ft.BrojTelefona));
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

        return telefoni;
    }

    public static async Task<FirmaTelefonBasic?> VratiTelefon(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return null;
            }

            FirmaTelefon telefon = await session.LoadAsync<FirmaTelefon>(id);

            FirmaTelefonBasic telefonBasic = new FirmaTelefonBasic(telefon.Id, telefon.BrojTelefona);

            return telefonBasic;

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            return null;
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void DodajTelefon(FirmaTelefonBasic telefonBasic, int firmaPIB)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            Firma firma = await session.LoadAsync<Firma>(firmaPIB);

            if (firma == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
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
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void IzmeniTelefon(FirmaTelefonBasic telefonBasic)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            FirmaTelefon telefon = await session.LoadAsync<FirmaTelefon>(telefonBasic.Id);

            if (telefon == null)
            {
                MessageBox.Show("Došlo je do greške!");
                return;
            }

            telefon.BrojTelefona = telefonBasic.BrojTelefona!;

            await session.UpdateAsync(telefon);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    public static async void ObrisiTelefon(int id)
    {

        ISession? session = null;

        try
        {
            session = DataLayer.GetSession();

            if (session == null)
            {
                MessageBox.Show("Veza ka bazi nije uspostavljena.");
                return;
            }

            FirmaTelefon firmaTelefon = await session.LoadAsync<FirmaTelefon>(id);

            await session.DeleteAsync(firmaTelefon);
            await session.FlushAsync();

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
        }
        finally
        {
            session?.Close();
        }

    }

    #endregion 

}