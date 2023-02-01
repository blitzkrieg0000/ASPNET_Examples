using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebProjesi.Controllers {
    public class FileController : Controller {

        public IActionResult List() {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files"));
            var files = directoryInfo.GetFiles();
            return View(files);
        }


        public IActionResult Create(){
            return View();
        }


        [HttpPost]
        public IActionResult Create(string fileName){

            FileInfo fileInfo = new(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", fileName));
            
            if (!fileInfo.Exists){
                fileInfo.Create();
                //Console.WriteLine($"Dosya Oluştu: {fileInfo}");
            }
            return RedirectToAction("List");
        }


        public IActionResult Upload(){
            return View();
        }


        public IActionResult Remove(string fileName){
            FileInfo fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files",fileName));
            if(fileInfo.Exists){
                fileInfo.Delete();
            }
            return RedirectToAction("List");
        }


        public IActionResult CreateWithData(){
            
            FileInfo fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", Guid.NewGuid()+ ".txt"));
            StreamWriter writer =  fileInfo.CreateText();

            writer.Write("Merhaba Dosyaya Yazıldı...!");
            writer.Close();

            return RedirectToAction("List");
        }


        [HttpPost]
        public IActionResult Upload(IFormFile formFile){
            if(formFile.ContentType=="image/png"){
                var ext = Path.GetExtension(formFile.FileName);
                var path = Directory.GetCurrentDirectory() + "/wwwroot/Images/" + Guid.NewGuid() + ext;
                FileStream stream = new(path, FileMode.Create);
                formFile.CopyTo(stream);
                TempData["Upload_Message"] = "Başarılı!";
            }else{
                TempData["Upload_Message"] = "Başarısız! (Type: png olmalı!)";
            }

            return RedirectToAction("Upload");
        }




    }
}