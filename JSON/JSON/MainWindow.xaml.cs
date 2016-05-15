using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Vamos a usar en este proyecto...
using System.Web.Script.Serialization;
using System.IO;



namespace JSON
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 
    
      
      /*
     * 
     * En este ejemplo vamos a hacer un sencillo ejercicio de lectura-escritura en C# de archivos JSON
     * 
     * 1.- Vamos a usar System.Web.Script.Serialization para poder hacer las serializaciones de JSON.
     * para usar esta extensión, tenemos que hacer referencia a System.Web.Extensions.
     * 
     */ 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        //Lo usamos para leer el archivo JSON
        private void bLeer_Click(object sender, RoutedEventArgs e)
        {
            String JSONstring = File.ReadAllText("..\\..\\Archivos\\personas.json");
            //Usamos esta clase para realizar la serialización del objeto
            JavaScriptSerializer ser = new JavaScriptSerializer();
            //Creamos el objeto Persona con los datos del JSON
            Persona persona = ser.Deserialize<Persona>(JSONstring);
            MessageBox.Show("Nombre: " + persona.Nombre + "\nEdad: " + persona.Edad);

        }

        private void bEscribir_Click(object sender, RoutedEventArgs e)
        {
            string nombre = tbNombre.Text;
            int edad = int.Parse(tbEdad.Text);      //Habría que controlar el FormatException.
            string JSONsalida;

            Persona persona = new Persona { Nombre = nombre, Edad = edad };
            JavaScriptSerializer ser = new JavaScriptSerializer();
            JSONsalida = ser.Serialize(persona);
            File.WriteAllText("..\\..\\Archivos\\JSONsalida.json", JSONsalida, Encoding.Default);

            //Informamos y limpiamos
            MessageBox.Show("Se ha escrito el archivo JSON");
            tbEdad.Text = "";
            tbNombre.Text = "";
        }
    }
}
