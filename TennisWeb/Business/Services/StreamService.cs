using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Common.ResponseObjects;
using DataAccess.UnitOfWork;
using Dtos.StreamDtos;
using Microsoft.AspNetCore.Http;
using Entities.Concrete;
using System.Text.RegularExpressions;
using FluentValidation;
using Business.Extensions;

namespace Business.Services {
    public class StreamService : IStreamService {
        // Mapping İşlemleri ve Validation İşlemelerinin çağrılması

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<StreamCreateDto> _streamCreateDtoValidator;

        public StreamService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<StreamCreateDto> streamCreateDtoValidator) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _streamCreateDtoValidator = streamCreateDtoValidator;
        }

        public async Task<Response<List<StreamListDto>>> GetAll() {
            var data = _mapper.Map<List<StreamListDto>>(
                await _unitOfWork.GetRepository<Stream>().GetAll()
            );
            return new Response<List<StreamListDto>>(ResponseType.Success, data);
        }

        public async Task<Response<StreamListDto>> GetById(long? id) {
            var data = _mapper.Map<StreamListDto>(
                await _unitOfWork.GetRepository<Stream>().GetByFilter(x => x.Id == id, asNoTracking: false)
            );
            return new Response<StreamListDto>(ResponseType.Success, data);
        }

        public async Task<IResponse<StreamCreateDto>> Create(IFormFile formFile, StreamCreateDto dto) {

            var validationResult = _streamCreateDtoValidator.Validate(dto);
            if (validationResult.IsValid){
                if (formFile == null && dto.Source == null) {
                    return new Response<StreamCreateDto>(ResponseType.ValidationError, dto);
                }

                //İsim Kontrolü
                string baseName = dto.Name;
                if (dto.Name == null) {
                    baseName = Guid.NewGuid().ToString();
                }
                Regex rgx = new("\\W+");
                baseName = rgx.Replace(baseName, "");
                dto.Name = baseName;

                if (dto.Source == null) {
                    if (formFile.ContentType != "video/mp4") {
                        return new Response<StreamCreateDto>(ResponseType.ValidationError, "Lütfen mp4 formatında video yükleyiniz.");
                    }

                    string SAVE_PATH = "/srv/nfs/mydata/docker-tennis";
                    string SAVE_FOLDER_NAME = "assets";
                    SAVE_PATH = System.IO.Path.Combine(SAVE_PATH, SAVE_FOLDER_NAME);

                    var newName = baseName + System.IO.Path.GetExtension(formFile.FileName);
                    var path = System.IO.Path.Combine(SAVE_PATH, newName);
                    var stream = new System.IO.FileStream(path, System.IO.FileMode.Create);
                    await formFile.CopyToAsync(stream);

                    //Path
                    dto.Source = "/assets/" + newName;

                    //TODO HASH KONTROLÜ YAPILABİLİR
                    // var hash = "";
                    // using (var md5 = System.Security.Cryptography.MD5.Create()) {

                    //     using (var streamReader = new StreamReader(formFile.OpenReadStream())) {
                    //         hash = BitConverter.ToString(md5.ComputeHash(streamReader.BaseStream)).Replace("-", "");
                    //     }
                    // }
                    // System.Console.WriteLine(hash);

                }

                dto.SaveDate = DateTime.Now;
                await _unitOfWork.GetRepository<Stream>().Create(_mapper.Map<Stream>(dto));
                await _unitOfWork.SaveChanges();
                return new Response<StreamCreateDto>(ResponseType.Success, dto, "Yükleme Başarılı");
            }else{
                return new Response<StreamCreateDto>(ResponseType.ValidationError, dto, validationResult.ConvertToCustomValidationError());
            }

        }

        public async Task<IResponse<StreamListDto>> Update(StreamListDto dto) {
            var updatedEntity = await _unitOfWork.GetRepository<Stream>().Find(dto.Id);
            _unitOfWork.GetRepository<Stream>().Update(_mapper.Map<Stream>(dto), updatedEntity);
            await _unitOfWork.SaveChanges();
            return new Response<StreamListDto>(ResponseType.Success, dto);
        }

        public async Task<IResponse> Remove(long id) {
            var removedEntity = await _unitOfWork.GetRepository<Stream>().GetByFilter(x => x.Id == id);

            if (removedEntity != null) {
                _unitOfWork.GetRepository<Stream>().Remove(removedEntity);
                await _unitOfWork.SaveChanges();
                return new Response(ResponseType.Success);
            }
            return new Response(ResponseType.NotFound, $"{id} ye ait veri bulunamadı!");
        }

    }
}