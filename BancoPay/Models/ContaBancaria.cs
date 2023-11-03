using BancoPay.Enums;

namespace BancoPay.Models
{
    abstract class ContaBancaria
    {
        public int NumeroConta { get; set; }
        public float SaldoConta { get; set; }

        public ETipoConta TipoConta { get; set; }

    }
}
