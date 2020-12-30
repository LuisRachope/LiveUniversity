using LiveUniversity.Business.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiveUniversity.DataAccess
{
    public class AnimalRepository : RepositoryBase<AnimalModel>, IConsultaRepository<AnimalModel>
    {
        public AnimalModel Obter(long cod)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AnimalModel> Obter()
        {

            string procedure = "SP_OBTER_TBS_ANIMAIS";



            // Create ADO.NET objects.

            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand(procedure, con);


            // Configure command and add input parameters.

            cmd.CommandType = CommandType.StoredProcedure;

            // Execute the command.

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<AnimalModel> animais = new List<AnimalModel>();

            // Call Read before accessing data.
            while (reader.Read())
            {
                var animal = new AnimalModel();
                animal.Id = Convert.ToInt32(reader["id"]);
                animal.Animal = Convert.ToString(reader["animal"]);
                animal.Total = Convert.ToInt64(reader["total"]);
                animais.Add(animal);
            }

            // Call Close when done reading.
            reader.Close();
            return animais;
        }
    }
}