namespace Zatvor.Forme_za_Zatvorske_Jedinice;

public partial class TerminPoseteDodaj : Form
{

    TerminPoseteBasic terminPosete;
    int idZatvorskeJedinice;
    bool izmena;

    public TerminPoseteDodaj(TerminPoseteBasic? termin, int idZatvorskeJedinice)
    {
        InitializeComponent();
        if (termin != null)
        {
            this.terminPosete = termin;
            izmena = true;
            popuniPolja();
        }
        else
        {
            this.terminPosete = new TerminPoseteBasic();
            izmena = false;
        }

        this.idZatvorskeJedinice = idZatvorskeJedinice;
    }

    public void popuniPolja()
    {
        btnDodaj.Text = "Izmeni";
        cbxDan.SelectedItem = terminPosete.Dan;
        txtTerminOd.Text = terminPosete.TerminOd;
        txtTerminDo.Text = terminPosete.TerminDo;
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {
        if (cbxDan.SelectedItem == null)
        {

            MessageBox.Show("Morate izabrati dan za termin!", "Greška");
            return;
        }

        string? dan = cbxDan.SelectedItem.ToString();

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

            this.terminPosete.Dan = dan;
            this.terminPosete.TerminOd = terminOd;
            this.terminPosete.TerminDo = terminDo;

            if (izmena)
                DTOManager.IzmeniTerminPosete(this.terminPosete);
            else
                DTOManager.DodajTerminPosete(this.terminPosete, idZatvorskeJedinice);

            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }
    }
}