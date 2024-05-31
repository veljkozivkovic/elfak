namespace Zatvor.Forme_za_Zatvorenike;

public partial class ZatvoreniciDodaj : Form
{
    ZatvorenikBasic? zatvorenikBasic;
    bool izmena;
    AdvokatBasic? advokatBasic;

    public ZatvoreniciDodaj(ZatvorenikBasic? zatvorenikBasic)
    {
        InitializeComponent();
        advokatBasic = new AdvokatBasic();
        if (zatvorenikBasic != null)
        {
            this.zatvorenikBasic = zatvorenikBasic;
            this.advokatBasic = zatvorenikBasic.Advokat;
            izmena = true;
            popuniPolja();
        }
        else
        {
            this.zatvorenikBasic = new ZatvorenikBasic();
            izmena = false;
        }
    }

    private void popuniPolja()
    {
        btnDodaj.Text = "Izmeni";
        txtIme.Text = zatvorenikBasic!.Ime;
        txtPrezime.Text = zatvorenikBasic!.Prezime;
        txtAdresa.Text = zatvorenikBasic!.Adresa;
        cbxPol.SelectedItem = zatvorenikBasic!.Pol.ToString();
        txtStatusUslovnogOtpusta.Text = zatvorenikBasic!.StatusUslovnogOtpusta;
        dtmSledecegSaslusanja.Value = zatvorenikBasic!.DatumSledecegSaslusanja;
    }

    private async void popuniPodacima()
    {
        listaZatvora.Items.Clear();
        List<ZatvorskaJedinicaPregled> podaci = await DTOManager.VratiSveZatvore();

        foreach (ZatvorskaJedinicaPregled z in podaci)
        {
            string periodZabrane = string.Empty;
            if (!(String.IsNullOrEmpty(z.PeriodZabraneOd) && String.IsNullOrEmpty(z.PeriodZabraneDo)))
                periodZabrane = z.PeriodZabraneOd + " - " + z.PeriodZabraneDo;

            ListViewItem item = new ListViewItem(new string[] { z.Id.ToString(), z.Naziv, z.Adresa, z.Kapacitet.ToString(), z.Tip, periodZabrane });
            if (izmena)
            {
                if (z.Id == zatvorenikBasic!.ZatvorskaJedinica!.Id)
                {
                    item.Selected = true;
                }
            }

            listaZatvora.Items.Add(item);

        }

        listaZatvora.Refresh();
    }

    private void ZatvoreniciDodaj_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {
        string ime = txtIme.Text;

        if (String.IsNullOrEmpty(ime))
        {
            MessageBox.Show("Morate uneti ime zatvorenika!", "Greška");
            return;
        }

        string prezime = txtPrezime.Text;

        if (String.IsNullOrEmpty(prezime))
        {
            MessageBox.Show("Morate uneti prezime zatvorenika!", "Greška");
            return;
        }

        string adresa = txtAdresa.Text;

        if (String.IsNullOrEmpty(prezime))
        {
            MessageBox.Show("Morate uneti adresu zatvorenika!", "Greška");
            return;
        }

        if (cbxPol.SelectedItem == null)
        {

            MessageBox.Show("Morate izabrati pol zatvorenika!", "Greška");
            return;
        }

        string? pol = cbxPol.SelectedItem!.ToString();

        string statusUslovnogOtpusta = txtStatusUslovnogOtpusta.Text;

        if (String.IsNullOrEmpty(statusUslovnogOtpusta))
        {
            MessageBox.Show("Morate uneti status uslovnog otpusta zatvorenika!", "Greška");
            return;
        }

        if (String.IsNullOrEmpty(advokatBasic?.JMBG))
        {
            MessageBox.Show("Morate izabrati advokata!", "Greška");
            return;
        }

        if (listaZatvora.SelectedItems.Count == 0)
        {
            MessageBox.Show("Morate izabrati zatvorsku jedinicu!", "Greška");
            return;
        }

        int idZatvorskeJedinice = Int32.Parse(listaZatvora.SelectedItems[0].SubItems[0].Text);

        string poruka = izmena ? "Da li želite da izmenite podatke o zatvoreniku?" :
                                 "Da li želite da dodate novog zatvorenika?";

        string porukaUspesno = izmena ? "Uspešno ste izmenili podatke o zatvoreniku!" :
                                        "Uspešno ste dodali novog zatvorenika!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            this.zatvorenikBasic!.Ime = ime;
            this.zatvorenikBasic.Prezime = prezime;
            this.zatvorenikBasic.Adresa = adresa;
            this.zatvorenikBasic.Pol = Char.Parse(pol!);
            this.zatvorenikBasic.StatusUslovnogOtpusta = statusUslovnogOtpusta;
            this.zatvorenikBasic.DatumSledecegSaslusanja = dtmSledecegSaslusanja.Value;
            this.zatvorenikBasic.Advokat = advokatBasic;

            if (izmena)
                DTOManager.IzmeniZatvorenika(this.zatvorenikBasic, idZatvorskeJedinice);
            else
                DTOManager.DodajZatvorenika(this.zatvorenikBasic, idZatvorskeJedinice);

            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }
    }

    private void btnAdvokat_Click(object sender, EventArgs e)
    {
        ZatvoreniciDodajIzaberiAdvokata forma = new ZatvoreniciDodajIzaberiAdvokata(zatvorenikBasic, advokatBasic, izmena);
        forma.ShowDialog();
    }

}