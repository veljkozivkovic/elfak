namespace Zatvor;

public partial class PocetnaStranica : Form
{
    public PocetnaStranica()
    {
        InitializeComponent();
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {

    }

    private void buttonZatvori_Click(object sender, EventArgs e)
    {
        ZatvorskeJediniceMain forma = new ZatvorskeJediniceMain();
        forma.ShowDialog();
    }

    private void buttonZaposleni_Click(object sender, EventArgs e)
    {
        FZaposleni forma = new FZaposleni();
        forma.ShowDialog();
    }

    private void buttonZatvorenici_Click(object sender, EventArgs e)
    {
        FZatvorenici form = new FZatvorenici();
        form.ShowDialog();
    }

    private void buttonOstalo_Click(object sender, EventArgs e)
    {
        OstaloMain form = new OstaloMain();
        form.ShowDialog();
    }
}
