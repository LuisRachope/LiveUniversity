using LiveUniversity.Business.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiveUniversity.DataAccess
{
    public class PaisRepository : RepositoryBase<PaisModel>, IConsultaRepository<PaisModel>
    {
        public PaisModel Obter(long cod)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaisModel> Obter()
        {

            string procedure = "SP_OBTER_TBS_PAISES";

            // Create ADO.NET objects.

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(procedure, con);


            // Configure command and add input parameters.

            cmd.CommandType = CommandType.StoredProcedure;

            // Execute the command.

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<PaisModel> paises = new List<PaisModel>();

            // Call Read before accessing data.
            while (reader.Read())
            {
                var pais = new PaisModel();
                pais.Id = Convert.ToInt32(reader["id"]);
                pais.Pais = Convert.ToString(reader["pais"]);
                pais.Total = Convert.ToInt64(reader["total"]);
                paises.Add(pais);
            }

            // Call Close when done reading.
            reader.Close();
            return paises;
        }
    }
}