using Newtonsoft.Json.Linq;

namespace FisTaramaSistemi
{
	class Program
	{
		static async Task Main(string[] args)
		{
			try
			{
				string jsonFilePath = @"C:\Users\acer\Downloads\response.json";

				
				string jsonText = await File.ReadAllTextAsync(jsonFilePath);

				JArray response = JArray.Parse(jsonText);

				if (response?.Count > 0) 
				{
					var firstItem = response[0];

					var firstVertex = firstItem["boundingPoly"]?["vertices"]?[0];

					int x = firstVertex?["x"]?.ToObject<int>() ?? 0; 
					int y = firstVertex?["y"]?.ToObject<int>() ?? 0; 

					string description = (string)firstItem["description"];

					
					Console.WriteLine($"{description}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Bir hata oluştu: {ex.Message}");
			}

			Console.ReadKey();
		}
	}
}