namespace Zatvor.Forme_za_Zatvorske_Jedinice;

public partial class ZatvorskeJediniceMain : Form
{
    public ZatvorskeJediniceMain()
    {
        InitializeComponent();
    }

    private void ZatvorskeJediniceMain_Load(object sender, EventArgs e)
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

    private void btnDodajZatvor_Click(object sender, EventArgs e)
    {
        ZatvorskeJediniceDodaj forma = new ZatvorskeJediniceDodaj(null);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private void btnZaposleni_Click(object sender, EventArgs e)
    {
        if (listaZatvora.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvor čije zaposlene želite da vidite!", "Greška");
            return;
        }

        int idZatvora = Int32.Parse(listaZatvora.SelectedItems[0].SubItems[0].Text);
        ZatvorskeJediniceZaposleni forma = new ZatvorskeJediniceZaposleni(idZatvora);
        forma.ShowDialog();
    }

    private async void btnIzmeniZatvor_Click(object sender, EventArgs e)
    {
        if (listaZatvora.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvor čije podatke želite da izmenite!", "Greška");
            return;
        }

        int idZatvora = Int32.Parse(listaZatvora.SelectedItems[0].SubItems[0].Text);
        string tip = listaZatvora.SelectedItems[0].SubItems[4].Text;
        ZatvorskaJedinicaBasic? zatvorskaJedinica = await DTOManager.VratiZatvorskuJedinicu(idZatvora, tip);
        ZatvorskeJediniceDodaj forma = new ZatvorskeJediniceDodaj(zatvorskaJedinica);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private void btnZatvorenici_Click(object sender, EventArgs e)
    {
        if (listaZatvora.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvor čije zatvorenike želite da vidite!", "Greška");
            return;
        }

        int idZatvora = Int32.Parse(listaZatvora.SelectedItems[0].SubItems[0].Text);
        ZatvorskeJediniceZatvorenici forma = new ZatvorskeJediniceZatvorenici(idZatvora);
        forma.ShowDialog();
    }

    private void btnObrisiZatvor_Click(object sender, EventArgs e)
    {
        if (listaZatvora.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvor koji želite da obrišete!", "Greška");
            return;
        }

        int idZatvora = Int32.Parse(listaZatvora.SelectedItems[0].SubItems[0].Text);
        string poruka = "Da li želite da obrišete izabran zatvor?";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.ObrisiZatvor(idZatvora);
            MessageBox.Show("Zatvor je uspešno izbrisan!", "Obaveštenje");
            this.popuniPodacima();
        }

    }

    private async void btnTerminPosete_Click(object sender, EventArgs e)
    {
        if (listaZatvora.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvor čije termine želite da vidite!", "Greška");
            return;
        }

        int idZatvora = Int32.Parse(listaZatvora.SelectedItems[0].SubItems[0].Text);
        string tip = listaZatvora.SelectedItems[0].SubItems[4].Text;

        if (!tip.Contains("Zatvorena"))
        {
            MessageBox.Show("Samo zatvorene zatvorske jedinice imaju termine za posete!", "Greška");
            return;
        }

        ZatvorskaJedinicaBasic? zatvorskaJedinica = await DTOManager.VratiZatvorskuJedinicu(idZatvora, tip);
        TerminiPosete forma = new TerminiPosete(zatvorskaJedinica!);
        forma.ShowDialog();

    }

    private async void btnTerminiSetnje_Click(object sender, EventArgs e)
    {
        if (listaZatvora.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvor čije termine želite da vidite!", "Greška");
            return;
        }

        int idZatvora = Int32.Parse(listaZatvora.SelectedItems[0].SubItems[0].Text);
        string tip = listaZatvora.SelectedItems[0].SubItems[4].Text;

        if (!tip.Contains("Zatvorena"))
        {
            MessageBox.Show("Samo zatvorene zatvorske jedinice imaju termine za šetnju!", "Greška");
            return;
        }

        ZatvorskaJedinicaBasic? zatvorskaJedinica = await DTOManager.VratiZatvorskuJedinicu(idZatvora, tip);
        TerminiSetnje forma = new TerminiSetnje(zatvorskaJedinica!);
        forma.ShowDialog();
    }

    private async void btnUpravnik_Click(object sender, EventArgs e)
    {
        if (listaZatvora.SelectedItems.Count == 0)
        {
            MessageBox.Show("Morate izabrati zatvorsku jedinicu iz liste!", "Greška");
            return;
        }

        int idZatvora = Int32.Parse(listaZatvora.SelectedItems[0].SubItems[0].Text);
        ZaposleniPregled? zaposleni = await DTOManager.VratiUpravnika(idZatvora);
        Upravnik forma = new Upravnik(zaposleni, idZatvora);
        forma.ShowDialog();
    }

    private void btnFirme_Click(object sender, EventArgs e)
    {
        if (listaZatvora.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zatvor čije saradnje želite da vidite!", "Greška");
            return;
        }

        int idZatvora = Int32.Parse(listaZatvora.SelectedItems[0].SubItems[0].Text);
        string tipZatvora = listaZatvora.SelectedItems[0].SubItems[4].Text;

        if (!tipZatvora.Contains("Otvorena"))
        {
            MessageBox.Show("Samo otvorene zatvorske jedinice imaju saradnje sa firmama!", "Greška");
            return;
        }

        ZatvorskeJediniceFirme forma = new ZatvorskeJediniceFirme(idZatvora);
        forma.ShowDialog();
    }
}