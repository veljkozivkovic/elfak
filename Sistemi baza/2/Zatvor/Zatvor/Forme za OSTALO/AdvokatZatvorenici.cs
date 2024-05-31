namespace Zatvor.Forme_za_OSTALO;

public partial class AdvokatZatvorenici : Form
{

    string advokatJMBG;

    public AdvokatZatvorenici(string advokatJMBG)
    {
        InitializeComponent();
        this.advokatJMBG = advokatJMBG;
    }

    private async void popuniPodacima()
    {
        listaZatvorenika.Items.Clear();
        List<ZatvorenikPregled> podaci = await DTOManager.VratiZatvorenikeZaAdvokata(advokatJMBG);

        foreach (ZatvorenikPregled z in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { z.Id.ToString(), z.Ime, z.Prezime, z.NazivZatvorskeJedinice, z.Adresa, z.Pol.ToString(), z.StatusUslovnogOtpusta, z.DatumSledecegSaslusanja.ToShortDateString(), z.AdvokatDatum.ToShortDateString(), z.AdvokatPoslednjiKontakt.ToShortDateString() });
            listaZatvorenika.Items.Add(item);
        }

        listaZatvorenika.Refresh();
    }

    private void AdvokatZatvorenici_Load(object sender, EventArgs e)
    {
        this.popuniPodacima();
    }

    private void btnDodajZatvorenika_Click(object sender, EventArgs e)
    {
        AdvokatZatvoreniciDodaj forma = new AdvokatZatvoreniciDodaj(advokatJMBG);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private void btnObrisiZatvorenika_Click(object sender, EventArgs e)
    {
        if (listaZatvorenika.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvorenika za koga želite da otkažete zastupanje!", "Greška");
            return;
        }

        int idZatvorenika = Int32.Parse(listaZatvorenika.SelectedItems[0].SubItems[0].Text);
        string poruka = "Da li želite da otkažete zastupanje za izabranog zatvorenika?";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.OtkaziZastupanje(idZatvorenika);
            MessageBox.Show("Zastupanje je uspešno otkazano!", "Obaveštenje");
            this.popuniPodacima();
        }
    }
}
