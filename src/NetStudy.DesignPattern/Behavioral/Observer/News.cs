﻿namespace NetSutdy.DesignPattern.Behavioral.Observer.ObserverPull
{
    public class News
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public News(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}
