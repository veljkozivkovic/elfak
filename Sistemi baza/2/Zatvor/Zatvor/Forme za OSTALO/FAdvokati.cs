namespace Zatvor.Forme_za_OSTALO
{
    public partial class FAdvokati : Form
    {
        public FAdvokati()
        {
            InitializeComponent();
        }

        private void FAdvokati_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private async void popuniPodacima()
        {
            listaAdvokata.Items.Clear();
            List<AdvokatPregled>? podaci = await DTOManager.VratiSveAdvokate();

            foreach (AdvokatPregled a in podaci!)
            {
                ListViewItem item = new ListViewItem(new string[] { a.JMBG!, a.Ime!, a.Prezime! });
                listaAdvokata.Items.Add(item);

            }

            listaAdvokata.Refresh();
        }

        private void btnDodajAdvokata_Click(object sender, EventArgs e)
        {
            AdvokatDodaj forma = new AdvokatDodaj(null);
            forma.ShowDialog();
            this.popuniPodacima();
        }

        private void btnObrisiAdvokata_Click(object sender, EventArgs e)
        {
            if (listaAdvokata.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite advokata koga želite da obrišete!", "Greška");
                return;
            }

            string jmbgAdvokata = listaAdvokata.SelectedItems[0].SubItems[0].Text;
            string poruka = "Da li želite da obrišete izabranog advokata?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.ObrisiAdvokata(jmbgAdvokata);
                MessageBox.Show("Advokat je uspešno izbrisan!", "Obaveštenje");
                this.popuniPodacima();
            }
        }

        private async void btnIzmeniAdvokata_Click(object sender, EventArgs e)
        {
            if (listaAdvokata.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite advokata za koga želite da izmenite podatke!", "Greška");
                return;
            }

            string jmbgAdvokata = listaAdvokata.SelectedItems[0].SubItems[0].Text;
            AdvokatBasic? advokat = await DTOManager.VratiAdvokata(jmbgAdvokata);
            AdvokatDodaj forma = new AdvokatDodaj(advokat);
            forma.ShowDialog();
            this.popuniPodacima();
        }

        private void btnZatvorenici_Click(object sender, EventArgs e)
        {
            if (listaAdvokata.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite advokata za koga želite da vidite koje zatvorenike zastupa!", "Greška");
                return;
            }

            string jmbgAdvokata = listaAdvokata.SelectedItems[0].SubItems[0].Text;
            AdvokatZatvorenici forma = new AdvokatZatvorenici(jmbgAdvokata);
            forma.ShowDialog();
        }

        private void btnPosete_Click(object sender, EventArgs e)
        {
            if (listaAdvokata.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite advokata za koga želite da vidite posete!", "Greška");
                return;
            }

            string jmbgAdvokata = listaAdvokata.SelectedItems[0].SubItems[0].Text;
            AdvokatPosete forma = new AdvokatPosete(jmbgAdvokata);
            forma.ShowDialog();
        }
    }
}
