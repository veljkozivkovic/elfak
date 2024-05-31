namespace Zatvor.Forme_za_Zaposlene;

public partial class LekarskiPregledDodaj : Form
{
    string zaposleniJMBG;
    LekarskiPregledBasic? lekarskiPregled;
    bool izmena;

    public LekarskiPregledDodaj(string zaposleniJMBG, LekarskiPregledBasic? lekarskiPregled)
    {
        InitializeComponent();
        this.zaposleniJMBG = zaposleniJMBG;
        if (lekarskiPregled != null)
        {
            this.lekarskiPregled = lekarskiPregled;
            izmena = true;
            popuniPolja();
        }
        else
        {
            this.lekarskiPregled = null;
            izmena = false;
        }
    }

    private void popuniPolja()
    {
        btnDodaj.Text = "Izmeni";
        txtNazivUstanove.Text = lekarskiPregled!.NazivUstanove;
        txtAdresaUstanove.Text = lekarskiPregled!.AdresaUstanove;
        txtLekar.Text = lekarskiPregled!.Lekar;
        dtmPregleda.Value = lekarskiPregled!.Datum;
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtNazivUstanove.Text))
        {
            MessageBox.Show("Morate uneti naziv ustanove!", "Greška");
            return;
        }

        string nazivUstanove = txtNazivUstanove.Text;

        if (String.IsNullOrEmpty(txtAdresaUstanove.Text))
        {
            MessageBox.Show("Morate uneti adresu ustanove!", "Greška");
            return;
        }

        string adresaUstanove = txtAdresaUstanove.Text;

        if (String.IsNullOrEmpty(txtLekar.Text))
        {
            MessageBox.Show("Morate uneti ime i prezime lekara!", "Greška");
            return;
        }

        string lekar = txtLekar.Text;

        string poruka = izmena ? "Da li želite da izmenite podatke o lekarskom pregledu?" :
                                "Da li želite da dodate novi lekarski pregled?";

        string porukaUspesno = izmena ? "Uspešno ste izmenili podatke o lekarskom pregledu!" :
                                        "Uspešno ste dodali novi lekarski pregled!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            int id = lekarskiPregled != null ? lekarskiPregled!.Id : 0;

            this.lekarskiPregled = new LekarskiPregledBasic();
            this.lekarskiPregled.Id = id;
            this.lekarskiPregled.NazivUstanove = nazivUstanove;
            this.lekarskiPregled.AdresaUstanove = adresaUstanove;
            this.lekarskiPregled.Lekar = lekar;
            this.lekarskiPregled.Datum = dtmPregleda.Value;

            if (izmena)
                DTOManager.IzmeniLekarskiPregled(this.lekarskiPregled);
            else
                DTOManager.DodajLekarskiPregled(this.lekarskiPregled, zaposleniJMBG);

            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }

    }
}