namespace Zatvor.Entiteti;

public class Poseta
{
    public virtual int Id { get; protected set; }
    public virtual DateTime Datum { get; set; }
    public virtual required string VremeOd { get; set; }
    public virtual required string VremeDo { get; set; }
    public virtual required Zatvorenik Zatvorenik { get; set; }
    public virtual required Advokat Advokat { get; set; }
}
