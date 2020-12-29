using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MePostWebApp.Models
{
    public class Calculate
    { 
        public static List<AramexWS.Table> GetTeable()
        {
            var res = Misc.WsAramexUZ.GetList();
            return res.ToList();
        }
        public static double Calc(Poster poster)
        { 
            var res = Misc.WsAramexUZ.Calculate(poster.Country, poster.Length, poster.Width, poster.Height, poster.Weight, poster.Type);
            return res;
        }
    }
    public class Poster
    {
        [Required]
        [Display(Name = "Страна")]
        public string Country { get; set; }
        [Required]
        [Display(Name = "Тип")]
        public string Type { get; set; }
        [Required]
        [Display(Name = "Ширина")]
        [Range(typeof(decimal), "1,01", "1000,01", ErrorMessage = "Наименьший ширина груза - 1,01 см, в качестве разделителя дробной и целой части используется запятая")]
        public double Length { get; set; }
        [Required]
        [Display(Name = "Длина")]
        [Range(typeof(decimal), "1,01", "1000,01", ErrorMessage = "Наименьший длина груза - 1,01 кг, в качестве разделителя дробной и целой части используется запятая")]
        public double Width { get; set; }
        [Required]
        [Display(Name = "Высота")]
        [Range(typeof(decimal), "0,1", "1000,01", ErrorMessage = "Наименьший высота груза - 0,1 кг, в качестве разделителя дробной и целой части используется запятая")]
        public double Height { get; set; }
        [Required]
        [Display(Name = "Вес")]
        [Range(typeof(decimal), "0,01", "1000,01", ErrorMessage = "Наименьший вес груза - 0,01 кг, в качестве разделителя дробной и целой части используется запятая")]
        public double Weight { get; set; }

    }
}