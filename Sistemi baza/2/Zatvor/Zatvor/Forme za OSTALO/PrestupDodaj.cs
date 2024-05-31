namespace Zatvor.Forme_za_OSTALO;

public partial class PrestupDodaj : Form
{
    PrestupBasic? prestupBasic;
    bool izmena;


    public PrestupDodaj(PrestupBasic? prestupBasic)
    {
        InitializeComponent();

        if (prestupBasic != null)
        {
            this.prestupBasic = prestupBasic;
            izmena = true;
            popuniPolja();
        }
        else
        {
            this.prestupBasic = null;
            izmena = false;
        }
    }

    private void popuniPolja()
    {
        btnDodaj.Text = "Izmeni";
        txtNaziv.Text = prestupBasic!.Naziv;
        txtKategorija.Text = prestupBasic!.Kategorija;
        txtOpis.Text = prestupBasic!.Opis;
        txtMinKazna.Text = prestupBasic!.MinKazna;
        txtMaxKazna.Text = prestupBasic!.MaxKazna;
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {

        if (String.IsNullOrEmpty(txtNaziv.Text))
        {
            MessageBox.Show("Morate uneti naziv prestupa!", "Greška");
            return;
        }

        string naziv = txtNaziv.Text;

        if (String.IsNullOrEmpty(txtKategorija.Text))
        {
            MessageBox.Show("Morate uneti kategoriju prestupa!", "Greška");
            return;
        }

        string kategorija = txtKategorija.Text;

        if (String.IsNullOrEmpty(txtOpis.Text))
        {
            MessageBox.Show("Morate uneti opis prestupa!", "Greška");
            return;
        }

        string opis = txtOpis.Text;

        if (String.IsNullOrEmpty(txtMinKazna.Text))
        {
            MessageBox.Show("Morate uneti minimalnu kaznu za prestup!", "Greška");
            return;
        }

        string minKazna = txtMinKazna.Text;

        if (String.IsNullOrEmpty(txtMaxKazna.Text))
        {
            MessageBox.Show("Morate uneti maksimalnu kaznu za prestup!", "Greška");
            return;
        }

        string maxKazna = txtMaxKazna.Text;

        string poruka = izmena ? "Da li želite da izmenite podatke o prestupu?" :
                                 "Da li želite da dodate novi prestup?";

        string porukaUspesno = izmena ? "Uspešno ste izmenili podatke o prestupu!" :
                                        "Uspešno ste dodali novi prestup!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            int id = izmena ? prestupBasic!.Id : 0;

            this.prestupBasic = new PrestupBasic(id, naziv, kategorija, opis, minKazna, maxKazna);

            if (izmena)
                DTOManager.IzmeniPrestup(this.prestupBasic);
            else
                DTOManager.DodajPrestup(this.prestupBasic!);

            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }
    }

}