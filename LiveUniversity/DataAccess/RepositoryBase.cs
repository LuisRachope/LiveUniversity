using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveUniversity.DataAccess
{
    public abstract class RepositoryBase<Tmodel>
    {
       protected readonly string connectionString = "Data Source=virtual2.febracorp.org.br;Initial Catalog=CONTOSO;User Id = user_trial; Password = 7412LIVE!@#$%¨&*();";

    }
}