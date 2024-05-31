namespace Zatvor.Forme_za_OSTALO;

public partial class FirmaDodaj : Form
{
    FirmaBasic? firmaBasic;
    bool izmena;

    public FirmaDodaj(FirmaBasic? firmaBasic)
    {
        InitializeComponent();
        if (firmaBasic != null)
        {
            this.firmaBasic = firmaBasic;
            izmena = true;
            txtPIB.Enabled = false;
            popuniPolja();
        }
        else
        {
            this.firmaBasic = null;
            izmena = false;
        }
    }

    private void popuniPolja()
    {
        btnDodaj.Text = "Izmeni";
        txtPIB.Text = firmaBasic!.PIB.ToString();
        txtImeFirme.Text = firmaBasic!.Ime;
        txtAdresaFirme.Text = firmaBasic!.Adresa;
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {
        string pib = txtPIB.Text;

        if (String.IsNullOrEmpty(pib))
        {
            MessageBox.Show("Morate uneti PIB firme!", "Greška");
            return;
        }

        if (pib.Length != 8)
        {
            MessageBox.Show("PIB mora da ima 8 cifara!", "Greška");
            return;
        }

        string ime = txtImeFirme.Text;

        if (String.IsNullOrEmpty(ime))
        {
            MessageBox.Show("Morate uneti ime firme!", "Greška");
            return;
        }

        string adresa = txtAdresaFirme.Text;

        if (String.IsNullOrEmpty(adresa))
        {
            MessageBox.Show("Morate uneti adresu firme!", "Greška");
            return;
        }

        string poruka = izmena ? "Da li želite da izmenite podatke o firmi?" :
                                 "Da li želite da dodate novu firmu?";

        string porukaUspesno = izmena ? "Uspešno ste izmenili podatke o firmi!" :
                                        "Uspešno ste dodali novu firmu!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {

            this.firmaBasic = new FirmaBasic(Int32.Parse(pib), ime, adresa);

            if (izmena)
                DTOManager.IzmeniFirmu(this.firmaBasic);
            else
                DTOManager.DodajFirmu(this.firmaBasic);

            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }
    }
}