namespace Backend.Services;

public interface IMailService
{
    bool SendMail(MailData mailData);
    Task<bool> SendMailAsync(MailData mailData);
    Task<bool> SendHTMLMailAsync(HTMLMailData htmlMailData);
    void SendHTMLMailFireAndForget(HTMLMailData htmlMailData);
}