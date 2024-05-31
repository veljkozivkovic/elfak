namespace Zatvor.Forme_za_Zatvorske_Jedinice;

public partial class PremestajIzvoristeZatvorenici : Form
{

    int zatvorDestinacijaId;
    int zatvorIzvorId;

    public PremestajIzvoristeZatvorenici(int zatvorDestinacijaId, int zatvorIzvorId)
    {
        InitializeComponent();
        this.zatvorDestinacijaId = zatvorDestinacijaId;
        this.zatvorIzvorId = zatvorIzvorId;
    }

    private void PremestajIzvoristeZatvorenici_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    private async void popuniPodacima()
    {
        listaZatvorenika.Items.Clear();
        List<ZatvorenikPregled> podaci = await DTOManager.VratiZatvorenikeZaZatvorskuJedinicu(zatvorIzvorId);

        foreach (ZatvorenikPregled z in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { z.Id.ToString(), z.Ime, z.Prezime, z.Adresa, z.Pol.ToString(), z.StatusUslovnogOtpusta, z.DatumSledecegSaslusanja.ToShortDateString(), z.AdvokatImeIPrezime!, z.AdvokatDatum.ToShortDateString(), z.AdvokatPoslednjiKontakt.ToShortDateString() });
            listaZatvorenika.Items.Add(item);
        }

        listaZatvorenika.Refresh();
    }

    private async void btnIzaberi_Click(object sender, EventArgs e)
    {
        if (listaZatvorenika.SelectedItems.Count == 0)
        {
            MessageBox.Show("Morate izabrati zatvorenika za premestaj!", "Greška");
            return;
        }

        int zatvorenikId = int.Parse(listaZatvorenika.SelectedItems[0].SubItems[0].Text);
        ZatvorenikBasic? zatvorenik = await DTOManager.VratiZatvorenika(zatvorenikId);

        DTOManager.IzmeniZatvorenika(zatvorenik!, zatvorDestinacijaId);
        this.Close();
    }

}
