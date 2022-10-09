using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TennisWeb6.Core.Application.Dtos;

namespace TennisWeb6.Core.Application.Features.CQRS.Queries {
    public class GetAllProductsQueryRequest : IRequest<List<ProductListDto>> {

    }
}