namespace Zatvor.Forme_za_Zatvorske_Jedinice;

public partial class ZatvorskeJediniceFirme : Form
{

    int zatvorskaJedinicaId;

    public ZatvorskeJediniceFirme(int zatvorskaJedinicaId)
    {
        InitializeComponent();
        this.zatvorskaJedinicaId = zatvorskaJedinicaId;
    }

    private void ZatvorskeJediniceFirme_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    private async void popuniPodacima()
    {
        listaFirmi.Items.Clear();
        List<FirmaPregled> podaci = await DTOManager.VratiFirmeZaZatvorskuJedinicu(zatvorskaJedinicaId);

        foreach (FirmaPregled f in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { f.PIB.ToString()!, f.Ime!, f.Adresa! });
            listaFirmi.Items.Add(item);
        }

        listaFirmi.Refresh();
    }

    private void btnDodajSaradnju_Click(object sender, EventArgs e)
    {
        ZatvorskeJediniceFirmeDodaj forma = new ZatvorskeJediniceFirmeDodaj(zatvorskaJedinicaId);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private void btnObrisiSaradnju_Click(object sender, EventArgs e)
    {
        if (listaFirmi.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite posetu koju želite da obrišete!", "Greška");
            return;
        }

        int idFirme = Int32.Parse(listaFirmi.SelectedItems[0].SubItems[0].Text);
        string poruka = "Da li želite da otkažete saradnju?";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.OtkaziSaradnju(zatvorskaJedinicaId, idFirme);
            MessageBox.Show("Saradnja je uspešno otkazana!", "Obaveštenje");
            this.popuniPodacima();
        }
    }
}