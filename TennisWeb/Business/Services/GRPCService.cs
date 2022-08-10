using System.Threading.Tasks;
using AutoMapper;
using Business.GRPCData;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.TennisDtos;
using Grpc.Net.Client;

namespace Business.Services {
    public class GRPCService : IGRPCService {
        
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GRPCService(IMapper mapper, IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<DetectCourtLinesDto>> DetectCourtLines(CourtLineDetectRequestModel model) {
            using var channel = GrpcChannel.ForAddress("http://localhost:50011");
            var client = new mainRouterServer.mainRouterServerClient(channel);
            var requestData = new detectCourtLinesRequestData() { Id = model.Id, Force = model.Force };
            var reply = await client.detectCourtLinesControllerAsync(requestData);

            //! PARSE
            var raw = reply.Lines;
            float[,] linesList = new float[10, 4];
            
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 4; j++) {
                    if (raw.Items.Count > 0) {
                        if (raw.Items[i].Items.Count > 0) {
                            linesList[i, j] = raw.Items[i].Items[j].Data;
                        }
                    }
                }
            }

            DetectCourtLinesDto data = new() {
                Lines = linesList,
                Base64Img = reply.Frame
            };

            return new Response<DetectCourtLinesDto>(ResponseType.Success, data);
        }
    }
}