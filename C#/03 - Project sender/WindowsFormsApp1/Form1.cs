using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string sln;
        public Form1()
        {
            InitializeComponent();
        }
        void Search(string path)
        {
            string[] file = Directory.GetFiles(path, "*.sln");

            if (file.Length != 0)
                sln= file[0];
            else
                sln= "";

            Console.Write("sln: "+sln+"\n"); //debug (if konsola on)

            if(sln.Length>0)
            {
                string[] files = Directory.GetFiles(path, "*.*proj", SearchOption.AllDirectories);
                if (files.Length == 1)
                {
                    List<string> filesToCopy = new List<string>();
                    List<XmlNodeList> el = new List<XmlNodeList>();
                    XmlDocument xml = new XmlDocument();
                    xml.PreserveWhitespace = true;
                    xml.Load(files[0]);

                    el.Add(xml.GetElementsByTagName("Compile"));
                    el.Add(xml.GetElementsByTagName("EmbeddedResource"));
                    el.Add(xml.GetElementsByTagName("None"));
                    foreach (XmlNodeList element in el)
                    {
                        foreach (XmlNode item in element)
                        {
                            filesToCopy.Add(Path.GetDirectoryName(files[0]) + Path.DirectorySeparatorChar + item.Attributes["Include"].Value);
                        }
                    }
                    if (filesToCopy.Count > 0)
                    {
                        string folder = Path.GetDirectoryName(sln) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(sln) + "copyDestination";
                        Directory.CreateDirectory(folder);
                        foreach (string fil in filesToCopy)
                        {
                            Console.Write(fil+"\n");

                            File.Copy(fil, folder + Path.DirectorySeparatorChar + Path.GetFileName(fil));
                        }
                    }
                    else
                        Console.Write("Brak plików do skopiowania");
                }
                else
                    Console.Write("Nie znaleziono plików projektu");
            }
            else
                Console.Write("Nie znaleziono pliku .sln");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath == "")
                Search(AppDomain.CurrentDomain.BaseDirectory);
            else
                Search(folderBrowserDialog1.SelectedPath);
        }
    }
}
