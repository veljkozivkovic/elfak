namespace ZatvorLibrary.Entiteti;

internal class ObukaVatrenoOruzje
{
    protected internal virtual int Id { get; set; }
    protected internal virtual DateTime? DatumIzdavanja { get; set; }
    protected internal virtual string? PolicijskaUprava { get; set; }

    protected internal virtual RadnikObezbedjenja? Radnik { get; set; }
}
