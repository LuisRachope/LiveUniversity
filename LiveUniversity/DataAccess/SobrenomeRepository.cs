using LiveUniversity.Business.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiveUniversity.DataAccess
{
    public class SobrenomeRepository : RepositoryBase<NomeModel>, IRepository<SobrenomeModel>, IConsultaRepository<SobrenomeModel>
    {
        public void Create(SobrenomeModel Sobrenome)
        {


            string procedure = "SP_CREATE_TBS_SOBRENOME";



            // Create ADO.NET objects.

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(procedure, con);



            // Configure command and add input parameters.

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;



            param = cmd.Parameters.Add("@Sobrenome", SqlDbType.NVarChar, 100);
            param.Value = Sobrenome.Sobrenome;



            param = cmd.Parameters.Add("@Cod", SqlDbType.BigInt);

            param.Value = Sobrenome.Cod;


            // Add the output parameter.

            param = cmd.Parameters.Add("@SobrenomeId", SqlDbType.Int);

            param.Direction = ParameterDirection.Output;



            // Execute the command.

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();


            Sobrenome.Id = (param.Value as int?).GetValueOrDefault();



        }

        public SobrenomeModel Obter(long cod)
        {

            string procedure = "SP_OBTER_TBS_SOBRENOME";



            // Create ADO.NET objects.

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(procedure, con);



            // Configure command and add input parameters.

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;


            param = cmd.Parameters.Add("@Cod", SqlDbType.BigInt);

            param.Value = cod;


            // Execute the command.

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            SobrenomeModel sobrenome = new SobrenomeModel();

            // Call Read before accessing data.
            if (reader.Read())
            {
                sobrenome.Id = Convert.ToInt32(reader["id"]);
                sobrenome.Cod = Convert.ToInt64(reader["cod"]);
                sobrenome.Sobrenome = Convert.ToString(reader["sobrenome"]);
                sobrenome.Soma = Convert.ToInt32(reader["soma"]);
            }

            // Call Close when done reading.
            reader.Close();
            return sobrenome;
        }

        public IEnumerable<SobrenomeModel> Obter()
        {
            throw new NotImplementedException();
        }
    }
}