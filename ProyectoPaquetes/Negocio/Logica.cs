using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Logica
    {

        #region Correo

        public static bool EnvioCorreo()
        {
            //Variables para generar el envio del correo
            MailMessage mensaje = new MailMessage();
            SmtpClient envio = new SmtpClient();
            bool respuesta = true;

            try
            {
                //Construimos el mensaje
                mensaje.From = new MailAddress("Santiagotc0710@gmail.com", "EnvioCorreoPrueba", Encoding.UTF8);
                mensaje.To.Add(new MailAddress("Santiagotc0710@gmail.com"));
                mensaje.Subject = "Nueva Contraseña";
                mensaje.Body = "Cliente: LCPR0001 / Funcionario: LWPR0001";
                mensaje.IsBodyHtml = true;
                mensaje.Priority = MailPriority.Normal;

                //Construir el servidor de envio
                envio.Host = "smtp.gmail.com";
                envio.Port = 587;
                envio.EnableSsl = true;
                envio.UseDefaultCredentials = false;
                envio.Credentials = new NetworkCredential("santiagotc0710@gmail.com", "kpjbvcomgyqznqjk");
                envio.DeliveryMethod = SmtpDeliveryMethod.Network;


                //Envio del correo
                envio.Send(mensaje);
                mensaje.Dispose();
            }
            catch (Exception ex)
            {
                GuardarExcepcion(ex);
                return false;
            }

            return respuesta;
        }

        /// <summary>
        /// Guardar en bitacora de errores
        /// </summary>
        public static void GuardarExcepcion(Exception ex)
        {
            string rutaDirectorio = @"D:\Log_Errores";
            string rutaArchivo = @"D:\Log_Errores\Error_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

            if (!Directory.Exists(rutaDirectorio)) //Esta preguntando si carpeta NO existe
                Directory.CreateDirectory(rutaDirectorio);

            if (!File.Exists(rutaArchivo)) //Esta preguntando si archivo NO existe
                File.Create(rutaArchivo).Close();

            FileStream archivo = new FileStream(rutaArchivo, FileMode.Append, FileAccess.Write);
            StreamWriter escribir = new StreamWriter(archivo);

            escribir.WriteLine("Fecha: " + DateTime.Now.ToString());
            escribir.WriteLine("Mensaje: " + ex.Message);
            if (ex.InnerException != null)
                escribir.WriteLine("InnerException: " + ex.InnerException.ToString());
            if (ex.StackTrace != null)
                escribir.WriteLine("StackTrace: " + ex.StackTrace.ToString());
            escribir.WriteLine("*********************************************************************************************");
            escribir.Close();
        }

        #endregion

        #region Verificacion

        public static bool AutenticacionC(Cliente P_Entidad)
        {
            AccesodatosSQL objacceso = new AccesodatosSQL();

            //Crea consulta para base de datos
            SQLPeticiones peticion = new SQLPeticiones
            {
                PeticionSQL = @"EXEC PA_AutenticacionCliente '" + P_Entidad.Nombre + "','" + P_Entidad.Contraseña + "'"
            };

            //ejecuta consulta 
            List<Cliente> lstresultado = objacceso.Consultar_Cliente(peticion);
            if (lstresultado.Count > 0)
                return true; //Si encontro el usuario
            else
                return false; //Datos no coinciden con usuario registrado
        }

        public static bool AutenticacionF(Cliente P_Entidad)
        {
            AccesodatosSQL objacceso = new AccesodatosSQL();

            //Crea consulta para base de datos
            SQLPeticiones peticion = new SQLPeticiones
            {
                PeticionSQL = @"EXEC PA_AutenticacionFuncionario '" + P_Entidad.Nombre + "','" + P_Entidad.Contraseña + "'"
            };

            //ejecuta consulta 
            List<Cliente> lstresultado = objacceso.Consultar_Cliente(peticion);
            if (lstresultado.Count > 0)
                return true; //Si encontro el usuario
            else
                return false; //Datos no coinciden con usuario registrado
        }

        public static bool AutenticacionCnp(Cliente P_Entidad)
        {
            AccesodatosSQL objacceso = new AccesodatosSQL();

            //Crea consulta para base de datos
            SQLPeticiones peticion = new SQLPeticiones
            {
                PeticionSQL = @"EXEC PA_AutenticacionClientenp '" + P_Entidad.Nombre + "'"
            };

            //ejecuta consulta 
            List<Cliente> lstresultado = objacceso.Consultar_Cliente(peticion);
            if (lstresultado.Count > 0)
                return true; //Si encontro el usuario
            else
                return false; //Datos no coinciden con usuario registrado
        }

        public static bool AutenticacionFnp(Cliente P_Entidad)
        {
            AccesodatosSQL objacceso = new AccesodatosSQL();

            //Crea consulta para base de datos
            SQLPeticiones peticion = new SQLPeticiones
            {
                PeticionSQL = @"EXEC PA_AutenticacionFuncionarionp '" + P_Entidad.Nombre + "'"
            };

            //ejecuta consulta 
            List<Cliente> lstresultado = objacceso.Consultar_Cliente(peticion);
            if (lstresultado.Count > 0)
                return true; //Si encontro el usuario
            else
                return false; //Datos no coinciden con usuario registrado
        }

        #endregion

        #region CRUD

        /// <summary>
        /// Metodo para agregar un Cliente en la base de datos
        /// </summary>
        /// <param name="P_CLiente">Entidad de tipo CLiente</param>
        /// <returns>True = Correct | False = Error</returns>
        public static ResultadoC AgregarC(Cliente P_Cliente)
        {
            ResultadoC resultadoC = new ResultadoC();

            try
            {
                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();

                //Creo la peticion de consulta
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDCliente, Nombre, Contraseña, CorreoE, Direccion, Dinero, IDPerfil FROM Cliente WHERE IDCliente = '" + P_Cliente.IDCliente + "'"
                };

                //Aqui se consulta si el usuario por insertar, ya existe en base de datos
                List<Cliente> lstOfertas = objacceso.Consultar_Cliente(peticion);
                if (lstOfertas.Count > 0) //Quiere indicar que el usuario ya existe, por lo tanto, no se puede insertar
                {
                    resultadoC = new ResultadoC
                    {
                        ResultadoOperacion = false,
                        MensajeCliente = "Cliente que intenta registrar ya existe"
                    };
                }
                else //De lo contrario, registra el nuevo usuario en base de datos
                {
                    //Creo mi objeto para armar la sentencia de T-SQL por ejecuta
                    peticion = new SQLPeticiones
                    {
                        PeticionSQL = @"INSERT INTO Cliente VALUES ('" + P_Cliente.IDCliente + "','" + P_Cliente.Nombre + "','" + P_Cliente.Contraseña + "','" + P_Cliente.CorreoE + "','" + P_Cliente.Direccion + "','" + P_Cliente.Dinero + "','" + P_Cliente.Dinero + "','" + P_Cliente.IDPerfil + "')"
                    };

                    if (!objacceso.Ejecutar_Sentencia(peticion)) //este metodo retorna TRUE si todo fue correcto, de lo contrario retorna FALSE
                    {
                        resultadoC = new ResultadoC
                        {
                            ResultadoOperacion = false,
                            MensajeCliente = "Surgio un error al registrar, comunicarse con el administrador"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultadoC;
        }

        /// <summary>
        /// Metodo para modificar un Cliente en base de datos
        /// </summary>
        /// <param name="P_Cliente">Entidad de tipo Cliente</param>
        /// <returns>True = Correct | False = Error</returns>
        public static ResultadoC ModificarC(Cliente P_Cliente)
        {
            ResultadoC resultadoC = new ResultadoC();

            try
            {
                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();

                //Creo la peticion de consulta
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDCliente, Nombre, Contraseña, CorreoE, Direccion, Dinero, IDPerfil FROM Cliente WHERE IDCliente = '" + P_Cliente.IDCliente + "'"
                };

                //Aqui se consulta si el usuario por insertar, ya existe en base de datos
                List<Cliente> lstOfertas = objacceso.Consultar_Cliente(peticion);
                if (lstOfertas.Count > 0) //Quiere indicar que el usuario ya existe, por lo tanto, se puede modificar
                {

                    //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                    peticion = new SQLPeticiones
                    {
                        PeticionSQL = @"UPDATE Cliente SET (Nombre = '" + P_Cliente.Nombre + "',Contraseña = '" + P_Cliente.Contraseña + "',CorreoE = '" + P_Cliente.CorreoE + "',Direccion = '" + P_Cliente.Direccion + "',Dinero = '" + P_Cliente.Dinero + "',IDPerfil = '" + P_Cliente.IDPerfil + "') WHERE IDCliente = '" + P_Cliente.IDCliente + "'"
                    };

                    if (!objacceso.Ejecutar_Sentencia(peticion)) //este metodo retorna TRUE si todo fue correcto, de lo contrario retorna FALSE
                    {
                        resultadoC = new ResultadoC
                        {
                            ResultadoOperacion = false,
                            MensajeCliente = "Surgio un error al registrar, comunicarse con el administrador"
                        };
                    }
                }
                else
                {
                    resultadoC = new ResultadoC
                    {
                        ResultadoOperacion = false,
                        MensajeCliente = "Cliente que intenta modificar no se encuentra"
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultadoC;
        }

        /// <summary>
        /// Metodo para eliminar un Cliente en base de datos
        /// </summary>
        /// <param name="P_Cliente">Entidad de tipo Cliente</param>
        /// <returns>True = Correct | False = Error</returns>
        public static ResultadoC EliminarC(Cliente P_Cliente)
        {
            ResultadoC resultadoc = new ResultadoC();

            try
            {
                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();

                //Creo la peticion de consulta
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDCliente, Nombre, Contraseña, CorreoE, Direccion, Dinero, IDPerfil FROM Cliente WHERE IDCliente = '" + P_Cliente.IDCliente + "'"
                };

                //Aqui se consulta si la oferta por insertar, ya existe en base de datos
                List<Cliente> lstCliente = objacceso.Consultar_Cliente(peticion);
                if (lstCliente.Count > 0) //Quiere indicar que la oferta ya existe, por lo tanto, se puede eliminar
                {
                    //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                    peticion = new SQLPeticiones
                    {
                        PeticionSQL = @"DELETE FROM Cliente WHERE IDCliente = '" + P_Cliente.IDCliente + "'"
                    };

                    if (!objacceso.Ejecutar_Sentencia(peticion)) //este metodo retorna TRUE si todo fue correcto, de lo contrario retorna FALSE
                    {
                        resultadoc = new ResultadoC
                        {
                            ResultadoOperacion = false,
                            MensajeCliente = "Surgio un error al registrar, comunicarse con el administrador"
                        };
                    }
                }
                else
                {
                    resultadoc = new ResultadoC
                    {
                        ResultadoOperacion = false,
                        MensajeCliente = "Cliente que intenta eliminar no se encuentra"
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultadoc;
        }

        /// <summary>
        /// Metodo para agregar una Autorizacion en la base de datos
        /// </summary>
        /// <param name="P_Autorizacion">Entidad de tipo CLiente</param>
        /// <returns>True = Correct | False = Error</returns>
        public static ResultadoAu AgregarAu(Autorizacion P_Autorizacion)
        {
            ResultadoAu resultadoAu = new ResultadoAu();

            try
            {
                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();

                //Creo la peticion de consulta
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDAutorizacion, IDCliente, Nombre FROM Autorizacion WHERE IDAutorizacion = '" + P_Autorizacion.IDAutorizacion + "'"
                };

                //Aqui se consulta si el usuario por insertar, ya existe en base de datos
                List<Autorizacion> lstOfertas = objacceso.Consultar_Autorizacion(peticion);
                if (lstOfertas.Count > 0) //Quiere indicar que el usuario ya existe, por lo tanto, no se puede insertar
                {
                    resultadoAu = new ResultadoAu
                    {
                        ResultadoOperacion = false,
                        MensajeAutorizacion = "Autorizacion que intenta registrar ya existe"
                    };
                }
                else //De lo contrario, registra el nuevo usuario en base de datos
                {
                    //Creo mi objeto para armar la sentencia de T-SQL por ejecuta
                    peticion = new SQLPeticiones
                    {
                        PeticionSQL = @"INSERT INTO Autorizacion VALUES ('" + P_Autorizacion.IDAutorizacion + "','" + P_Autorizacion.IDCliente + "','" + P_Autorizacion.Nombre + "')"
                    };

                    if (!objacceso.Ejecutar_Sentencia(peticion)) //este metodo retorna TRUE si todo fue correcto, de lo contrario retorna FALSE
                    {
                        resultadoAu = new ResultadoAu
                        {
                            ResultadoOperacion = false,
                            MensajeAutorizacion = "Surgio un error al registrar, comunicarse con el administrador"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultadoAu;
        }

        /// <summary>
        /// Metodo para agregar un Paquete en la base de datos
        /// </summary>
        /// <param name="P_Paquete">Entidad de tipo Paquete</param>
        /// <returns>True = Correct | False = Error</returns>
        public static ResultadoP AgregarP(Paquete P_Paquete)
        {
            ResultadoP resultadoP = new ResultadoP();

            try
            {
                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();

                //Creo la peticion de consulta
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDPaquete, IDCliente, IDArticulo, Entregado, Descripcion, Fecha FROM Paquete WHERE IDPaquete = '" + P_Paquete.IDPaquete + "'"
                };

                //Aqui se consulta si el usuario por insertar, ya existe en base de datos
                List<Paquete> lstPaquete = objacceso.Consultar_Paquete(peticion);
                if (lstPaquete.Count > 0) //Quiere indicar que el usuario ya existe, por lo tanto, no se puede insertar
                {
                    resultadoP = new ResultadoP
                    {
                        ResultadoOperacion = false,
                        MensajePaquete = "Paquete que intenta registrar ya existe"
                    };
                }
                else //De lo contrario, registra el nuevo usuario en base de datos
                {
                    //Creo mi objeto para armar la sentencia de T-SQL por ejecuta
                    peticion = new SQLPeticiones
                    {
                        PeticionSQL = @"INSERT INTO Paquete VALUES ('" + P_Paquete.IDPaquete + "','" + P_Paquete.IDCliente + "','" + P_Paquete.IDArticulo + "','" + P_Paquete.Entregado + "','" + P_Paquete.Descripcion + "','" + P_Paquete.Fecha + "')"
                    };

                    if (!objacceso.Ejecutar_Sentencia(peticion)) //este metodo retorna TRUE si todo fue correcto, de lo contrario retorna FALSE
                    {
                        resultadoP = new ResultadoP
                        {
                            ResultadoOperacion = false,
                            MensajePaquete = "Surgio un error al registrar, comunicarse con el administrador"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultadoP;
        }

        /// <summary>
        /// Metodo para modificar un Paquete en base de datos
        /// </summary>
        /// <param name="P_Paquete">Entidad de tipo Paquete</param>
        /// <returns>True = Correct | False = Error</returns>
        public static ResultadoP ModificarP(Paquete P_Paquete)
        {
            ResultadoP resultadoP = new ResultadoP();

            try
            {
                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();

                //Creo la peticion de consulta
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDPaquete, IDCliente, IDArticulo, Entregado, Descripcion, Fecha FROM Paquete WHERE IDPaquete = '" + P_Paquete.IDPaquete + "'"
                };

                //Aqui se consulta si el usuario por insertar, ya existe en base de datos
                List<Paquete> lstOfertas = objacceso.Consultar_Paquete(peticion);
                if (lstOfertas.Count > 0) //Quiere indicar que el usuario ya existe, por lo tanto, se puede modificar
                {

                    //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                    peticion = new SQLPeticiones
                    {
                        PeticionSQL = @"UPDATE Paquete SET (IDCliente = '" + P_Paquete.IDCliente + "',IDArticulo = '" + P_Paquete.IDArticulo + "',Entregado = '" + P_Paquete.Entregado + "',Descripcion = '" + P_Paquete.Descripcion + "',Fecha = '" + P_Paquete.Fecha + "') WHERE IDPaquete = '" + P_Paquete.IDPaquete + "'"
                    };

                    if (!objacceso.Ejecutar_Sentencia(peticion)) //este metodo retorna TRUE si todo fue correcto, de lo contrario retorna FALSE
                    {
                        resultadoP = new ResultadoP
                        {
                            ResultadoOperacion = false,
                            MensajePaquete = "Surgio un error al registrar, comunicarse con el administrador"
                        };
                    }
                }
                else
                {
                    resultadoP = new ResultadoP
                    {
                        ResultadoOperacion = false,
                        MensajePaquete = "Paquete que intenta modificar no se encuentra"
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultadoP;
        }

        /// <summary>
        /// Metodo para eliminar un Paquete en base de datos
        /// </summary>
        /// <param name="P_Paquete">Entidad de tipo Paquete</param>
        /// <returns>True = Correct | False = Error</returns>
        public static ResultadoP EliminarP(Paquete P_Paquete)
        {
            ResultadoP resultadop = new ResultadoP();

            try
            {
                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();

                //Creo la peticion de consulta
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDPaquete, IDCliente, IDArticulo, Entregado, Descripcion, Fecha FROM Paquete WHERE IDPaquete = '" + P_Paquete.IDPaquete + "'"
                };

                //Aqui se consulta si la oferta por insertar, ya existe en base de datos
                List<Paquete> lstPaquete = objacceso.Consultar_Paquete(peticion);
                if (lstPaquete.Count > 0) //Quiere indicar que la oferta ya existe, por lo tanto, se puede eliminar
                {
                    //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                    peticion = new SQLPeticiones
                    {
                        PeticionSQL = @"DELETE FROM Paquete WHERE IDPaquete = '" + P_Paquete.IDPaquete + "'"
                    };

                    if (!objacceso.Ejecutar_Sentencia(peticion)) //este metodo retorna TRUE si todo fue correcto, de lo contrario retorna FALSE
                    {
                        resultadop = new ResultadoP
                        {
                            ResultadoOperacion = false,
                            MensajePaquete = "Surgio un error al registrar, comunicarse con el administrador"
                        };
                    }
                }
                else
                {
                    resultadop = new ResultadoP
                    {
                        ResultadoOperacion = false,
                        MensajePaquete = "Paquete que intenta eliminar no se encuentra"
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultadop;
        }

        /// <summary>
        /// Metodo para agregar un Ruta en la base de datos
        /// </summary>
        /// <param name="P_Ruta">Entidad de tipo Ruta</param>
        /// <returns>True = Correct | False = Error</returns>
        public static ResultadoR AgregarR(Ruta P_Ruta)
        {
            ResultadoR resultadoR = new ResultadoR();

            try
            {
                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();

                //Creo la peticion de consulta
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDRuta, IDPaquete, Fecha, IDLocalizacion FROM Ruta WHERE IDRuta = '" + P_Ruta.IDRuta + "'"
                };

                //Aqui se consulta si el usuario por insertar, ya existe en base de datos
                List<Ruta> lstOfertas = objacceso.Consultar_Ruta(peticion);
                if (lstOfertas.Count > 0) //Quiere indicar que el usuario ya existe, por lo tanto, no se puede insertar
                {
                    resultadoR = new ResultadoR
                    {
                        ResultadoOperacion = false,
                        MensajeRuta = "Ruta que intenta registrar ya existe"
                    };
                }
                else //De lo contrario, registra el nuevo usuario en base de datos
                {
                    //Creo mi objeto para armar la sentencia de T-SQL por ejecuta
                    peticion = new SQLPeticiones
                    {
                        PeticionSQL = @"INSERT INTO Ruta VALUES ('" + P_Ruta.IDRuta + "','" + P_Ruta.IDPaquete + "','" + P_Ruta.Fecha + "','" + P_Ruta.IDLocalizacion + "')"
                    };

                    if (!objacceso.Ejecutar_Sentencia(peticion)) //este metodo retorna TRUE si todo fue correcto, de lo contrario retorna FALSE
                    {
                        resultadoR = new ResultadoR
                        {
                            ResultadoOperacion = false,
                            MensajeRuta = "Surgio un error al registrar, comunicarse con el administrador"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultadoR;
        }

        /// <summary>
        /// Metodo para modificar una Ruta en base de datos
        /// </summary>
        /// <param name="P_Ruta">Entidad de tipo Ruta</param>
        /// <returns>True = Correct | False = Error</returns>
        public static ResultadoR ModificarR(Ruta P_Ruta)
        {
            ResultadoR resultadoR = new ResultadoR();

            try
            {
                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();

                //Creo la peticion de consulta
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDRuta, IDPaquete, Fecha, IDLocalizacion FROM Ruta WHERE IDRuta = '" + P_Ruta.IDRuta + "'"
                };

                //Aqui se consulta si el usuario por insertar, ya existe en base de datos
                List<Paquete> lstOfertas = objacceso.Consultar_Paquete(peticion);
                if (lstOfertas.Count > 0) //Quiere indicar que el usuario ya existe, por lo tanto, se puede modificar
                {

                    //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                    peticion = new SQLPeticiones
                    {
                        PeticionSQL = @"UPDATE Ruta SET (IDPaquete = '" + P_Ruta.IDPaquete + "',Fecha = '" + P_Ruta.Fecha + "',IDLocalizacion = '" + P_Ruta.IDLocalizacion + "') WHERE IDRuta = '" + P_Ruta.IDPaquete + "'"
                    };

                    if (!objacceso.Ejecutar_Sentencia(peticion)) //este metodo retorna TRUE si todo fue correcto, de lo contrario retorna FALSE
                    {
                        resultadoR = new ResultadoR
                        {
                            ResultadoOperacion = false,
                            MensajeRuta = "Surgio un error al registrar, comunicarse con el administrador"
                        };
                    }
                }
                else
                {
                    resultadoR = new ResultadoR
                    {
                        ResultadoOperacion = false,
                        MensajeRuta = "Ruta que intenta modificar no se encuentra"
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultadoR;
        }

        /// <summary>
        /// Metodo para eliminar una ruta en base de datos
        /// </summary>
        /// <param name="P_Ruta">Entidad de tipo Ruta</param>
        /// <returns>True = Correct | False = Error</returns>
        public static ResultadoR EliminarR(Ruta P_Ruta)
        {
            ResultadoR resultadoR = new ResultadoR();

            try
            {
                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();

                //Creo la peticion de consulta
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDRuta, IDPaquete, Fecha, IDLocalizacion FROM Ruta WHERE IDRuta = '" + P_Ruta.IDRuta + "'"
                };

                //Aqui se consulta si la oferta por insertar, ya existe en base de datos
                List<Ruta> lstPaquete = objacceso.Consultar_Ruta(peticion);
                if (lstPaquete.Count > 0) //Quiere indicar que la oferta ya existe, por lo tanto, se puede eliminar
                {
                    //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                    peticion = new SQLPeticiones
                    {
                        PeticionSQL = @"DELETE FROM Ruta WHERE IDRuta = '" + P_Ruta.IDRuta + "'"
                    };

                    if (!objacceso.Ejecutar_Sentencia(peticion)) //este metodo retorna TRUE si todo fue correcto, de lo contrario retorna FALSE
                    {
                        resultadoR = new ResultadoR
                        {
                            ResultadoOperacion = false,
                            MensajeRuta = "Surgio un error al registrar, comunicarse con el administrador"
                        };
                    }
                }
                else
                {
                    resultadoR = new ResultadoR
                    {
                        ResultadoOperacion = false,
                        MensajeRuta = "Ruta que intenta eliminar no se encuentra"
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultadoR;
        }

        /// <summary>
        /// Metodo para agregar una Localizacion en la base de datos
        /// </summary>
        /// <param name="P_Localizacion">Entidad de tipo Localizacion</param>
        /// <returns>True = Correct | False = Error</returns>
        public static ResultadoL AgregarL(Localizacion P_Localizacion)
        {
            ResultadoL resultadoL = new ResultadoL();

            try
            {
                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();

                //Creo la peticion de consulta
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDLocalizacion, Descripcion FROM Localizacion WHERE IDLocalizacion = '" + P_Localizacion.IDLocalizacion + "'"
                };

                //Aqui se consulta si el usuario por insertar, ya existe en base de datos
                List<Localizacion> lstOfertas = objacceso.Consultar_Localizacion(peticion);
                if (lstOfertas.Count > 0) //Quiere indicar que el usuario ya existe, por lo tanto, no se puede insertar
                {
                    resultadoL = new ResultadoL
                    {
                        ResultadoOperacion = false,
                        MensajeLocalizacion = "Localizacion que intenta registrar ya existe"
                    };
                }
                else //De lo contrario, registra el nuevo usuario en base de datos
                {
                    //Creo mi objeto para armar la sentencia de T-SQL por ejecuta
                    peticion = new SQLPeticiones
                    {
                        PeticionSQL = @"INSERT INTO Localizacion VALUES ('" + P_Localizacion.IDLocalizacion + "','" + P_Localizacion.Descripcion + "')"
                    };

                    if (!objacceso.Ejecutar_Sentencia(peticion)) //este metodo retorna TRUE si todo fue correcto, de lo contrario retorna FALSE
                    {
                        resultadoL = new ResultadoL
                        {
                            ResultadoOperacion = false,
                            MensajeLocalizacion = "Surgio un error al registrar, comunicarse con el administrador"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultadoL;
        }

        /// <summary>
        /// Metodo para modificar una Localizacion en base de datos
        /// </summary>
        /// <param name="P_Localizacion">Entidad de tipo Localizacion</param>
        /// <returns>True = Correct | False = Error</returns>
        public static ResultadoL ModificarL(Localizacion P_Localizacion)
        {
            ResultadoL resultadoL = new ResultadoL();

            try
            {
                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();

                //Creo la peticion de consulta
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDLocalizacion, Descripcion FROM Localizacion WHERE IDLocalizacion = '" + P_Localizacion.IDLocalizacion + "'"
                };

                //Aqui se consulta si el usuario por insertar, ya existe en base de datos
                List<Localizacion> lstOfertas = objacceso.Consultar_Localizacion(peticion);
                if (lstOfertas.Count > 0) //Quiere indicar que el usuario ya existe, por lo tanto, se puede modificar
                {

                    //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                    peticion = new SQLPeticiones
                    {
                        PeticionSQL = @"UPDATE Localizacion SET (Descripcion = '" + P_Localizacion.Descripcion + "') WHERE IDLocalizacion = '" + P_Localizacion.IDLocalizacion + "'"
                    };

                    if (!objacceso.Ejecutar_Sentencia(peticion)) //este metodo retorna TRUE si todo fue correcto, de lo contrario retorna FALSE
                    {
                        resultadoL = new ResultadoL
                        {
                            ResultadoOperacion = false,
                            MensajeLocalizacion = "Surgio un error al registrar, comunicarse con el administrador"
                        };
                    }
                }
                else
                {
                    resultadoL = new ResultadoL
                    {
                        ResultadoOperacion = false,
                        MensajeLocalizacion = "Localizacion que intenta modificar no se encuentra"
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultadoL;
        }

        /// <summary>
        /// Metodo para eliminar una Localizacion en base de datos
        /// </summary>
        /// <param name="P_Localizacion">Entidad de tipo Localizacion</param>
        /// <returns>True = Correct | False = Error</returns>
        public static ResultadoL EliminarL(Localizacion P_Localizacion)
        {
            ResultadoL resultadoL = new ResultadoL();

            try
            {
                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();

                //Creo la peticion de consulta
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDLocalizacion, Descripcion FROM Localizacion WHERE IDLocalizacion = '" + P_Localizacion.IDLocalizacion + "'"
                };

                //Aqui se consulta si la oferta por insertar, ya existe en base de datos
                List<Localizacion> lstPaquete = objacceso.Consultar_Localizacion(peticion);
                if (lstPaquete.Count > 0) //Quiere indicar que la oferta ya existe, por lo tanto, se puede eliminar
                {
                    //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                    peticion = new SQLPeticiones
                    {
                        PeticionSQL = @"DELETE FROM Localizacion WHERE IDLocalizacion = '" + P_Localizacion.IDLocalizacion + "'"
                    };

                    if (!objacceso.Ejecutar_Sentencia(peticion)) //este metodo retorna TRUE si todo fue correcto, de lo contrario retorna FALSE
                    {
                        resultadoL = new ResultadoL
                        {
                            ResultadoOperacion = false,
                            MensajeLocalizacion = "Surgio un error al registrar, comunicarse con el administrador"
                        };
                    }
                }
                else
                {
                    resultadoL = new ResultadoL
                    {
                        ResultadoOperacion = false,
                        MensajeLocalizacion = "Localizacion que intenta eliminar no se encuentra"
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultadoL;
        }

        /// <summary>
        /// Metodo para ayudar a rellenar las data grid views
        /// </summary>
        /// <param name="P_Cliente">Entidad de tipo Oferta</param>
        /// <returns>True = Correct | False = Error</returns>
        public static List<Cliente> ConsultarC(Cliente P_Cliente)
        {
            try
            {
                //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDCliente,Nombre,Contraseña,CorreoE,Direccion,Dinero,IDPerfil FROM Cliente"
                };

                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();
                return objacceso.Consultar_Cliente(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para ayudar a rellenar las data grid views
        /// </summary>
        /// <param name="P_Cliente">Entidad de tipo Oferta</param>
        /// <returns>True = Correct | False = Error</returns>
        public static List<Cliente> ConsultarCporID(Cliente P_Cliente)
        {
            try
            {
                //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDCliente,Nombre,Contraseña,CorreoE,Direccion,Dinero,IDPerfil FROM Cliente WHERE IDCliente = '" + P_Cliente.IDCliente + "'"
                };

                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();
                return objacceso.Consultar_Cliente(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para ayudar a rellenar las data grid views
        /// </summary>
        /// <param name="P_Paquete">Entidad de tipo Paquete</param>
        /// <returns>True = Correct | False = Error</returns>
        public static List<Paquete> ConsultarP(Paquete P_Paquete)
        {
            try
            {
                //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDPaquete, IDCliente, IDArticulo, Entregado, Descripcion, Fecha FROM Paquete "
                };

                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();
                return objacceso.Consultar_Paquete(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para ayudar a rellenar las data grid views
        /// </summary>
        /// <param name="P_Paquete">Entidad de tipo Paquete</param>
        /// <returns>True = Correct | False = Error</returns>
        public static List<Paquete> ConsultarPporID(Paquete P_Paquete)
        {
            try
            {
                //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDPaquete, IDCliente, IDArticulo, Entregado, Descripcion, Fecha FROM Paquete WHERE IDPaquete = '" + P_Paquete.IDPaquete + "'"
                };

                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();
                return objacceso.Consultar_Paquete(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para ayudar a rellenar las data grid views
        /// </summary>
        /// <param name="P_Paquete">Entidad de tipo Paquete</param>
        /// <returns>True = Correct | False = Error</returns>
        public static List<Paquete> ConsultarPporFecha(Paquete P_Paquete)
        {
            try
            {
                //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDPaquete, IDCliente, IDArticulo, Entregado, Descripcion, Fecha FROM Paquete WHERE IDPaquete = '" + P_Paquete.Fecha + "'"
                };

                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();
                return objacceso.Consultar_Paquete(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para ayudar a rellenar las data grid views
        /// </summary>
        /// <param name="P_Paquete">Entidad de tipo Paquete</param>
        /// <returns>True = Correct | False = Error</returns>
        public static List<Paquete> ConsultarPporDescripcion(Paquete P_Paquete)
        {
            try
            {
                //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDPaquete, IDCliente, IDArticulo, Entregado, Descripcion, Fecha FROM Paquete WHERE IDPaquete = '" + P_Paquete.Descripcion + "'"
                };

                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();
                return objacceso.Consultar_Paquete(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para ayudar a rellenar las data grid views
        /// </summary>
        /// <param name="P_Ruta">Entidad de tipo Ruta</param>
        /// <returns>True = Correct | False = Error</returns>
        public static List<Ruta> ConsultarRporPaquete(Ruta P_Ruta)
        {
            try
            {
                //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDRuta,IDPaquete,Fecha,IDLocalizacion FROM Ruta WHERE IDPaquete = '" + P_Ruta.IDPaquete + "'"
                };

                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();
                return objacceso.Consultar_Ruta(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para ayudar a rellenar las data grid views
        /// </summary>
        /// <param name="P_Ruta">Entidad de tipo Ruta</param>
        /// <returns>True = Correct | False = Error</returns>
        public static List<Ruta> ConsultarR(Ruta P_Ruta)
        {
            try
            {
                //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDRuta,IDPaquete,Fecha,IDLocalizacion FROM Ruta"
                };

                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();
                return objacceso.Consultar_Ruta(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para ayudar a rellenar las data grid views
        /// </summary>
        /// <param name="P_Localizacion">Entidad de tipo Localizacion</param>
        /// <returns>True = Correct | False = Error</returns>
        public static List<Localizacion> ConsultarL(Localizacion P_Localizacion)
        {
            try
            {
                //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDLocalizacion, Descripcion FROM Localizacion "
                };

                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();
                return objacceso.Consultar_Localizacion(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para ayudar a rellenar las data grid views
        /// </summary>
        /// <param name="P_Articulo">Entidad de tipo Articulo</param>
        /// <returns>True = Correct | False = Error</returns>
        public static List<Articulo> ConsultarAR(Articulo P_Articulo)
        {
            try
            {
                //Creo mi objeto para armar la sentencia de T-SQL por ejecutar
                SQLPeticiones peticion = new SQLPeticiones
                {
                    PeticionSQL = @"SELECT IDArticulo,Nombre,Descripcion,Precio,Empresa FROM Articulo"
                };

                //Creo mi objeto de acceso datos
                AccesodatosSQL objacceso = new AccesodatosSQL();
                return objacceso.Consultar_Articulo(peticion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
