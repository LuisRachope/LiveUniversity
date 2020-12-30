using LiveUniversity.Business.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiveUniversity.DataAccess
{
    public class CorRepository : RepositoryBase<CorModel>, IConsultaRepository<CorModel>
    {
        public CorModel Obter(long cod)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CorModel> Obter()
        {

            string procedure = "SP_OBTER_TBS_CORES";

            // Create ADO.NET objects.

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(procedure, con);


            // Configure command and add input parameters.

            cmd.CommandType = CommandType.StoredProcedure;

            // Execute the command.

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<CorModel> cores = new List<CorModel>();

            // Call Read before accessing data.
            while (reader.Read())
            {
                var cor = new CorModel();
                cor.Id = Convert.ToInt32(reader["id"]);
                cor.Cor = Convert.ToString(reader["cor"]);
                cor.Total = Convert.ToInt64(reader["total"]);
                cores.Add(cor);
            }

            // Call Close when done reading.
            reader.Close();
            return cores;
        }
    }
}