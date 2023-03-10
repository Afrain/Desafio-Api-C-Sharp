using ProjetoCadastroPessoa.Models;

namespace ProjetoCadastroPessoa.Repository
{
    public class UserRepository
    {
        public static User Get(string email, string senha)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Email = "admin@gmail.com", Senha = "123456", Role = "ADMIN" });
            users.Add(new User { Id = 2, Email = "user@gmail.com", Senha = "123456", Role = "USER" });
            return users.FirstOrDefault(User => User.Email.ToLower() == email && User.Senha == senha);
        }
    }
}
