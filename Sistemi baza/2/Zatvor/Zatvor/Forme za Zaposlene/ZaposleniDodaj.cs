namespace Zatvor.Forme_za_Zaposlene;

public partial class ZaposleniDodaj : Form
{
    ZaposleniBasic? zaposleniBasic;
    int zatvorskaJedinicaId;
    bool izmena;
    bool radiUPodaci;
    string staroRadnoMesto;

    public ZaposleniDodaj(ZaposleniBasic? zaposleniBasic, int zatvorskaJedinicaId, bool radiUPodaci, string staroRadnoMesto)
    {
        InitializeComponent();
        this.zatvorskaJedinicaId = zatvorskaJedinicaId;
        this.radiUPodaci = radiUPodaci;
        this.staroRadnoMesto = staroRadnoMesto;
        if (!radiUPodaci)
        {
            lblRadnoMesto.Visible = false;
            txtRadnoMesto.Visible = false;
            lblDatumPocetka.Visible = false;
            dtmZaposlenja.Visible = false;

            Size size = new Size(461, 625);

            this.Size = size;
            this.MaximumSize = size;
            this.MinimumSize = size;
            btnDodaj.Location = new Point(253, 480);
            gbxPodaci.Size = new Size(415, 545);
        }

        if (zaposleniBasic != null)
        {
            this.zaposleniBasic = zaposleniBasic;
            izmena = true;
            txtJMBG.Enabled = false;
            popuniPolja();
        }
        else
        {
            this.zaposleniBasic = null;
            izmena = false;
        }
    }

    private void popuniPolja()
    {
        btnDodaj.Text = "Izmeni";
        cbxTip.Enabled = false;
        cbxPodtip.Enabled = false;
        txtJMBG.Text = zaposleniBasic!.JMBG;
        txtIme.Text = zaposleniBasic!.Ime;
        txtPrezime.Text = zaposleniBasic!.Prezime;
        dtmObuke.Value = zaposleniBasic!.DatumObuke;
        if (zaposleniBasic.ToString() == "Administracija")
        {
            cbxTip.SelectedItem = "Administracija";
            txtZanimanje.Text = (zaposleniBasic as ZaposleniAdministracijaBasic)!.Zanimanje;
            txtStrucnaSprema.Text = (zaposleniBasic as ZaposleniAdministracijaBasic)!.StrucnaSprema;
        }
        else
        {
            cbxTip.SelectedItem = "Sa direktnim kontaktom";
            cbxPodtip.SelectedItem = zaposleniBasic.ToString();
        }

        if (radiUPodaci)
        {
            txtRadnoMesto.Text = zaposleniBasic!.RadiU.NazivRadnogMesta;
            dtmZaposlenja.Value = zaposleniBasic!.RadiU.DatumPocetkaRada;
        }

    }

    private void kreirajZaposlenog(string JMBG, string ime, string prezime, DateTime datumObuke, string tip, string zanimanje, string strucnaSprema, string radnoMesto, DateTime datumZaposlenja)
    {

        if (tip == "Administracija")
        {
            zaposleniBasic = new ZaposleniAdministracijaBasic(JMBG, ime, prezime, datumObuke, zanimanje, strucnaSprema);
        }
        else if (tip == "Psiholog")
        {
            zaposleniBasic = new PsihologBasic(JMBG, ime, prezime, datumObuke);
        }
        else if (tip == "Radnik obezbeđenja")
        {
            zaposleniBasic = new RadnikObezbedjenjaBasic(JMBG, ime, prezime, datumObuke);
        }

        if (radiUPodaci)
        {
            RadiUBasic radiU = new RadiUBasic(datumZaposlenja, radnoMesto, zatvorskaJedinicaId);
            zaposleniBasic!.RadiU = radiU;
        }

    }

    private void cbxTip_SelectedValueChanged(object sender, EventArgs e)
    {
        if (cbxTip.SelectedItem != null)
        {
            string? selected = cbxTip.SelectedItem.ToString();
            if (selected == "Sa direktnim kontaktom")
            {
                lblPodtip.Visible = true;
                cbxPodtip.Visible = true;

                lblZanimanje.Visible = false;
                txtZanimanje.Visible = false;
                lblStrucnaSprema.Visible = false;
                txtStrucnaSprema.Visible = false;

                lblRadnoMesto.Location = new Point(62, 371);
                txtRadnoMesto.Location = new Point(197, 369);
                lblDatumPocetka.Location = new Point(26, 427);
                dtmZaposlenja.Location = new Point(197, 425);
            }
            else
            {
                lblPodtip.Visible = false;
                cbxPodtip.Visible = false;

                lblZanimanje.Visible = true;
                txtZanimanje.Visible = true;
                lblStrucnaSprema.Visible = true;
                txtStrucnaSprema.Visible = true;

                lblRadnoMesto.Location = new Point(62, 427);
                txtRadnoMesto.Location = new Point(197, 425);
                lblDatumPocetka.Location = new Point(22, 480);
                dtmZaposlenja.Location = new Point(197, 478);

                lblZanimanje.Location = new Point(83, 323);
                txtZanimanje.Location = new Point(197, 321);
                lblStrucnaSprema.Location = new Point(45, 371);
                txtStrucnaSprema.Location = new Point(197, 369);
            }
        }
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {
        string jmbg = txtJMBG.Text;

        if (String.IsNullOrEmpty(jmbg))
        {
            MessageBox.Show("Morate uneti JMBG zaposlenog!");
            return;
        }

        if (jmbg.Length != 13)
        {
            MessageBox.Show("JMBG mora da ima 13 cifara!");
            return;
        }

        string ime = txtIme.Text;

        if (String.IsNullOrEmpty(ime))
        {
            MessageBox.Show("Morate uneti ime zaposlenog!");
            return;
        }

        string prezime = txtPrezime.Text;

        if (String.IsNullOrEmpty(prezime))
        {
            MessageBox.Show("Morate uneti prezime zaposlenog!");
            return;
        }

        if (cbxTip.SelectedItem == null)
        {

            MessageBox.Show("Morate izabrati tip zaposlenog!");
            return;
        }

        string? tip = cbxTip.SelectedItem!.ToString();

        if (cbxPodtip.Visible)
        {
            if (cbxPodtip.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati podtip zaposlenog!");
                return;
            }

            tip = cbxPodtip.SelectedItem!.ToString();
        }

        string zanimanje = "";
        string strucnaSprema = "";

        if (tip == "Administracija")
        {
            if (String.IsNullOrEmpty(txtZanimanje.Text))
            {
                MessageBox.Show("Morate uneti tip zaposlenog!");
                return;
            }

            if (String.IsNullOrEmpty(txtStrucnaSprema.Text))
            {
                MessageBox.Show("Morate uneti stručnu spremu zaposlenog!");
                return;
            }

            zanimanje = txtZanimanje.Text;
            strucnaSprema = txtStrucnaSprema.Text;
        }

        string radnoMesto = "";

        if (radiUPodaci)
        {
            if (String.IsNullOrEmpty(txtRadnoMesto.Text))
            {
                MessageBox.Show("Morate uneti radno mesto zaposlenog!");
                return;
            }

            radnoMesto = txtRadnoMesto.Text;
        }

        string poruka = izmena ? "Da li želite da izmenite podatke o zaposlenom?" :
                                 "Da li želite da dodate novog zaposlenog?";

        string porukaUspesno = izmena ? "Uspešno ste izmenili podatke o zaposlenom!" :
                                        "Uspešno ste dodali novog zaposlenog!";

        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            kreirajZaposlenog(jmbg, ime, prezime, dtmObuke.Value, tip, zanimanje, strucnaSprema, radnoMesto, dtmZaposlenja.Value);

            if (izmena)
                DTOManager.IzmeniZaposlenog(this.zaposleniBasic!, this.staroRadnoMesto);
            else
                DTOManager.DodajZaposlenog(this.zaposleniBasic!);


            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }
    }
}