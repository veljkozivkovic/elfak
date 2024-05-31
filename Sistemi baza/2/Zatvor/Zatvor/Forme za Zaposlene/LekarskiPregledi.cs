namespace Zatvor.Forme_za_Zaposlene;

public partial class LekarskiPregledi : Form
{
    string zaposleniJMBG;

    public LekarskiPregledi(string zaposleniJMBG)
    {
        InitializeComponent();
        this.zaposleniJMBG = zaposleniJMBG;
    }

    private void LekarskiPregledi_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    private async void popuniPodacima()
    {
        listaPregleda.Items.Clear();
        List<LekarskiPregledPregled> podaci = await DTOManager.VratiLekarskePreglede(zaposleniJMBG);

        foreach (LekarskiPregledPregled l in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { l.Id.ToString(), l.Datum.ToShortDateString(), l.NazivUstanove, l.AdresaUstanove, l.Lekar });
            listaPregleda.Items.Add(item);
        }

        listaPregleda.Refresh();
    }

    private void btnDodajPregled_Click(object sender, EventArgs e)
    {
        LekarskiPregledDodaj forma = new LekarskiPregledDodaj(zaposleniJMBG, null);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private void btnObrisiPregled_Click(object sender, EventArgs e)
    {
        if (listaPregleda.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite lekarski pregled koji želite da obrišete!", "Greška");
            return;
        }

        int idPregleda = Int32.Parse(listaPregleda.SelectedItems[0].SubItems[0].Text);
        string poruka = "Da li želite da obrišete izabrani lekarski pregled?";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.ObrisiLekarskiPregled(idPregleda);
            MessageBox.Show("Lekarski pregled je uspešno izbrisan!", "Obaveštenje");
            this.popuniPodacima();
        }
    }

    private async void btnIzmeniRadnoMesto_Click(object sender, EventArgs e)
    {
        if (listaPregleda.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite lekarski pregled čije podatke želite da izmenite!", "Greška");
            return;
        }

        int idPregleda = Int32.Parse(listaPregleda.SelectedItems[0].SubItems[0].Text);
        LekarskiPregledBasic? lp = await DTOManager.VratiLekarskiPregled(idPregleda);
        LekarskiPregledDodaj forma = new LekarskiPregledDodaj(this.zaposleniJMBG, lp);
        forma.ShowDialog();
        this.popuniPodacima();
    }

}
