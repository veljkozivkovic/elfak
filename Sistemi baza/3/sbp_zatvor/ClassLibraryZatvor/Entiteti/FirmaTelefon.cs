namespace ZatvorLibrary.Entiteti;

internal class FirmaTelefon
{
    protected internal virtual int Id { get; set; }
    protected internal virtual string? BrojTelefona { get; set; }
    protected internal virtual Firma? Firma { get; set; }
}
