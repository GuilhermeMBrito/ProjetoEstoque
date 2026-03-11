using DBHandler.DBClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBServices.ServicesClass.Services
{
    public class DBService
    {
        protected DBConnection dbConnection { get; } = new DBConnection("data source=NEAT5;initial catalog=ProjetoEstoqueDB;Integrated Security=SSPI;TrustServerCertificate=True");
    }
}
