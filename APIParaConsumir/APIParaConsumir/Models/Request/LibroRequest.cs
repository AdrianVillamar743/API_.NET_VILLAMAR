namespace APIParaConsumir.Models.Request
{
    public class LibroRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdBibliotecaria { get; set; }
    }
}
