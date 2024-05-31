namespace Zatvor.Forme_za_OSTALO;

public partial class FirmaZatvorskeJedinice : Form
{

    int firmaPIB;

    public FirmaZatvorskeJedinice(int firmaPIB)
    {
        InitializeComponent();
        this.firmaPIB = firmaPIB;
    }

    private void FirmaZatvorskeJedinice_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    public async void popuniPodacima()
    {
        listaZatvora.Items.Clear();
        List<ZatvorskaJedinicaPregled> podaci = await DTOManager.VratiZatvoreZaFirmu(firmaPIB);

        foreach (ZatvorskaJedinicaPregled z in podaci)
        {
            string periodZabrane = string.Empty;
            if (!(String.IsNullOrEmpty(z.PeriodZabraneOd) && String.IsNullOrEmpty(z.PeriodZabraneDo)))
                periodZabrane = z.PeriodZabraneOd + " - " + z.PeriodZabraneDo;

            ListViewItem item = new ListViewItem(new string[] { z.Id.ToString(), z.Naziv, z.Adresa, z.Kapacitet.ToString(), z.Tip, periodZabrane });
            listaZatvora.Items.Add(item);

        }

        listaZatvora.Refresh();

        listaOstali.Items.Clear();
        List<ZatvorskaJedinicaPregled> podaci2 = await DTOManager.VratiPotencijalneZatvoreZaFirmu(firmaPIB);

        foreach (ZatvorskaJedinicaPregled z in podaci2)
        {
            string periodZabrane = string.Empty;
            if (!(String.IsNullOrEmpty(z.PeriodZabraneOd) && String.IsNullOrEmpty(z.PeriodZabraneDo)))
                periodZabrane = z.PeriodZabraneOd + " - " + z.PeriodZabraneDo;

            ListViewItem item = new ListViewItem(new string[] { z.Id.ToString(), z.Naziv, z.Adresa, z.Kapacitet.ToString(), z.Tip, periodZabrane });
            listaOstali.Items.Add(item);

        }

        listaOstali.Refresh();

    }

    private void btnDodajSaradnju_Click(object sender, EventArgs e)
    {
        if (listaOstali.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvor sa kojim želite da uspostavite saradnju!", "Greška");
            return;
        }

        int idZatvora = Int32.Parse(listaOstali.SelectedItems[0].SubItems[0].Text);
        string poruka = "Da li želite da uspostavite saradnju sa izabranim zatvorom?";
        string porukaUspesno = "Uspešno ste uspostavili saradnju sa zatvorom!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.ZapocniSaradnju(idZatvora, firmaPIB);
            this.popuniPodacima();
            MessageBox.Show(porukaUspesno, "Obaveštenje");
        }
    }

    private void btnOtkaziSaradnju_Click(object sender, EventArgs e)
    {
        if (listaZatvora.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvor sa kojim želite da otkažete saradnju!", "Greška");
            return;
        }

        int idZatvora = Int32.Parse(listaZatvora.SelectedItems[0].SubItems[0].Text);
        string poruka = "Da li želite da otkažete saradnju sa izabranim zatvorom?";
        string porukaUspesno = "Uspešno ste otkazali saradnju sa zatvorom!";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.OtkaziSaradnju(idZatvora, firmaPIB);
            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.popuniPodacima();
        }

    }
}