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
        void CreateAccount(string Name, string Emailadress, string Password);
        int GetContactIdByMail(string Emailaddress);
        IEnumerable<Accounts> GetAllAccount();

        Accounts GetAccountById(int Id);
        Accounts GetAccountByAccountId(int id);
    }
}
    public class DbAccountRepository : IAccountRepository
    {


    private ModelContainer ctx = new ModelContainer();

    public void CreateAccount(string Name, string Emailadress, string Password)
    {
        Accounts account = new Accounts();
        account.email = Emailadress;
        account.firstName = Name;
        account.password = Password;
        ctx.AccountSet.Add(account);
        ctx.SaveChanges();
    }

    public Accounts GetAccount(string emailAddress, string password)
    {
        Accounts account;
        account = ctx.AccountSet.SingleOrDefault(a => a.email == emailAddress && a.password == password);
        return account;
    }

    public Accounts GetAccountByAccountId(int id)
    {
        Accounts account = ctx.AccountSet.Find(id);
        return account;
    }

   public Accounts GetAccountById(int id)
    {
       Persons person;
       person = ctx.AccountSet.Find(id);

       Accounts account = new Accounts();
        if (person != null)
        {
     //      account = ctx.AccountSet.Find(person.ContactAccountId);
        }

        return account;
    }

    public IEnumerable<Accounts> GetAllAccount()
    {
        IEnumerable<Accounts> AllAccounts = ctx.AccountSet.Select(A => A);
        return AllAccounts;
    }

    public int GetContactIdByMail(string Emailaddress)
    {
        Accounts account;
        account = ctx.AccountSet.SingleOrDefault(c => c.email == Emailaddress);
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

