using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace LibreriaClases1
{
    public class Utilidades
    {
        public static DataSet EjecutarSQL(string cmd) {
            //Data Source=SERVIDOR;Initial Catalog=BASE_DATOS;User ID=sa;Password=PasswordO1.;MultipleActiveResultSets=True;Connect Timeout=100;Encrypt=False;Application Name=MyApp;Current Language=spanish
            //Data Source=SRVINCC;Initial Catalog=DM_COMERCIO_CN;User ID=GEN_DM_COMERCIO_CN_RW;Password=***********
            String server = "MJPA" + "\\PIVA";
                SqlConnection Con = new SqlConnection("Data Source =" + server + "; Initial Catalog = SISTEMAS; Integrated Security = True");
                Con.Open();

                DataSet DS = new DataSet();
                SqlDataAdapter DP = new SqlDataAdapter(cmd, Con);
                DP.Fill(DS);
                Con.Close();


                return DS;
           
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            StringBuilder sb = new StringBuilder();
            byte[] stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }




    }
}
