using Newtonsoft.Json.Linq; // Newtonsoft.Json kütüphanesinden JArray gibi JSON işlemleri için gerekli nesneleri kullanabilmek için eklendi.

namespace FisTaramaSistemi
{
	class Program
	{
		static async Task Main(string[] args)
		{
			try
			{
				string jsonFilePath = @"C:\Users\acer\Downloads\response.json";  // jsonFilePath değişkeni dosyanın yolunu tutar.

				
				string jsonText = await File.ReadAllTextAsync(jsonFilePath); // await File.ReadAllTextAsync(jsonFilePath) ifadesiyle dosyanın içeriği bir string olarak jsonText değişkenine atanır.

				JArray response = JArray.Parse(jsonText); // jsonText içindeki JSON verisi JArray.Parse metodu ile bir JArray nesnesine dönüştürülür. JSON verisinin bir dizi olarak işlenmesini sağlar.

				if (response?.Count > 0) // response JArray'indeki ilk öğeyi işler. 
				{
					var firstItem = response[0]; // eğer dizi boş değilse, dizinin ilk öğesini (firstItem) alır.

					var firstVertex = firstItem["boundingPoly"]?["vertices"]?[0]; // firstItem içindeki "boundingPoly" anahtarına ait nesnenin "vertices" dizisinin ilk elemanı (firstVertex) alınır.

					int x = firstVertex?["x"]?.ToObject<int>() ?? 0; // firstVertex içindeki x ve y koordinatları çıkarılır. Eğer bu değerler null ise varsayılan olarak 0 atanır.
					int y = firstVertex?["y"]?.ToObject<int>() ?? 0; 

					string description = (string)firstItem["description"]; //  firstItem içindeki "description" anahtarına ait değer string olarak description değişkenine atanır.

					
					Console.WriteLine($"{description}"); // description değişkenindeki değer konsola yazdırılır.
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
