namespace Zatvor.Entiteti;

public class TerminPosete
{
    public virtual int Id { get; protected set; }
    public virtual required string Dan { get; set; }
    public virtual required string TerminOd { get; set; }
    public virtual required string TerminDo { get; set; }
    public virtual required ZatvorskaJedinica ZatvorskaJedinica { get; set; }
}
