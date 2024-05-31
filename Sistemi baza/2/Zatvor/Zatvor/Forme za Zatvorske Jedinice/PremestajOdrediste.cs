namespace Zatvor.Forme_za_Zatvorske_Jedinice;

public partial class PremestajOdrediste : Form
{
    ZatvorenikBasic? zatvorenik;
    int zatvorskaJedinicaIzvorId;

    public PremestajOdrediste(ZatvorenikBasic? zatvorenik, int zatvorskaJedinicaIzvorId)
    {
        InitializeComponent();
        this.zatvorenik = zatvorenik;
        this.zatvorskaJedinicaIzvorId = zatvorskaJedinicaIzvorId;
    }

    private void PremestajOdrediste_Load(object sender, EventArgs e)
    {
        popuniPodacima();
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

            if (z.Id == zatvorskaJedinicaIzvorId)
                item.BackColor = Color.Gray;

            listaZatvora.Items.Add(item);

        }

        listaZatvora.Refresh();
    }

    private void btnIzaberi_Click(object sender, EventArgs e)
    {
        if (listaZatvora.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvor gde želite da premestite zatvorenika!", "Greška");
            return;
        }

        int idZatvora = Int32.Parse(listaZatvora.SelectedItems[0].SubItems[0].Text);
        DTOManager.IzmeniZatvorenika(zatvorenik!, idZatvora);

        this.Close();
    }

    private void listaZatvora_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        ListViewItem item = e.Item!;
        int idZatvora = Int32.Parse(item.SubItems[0].Text);

        if (idZatvora == zatvorskaJedinicaIzvorId)
            item.Selected = false;

    }
}
