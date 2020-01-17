using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{

		public Form1()
		{
			InitializeComponent();
			Read(filepath);
			SortD(nazwiska);
			SortT(nazwiska);
		}
		public static List<string> nazwiska = new List<string>();
		public static string filepath = @"C:\Users\Nergosu\source\repos\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\nazwiska8.txt";

		public void Read(string fileName)
		{
			using (StreamReader sr = new StreamReader(filepath))
			{
				string s = String.Empty;
				var stopwatch = new Stopwatch();
				stopwatch.Start();
				while ((s = sr.ReadLine()) != null)
				{

					Regex re = new Regex(@"(\d+)(\s)([a-zA-Z]+)");
					Match result = re.Match(s);

					string alphaPart = result.Groups[3].Value;
					string numberPart = result.Groups[1].Value;
					nazwiska.Add(alphaPart);
				}
				stopwatch.Stop();
				var elapsed_time = stopwatch.Elapsed;
				label1.Text = "Czas wczytywania danych: \t" + elapsed_time.ToString() + "\n";
			}
		}

		StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;

		Dictionary<string, List<string>> Dwa = new Dictionary<string, List<string>>();
		Dictionary<string, List<string>> Try = new Dictionary<string, List<string>>();

		public void SortD(List<string> _nazwiska)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			for (int i = 0; i < _nazwiska.Count(); i++)
			{
				string inicjaly = String.Empty;
				if (_nazwiska[i].Count() >= 2)
				{
					inicjaly = _nazwiska[i][0].ToString() + _nazwiska[i][1].ToString();
				}
				else
				{
					continue;
				}
				/*if (i == 0)
				{
					//label1.Text = _nazwiska[0][0].ToString();					
					Dwa.Add(inicjaly, new List<string>{_nazwiska[0]});
				}*/
				List<string> existing;
				if (Dwa.TryGetValue(inicjaly, out existing))
				{
					Dwa[inicjaly] = existing;
					existing.Add(_nazwiska[i]);
				}
				else
				{
					Dwa.Add(inicjaly, new List<string> { _nazwiska[i] });
				}
			}
			stopwatch.Stop();
			var elapsed_time = stopwatch.Elapsed;
			label1.Text += "Czas tworzenia struktur 2-znakowych: \t" + elapsed_time.ToString() +"\n";
			/*comboBox1.DataSource = Dwa.Values;
			comboBox1.DisplayMember = "Name";
			comboBox1.ValueMember = "Cities";*/
			//comboBox1.AutoCompleteSource.Insert(Dwa);
		}
		public void SortT(List<string> _nazwiska)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();
			for (int i = 0; i < _nazwiska.Count(); i++)
			{
				string inicjaly = String.Empty;
				if (_nazwiska[i].Count() >= 3)
				{
					inicjaly = _nazwiska[i][0].ToString() + _nazwiska[i][1].ToString() + _nazwiska[i][2].ToString();
				}
				else
				{
					continue;
				}
				/*if (i == 0)
				{
					//label1.Text = _nazwiska[0][0].ToString();					
					Dwa.Add(inicjaly, new List<string>{_nazwiska[0]});
				}*/
				List<string> existing;
				if (Try.TryGetValue(inicjaly, out existing))
				{
					Try[inicjaly] = existing;
					existing.Add(_nazwiska[i]);
				}
				else
				{
					Try.Add(inicjaly, new List<string> { _nazwiska[i] });
				}
			}
			stopwatch.Stop();
			var elapsed_time = stopwatch.Elapsed;
			label1.Text += "Czas tworzenia struktur 3-znakowych: \t" + elapsed_time.ToString();
			/*comboBox1.DataSource = Dwa.Values;
			comboBox1.DisplayMember = "Name";
			comboBox1.ValueMember = "Cities";*/
			//comboBox1.AutoCompleteSource.Insert(Dwa);
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void comboBox1_TextChanged(object sender, EventArgs e)
		{
			if (comboBox1.Text.Length < 2)
			{
				List<string> existing;
				existing = new List<string>() { "Brak wyników" };
				comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
				comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
				var autoComplete = new AutoCompleteStringCollection();
				autoComplete.AddRange(existing.ToArray());
				comboBox1.AutoCompleteCustomSource = autoComplete;
			}
			if (comboBox1.Text.Length == 2)
			{
				string inicjaly = String.Empty;
				inicjaly = comboBox1.Text[0].ToString().ToUpper()+ comboBox1.Text[1].ToString();
				List<string> existing;
				if (Dwa.TryGetValue(inicjaly, out existing))
				{
					Dwa[inicjaly] = existing;
				}
				else
				{
					existing = new List<string>() { "Brak wyników" };
				}
				BindingSource bs = new BindingSource();
				bs.DataSource = existing;
				//comboBox1.DataSource = bs;
				comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
				comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
				var autoComplete = new AutoCompleteStringCollection();
				autoComplete.AddRange(existing.ToArray());
				comboBox1.AutoCompleteCustomSource = autoComplete;

				/*foreach (KeyValuePair<string, List<string>> item in Dwa)
				{
					for (int i = 0; i < item.Value.Count(); i++)
					{
						comboBox1.AutoCompleteCustomSource.Insert(i, item.Value[i]);
					}
				}*/
			}
			if (comboBox1.Text.Length == 3)
			{
				string inicjaly = String.Empty;
				inicjaly = comboBox1.Text[0].ToString().ToUpper() + comboBox1.Text[1].ToString() + comboBox1.Text[2].ToString();
				List<string> existing;
				if (Try.TryGetValue(inicjaly, out existing))
				{
					Try[inicjaly] = existing;
				}
				else
				{
					existing = new List<string>() { "Brak wyników" };
				}
				BindingSource bs = new BindingSource();
				bs.DataSource = existing;
				//comboBox1.DataSource = bs;
				comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
				comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
				var autoComplete = new AutoCompleteStringCollection();
				autoComplete.AddRange(existing.ToArray());
				comboBox1.AutoCompleteCustomSource = autoComplete;
				/*foreach (KeyValuePair<string, List<string>> item in Dwa)
				{
					for (int i = 0; i < item.Value.Count(); i++)
					{
						comboBox1.AutoCompleteCustomSource.Insert(i, item.Value[i]);
					}
				}*/
			}
			if (comboBox1.Text != null)
				comboBox1.Select(comboBox1.Text.Length, 0);
			/*if (comboBox1.Text.Length == 3)
			{
				foreach (KeyValuePair<string, List<string>> item in Try)
				{
					for (int i = 0; i < item.Value.Count(); i++)
					{
						comboBox1.AutoCompleteCustomSource.Insert(i, item.Value[i]);
					}
				}
			}*/
		}
	}
}
