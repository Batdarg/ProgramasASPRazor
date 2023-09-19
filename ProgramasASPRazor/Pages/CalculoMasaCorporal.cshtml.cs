using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ProgramasASPRazor.Pages
{
    public class CalculoMasaCorporalModel : PageModel
    {
        [BindProperty]
        public double Peso{ get; set; } = 0;
        [BindProperty]
        public double Altura{ get; set; } = 0;
        
        public double calculoIMC = 0;

        public string mensaje = "";

        public string error = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            calculoIMC = Math.Round((Peso/Math.Pow(Altura,2)),2);

            mensaje += "Para la información que ingresó: " + " Peso: " + Peso + " kg" + ", Altura: " + Altura + " m." +
                       " Su IMC es: " + calculoIMC + ", lo que indica que su peso esta en la categoría de: "; 

            ModelState.Clear();
        }
    }
}
