namespace Zatvor.Forme_za_Zaposlene;

public partial class Obuke : Form
{
    string zaposleniJMBG;

    public Obuke(string zaposleniJMBG)
    {
        InitializeComponent();
        this.zaposleniJMBG = zaposleniJMBG;
    }

    private void Obuke_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    private async void popuniPodacima()
    {
        listaObuka.Items.Clear();
        List<ObukaVatrenoOruzjePregled> podaci = await DTOManager.VratiObuke(zaposleniJMBG);

        foreach (ObukaVatrenoOruzjePregled o in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { o.Id.ToString(), o.DatumIzdavanja.ToShortDateString(), o.PolicijskaUprava });
            listaObuka.Items.Add(item);
        }

        listaObuka.Refresh();
    }

    private void btnDodajObuku_Click(object sender, EventArgs e)
    {
        ObukeDodaj forma = new ObukeDodaj(zaposleniJMBG, null);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private void btnObrisiObuku_Click(object sender, EventArgs e)
    {
        if (listaObuka.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite obuku koji želite da obrišete!", "Greška");
            return;
        }

        int idObuke = Int32.Parse(listaObuka.SelectedItems[0].SubItems[0].Text);
        string poruka = "Da li želite da obrišete izabranu obuku?";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.ObrisiObuku(idObuke);
            MessageBox.Show("Obuka je uspešno izbrisana!", "Obaveštenje");
            this.popuniPodacima();
        }
    }

    private async void btnIzmeniObuku_Click(object sender, EventArgs e)
    {
        if (listaObuka.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite obuku čije podatke želite da izmenite!", "Greška");
            return;
        }

        int idObuke = Int32.Parse(listaObuka.SelectedItems[0].SubItems[0].Text);
        ObukaVatrenoOruzjeBasic? o = await DTOManager.VratiObuku(idObuke);
        ObukeDodaj forma = new ObukeDodaj(this.zaposleniJMBG, o);
        forma.ShowDialog();
        this.popuniPodacima();
    }

}
