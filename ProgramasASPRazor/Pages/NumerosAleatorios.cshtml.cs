using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Reflection;

namespace ProgramasASPRazor.Pages
{
    public class NumerosAleatoriosModel : PageModel
    {
        public required List<int> ListaNumeros { get; set; }
        public required List<int> ListaNumerosOrdenada { get; set; }
        public int Suma { get; set; }
        public double Promedio { get; set; }
        public required List<int> Moda { get; set; }
        public double Mediana { get; set; }
        public int contador { get; set; }
        public void OnGet()
        {
        }

        public void OnPost() 
        { 
            ListaNumeros = new List<int>();
            ListaNumerosOrdenada = new List<int>();
            Moda = new List<int>();

            for (int i = 0; i < 20; i++)
            {
                int numero = new Random().Next(0,100);
                ListaNumeros.Add(numero);
                ListaNumerosOrdenada.Add(numero);
            }

            Suma = ListaNumeros.Sum();
            Promedio = ListaNumeros.Average();
            ListaNumerosOrdenada.Sort();

            Moda = ListaNumerosOrdenada.GroupBy(x => x).Where(g => g.Count() > 1).Select(x => x.Key).ToList();
            contador = Moda.Count;

            int mitad = ListaNumerosOrdenada.Count / 2;
            Mediana = (ListaNumerosOrdenada[mitad - 1] + ListaNumerosOrdenada[mitad])/2;
        }
    }
}