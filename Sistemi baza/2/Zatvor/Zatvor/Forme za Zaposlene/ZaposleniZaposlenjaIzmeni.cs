namespace Zatvor.Forme_za_Zaposlene;

public partial class ZaposleniZaposlenjaIzmeni : Form
{
    string zatvorskaJedinicaNaziv;
    string zaposleniJMBG;
    string radnoMesto;
    DateTime datumZaposlenja;

    public ZaposleniZaposlenjaIzmeni(string zatvorskaJedinicaNaziv, string zaposleniJMBG, string radnoMesto, DateTime datumZaposlenja)
    {
        InitializeComponent();
        this.zatvorskaJedinicaNaziv = zatvorskaJedinicaNaziv;
        this.zaposleniJMBG = zaposleniJMBG;
        this.radnoMesto = radnoMesto;
        this.datumZaposlenja = datumZaposlenja;
    }

    private void ZaposleniZaposlenjaIzmeni_Load(object sender, EventArgs e)
    {
        popuniPolja();
    }

    private void popuniPolja()
    {
        txtRadnoMesto.Text = radnoMesto;
        dtmZaposlenja.Value = datumZaposlenja;
    }

    private void btnIzmeni_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtRadnoMesto.Text))
        {
            MessageBox.Show("Morate uneti radno mesto zaposlenog!", "Greška");
            return;
        }

        string radnoMesto = txtRadnoMesto.Text;
        DateTime datumZaposlenja = dtmZaposlenja.Value;

        string poruka = "Da li želite da izmenite podatke o radnom mestu?";
        string porukaUspesno = "Uspešno ste promenili podatke o radnom mestu!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.IzmeniRadnoMesto(zaposleniJMBG, zatvorskaJedinicaNaziv, this.radnoMesto, radnoMesto, datumZaposlenja);
            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }

    }
}