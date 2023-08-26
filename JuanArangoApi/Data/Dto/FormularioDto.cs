using JuanArangoApi.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuanArangoApi.Data.Dto
{
    public class FormularioDto
    {
        public string Pregunta_1 { get; set; } = string.Empty;
        public string Respuesta_1 { get; set; } 
        public string Pregunta_2 { get; set; } = string.Empty;
        public string Respuesta_2 { get; set; }
        public string Pregunta_3 { get; set; } = string.Empty;
        public string Respuesta_3 { get; set; }
        public string Latitud { get; set; } = string.Empty;
        public string Longitud { get; set; } = string.Empty;
        public long UserId { get; set; }

    }
}
