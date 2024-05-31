namespace Zatvor.Forme_za_Zatvorske_Jedinice;

public partial class ZatvorskeJediniceZaposleni : Form
{

    int zatvorskaJedinicaId;

    public ZatvorskeJediniceZaposleni(int zatvorskaJedinicaId)
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
        List<ZaposleniPregled> podaci = await DTOManager.VratiZaposleneZaZatvorskuJedinicu(zatvorskaJedinicaId);

        foreach (ZaposleniPregled z in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { z.JMBG, z.Ime, z.Prezime, z.DatumObuke.ToShortDateString(), z.TipZaposlenog, z.Zanimanje, z.StrucnaSprema, z.RadnoMesto, z.DatumPocetka.ToShortDateString() });
            listaZaposlenih.Items.Add(item);
        }

        listaZaposlenih.Refresh();
    }

    private void btnDodajZaposlenog_Click(object sender, EventArgs e)
    {
        ZaposleniDodaj forma = new ZaposleniDodaj(null, zatvorskaJedinicaId, true, "");
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private void btnObrisiZaposlenog_Click(object sender, EventArgs e)
    {
        if (listaZaposlenih.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zaposlenog koga želite da obrišete!", "Greška");
            return;
        }

        string idZaposlenog = listaZaposlenih.SelectedItems[0].SubItems[0].Text;
        string poruka = "Da li želite da obrišete izabranog zaposlenog?";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.ObrisiZaposlenog(idZaposlenog);
            MessageBox.Show("Zaposleni je uspešno izbrisan!", "Obaveštenje");
            this.popuniPodacima();
        }
    }

    private void btnDodajPostojecegZaposlenog_Click(object sender, EventArgs e)
    {
        ZatvorskeJediniceDodajPostojeceg forma = new ZatvorskeJediniceDodajPostojeceg(zatvorskaJedinicaId);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private async void btnIzmeniZaposlenog_Click(object sender, EventArgs e)
    {
        if (listaZaposlenih.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite zaposlenog čije podatke želite da izmenite!", "Greška");
            return;
        }

        string idZaposlenog = listaZaposlenih.SelectedItems[0].SubItems[0].Text;
        string tip = listaZaposlenih.SelectedItems[0].SubItems[4].Text;
        string radnoMesto = listaZaposlenih.SelectedItems[0].SubItems[7].Text;
        ZaposleniBasic? zaposleni = await DTOManager.VratiZaposlenog(idZaposlenog, tip, zatvorskaJedinicaId, radnoMesto);
        ZaposleniDodaj forma = new ZaposleniDodaj(zaposleni, zatvorskaJedinicaId, true, radnoMesto);
        forma.ShowDialog();
        this.popuniPodacima();
    }
}
