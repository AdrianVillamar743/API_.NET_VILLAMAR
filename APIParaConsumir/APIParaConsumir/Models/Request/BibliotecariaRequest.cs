namespace APIParaConsumir.Models.Request
{
    public class BibliotecariaRequest
    {
        public int IdBibliotecaria { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdBiblioteca { get; set; }
    }
}
