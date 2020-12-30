using LiveUniversity.Business.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiveUniversity.DataAccess
{
    public class EmailRepository : RepositoryBase<EmailModel>, IRepository<EmailModel>, IConsultaRepository<EmailModel>
    {
        public void Create(EmailModel Email)
        {


            string procedure = "SP_CREATE_TBS_EMAIL";



            // Create ADO.NET objects.

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(procedure, con);



            // Configure command and add input parameters.

            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter param;



            param = cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100);
            param.Value = Email.Email;



            param = cmd.Parameters.Add("@Cod", SqlDbType.BigInt);

            param.Value = Email.Cod;


            // Add the output parameter.

            param = cmd.Parameters.Add("@EmailId", SqlDbType.Int);

            param.Direction = ParameterDirection.Output;



            // Execute the command.

            con.Open();

            cmd.ExecuteNonQuery();

            con.Close();

            Email.Id = (param.Value as int?).GetValueOrDefault();

        }

        public EmailModel Obter(long cod)
        {

            string procedure = "SP_OBTER_TBS_EMAIL";



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
            EmailModel email = new EmailModel();

            // Call Read before accessing data.
            if (reader.Read())
            {
                email.Id = Convert.ToInt32(reader["id"]);
                email.Cod = Convert.ToInt64(reader["cod"]);
                email.Email = Convert.ToString(reader["email"]);
                email.Soma = Convert.ToInt64(reader["soma"]);
            }

            // Call Close when done reading.
            reader.Close();
            return email;
        }

        public IEnumerable<EmailModel> Obter()
        {
            throw new NotImplementedException();
        }
    }
}