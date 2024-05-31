namespace Zatvor.Forme_za_Zaposlene
{
    public partial class FZaposleni : Form
    {
        public FZaposleni()
        {
            InitializeComponent();
        }

        private void FZaposleni_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private async void popuniPodacima()
        {
            listaZaposlenih.Items.Clear();
            List<ZaposleniPregled> podaci = await DTOManager.VratiSveZaposlene();

            foreach (ZaposleniPregled z in podaci)
            {
                ListViewItem item = new ListViewItem(new string[] { z.JMBG, z.Ime, z.Prezime, z.DatumObuke.ToShortDateString(), z.TipZaposlenog, z.Zanimanje, z.StrucnaSprema, z.RadnoMesto, z.DatumPocetka.ToShortDateString() });
                listaZaposlenih.Items.Add(item);
            }

            listaZaposlenih.Refresh();
        }

        private void btnDodajZaposlenog_Click(object sender, EventArgs e)
        {
            ZaposleniDodaj forma = new ZaposleniDodaj(null, 0, false, "");
            forma.ShowDialog();
            this.popuniPodacima();
        }

        private void btnObrisiZaposlenog_Click(object sender, EventArgs e)
        {
            if (listaZaposlenih.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zaposlenog koga želite da obrišete!", "Greška");
                return;
            }

            string idZaposlenog = listaZaposlenih.SelectedItems[0].SubItems[0].Text;
            string poruka = "Da li želite da obrišete izabranog zaposlenog?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.ObrisiZaposlenog(idZaposlenog);
                MessageBox.Show("Zaposleni je uspešno izbrisan!", "Obaveštenje");
                this.popuniPodacima();
            }
        }

        private async void btnIzmeniZaposlenog_Click(object sender, EventArgs e)
        {
            if (listaZaposlenih.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zaposlenog čije podatke želite da izmenite!", "Greška");
                return;
            }

            string idZaposlenog = listaZaposlenih.SelectedItems[0].SubItems[0].Text;
            string tip = listaZaposlenih.SelectedItems[0].SubItems[4].Text;
            ZaposleniBasic? zaposleni = await DTOManager.VratiZaposlenog(idZaposlenog, tip, 0, "");
            ZaposleniDodaj forma = new ZaposleniDodaj(zaposleni, 0, false, "");
            forma.ShowDialog();
            this.popuniPodacima();
        }

        private void btnPrikaziZaposlenja_Click(object sender, EventArgs e)
        {
            if (listaZaposlenih.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zaposlenog čija zaposlenja želite da vidite!", "Greška");
                return;
            }

            string idZaposlenog = listaZaposlenih.SelectedItems[0].SubItems[0].Text;
            ZaposleniZaposlenja forma = new ZaposleniZaposlenja(idZaposlenog);
            forma.ShowDialog();
        }

        private void btnLekarskiPregledi_Click(object sender, EventArgs e)
        {
            if (listaZaposlenih.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zaposlenog čije lekarske preglede želite da vidite!", "Greška");
                return;
            }

            string idZaposlenog = listaZaposlenih.SelectedItems[0].SubItems[0].Text;
            string tip = listaZaposlenih.SelectedItems[0].SubItems[4].Text;
            if (tip == "Administracija")
            {
                MessageBox.Show("Radnik u administraciji nema lekarske preglede!", "Greška");
                return;
            }

            LekarskiPregledi forma = new LekarskiPregledi(idZaposlenog);
            forma.ShowDialog();

        }

        private void btnObuke_Click(object sender, EventArgs e)
        {
            if (listaZaposlenih.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite zaposlenog čije obuke želite da vidite!", "Greška");
                return;
            }

            string idZaposlenog = listaZaposlenih.SelectedItems[0].SubItems[0].Text;
            string tip = listaZaposlenih.SelectedItems[0].SubItems[4].Text;
            if (tip != "Obezbeđenje")
            {
                MessageBox.Show("Samo radnici obezbeđenja imaju obuke!", "Greška");
                return;
            }

            Obuke forma = new Obuke(idZaposlenog);
            forma.ShowDialog();
        }
    }
}
