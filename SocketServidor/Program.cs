using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketServidor
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 1) Declaramos el socket servidor con sus caracteristicas de coneccion */
            Socket servidor = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

            /* 2) Establecemos la direccion del socket servidor, en este caso nuestra direccion local
             Se cambia a necesidad de la aplicacion o donde se encuentre situada*/
            IPEndPoint direccion = new IPEndPoint(IPAddress.Parse("127.0.0.1"),1234);

            /* 3) Le asignamos la direccion al socket, la cantidad de conexiones a la vez*/
            servidor.Bind(direccion);
            servidor.Listen(5);

            Console.WriteLine("Mordor is listening in the shadows...");

            Socket escuchar = servidor.Accept();
            Console.WriteLine(" His followers arrived at the scene ");


            /* 4) Le asignamos una variable para guardar y mostrar el mensaje escrito por el socket Cliente*/
            byte[] mensaje = new byte[255];
            int msjSize = escuchar.Receive(mensaje, 0, mensaje.Length, 0);
            Array.Resize(ref mensaje,msjSize);
            Console.WriteLine(" And the followers of Mordor said '"+ Encoding.Default.GetString(mensaje)+"' And rapidly ran away");
            servidor.Close();

            Console.WriteLine("Presione cualquier tecla para terminar");
            Console.ReadKey();
        }
    }
}
