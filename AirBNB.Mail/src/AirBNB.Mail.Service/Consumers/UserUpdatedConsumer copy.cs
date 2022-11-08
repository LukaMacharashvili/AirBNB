using MassTransit;
using EventBus.Contracts;
using AirBNB.Mail.Service.Services;
using AirBNB.Mail.Service.Dtos;

namespace AirBNB.Mail.Service.Consumers
{
    public class UserUpdatedConsumer : IConsumer<UserUpdated>
    {
        private MailService _mailService;
        public UserUpdatedConsumer(MailService mailService)
        {
            _mailService = mailService;
        }

        public async Task Consume(ConsumeContext<UserUpdated> context)
        {
            var message = context.Message;
            var body = $@"<p>Dear User, please verify your email for AirBNB-Clone project.</p>
        <p>
            This <a href=@""https://localhost:5001/api/auth/verify-user/{message.VerificationToken}"">link</a> will verify your email address.
        </p>
        <p>
            If you did not registered on AirBNB-Clone project, you can just ignore this message and do not click on the link!
        </p>";
            _mailService.SendEmail(new MailDto(message.Email, "Email Verification", body));
        }
    }
}