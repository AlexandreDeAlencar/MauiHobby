using ErrorOr;
using GA_Intergado.CR2.App.Common.UnitOfWork;
using GA_Intergado.CR2.App.Login.Settings;
using GA_Intergado.CR2.App.ServerIntegration.Commands;
using GA_Intergado.CR2.Domain.Users;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GA_Intergado.CR2.App.Login.Command
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ErrorOr<Success>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(IUnitOfWork unitOfWork,
            IConfiguration configuration) 
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<ErrorOr<Success>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            byte[] passwordBytes = Encoding.ASCII.GetBytes(request.Password);
            MD5 md5 = MD5.Create();
            byte[] hashBytes = md5.ComputeHash(passwordBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            List<User> users;

            if (request.Login == _configuration.GetRequiredSection("DefaultUser").Get<DefaultUserSettings>().UserName
               && hash == _configuration.GetRequiredSection("DefaultUser").Get<DefaultUserSettings>().Password
               )
            {
                return Result.Success;
            }

            try
            {
                users = _unitOfWork.Users.GetAll();
            }
            catch (Exception ex)
            {
                return Error.Failure("Users Search", ex.Message);
            }

            if(!users.Any()
                && request.Login == _configuration.GetRequiredSection("IntegrationServiceHostAdress").Get<DefaultUserSettings>().UserName
                && hash == _configuration.GetRequiredSection("IntegrationServiceHostAdress").Get<DefaultUserSettings>().Password
                )
            {
                return Result.Success;
            }

            if (users
                .Where(u => u.UserName == request.Login
                && u.Password == hash)
                .Any())
            {
                return Result.Success;
            }

            return Error.NotFound();
        }
    }
}
