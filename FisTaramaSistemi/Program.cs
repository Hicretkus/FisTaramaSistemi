using Newtonsoft.Json.Linq;

namespace FisTaramaSistemi
{
	class Program
	{
		static void Main(string[] args)
		{

			string jsonFilePath = @"C:\Users\acer\Downloads\response.json";

			string jsonText = File.ReadAllText(jsonFilePath);

			JArray response = JArray.Parse(jsonText);

			if (response != null && response.Count > 0)
			{
				var firstItem = response[0];

				var firstVertex = firstItem["boundingPoly"]["vertices"][0];

				int x = (int)firstVertex["x"];

				int y = (int)firstVertex["y"];


				string description = (string)firstItem["description"];

				string formattedLine = $"{description}";

				Console.WriteLine(formattedLine);
			}

			Console.ReadKey();
		}
	}
}