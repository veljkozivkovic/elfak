namespace Zatvor.Forme_za_Zaposlene;

public partial class ObukeDodaj : Form
{
    string zaposleniJMBG;
    ObukaVatrenoOruzjeBasic? obuka;
    bool izmena;

    public ObukeDodaj(string zaposleniJMBG, ObukaVatrenoOruzjeBasic? obuka)
    {
        InitializeComponent();
        this.zaposleniJMBG = zaposleniJMBG;
        if (obuka != null)
        {
            this.obuka = obuka;
            izmena = true;
            popuniPolja();
        }
        else
        {
            this.obuka = null;
            izmena = false;
        }
    }

    private void popuniPolja()
    {
        btnDodaj.Text = "Izmeni";
        txtPolicijskaUprava.Text = obuka!.PolicijskaUprava;
        dtmIzdavanja.Value = obuka!.DatumIzdavanja;
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtPolicijskaUprava.Text))
        {
            MessageBox.Show("Morate uneti naziv policijske uprave!", "Greška");
            return;
        }

        string policijskaUprava = txtPolicijskaUprava.Text;

        string poruka = izmena ? "Da li želite da izmenite podatke o obuci?" :
                                "Da li želite da dodate novu obuku?";

        string porukaUspesno = izmena ? "Uspešno ste izmenili podatke o obuci" :
                                        "Uspešno ste dodali novu obuku!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            int id = obuka != null ? obuka!.Id : 0;

            this.obuka = new ObukaVatrenoOruzjeBasic();
            this.obuka.Id = id;
            this.obuka.PolicijskaUprava = policijskaUprava;
            this.obuka.DatumIzdavanja = dtmIzdavanja.Value;

            if (izmena)
                DTOManager.IzmeniObuku(this.obuka);
            else
                DTOManager.DodajObuku(this.obuka, zaposleniJMBG);

            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }

    }
}