using Orbita.Entity;
using Orbita.DTO;

namespace Orbita.Entity
{
    public class Student : Entitys
    {    

        public string Name { get; set; }
        public string Email { get; set; }
        public string RA { get; set; }
        public string CPF { get; set; }

        public Student(SaveStudentsDTO dto)
        {
            Name = dto.Name;
            Email = dto.Email;
            RA = GenerateRA(dto.RA, dto.Name);
            CPF = dto.CPF;
        }

        public string GenerateRA(string ra, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                string initials = new string(name.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(part => part[0]).ToArray());
                string record = $"{ra}{initials}";
                return record;
            }
            return string.Empty;
        }



    }
}
