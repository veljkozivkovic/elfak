namespace Zatvor.Forme_za_OSTALO;

public partial class OstaloMain : Form
{
    public OstaloMain()
    {
        InitializeComponent();
    }

    private void btnAdvokati_Click(object sender, EventArgs e)
    {
        FAdvokati forma = new FAdvokati();
        forma.ShowDialog();
    }

    private void btnFirme_Click(object sender, EventArgs e)
    {
        FFirme forma = new FFirme();
        forma.ShowDialog();
    }

    private void btnPrestupi_Click(object sender, EventArgs e)
    {
        FPrestupi forma = new FPrestupi();
        forma.ShowDialog();
    }

}
