﻿namespace GerenciadorLivros.API.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int YearPublicacion { get; set; }
    }
}
