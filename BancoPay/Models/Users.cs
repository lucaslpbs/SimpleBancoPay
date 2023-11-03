
using BancoPay.Models;

class Users
{
    public Users(int id, string nome, string userName, string password, string email, string cpf)
    {
        Id = id;
        Nome = nome;   
        Username = userName;
        Password = password;
        Email = email;
        Cpf = cpf;
        Contas = new List<ContaBancaria>();

    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Username { get; set; } 
    public string Password { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public List<ContaBancaria> Contas { get; set; }

}