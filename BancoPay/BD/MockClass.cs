using BancoPay.Models;

namespace BancoPay.BD
{
    class MockClass
    {
        public static List<Users> MockUsers()
        {
            List<Users> users = new List<Users>
            {
                new Users(1, "Lucas", "lucaslpbs", "senha123", "emailteste@teste.com", "01598065871"),
                new Users(1, "Gabriel", "gabrielgpbs", "senha123", "emailteste@teste.com", "98065087541")
            };
            MockConta(users);

            return users;
        }

        public static void MockConta(List<Users> users)
        {

            ContaCorrente contaCorrente = new ContaCorrente();
            contaCorrente.NumeroConta = 123;
            contaCorrente.SaldoConta = 2000;
            contaCorrente.TaxaSaque = 5.3f;
            contaCorrente.TipoConta = Enums.ETipoConta.ContaCorrente;

            ContaPoupanca contaPoupanca = new ContaPoupanca();
            contaPoupanca.NumeroConta = 1234;
            contaPoupanca.SaldoConta = 3000;
            contaPoupanca.CreditoConta = 100f;
            contaPoupanca.TipoConta = Enums.ETipoConta.ContaPoupanca;

            foreach (var user in users)
            {

                user.Contas.Add(contaCorrente);

                user.Contas.Add(contaPoupanca);

                contaCorrente.NumeroConta += 1;
                contaPoupanca.NumeroConta +=1;
            }
        }
    }
}
