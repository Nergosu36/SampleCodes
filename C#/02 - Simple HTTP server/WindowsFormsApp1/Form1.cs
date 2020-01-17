using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string myFolder;
        int port;
        Program2 myServer;
        bool running=false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (running)
                return;
            if (textBox1.Text != null)
            {
                myFolder = @""+textBox1.Text;
            }
            else
            {
                myFolder = null;
            }

            if (textBox2.Text != null)
            {
                if (int.TryParse(textBox2.Text, out port))
                {
                    port = Convert.ToInt32(textBox2.Text);
                }
                else
                {
                    //parsing failed. 
                }
            }
            else
            {
                port = 0;
            }
            
            if(myFolder.Length>0)
                if(port!=0)
                    myServer = new Program2(myFolder, port);
                else
                    myServer = new Program2(myFolder);
            else if(port!=0)
                myServer = new Program2(port);
            else
                myServer = new Program2();
            running = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            myServer.Stop();
            running = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void readOnlyTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void readOnlyTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class Program2
    {
        private Thread _serverThread;
        private string _rootDirectory;
        private HttpListener _listener;
        private int _port;
       

        public int Port
        {
            get { return _port; }
        }

        public Program2(string path, int port)
        {
            this.Setup(path, port);
        }
        public Program2()
        {
            string path = @".\pliki\def\index.html";
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            this.Setup(path, port);
        }
        public Program2(string path)
        {
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            this.Setup(path, port);
        }
        public Program2(int _port)
        {
            string path = @".\pliki\def\index.html";
            int port = _port;
            this.Setup(path, port);
        }
        public void Stop()
        {
            _serverThread.Abort();
            _listener.Stop();
        }
        private void Setup(string path, int port)
        {
            this._rootDirectory = path;
            this._port = port;
            _serverThread = new Thread(this.Listen);
            _serverThread.Start();
            Console.Write("Server running at: " + port + " port, in: "+_rootDirectory+"\n");
        }
        private void Listen()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://*:" + _port.ToString() + "/");
            _listener.Start();
            while (true)
            {
                try
                {
                    HttpListenerContext context = _listener.GetContext();
                    Content(context);
                }
                catch (Exception ex)
                {

                }
            }
        }
        private void Content(HttpListenerContext context)
        {
            if (_rootDirectory == @".\pliki\def\index.html")
            {
                string filename = _rootDirectory;
                if (File.Exists(filename))
                {
                    try
                    {
                        Console.Write(_rootDirectory + "\n");
                        string lines = File.ReadAllText(filename);
                        context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(lines);
                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                        using (Stream stream = context.Response.OutputStream)
                        {
                            using (StreamWriter writer = new StreamWriter(stream))
                            {
                                writer.Write(lines);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        Console.Write("500, server error.\n");
                    }
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    Console.Write("404, not found.\n");
                }
            }
            else
            {
                Random rand = new Random();
                string[] array2 = Directory.GetFiles(_rootDirectory);
                string filename = array2[rand.Next(array2.Length)];
                Console.Write(array2[rand.Next(array2.Length)] + "\n");
                if (File.Exists(filename))
                {
                    try
                    {
                        string lines = File.ReadAllText(filename);
                        context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(lines);
                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                        using (Stream stream = context.Response.OutputStream)
                        {
                            using (StreamWriter writer = new StreamWriter(stream))
                            {
                                writer.Write(lines);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        Console.Write("500, server error.\n");
                    }
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    Console.Write("404, not found.\n");
                }
            }
        }
    }


}
