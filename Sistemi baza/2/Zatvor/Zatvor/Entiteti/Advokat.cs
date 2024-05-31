namespace Zatvor.Entiteti;

public class Advokat
{
    public virtual required string JMBG { get; set; }
    public virtual required string Ime { get; set; }
    public virtual required string Prezime { get; set; }

    public virtual IList<Poseta> Posete { get; set; } = [];
    public virtual IList<Zatvorenik> Zatvorenici { get; set; } = [];

}