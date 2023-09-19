using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ProgramasASPRazor.Pages
{
    public class CifradoCesarModel : PageModel
    {
        [BindProperty]
        public string Mensaje { get; set; }

        [BindProperty]
        public int Desplazamiento { get; set; }

        [BindProperty]
        public string Accion { get; set; }

        public string Resultado { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            Resultado = RealizarAccionCesar(Mensaje, Desplazamiento, Accion);
        }

        private string RealizarAccionCesar(string mensaje, int desplazamiento, string accion)
        {
            char[] chars = mensaje.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];

                if (char.IsLetter(c))
                {
                    char baseChar = char.IsUpper(c) ? 'A' : 'a';
                    int offset = accion == "codificar" ? desplazamiento : 26 - desplazamiento;
                    chars[i] = (char)(baseChar + (c - baseChar + offset) % 26);
                }
            }

            return new string(chars);
        }
    }
}