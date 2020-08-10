using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConecionDB
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection coneccion = new SqlConnection("server=localhost; database=AdventureWorksDW2019; integrated security = true");
            coneccion.Open();
            Console.WriteLine("conexion establecida.");

            string consulta = " SELECT FirstName, MiddleName FROM DimCustomer ";

            SqlCommand comando = new SqlCommand(consulta, coneccion);
            SqlDataReader registro = comando.ExecuteReader();

            int i = 0;
            while (registro.Read() && i++ < 60)
            {
                string nombre = registro["FirstName"].ToString();
                string apellidos = registro["MiddleName"].ToString();
                Console.WriteLine(nombre+" "+apellidos);
            }
            Console.ReadKey();
            coneccion.Close();


        }
    }
}
