﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.Controls.VisualMarker;

namespace ZuydApp_V1.API
{
    public class ComboBox : StackLayout
    {
        private Entry _entry;
        private ListView _listView;
        private bool _supressFiltering;
        private bool _supressSelectedItemFiltering;
        //Bindable properties
        public static readonly BindableProperty ListViewHeightRequestProperty = BindableProperty.Create(nameof(ListViewHeightRequest), typeof(double), typeof(ComboBox), defaultValue: null, propertyChanged: (bindable, oldVal, newVal) => {
            var comboBox = (ComboBox)bindable;
            comboBox._listView.HeightRequest = (double)newVal;
        });
        public double ListViewHeightRequest
        {
            get { return (double)GetValue(ListViewHeightRequestProperty); }
            set { SetValue(ListViewHeightRequestProperty, value); }
        }
        public static readonly BindableProperty EntryBackgroundColorProperty = BindableProperty.Create(nameof(EntryBackgroundColor), typeof(Color), typeof(ComboBox), defaultValue: null, propertyChanged: (bindable, oldVal, newVal) => {
            var comboBox = (ComboBox)bindable;
            comboBox._entry.BackgroundColor = (Color)newVal;
        });
        public Color EntryBackgroundColor
        {
            get { return (Color)GetValue(EntryBackgroundColorProperty); }
            set { SetValue(EntryBackgroundColorProperty, value); }
        }
        public static readonly BindableProperty EntryFontSizeProperty = BindableProperty.Create(nameof(EntryFontSize), typeof(double), typeof(ComboBox), defaultValue: null, propertyChanged: (bindable, oldVal, newVal) => {
            var comboBox = (ComboBox)bindable;
            comboBox._entry.FontSize = (double)newVal;
        });
        [TypeConverter(typeof(FontSizeConverter))]
        public double EntryFontSize
        {
            get { return (double)GetValue(EntryFontSizeProperty); }
            set { SetValue(EntryFontSizeProperty, value); }
        }

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(ComboBox), defaultValue: null, propertyChanged: (bindable, oldVal, newVal) => {
            var comboBox = (ComboBox)bindable;
            comboBox._listView.ItemsSource = (IEnumerable)newVal;
        });
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(ComboBox), defaultValue: null, propertyChanged: (bindable, oldVal, newVal) => {
            var comboBox = (ComboBox)bindable;
            comboBox._listView.SelectedItem = newVal;
        });
        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        public static new readonly BindableProperty VisualProperty = BindableProperty.Create(nameof(Visual), typeof(IVisual), typeof(ComboBox), defaultValue: new DefaultVisual(), propertyChanged: (bindable, oldVal, newVal) => {
            var comboBox = (ComboBox)bindable;
            comboBox._listView.Visual = (IVisual)newVal;
            comboBox._entry.Visual = (IVisual)newVal;
        });
        public new IVisual Visual
        {
            get { return (IVisual)GetValue(VisualProperty); }
            set { SetValue(VisualProperty, value); }
        }
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(ComboBox), defaultValue: "", propertyChanged: (bindable, oldVal, newVal) => {
            var comboBox = (ComboBox)bindable;
            comboBox._entry.Placeholder = (string)newVal;
        });
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(ComboBox), defaultValue: "", propertyChanged: (bindable, oldVal, newVal) => {
            var comboBox = (ComboBox)bindable;
            comboBox._entry.Text = (string)newVal;
        });
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(ComboBox), defaultValue: null, propertyChanged: (bindable, oldVal, newVal) => {
            var comboBox = (ComboBox)bindable;
            comboBox._listView.ItemTemplate = (DataTemplate)newVal;
        });
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }
        public static readonly BindableProperty EntryDisplayPathProperty = BindableProperty.Create(nameof(EntryDisplayPath), typeof(string), typeof(ComboBox), defaultValue: "");
        public string EntryDisplayPath
        {
            get { return (string)GetValue(EntryDisplayPathProperty); }
            set { SetValue(EntryDisplayPathProperty, value); }
        }
        public event EventHandler<SelectedItemChangedEventArgs> SelectedItemChanged;
        protected virtual void OnSelectedItemChanged(SelectedItemChangedEventArgs e)
        {
            EventHandler<SelectedItemChangedEventArgs> handler = SelectedItemChanged;
            handler?.Invoke(this, e);
        }
        public event EventHandler<TextChangedEventArgs> TextChanged;
        protected virtual void OnTextChanged(TextChangedEventArgs e)
        {
            EventHandler<TextChangedEventArgs> handler = TextChanged;
            handler?.Invoke(this, e);
        }
        public ComboBox()
        {
            //Entry used for filtering list view
            _entry = new Entry();
            _entry.Margin = new Thickness(0);
            _entry.Keyboard = Keyboard.Create(KeyboardFlags.None);
            _entry.Focused += (sender, args) => _listView.IsVisible = true;
            _entry.Unfocused += (sender, args) => _listView.IsVisible = false;
            //Text changed event, bring it back to the surface
            _entry.TextChanged += (sender, args) =>
            {
                if (_supressFiltering)
                    return;
                if (String.IsNullOrEmpty(args.NewTextValue))
                {
                    _supressSelectedItemFiltering = true;
                    _listView.SelectedItem = null;
                    _supressSelectedItemFiltering = false;
                }
                _listView.IsVisible = true;
                OnTextChanged(args);
            };
            //List view - used to display search options
            _listView = new ListView();
            _listView.IsVisible = false;
            _listView.Margin = new Thickness(0);
            Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific.ListView.SetSeparatorStyle(_listView, Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific.SeparatorStyle.FullWidth);
            _listView.HeightRequest = 100;
            _listView.HorizontalOptions = LayoutOptions.StartAndExpand;
            _listView.SetBinding(ListView.SelectedItemProperty, new Binding(nameof(ComboBox.SelectedItem), source: this));
            //Item selected event, surface it back to the top
            _listView.ItemSelected += (sender, args) =>
            {
                if (!_supressSelectedItemFiltering)
                {
                    _supressFiltering = true;
                    var selectedItem = args.SelectedItem;
                    _entry.Text = !String.IsNullOrEmpty(EntryDisplayPath) && selectedItem != null ? selectedItem.GetType().GetProperty(EntryDisplayPath).GetValue(selectedItem, null).ToString() : selectedItem?.ToString();
                    _supressFiltering = false;
                    _listView.IsVisible = false;
                    OnSelectedItemChanged(args);
                    _entry.Unfocus();
                }
            };
            //Add bottom border
            var boxView = new BoxView();
            boxView.HeightRequest = 1;
            boxView.
}
