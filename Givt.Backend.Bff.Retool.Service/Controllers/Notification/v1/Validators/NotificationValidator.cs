using FluentValidation;
using Givt.Backend.Bff.Retool.Service.Configurations;
using Microsoft.Extensions.Options;

namespace Givt.Backend.Bff.Retool.Service.Controllers.Notification.v1
{
    public class NotificationValidator : AbstractValidator<Model.Notification>
    {
        private readonly ApplicationSettings _applicationSettings;

        public NotificationValidator(IOptions<ApplicationSettings> applicationSettings)
        {
            _applicationSettings = applicationSettings.Value;

            RuleFor(model => model.Message)
                .NotEmpty()
                    .WithMessage("Message_Error");
        }
    }
}