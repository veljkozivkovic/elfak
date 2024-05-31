namespace Zatvor.Forme_za_OSTALO;

public partial class FirmaOdgovornaLica : Form
{

    int firmaPIB;

    public FirmaOdgovornaLica(int firmaPIB)
    {
        InitializeComponent();
        this.firmaPIB = firmaPIB;
    }

    private void FirmaOdgovornaLica_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    private async void popuniPodacima()
    {
        listaOdgovornihLica.Items.Clear();
        List<OdgovornoLicePregled> podaci = await DTOManager.VratiOdgovornaLicaZaFirmu(firmaPIB);

        foreach (OdgovornoLicePregled o in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { o.Id.ToString(), o.Ime, o.Prezime });
            listaOdgovornihLica.Items.Add(item);
        }

        listaOdgovornihLica.Refresh();
    }

    private void btnDodajOdgovornoLice_Click(object sender, EventArgs e)
    {
        FirmaOdgovornaLicaDodaj forma = new FirmaOdgovornaLicaDodaj(null, firmaPIB);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private void btnObrisiPosetu_Click(object sender, EventArgs e)
    {
        if (listaOdgovornihLica.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite odgovorno lice koje želite da obrišete!", "Greška");
            return;
        }

        int idOdgovornogLica = Int32.Parse(listaOdgovornihLica.SelectedItems[0].SubItems[0].Text);
        string poruka = "Da li želite da obrišete odgovorno lice?";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.ObrisiOdgovornoLice(idOdgovornogLica);
            MessageBox.Show("Odgovorno lice je uspešno izbrisano!", "Obaveštenje");
            this.popuniPodacima();
        }
    }

    private async void btnIzmeniPosetu_Click(object sender, EventArgs e)
    {
        if (listaOdgovornihLica.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite odgovorno lice čije podatke želite da izmenite!", "Greška");
            return;
        }

        int idOdgovornogLica = Int32.Parse(listaOdgovornihLica.SelectedItems[0].SubItems[0].Text);
        OdgovornoLiceBasic? odgovornoLice = await DTOManager.VratiOdgovornoLice(idOdgovornogLica);
        FirmaOdgovornaLicaDodaj forma = new FirmaOdgovornaLicaDodaj(odgovornoLice, firmaPIB);
        forma.ShowDialog();
        this.popuniPodacima();
    }
}