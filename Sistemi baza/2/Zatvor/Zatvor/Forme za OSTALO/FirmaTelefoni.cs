namespace Zatvor.Forme_za_OSTALO;

public partial class FirmaTelefoni : Form
{

    int firmaPIB;
    FirmaTelefonBasic? telefonBasic;

    public FirmaTelefoni(int firmaPIB)
    {
        InitializeComponent();
        this.firmaPIB = firmaPIB;
    }

    private void FirmaTelefoni_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    public async void popuniPodacima()
    {
        listaTelefona.Items.Clear();
        List<FirmaTelefonPregled> podaci = await DTOManager.VratiTelefoneZaFirmu(firmaPIB);

        foreach (FirmaTelefonPregled t in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { t.Id.ToString(), t.BrojTelefona });
            listaTelefona.Items.Add(item);
        }

        listaTelefona.Refresh();
    }

    private void btnDodajTelefon_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtTelefon.Text))
        {
            MessageBox.Show("Morate uneti broj telefona!", "Greška");
            return;
        }

        string telefon = txtTelefon.Text;

        string poruka = "Da li želite da dodate novi telefon?";
        string porukaUspesno = "Uspešno ste dodali novi telefon!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            this.telefonBasic = new FirmaTelefonBasic()
            {
                BrojTelefona = telefon
            };

            DTOManager.DodajTelefon(telefonBasic, firmaPIB);
            MessageBox.Show(porukaUspesno, "Obaveštenje");
            popuniPodacima();
        }

    }

    private void btnIzmeni_Click(object sender, EventArgs e)
    {
        if (listaTelefona.SelectedItems.Count == 0)
        {
            MessageBox.Show("Morate izabrati broj telefona koji želite da promenite!", "Greška");
            return;
        }

        string telefon = txtTelefon.Text;

        string poruka = "Da li želite da izmenite izabrani telefon?";
        string porukaUspesno = "Uspešno ste izmenili izabrani telefon!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            int idTelefona = Int32.Parse(listaTelefona.SelectedItems[0].SubItems[0].Text);
            this.telefonBasic = new FirmaTelefonBasic()
            {
                Id = idTelefona,
                BrojTelefona = telefon
            };

            DTOManager.IzmeniTelefon(telefonBasic);
            MessageBox.Show(porukaUspesno, "Obaveštenje");
            popuniPodacima();
        }
    }

    private void btnObrisi_Click(object sender, EventArgs e)
    {
        if (listaTelefona.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite broj telefona koji želite da obrišete!", "Greška");
            return;
        }

        int idTelefona = Int32.Parse(listaTelefona.SelectedItems[0].SubItems[0].Text);
        string poruka = "Da li želite da obrišete izabrani broj telefona?";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.ObrisiTelefon(idTelefona);
            MessageBox.Show("Broj telefona je uspešno izbrisan!", "Obaveštenje");
            this.popuniPodacima();
        }
    }

    private void listaTelefona_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
            txtTelefon.Text = e.Item?.SubItems[1].Text;
    }

}
