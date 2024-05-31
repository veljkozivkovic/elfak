namespace Zatvor.Forme_za_Zatvorske_Jedinice;

public partial class ZatvorskeJediniceZatvorenici : Form
{

    int zatvorskaJedinicaId;

    public ZatvorskeJediniceZatvorenici(int zatvorskaJedinicaId)
    {
        InitializeComponent();
        this.zatvorskaJedinicaId = zatvorskaJedinicaId;
    }

    private void ZatvorskeJediniceZatvorenici_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    public async void popuniPodacima()
    {
        listaZatvorenika.Items.Clear();
        List<ZatvorenikPregled> podaci = await DTOManager.VratiZatvorenikeZaZatvorskuJedinicu(zatvorskaJedinicaId);

        foreach (ZatvorenikPregled z in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { z.Id.ToString(), z.Ime, z.Prezime, z.Adresa, z.Pol.ToString(), z.StatusUslovnogOtpusta, z.DatumSledecegSaslusanja.ToShortDateString(), z.AdvokatImeIPrezime!, z.AdvokatDatum.ToShortDateString(), z.AdvokatPoslednjiKontakt.ToShortDateString() });
            listaZatvorenika.Items.Add(item);

        }

        listaZatvorenika.Refresh();
    }
    private void btnDodajZatvorenika_Click(object sender, EventArgs e)
    {
        ZatvorskeJediniceDodajZatvorenika forma = new ZatvorskeJediniceDodajZatvorenika(null, zatvorskaJedinicaId);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private async void btnIzmeniZatvorenika_Click(object sender, EventArgs e)
    {
        if (listaZatvorenika.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvorenika čije podatke želite da izmenite!", "Greška");
            return;
        }

        int idZatvorenika = Int32.Parse(listaZatvorenika.SelectedItems[0].SubItems[0].Text);
        ZatvorenikBasic? zatvorenik = await DTOManager.VratiZatvorenika(idZatvorenika);
        ZatvorskeJediniceDodajZatvorenika forma = new ZatvorskeJediniceDodajZatvorenika(zatvorenik, zatvorskaJedinicaId);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private void btnObrisiZatvorenika_Click(object sender, EventArgs e)
    {
        if (listaZatvorenika.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvorenika koga želite da obrišete!", "Greška");
            return;
        }

        int idZatvorenika = Int32.Parse(listaZatvorenika.SelectedItems[0].SubItems[0].Text);
        string poruka = "Da li želite da obrišete izabranog zatvorenika?";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.ObrisiZatvorenika(idZatvorenika);
            MessageBox.Show("Zatvorenik je uspešno izbrisan!", "Obaveštenje");
            this.popuniPodacima();
        }
    }

    private void btnPremestajDodaj_Click(object sender, EventArgs e)
    {
        PremestajIzvoriste forma = new PremestajIzvoriste(zatvorskaJedinicaId);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private async void btnPremestajPremesti_Click(object sender, EventArgs e)
    {
        if (listaZatvorenika.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvorenika koga želite da premestite!", "Greška");
            return;
        }

        int idZatvorenika = Int32.Parse(listaZatvorenika.SelectedItems[0].SubItems[0].Text);
        ZatvorenikBasic? zatvorenik = await DTOManager.VratiZatvorenika(idZatvorenika);

        PremestajOdrediste forma = new PremestajOdrediste(zatvorenik, zatvorskaJedinicaId);
        forma.ShowDialog();
        this.popuniPodacima();
    }
}
