namespace Zatvor.Forme_za_OSTALO;

public partial class AdvokatZatvoreniciDodaj : Form
{

    string advokatJMBG;

    public AdvokatZatvoreniciDodaj(string advokatJMBG)
    {
        InitializeComponent();
        this.advokatJMBG = advokatJMBG;
    }

    private void AdvokatZatvoreniciDodaj_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    private async void popuniPodacima()
    {
        listaZatvorenika.Items.Clear();
        List<ZatvorenikPregled> podaci = await DTOManager.VratiMoguceZatvorenikeZaAdvokata(advokatJMBG);

        foreach (ZatvorenikPregled z in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { z.Id.ToString(), z.Ime, z.Prezime, z.NazivZatvorskeJedinice, z.Adresa, z.Pol.ToString(), z.StatusUslovnogOtpusta, z.DatumSledecegSaslusanja.ToShortDateString(), z.AdvokatImeIPrezime!, z.AdvokatDatum.ToShortDateString(), z.AdvokatPoslednjiKontakt.ToShortDateString() });
            listaZatvorenika.Items.Add(item);
        }

        listaZatvorenika.Refresh();
    }

    private void btnZastupaj_Click(object sender, EventArgs e)
    {
        if (listaZatvorenika.SelectedItems.Count == 0)
        {
            MessageBox.Show("Morate izabrati zatvorenika!", "Greška");
            return;
        }

        string poruka = "Da li želite da dodate novo zastupanje?";

        string porukaUspesno = "Uspešno ste dodali novo zastupanje!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            int zatvorenikId = int.Parse(listaZatvorenika.SelectedItems[0].SubItems[0].Text);
            DTOManager.DodajZastupanje(zatvorenikId, advokatJMBG);
            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }
    }

}
