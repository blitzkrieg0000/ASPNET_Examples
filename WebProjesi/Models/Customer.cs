using System.ComponentModel.DataAnnotations;

namespace WebProjesi.Models {

    //DataAnnotation
    public class Customer {

        [Required(ErrorMessage = "Id gereklidir.")]
        public int Id {get; set;}

        [Required(ErrorMessage = "İsim alanı boş olamaz.")]
        [MinLength(3, ErrorMessage = "Ad alanı en az 3 karakter olabilir.")]
        [MaxLength(30, ErrorMessage = "İsim alanı 30 karakteri geçemez.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş olamaz.")]
        [MinLength(3, ErrorMessage = "Soyad alanı en az 3 karakter olabilir.")]
        public string LastName { get; set; }

        [Range(18,40, ErrorMessage = "Yaş değeri en az 18 en fazla 40 olabilir.")]
        public int Age { get; set; }
    }
}