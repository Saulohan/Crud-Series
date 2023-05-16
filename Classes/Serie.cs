using Crud;

namespace Crud
{
    public class Serie :BaseEntity
    {

        private Genres Gender { get; set; }

        private string Title { get; set; }

        private string Description { get; set; }

        private int Year { get; set; }

        private bool Deletion { get; set; }

        public Serie(int id, Genres gender, string title, string description, int year)
        {
            this.Id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deletion = false;
        }

        public override string ToString()
        {
            string result = "";

            result += "Genero" + this.Gender + Environment.NewLine;
            result += "Titulo" + this.Title + Environment.NewLine;
            result += "Descrição" + this.Description + Environment.NewLine;
            result += "Ano de Inicio" + this.Year + Environment.NewLine;
            result += "Excluido" + this.Deletion + Environment.NewLine;

            return result;
        }

        public string ReturnTitle()
        {
            return this.Title;
        }
        public int ReturnId()
        {
            return this.Id;
        }

        public bool ReturnDeletion()
        {
            return this.Deletion;
        }

        public void Delition(){
            this.Deletion = true;
        }
    }
}