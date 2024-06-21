using System.Net.Mail;
using System.Net;

Console.WriteLine("Введите адрес smpt сервера:");
string smtpServer = "smtp.mail.ru"; //smpt сервер(зависит от почты отправителя)
smtpServer = Console.ReadLine();

Console.WriteLine("Введите порт:");
int smtpPort = 587; // Обычно используется порт 587 для TLS
smtpPort = Int32.Parse( Console.ReadLine());


Console.WriteLine("Укажите почту с которой будет отправлено сообщение:");
string smtpUsername = ""; //почта, с которой отправляется сообщение
smtpUsername = Console.ReadLine();
Console.WriteLine("Введите пароль:");
string smtpPassword = "";//пароль приложения (от почты c с которой отправляется)
smtpPassword = Console.ReadLine();
using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
{
	// Настройки аутентификации
	smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
	smtpClient.EnableSsl = true;

	using (MailMessage mailMessage = new MailMessage())
	{
		mailMessage.From = new MailAddress(smtpUsername);
        Console.WriteLine("Укажите адрес получателя:");
		string reciver = Console.ReadLine();
        mailMessage.To.Add(reciver); // адрес получателя

        Console.WriteLine("Введите заголовок письма");
		string header = Console.ReadLine(); 
        mailMessage.Subject = header;
        Console.WriteLine("Введите сообщение:");
		string message = Console.ReadLine();
        mailMessage.Body = $"{message}";

		try
		{
			// Отправляем сообщение
			smtpClient.Send(mailMessage);
			Console.WriteLine("Сообщение успешно отправлено.");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Ошибка отправки сообщения: {ex.Message}");
		}
	}
}