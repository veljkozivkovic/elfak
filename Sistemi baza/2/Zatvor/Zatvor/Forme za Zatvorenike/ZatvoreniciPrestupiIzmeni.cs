namespace Zatvor.Forme_za_Zatvorenike;

public partial class ZatvoreniciPrestupiIzmeni : Form
{

    IzvrsenPrestupBasic prestup;

    public ZatvoreniciPrestupiIzmeni(IzvrsenPrestupBasic prestup)
    {
        InitializeComponent();
        this.prestup = prestup;
    }

    private void ZatvoreniciPrestupiIzmeni_Load(object sender, EventArgs e)
    {
        popuniPolja();
    }

    public void popuniPolja()
    {
        txtMesto.Text = prestup.Mesto;
        dtmDatum.Value = prestup.Datum;
    }

    private void btnIzmeni_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtMesto.Text))
        {
            MessageBox.Show("Morate uneti mesto prestupa!", "Greška");
            return;
        }

        string poruka = "Da li želite da izmenite podatke o prestupu?";
        string porukaUspesno = "Uspešno ste izmeni podatke o prestupu!";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            prestup.Mesto = txtMesto.Text;
            prestup.Datum = dtmDatum.Value;
            DTOManager.IzmeniIzvrsenPrestup(prestup);
            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }
    }

}
