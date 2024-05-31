namespace Zatvor.Forme_za_Zatvorske_Jedinice;

public partial class ZatvorskeJediniceDodajPostojeceg : Form
{

    int zatvorskaJedinicaId;

    public ZatvorskeJediniceDodajPostojeceg(int zatvorskaJedinicaId)
    {
        InitializeComponent();
        this.zatvorskaJedinicaId = zatvorskaJedinicaId;
    }

    private void ZatvorskeJediniceZaposleni_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    public async void popuniPodacima()
    {
        listaZaposlenih.Items.Clear();
        List<ZaposleniPregled> podaci = await DTOManager.VratiSveZaposlene();

        foreach (ZaposleniPregled z in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { z.JMBG, z.Ime, z.Prezime, z.DatumObuke.ToShortDateString(), z.TipZaposlenog, z.Zanimanje, z.StrucnaSprema });
            listaZaposlenih.Items.Add(item);

        }

        listaZaposlenih.Refresh();
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {

        if (listaZaposlenih.SelectedItems.Count == 0)
        {
            MessageBox.Show("Morate odabrati zaposlenog!", "Greška");
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
            string idZaposlenog = listaZaposlenih.SelectedItems[0].SubItems[0].Text;
            RadiUBasic radiU = new RadiUBasic(datumPocetka, radnoMesto, zatvorskaJedinicaId);
            DTOManager.ZaposliRadnika(idZaposlenog, radiU);
            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }


    }
}
