namespace ZatvorLibrary.Entiteti;

internal class Poseta
{
    protected internal virtual int Id { get; set; }
    protected internal virtual DateTime? Datum { get; set; }
    protected internal virtual string? VremeOd { get; set; }
    protected internal virtual string? VremeDo { get; set; }
    protected internal virtual Zatvorenik? Zatvorenik { get; set; }
    protected internal virtual Advokat? Advokat { get; set; }
}
