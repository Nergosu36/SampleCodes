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
                    XmlDocument doc = new XmlDocument();

                    doc.PreserveWhitespace = true;
                    doc.Load(files[0]);
                    List<XmlNodeList> el = new List<XmlNodeList>();

                    el.Add(doc.GetElementsByTagName("Compile"));
                    el.Add(doc.GetElementsByTagName("EmbeddedResource"));
                    el.Add(doc.GetElementsByTagName("None"));

                    foreach (XmlNodeList element in el)
                    {
                        foreach (XmlNode item in element)
                        {
                            filesToCopy.Add(files[0] + item.Attributes["Include"].Value);
                        }
                    }
                    if (filesToCopy.Count > 0)
                    {
                        string folder = sln + "copyDestination";
                        Directory.CreateDirectory(folder);
                        foreach (string fil in filesToCopy)
                        {
                            string[] paths = fil.Split(Path.DirectorySeparatorChar);
                            string dirToCopy = fil.Substring(0, fil.Length - paths[paths.Length - 1].Length);
                            string fileToCopy = paths[paths.Length - 1];
                            string finalToCopy;
                            if (fileToCopy.Contains(Path.DirectorySeparatorChar))
                                finalToCopy = fileToCopy;
                            else
                                finalToCopy = dirToCopy + fileToCopy;
                            Console.Write(fil+"\n");

                            //File.Copy(fil, folder);
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
        /*private void StartAnalyze()
        {
            string slnFilePath = FindFile(path, "*.sln", false);
            if (slnFilePath != "")
            {


                string projFilePath = FindFile(path, "*.*proj", true);
                if (projFilePath != "")
                {


                    string pathToCopiedFiles = CopyFiles(GetPathOfParentDirectory(slnFilePath), AnalyzeXML(projFilePath));


                    System.Diagnostics.Process.Start("explorer.exe", pathToCopiedFiles);
                }
                else
                {

                }
            }
            else
            {

            }
        }

        private string FindFile(string path, string fileName, bool searchInSubdirectories)
        {
            string[] files = (searchInSubdirectories) ? Directory.GetFiles(path, fileName, SearchOption.AllDirectories) : Directory.GetFiles(path, fileName);

            if (files.Length != 0) return files[0];
            return "";
        }

        private List<string> AnalyzeXML(string fileName)
        {
            string pathToFile = GetPathOfParentDirectory(fileName);
            List<string> files = new List<string>();

            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(fileName);

            List<XmlNodeList> elements = new List<XmlNodeList>();
            elements.Add(doc.GetElementsByTagName("Compile"));
            elements.Add(doc.GetElementsByTagName("EmbeddedResource"));
            elements.Add(doc.GetElementsByTagName("None"));

            foreach (XmlNodeList element in elements)
            {
                foreach (XmlNode item in element)
                {
                    files.Add(pathToFile + item.Attributes["Include"].Value);
                }
            }

            return files;
        }

        private string CopyFiles(string destinationPath, List<string> filesToCopyPaths)
        {
            string nameOfCreatedFolder = destinationPath + "Kopia";
            while (Directory.Exists(nameOfCreatedFolder))
            {
                nameOfCreatedFolder += "a";
            }

            Directory.CreateDirectory(nameOfCreatedFolder);

            foreach (string filePath in filesToCopyPaths)
            {
                string fileName = filePath;
                if (filePath.Contains(Path.DirectorySeparatorChar)) fileName = GetNameOfFileFromPath(filePath);

                File.Copy(filePath, nameOfCreatedFolder + Path.DirectorySeparatorChar + fileName);
            }

            return nameOfCreatedFolder;
        }

        private string GetPathOfParentDirectory(string filePath)
        {
            string[] path = filePath.Split(Path.DirectorySeparatorChar);
            return filePath.Substring(0, filePath.Length - path[path.Length - 1].Length);
        }

        private string GetNameOfFileFromPath(string filePath)
        {
            string[] path = filePath.Split(Path.DirectorySeparatorChar);
            return path[path.Length - 1];
        }*/
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
