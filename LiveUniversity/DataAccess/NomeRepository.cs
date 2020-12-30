using LiveUniversity.Business.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiveUniversity.DataAccess
{
    public class NomeRepository : RepositoryBase<NomeModel>, IRepository<NomeModel>, IConsultaRepository<NomeModel>
    {

        public void Create(NomeModel Nome)
        {

            
            string procedure = "SP_CREATE_TBS_NOME";



            // Create ADO.NET objects.

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(procedure, con);



            // Configure command and add input parameters.

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;



            param = cmd.Parameters.Add("@Nome", SqlDbType.NVarChar, 100);
            param.Value = Nome.Nome;



            param = cmd.Parameters.Add("@Cod", SqlDbType.BigInt);

            param.Value = Nome.Cod;


            // Add the output parameter.

            param = cmd.Parameters.Add("@NomeId", SqlDbType.Int);

            param.Direction = ParameterDirection.Output;



            // Execute the command.

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();


            Nome.Id = (param.Value as int?).GetValueOrDefault();



        }

        public NomeModel Obter(long cod)
        {

            string procedure = "SP_OBTER_TBS_NOME";



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
            NomeModel nome = new NomeModel();

            // Call Read before accessing data.
            if (reader.Read())
            {
                nome.Id = Convert.ToInt32(reader["id"]);
                nome.Cod = Convert.ToInt64(reader["cod"]);
                nome.Nome = Convert.ToString(reader["nome"]);
                nome.Soma = Convert.ToInt32(reader["soma"]);
            }

            // Call Close when done reading.
            reader.Close();
            return nome;
        }

        public IEnumerable<NomeModel> Obter()
        {
            throw new NotImplementedException();
        }
    }
}