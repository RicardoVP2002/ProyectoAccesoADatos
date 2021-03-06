﻿using System;

using System.Collections.Generic;

using System.Text;

using System.Data;

using System.Data.SqlClient;



namespace CapaDatos

{

    public static class MateriaDAO

    {

        
        //DAO Data Access Object
        private static String cadenaConexion = @"server=PC; database=Materias; integrated security=true";

        public static int crear(Materia materia)
        {
            //Agregar estudiantes en la BDD
            //1. Establecer conexión con el servidor de BDD
            string cadenaConexion = @"server=PC; database=Materias; integrated security=true";

            //objeto tipo Conexión para conectarse al servidor
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            //2. Definir operación sobre la bdd (insertar)
            string sql = "insert into Materias(codMat, nombreMateria, nivel, carrera)" +
                " values(@codMat, @nombreMateria, @nivel, @carrera)";

            //Definir un objeto de la clase Command para ejecutar la sentencia sql que hemos creado
            SqlCommand comando = new SqlCommand(sql, conexion);

            //Definir parámetros
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@codMat", materia.CodMat);
            comando.Parameters.AddWithValue("@nombreMateria", materia.NombreMateria);
            comando.Parameters.AddWithValue("@nivel", materia.Nivel);
            comando.Parameters.AddWithValue("@carrera", materia.Carrera);
            

            //3. Abrir la conexión y ejecutar el comando
            conexion.Open();
            int x = comando.ExecuteNonQuery();
            //4. Cerrar la conexión
            conexion.Close();

            return x;
        }

        public static int actualizar(Materia materia)
        {
            //Agregar estudiantes en la BDD
            //1. Establecer conexión con el servidor de BDD
            string cadenaConexion = @"server=PC; database=Materias; integrated security=true";

            //objeto tipo Conexión para conectarse al servidor
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            //2. Definir operación sobre la bdd (insertar)
            string sql = "update Materias set codMat=@codMat, nombreMateria=@nombreMateria, nivel=@nivel, carrera=@carrera" +
                " where codMat=@codMat";

            //Definir un objeto de la clase Command para ejecutar la sentencia sql que hemos creado
            SqlCommand comando = new SqlCommand(sql, conexion);

            //Definir parámetros
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@codMat", materia.CodMat);
            comando.Parameters.AddWithValue("@nombreMateria", materia.NombreMateria);
            comando.Parameters.AddWithValue("@nivel", materia.Nivel);
            comando.Parameters.AddWithValue("@carrera", materia.Carrera);


            //3. Abrir la conexión y ejecutar el comando
            conexion.Open();
            int x = comando.ExecuteNonQuery();
            //4. Cerrar la conexión
            conexion.Close();

            return x;
        }

        public static int eliminar(String CodMat)
        {
            //Agregar estudiantes en la BDD
            //1. Establecer conexión con el servidor de BDD
            string cadenaConexion = @"server=PC; database=Materias; integrated security=true";

            //objeto tipo Conexión para conectarse al servidor
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            //2. Definir operación sobre la bdd (insertar)
            string sql = "delete from Materias" +
                " where codMat=@codMat";

            //Definir un objeto de la clase Command para ejecutar la sentencia sql que hemos creado
            SqlCommand comando = new SqlCommand(sql, conexion);

            //Definir parámetros
            comando.CommandType = CommandType.Text;
            comando.Parameters.AddWithValue("@codMat", CodMat);


            //3. Abrir la conexión y ejecutar el comando
            conexion.Open();
            int x = comando.ExecuteNonQuery();
            //4. Cerrar la conexión
            conexion.Close();

            return x;
        }

        public static DataTable GetAll()

        {

            //1. Establecer conexión con el servidor de BDD



            //autenticación sql server

            //string cadenaConexion = @"server=A-SIS-0KP\SQLEXPRESS2016; database=Estudiantes; user id=sa; pwd=isa";



            //autenticación con el usuario de windows

            string cadenaConexion = @"server=PC; database=Materias; integrated security=true";



            //objeto tipo Conexión para conectarse al servidor

            SqlConnection conexion = new SqlConnection(cadenaConexion);



            //2. definir la operación a realizar en el servidor

            //operación: obtener todos los registros

            //sql (lenguaje estructurado de consultas)

            string sql = "select codMat as Código, nombreMateria as Materia, nivel as Nivel, carrera as Carrera" +
                " from Materias";

                

            //definir un adaptador de datos: es un puente que permite pasar los datos de la BDD hacia el datatable

            SqlDataAdapter ad = new SqlDataAdapter(sql, conexion);



            //3. recuperamos los datos

            DataTable dt = new DataTable();

            ad.Fill(dt);//desde el adaptador paso los datos al datatable

            return dt;

        }

        public static Materia GetMateria(String nombreMateria)

        {

            //1. Establecer conexión con el servidor de BDD



            //autenticación sql server

            //string cadenaConexion = @"server=A-SIS-0KP\SQLEXPRESS2016; database=Estudiantes; user id=sa; pwd=isa";



            //autenticación con el usuario de windows



            //objeto tipo Conexión para conectarse al servidor

            SqlConnection conexion = new SqlConnection(cadenaConexion);



            //2. definir la operación a realizar en el servidor

            //operación: obtener todos los registros

            //sql (lenguaje estructurado de consultas)

            string sql = "select codMat, nombreMateria, nivel, carrera " +
                "from Materias " +
                "where nombreMateria=@nombreMateria";

            //definir un adaptador de datos: es un puente que permite pasar los datos de la BDD hacia el datatable

            SqlDataAdapter ad = new SqlDataAdapter(sql, conexion);

            //pasar el parámetro
            ad.SelectCommand.Parameters.AddWithValue("@nombreMateria", nombreMateria);


            //3. recuperamos los datos

            DataTable dt = new DataTable();

            ad.Fill(dt);//desde el adaptador paso los datos al datatable

            Materia m = new Materia();
            //Encerar valores
            m.CodMat = "";
            m.NombreMateria= "";
            m.Nivel = "";
            m.Carrera = "";
            //recorrer el datatable
            foreach (DataRow fila in dt.Rows)
            {
                m.CodMat = fila["codMat"].ToString();
                m.NombreMateria = fila["nombreMateria"].ToString();
                m.Nivel = fila["nivel"].ToString();
                m.Carrera = fila["carrera"].ToString();
                break; //abandona el for
            }

            return m;

        }

    }

}