using AwesomeNotes.EventArguments;
using CommunityToolkit.Maui.Core.Extensions;
using Microsoft.Maui.Controls.Compatibility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Android.Content.ClipData;

namespace AwesomeNotes.Controls
{
    public class CustomDraggableCollectionView : CollectionView
    {
        public static readonly BindableProperty ScrollToItemProperty =
           BindableProperty.Create(nameof(ScrollToItem), typeof(object), typeof(CustomDraggableCollectionView), null);


        public object ScrollToItem
        {
            get => GetValue(ScrollToItemProperty);
            set => SetValue(ScrollToItemProperty, value);
        }

        public CustomDraggableCollectionView()
        {

        }

        
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(ScrollToItem))
            {
                if (ScrollToItem != null && DeviceInfo.Platform == DevicePlatform.Android)
                {
                    try
                    {
                        ScrollTo(ScrollToItem, -1, ScrollToPosition.Center, true);
                    }
                    catch
                    {
                        Debug.WriteLine("Invalid Target Position !!!!!!");
                    }

                }

            }

        }
    }
}
