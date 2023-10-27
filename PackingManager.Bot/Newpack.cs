using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PackingManager.Bot
{
	internal class Newpack
	{
		public string Nazwa { get; set; }
		public string Numer_Zamowlenia { get; set; }
		public string NUmer_Paczki { get; set; }

		public string Waga_Paczki { get; set; }


		public Newpack()
		{
	
        }
		public static void writeInfo()
		{
			Console.WriteLine("NEW PACK");
		}

}
}
