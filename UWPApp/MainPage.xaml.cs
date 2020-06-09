using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Bluetooth.Rfcomm;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public class Category : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string name { get; set; }
        public string Name {
            get {
                return name;
            }
            set {
                name = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Receipe : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string name { get; set; }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MyDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Normal { get; set; }
        public DataTemplate Accent { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            if (item is Category)
            {
                return Normal;
            }
            else
            {
                return Accent;
            }
        }
    }



    public class CardStyleTemplateSelector : StyleSelector
    {

        public Style CategoryStyle { get; set; }
        public Style ReceipeStyle { get; set; }

        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            switch (item)
            {
                case Category category:
                    return CategoryStyle;
                case Receipe receipe:
                    return ReceipeStyle;
            }
            return null;
        }
    }


    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();


            Source = new ObservableCollection<object>();
            Source.Add(new Category() { Name = "Category1" });
            Source.Add(new Receipe() { Name = "Receipe1" });
            Source.Add(new Category() { Name = "Category2" });
            Source.Add(new Receipe() { Name = "Receipe2" });
            Source.Add(new Category() { Name = "Category3" });
            Source.Add(new Receipe() { Name = "Receipe3" });
        }

        private ObservableCollection<object> Source { get; set; }
    }
}
