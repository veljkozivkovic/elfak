namespace Zatvor.Entiteti;

public class Prestup
{
    public virtual int Id { get; protected set; }
    public virtual required string Naziv { get; set; }
    public virtual required string Kategorija { get; set; }
    public virtual required string Opis { get; set; }
    public virtual required string MinKazna { get; set; }
    public virtual required string MaxKazna { get; set; }

    public virtual IList<IzvrsenPrestup> IzvrseniPrestupi { get; set; } = [];
}
