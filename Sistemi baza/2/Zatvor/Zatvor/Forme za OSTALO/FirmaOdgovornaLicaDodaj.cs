namespace Zatvor.Forme_za_OSTALO;

public partial class FirmaOdgovornaLicaDodaj : Form
{
    OdgovornoLiceBasic? odgovornoLiceBasic;
    int firmaPIB;
    bool izmena;

    public FirmaOdgovornaLicaDodaj(OdgovornoLiceBasic? odgovornoLiceBasic, int firmaPIB)
    {
        InitializeComponent();
        if (odgovornoLiceBasic != null)
        {
            this.odgovornoLiceBasic = odgovornoLiceBasic;
            izmena = true;
            popuniPolja();
        }
        else
        {
            this.odgovornoLiceBasic = null;
            izmena = false;
        }

        this.firmaPIB = firmaPIB;
    }

    private void popuniPolja()
    {
        btnDodaj.Text = "Izmeni";
        txtIme.Text = odgovornoLiceBasic!.Ime;
        txtPrezime.Text = odgovornoLiceBasic!.Prezime;
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {
        string ime = txtIme.Text;

        if (String.IsNullOrEmpty(ime))
        {
            MessageBox.Show("Morate uneti ime zaposlenog!", "Greška");
            return;
        }

        string prezime = txtPrezime.Text;

        if (String.IsNullOrEmpty(prezime))
        {
            MessageBox.Show("Morate uneti prezime zaposlenog!", "Greška");
            return;
        }

        string poruka = izmena ? "Da li želite da izmenite podatke o odgovornom licu?" :
                                 "Da li želite da dodate novo odgovorno lice?";

        string porukaUspesno = izmena ? "Uspešno ste izmenili podatke o odgovornom licu!" :
                                        "Uspešno ste dodali novo odgovorno lice!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            int id = izmena ? odgovornoLiceBasic!.Id : 0;
            this.odgovornoLiceBasic = new OdgovornoLiceBasic(id, ime, prezime);

            if (izmena)
                DTOManager.IzmeniOdgovornoLice(this.odgovornoLiceBasic);
            else
                DTOManager.DodajOdgovornoLice(this.odgovornoLiceBasic, firmaPIB);

            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }
    }
}