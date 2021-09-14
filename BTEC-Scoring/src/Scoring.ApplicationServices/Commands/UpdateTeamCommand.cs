using MediatR;
using Scoring.ApplicationShared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.ApplicationServices.Commands
{
    public class UpdateTeamCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public List<StudentDto> Students { get; set; } = new List<StudentDto>();
    }
}
