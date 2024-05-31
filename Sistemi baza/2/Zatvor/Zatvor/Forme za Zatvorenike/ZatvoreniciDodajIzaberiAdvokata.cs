namespace Zatvor.Forme_za_Zatvorenike;

public partial class ZatvoreniciDodajIzaberiAdvokata : Form
{

    ZatvorenikBasic? zatvorenikBasic;
    AdvokatBasic? advokatBasic;
    bool izmena;

    public ZatvoreniciDodajIzaberiAdvokata(ZatvorenikBasic? zatvorenikBasic, AdvokatBasic? advokatBasic, bool izmena)
    {
        InitializeComponent();
        this.zatvorenikBasic = zatvorenikBasic;
        this.advokatBasic = advokatBasic;
        this.izmena = izmena;
    }

    private void FZatvoreniciDodajIzaberiAdvokata_Load(object sender, EventArgs e)
    {
        popuniPodacima();

        if (izmena)
        {
            dtmDodele.Value = zatvorenikBasic!.AdvokatDatum;
            dtmPoslednjiKontakt.Value = zatvorenikBasic!.AdvokatPoslednjiKontakt;
        }

    }

    public async void popuniPodacima()
    {
        listaAdvokata.Items.Clear();
        List<AdvokatPregled>? podaci = await DTOManager.VratiSveAdvokate();

        foreach (AdvokatPregled a in podaci!)
        {
            ListViewItem item = new ListViewItem(new string[] { a.JMBG!, a.Ime!, a.Prezime! });
            if (izmena && item.SubItems[0].Text == zatvorenikBasic!.Advokat!.JMBG)
                item.Selected = true;
            listaAdvokata.Items.Add(item);

        }

        listaAdvokata.Refresh();
    }

    private async void btnDodeli_Click(object sender, EventArgs e)
    {
        if (listaAdvokata.SelectedItems.Count == 0)
        {
            MessageBox.Show("Morate izabrati advokata!", "Greška");
            return;
        }

        string jmbg = listaAdvokata.SelectedItems[0].SubItems[0].Text;
        AdvokatBasic? izabraniAdvokat = await DTOManager.VratiAdvokata(jmbg);

        advokatBasic!.JMBG = izabraniAdvokat!.JMBG;
        advokatBasic.Ime = izabraniAdvokat.Ime;
        advokatBasic.Prezime = izabraniAdvokat.Prezime;

        zatvorenikBasic!.AdvokatDatum = dtmDodele.Value;
        zatvorenikBasic.AdvokatPoslednjiKontakt = dtmPoslednjiKontakt.Value;
        
        this.Close();
    }

}
