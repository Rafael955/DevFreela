using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System.Linq;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _context;

        public UserService(DevFreelaDbContext context)
        {
            _context = context;
        }

        public int Create(CreateUserInputModel inputModel)
        {
            var newUser = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);

            _context.Users.Add(newUser);

            _context.SaveChanges();

            return newUser.Id;
        }

        //public UserViewModel GetUser(int id)
        //{
        //    var user =_context.Users.SingleOrDefault(x => x.Id == id);

        //    if (user == null)
        //    {
        //        return null;
        //    }

        //    var userViewModel = new UserViewModel(user.FullName, user.Email);

        //    return userViewModel;
        //}
    }
}
