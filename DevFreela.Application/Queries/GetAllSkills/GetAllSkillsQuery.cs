using DevFreela.Application.ViewModels;
using DevFreela.Core.DTOs;
using MediatR;
using System.Collections.Generic;

namespace DevFreela.Application.Queries
{
    public class GetAllSkillsQuery : IRequest<List<SkillDTO>>
    {

    }
}
