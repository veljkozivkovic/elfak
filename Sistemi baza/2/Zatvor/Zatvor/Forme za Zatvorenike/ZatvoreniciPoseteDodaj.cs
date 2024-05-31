namespace Zatvor.Forme_za_Zatvorenike;

public partial class ZatvoreniciPoseteDodaj : Form
{
    PosetaBasic? poseta;
    int idZatvorenika;
    bool izmena;

    public ZatvoreniciPoseteDodaj(PosetaBasic? poseta, int idZatvorenika)
    {
        InitializeComponent();
        this.idZatvorenika = idZatvorenika;
        if (poseta != null)
        {
            this.poseta = poseta;
            izmena = true;
            popuniPolja();
        }
        else
        {
            this.poseta = null;
            izmena = false;
        }
    }

    private void popuniPolja()
    {
        btnDodaj.Text = "Izmeni";
        txtVremeOd.Text = poseta!.VremeOd;
        txtVremeDo.Text = poseta!.VremeDo;
        dtmDatum.Value = poseta!.Datum;
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {

        if (String.IsNullOrEmpty(txtVremeOd.Text))
        {
            MessageBox.Show("Morate uneti vreme početka posete!", "Greška");
            return;
        }

        if (txtVremeOd.Text.Length != 5 || txtVremeOd.Text[2] != ':')
        {
            MessageBox.Show("Vreme početka posete mora biti u formatu HH:mm!", "Greška");
            return;
        }

        string vremeOd = txtVremeOd.Text;

        if (String.IsNullOrEmpty(txtVremeDo.Text))
        {
            MessageBox.Show("Morate uneti vreme kraja posete!", "Greška");
            return;
        }

        if (txtVremeDo.Text.Length != 5 || txtVremeDo.Text[2] != ':')
        {
            MessageBox.Show("Vreme kraja posete mora biti u formatu HH:mm!", "Greška");
            return;
        }

        string vremeDo = txtVremeDo.Text;

        string poruka = izmena ? "Da li želite da izmenite posetu?" :
                                 "Da li želite da dodate novu posetu?";

        string porukaUspesno = izmena ? "Uspešno ste izmenili posetu!" :
                                        "Uspešno ste dodali novu posetu!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            int id = poseta != null ? poseta!.Id : 0;
            this.poseta = new PosetaBasic()
            {
                Id = id,
                ZatvorenikId = idZatvorenika,
                VremeOd = vremeOd,
                VremeDo = vremeDo,
                Datum = dtmDatum.Value
            };

            if (izmena)
                DTOManager.IzmeniPosetu(this.poseta);
            else
                DTOManager.DodajPosetu(this.poseta);

            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }
    }
}