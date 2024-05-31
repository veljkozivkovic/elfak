namespace Zatvor.Forme_za_Zaposlene;

public partial class ZaposleniZaposlenjaDodaj : Form
{

    string zaposleniJMBG;

    public ZaposleniZaposlenjaDodaj(string zaposleniJMBG)
    {
        InitializeComponent();
        this.zaposleniJMBG = zaposleniJMBG;
    }

    private void ZaposleniZaposlenjaDodaj_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    public async void popuniPodacima()
    {
        listaZatvora.Items.Clear();
        List<ZatvorskaJedinicaPregled> podaci = await DTOManager.VratiSveZatvore();

        foreach (ZatvorskaJedinicaPregled z in podaci)
        {
            string periodZabrane = string.Empty;
            if (!(String.IsNullOrEmpty(z.PeriodZabraneOd) && String.IsNullOrEmpty(z.PeriodZabraneDo)))
                periodZabrane = z.PeriodZabraneOd + " - " + z.PeriodZabraneDo;

            ListViewItem item = new ListViewItem(new string[] { z.Id.ToString(), z.Naziv, z.Adresa, z.Kapacitet.ToString(), z.Tip, periodZabrane });
            
            listaZatvora.Items.Add(item);

        }

        listaZatvora.Refresh();
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {

        if (listaZatvora.SelectedItems.Count == 0)
        {
            MessageBox.Show("Morate odabrati zatvorsku jedinicu!", "Greška");
            return;
        }

        if (String.IsNullOrEmpty(txtRadnoMesto.Text))
        {
            MessageBox.Show("Morate uneti radno mesto zaposlenog!", "Greška");
            return;
        }

        string radnoMesto = txtRadnoMesto.Text;
        DateTime datumPocetka = dtmZaposlenja.Value;

        string poruka = "Da li želite da zaposlite zaposlenog u zatvorsku jedinicu?";
        string porukaUspesno = "Uspešno ste zaposlili zaposlenog!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            int zatvorskaJedinicaId = Int32.Parse(listaZatvora.SelectedItems[0].SubItems[0].Text);
            RadiUBasic radiU = new RadiUBasic(datumPocetka, radnoMesto, zatvorskaJedinicaId);
            DTOManager.ZaposliRadnika(zaposleniJMBG, radiU);
            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }

    }
}
