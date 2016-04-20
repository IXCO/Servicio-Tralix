/*
 * Copyright (c) Ana Arellano 2015
 */
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.Data.OleDb;
using System.Xml.Linq;
using ServicioTralix;

namespace Servicio_Tralix
{
    static class Program
    {
        /// <summary>
        ///  Cancelacion de cfdi 3.2 via PAC Tralix.
        /// Se requiere del archivo de cifrado .pfx y la contraseña de los mismos
        /// para poder cancelar el paquete de XML que se asignen.
        /// </summary>
        
        public static Comprobante ObtenerComprobantes(String direccionFisica)
        {

            Comprobante comprobante = new Comprobante();

            try
            {
                //Intenta leer XML
                XElement xelement = XElement.Load(direccionFisica);
                IEnumerable<XElement> elementos = xelement.Elements();
                String esSub;
                foreach (XElement Emisor in elementos)
                {
                    String esEmi;
                    esEmi = Emisor.Name.ToString();
                    //Busca el Nodo de emisor
                    if (esEmi.Contains("Emisor"))
                    {
                        comprobante.RFC = Emisor.Attribute("rfc").Value;
                    }
                        //Busca el nodo de complemento
                    else if (esEmi.Contains("Complemento"))
                    {
                        IEnumerable<XElement> subelem = Emisor.Elements();
                        foreach (XElement subElemento in subelem)
                        {
                            esSub = subElemento.Name.ToString();
                            if (esSub.Contains("TimbreFiscalDigital"))
                            {
                                comprobante.UUID = subElemento.Attribute("UUID").Value;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                
                MessageBox.Show("ERROR: No se pudo leer el XML: " + direccionFisica);
            }
            //Regresa la estructura del comprobante
            return comprobante;
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Interfaz());
            
        }
    }
}
