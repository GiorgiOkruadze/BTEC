using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.ApplicationShared.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fill Team Name Property")]

        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fill Team Name Property")]
        public string Surname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Fill Team Name Property")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        public int TeamId { get; set; }
    }
}
