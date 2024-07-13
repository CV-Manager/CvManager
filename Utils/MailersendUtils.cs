using System.Text;
using System.Text.Json;
// using CvManager.Models;

namespace CvManager.Utils
{
    public class MailersendUtils
    {
        public async void EnviarCorreo(string emailUser)
        {
            string url = "https://api.mailersend.com/v1/email";
            string tokenEmail = "mlsn.615e5bfb39cbde0a574fca52d21fcd3c2a28b53d02bfb57e5e31b26a50dae228";

            var emailMessage = new Emails
            {
                from = new From { email = "MS_W42PgZ@trial-3z0vklozo0v47qrx.mlsender.net" },
                to =
                [
                    new To { email = emailUser},
                ],
                subject = "ENVIO",
                text = $"Su cita ha sido creada exitosamente"
            };
            // Serializar el objeto email en formato JSON:
            string jsonBody = JsonSerializer.Serialize(emailMessage);

            using (HttpClient client = new HttpClient())
            {
                //configurar el encabezado de Authorization para indicar el token de autorizacion :
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.
                AuthenticationHeaderValue("Bearer", tokenEmail);

                // crear el contenido de la solicitud POST como stringContent :  Encoding.UTF8 esto encripta
                StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                //realizar la solicitud POST a la URL indicada:
                HttpResponseMessage response = await client.PostAsync(url, content);

                //verificar si la solicitud fue exitosa (codigo de estado: 200 - 209):
                if (response.IsSuccessStatusCode)
                {
                    //se muestra el estado de la solicitud :
                    Console.WriteLine($"Estado de la solicitud :{response.StatusCode}");
                }
                else
                {
                    // si la solicitud no fue exitosa, se muestra el estado de la solicitud :
                    Console.WriteLine($"correo no enviado : {response.StatusCode}");
                }
            }
        }
    }
}