
namespace AboutPrintManager
{
	public static class PrintManager
	{
		public static void PrintToConsole(string[] ThingsToPrint)
		{
			for (int i = 0; i < ThingsToPrint.Length; i++)
			{
				Console.WriteLine(ThingsToPrint[i]);
			}
		}

		public static void PrintToConsole(string ThingToPrint)
		{
			Console.WriteLine(ThingToPrint);
		}

		public static void PrintToConsole(List<string> ThingsToPrint, int sectionNum)
		{
			string sos = $"#SOS{sectionNum}";
			string eos = $"#EOS{sectionNum}";
			int sosIndex = ThingsToPrint.FindIndex(item => item == sos);

			for (int i = sosIndex + 1; ; i++)
			{
				string tmp = ThingsToPrint[i];
				if (tmp == eos)
				{
					break;
				}
				Console.WriteLine(tmp);
			}
		}

		public static void PrintToConsole(List<string> ThingsToPrint, int sectionNum, int branchNum)
		{
			string sos = $"#SOS{sectionNum}-{branchNum}";
			string eos = $"#EOS{sectionNum}-{branchNum}";
			int sosIndex = ThingsToPrint.FindIndex(item => item == sos);

			for (int i = sosIndex + 1; ; i++)
			{
				string tmp = ThingsToPrint[i];
				if (tmp == eos)
				{
					break;
				}
				Console.WriteLine(tmp);
			}
		}
	}
}