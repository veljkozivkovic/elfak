namespace Zatvor.Forme_za_Zatvorske_Jedinice;

public partial class TerminiSetnje : Form
{

    ZatvorskaJedinicaBasic zatvorskaJedinica;

    public TerminiSetnje(ZatvorskaJedinicaBasic zatvorskaJedinica)
    {
        InitializeComponent();
        this.zatvorskaJedinica = zatvorskaJedinica;
    }

    private void TerminiPosete_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    public async void popuniPodacima()
    {
        listaTermina.Items.Clear();
        List<TerminSetnjePregled>? podaci = await DTOManager.VratiTermineSetnje(zatvorskaJedinica.Id);

        foreach (TerminSetnjePregled t in podaci!)
        {
            ListViewItem item = new ListViewItem(new string[] { t.Id.ToString(), t.TerminOd, t.TerminDo });
            listaTermina.Items.Add(item);
        }

        listaTermina.Refresh();
    }

    private void btnDodajTermin_Click(object sender, EventArgs e)
    {
        TerminSetnjeDodaj forma = new TerminSetnjeDodaj(null, zatvorskaJedinica.Id);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private async void btnIzmeniTermin_Click(object sender, EventArgs e)
    {
        if (listaTermina.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite termin čije podatke želite da izmenite!", "Greška");
            return;
        }

        int idTermina = Int32.Parse(listaTermina.SelectedItems[0].SubItems[0].Text);
        TerminSetnjeBasic? termin = await DTOManager.VratiTerminSetnje(idTermina);
        TerminSetnjeDodaj forma = new TerminSetnjeDodaj(termin, zatvorskaJedinica.Id);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private void btnObrisiTermin_Click(object sender, EventArgs e)
    {
        if (listaTermina.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite termin koji želite da obrišete!", "Greška");
            return;
        }

        int idTermina = Int32.Parse(listaTermina.SelectedItems[0].SubItems[0].Text);
        string poruka = "Da li želite da obrišete izabran termin?";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.ObrisiTerminSetnje(idTermina);
            MessageBox.Show("Termin je uspešno izbrisan!", "Obaveštenje");
            this.popuniPodacima();
        }
    }
}
