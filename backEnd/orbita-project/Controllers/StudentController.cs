using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using orbita.Interface;
using Orbita.DTO;
using Orbita.Entity;
using Orbita.Enums;
using Orbita.Interface;
using System.Security.Claims;
 

namespace orbita.Controllers
{
    [ApiController]
    [Route("student")]
    public class StudentController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IStudentRepository _studentRepository;
        private readonly ILogger<StudentController> _logger;

        public StudentController(
            IUserRepository userRepository,
            ILogger<StudentController> logger,
            IStudentRepository studentRepository
            )
        {
            _userRepository = userRepository;
            _logger = logger;
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        /// <param name="SaveStudentsDTO"></param>
        /// <returns></returns>  
        [Authorize]
        [Authorize(Roles = Permitions.Admin)]
        [HttpPost("saveStudent")]
        public IActionResult SaveStudent(SaveStudentsDTO saveDto)
        {            
            if (_studentRepository.IsEmailAlreadyRegistered(saveDto.Email))
            {
                var errorMessage = $"Error: Email {saveDto.Email} já esta cadastrado.";
                _logger.LogError(errorMessage);
                return BadRequest(errorMessage);
            }

           _studentRepository.Save(new Student(saveDto));

            var message = $"Aluno {saveDto.Name} registrado com sucesso";
            _logger.LogWarning(message);
            return Ok(message);
        }

        /// <summary>
        /// Obtém todos os alunos, o método necessita de autenticação e permissão de Administrador
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retonar Sucesso</response>
        /// <response code="401"> Não Autenticado</response>
        /// <response code="403"> Ñão Autorizado</response>
        [Authorize]       
        [HttpGet("getAllStudent")]
        public IActionResult GetAllUser()
        {
            return Ok(_studentRepository.GetAll());
        }

        /// <summary>
        ///  Obtém  alunos por RA, o método necessita de autenticação e permissão de Administrador
        /// </summary>
        /// <param name="ra"></param>
        /// <returns></returns>
        /// <response code="200"> Retonar Sucesso</response>
        /// <response code="401"> Não Autenticado</response>
        /// <response code="403"> Ñão Autorizado</response>
        /// <response code="404"> Aluno não encontrado</response>
        [Authorize]        
        [HttpGet("getStudentByRA/{ra}")]
        public IActionResult GetUserByRA(string ra)
        {
            var user = _studentRepository.GetByRA(ra);

            if (user == null)
            {
                _logger.LogError("Aluno não encontrado!");
                return NotFound("Aluno não encontrado!");
            }
            else
            {
                return Ok(user);
            }                

           
        }


        /// <summary>
        /// Deleta um aluno, o método necessita de permissão de Administrador.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200"> Retonar Sucesso</response>
        /// <response code="401"> Não Autenticado</response>
        /// <response code="403"> Ñão Autorizado</response>
        /// <response code="404"> Usuário não encontrado</response>
        [Authorize]
        [Authorize(Roles = Permitions.Admin)]
        [HttpDelete("deleteStudent/{ra}")]
        public IActionResult DeleteStudent(string ra)
        {
            var student = _studentRepository.GetByRA(ra);
            _studentRepository.Delete(student.Id);

            _logger.LogInformation($"Aluno {student.Name} deletado com sucesso");

            return Ok("Aluno deletado com sucesso");
             
        }

        /// <summary>
        /// Modifica email do usuário, método necessita de autenticação.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200"> Retonar Sucesso</response>
        /// <response code="401"> Não Autenticado</response> 
        /// <response code="404"> Usuário não encontrado</response>
        [Authorize]
        [HttpPut("editStudent")]
        public IActionResult EditStudent(PutStudentDTO dto)
        {
            
            var student = _studentRepository.GetByRA(dto.RA);

            var email = _studentRepository.IsEmailAlreadyRegistered(dto.Email); 

            if(email != null)
            {
                BadRequest("Email já está cadastrado");
            }         
            
            student.ChangeNameOrEmail(dto.Name, dto.Email);
            _studentRepository.Put(student);  

            return Ok("Dados alterados com sucesso");

        }


    }
}