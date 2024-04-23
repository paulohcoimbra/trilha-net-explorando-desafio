namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            bool excedeCapacidadeDeHospedes = Suite.Capacidade < hospedes.Count();

            if (excedeCapacidadeDeHospedes)
                throw new Exception("A quantidae de hóspedes não pode exceder a capacidade da suíte");

            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count();
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;
            bool elegivelParaDesconto = DiasReservados >= 10;

            if (elegivelParaDesconto)
                valor*= 0.90M;

            return valor;
        }
    }
}