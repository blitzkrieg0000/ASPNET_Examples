using MediatR;

namespace TennisWeb6.Core.Application.Features.CQRS.Commands {
    public class DeleteProductCommandRequest : IRequest {
        public int Id { get; set; }

        public DeleteProductCommandRequest(int id) {
            this.Id = id;
        }
    }
}