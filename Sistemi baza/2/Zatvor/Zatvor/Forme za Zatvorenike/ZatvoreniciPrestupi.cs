namespace Zatvor.Forme_za_Zatvorenike;

public partial class ZatvoreniciPrestupi : Form
{

    int zatvorenikId;

    public ZatvoreniciPrestupi(int zatvorenikId)
    {
        InitializeComponent();
        this.zatvorenikId = zatvorenikId;
    }

    private void ZatvoreniciPrestupi_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    private async void popuniPodacima()
    {
        listaPrestupa.Items.Clear();
        List<IzvrsenPrestupPregled> podaci = await DTOManager.VratiIzvrsenePrestupe(zatvorenikId);

        foreach (IzvrsenPrestupPregled p in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { p.Id.ToString(), p.Naziv, p.Mesto, p.Datum.ToShortDateString(), p.Kategorija, p.Opis, p.MinKazna, p.MaxKazna });
            listaPrestupa.Items.Add(item);
        }

        listaPrestupa.Refresh();
    }

    private void btnDodajPrestup_Click(object sender, EventArgs e)
    {
        ZatvoreniciPrestupiDodaj forma = new ZatvoreniciPrestupiDodaj(zatvorenikId);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private void btnObrisiPrestup_Click(object sender, EventArgs e)
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
            DTOManager.ObrisiIzvrsenPrestup(idPrestupa);
            MessageBox.Show("Izvršeni prestup je uspešno izbrisan!", "Obaveštenje");
            this.popuniPodacima();
        }
    }

    private async void btnIzmeniPrestup_Click(object sender, EventArgs e)
    {
        if (listaPrestupa.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite prestup čije podatke želite da izmenite!", "Greška");
            return;
        }

        int idPrestupa = Int32.Parse(listaPrestupa.SelectedItems[0].SubItems[0].Text);
        IzvrsenPrestupBasic? prestup = await DTOManager.VratiIzvrsenPrestup(idPrestupa);
        ZatvoreniciPrestupiIzmeni forma = new ZatvoreniciPrestupiIzmeni(prestup!);
        forma.ShowDialog();
        this.popuniPodacima();
    }
}