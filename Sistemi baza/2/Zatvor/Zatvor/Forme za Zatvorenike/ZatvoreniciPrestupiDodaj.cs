namespace Zatvor.Forme_za_Zatvorenike;

public partial class ZatvoreniciPrestupiDodaj : Form
{

    int idZatvorenika;

    public ZatvoreniciPrestupiDodaj(int idZatvorenika)
    {
        InitializeComponent();
        this.idZatvorenika = idZatvorenika;
    }

    private void ZatvoreniciPrestupiDodaj_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    public async void popuniPodacima()
    {
        listaPrestupa.Items.Clear();
        List<PrestupPregled> podaci = await DTOManager.VratiSvePrestupe();

        foreach (PrestupPregled p in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { p.Id.ToString(), p.Naziv, p.Kategorija, p.Opis, p.MinKazna, p.MaxKazna });
            listaPrestupa.Items.Add(item);
        }

        listaPrestupa.Refresh();
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtMesto.Text))
        {
            MessageBox.Show("Morate uneti mesto prestupa!", "Greška");
            return;
        }

        string mesto = txtMesto.Text;

        if (listaPrestupa.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite prestup koji želite da dodate zatvoreniku!", "Greška");
            return;
        }

        string poruka = "Da li želite da dodate novi prestup zatvoreniku?";

        string porukaUspesno = "Uspešno ste dodali novi prestup!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            int idPrestupa = Int32.Parse(listaPrestupa.SelectedItems[0].SubItems[0].Text);
            IzvrsenPrestupBasic prestupBasic = new IzvrsenPrestupBasic()
            {
                IdPrestupa = idPrestupa,
                IdZatvorenika = idZatvorenika,
                Mesto = mesto,
                Datum = dtmDatum.Value
            };
            DTOManager.DodajIzvrsenPrestup(prestupBasic);
            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }

    }
}
