﻿using Xamarin.Forms;
using System.Windows.Input;
using System.Collections;

namespace CustomControls
{
    public class InfiniteListView : ListView
    {
        public static readonly BindableProperty LoadMoreCommandProperty = BindableProperty.Create<InfiniteListView, ICommand>(bp => bp.LoadMoreCommand, default(ICommand));

        public ICommand LoadMoreCommand
        {
            get { return (ICommand)GetValue(LoadMoreCommandProperty); }
            set { SetValue(LoadMoreCommandProperty, value); }
        }

        public InfiniteListView()
        {
            SeparatorColor = Color.FromHex("#b455b6");
            BackgroundColor = Color.FromHex("#77d065");
            ItemAppearing += OnItemAppearing;
            ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };
        }

        private void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var items = ItemsSource as IList;

            if (items != null && e.Item == items[items.Count - 1])
            {
                if (LoadMoreCommand != null && LoadMoreCommand.CanExecute(null))
                    LoadMoreCommand.Execute(null);
            }
        }
    }
}