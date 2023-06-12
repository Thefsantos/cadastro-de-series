using System;

namespace Cadastro_de_Series
{
    public class Serie : EntityBase
    {
        // Constructor
        public Serie(int id, Genre genre, string title, string description, int year){
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;

        }

        // Attribute
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set;}

        public override string ToString()
        {
            string returnn = "";
            returnn += "Genre: " + this.Genre + Environment.NewLine;
            returnn += "Title: " + this.Title + Environment.NewLine;
            returnn += "Description: " + this.Description + Environment.NewLine;
            returnn += "Year: " + this.Year + Environment.NewLine;
            returnn += "Deleted: " + this.Deleted + Environment.NewLine;
            return returnn;
        }

        public string ReturnTitle()
        {
            return this.Title;
        }
        public int ReturnId()
        {
            return this.Id;
        }

        public void Delete() {
            this.Deleted = true;
        }
    }
}