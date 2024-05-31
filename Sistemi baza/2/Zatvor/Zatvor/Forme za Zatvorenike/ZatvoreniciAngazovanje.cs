namespace Zatvor.Forme_za_Zatvorenike;

public partial class ZatvoreniciAngazovanje : Form
{

    int zatvorenikId;
    FirmaPregled? firma;

    public ZatvoreniciAngazovanje(int zatvorenikId, FirmaPregled? firma)
    {
        InitializeComponent();
        this.zatvorenikId = zatvorenikId;
        this.firma = firma;
    }

    private async void popuniPodacima()
    {
        listaFirmi.Items.Clear();
        List<FirmaPregled> podaci = await DTOManager.VratiFirmeZaZatvorenika(zatvorenikId);

        foreach (FirmaPregled f in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { f.PIB.ToString()!, f.Ime!, f.Adresa! });

            if (f.PIB == firma?.PIB)
                item.BackColor = Color.Gray;

            listaFirmi.Items.Add(item);
        }

        listaFirmi.Refresh();
    }

    private void popuniPolja()
    {
        dgvUpravnik.Rows.Clear();
        dgvUpravnik.Rows.Add("PIB", firma!.PIB);
        dgvUpravnik.Rows.Add("Ime firme", firma!.Ime);
        dgvUpravnik.Rows.Add("Adresa firme", firma!.Adresa);
    }

    private void highlightFirma()
    {
        foreach (ListViewItem item in listaFirmi.Items)
        {
            if (item.BackColor == Color.Gray)
                item.BackColor = Color.White;

            if (item.SubItems[0].Text == firma?.PIB.ToString())
            {
                item.BackColor = Color.Gray;
            }
        }
    }

    private void Angazovanje_Load(object sender, EventArgs e)
    {
        if (this.firma != null)
            popuniPolja();
        popuniPodacima();
    }

    private void listaFirmi_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        ListViewItem item = e.Item!;
        int pibFirme = Int32.Parse(item.SubItems[0].Text);

        if (pibFirme == firma?.PIB)
            item.Selected = false;
    }


    private async void btnIzaberi_Click(object sender, EventArgs e)
    {
        if (listaFirmi.SelectedItems.Count == 0)
        {
            MessageBox.Show("Morate izabrati firmu iz liste!", "Greška");
            return;
        }

        string poruka = "Da li želite da promenite radno mesto zatvorenika?";
        string porukaUspesno = "Uspešno ste promenili radno mesto zatvorenika!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            int idFirme = Int32.Parse(listaFirmi.SelectedItems[0].SubItems[0].Text);
            DTOManager.ZaposliZatvorenika(zatvorenikId, idFirme);
            this.firma = await DTOManager.VratiFirmuZatvorenika(zatvorenikId);
            popuniPolja();
            highlightFirma();
            MessageBox.Show(porukaUspesno, "Obaveštenje");
        }
    }

    private void btnDajOtkaz_Click(object sender, EventArgs e)
    {
        string poruka = "Da li želite da date otkaz zatvoreniku?";
        string porukaUspesno = "Uspešno ste dali otkaz zatvoreniku!";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.DajOtkazZatvoreniku(zatvorenikId);
            this.firma = new FirmaPregled();
            popuniPolja();
            highlightFirma();
            MessageBox.Show(porukaUspesno, "Obaveštenje");
        }
    }
}