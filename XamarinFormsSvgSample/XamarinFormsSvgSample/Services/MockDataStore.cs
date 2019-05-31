using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinFormsSvgSample.Models;

namespace XamarinFormsSvgSample.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        private readonly List<Item> _items = new List<Item>();

        public MockDataStore()
        {
            CreateMockItems();
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = _items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            _items.Remove(oldItem);
            _items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = _items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            _items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(_items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_items);
        }

        private void CreateMockItems()
        {
            var icons = new[]
            {
                "https://material.io/tools/icons/static/icons/baseline-cloud_done-24px.svg",
                "https://material.io/tools/icons/static/icons/baseline-flare-24px.svg",
                "https://material.io/tools/icons/static/icons/baseline-airplanemode_active-24px.svg",
                "https://material.io/tools/icons/static/icons/baseline-move_to_inbox-24px.svg",
                "https://material.io/tools/icons/static/icons/baseline-unarchive-24px.svg",
                "https://material.io/tools/icons/static/icons/baseline-hd-24px.svg",
                "https://material.io/tools/icons/static/icons/baseline-stars-24px.svg",
                "https://material.io/tools/icons/static/icons/baseline-build-24px.svg",
                "https://material.io/tools/icons/static/icons/baseline-tab_unselected-24px.svg",
                "https://material.io/tools/icons/static/icons/baseline-view_quilt-24px.svg",
                "https://material.io/tools/icons/static/icons/baseline-view_quilt-24px.svg",
                "https://material.io/tools/icons/static/icons/baseline-mood-24px.svg",
                "https://material.io/tools/icons/static/icons/baseline-thumb_up_alt-24px.svg",
                "https://material.io/tools/icons/static/icons/baseline-notifications_active-24px.svg"
            };

            var rnd = new Random();

            for (var i = 1; i < 100; i++)
            {
                var iconIndex = rnd.Next(0, icons.Length - 1);
                _items.Add(new Item(Guid.NewGuid().ToString(), icons[iconIndex], $"Item {i}", $"This is the description of item {i}"));
            }
        }
    }
}