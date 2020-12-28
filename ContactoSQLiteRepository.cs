using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testx.Models;
using Microsoft.EntityFrameworkCore.Sqlite;
using projecto_incidencias.Models;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;



namespace testx
{
    public class ContactoSQLiteRepository
    {
        public readonly string connection;


        public ContactoSQLiteRepository(string Connstr)
        {
            connection = Connstr;


        }

       
          public bool Actualizar_Prospecto(prospecto co , int id)
        {
           
            
            var cmd = new SqliteCommand("UPDATE PROSPECTO SET " + " NOMBRE = @NOMBRE, " +
                "PRIMER_APELLIDO =  @PRIMER_APELLIDO ,SEGUNDO_APELLIDO = @SEGUNDO_APELLIDO ,CALLE = @CALLE ,NUMERO = @NUMERO ,COLONIA = @COLONIA ,CODIGO_POSTAL = @CODIGO_POSTAL ,TELEFONO = @TELEFONO ,RFC = @RFC  WHERE ID = " + id);

            cmd.Parameters.AddWithValue("@NOMBRE", co.NOMBRE); 
            cmd.Parameters.AddWithValue("@PRIMER_APELLIDO", co.PRIMER_APELLIDO); 
            cmd.Parameters.AddWithValue("@SEGUNDO_APELLIDO", co.SEGUNDO_APELLIDO);
            cmd.Parameters.AddWithValue("@CALLE", co.CALLE);
            cmd.Parameters.AddWithValue("@NUMERO", co.NUMERO); 
            cmd.Parameters.AddWithValue("@COLONIA", co.COLONIA); 
            cmd.Parameters.AddWithValue("@CODIGO_POSTAL", co.CODIGO_POSTAL); 
            cmd.Parameters.AddWithValue("@TELEFONO", co.TELEFONO);
            cmd.Parameters.AddWithValue("@RFC", co.RFC);



            executeCMD(cmd);
            return true;
        }




        public bool Actualizar_Doc(Documento co, int id)
        {

            var cmd = new SqliteCommand("UPDATE DOCUMENTO SET ID = @ID ,ID2  = @ID2 ,NOMBRE_DEL_DOCUMENTO = @NOMBRE_DEL_DOCUMENTO ,NOMBRE = @NOMBRE ,PRIMER_APELLIDO = @PRIMER_APELLIDO ,SEGUNDO_APELLIDO = @SEGUNDO_APELLIDO ,ESTATUS = @ESTATUS ,CALLE = @CALLE ,NUMERO  = @NUMERO ,COLONIA = @COLONIA ,CODIGO_POSTAL = @CODIGO_POSTAL ,TELEFONO = @TELEFONO ,RFC = @RFC ,OBSERVACIONES = @OBSERVACIONES WHERE ID2 = " + id);

            cmd.Parameters.AddWithValue("@ID", co.ID);
            cmd.Parameters.AddWithValue("@ID2", co.ID2);
            cmd.Parameters.AddWithValue("@NOMBRE_DEL_DOCUMENTO", co.NOMBRE_DEL_DOCUMENTO);
            cmd.Parameters.AddWithValue("@NOMBRE", co.NOMBRE);
            cmd.Parameters.AddWithValue("@PRIMER_APELLIDO", co.PRIMER_APELLIDO);
            cmd.Parameters.AddWithValue("@SEGUNDO_APELLIDO", co.SEGUNDO_APELLIDO);
            cmd.Parameters.AddWithValue("@ESTATUS", co.ESTATUS);
            cmd.Parameters.AddWithValue("@CALLE", co.CALLE);
            cmd.Parameters.AddWithValue("@NUMERO", co.NUMERO);
            cmd.Parameters.AddWithValue("@COLONIA", co.COLONIA);
            cmd.Parameters.AddWithValue("@CODIGO_POSTAL", co.CODIGO_POSTAL);
            cmd.Parameters.AddWithValue("@TELEFONO", co.TELEFONO );
            cmd.Parameters.AddWithValue("@RFC", co.RFC);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", co.OBSERVACIONES);

            executeCMD(cmd);
            return true;
        }
      
        public int executeCMD(SqliteCommand cmd)
        {

            using (var con = new SqliteConnection(connection))
            {
                cmd.Connection = con;
                cmd.Connection.Open();
                
                var inserted = cmd.ExecuteNonQuery();

                return inserted;

            }
        }


        

        public bool CrearProspecto(prospecto model)
        {
            var cmd = new SqliteCommand("INSERT INTO PROSPECTO (ID,NOMBRE,PRIMER_APELLIDO,SEGUNDO_APELLIDO,CALLE,NUMERO,COLONIA,CODIGO_POSTAL,TELEFONO,RFC) VALUES (@ID,@NOMBRE,@PRIMER_APELLIDO,@SEGUNDO_APELLIDO,@CALLE,@NUMERO,@COLONIA,@CODIGO_POSTAL,@TELEFONO,@RFC)");
            cmd.Parameters.AddWithValue("@ID", model.ID);
            cmd.Parameters.AddWithValue("@NOMBRE",model.NOMBRE);
            cmd.Parameters.AddWithValue("@PRIMER_APELLIDO", model.PRIMER_APELLIDO);
            cmd.Parameters.AddWithValue("@SEGUNDO_APELLIDO", model.SEGUNDO_APELLIDO);
            cmd.Parameters.AddWithValue("@CALLE",model.CALLE);
            cmd.Parameters.AddWithValue("@NUMERO",model.NUMERO);
            cmd.Parameters.AddWithValue("@COLONIA",model.COLONIA);
            cmd.Parameters.AddWithValue("@CODIGO_POSTAL",model.CODIGO_POSTAL);
            cmd.Parameters.AddWithValue("@TELEFONO",model.TELEFONO);
            cmd.Parameters.AddWithValue("@RFC",model.RFC);



            executeCMD(cmd);
            return true;
        }

       

        public bool CrearDocumento(Documento model)
        {

           
            var cmd = new SqliteCommand("INSERT INTO DOCUMENTO (ID,ID2,NOMBRE_DEL_DOCUMENTO,NOMBRE,PRIMER_APELLIDO,SEGUNDO_APELLIDO,ESTATUS,CALLE,NUMERO,COLONIA,CODIGO_POSTAL,TELEFONO,RFC,OBSERVACIONES) VALUES (@ID,@ID2,@NOMBRE_DEL_DOCUMENTO,@NOMBRE,@PRIMER_APELLIDO,@SEGUNDO_APELLIDO,@ESTATUS,@CALLE,@NUMERO,@COLONIA,@CODIGO_POSTAL,@TELEFONO,@RFC,@OBSERVACIONES )");
            cmd.Parameters.AddWithValue("@ID", model.ID);
            cmd.Parameters.AddWithValue("@ID2", model.ID2);
            cmd.Parameters.AddWithValue("@NOMBRE_DEL_DOCUMENTO", model.NOMBRE_DEL_DOCUMENTO);
            cmd.Parameters.AddWithValue("@NOMBRE", model.NOMBRE);
            cmd.Parameters.AddWithValue("@PRIMER_APELLIDO", model.PRIMER_APELLIDO);
            cmd.Parameters.AddWithValue("@SEGUNDO_APELLIDO", model.SEGUNDO_APELLIDO);
            cmd.Parameters.AddWithValue("@ESTATUS", model.ESTATUS);
            cmd.Parameters.AddWithValue("@CALLE", model.CALLE);
            cmd.Parameters.AddWithValue("@NUMERO", model.NUMERO);
            cmd.Parameters.AddWithValue("@COLONIA", model.COLONIA);
            cmd.Parameters.AddWithValue("@CODIGO_POSTAL", model.CODIGO_POSTAL);
            cmd.Parameters.AddWithValue("@TELEFONO", model.TELEFONO);
            cmd.Parameters.AddWithValue("@RFC", model.RFC);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", model.OBSERVACIONES);

            executeCMD(cmd);
            return true;
        }


      
       
private const string SELECTDOCUMENTOS = "SELECT  ID ,ID2,NOMBRE_DEL_DOCUMENTO,NOMBRE,PRIMER_APELLIDO,SEGUNDO_APELLIDO,ESTATUS,CALLE,NUMERO,COLONIA , CODIGO_POSTAL ,TELEFONO ,RFC ,OBSERVACIONES FROM DOCUMENTO";
       

        private const string SELECTPROSPECTO = "SELECT  ID,NOMBRE,PRIMER_APELLIDO,SEGUNDO_APELLIDO,CALLE,NUMERO,COLONIA , CODIGO_POSTAL ,TELEFONO ,RFC FROM PROSPECTO";
     
 
        


        public List<Documento> LeerDocumentos()
        {

            var cmd = new SqliteCommand(SELECTDOCUMENTOS);
            var documento = new List<Documento>();
            using (var con = new SqliteConnection(connection))
            {
                /* try
                 {
                 */
                cmd.Connection = con;
                cmd.Connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Documento = ParseDocumento(reader);
                        documento.Add(Documento);

                    }
                }
                /*
                   }
                   catch (Exception)
                   {


                   }
              */
            }
            return documento;
        }

        public List<prospecto> LeerProspecto()
        {

            var cmd = new SqliteCommand(SELECTPROSPECTO);
            var Prospecto = new List<prospecto>();
            using (var con = new SqliteConnection(connection))
            {
                /* try
                 {
                 */
                cmd.Connection = con;
                cmd.Connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Prop = ParseProspecto(reader);
                        Prospecto.Add(Prop);

                    }
                }
                /*
                   }
                   catch (Exception)
                   {


                   }
              */
            }
            return Prospecto;
        }
       


        public Documento LeerDocPorId(int id)
        {

            var cmd = new SqliteCommand(SELECTDOCUMENTOS+ " WHERE ID2  = @id");
            cmd.Parameters.AddWithValue("@id", id);
            using (var con = new SqliteConnection(connection))
            {

                cmd.Connection = con;
                cmd.Connection.Open();

                using (var reader = cmd.ExecuteReader())
                {



                    if (reader.Read())
                    {

                        var usuario = ParseDocumento(reader);

                        return usuario;

                    }
                    else
                    {
                        return null;
                    }
                }
            }



        }

        public prospecto LeerProspectoPorId(int id)
        {

            var cmd = new SqliteCommand(SELECTPROSPECTO + " WHERE ID  = @id");
            cmd.Parameters.AddWithValue("@id", id);
            using (var con = new SqliteConnection(connection))
            {

                cmd.Connection = con;
                cmd.Connection.Open();

                using (var reader = cmd.ExecuteReader())
                {



                    if (reader.Read())
                    {

                        var Props = ParseProspecto(reader);

                        return Props;

                    }
                    else
                    {
                        return null;
                    }
                }
            }



        }
       


        private Documento ParseDocumento(SqliteDataReader reader)
        {
            var contacto = new Documento();
            var i = 0;
            unchecked
            {
                contacto.ID = (int)reader.GetInt64(i++);
                contacto.ID2 = (int)reader.GetInt64(i++);
                contacto.NOMBRE_DEL_DOCUMENTO = reader.GetString(i++);
                contacto.NOMBRE = reader.GetString(i++);
                contacto.PRIMER_APELLIDO = reader.GetString(i++);
                contacto.SEGUNDO_APELLIDO = reader.GetString(i++);
                contacto.ESTATUS = reader.GetString(i++);
                contacto.CALLE = reader.GetString(i++);
                contacto.NUMERO = (int)reader.GetInt64(i++);
                contacto.COLONIA = reader.GetString(i++);
                contacto.CODIGO_POSTAL = reader.GetString(i++);
                contacto.TELEFONO = (int)reader.GetInt64(i++);
                contacto.RFC = reader.GetString(i++);
                contacto.OBSERVACIONES = reader.GetString(i++);

                return contacto;


            }










        }

        private prospecto  ParseProspecto(SqliteDataReader reader)
        {
            var contacto = new prospecto();
            var i = 0;
            unchecked
            {
                contacto.ID = (int)reader.GetInt64(i++);
                contacto.NOMBRE = reader.GetString(i++);
                contacto.PRIMER_APELLIDO = reader.GetString(i++);
                contacto.SEGUNDO_APELLIDO = reader.GetString(i++);
                contacto.CALLE = reader.GetString(i++);
                contacto.NUMERO = (int)reader.GetInt64(i++);
                contacto.COLONIA = reader.GetString(i++);
                contacto.CODIGO_POSTAL = reader.GetString(i++);
                contacto.TELEFONO = (int)reader.GetInt64(i++);
                contacto.RFC = reader.GetString(i++);


                return contacto;

            }










        }
    }

}