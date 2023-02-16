using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace jwtapp.back.Core.Application.Features.CQRS.Commands
{
    public class DeleteCategoryCommandRequest : IRequest
    {
       public int Id { get; set; }
       public DeleteCategoryCommandRequest(int id)
       {
        this.Id=id;
       }
    }
}