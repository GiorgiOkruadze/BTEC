using MediatR;
using Scoring.ApplicationShared.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.ApplicationServices.Commands
{
    public class CreateTeamCommand : IRequest<bool>
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fill Team Name Property")]
        public string TeamName { get; set; }
        public List<StudentDto> Students { get; set; } = new List<StudentDto>();
    }
}
