using AwesomeNotes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AwesomeNotes.Controls
{
    public class DraggableCollectionView : Sharpnado.CollectionView.CollectionView
    {
        

        public static readonly BindableProperty ScrollToItemProperty =
           BindableProperty.Create(nameof(ScrollToItem), typeof(object), typeof(DraggableCollectionView), null);
      
        public object ScrollToItem
        {
            get => GetValue(ScrollToItemProperty);
            set => SetValue(ScrollToItemProperty, value);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(ScrollToItem))
            {
                if (ItemsSource != null)
                {
                    int index = 0;
                    foreach (var item in ItemsSource)
                    {
                        if (item is Categorie)
                        {
                            if (object.Equals((item as Categorie).Name, (ScrollToItem as Categorie).Name))
                            {
                                ScrollTo(index, false);
                                break;
                            }
                            index++;
                        }      
                        if (item is Note)
                        {
                            if (object.Equals((item as Note).Id, (ScrollToItem as Note).Id))
                            {
                                ScrollTo(index, false);
                                break;
                            }
                            index++;
                        }
                    }
                }
            }
            
        }
      
    }
}
