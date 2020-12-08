using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Juventus_Szilágyi
{
	struct Focista
	{
		public int Mez { get; set; }
		public string Nev { get; set; }
		public string Nem { get; set; }
		public string Poszt { get; set; }
		public int Szul { get; set; }
	}
	class Program
	{
		static void Main()
		{
			int seg = -1;
			int olaszok = 0;
			string eler = "juve.txt";
			List<string> sorok = File.ReadAllLines(eler).ToList();
			var csapat = new List<Focista>();
			foreach (var sor in sorok)
			{
				string[] darabok = sor.Split(';');

				csapat.Add(new Focista() { Mez = Int32.Parse(darabok[0]), Nev = darabok[1], Nem = darabok[2], Poszt = darabok[3], Szul = Int32.Parse(darabok[4]) });
			}
			//1. kérdés
			Console.WriteLine(csapat.Count + " igazolt játékosa van a csapatnak.");

			//2. kérdés
			foreach (var jat in csapat)
			{
				if (jat.Nem == "magyar")
				{
					seg = 1;
				}
			}
			if (seg == 1)
			{
				Console.WriteLine("Van magyar a csapatba.");
			}
			else
			{
				Console.WriteLine("Nincs magyar a csapatba.");
			}

			//3. kérdés
			foreach (var jat in csapat)
			{
				if (jat.Nem == "olasz")
				{
					olaszok++;
				}
			}
			Console.WriteLine(olaszok + " olasz van a csapatba");

			//4. kérdés
			Focista fiatal = csapat[0];
			foreach (var jat in csapat)
			{
				if (jat.Szul > fiatal.Szul)
				{
					fiatal = jat;
				}
			}
			Console.WriteLine(fiatal.Nev + " a legfiatalabb a csapatba");

			//5. 
			Console.ReadKey();
		}
	}
}
