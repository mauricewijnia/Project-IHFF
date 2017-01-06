using Project_IHFF.Models;
using Project_IHFF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_IHFF.Repositories
{
    interface IAccountRepository
    {
        Accounts GetAccount(string emailAddress, string password);
        void CreateAccount(string firstName, string LastName, string phoneNumber, string Emailadress, string Password);
        int GetContactIdByMail(string Emailaddress);
        IEnumerable<Accounts> GetAllAccount();

        Accounts GetAccountById(int Id);
        Accounts GetAccountByAccountId(int id);
    }
}
    public class DbAccountRepository : IAccountRepository
    {


    private ModelContainer ctx = new ModelContainer();

    public void CreateAccount(string firstName, string lastName, string phoneNumber, string Emailadress, string Password)
    {
        Accounts account = new Accounts();
        account.firstName = firstName;
        account.lastName = lastName;
        account.phoneNumber = phoneNumber;
        account.email = Emailadress;
        account.password = Password;
        ctx.Accounts.Add(account);
        ctx.SaveChanges();
    }

    public Accounts GetAccount(string emailAddress, string password)
    {
        Accounts account;
        account = ctx.Accounts.SingleOrDefault(a => a.email == emailAddress && a.password == password);
        return account;
    }

    public Accounts GetAccountByAccountId(int id)
    {
        Accounts account = ctx.Accounts.Find(id);
        return account;
    }

   public Accounts GetAccountById(int id)
    {
       Persons person;
       person = ctx.Accounts.Find(id);

       Accounts account = new Accounts();
        if (person != null)
        {
          account = ctx.Accounts.Find(person.id);
        }

        return account;
    }

    public IEnumerable<Accounts> GetAllAccount()
    {
        IEnumerable<Accounts> AllAccounts = ctx.Accounts.Select(A => A);
        return AllAccounts;
    }

    public int GetContactIdByMail(string Emailaddress)
    {
        Accounts account;
        account = ctx.Accounts.SingleOrDefault(c => c.email == Emailaddress);
        if (account != null)
        {
            return account.id;
        }
        else
        {
            int i = -1;
            return i;
        }
    }
}

