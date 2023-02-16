using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtapp.back.Core.Application.Dto;
using MediatR;

namespace jwtapp.back.Core.Application.Features.CQRS.Queries
{
    public class GetProductQueryRequest : IRequest<ProductListDto>
    {
        public int Id { get; set; }
        public GetProductQueryRequest(int id)
        {
            this.Id = id;
        }
    }
}