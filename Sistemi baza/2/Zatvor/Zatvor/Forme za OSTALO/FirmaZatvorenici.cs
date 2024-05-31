namespace Zatvor.Forme_za_OSTALO;

public partial class FirmaZatvorenici : Form
{

    int firmaPIB;

    public FirmaZatvorenici(int firmaPIB)
    {
        InitializeComponent();
        this.firmaPIB = firmaPIB;
    }

    private void FirmaZatvorenici_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    public async void popuniPodacima()
    {
        listaZatvorenika.Items.Clear();
        List<ZatvorenikPregled> podaci = await DTOManager.VratiZatvorenikeZaFirmu(firmaPIB);

        foreach (ZatvorenikPregled z in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { z.Id.ToString(), z.Ime, z.Prezime, z.NazivZatvorskeJedinice, z.Adresa, z.Pol.ToString(), z.StatusUslovnogOtpusta, z.DatumSledecegSaslusanja.ToShortDateString(), z.AdvokatImeIPrezime!, z.AdvokatDatum.ToShortDateString(), z.AdvokatPoslednjiKontakt.ToShortDateString() });
            listaZatvorenika.Items.Add(item);
        }

        listaZatvorenika.Refresh();

        listaOstali.Items.Clear();
        List<ZatvorenikPregled> podaci2 = await DTOManager.VratiPotencijalneRadnike(firmaPIB);

        foreach (ZatvorenikPregled z in podaci2)
        {
            ListViewItem item = new ListViewItem(new string[] { z.Id.ToString(), z.Ime, z.Prezime, z.NazivZatvorskeJedinice, z.Adresa, z.Pol.ToString(), z.StatusUslovnogOtpusta, z.DatumSledecegSaslusanja.ToShortDateString(), z.AdvokatImeIPrezime!, z.AdvokatDatum.ToShortDateString(), z.AdvokatPoslednjiKontakt.ToShortDateString() });
            listaOstali.Items.Add(item);
        }

        listaOstali.Refresh();

    }

    private void btnZaposliZatvorenika_Click(object sender, EventArgs e)
    {
        if (listaOstali.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvorenika koga želite da zaposlite!", "Greška");
            return;
        }

        int idZatvorenika = Int32.Parse(listaOstali.SelectedItems[0].SubItems[0].Text);
        string poruka = "Da li želite da zaposlite izabranog zatvorenika?";
        string porukaUspesno = "Uspešno ste zaposlili izabranog zatvorenika!";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.ZaposliZatvorenika(idZatvorenika, firmaPIB);
            this.popuniPodacima();
            MessageBox.Show(porukaUspesno, "Obaveštenje");
        }
    }

    private void btnDajOtkaz_Click(object sender, EventArgs e)
    {
        if (listaZatvorenika.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvorenika kome želite da date otkaz!", "Greška");
            return;
        }

        int idZatvorenika = Int32.Parse(listaZatvorenika.SelectedItems[0].SubItems[0].Text);
        string poruka = "Da li želite da date otkaz izabranom zatvoreniku?";
        string porukaUspesno = "Uspešno ste dali otkaz izabranom zatvoreniku!";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.DajOtkazZatvoreniku(idZatvorenika);
            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.popuniPodacima();
        }

    }
}