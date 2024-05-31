namespace Zatvor.Forme_za_OSTALO;

public partial class FPrestupi : Form
{
    public FPrestupi()
    {
        InitializeComponent();
    }

    private void FPrestupi_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    private async void popuniPodacima()
    {
        listaPrestupa.Items.Clear();
        List<PrestupPregled> podaci = await DTOManager.VratiSvePrestupe();

        foreach (PrestupPregled p in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { p.Id.ToString(), p.Naziv, p.Kategorija, p.Opis, p.MinKazna, p.MaxKazna });
            listaPrestupa.Items.Add(item);
        }

        listaPrestupa.Refresh();
    }

    private void btnDodajFirmu_Click(object sender, EventArgs e)
    {
        PrestupDodaj forma = new PrestupDodaj(null);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private void btnObrisiFirmu_Click(object sender, EventArgs e)
    {
        if (listaPrestupa.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite prestup koji želite da obrišete!", "Greška");
            return;
        }

        int idPrestupa = Int32.Parse(listaPrestupa.SelectedItems[0].SubItems[0].Text);
        string poruka = "Da li želite da obrišete izabrani prestup?";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.ObrisiPrestup(idPrestupa);
            MessageBox.Show("Prestup je uspešno izbrisan!", "Obaveštenje");
            this.popuniPodacima();
        }
    }

    private async void btnIzmeniFirmu_Click(object sender, EventArgs e)
    {
        if (listaPrestupa.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite prestup čije podatke želite da izmenite!", "Greška");
            return;
        }

        int idPrestupa = Int32.Parse(listaPrestupa.SelectedItems[0].SubItems[0].Text);
        PrestupBasic? prestup = await DTOManager.VratiPrestup(idPrestupa);
        PrestupDodaj forma = new PrestupDodaj(prestup);
        forma.ShowDialog();
        this.popuniPodacima();
    }
}
