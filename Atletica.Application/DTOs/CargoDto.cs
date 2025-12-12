namespace Atletica.Application.DTOs
{
    public class CargoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }

    public class CreateCargoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }

    public class UpdateCargoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
