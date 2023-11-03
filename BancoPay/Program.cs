
using BancoPay.BD;
using BancoPay.Enums;
using BancoPay.Models;


MenuPrincipal();

static void MenuPrincipal()
{
    Console.Clear();
    Console.WriteLine("==============");
    Console.WriteLine("Bem Vindos ao Banco Pay!!");
    Console.WriteLine("Oque deseja fazer inicialmente?");
    Console.WriteLine("1 - Login");
    Console.WriteLine("2 - Criar Conta");
    Console.WriteLine("==============");

    int escolhaTelaLogin = int.Parse(Console.ReadLine());
    if (escolhaTelaLogin == 1)
    {
        Login();
    }
}

static void Login()
{
    Console.Clear();
    Console.WriteLine("==============");
    Console.WriteLine("Digite Seu Login e Senha");
    Console.Write("Login: ");
    string login = Console.ReadLine();
    Console.Write("Senha: ");
    string senha = Console.ReadLine();
    Console.WriteLine("==============");

    Users usuarioValidado = ValidaUsuario(login, senha);

    if (usuarioValidado != null)
    {
        
        SelecaoConta(usuarioValidado);
    }
    else { Console.WriteLine("Login Inexistente"); }
}

static void SelecaoConta(Users users)
{
    Console.Clear();
    Console.WriteLine($"Bem vindo! {users.Nome}!!");

    Console.WriteLine("==========================");
    Console.WriteLine("Digite a conta que deseja utilizar");

    ContaCorrente contaCorrente = new();
    ContaPoupanca contaPoupanca = new();
    foreach (var conta in users.Contas)
    {
        if (conta.TipoConta == ETipoConta.ContaCorrente)
        {
            Console.Write("1 - Conta Corrente || ");
            contaCorrente = (ContaCorrente)conta;
        }
        if (conta.TipoConta == ETipoConta.ContaPoupanca)
        {

            contaPoupanca = (ContaPoupanca)conta;
            Console.Write("2 - Conta Poupança || ");
        }

        Console.WriteLine(conta.NumeroConta);
    }
    Console.WriteLine("==========================");
    int escolhaConta = int.Parse(Console.ReadLine());

    MenuHome(escolhaConta, users);

}

static void MenuHome(int escolhaConta, Users user)
{
    Console.WriteLine("============================");
    Console.WriteLine("1 - Sacar");
    Console.WriteLine("2 - Depositar");
    Console.WriteLine("3 - Relatório");
    Console.WriteLine("4 - Sair");
    Console.WriteLine("============================");

    int escolhaAcaoHome = int.Parse(Console.ReadLine());

    switch (escolhaAcaoHome)
    {
        case 1:
            Sacar(escolhaConta, user);
            break;
        default:
            break;
    }
}
static void Sacar(int escolhaConta, Users user)
{
    ContaCorrente contaCorrente = new();
    ContaPoupanca contaPoupanca = new();

    Console.WriteLine("============================");
    Console.WriteLine("Digite qual o valor que deseja sacar: ");
    Console.WriteLine("============================");

    float quantidadeSaque = float.Parse(Console.ReadLine());


    foreach (var conta in user.Contas)
    {
        if (conta.TipoConta == ETipoConta.ContaCorrente)
        {
            contaCorrente = (ContaCorrente)conta;
        }
        if (conta.TipoConta == ETipoConta.ContaPoupanca)
        {

            contaPoupanca = (ContaPoupanca)conta;
        }
    }

    if (escolhaConta == 1)
    {
        SaqueContaCorrente(contaCorrente, quantidadeSaque);
    }
    else
    {
        SaqueContaPoupanca(contaPoupanca, quantidadeSaque);
    }
}
static void SaqueContaCorrente(ContaCorrente contaCorrente, float quantidadeSaque)
{
    if (contaCorrente != null)
    {
        float totalSaque = quantidadeSaque + contaCorrente.TaxaSaque;
        if (totalSaque > contaCorrente.SaldoConta)
        {
            Console.WriteLine("Saldo Insuficiente! ");
        }
        else
        {
            contaCorrente.SaldoConta -= totalSaque;
            Console.WriteLine("Saque efetuado com sucesso! ");
            Console.WriteLine($"Seu saldo atual é de: {contaCorrente.SaldoConta}");
        }
    }
}
static void SaqueContaPoupanca(ContaPoupanca contaPoupanca, float quantidadeSaque)
{
    if (contaPoupanca != null)
    {
        float saldoTotalComCredito = contaPoupanca.SaldoConta + contaPoupanca.CreditoConta;
        if (quantidadeSaque <= contaPoupanca.SaldoConta)
        {
            //VAI FAZER A OPERAÇÃO DE SAQUE SEM PRECISAR DO CRÉDITO
            contaPoupanca.SaldoConta -= quantidadeSaque;
            Console.WriteLine("Saque efetuado com sucesso!");
            Console.WriteLine($"Seu saldo atual é de: {contaPoupanca.SaldoConta}");
        }
        else if (quantidadeSaque > contaPoupanca.SaldoConta && quantidadeSaque <= saldoTotalComCredito)
        {
            //VAI FAZER A OPERAÇÃO DE SAQUE USANDO O CRÉDITO
            contaPoupanca.SaldoConta -= quantidadeSaque;
            Console.WriteLine("Saque Efetuado com sucesso ultilizando crédito da poupança!");
            Console.WriteLine($"Seu saldo atual é de: {contaPoupanca.SaldoConta}");
        }
        else
        {
            Console.WriteLine("Saldo Insuficiente!");
        }
    }
}

static Users ValidaUsuario(string login, string senha)
{

    List<Users> users = MockClass.MockUsers();

    Users usuario = users.FirstOrDefault(w => w.Username.Equals(login));

    return usuario;
}

