namespace ZatvorLibrary.Entiteti;

internal class TerminSetnje
{
    protected internal virtual int Id { get; set; }
    protected internal virtual string? TerminOd { get; set; }
    protected internal virtual string? TerminDo { get; set; }

    protected internal virtual ZatvorskaJedinica? ZatvorskaJedinica { get; set; }

}
