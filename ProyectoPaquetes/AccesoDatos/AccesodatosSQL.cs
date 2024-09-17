using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AccesodatosSQL
    {

        #region Atributos

        //Atributos de las cadenas de conexion, una con Windows Authentication (cadenaconexionWA)
        //Aqui se conectan con el app configuratio 
        private readonly string cadenaconexionSQL = ConfigurationManager.AppSettings["ConexionSQL"].ToString();
        private readonly string cadenaconexionWA = ConfigurationManager.AppSettings["ConexionWA"].ToString();

        //Objeto de Conexion brindado por system.data.sqlclient
        private SqlConnection objconexion;

        #endregion

        #region Constructor

        public AccesodatosSQL()
        {
            try
            {
                //Se inicializa el objeto conexión con la cadena construida
                //Aqui se conecta con el ddl de seguridad
                objconexion = new SqlConnection(Seguridad.Encriptacion.Desencriptar(cadenaconexionSQL));
                ABRIR(); //Aqui intenta abrir la conexión
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR(); //Aqui garantiza que la conexión se cierra
            }
        }

        #endregion

        #region Metodos

        #region Privados

        private void ABRIR()
        {
            if (objconexion.State == System.Data.ConnectionState.Closed)
                objconexion.Open();
        }
        private void CERRAR()
        {
            if (objconexion.State == System.Data.ConnectionState.Open)
                objconexion.Close();
        }

        #endregion

        #region Publicos

        /// <summary>
        /// Metodo encargado de ejecutar las T-SQL recibidas por parte del negocio en la base de datos (Insercion - Modificacion - Eliminacion)
        /// </summary>
        /// <param name="P_peticion">Entidad de tipo SQLPeticiones con la instruccion por ejecutar</param>
        /// <returns>True = Correct | False = Error </returns> 
        public bool Ejecutar_Sentencia(SQLPeticiones P_peticion)
        {
            try
            {
                //Crear un objeto comando, que permite configurar a donde tengo que ir, que tengo que enviar y cual es modo para ejecutarlo
                SqlCommand comando = new SqlCommand
                {
                    Connection = objconexion, //a donde voy (cadena de conexion a la instancia de SQL)
                    CommandText = P_peticion.PeticionSQL, //aqui se establece la T-SQL por ejecutar (la trae el parametro P_peticion),
                    CommandType = System.Data.CommandType.Text
                };

                //Ejecutar 
                //ABRIR();
                comando.Connection.Open();
                return comando.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }
        }

        /// <summary>
        /// Método para realizar una consulta en base de datos y retornar resultado
        /// </summary>
        /// <param name="P_peticion">Entidad de tipo SQLPeticiones</param>
        /// <returns>Entidad lista de tipo Cliente</returns>
        public List<Cliente> Consultar_Cliente(SQLPeticiones P_peticion)
        {
            List<Cliente> lstresultados = new List<Cliente>();
            DataTable dt = new DataTable();

            try
            {
                //Crear un objeto comando, que permite configurar a donde tengo que ir, que tengo que enviar y cual es modo para ejecutarlo
                SqlCommand comando = new SqlCommand
                {
                    Connection = objconexion, //a donde voy (cadena de conexion a la instancia de SQL)
                    CommandText = P_peticion.PeticionSQL, //aqui se establece la T-SQL por ejecutar (la trae el parametro P_peticion),
                    CommandType = System.Data.CommandType.Text
                };

                //Crea un objeto para consultar y mantener en memoria el resultado obtenido de la consulta, para que el objeto conozca a donde tiene que ir
                //se inicializa con el SqlCommando configurado anteriormente
                SqlDataAdapter objcapturadatos = new SqlDataAdapter(comando);
                objcapturadatos.Fill(dt); //Se captura en memoria el resultado de la consulta

                if (dt.Rows.Count > 0) //Aqui valida que existieran datos
                {
                    foreach (DataRow item in dt.Rows) //Recorre fila por fila                    
                    {    //foreach(object columna in item.ItemArray) //Recorre de columna por columan por cada fila leida
                         //{
                        Cliente u = new Cliente
                        {
                            IDCliente = item.ItemArray[0].ToString(),
                            Nombre = item.ItemArray[1].ToString(),
                            Contraseña = item.ItemArray[2].ToString(),
                            CorreoE = item.ItemArray[3].ToString(),
                            Direccion = item.ItemArray[4].ToString(),
                            Dinero = Convert.ToInt32(item.ItemArray[5].ToString()),
                            IDPerfil = item.ItemArray[6].ToString()
                        };

                        lstresultados.Add(u);
                        //}                                            
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }

            return lstresultados;
        }

        /// <summary>
        /// Método para realizar una consulta en base de datos y retornar resultado
        /// </summary>
        /// <param name="P_peticion">Entidad de tipo SQLPeticiones</param>
        /// <returns>Entidad lista de tipo Autorizacion</returns>
        public List<Autorizacion> Consultar_Autorizacion(SQLPeticiones P_peticion)
        {
            List<Autorizacion> lstresultados = new List<Autorizacion>();
            DataTable dt = new DataTable();

            try
            {
                //Crear un objeto comando, que permite configurar a donde tengo que ir, que tengo que enviar y cual es modo para ejecutarlo
                SqlCommand comando = new SqlCommand
                {
                    Connection = objconexion, //a donde voy (cadena de conexion a la instancia de SQL)
                    CommandText = P_peticion.PeticionSQL, //aqui se establece la T-SQL por ejecutar (la trae el parametro P_peticion),
                    CommandType = System.Data.CommandType.Text
                };

                //Crea un objeto para consultar y mantener en memoria el resultado obtenido de la consulta, para que el objeto conozca a donde tiene que ir
                //se inicializa con el SqlCommando configurado anteriormente
                SqlDataAdapter objcapturadatos = new SqlDataAdapter(comando);
                objcapturadatos.Fill(dt); //Se captura en memoria el resultado de la consulta

                if (dt.Rows.Count > 0) //Aqui valida que existieran datos
                {
                    foreach (DataRow item in dt.Rows) //Recorre fila por fila                    
                    {    //foreach(object columna in item.ItemArray) //Recorre de columna por columan por cada fila leida
                         //{
                        Autorizacion u = new Autorizacion
                        {
                            IDAutorizacion = item.ItemArray[0].ToString(),
                            IDCliente = item.ItemArray[1].ToString(),
                            Nombre = item.ItemArray[2].ToString(),
                        };

                        lstresultados.Add(u);
                        //}                                            
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }

            return lstresultados;
        }

        /// <summary>
        /// Método para realizar una consulta en base de datos y retornar resultado
        /// </summary>
        /// <param name="P_peticion">Entidad de tipo SQLPeticiones</param>
        /// <returns>Entidad lista de tipo Paquete</returns>
        public List<Paquete> Consultar_Paquete(SQLPeticiones P_peticion)
        {
            List<Paquete> lstresultados = new List<Paquete>();
            DataTable dt = new DataTable();

            try
            {
                //Crear un objeto comando, que permite configurar a donde tengo que ir, que tengo que enviar y cual es modo para ejecutarlo
                SqlCommand comando = new SqlCommand
                {
                    Connection = objconexion, //a donde voy (cadena de conexion a la instancia de SQL)
                    CommandText = P_peticion.PeticionSQL, //aqui se establece la T-SQL por ejecutar (la trae el parametro P_peticion),
                    CommandType = System.Data.CommandType.Text
                };

                //Crea un objeto para consultar y mantener en memoria el resultado obtenido de la consulta, para que el objeto conozca a donde tiene que ir
                //se inicializa con el SqlCommando configurado anteriormente
                SqlDataAdapter objcapturadatos = new SqlDataAdapter(comando);
                objcapturadatos.Fill(dt); //Se captura en memoria el resultado de la consulta

                if (dt.Rows.Count > 0) //Aqui valida que existieran datos
                {
                    foreach (DataRow item in dt.Rows) //Recorre fila por fila                    
                    {    //foreach(object columna in item.ItemArray) //Recorre de columna por columan por cada fila leida
                         //{
                        Paquete u = new Paquete
                        {
                            IDPaquete = item.ItemArray[0].ToString(),
                            IDCliente = item.ItemArray[1].ToString(),
                            IDArticulo = item.ItemArray[2].ToString(),
                            Entregado = Convert.ToBoolean(item.ItemArray[4].ToString()),
                            Descripcion = item.ItemArray[5].ToString(),
                            Fecha = Convert.ToDateTime(item.ItemArray[6].ToString())
                        };

                        lstresultados.Add(u);
                        //}                                            
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }

            return lstresultados;
        }

        /// <summary>
        /// Método para realizar una consulta en base de datos y retornar resultado
        /// </summary>
        /// <param name="P_peticion">Entidad de tipo SQLPeticiones</param>
        /// <returns>Entidad lista de tipo Articulo</returns>
        public List<Articulo> Consultar_Articulo(SQLPeticiones P_peticion)
        {
            List<Articulo> lstresultados = new List<Articulo>();
            DataTable dt = new DataTable();

            try
            {
                //Crear un objeto comando, que permite configurar a donde tengo que ir, que tengo que enviar y cual es modo para ejecutarlo
                SqlCommand comando = new SqlCommand
                {
                    Connection = objconexion, //a donde voy (cadena de conexion a la instancia de SQL)
                    CommandText = P_peticion.PeticionSQL, //aqui se establece la T-SQL por ejecutar (la trae el parametro P_peticion),
                    CommandType = System.Data.CommandType.Text
                };

                //Crea un objeto para consultar y mantener en memoria el resultado obtenido de la consulta, para que el objeto conozca a donde tiene que ir
                //se inicializa con el SqlCommando configurado anteriormente
                SqlDataAdapter objcapturadatos = new SqlDataAdapter(comando);
                objcapturadatos.Fill(dt); //Se captura en memoria el resultado de la consulta

                if (dt.Rows.Count > 0) //Aqui valida que existieran datos
                {
                    foreach (DataRow item in dt.Rows) //Recorre fila por fila                    
                    {    //foreach(object columna in item.ItemArray) //Recorre de columna por columan por cada fila leida
                         //{
                        Articulo u = new Articulo
                        {
                            IDArticulo = item.ItemArray[0].ToString(),
                            Nombre = item.ItemArray[1].ToString(),
                            Descripcion = item.ItemArray[2].ToString(),
                            Precio = Convert.ToInt32(item.ItemArray[3].ToString()),
                            Empresa = item.ItemArray[4].ToString()
                        };

                        lstresultados.Add(u);
                        //}                                            
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }

            return lstresultados;
        }

        /// <summary>
        /// Método para realizar una consulta en base de datos y retornar resultado
        /// </summary>
        /// <param name="P_peticion">Entidad de tipo SQLPeticiones</param>
        /// <returns>Entidad lista de tipo Ruta</returns>
        public List<Ruta> Consultar_Ruta(SQLPeticiones P_peticion)
        {
            List<Ruta> lstresultados = new List<Ruta>();
            DataTable dt = new DataTable();

            try
            {
                //Crear un objeto comando, que permite configurar a donde tengo que ir, que tengo que enviar y cual es modo para ejecutarlo
                SqlCommand comando = new SqlCommand
                {
                    Connection = objconexion, //a donde voy (cadena de conexion a la instancia de SQL)
                    CommandText = P_peticion.PeticionSQL, //aqui se establece la T-SQL por ejecutar (la trae el parametro P_peticion),
                    CommandType = System.Data.CommandType.Text
                };

                //Crea un objeto para consultar y mantener en memoria el resultado obtenido de la consulta, para que el objeto conozca a donde tiene que ir
                //se inicializa con el SqlCommando configurado anteriormente
                SqlDataAdapter objcapturadatos = new SqlDataAdapter(comando);
                objcapturadatos.Fill(dt); //Se captura en memoria el resultado de la consulta

                if (dt.Rows.Count > 0) //Aqui valida que existieran datos
                {
                    foreach (DataRow item in dt.Rows) //Recorre fila por fila                    
                    {    //foreach(object columna in item.ItemArray) //Recorre de columna por columan por cada fila leida
                         //{
                        Ruta u = new Ruta
                        {
                            IDRuta = item.ItemArray[0].ToString(),
                            IDPaquete = item.ItemArray[1].ToString(),
                            Fecha = Convert.ToDateTime(item.ItemArray[2].ToString()),
                            IDLocalizacion = item.ItemArray[3].ToString()
                        };

                        lstresultados.Add(u);
                        //}                                            
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }

            return lstresultados;
        }

        /// <summary>
        /// Método para realizar una consulta en base de datos y retornar resultado
        /// </summary>
        /// <param name="P_peticion">Entidad de tipo SQLPeticiones</param>
        /// <returns>Entidad lista de tipo Localizacion</returns>
        public List<Localizacion> Consultar_Localizacion(SQLPeticiones P_peticion)
        {
            List<Localizacion> lstresultados = new List<Localizacion>();
            DataTable dt = new DataTable();

            try
            {
                //Crear un objeto comando, que permite configurar a donde tengo que ir, que tengo que enviar y cual es modo para ejecutarlo
                SqlCommand comando = new SqlCommand
                {
                    Connection = objconexion, //a donde voy (cadena de conexion a la instancia de SQL)
                    CommandText = P_peticion.PeticionSQL, //aqui se establece la T-SQL por ejecutar (la trae el parametro P_peticion),
                    CommandType = System.Data.CommandType.Text
                };

                //Crea un objeto para consultar y mantener en memoria el resultado obtenido de la consulta, para que el objeto conozca a donde tiene que ir
                //se inicializa con el SqlCommando configurado anteriormente
                SqlDataAdapter objcapturadatos = new SqlDataAdapter(comando);
                objcapturadatos.Fill(dt); //Se captura en memoria el resultado de la consulta

                if (dt.Rows.Count > 0) //Aqui valida que existieran datos
                {
                    foreach (DataRow item in dt.Rows) //Recorre fila por fila                    
                    {    //foreach(object columna in item.ItemArray) //Recorre de columna por columan por cada fila leida
                         //{
                        Localizacion u = new Localizacion
                        {
                            IDLocalizacion = item.ItemArray[0].ToString(),
                            Descripcion = item.ItemArray[1].ToString(),
                        };

                        lstresultados.Add(u);
                        //}                                            
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }

            return lstresultados;
        }

        #endregion

        #endregion

    }
}
