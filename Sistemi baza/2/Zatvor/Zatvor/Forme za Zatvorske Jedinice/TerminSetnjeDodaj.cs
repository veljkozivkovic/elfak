namespace Zatvor.Forme_za_Zatvorske_Jedinice;

public partial class TerminSetnjeDodaj : Form
{

    TerminSetnjeBasic terminSetnje;
    int idZatvorskeJedinice;
    bool izmena;

    public TerminSetnjeDodaj(TerminSetnjeBasic? termin, int idZatvorskeJedinice)
    {
        InitializeComponent();
        if (termin != null)
        {
            this.terminSetnje = termin;
            izmena = true;
            popuniPolja();
        }
        else
        {
            this.terminSetnje = new TerminSetnjeBasic();
            izmena = false;
        }

        this.idZatvorskeJedinice = idZatvorskeJedinice;
    }

    public void popuniPolja()
    {
        btnDodaj.Text = "Izmeni";
        txtTerminOd.Text = terminSetnje.TerminOd;
        txtTerminDo.Text = terminSetnje.TerminDo;
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {

        string terminOd = txtTerminOd.Text;

        if (String.IsNullOrEmpty(terminOd))
        {
            MessageBox.Show("Morate uneti vreme početka termina!", "Greška");
            return;
        }

        if (txtTerminOd.Text.Length != 5 || txtTerminOd.Text[2] != ':')
        {
            MessageBox.Show("Početak termina mora biti u formatu HH:mm!", "Greška");
            return;
        }

        string terminDo = txtTerminDo.Text;

        if (String.IsNullOrEmpty(terminDo))
        {
            MessageBox.Show("Morate uneti vreme kraja termina!", "Greška");
            return;
        }

        if (txtTerminDo.Text.Length != 5 || txtTerminDo.Text[2] != ':')
        {
            MessageBox.Show("Kraj termina mora biti u formatu HH:mm!", "Greška");
            return;
        }

        string poruka = izmena ? "Da li želite da izmenite termin?" :
                                 "Da li želite da dodate novi termin?";

        string porukaUspesno = izmena ? "Uspešno ste izmenili termin!" :
                                        "Uspešno ste dodali novi termin!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            this.terminSetnje.TerminOd = terminOd;
            this.terminSetnje.TerminDo = terminDo;

            if (izmena)
                DTOManager.IzmeniTerminSetnje(this.terminSetnje);
            else
                DTOManager.DodajTerminSetnje(this.terminSetnje, idZatvorskeJedinice);

            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }
    }
}