using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AwesomeNotes.Controls
{
    public class NumericUpDownControl : ContentView
    {
        public static readonly BindableProperty CurrentValueChangedCommandProperty =
         BindableProperty.Create(nameof(CurrentValueChangedCommand), typeof(ICommand), typeof(NumericUpDownControl));

        public static readonly BindableProperty AcceptChangesCommandProperty =      
        BindableProperty.Create(nameof(AcceptChangesCommand), typeof(ICommand), typeof(NumericUpDownControl));

        public static readonly BindableProperty CurrentValueProperty =
           BindableProperty.Create(nameof(CurrentValue), typeof(double), typeof(NumericUpDownControl), 20.0, BindingMode.TwoWay);

        public static readonly BindableProperty AcceptButtonImageSourceProperty =       
         BindableProperty.Create(nameof(AcceptButtonImageSource), typeof(ImageSource), typeof(NumericUpDownControl));

        public static readonly BindableProperty UpButtonImageSourceProperty =
          BindableProperty.Create(nameof(UpButtonImageSource), typeof(ImageSource), typeof(NumericUpDownControl));

        public static readonly BindableProperty DownButtonImageSourceProperty =
          BindableProperty.Create(nameof(DownButtonImageSource), typeof(ImageSource), typeof(NumericUpDownControl));

        public static readonly BindableProperty BackGroundColorProperty =
         BindableProperty.Create(nameof(BackGroundColor), typeof(Color), typeof(NumericUpDownControl), Colors.White);

        public static readonly BindableProperty TextColorProperty =
         BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(NumericUpDownControl), Colors.Blue);

        public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(NumericUpDownControl), Colors.Blue);

        public static readonly BindableProperty FontSizeProperty =
         BindableProperty.Create(nameof(FontSize), typeof(double), typeof(NumericUpDownControl), 20.0);

        public static readonly BindableProperty ImageHeightProperty =
         BindableProperty.Create(nameof(ImageHeight), typeof(double), typeof(NumericUpDownControl), 30.0);

        public static readonly BindableProperty ImageWidthProperty =
        BindableProperty.Create(nameof(ImageWidth), typeof(double), typeof(NumericUpDownControl), 30.0);

        public static readonly BindableProperty MaxValueProperty =
        BindableProperty.Create(nameof(ImageWidth), typeof(double), typeof(NumericUpDownControl), 65.0);

        public static readonly BindableProperty MinValueProperty =
        BindableProperty.Create(nameof(ImageWidth), typeof(double), typeof(NumericUpDownControl), 9.0);

        public static readonly BindableProperty FontFamilyProperty =
           BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(NumericUpDownControl), "Aqira");


        public NumericUpDownControl()
        {
            InitControl();
        }

        public ICommand CurrentValueChangedCommand  
        {
            get { return (ICommand)GetValue(CurrentValueChangedCommandProperty); }
            set { SetValue(CurrentValueChangedCommandProperty, value); }
        }

        public ICommand AcceptChangesCommand
        {
            get { return (ICommand)GetValue(AcceptChangesCommandProperty); }
            set { SetValue(AcceptChangesCommandProperty, value); }
        }

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public double CurrentValue
        {
            get => (double)GetValue(CurrentValueProperty);
            set => SetValue(CurrentValueProperty, value);
        }

        public double MaxValue
        {
            get => (double)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        public double MinValue
        {
            get => (double)GetValue(MinValueProperty);
            set => SetValue(CurrentValueProperty, value);
        }

        public ImageSource AcceptButtonImageSource
        {
            get => (ImageSource)GetValue(AcceptButtonImageSourceProperty);
            set => SetValue(AcceptButtonImageSourceProperty, value);
        }

        public ImageSource UpButtonImageSource
        {
            get => (ImageSource)GetValue(UpButtonImageSourceProperty);
            set => SetValue(UpButtonImageSourceProperty, value);
        }

        public ImageSource DownButtonImageSource
        {
            get => (ImageSource)GetValue(DownButtonImageSourceProperty);
            set => SetValue(DownButtonImageSourceProperty, value);
        }

        public Color BackGroundColor
        {
            get { return (Color)GetValue(BackGroundColorProperty); }
            set { SetValue(BackGroundColorProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public double ImageHeight
        {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        public double ImageWidth
        {
            get { return (double)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        private double commandParameter;

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == null) return; 

            if (propertyName == "CurrentValue")
            {
                this.labelValue.Text = CurrentValue.ToString();
                this.commandParameter = CurrentValue;
                if (ValueChangedCommand != null)
                ValueChangedCommand.Execute(commandParameter);
            }
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            this.border.Stroke = BorderColor;
            this.border.BackgroundColor = BackGroundColor;
            this.border.HeightRequest = HeightRequest;
            this.border.WidthRequest = WidthRequest;
            this.border.HorizontalOptions = HorizontalOptions;
            this.border.VerticalOptions = VerticalOptions;

            this.horStack.BackgroundColor = BackgroundColor;

            this.labelValue.FontSize = FontSize;
            this.labelValue.Text = CurrentValue.ToString();
            this.labelValue.BackgroundColor = BackgroundColor;
            this.labelValue.TextColor = TextColor;
            this.labelValue.FontFamily = FontFamily;

            this.upImage.Source = UpButtonImageSource;
            this.upImage.HeightRequest = ImageHeight;
            this.upImage.WidthRequest = ImageWidth;

            this.downImage.Source = DownButtonImageSource;
            this.downImage.HeightRequest = ImageHeight;
            this.downImage.WidthRequest = ImageWidth;

            this.acceptImage.Source = AcceptButtonImageSource;
            this.acceptImage.HeightRequest = ImageHeight;
            this.acceptImage.WidthRequest = ImageWidth;

        }

        private Border border;
        private HorizontalStackLayout horStack;
        private Label labelValue;
        private ImageButton upImage;
        private ImageButton downImage;
        private ImageButton acceptImage;    
        private ICommand upButtonCommand;
        private ICommand downButtonCommand;
        private ICommand valueChangedCommand;
        private ICommand acceptImageCommand;

        private void InitControl()
        {
            var border = new Border
            {
                StrokeThickness = 3,
                StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(20, 20, 20, 20) }
            };
            this.border = border;

            var horStack = new HorizontalStackLayout
            {
                Spacing = 20,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            this.horStack = horStack;

            var labelValue = new Label  
            { 
                Text = CurrentValue.ToString(),
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center

            };
            this.labelValue = labelValue;

            var upImage = new ImageButton
            {
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Command = UpButtonCommand
            };
            this.upImage = upImage;

            var downImage = new ImageButton
            {
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Command = DownButtonCommand 
            };
            this.downImage = downImage;

            var acceptImage = new ImageButton
            {
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Command = AcceptImageCommand
            };
            this.acceptImage = acceptImage; 

            horStack.Children.Add(labelValue);
            horStack.Children.Add(upImage);
            horStack.Children.Add(downImage);
            horStack.Children.Add(acceptImage);
            border.Content = horStack;
            Content = border;
        }

        public ICommand UpButtonCommand =>
          upButtonCommand
          ?? (upButtonCommand = new RelayCommand(() => UpButtonAction()));
        private void UpButtonAction()   
        {
            Application.Current.Dispatcher.Dispatch(async () =>
            {
                await upImage.ScaleTo(0.8, 70, Easing.Linear);

                if (CurrentValue < MaxValue)
                    CurrentValue++;

                await Task.Delay(40);
                await upImage.ScaleTo(1, 70, Easing.Linear);

            });
           
        }

        public ICommand DownButtonCommand =>
          downButtonCommand
          ?? (downButtonCommand = new RelayCommand(() => DownButtonAction()));
        private void DownButtonAction() 
        {
            Application.Current.Dispatcher.Dispatch(async () =>
            {
                await downImage.ScaleTo(0.8, 70, Easing.Linear);

                if (CurrentValue > MinValue)
                    CurrentValue--;

                await Task.Delay(40);
                await downImage.ScaleTo(1, 70, Easing.Linear);

            });
           
        }

        public ICommand ValueChangedCommand =>
         valueChangedCommand
         ?? (valueChangedCommand = new RelayCommand(() => ValueChangedAction()));
        private void ValueChangedAction()   
        {
            if (!IsEnabled)
                return;

            Application.Current.Dispatcher.Dispatch(() =>
            {
                if (CurrentValueChangedCommand != null)
                     CurrentValueChangedCommand.Execute(commandParameter);
            });
        }

        public ICommand AcceptImageCommand =>
        acceptImageCommand
        ?? (acceptImageCommand = new RelayCommand(() => AcceptImageAction()));

        private void AcceptImageAction()
        {
            if (!IsEnabled)
                return;

            Application.Current.Dispatcher.Dispatch(async () =>
            {
                await border.ScaleTo(0.8, 70, Easing.Linear);

                if (AcceptChangesCommand != null)
                {
                    AcceptChangesCommand.Execute(null);

                }
                await Task.Delay(40);
                await border.ScaleTo(1, 70, Easing.Linear);

            });
        }
    }
}
