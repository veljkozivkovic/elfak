namespace Zatvor.Entiteti;

public class ObukaVatrenoOruzje
{
    public virtual int Id { get; protected set; }
    public virtual DateTime DatumIzdavanja { get; set; }
    public virtual required string PolicijskaUprava { get; set; }

    public virtual required RadnikObezbedjenja Radnik { get; set; }
}
