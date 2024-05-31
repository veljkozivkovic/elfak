namespace Zatvor.Forme_za_Zatvorske_Jedinice;

public partial class Upravnik : Form
{

    int zatvorskaJedinicaId;
    ZaposleniPregled? upravnik;

    public Upravnik(ZaposleniPregled? upravnik, int zatvorskaJedinicaId)
    {
        InitializeComponent();
        this.zatvorskaJedinicaId = zatvorskaJedinicaId;
        this.upravnik = upravnik;
    }

    private async void popuniPodacima()
    {
        listaZaposlenih.Items.Clear();
        List<ZaposleniPregled> podaci = await DTOManager.VratiMoguceUpravnike(zatvorskaJedinicaId);

        foreach (ZaposleniPregled z in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { z.JMBG, z.Ime, z.Prezime, z.DatumObuke.ToShortDateString(), z.TipZaposlenog, z.Zanimanje, z.StrucnaSprema, z.RadnoMesto, z.DatumPocetka.ToShortDateString() });

            if (z.JMBG == upravnik?.JMBG)
                item.BackColor = Color.Gray;

            listaZaposlenih.Items.Add(item);
        }

        listaZaposlenih.Refresh();
    }

    private void popuniPolja()
    {
        dgvUpravnik.Rows.Clear();
        dgvUpravnik.Rows.Add("JMBG", upravnik!.JMBG);
        dgvUpravnik.Rows.Add("Ime", upravnik.Ime);
        dgvUpravnik.Rows.Add("Prezime", upravnik.Prezime);
        dgvUpravnik.Rows.Add("Datum PP obuke", upravnik.DatumObuke.ToShortDateString());
        dgvUpravnik.Rows.Add("Zanimanje", upravnik.Zanimanje);
        dgvUpravnik.Rows.Add("Stručna sprema", upravnik.StrucnaSprema);
        dgvUpravnik.Rows.Add("Radno mesto", upravnik.RadnoMesto);
        dgvUpravnik.Rows.Add("Datum zaposlenja", upravnik.DatumPocetka.ToShortDateString());
    }

    private void Upravnik_Load(object sender, EventArgs e)
    {
        if (this.upravnik != null)
            popuniPolja();

        popuniPodacima();
    }

    private void highlightUpravnik()
    {
        foreach (ListViewItem item in listaZaposlenih.Items)
        {
            if (item.BackColor == Color.Gray)
                item.BackColor = Color.White;

            if (item.SubItems[0].Text == upravnik?.JMBG)
            {
                item.BackColor = Color.Gray;
            }
        }
    }

    private async void btnIzaberi_Click(object sender, EventArgs e)
    {
        if (listaZaposlenih.SelectedItems.Count == 0)
        {
            MessageBox.Show("Morate izabrati upravnika iz liste!", "Greška");
            return;
        }

        string poruka = "Da li želite da promenite upravnika zatvorske jedinice?";

        string porukaUspesno = "Uspešno ste promenili upravnika zatvorske jedinice!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            string idZaposlenog = listaZaposlenih.SelectedItems[0].SubItems[0].Text;
            string tip = listaZaposlenih.SelectedItems[0].SubItems[4].Text;
            string radnoMesto = listaZaposlenih.SelectedItems[0].SubItems[7].Text;
            DTOManager.DodeliUpravnika(idZaposlenog, zatvorskaJedinicaId);
            this.upravnik = await DTOManager.VratiUpravnika(zatvorskaJedinicaId);
            popuniPolja();
            highlightUpravnik();
            MessageBox.Show(porukaUspesno, "Obaveštenje");
        }
    }

    private void listaZaposlenih_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        ListViewItem item = e.Item!;
        string jmbgUpravnika = item.SubItems[0].Text;

        if (jmbgUpravnika == upravnik?.JMBG)
            item.Selected = false;
    }

}