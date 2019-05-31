using System;

namespace XamarinFormsSvgSample.Models
{
    public class Item
    {
        public Item(string id, string iconUrl, string text, string description)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            IconUrl = iconUrl ?? throw new ArgumentNullException(nameof(iconUrl));
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public string Id { get; }
        public string IconUrl { get; }
        public string Text { get; }
        public string Description { get; }
    }
}