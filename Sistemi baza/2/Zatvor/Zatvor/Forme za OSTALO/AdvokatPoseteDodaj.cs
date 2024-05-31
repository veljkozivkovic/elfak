namespace Zatvor.Forme_za_OSTALO;

public partial class AdvokatPoseteDodaj : Form
{

    PosetaBasic? poseta;
    string advokatJMBG;
    bool izmena;

    public AdvokatPoseteDodaj(string advokatJMBG, PosetaBasic? poseta)
    {
        InitializeComponent();
        this.advokatJMBG = advokatJMBG;
        if (poseta != null)
        {
            this.poseta = poseta;
            izmena = true;
            popuniPolja();
        }
        else
        {
            this.poseta = null;
            izmena = false;
        }
    }

    private void popuniPolja()
    {
        btnDodaj.Text = "Izmeni";
        txtVremeOd.Text = poseta!.VremeOd;
        txtVremeDo.Text = poseta!.VremeDo;
        dtmDatum.Value = poseta!.Datum;
        listaZatvorenika.Enabled = false;
    }

    private void AdvokatPoseteDodaj_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    public async void popuniPodacima()
    {
        listaZatvorenika.Items.Clear();
        List<ZatvorenikPregled> podaci = await DTOManager.VratiZatvorenikeZaAdvokata(advokatJMBG);

        foreach (ZatvorenikPregled z in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { z.Id.ToString(), z.Ime, z.Prezime, z.NazivZatvorskeJedinice, z.Adresa, z.Pol.ToString(), z.StatusUslovnogOtpusta, z.DatumSledecegSaslusanja.ToShortDateString(), z.AdvokatImeIPrezime!, z.AdvokatDatum.ToShortDateString(), z.AdvokatPoslednjiKontakt.ToShortDateString() });
            
            if (izmena && z.Id == poseta!.ZatvorenikId)
            {
                item.Selected = true;
            }
            
            listaZatvorenika.Items.Add(item);
        }

        listaZatvorenika.Refresh();
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtVremeOd.Text))
        {
            MessageBox.Show("Morate uneti vreme početka posete!", "Greška");
            return;
        }

        if (txtVremeOd.Text.Length != 5 || txtVremeOd.Text[2] != ':')
        {
            MessageBox.Show("Vreme početka posete mora biti u formatu HH:mm!", "Greška");
            return;
        }

        string vremeOd = txtVremeOd.Text;

        if (String.IsNullOrEmpty(txtVremeOd.Text))
        {
            MessageBox.Show("Morate uneti vreme kraja posete!", "Greška");
            return;
        }

        if (txtVremeDo.Text.Length != 5 || txtVremeDo.Text[2] != ':')
        {
            MessageBox.Show("Vreme kraja posete mora biti u formatu HH:mm!", "Greška");
            return;
        }

        string vremeDo = txtVremeDo.Text;

        if (listaZatvorenika.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvorenika za koga je vezana poseta!", "Greška");
            return;
        }

        string poruka = izmena ? "Da li želite da izmenite podatke o poseti?"
                                : "Da li želite da dodate novu posetu?";
        string porukaUspesno = izmena ? "Uspešno ste izmenili podatke o poseti!"
                                      : "Uspešno ste dodali novu posetu!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            int idZatvorenika = Int32.Parse(listaZatvorenika.SelectedItems[0].SubItems[0].Text);
            int posetaId = izmena ? poseta!.Id : 0;
            PosetaBasic posetaBasic = new PosetaBasic()
            {
                Id = posetaId,
                ZatvorenikId = idZatvorenika,
                VremeOd = vremeOd,
                VremeDo = vremeDo,
                Datum = dtmDatum.Value
            };

            if (izmena)
                DTOManager.IzmeniPosetu(posetaBasic);
            else
                DTOManager.DodajPosetu(posetaBasic);

            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }

    }
}
