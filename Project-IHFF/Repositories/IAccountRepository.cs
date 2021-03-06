﻿using Project_IHFF.Models;
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
        Accounts GetAccount(string emailAddress);
        void CreateAccount(string firstName, string lastName, string phoneNumber, string Emailadress, string Password);
        int GetContactIdByMail(string Emailaddress);
        IEnumerable<Accounts> GetAllAccount();

        Accounts GetAccountById(int Id);
        Accounts GetAccountByAccountId(int id);
        void CreateAccount(Accounts account);
    }
}
    public class DbAccountRepository : IAccountRepository
    {


    private ModelContainer ctx = new ModelContainer();

    public void CreateAccount(string firstName, string lastName, string phoneNumber, string email, string password)
    {
        Accounts account = new Accounts();
        account.firstName = firstName;
        account.lastName = lastName;
        account.phoneNumber = phoneNumber;
        account.email = email;
        account.password = password;
        ctx.Persons.Add(account);
        ctx.SaveChanges();
    }

    public Accounts GetAccount(string emailAddress)
    {
        Accounts account;
        account = ctx.Persons.OfType<Accounts>().SingleOrDefault(a => a.email == emailAddress);
        return account;
    }

    public void CreateAccount(Accounts account)
    {
        ctx.Persons.Add(account);
        ctx.SaveChanges();
    }
    /// 
    


    public Accounts GetAccountByAccountId(int id)
    {
        Accounts account = ctx.Persons.OfType<Accounts>().SingleOrDefault(x => x.id == id);
        return account;
    }

   public Accounts GetAccountById(int id)
    {
        Accounts account = ctx.Persons.OfType<Accounts>().SingleOrDefault(x => x.id == id);
        return account;
    }

    public IEnumerable<Accounts> GetAllAccount()
    {
        IEnumerable<Accounts> AllAccounts = ctx.Persons.OfType<Accounts>().ToList();
        return AllAccounts;
    }

    public int GetContactIdByMail(string Emailaddress)
    {
        Accounts account;
        account = ctx.Persons.OfType<Accounts>().SingleOrDefault(c => c.email == Emailaddress);
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

