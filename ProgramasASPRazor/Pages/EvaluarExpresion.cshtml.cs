using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProgramasASPRazor.Pages
{
    public class EvaluarExpresionModel : PageModel
    {
        [BindProperty]
        public int A { get; set; } = 0;
        [BindProperty]
        public int B { get; set; } = 0;
        [BindProperty]
        public int X { get; set; } = 0;
        [BindProperty]
        public int Y { get; set; } = 0;
        [BindProperty]
        public int N { get; set; } = 0;

        public double solucionD, solucionI = 0;
        public required List<double> ListaIteraciones { get; set; }
        public string Cadena { get; set; } = "";

        public void OnPost()
        {
            ListaIteraciones = new List<double>();
            solucionD = Math.Pow(((A * X) + (B * Y)), N);

            for (int k = 0; k <= N; k++)
            {
                double op1 = FunKN(N, k) * (Math.Pow((A * X), (N - k)) * (Math.Pow((B * Y), k)));
                solucionI += op1;
                ListaIteraciones.Add(op1);
            }

            Cadena = string.Join("+", ListaIteraciones);
        }

        public double Fact(int num)
        {
            int fact = 1;
            for (int i = 1; i <= num; i++)
            {
                fact *= i;
            }
            return fact;
        }

        public double FunKN(int n, int k)
        {
            double r = Fact(n) / (Fact(k) * Fact(n - k));
            return r;
        }
    }
}
