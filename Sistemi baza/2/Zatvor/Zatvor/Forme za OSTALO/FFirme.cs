namespace Zatvor.Forme_za_OSTALO
{
    public partial class FFirme : Form
    {
        public FFirme()
        {
            InitializeComponent();
        }

        private void FFirme_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private async void popuniPodacima()
        {
            listaFirmi.Items.Clear();
            List<FirmaPregled>? podaci = await DTOManager.VratiSveFirme();

            foreach (FirmaPregled f in podaci!)
            {
                ListViewItem item = new ListViewItem(new string[] { f.PIB.ToString()!, f.Ime!, f.Adresa! });
                listaFirmi.Items.Add(item);

            }

            listaFirmi.Refresh();
        }

        private void btnDodajFirmu_Click(object sender, EventArgs e)
        {
            FirmaDodaj forma = new FirmaDodaj(null);
            forma.ShowDialog();
            this.popuniPodacima();
        }

        private void btnObrisiFirmu_Click(object sender, EventArgs e)
        {
            if (listaFirmi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite firmu koju želite da obrišete!", "Greška");
                return;
            }

            int pibFirme = Int32.Parse(listaFirmi.SelectedItems[0].SubItems[0].Text);
            string poruka = "Da li želite da obrišete izabranu firmu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.ObrisiFirmu(pibFirme);
                MessageBox.Show("Firma je uspešno izbrisana!", "Obaveštenje");
                this.popuniPodacima();
            }
        }

        private async void btnIzmeniFirmu_Click(object sender, EventArgs e)
        {
            if (listaFirmi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite firmu kojoj želite da izmenite podatke!", "Greška");
                return;
            }

            int pibFirme = Int32.Parse(listaFirmi.SelectedItems[0].SubItems[0].Text);
            FirmaBasic? firma = await DTOManager.VratiFirmu(pibFirme);
            FirmaDodaj forma = new FirmaDodaj(firma);
            forma.ShowDialog();
            this.popuniPodacima();
        }

        private void btnOdgovornaLica_Click(object sender, EventArgs e)
        {
            if (listaFirmi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite firmu za koju želite da vidite odgovorna lica!", "Greška");
                return;
            }

            int pibFirme = Int32.Parse(listaFirmi.SelectedItems[0].SubItems[0].Text);
            FirmaOdgovornaLica forma = new FirmaOdgovornaLica(pibFirme);
            forma.ShowDialog();
        }

        private void btnTelefoni_Click(object sender, EventArgs e)
        {
            if (listaFirmi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite firmu za koju želite da vidite brojeve telefona!", "Greška");
                return;
            }

            int pibFirme = Int32.Parse(listaFirmi.SelectedItems[0].SubItems[0].Text);
            FirmaTelefoni forma = new FirmaTelefoni(pibFirme);
            forma.ShowDialog();
        }

        private void btnSaradnje_Click(object sender, EventArgs e)
        {
            if (listaFirmi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite firmu čije saradnje želite da vidite!", "Greška");
                return;
            }

            int pibFirme = Int32.Parse(listaFirmi.SelectedItems[0].SubItems[0].Text);
            FirmaZatvorskeJedinice forma = new FirmaZatvorskeJedinice(pibFirme);
            forma.ShowDialog();
        }

        private void btnZatvoreniciRadnici_Click(object sender, EventArgs e)
        {
            if (listaFirmi.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite firmu čije zatvorenike koje rade u njoj želite da vidite!", "Greška");
                return;
            }

            int pibFirme = Int32.Parse(listaFirmi.SelectedItems[0].SubItems[0].Text);
            FirmaZatvorenici forma = new FirmaZatvorenici(pibFirme);
            forma.ShowDialog();
        }
    }
}
