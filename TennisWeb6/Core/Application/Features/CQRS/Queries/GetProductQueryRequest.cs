using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TennisWeb6.Core.Application.Dtos;

namespace TennisWeb6.Core.Application.Features.CQRS.Queries {
    public class GetProductQueryRequest : IRequest<ProductListDto> {
        public int Id { get; set; }

        public GetProductQueryRequest(int id) {
            this.Id = id;
        }

    }
}