namespace ZatvorLibrary.Entiteti;

internal class IzvrsenPrestup
{
    protected internal virtual int Id { get; set; }
    protected internal virtual DateTime? Datum { get; set; }
    protected internal virtual string? Mesto { get; set; }

    protected internal virtual Zatvorenik? Zatvorenik { get; set; }
    protected internal virtual Prestup? Prestup { get; set; }

}
