using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JuegoRol
{
    class ProvinciasApi
    {
        public static ProvinciasArgentinas GetProvincias()
        {
            var url = $"https://apis.datos.gob.ar/georef/api/provincias";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            ProvinciasArgentinas ListProvincias = null;

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream()){
                        if(strReader != null)
                        {
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                ListProvincias = JsonSerializer.Deserialize<ProvinciasArgentinas>(responseBody);
                            }
                        }
                    }
                }
            }

            catch (WebException ex)
            {
                // Handle error
            }

            return ListProvincias;
        }
    }


    public class Parametros
    {
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
    }

    public class Centroide
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }
    }

    public class Provincia
    {
        [JsonPropertyName("centroide")]
        public Centroide Centroide { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
    }

    public class ProvinciasArgentinas
    {
        [JsonPropertyName("cantidad")]
        public int Cantidad { get; set; }

        [JsonPropertyName("inicio")]
        public int Inicio { get; set; }

        [JsonPropertyName("parametros")]
        public Parametros Parametros { get; set; }

        [JsonPropertyName("provincias")]
        public List<Provincia> Provincias { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }

}
