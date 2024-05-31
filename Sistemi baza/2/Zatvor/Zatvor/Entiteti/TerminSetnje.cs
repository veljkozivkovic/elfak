namespace Zatvor.Entiteti;

public class TerminSetnje
{
    public virtual int Id { get; protected set; }
    public virtual required string TerminOd { get; set; }
    public virtual required string TerminDo { get; set; }

    public virtual required ZatvorskaJedinica ZatvorskaJedinica { get; set; }

}
