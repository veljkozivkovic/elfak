namespace Zatvor.Forme_za_Zaposlene;

public partial class ZaposleniZaposlenja : Form
{
    string zaposleniJMBG;

    public ZaposleniZaposlenja(string zaposleniJMBG)
    {
        InitializeComponent();
        this.zaposleniJMBG = zaposleniJMBG;
    }

    private void ZaposleniZaposlenja_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    private async void popuniPodacima()
    {
        listaZaposlenja.Items.Clear();
        List<RadiUPregled> podaci = await DTOManager.VratiZaposlenjaZaZaposlenog(zaposleniJMBG);

        foreach (RadiUPregled r in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { r.JMBG, r.Ime, r.Prezime, r.NazivZatvorskeJedinice, r.RadnoMesto, r.DatumPocetkaRada.ToShortDateString() });
            listaZaposlenja.Items.Add(item);
        }

        listaZaposlenja.Refresh();
    }

    private void btnDodajRadnoMesta_Click(object sender, EventArgs e)
    {
        ZaposleniZaposlenjaDodaj forma = new ZaposleniZaposlenjaDodaj(zaposleniJMBG);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private void btnObrisiRadnoMesto_Click(object sender, EventArgs e)
    {
        if (listaZaposlenja.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite radno mesto koje želite da obrišete!", "Greška");
            return;
        }

        string zaposleniJMBG = listaZaposlenja.SelectedItems[0].SubItems[0].Text;
        string zatvorskaJedinicaNaziv = listaZaposlenja.SelectedItems[0].SubItems[3].Text;
        string radnoMestoNaziv = listaZaposlenja.SelectedItems[0].SubItems[4].Text;
        string poruka = "Da li želite da obrišete izabrano radno mesto?";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.ObrisiRadnoMesto(zaposleniJMBG, zatvorskaJedinicaNaziv, radnoMestoNaziv);
            MessageBox.Show("Radno mesto je uspešno izbrisano!", "Obaveštenje");
            this.popuniPodacima();
        }
    }

    private void btnIzmeniRadnoMesto_Click(object sender, EventArgs e)
    {
        if (listaZaposlenja.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite radno mesto čije podatke želite da izmenite!", "Greška");
            return;
        }

        string zaposleniJMBG = listaZaposlenja.SelectedItems[0].SubItems[0].Text;
        string zatvorskaJedinicaNaziv = listaZaposlenja.SelectedItems[0].SubItems[3].Text;
        string radnoMestoNaziv = listaZaposlenja.SelectedItems[0].SubItems[4].Text;
        DateTime datumZaposlenja = DateTime.Parse(listaZaposlenja.SelectedItems[0].SubItems[5].Text);
        ZaposleniZaposlenjaIzmeni forma = new ZaposleniZaposlenjaIzmeni(zatvorskaJedinicaNaziv, zaposleniJMBG, radnoMestoNaziv, datumZaposlenja);
        forma.ShowDialog();
        this.popuniPodacima();
    }

}
