﻿namespace Zatvor.Forme_za_Zatvorenike;

public partial class ZatvoreniciPosete : Form
{

    int zatvorenikId;

    public ZatvoreniciPosete(int zatvorenikId)
    {
        InitializeComponent();
        this.zatvorenikId = zatvorenikId;
    }

    private void ZatvoreniciPrestupi_Load(object sender, EventArgs e)
    {
        popuniPodacima();
    }

    private async void popuniPodacima()
    {
        listaPoseta.Items.Clear();
        List<PosetaPregled> podaci = await DTOManager.VratiPoseteZaZatvorenika(zatvorenikId);

        foreach (PosetaPregled p in podaci)
        {
            ListViewItem item = new ListViewItem(new string[] { p.Id.ToString(), p.Advokat, p.Datum.ToShortDateString(), p.VremeOd, p.VremeDo });
            listaPoseta.Items.Add(item);
        }

        listaPoseta.Refresh();
    }

    private void btnDodajPosetu_Click(object sender, EventArgs e)
    {
        ZatvoreniciPoseteDodaj forma = new ZatvoreniciPoseteDodaj(null, zatvorenikId);
        forma.ShowDialog();
        this.popuniPodacima();
    }

    private void btnObrisiPosetu_Click(object sender, EventArgs e)
    {
        if (listaPoseta.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite posetu koju želite da obrišete!", "Greška");
            return;
        }

        int idPosete = Int32.Parse(listaPoseta.SelectedItems[0].SubItems[0].Text);
        string poruka = "Da li želite da obrišete izabranu posetu?";
        string title = "Pitanje";
        MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
        DialogResult result = MessageBox.Show(poruka, title, buttons);

        if (result == DialogResult.OK)
        {
            DTOManager.ObrisiPosetu(idPosete);
            MessageBox.Show("Poseta je uspešno izbrisana!", "Obaveštenje");
            this.popuniPodacima();
        }
    }

    private async void btnIzmeniPosetu_Click(object sender, EventArgs e)
    {
        if (listaPoseta.SelectedItems.Count == 0)
        {
            MessageBox.Show("Izaberite posetu čije podatke želite da izmenite!", "Greška");
            return;
        }

        int idPosete = Int32.Parse(listaPoseta.SelectedItems[0].SubItems[0].Text);
        PosetaBasic? prestup = await DTOManager.VratiPosetu(idPosete);
        ZatvoreniciPoseteDodaj forma = new ZatvoreniciPoseteDodaj(prestup, zatvorenikId);
        forma.ShowDialog();
        this.popuniPodacima();
    }
}