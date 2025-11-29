namespace Apitest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            var rutaEspecies = "api/Especies";
            httpClient.BaseAddress = new Uri("https://localhost:7241/");
            //Lecturda de datos
            var response = httpClient.GetAsync(rutaEspecies).Result;
            var json = response.Content.ReadAsStringAsync().Result;

            var especies = Newtonsoft.Json.JsonConvert.DeserializeObject<Prueba_Clases.ApiResult<List<Prueba_Clases.Especie>>>(json);
            //Inserccion de datos
            var nuevaEspecie = new Prueba_Clases.Especie
            {
                Id = 0,
                NombreEspecie = "xyz"
            };
            //Invocar al servicio web para insertar la nueva especie    

            var jsonNuevaEspecie = Newtonsoft.Json.JsonConvert.SerializeObject(nuevaEspecie);
            var content = new StringContent(jsonNuevaEspecie, System.Text.Encoding.UTF8, "application/json");
            response = httpClient.PostAsync(rutaEspecies, content).Result;
            json = response.Content.ReadAsStringAsync().Result;
            //Deserializar la respuesta
            var especieCreada = Newtonsoft.Json.JsonConvert.DeserializeObject<Prueba_Clases.ApiResult<Prueba_Clases.Especie>>(json);
            //Actulizacion de datos 
            especieCreada.Data.NombreEspecie = "xyz Actuzalido"; 
            jsonNuevaEspecie = Newtonsoft.Json.JsonConvert.SerializeObject(especieCreada.Data);    
            content = new StringContent(jsonNuevaEspecie, System.Text.Encoding.UTF8, "application/json");
            response = httpClient.PutAsync($"{rutaEspecies}/{especieCreada.Data.Id}", content).Result;
            json = response.Content.ReadAsStringAsync().Result;
            var especieActulizada = Newtonsoft.Json.JsonConvert.DeserializeObject<Prueba_Clases.ApiResult<Prueba_Clases.Especie>>(json);
            //Eliminacion de datos
            response = httpClient.DeleteAsync($"{rutaEspecies}/{especieCreada.Data.Id}").Result; 
            json = response.Content.ReadAsStringAsync().Result;
            var especieEliminada = Newtonsoft.Json.JsonConvert.DeserializeObject<Prueba_Clases.ApiResult<Prueba_Clases.Especie>>(json);

            Console.WriteLine(json);
            Console.ReadLine();
            //sdfsdgfsd
        }
    }
}
