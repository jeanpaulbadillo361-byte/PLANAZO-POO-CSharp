namespace PLANAZO_POO_CSharp.Modelos
{
    public class Usuario
    {
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        public Usuario(string documento, string nombre, string email)
        {
            Documento = documento;
            Nombre = nombre;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Nombre} (Doc: {Documento})";
        }
    }
}
