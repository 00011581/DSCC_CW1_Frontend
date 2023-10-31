﻿namespace Frontend.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public Topic Topic { get; set; }
    }
}
