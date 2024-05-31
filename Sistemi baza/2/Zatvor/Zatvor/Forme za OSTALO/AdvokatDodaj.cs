namespace Zatvor.Forme_za_OSTALO;

public partial class AdvokatDodaj : Form
{
    AdvokatBasic? advokatBasic;
    bool izmena;

    public AdvokatDodaj(AdvokatBasic? advokatBasic)
    {
        InitializeComponent();
        if (advokatBasic != null)
        {
            this.advokatBasic = advokatBasic;
            izmena = true;
            txtJMBG.Enabled = false;
            popuniPolja();
        }
        else
        {
            this.advokatBasic = null;
            izmena = false;
        }
    }

    private void popuniPolja()
    {
        btnDodaj.Text = "Izmeni";
        txtJMBG.Text = advokatBasic!.JMBG;
        txtIme.Text = advokatBasic!.Ime;
        txtPrezime.Text = advokatBasic!.Prezime;
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {
        string jmbg = txtJMBG.Text;

        if (String.IsNullOrEmpty(jmbg))
        {
            MessageBox.Show("Morate uneti JMBG zaposlenog!", "Greška");
            return;
        }

        if (jmbg.Length != 13)
        {
            MessageBox.Show("JMBG mora da ima 13 cifara!", "Greška");
            return;
        }

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

        string poruka = izmena ? "Da li želite da izmenite podatke o advokatu?" :
                                 "Da li želite da dodate novog advokata?";

        string porukaUspesno = izmena ? "Uspešno ste izmenili podatke o advokatu!" :
                                        "Uspešno ste dodali novog advokata!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {

            this.advokatBasic = new AdvokatBasic(jmbg, ime, prezime);

            if (izmena)
                DTOManager.IzmeniAdvokata(this.advokatBasic);
            else
                DTOManager.DodajAdvokata(this.advokatBasic);

            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }
    }
}