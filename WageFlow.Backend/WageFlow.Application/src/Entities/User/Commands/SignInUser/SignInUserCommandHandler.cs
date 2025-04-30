using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WageFlow.Application.src.Interfaces;

namespace WageFlow.Application.src.Entities.User.Commands.SignInUser
{
    public class SignInUserCommandHandler
        : IRequestHandler<SignInUserCommand, SignInUserCommandVm?>
    {
        private readonly IWageFlowDbContext _dbContext;

        public SignInUserCommandHandler(IWageFlowDbContext dbContext) => _dbContext = dbContext;
        public async Task<SignInUserCommandVm?> Handle(SignInUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _dbContext.User
                .Where(note => note.user_name == request.user_name &&
                note.user_password == request.user_password)
                .Select(note => new { note.Staff.id_post, note.id_staff, note.Staff.Post.name_post })
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
            {
                return null;
            }

            return new SignInUserCommandVm(user.id_post, user.id_staff, user.name_post);
        }
    }
}
