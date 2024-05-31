namespace Zatvor.Forme_za_Zatvorske_Jedinice;

public partial class ZatvorskeJediniceFirmeDodaj : Form
{
    int zatvorskaJedinicaId;

    public ZatvorskeJediniceFirmeDodaj(int zatvorskaJedinicaId)
    {
        InitializeComponent();
        this.zatvorskaJedinicaId = zatvorskaJedinicaId;
    }

    private void ZatvorskeJediniceFirmeDodaj_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    private async void popuniPodacima()
    {
        listaFirmi.Items.Clear();
        List<FirmaPregled> podaci = await DTOManager.VratiSveFirmeZaSaradnju(zatvorskaJedinicaId);

        foreach (FirmaPregled f in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { f.PIB.ToString()!, f.Ime!, f.Adresa! });
            listaFirmi.Items.Add(item);
        }

        listaFirmi.Refresh();
    }

    private void btnIzaberi_Click(object sender, EventArgs e)
    {
        if (listaFirmi.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite firmu sa kojom želite da započnete saradnju!", "Greška");
            return;
        }

        string poruka = "Da li želite da započnete saradnju sa izabranom firmom?";
        string porukaUspesno = "Uspešno ste započeli saradnju sa izabranom firmom!";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            int firmaPIB = Int32.Parse(listaFirmi.SelectedItems[0].SubItems[0].Text);
            DTOManager.ZapocniSaradnju(zatvorskaJedinicaId, firmaPIB);
            MessageBox.Show(porukaUspesno, "Obaveštenje");
            this.Close();
        }
    }

}
