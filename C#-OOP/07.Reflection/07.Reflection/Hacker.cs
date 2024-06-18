using _02.CreateAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stealer;
[Author("George")]
public class Hacker: Object
{
    public string username = "securityGod82";
    private string password = "mySuperSecretPassw0rd";
   
    public string Password
    {
        get => this.password;
        set => this.password = value;
    }

    private int Id { get; set; }

    public double BankAccountBalance { get; private set; }
    [Author("George")]
    public void DownloadAllBankAccountsInTheWorld()
    {
    }
}


