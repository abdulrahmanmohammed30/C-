using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
//using Internal;

namespace Events
{
    public class NewsPublishedEventArgs : EventArgs
    {
        public string Title { get; }
        public string Content { get; }
        public string Category { get; }

        public NewsPublishedEventArgs(string category, string title, string content)
        {
            Category = category;
            Title = title;
            Content = content;
        }
    }

    public class NewsPublisher
    {
        private Dictionary<string, Action<NewsPublishedEventArgs>> _subscribers =
        new Dictionary<string, Action<NewsPublishedEventArgs>>();

        public void PublishNews(string category, string title, string content)
        {
            Console.WriteLine("Publishing news: " + title);

            OnNewsPublished(new NewsPublishedEventArgs(category, title, content));
        }

        public void AddEventHandlerFor(string category)
        {
            if (_subscribers.ContainsKey(category))
            {
                Console.WriteLine("Category is already exists");
                return; ;
            }
            _subscribers[category] = delegate { };
        }
        public void Subscribe(string category, Action<NewsPublishedEventArgs> handler)
        {

            if (string.IsNullOrEmpty(category))
                throw new Exception("Category cannot be null or empty");

            if (_subscribers.TryGetValue(category, out Action<NewsPublishedEventArgs> categoryEventHanlder))
            {
                if (categoryEventHanlder.GetInvocationList().Contains(handler))
                {
                    Console.WriteLine($"Handle is already exists for {category}");
                    return;
                }
                else
                {
                    Console.WriteLine($"Handler added for '{category}'.");
                    _subscribers[category] += handler;
                }
            }
            else
                throw new Exception("Category does't exist. Provide a valid category.");
        }

        public void Unsubscribe(string category, Action<NewsPublishedEventArgs> handler)
        {

            if (string.IsNullOrEmpty(category))
                throw new Exception("Category cannot be null or empty");

            if (_subscribers.TryGetValue(category, out Action<NewsPublishedEventArgs> categoryEventHanlder))
            {
                if (categoryEventHanlder.GetInvocationList().Contains(handler))
                {
                    _subscribers[category] -= handler;
                    return;
                }
                else
                {
                    Console.WriteLine($"Handle doesn't already exists for {category}");
                }
            }
            else
                throw new Exception("Category does't exist. Provide a valid category.");
        }

        protected virtual void OnNewsPublished(NewsPublishedEventArgs e)
        {
            _subscribers[e.Category]?.Invoke(e);
        }

    }


    public class NewsReader
    {
        private string _name;

        public NewsReader(string name)
        {
            _name = name;
        }
        public void OnNewsReceived(NewsPublishedEventArgs e)
        {
            Console.WriteLine($"{_name} is reading news: {e.Title} - {e.Content} - {e.Category}");
        }
    }

    public class NewsAggregator
    {
        public void OnNewsReceived(NewsPublishedEventArgs e)
        {
            Console.WriteLine($"Aggregating news: {e.Title} - {e.Content} - {e.Category}");
        }
    }


}