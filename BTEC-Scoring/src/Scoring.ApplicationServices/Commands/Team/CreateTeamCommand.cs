using MediatR;
using Scoring.ApplicationShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.ApplicationServices.Commands
{
    public class CreateTeamCommand : IRequest<bool>
    {
        public string TeamName { get; set; }
        public List<StudentDto> Students { get; set; } = new List<StudentDto>();
    }
}
