/*
 * Copyright (c) Ana Arellano 2015
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Tralix;
using System.IO;
using ServicioTralix;
using System.Reflection;

namespace Servicio_Tralix
{
    public partial class Interfaz : Form
    {
        private String nombreCertificado;
        private String contraseña;
        public Interfaz()
        {
            InitializeComponent();

        }

        private void BuscarBtn_Click(object sender, EventArgs e)
        {
            //Muestra el dialogo para que seleccione el directorio
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //
                // El usuario selecciono el directorio.
                //
                DirectorioLbl.Text = folderBrowserDialog1.SelectedPath;
                string[] archivosEnDirectorio = Directory.GetFiles(folderBrowserDialog1.SelectedPath,"*.xml");
                //Muestra mensaje de confirmación para continuar 
                DialogResult confirmacion=MessageBox.Show("Se encontraron un total de " + archivosEnDirectorio.Length.ToString()+" archivos.\n ¿Desea continuar con la cancelación?", "Confirmación",MessageBoxButtons.YesNo);
                if (confirmacion == DialogResult.Yes)
                {
                    //Cifra el certificado personal de la empresa seleccionada
                    try
                    {
                        //Obtiene el certificado y lo almacena
                        var cer = new X509Certificate2(nombreCertificado, contraseña, X509KeyStorageFlags.MachineKeySet);
                        System.Diagnostics.Debug.WriteLine("Procesando:" +cer.ToString());
                        //Recorre el directorio seleccionado para cancelar los archivos
                        foreach (String nombreArchivo in archivosEnDirectorio)
                        {
                            //Obtiene datos requeridos del XML
                            Comprobante comprobanteActual = Program.ObtenerComprobantes(nombreArchivo);
                            var xml2 = "";
                            try
                            {
                                //Construye objeto XML para peticion
                                //UUID,RFC,FECHADECANCELACIÓN,CERTIFICADOCIFRADO
                                xml2 = Cancelador.Xml(comprobanteActual.UUID, comprobanteActual.RFC, DateTime.Now, cer);

                                //CANCELAR un folio
                                //Llama al servicio del PAC Tralix para realizar la cancelación
                                var soap2 = Cancelador.Cancelar("https://timbrador.tralix.com:8081/", key, xml2);
                                //Obtiene estatus de respuesta
                                var status = Cancelador.Status(soap2);
                                progresoTxt.Text = progresoTxt.Text + "Procesado: " + nombreArchivo + "\n ";
                                progresoTxt.Text = progresoTxt.Text + "Estatus de cancelacion : " + status + "\n";
                            }
                            catch (Exception ex)
                            {
                                //Error en construccion de peticion
                                System.Diagnostics.Debug.WriteLine(ex.Message);
                                System.Diagnostics.Debug.WriteLine(ex.InnerException.Message);
                                progresoTxt.Text = progresoTxt.Text + "Error:" + ex.Message + "\n";
                            }  
                        }
                    }catch (Exception ex){
                        //Error en obtener certificado
                        var error = ex.Message;
                        System.Diagnostics.Debug.WriteLine(error);
                        progresoTxt.Text = progresoTxt.Text + "Error:" + error + "\n";
                    }
                }
               }
        }

        private void EmpresaCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            object objetoseleccionado = EmpresaCB.SelectedItem;
            
            /* Busca dependiendo de la empresa 
             * el nombre del archivo .pfx que se usara
             * como ceritificado y la contraseña correspondiente
             */
            switch (objetoseleccionado.ToString())
            {
                case"CAMSA":
                    
                    nombreCertificado = Properties.Resources.nombreCertificadoCamsa;
                    contraseña = Properties.Resources.claveCertificadoCamsa;
                    break;
                case"MISA":
                    nombreCertificado = Properties.Resources.nombreCertificadoMisa;
                    contraseña = Properties.Resources.claveCertificadoMisa;
                    MessageBox.Show(nombreCertificado.ToString());
                    break;
                case"TRONCALNET":
                    nombreCertificado = Properties.Resources.nombreCertificadoTroncalnet;
                    contraseña = Properties.Resources.claveCertificadoTroncalnet;
                    break;
                case"MASERTEC":
                    nombreCertificado = Properties.Resources.nombreCertificadoMasertec;
                    contraseña = Properties.Resources.claveCertificadoMasertec;
                    break;
                case "FOTUNAL":
                    nombreCertificado = Properties.Resources.nombreCertificadoFotunal;
                    contraseña = Properties.Resources.claveCertificadoFotunal;
                    break;
                default:
                    MessageBox.Show("No se encontro el certificado para la empresa seleccionada.");
                    break;
            }
         
        }

    }
}
