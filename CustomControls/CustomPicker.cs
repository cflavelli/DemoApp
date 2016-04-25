using System;
using System.Collections;
using System.Windows.Input;

using Xamarin.Forms;

namespace CustomControls
{
	public class CustomPicker : Picker
	{
		public static BindableProperty ItemsSourceProperty = BindableProperty.Create<CustomPicker, IEnumerable>(x => x.ItemsSource, default(IEnumerable), BindingMode.OneWay, null, OnItemsSourceChanged);

		public static BindableProperty SelectedItemProperty = BindableProperty.Create<CustomPicker, object>(x => x.SelectedItem, default(object), BindingMode.TwoWay, null, OnSelectedItemChanged);

		public static readonly BindableProperty ItemSelectedCommandProperty = BindableProperty.Create("ItemSelectedCommand", typeof(ICommand), typeof(CustomPicker), null, BindingMode.OneWay); 

		public IList ItemsSource
		{
			get { return (IList)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		public object SelectedItem
		{
			get { return GetValue(SelectedItemProperty); }
			set { SetValue(SelectedItemProperty, value); }
		}

		public ICommand ItemSelectedCommand
		{
			get
			{ 
				return (ICommand)base.GetValue(ItemSelectedCommandProperty);
			}
			set
			{ 
				base.SetValue(ItemSelectedCommandProperty, value);
			}
		}

		public CustomPicker ()
		{
			SelectedIndexChanged += OnSelectedIndexChanged;
		}

		private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
		{
			var picker = bindable as CustomPicker;
			picker.Items.Clear();
			if (newvalue != null)
			{
				foreach (var item in newvalue)
				{
					picker.Items.Add(item.ToString());
				}
			}
		}

		private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var picker = bindable as CustomPicker;

			if (newValue != null)
			{
				picker.SelectedIndex = picker.Items.IndexOf(newValue.ToString());
			}
		}

		private void OnSelectedIndexChanged(object sender, EventArgs ev)
		{
			if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
			{
				SelectedItem = null;
			}
			else
			{
				SelectedItem = ItemsSource[SelectedIndex];
				ICommand command = ItemSelectedCommand;
				if (command != null) 
				{
					command.Execute (SelectedItem);
				}
			}
		}
	}
}

