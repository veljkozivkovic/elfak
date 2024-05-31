namespace Zatvor.Forme_za_Zatvorenike;

public partial class FZatvorenici : Form
{
    public FZatvorenici()
    {
        InitializeComponent();
    }

    private async void popuniPodacima()
    {
        listaZatvorenika.Items.Clear();
        List<ZatvorenikPregled> podaci = await DTOManager.VratiSveZatvorenike();

        foreach (ZatvorenikPregled z in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { z.Id.ToString(), z.Ime, z.Prezime, z.NazivZatvorskeJedinice, z.Adresa, z.Pol.ToString(), z.StatusUslovnogOtpusta, z.DatumSledecegSaslusanja.ToShortDateString(), z.AdvokatImeIPrezime!, z.AdvokatDatum.ToShortDateString(), z.AdvokatPoslednjiKontakt.ToShortDateString() });
            listaZatvorenika.Items.Add(item);
        }

        listaZatvorenika.Refresh();
    }

    private void FZatvorenici_Load(object sender, EventArgs e)
    {
        this.popuniPodacima();
    }

    private void btnDodajZatvorenika_Click(object sender, EventArgs e)
    {
        ZatvoreniciDodaj forma = new ZatvoreniciDodaj(null);
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

    private async void btnIzmeniZatvorenika_Click(object sender, EventArgs e)
    {
        if (listaZatvorenika.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvorenika čije podatke želite da izmenite!", "Greška");
            return;
        }

        int idZatvorenika = Int32.Parse(listaZatvorenika.SelectedItems[0].SubItems[0].Text);
        ZatvorenikBasic? zatvorenik = await DTOManager.VratiZatvorenika(idZatvorenika);
        ZatvoreniciDodaj forma = new ZatvoreniciDodaj(zatvorenik);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private void btnPrestupi_Click(object sender, EventArgs e)
    {
        if (listaZatvorenika.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvorenika čije prestupe želite da vidite!", "Greška");
            return;
        }

        int idZatvorenika = Int32.Parse(listaZatvorenika.SelectedItems[0].SubItems[0].Text);
        ZatvoreniciPrestupi forma = new ZatvoreniciPrestupi(idZatvorenika);
        forma.ShowDialog();
    }

    private async void btnAngažovanja_Click(object sender, EventArgs e)
    {
        if (listaZatvorenika.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvorenika čija angažovanja želite da vidite!", "Greška");
            return;
        }

        int idZatvorenika = Int32.Parse(listaZatvorenika.SelectedItems[0].SubItems[0].Text);
        FirmaPregled? firmaPregled = await DTOManager.VratiFirmuZatvorenika(idZatvorenika);

        if (firmaPregled != null)
        {
            ZatvoreniciAngazovanje forma = new ZatvoreniciAngazovanje(idZatvorenika, firmaPregled);
            forma.ShowDialog();
        }
    }

    private void btnPosete_Click(object sender, EventArgs e)
    {
        if (listaZatvorenika.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvorenika čije posete želite da vidite!", "Greška");
            return;
        }

        int idZatvorenika = Int32.Parse(listaZatvorenika.SelectedItems[0].SubItems[0].Text);
        ZatvoreniciPosete forma = new ZatvoreniciPosete(idZatvorenika);
        forma.ShowDialog();
    }
}
