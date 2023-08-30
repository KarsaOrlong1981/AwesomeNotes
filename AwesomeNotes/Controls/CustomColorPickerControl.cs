using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ColorPicker.Maui;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace AwesomeNotes.Controls
{
    public class CustomColorPickerControl : ContentView 
    {
        public static readonly BindableProperty PickedBackColorChangedCommandProperty =
       BindableProperty.Create(nameof(PickedBackColorChangedCommand), typeof(ICommand), typeof(CustomColorPickerControl));

        public static readonly BindableProperty PickedTextColorChangedCommandProperty =
            BindableProperty.Create(nameof(PickedBackColorChangedCommand), typeof(ICommand), typeof(CustomColorPickerControl));

        public static readonly BindableProperty CommandProperty =
          BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(CustomColorPickerControl));

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(CustomColorPickerControl));

        public static readonly BindableProperty FontFamilyBackColorProperty =
            BindableProperty.Create(nameof(FontFamilyBackColor), typeof(string), typeof(CustomColorPickerControl), "IWantMy");

        public static readonly BindableProperty FontFamilyTextColorProperty =
           BindableProperty.Create(nameof(FontFamilyTextColor), typeof(string), typeof(CustomColorPickerControl), "IWantMy");

        public static readonly BindableProperty BackGroundColorProperty =
          BindableProperty.Create(nameof(BackGroundColor), typeof(Color), typeof(CustomColorPickerControl), Colors.White);

        public static readonly BindableProperty TextColorProperty =
         BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(CustomColorPickerControl), Colors.Blue);

        public static readonly BindableProperty PickedBackColorProperty =
        BindableProperty.Create(nameof(PickedBackColor), typeof(Color), typeof(CustomColorPickerControl), Colors.White, BindingMode.TwoWay);

        public static readonly BindableProperty PickedTextColorProperty =
       BindableProperty.Create(nameof(PickedTextColor), typeof(Color), typeof(CustomColorPickerControl), Colors.Blue, BindingMode.TwoWay);

        public static readonly BindableProperty FontSizeProperty =
          BindableProperty.Create(nameof(FontSize), typeof(double), typeof(CustomColorPickerControl), 16.0);

        public ICommand PickedBackColorChangedCommand
        {
            get { return (ICommand)GetValue(PickedBackColorChangedCommandProperty); }
            set { SetValue(PickedBackColorChangedCommandProperty, value); }
        }

        public ICommand PickedTextColorChangedCommand
        {
            get { return (ICommand)GetValue(PickedTextColorChangedCommandProperty); }
            set { SetValue(PickedTextColorChangedCommandProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public string FontFamilyBackColor
        {
            get { return (string)GetValue(FontFamilyBackColorProperty); }
            set { SetValue(FontFamilyBackColorProperty , value); }
        }

        public string FontFamilyTextColor
        {
            get { return (string)GetValue(FontFamilyTextColorProperty); }
            set { SetValue(FontFamilyTextColorProperty, value); }
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

        public Color PickedBackColor
        {
            get { return (Color)GetValue(PickedBackColorProperty); }
            set { SetValue(PickedBackColorProperty, value); }
        }

        public Color PickedTextColor
        {
            get { return (Color)GetValue(PickedTextColorProperty); }
            set { SetValue(PickedTextColorProperty, value); }
        }
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        ICommand buttonCommand;
        private VerticalStackLayout verticalStack;
        private Label backLabel;
        private Label textLabel;
        private ColorPicker.Maui.ColorPicker colorPickerBack;
        private ColorPicker.Maui.ColorPicker colorPickerText;
        private Button acceptButton;

        public CustomColorPickerControl()
        {
            InitControl();
        }

        private void InitControl()
        {
            //Container
            var vertStack = new VerticalStackLayout
            {
                Spacing = 20,
            };
            this.verticalStack = vertStack;
            //Label Background picker
            var labBack = new Label 
            {
                Text = "Hintergrundfarbe:"
            };
           
            this.backLabel = labBack;
            //Color picker Background
            var cpBack = new ColorPicker.Maui.ColorPicker 
            { 
                HeightRequest = 200,
                PickedColor = PickedBackColor,
                ColorFlowDirection = ColorFlowDirection.Horizontal,
                ColorSpectrumStyle = ColorSpectrumStyle.ShadeToHueStyle,
                PointerRingDiameterUnits = 0.7,
                PointerRingBorderUnits = 0.3
            };
            cpBack.BaseColorList = new List<string>
            {
                "#f8f8ff",
                "#7fff00",
                "#ff00ff",
                "#0000ff",
                "#ffff00"
            };
            this.colorPickerBack = cpBack;

            //Label Text picker
            var labText = new Label 
            {
                Text = "Textfarbe:"
            };

            this.textLabel = labText;
            //Color picker Background
            var cpText = new ColorPicker.Maui.ColorPicker
            {
                HeightRequest = 200,
                PickedColor = PickedTextColor,
                ColorFlowDirection = ColorFlowDirection.Horizontal,
                ColorSpectrumStyle = ColorSpectrumStyle.ShadeToHueStyle,
                PointerRingDiameterUnits = 0.7,
                PointerRingBorderUnits = 0.3
            };
            cpText.BaseColorList = new List<string>
            {
                "#f8f8ff",
                "#7fff00",
                "#ff00ff",
                "#0000ff",
                "#ffff00"
            };
            this.colorPickerText = cpText;

            var button = new Button
            {
                Text = "Farben akzeptieren"
            };
            this.acceptButton = button;

            verticalStack.Children.Add(labBack);
            verticalStack.Children.Add(cpBack);
            verticalStack.Children.Add(labText);
            verticalStack.Children.Add(cpText);
            verticalStack.Children.Add(button);

            Content = verticalStack;

        }

        protected override void OnParentSet()
        {
            base.OnParentSet();

            // Label Backgroundcolor
            backLabel.FontFamily = FontFamilyBackColor;
            backLabel.BackgroundColor = BackgroundColor;
            backLabel.TextColor = TextColor;
            backLabel.FontSize = FontSize;

            // Background color Picker
            colorPickerBack.PickedColor = PickedBackColor;
            colorPickerBack.PickedColorChanged += ColorPickerBack_PickedColorChanged;
          
            // Label Textcolor
            textLabel.FontFamily = FontFamilyTextColor;
            textLabel.BackgroundColor = BackgroundColor;
            textLabel.TextColor = TextColor;
            textLabel.FontSize = FontSize;

            // Text color picker
            colorPickerText.PickedColor = PickedTextColor;
            colorPickerText.PickedColorChanged += ColorPickerText_PickedColorChanged;

            // Button
            acceptButton.Command = ButtonCommand;
           
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == null) return;

            if (propertyName == nameof(PickedTextColor))
            {
                textLabel.TextColor = PickedTextColor;
                backLabel.TextColor = PickedTextColor;
            }
            if (propertyName == nameof(PickedBackColor)) 
            {
                textLabel.BackgroundColor = PickedBackColor;
                backLabel.BackgroundColor = PickedBackColor;
            }
        }

        private void ColorPickerText_PickedColorChanged(object sender, PickedColorChangedEventArgs e)
        {
            colorPickerText.PickedColorChanged -= ColorPickerText_PickedColorChanged;
            PickedTextColor = e.NewPickedColorValue;
            if (PickedTextColorChangedCommand != null && PickedTextColorChangedCommand.CanExecute(e))
            {
                PickedTextColorChangedCommand.Execute(e);
            }
            colorPickerText.PickedColorChanged += ColorPickerText_PickedColorChanged;
        }

        private void ColorPickerBack_PickedColorChanged(object sender, PickedColorChangedEventArgs e)
        {
            colorPickerBack.PickedColorChanged -= ColorPickerBack_PickedColorChanged;
            PickedBackColor = e.NewPickedColorValue;
            if (PickedBackColorChangedCommand != null && PickedBackColorChangedCommand.CanExecute(e))
            {
                PickedBackColorChangedCommand.Execute(e);
            }
            colorPickerBack.PickedColorChanged += ColorPickerBack_PickedColorChanged;
        }

        public ICommand ButtonCommand =>
           buttonCommand
           ?? (buttonCommand = new RelayCommand(() => ButtonAction()));

        private void ButtonAction() 
        {
            if (!IsEnabled)
                return;

            Application.Current.Dispatcher.Dispatch(async () =>
            {
                await verticalStack.ScaleTo(0.8, 70, Easing.Linear);
                
                if (Command != null)
                {
                    Command.Execute(CommandParameter);
                   
                }
                await Task.Delay(40);
                await verticalStack.ScaleTo(1, 70, Easing.Linear);

            });
        }
    }
}
