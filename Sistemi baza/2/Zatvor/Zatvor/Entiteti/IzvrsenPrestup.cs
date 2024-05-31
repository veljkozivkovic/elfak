namespace Zatvor.Entiteti;

public class IzvrsenPrestup
{
    public virtual int Id { get; protected set; }
    public virtual required DateTime Datum { get; set; }
    public virtual required string Mesto { get; set; }

    public virtual required Zatvorenik Zatvorenik { get; set; }
    public virtual required Prestup Prestup { get; set; }

}
