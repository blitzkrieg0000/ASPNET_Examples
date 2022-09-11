using System.Threading.Tasks;
using Business.Interfaces;
using Dtos.AosTypeDtos;
using Dtos.CourtDtos;
using Dtos.PlayerDtos;
using Dtos.StreamDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Entities.Concrete;
using Dtos.CourtTypeDtos;

namespace UI.ViewComponents {
    public class SelectListFromTable : ViewComponent {
        private readonly IGenericService _genericService;

        public SelectListFromTable(IGenericService genericService) {
            _genericService = genericService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string tableName) {

            SelectList data = null;
            if (tableName == "Stream") {
                //var results = await _genericService.GetAll<StreamListDto, Stream>();
                var results = await _genericService.GetListByFilter<StreamListDto, Stream>(x=>x.IsVideo != true);
                data = new SelectList(results.Data, "Id", "Name", tableName + "Id");
            } else if (tableName == "Player") {
                var results = await _genericService.GetAll<PlayerListDto, Player>();
                data = new SelectList(results.Data, "Id", "Name", tableName + "Id");
            } else if (tableName == "Court") {
                var results = await _genericService.GetAll<CourtListDto, Court>();
                data = new SelectList(results.Data, "Id", "Name", tableName + "Id");
            } else if (tableName == "AosType") {
                var results = await _genericService.GetAll<AosTypeListDto, AosType>();
                data = new SelectList(results.Data, "Id", "Name", tableName + "Id");
            } else if (tableName == "CourtType"){
                var results = await _genericService.GetAll<CourtTypeListDto, CourtType>();
                data = new SelectList(results.Data, "Id", "Name", tableName + "Id");
            }

            return View(data);
        }


    }
}