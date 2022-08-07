using System;
using System.Threading.Tasks;
using AutoMapper;
using Business.GRPCData;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.TennisDtos;
using Grpc.Net.Client;
using OpenCvSharp;
using UI.Entities.Concrete;

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
            var reply = await client.detectCourtLinesControllerAsync(new detectCourtLinesRequestData() { Id = model.Id, Force = model.Force });


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

            //!READ SOURCE
            var stream = await _unitOfWork.GetRepository<Stream>().GetByFilter(x => x.Id == model.Id);
            var image = new Mat();
            var capture = new VideoCapture(stream.Source);
            capture.Read(image);
            capture.Release();

            if (!image.Empty()) {


                for (int i = 0; i < 10; i++) {

                    Cv2.Line(image,
                        (int)linesList[i, 0], (int)linesList[i, 1],
                        (int)linesList[i, 2], (int)linesList[i, 3],
                 new Scalar(255, 255, 255), 10
                    );
                }

            }

            string encodedByte = Convert.ToBase64String(image.ToBytes());

            DetectCourtLinesDto data = new() {
                Lines = encodedByte
            };

            return new Response<DetectCourtLinesDto>(ResponseType.Success, data);
        }
    }
}