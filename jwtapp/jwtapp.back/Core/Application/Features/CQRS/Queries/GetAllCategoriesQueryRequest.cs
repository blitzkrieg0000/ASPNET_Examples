using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtapp.back.Core.Application.Dto;
using MediatR;

namespace jwtapp.back.Core.Application.Features.CQRS.Queries
{
    public class GetAllCategoriesQueryRequest : IRequest<List<CategoryListDto>>
    {
        
    }
}