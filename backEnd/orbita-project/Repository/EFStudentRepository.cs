using orbita.Interface;
using Orbita.Entity;
using Orbita.Interface;
 

namespace Orbita.Repository
{
    public class EFStudentRepository : EFRepository<Student>, IStudentRepository
    {
        public EFStudentRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Faz a verificação se o email já esta registrado
        /// </summary>
        /// <param name="email"></param>        
        /// <returns></returns>
        public bool IsEmailAlreadyRegistered(string email)
        {
            var user = _context.Student.FirstOrDefault(user => user.Email == email);

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public Student GetByRA(string ra)
        {
            var user = _context.Student.FirstOrDefault(user => user.RA == ra);

            return user ?? throw new ArgumentException("Aluno não encontrado!");
        }
    }
}
