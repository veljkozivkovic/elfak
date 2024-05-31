namespace Zatvor.Forme_za_Zatvorske_Jedinice;

public partial class ZatvorskeJediniceDodaj : Form
{
    ZatvorskaJedinicaBasic? zatvorskaJedinica;
    bool izmena;

    public ZatvorskeJediniceDodaj(ZatvorskaJedinicaBasic? zatvorskaJedinica)
    {
        InitializeComponent();
        if (zatvorskaJedinica != null)
        {
            this.zatvorskaJedinica = zatvorskaJedinica;
            izmena = true;
            popuniPolja();
        }
        else
        {
            this.zatvorskaJedinica = null;
            izmena = false;
        }
    }

    private void prikaziPoljaZaZabranu()
    {
        if (cbxTip.SelectedItem != null)
        {
            string? selectedItem = cbxTip.SelectedItem.ToString();

            if (selectedItem != "Zatvorena")
            {
                lblPeriodZabraneOd.Visible = true;
                lblPeriodZabraneDo.Visible = true;
                txtPeriodZabraneOd.Visible = true;
                txtPeriodZabraneDo.Visible = true;
            }
            else
            {
                lblPeriodZabraneOd.Visible = false;
                lblPeriodZabraneDo.Visible = false;
                txtPeriodZabraneOd.Visible = false;
                txtPeriodZabraneDo.Visible = false;
            }
        }
    }

    private void popuniPolja()
    {
        btnDodaj.Text = "Izmeni";
        cbxTip.Enabled = false;
        txtNaziv.Text = zatvorskaJedinica!.Naziv;
        txtAdresa.Text = zatvorskaJedinica!.Adresa;
        numKapacitet.Value = zatvorskaJedinica!.Kapacitet;
        cbxTip.SelectedItem = zatvorskaJedinica!.ToString();
        prikaziPoljaZaZabranu();

        if (zatvorskaJedinica is ZatvorZabranaInterface zInterface)
        {
            txtPeriodZabraneOd.Text = zInterface.PeriodZabraneOd;
            txtPeriodZabraneDo.Text = zInterface.PeriodZabraneDo;
        }
    }

    private void kreirajZatvorskuJedinicu(int id, string naziv, string adresa, int kapacitet, string tip, string periodZabraneOd, string periodZabraneDo)
    {
        if (tip == "Otvorena")
        {
            zatvorskaJedinica = new OtvorenaZatvorskaJedinicaBasic(id, naziv, kapacitet, adresa, periodZabraneOd, periodZabraneDo);
        }
        else if (tip == "Poluotvorena")
        {
            zatvorskaJedinica = new PoluotvorenaZatvorskaJedinicaBasic(id, naziv, kapacitet, adresa, periodZabraneOd, periodZabraneDo);
        }
        else if (tip == "Zatvorena")
        {
            zatvorskaJedinica = new ZatvorenaZatvorskaJedinicaBasic(id, naziv, kapacitet, adresa);
        }
        else if (tip == "Otvorena-Poluotvorena")
        {
            zatvorskaJedinica = new OPZatvorskaJedinicaBasic(id, naziv, kapacitet, adresa, periodZabraneOd, periodZabraneDo);
        }
        else if (tip == "Otvorena-Zatvorena")
        {
            zatvorskaJedinica = new OZZatvorskaJedinicaBasic(id, naziv, kapacitet, adresa, periodZabraneOd, periodZabraneDo);
        }
        else if (tip == "Poluotvorena-Zatvorena")
        {
            zatvorskaJedinica = new PZZatvorskaJedinicaBasic(id, naziv, kapacitet, adresa, periodZabraneOd, periodZabraneDo);
        }
    }

    private void cbxTip_SelectedValueChanged(object sender, EventArgs e)
    {
        prikaziPoljaZaZabranu();
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {
        string naziv = txtNaziv.Text;

        if (String.IsNullOrEmpty(naziv))
        {
            MessageBox.Show("Morate uneti naziv zatvorske jedinice!", "Greška");
            return;
        }

        string adresa = txtAdresa.Text;

        if (String.IsNullOrEmpty(adresa))
        {
            MessageBox.Show("Morate uneti adresu zatvorske jedinice!", "Greška");
            return;
        }

        int kapacitet = Convert.ToInt32(numKapacitet.Value);

        if (kapacitet == 0)
        {
            MessageBox.Show("Morate uneti kapacitet zatvorske jedinice veći od 0!", "Greška");
            return;
        }

        if (cbxTip.SelectedItem == null)
        {

            MessageBox.Show("Morate izabrati tip zatvorske jedinice!", "Greška");
            return;
        }

        string? tip = cbxTip.SelectedItem!.ToString();

        string periodZabraneOd = "";
        string periodZabraneDo = "";

        if (tip != "Zatvorena")
        {
            if (String.IsNullOrEmpty(txtPeriodZabraneOd.Text))
            {
                MessageBox.Show("Morate uneti od kada važi period zabrane!", "Greška");
                return;
            }

            if (txtPeriodZabraneOd.Text.Length != 5 || txtPeriodZabraneOd.Text[2] != ':')
            {
                MessageBox.Show("Početak perioda zabrane mora biti u formatu HH:mm!", "Greška");
                return;
            }

            if (String.IsNullOrEmpty(txtPeriodZabraneDo.Text))
            {
                MessageBox.Show("Morate uneti do kada važi period zabrane!", "Greška");
                return;
            }

            if (txtPeriodZabraneDo.Text.Length != 5 || txtPeriodZabraneDo.Text[2] != ':')
            {
                MessageBox.Show("Kraj perioda zabrane mora biti u formatu HH:mm!", "Greška");
                return;
            }

            periodZabraneOd = txtPeriodZabraneOd.Text;
            periodZabraneDo = txtPeriodZabraneDo.Text;

        }

        string poruka = izmena ? "Da li želite da izmenite zatvorsku jedinicu?" :
                                 "Da li želite da dodate novu zatvorsku jedinicu?";

        string porukaUspesno = izmena ? "Uspešno ste izmenili zatvorsku jedinicu!" :
                                        "Uspešno ste dodali novu zatvorsku jedinicu!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            int id = zatvorskaJedinica != null ? zatvorskaJedinica!.Id : 0;
            kreirajZatvorskuJedinicu(id, naziv, adresa, kapacitet, tip, periodZabraneOd, periodZabraneDo);

            if (izmena)
                DTOManager.IzmeniZatvorskuJedinicu(this.zatvorskaJedinica);
            else
                DTOManager.DodajZatvorskuJedinicu(this.zatvorskaJedinica);

            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }
    }
}