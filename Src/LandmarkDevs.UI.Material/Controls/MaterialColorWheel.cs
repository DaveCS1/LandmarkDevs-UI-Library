﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using LandmarkDevs.UI.Material.Helpers;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;

namespace LandmarkDevs.UI.Material.Controls
{
    /// <summary>
    ///     A color picker designed after Google's customizer.
    ///     The first click sets the primary color and the second click sets the accent color.
    ///     The credit for the design of this control goes to Google and the original can be found
    ///     at https://getmdl.io/customize/index.html. I took their SVG file and created a XAML control
    ///     based on that file.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Control" />
    public class MaterialColorWheel : Control
    {
        #region Initialization and Template

        /// <summary>
        ///     Initializes static members of the <see cref="MaterialColorWheel" /> class.
        /// </summary>
        static MaterialColorWheel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MaterialColorWheel),
                new FrameworkPropertyMetadata(typeof(MaterialColorWheel)));
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MaterialColorWheel" /> class.
        /// </summary>
        public MaterialColorWheel()
        {
            Swatches = new SwatchesProvider().Swatches;
        }

        /// <summary>
        ///     When overridden in a derived class, is invoked whenever application code or internal processes call
        ///     <see cref="M:System.Windows.FrameworkElement.ApplyTemplate" />.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            SetTemplateChildren();
            CreateDictionaries();
            SetColorCanvases();
        }

        private void SetTemplateChildren()
        {
            _cyanCanvas = GetTemplateChild(PART_CyanCanvas) as Canvas;
            _tealCanvas = GetTemplateChild(PART_TealCanvas) as Canvas;
            _greenCanvas = GetTemplateChild(PART_GreenCanvas) as Canvas;
            _lightGreenCanvas = GetTemplateChild(PART_LightGreenCanvas) as Canvas;
            _limeCanvas = GetTemplateChild(PART_LimeCanvas) as Canvas;
            _yellowCanvas = GetTemplateChild(PART_YellowCanvas) as Canvas;
            _amberCanvas = GetTemplateChild(PART_AmberCanvas) as Canvas;
            _orangeCanvas = GetTemplateChild(PART_OrangeCanvas) as Canvas;
            _brownCanvas = GetTemplateChild(PART_BrownCanvas) as Canvas;
            _blueGreyCanvas = GetTemplateChild(PART_BlueGreyCanvas) as Canvas;
            _greyCanvas = GetTemplateChild(PART_GreyCanvas) as Canvas;
            _deepOrangeCanvas = GetTemplateChild(PART_DeepOrangeCanvas) as Canvas;
            _redCanvas = GetTemplateChild(PART_RedCanvas) as Canvas;
            _purpleCanvas = GetTemplateChild(PART_PurpleCanvas) as Canvas;
            _deepPurpleCanvas = GetTemplateChild(PART_DeepPurpleCanvas) as Canvas;
            _blueCanvas = GetTemplateChild(PART_BlueCanvas) as Canvas;
            _lightBlueCanvas = GetTemplateChild(PART_LightBlueCanvas) as Canvas;
            _indigoCanvas = GetTemplateChild(PART_IndigoCanvas) as Canvas;
            _pinkCanvas = GetTemplateChild(PART_PinkCanvas) as Canvas;
            _cyanSelector = GetTemplateChild(PART_CyanSelector) as Path;
            _tealSelector = GetTemplateChild(PART_TealSelector) as Path;
            _greenSelector = GetTemplateChild(PART_GreenSelector) as Path;
            _lightGreenSelector = GetTemplateChild(PART_LightGreenSelector) as Path;
            _limeSelector = GetTemplateChild(PART_LimeSelector) as Path;
            _yellowSelector = GetTemplateChild(PART_YellowSelector) as Path;
            _amberSelector = GetTemplateChild(PART_AmberSelector) as Path;
            _orangeSelector = GetTemplateChild(PART_OrangeSelector) as Path;
            _brownSelector = GetTemplateChild(PART_BrownSelector) as Path;
            _blueGreySelector = GetTemplateChild(PART_BlueGreySelector) as Path;
            _greySelector = GetTemplateChild(PART_GreySelector) as Path;
            _deepOrangeSelector = GetTemplateChild(PART_DeepOrangeSelector) as Path;
            _redSelector = GetTemplateChild(PART_RedSelector) as Path;
            _purpleSelector = GetTemplateChild(PART_PurpleSelector) as Path;
            _deepPurpleSelector = GetTemplateChild(PART_DeepPurpleSelector) as Path;
            _blueSelector = GetTemplateChild(PART_BlueSelector) as Path;
            _lightBlueSelector = GetTemplateChild(PART_LightBlueSelector) as Path;
            _indigoSelector = GetTemplateChild(PART_IndigoSelector) as Path;
            _pinkSelector = GetTemplateChild(PART_PinkSelector) as Path;
            _cyan1Canvas = GetTemplateChild(PART_Cyan1Canvas) as Canvas;
            _teal1Canvas = GetTemplateChild(PART_Teal1Canvas) as Canvas;
            _green1Canvas = GetTemplateChild(PART_Green1Canvas) as Canvas;
            _lightGreen1Canvas = GetTemplateChild(PART_LightGreen1Canvas) as Canvas;
            _lime1Canvas = GetTemplateChild(PART_Lime1Canvas) as Canvas;
            _yellow1Canvas = GetTemplateChild(PART_Yellow1Canvas) as Canvas;
            _amber1Canvas = GetTemplateChild(PART_Amber1Canvas) as Canvas;
            _orange1Canvas = GetTemplateChild(PART_Orange1Canvas) as Canvas;
            _brown1Canvas = GetTemplateChild(PART_Brown1Canvas) as Canvas;
            _blueGrey1Canvas = GetTemplateChild(PART_BlueGrey1Canvas) as Canvas;
            _grey1Canvas = GetTemplateChild(PART_Grey1Canvas) as Canvas;
            _deepOrange1Canvas = GetTemplateChild(PART_DeepOrange1Canvas) as Canvas;
            _red1Canvas = GetTemplateChild(PART_Red1Canvas) as Canvas;
            _purple1Canvas = GetTemplateChild(PART_Purple1Canvas) as Canvas;
            _deepPurple1Canvas = GetTemplateChild(PART_DeepPurple1Canvas) as Canvas;
            _blue1Canvas = GetTemplateChild(PART_Blue1Canvas) as Canvas;
            _lightBlue1Canvas = GetTemplateChild(PART_LightBlue1Canvas) as Canvas;
            _indigo1Canvas = GetTemplateChild(PART_Indigo1Canvas) as Canvas;
            _pink1Canvas = GetTemplateChild(PART_Pink1Canvas) as Canvas;
            _cyan2Canvas = GetTemplateChild(PART_Cyan2Canvas) as Canvas;
            _teal2Canvas = GetTemplateChild(PART_Teal2Canvas) as Canvas;
            _green2Canvas = GetTemplateChild(PART_Green2Canvas) as Canvas;
            _lightGreen2Canvas = GetTemplateChild(PART_LightGreen2Canvas) as Canvas;
            _lime2Canvas = GetTemplateChild(PART_Lime2Canvas) as Canvas;
            _yellow2Canvas = GetTemplateChild(PART_Yellow2Canvas) as Canvas;
            _amber2Canvas = GetTemplateChild(PART_Amber2Canvas) as Canvas;
            _orange2Canvas = GetTemplateChild(PART_Orange2Canvas) as Canvas;
            _brown2Canvas = GetTemplateChild(PART_Brown2Canvas) as Canvas;
            _blueGrey2Canvas = GetTemplateChild(PART_BlueGrey2Canvas) as Canvas;
            _grey2Canvas = GetTemplateChild(PART_Grey2Canvas) as Canvas;
            _deepOrange2Canvas = GetTemplateChild(PART_DeepOrange2Canvas) as Canvas;
            _red2Canvas = GetTemplateChild(PART_Red2Canvas) as Canvas;
            _purple2Canvas = GetTemplateChild(PART_Purple2Canvas) as Canvas;
            _deepPurple2Canvas = GetTemplateChild(PART_DeepPurple2Canvas) as Canvas;
            _blue2Canvas = GetTemplateChild(PART_Blue2Canvas) as Canvas;
            _lightBlue2Canvas = GetTemplateChild(PART_LightBlue2Canvas) as Canvas;
            _indigo2Canvas = GetTemplateChild(PART_Indigo2Canvas) as Canvas;
            _pink2Canvas = GetTemplateChild(PART_Pink2Canvas) as Canvas;
            _cyanPolys = GetTemplateChild(PART_CyanPolys) as Canvas;
            _tealPolys = GetTemplateChild(PART_TealPolys) as Canvas;
            _greenPolys = GetTemplateChild(PART_GreenPolys) as Canvas;
            _lightGreenPolys = GetTemplateChild(PART_LightGreenPolys) as Canvas;
            _limePolys = GetTemplateChild(PART_LimePolys) as Canvas;
            _yellowPolys = GetTemplateChild(PART_YellowPolys) as Canvas;
            _amberPolys = GetTemplateChild(PART_AmberPolys) as Canvas;
            _orangePolys = GetTemplateChild(PART_OrangePolys) as Canvas;
            _brownPolys = GetTemplateChild(PART_BrownPolys) as Canvas;
            _blueGreyPolys = GetTemplateChild(PART_BlueGreyPolys) as Canvas;
            _greyPolys = GetTemplateChild(PART_GreyPolys) as Canvas;
            _deepOrangePolys = GetTemplateChild(PART_DeepOrangePolys) as Canvas;
            _redPolys = GetTemplateChild(PART_RedPolys) as Canvas;
            _purplePolys = GetTemplateChild(PART_PurplePolys) as Canvas;
            _deepPurplePolys = GetTemplateChild(PART_DeepPurplePolys) as Canvas;
            _bluePolys = GetTemplateChild(PART_BluePolys) as Canvas;
            _lightBluePolys = GetTemplateChild(PART_LightBluePolys) as Canvas;
            _indigoPolys = GetTemplateChild(PART_IndigoPolys) as Canvas;
            _pinkPolys = GetTemplateChild(PART_PinkPolys) as Canvas;
            _darkLightButton = GetTemplateChild(PART_DarkLightButton) as Button;
            _foregroundColorButton = GetTemplateChild(PART_ForegroundColorButton) as Button;
        }

        /// <summary>
        ///     Creates the dictionaries of colors, selectors, and polygons.
        /// </summary>
        private void CreateDictionaries()
        {
            _colorCanvases = new Dictionary<string, Canvas>
            {
                {"Cyan", _cyanCanvas},
                {"Teal", _tealCanvas},
                {"Green", _greenCanvas},
                {"LightGreen", _lightGreenCanvas},
                {"Lime", _limeCanvas},
                {"Yellow", _yellowCanvas},
                {"Amber", _amberCanvas},
                {"Orange", _orangeCanvas},
                {"Brown", _brownCanvas},
                {"BlueGrey", _blueGreyCanvas},
                {"Grey", _greyCanvas},
                {"DeepOrange", _deepOrangeCanvas},
                {"Red", _redCanvas},
                {"Purple", _purpleCanvas},
                {"DeepPurple", _deepPurpleCanvas},
                {"Blue", _blueCanvas},
                {"LightBlue", _lightBlueCanvas},
                {"Indigo", _indigoCanvas},
                {"Pink", _pinkCanvas}
            };
            _selectors = new Dictionary<string, Path>
            {
                {"Cyan", _cyanSelector},
                {"Teal", _tealSelector},
                {"Green", _greenSelector},
                {"LightGreen", _lightGreenSelector},
                {"Lime", _limeSelector},
                {"Yellow", _yellowSelector},
                {"Amber", _amberSelector},
                {"Orange", _orangeSelector},
                {"Brown", _brownSelector},
                {"BlueGrey", _blueGreySelector},
                {"Grey", _greySelector},
                {"DeepOrange", _deepOrangeSelector},
                {"Red", _redSelector},
                {"Purple", _purpleSelector},
                {"DeepPurple", _deepPurpleSelector},
                {"Blue", _blueSelector},
                {"LightBlue", _lightBlueSelector},
                {"Indigo", _indigoSelector},
                {"Pink", _pinkSelector}
            };
            _polygons = new Dictionary<string, Canvas>
            {
                {"Cyan", _cyanPolys},
                {"Teal", _tealPolys},
                {"Green", _greenPolys},
                {"LightGreen", _lightGreenPolys},
                {"Lime", _limePolys},
                {"Yellow", _yellowPolys},
                {"Amber", _amberPolys},
                {"Orange", _orangePolys},
                {"Brown", _brownPolys},
                {"BlueGrey", _blueGreyPolys},
                {"Grey", _greyPolys},
                {"DeepOrange", _deepOrangePolys},
                {"Red", _redPolys},
                {"Purple", _purplePolys},
                {"DeepPurple", _deepPurplePolys},
                {"Blue", _bluePolys},
                {"LightBlue", _lightBluePolys},
                {"Indigo", _indigoPolys},
                {"Pink", _pinkPolys}
            };
        }

        /// <summary>
        ///     Sets the canvas click event.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <param name="restricted">if set to <c>true</c> the colors that can be selected are restricted.</param>
        private void SetCanvasClickEvent(Canvas canvas, bool restricted)
        {
            if (canvas == null)
                return;
            if (!restricted)
                canvas.PreviewMouseLeftButtonUp += UnrestrictedColorCanvas_PreviewMouseLeftButtonUp;
            else
                canvas.PreviewMouseLeftButtonUp += RestrictedColorCanvas_PreviewMouseLeftButtonUp;
        }

        /// <summary>
        ///     Sets the color canvases.
        /// </summary>
        private void SetColorCanvases()
        {
            SetCanvasClickEvent(_cyanCanvas, false);
            SetCanvasClickEvent(_tealCanvas, false);
            SetCanvasClickEvent(_greenCanvas, false);
            SetCanvasClickEvent(_lightGreenCanvas, false);
            SetCanvasClickEvent(_limeCanvas, false);
            SetCanvasClickEvent(_yellowCanvas, false);
            SetCanvasClickEvent(_amberCanvas, false);
            SetCanvasClickEvent(_orangeCanvas, false);
            SetCanvasClickEvent(_brownCanvas, true);
            SetCanvasClickEvent(_blueGreyCanvas, true);
            SetCanvasClickEvent(_greyCanvas, true);
            SetCanvasClickEvent(_deepOrangeCanvas, false);
            SetCanvasClickEvent(_redCanvas, false);
            SetCanvasClickEvent(_purpleCanvas, false);
            SetCanvasClickEvent(_deepPurpleCanvas, false);
            SetCanvasClickEvent(_blueCanvas, false);
            SetCanvasClickEvent(_lightBlueCanvas, false);
            SetCanvasClickEvent(_indigoCanvas, false);
            SetCanvasClickEvent(_pinkCanvas, false);
            if (_darkLightButton != null)
                _darkLightButton.Click += (s, e) =>
                {
                    var btn = (Button) s;
                    if (btn == null)
                        return;
                    ToggleDarkLight();
                    if (IsDark)
                    {
                        IsDark = false;
                        ForegroundIsDark = true;
                        new PaletteHelper().SetLightDark(false);
                        ReplaceEntry("CurrentForegroundColor", new SolidColorBrush(Color.FromArgb(221, 0, 0, 0)));
                        ReplaceEntry("CurrentBackgroundColor", new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)));
                        CenterButtonFontColor = new SolidColorBrush(Color.FromArgb(221, 0, 0, 0));
                        CenterButtonText = "Light";
                    }
                    else
                    {
                        IsDark = true;
                        ForegroundIsDark = false;
                        new PaletteHelper().SetLightDark(true);
                        ReplaceEntry("CurrentForegroundColor", new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)));
                        ReplaceEntry("CurrentBackgroundColor", new SolidColorBrush(Color.FromRgb(55, 71, 79)));
                        CenterButtonFontColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                        CenterButtonText = "Dark";
                    }
                };
            if (_foregroundColorButton != null)
                _foregroundColorButton.Click += (s, e) =>
                {
                    var btn = (Button) s;
                    if (btn == null)
                        return;
                    if (ForegroundIsDark)
                    {
                        ForegroundIsDark = false;
                        ReplaceEntry("CurrentForegroundColor", new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)));
                        ReplaceEntry("CurrentBackgroundColor", new SolidColorBrush(Color.FromRgb(55, 71, 79)));
                        ForegroundButtonBackgroundColor = new SolidColorBrush(Color.FromRgb(55, 71, 79));
                        ForegroundButtonForegroundColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    }
                    else
                    {
                        ForegroundIsDark = true;
                        ReplaceEntry("CurrentForegroundColor", new SolidColorBrush(Color.FromArgb(221, 0, 0, 0)));
                        ReplaceEntry("CurrentBackgroundColor", new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)));
                        ForegroundButtonForegroundColor = new SolidColorBrush(Color.FromRgb(55, 71, 79));
                        ForegroundButtonBackgroundColor = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    }
                };
        }

        #endregion Initialization and Template

        #region Event Methods

        /// <summary>
        ///     Fired when a canvas that is not grey, blue grey, or brown is clicked. This changes
        ///     the primary or accent color depending on which selection is being processed.
        /// </summary>
        /// <param name="sender">The canvas.</param>
        /// <param name="e">The event arguments</param>
        private void UnrestrictedColorCanvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var canvas = (Canvas) sender;
            if (canvas == null)
                throw new InvalidOperationException("Canvas can't be found.");
            var upperColorName = canvas.Name.Replace("PART_", "").Replace("Canvas", "");
            var colorName = upperColorName.ToLower(CultureInfo.InvariantCulture);
            var selectorName = $"PART_{upperColorName}Selector";
            var numberOneName = $"PART_{upperColorName}1Canvas";
            var numberTwoName = $"PART_{upperColorName}2Canvas";
            var colorArray = new[] {upperColorName, colorName, selectorName, numberOneName, numberTwoName};
            if (_isSecondColorSelected) SecondColorSelected();
            if (!_isFirstColorSelected)
                FirstColorNotSelected(canvas, colorArray);
            else
                FirstColorSelected(canvas, colorArray);
        }

        /// <summary>
        ///     Called when the second color has been selected. It clears the
        ///     previous selections and lets the user select new colors.
        /// </summary>
        private void SecondColorSelected()
        {
            ClearAllSelections();
            _isFirstColorSelected = false;
            _isSecondColorSelected = false;
        }

        /// <summary>
        ///     Called when the user makes a selection and the first color has not already
        ///     been selected.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <param name="colorArray">The color array.</param>
        private void FirstColorNotSelected(Canvas canvas, string[] colorArray)
        {
            PrimaryName = colorArray[0];
            DisableAllEffects();
            var selector = canvas.FindChild<Path>(colorArray[2]);
            if (selector != null)
                selector.Visibility = Visibility.Visible;
            var numberOneCanvas = canvas.FindChild<Canvas>(colorArray[3]);
            if (numberOneCanvas != null)
                numberOneCanvas.Visibility = Visibility.Visible;
            _isFirstColorSelected = true;
            new PaletteHelper().ReplacePrimaryColor(colorArray[1]);
            if (colorArray[0] == "Grey")
                _greySelected = true;
            if (colorArray[0] == "BlueGrey")
                _blueGreySelected = true;
            if (colorArray[0] == "Brown")
                _brownSelected = true;
            ApplyDropShadowEffect(colorArray[0]);
            DisableInvalidColorChoices(colorArray[0]);
        }

        /// <summary>
        ///     Called when the user makes a selection and the first color has already been selected.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <param name="colorArray">The color array.</param>
        private void FirstColorSelected(Canvas canvas, string[] colorArray)
        {
            AccentName = colorArray[0];
            var numberOneCanvas = canvas.FindChild<Canvas>(colorArray[3]);
            if (numberOneCanvas?.Visibility == Visibility.Visible)
                return;
            var selector = canvas.FindChild<Path>(colorArray[2]);
            if (selector != null)
                selector.Visibility = Visibility.Visible;
            var numberTwoCanvas = canvas.FindChild<Canvas>(colorArray[4]);
            if (numberTwoCanvas != null)
                numberTwoCanvas.Visibility = Visibility.Visible;
            _isSecondColorSelected = true;
            ApplyDropShadowEffect(colorArray[0]);
            new PaletteHelper().ReplaceAccentColor(colorArray[1]);
            EnableDisabledColorChoices();
        }

        /// <summary>
        ///     Fired when a canvas that is grey, blue grey, or brown is clicked. This changes
        ///     the primary color only because these colors are not allowed to be selected as
        ///     accent colors.
        /// </summary>
        /// <param name="sender">The canvas.</param>
        /// <param name="e">The event arguments</param>
        private void RestrictedColorCanvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var canvas = (Canvas) sender;
            if (canvas == null)
                throw new InvalidOperationException("Canvas can't be found.");
            var upperColorName = canvas.Name.Replace("PART_", "").Replace("Canvas", "");
            var colorName = upperColorName.ToLower(CultureInfo.InvariantCulture);
            var selectorName = $"PART_{upperColorName}Selector";
            var numberOneName = $"PART_{upperColorName}1Canvas";
            if (_isSecondColorSelected)
            {
                ClearAllSelections();
                _isFirstColorSelected = false;
                _isSecondColorSelected = false;
            }

            if (!_isFirstColorSelected)
            {
                PrimaryName = upperColorName;
                DisableAllEffects();
                var selector = canvas.FindChild<Path>(selectorName);
                if (selector != null)
                    selector.Visibility = Visibility.Visible;
                // Disabled this until I can figure out a way to fix the font size inside the viewbox.
                var numberOneCanvas = canvas.FindChild<Canvas>(numberOneName);
                if (numberOneCanvas != null)
                    numberOneCanvas.Visibility = Visibility.Visible;
                _isFirstColorSelected = true;
                new PaletteHelper().ReplacePrimaryColor(colorName);
                if (upperColorName == "Grey")
                    _greySelected = true;
                if (upperColorName == "BlueGrey")
                    _blueGreySelected = true;
                if (upperColorName == "Brown")
                    _brownSelected = true;
                ApplyDropShadowEffect(upperColorName);
                DisableInvalidColorChoices(upperColorName);
            }
        }

        #endregion Event Methods

        #region Helpers

        /// <summary>
        ///     Keeps grey, brown, and blue grey from being selected as an accent color.
        /// </summary>
        /// <param name="color">The color.</param>
        private void DisableInvalidColorChoices(string color)
        {
            DisableGrey();
            DisableBlueGrey();
            DisableBrown();
            DisableCurrentColor(color);
        }

        /// <summary>
        ///     Gets the canvas of the specified color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>Canvas.</returns>
        private Canvas GetColorCanvas(string color)
        {
            _colorCanvases.TryGetValue(color, out var canvas);
            return canvas;
        }

        /// <summary>
        ///     Disables the currently selected primary color.
        /// </summary>
        /// <param name="color">The color.</param>
        private void DisableCurrentColor(string color)
        {
            var canvas = GetColorCanvas(color);
            if (canvas != null)
                canvas.IsEnabled = false;
        }

        /// <summary>
        ///     Keeps grey from being selected as an accent color.
        /// </summary>
        private void DisableGrey()
        {
            if (_greySelected)
                return;
            _greyCanvas.IsEnabled = false;
            var greyOuter = _greyPolys.FindChild<Polygon>("GreyOuter");
            if (greyOuter != null)
                greyOuter.Fill = new SolidColorBrush(Color.FromRgb(239, 239, 239));
            var greyInner = _greyPolys.FindChild<Polygon>("GreyInner");
            if (greyInner != null)
                greyInner.Fill = new SolidColorBrush(Color.FromRgb(232, 232, 232));
        }

        /// <summary>
        ///     Keeps blue grey from being selected as an accent color.
        /// </summary>
        private void DisableBlueGrey()
        {
            if (_blueGreySelected)
                return;
            _blueGreyCanvas.IsEnabled = false;
            var greyOuter = _blueGreyPolys.FindChild<Polygon>("BlueGreyOuter");
            if (greyOuter != null)
                greyOuter.Fill = new SolidColorBrush(Color.FromRgb(232, 235, 237));
            var greyInner = _blueGreyPolys.FindChild<Polygon>("BlueGreyInner");
            if (greyInner != null)
                greyInner.Fill = new SolidColorBrush(Color.FromRgb(228, 231, 232));
        }

        /// <summary>
        ///     Keeps brown from being selected as an accent color.
        /// </summary>
        private void DisableBrown()
        {
            if (_brownSelected)
                return;
            _brownCanvas.IsEnabled = false;
            var brownOuter = _brownPolys.FindChild<Polygon>("BrownOuter");
            if (brownOuter != null)
                brownOuter.Fill = new SolidColorBrush(Color.FromRgb(235, 230, 229));
            var brownInner = _brownPolys.FindChild<Polygon>("BrownInner");
            if (brownInner != null)
                brownInner.Fill = new SolidColorBrush(Color.FromRgb(231, 228, 227));
        }

        /// <summary>
        ///     Enables blue grey, grey, and brown to be selected as a primary color.
        /// </summary>
        private void EnableDisabledColorChoices()
        {
            EnableGrey();
            EnableBlueGrey();
            EnableBrown();
            EnableAllColors();
        }

        /// <summary>
        ///     Enables all colors.
        /// </summary>
        private void EnableAllColors()
        {
            foreach (var o in _colorCanvases)
                o.Value.IsEnabled = true;
        }

        /// <summary>
        ///     Disables all effects.
        /// </summary>
        private void DisableAllEffects()
        {
            foreach (var o in _polygons)
                o.Value.Effect = null;
        }

        /// <summary>
        ///     Enables grey to be selected.
        /// </summary>
        private void EnableGrey()
        {
            _greyCanvas.IsEnabled = true;
            var greyOuter = _greyPolys.FindChild<Polygon>("GreyOuter");
            if (greyOuter != null)
                greyOuter.Fill = new SolidColorBrush(Color.FromRgb(158, 158, 158));
            var greyInner = _greyPolys.FindChild<Polygon>("GreyInner");
            if (greyInner != null)
                greyInner.Fill = new SolidColorBrush(Color.FromRgb(97, 97, 97));
        }

        /// <summary>
        ///     Enables blue grey to be selected.
        /// </summary>
        private void EnableBlueGrey()
        {
            _blueGreyCanvas.IsEnabled = true;
            var blueGreyOuter = _blueGreyPolys.FindChild<Polygon>("BlueGreyOuter");
            if (blueGreyOuter != null)
                blueGreyOuter.Fill = new SolidColorBrush(Color.FromRgb(96, 125, 139));
            var blueGreyInner = _blueGreyPolys.FindChild<Polygon>("BlueGreyInner");
            if (blueGreyInner != null)
                blueGreyInner.Fill = new SolidColorBrush(Color.FromRgb(69, 90, 100));
        }

        /// <summary>
        ///     Enables brown to be selected.
        /// </summary>
        private void EnableBrown()
        {
            _brownCanvas.IsEnabled = true;
            var brownOuter = _brownPolys.FindChild<Polygon>("BrownOuter");
            if (brownOuter != null)
                brownOuter.Fill = new SolidColorBrush(Color.FromRgb(121, 85, 72));
            var brownInner = _brownPolys.FindChild<Polygon>("BrownInner");
            if (brownInner != null)
                brownInner.Fill = new SolidColorBrush(Color.FromRgb(93, 64, 55));
        }

        /// <summary>
        ///     Sets the visibility to collapsed for all of the selectors and indicators.
        /// </summary>
        private void ClearAllSelections()
        {
            ClearTextIcons();
            ClearSelectionIcons();
            _greySelected = false;
            _blueGreySelected = false;
            _brownSelected = false;
        }

        /// <summary>
        ///     Sets the visibility of all the selector <see cref="Path" /> to collapsed.
        /// </summary>
        private void ClearSelectionIcons()
        {
            foreach (var o in _selectors)
                o.Value.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        ///     Sets the visibility of all of the <see cref="TextBlock" /> that specify
        ///     whether the selection is primary or accent to collapsed.
        /// </summary>
        private void ClearTextIcons()
        {
            _cyan1Canvas.Visibility = Visibility.Collapsed;
            _teal1Canvas.Visibility = Visibility.Collapsed;
            _green1Canvas.Visibility = Visibility.Collapsed;
            _lightGreen1Canvas.Visibility = Visibility.Collapsed;
            _lime1Canvas.Visibility = Visibility.Collapsed;
            _yellow1Canvas.Visibility = Visibility.Collapsed;
            _amber1Canvas.Visibility = Visibility.Collapsed;
            _orange1Canvas.Visibility = Visibility.Collapsed;
            _brown1Canvas.Visibility = Visibility.Collapsed;
            _blueGrey1Canvas.Visibility = Visibility.Collapsed;
            _grey1Canvas.Visibility = Visibility.Collapsed;
            _deepOrange1Canvas.Visibility = Visibility.Collapsed;
            _red1Canvas.Visibility = Visibility.Collapsed;
            _purple1Canvas.Visibility = Visibility.Collapsed;
            _deepPurple1Canvas.Visibility = Visibility.Collapsed;
            _blue1Canvas.Visibility = Visibility.Collapsed;
            _lightBlue1Canvas.Visibility = Visibility.Collapsed;
            _indigo1Canvas.Visibility = Visibility.Collapsed;
            _pink1Canvas.Visibility = Visibility.Collapsed;
            _cyan2Canvas.Visibility = Visibility.Collapsed;
            _teal2Canvas.Visibility = Visibility.Collapsed;
            _green2Canvas.Visibility = Visibility.Collapsed;
            _lightGreen2Canvas.Visibility = Visibility.Collapsed;
            _lime2Canvas.Visibility = Visibility.Collapsed;
            _yellow2Canvas.Visibility = Visibility.Collapsed;
            _amber2Canvas.Visibility = Visibility.Collapsed;
            _orange2Canvas.Visibility = Visibility.Collapsed;
            _brown2Canvas.Visibility = Visibility.Collapsed;
            _blueGrey2Canvas.Visibility = Visibility.Collapsed;
            _grey2Canvas.Visibility = Visibility.Collapsed;
            _deepOrange2Canvas.Visibility = Visibility.Collapsed;
            _red2Canvas.Visibility = Visibility.Collapsed;
            _purple2Canvas.Visibility = Visibility.Collapsed;
            _deepPurple2Canvas.Visibility = Visibility.Collapsed;
            _blue2Canvas.Visibility = Visibility.Collapsed;
            _lightBlue2Canvas.Visibility = Visibility.Collapsed;
            _indigo2Canvas.Visibility = Visibility.Collapsed;
            _pink2Canvas.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        ///     Returns the canvas that contains the polygons for the
        ///     selected color.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private Canvas GetPolygons(string color)
        {
            _polygons.TryGetValue(color, out var canvas);
            return canvas;
        }

        /// <summary>
        ///     Applies a drop shadow effect to the canvas that contains the polygons
        ///     for the selected color.
        /// </summary>
        /// <param name="color"></param>
        private void ApplyDropShadowEffect(string color)
        {
            var canvas = GetPolygons(color);
            canvas.Effect = new DropShadowEffect
            {
                BlurRadius = 14,
                Color = Color.FromArgb(153, 0, 0, 0),
                Direction = 270,
                Opacity = 0.42,
                RenderingBias = RenderingBias.Performance,
                ShadowDepth = 4.5
            };
        }

        /// <summary>
        ///     Toggles the theme between dark and light.
        /// </summary>
        public virtual void ToggleDarkLight()
        {
            ReplaceEntry("MaterialDesignUserControlBackground",
                IsDark
                    ? new SolidColorBrush(Color.FromRgb(224, 224, 224))
                    : new SolidColorBrush(Color.FromRgb(55, 71, 79)));
        }

        /// <summary>
        ///     Replaces a certain entry anywhere in the parent dictionary and its merged dictionaries.
        ///     This was taken from the Material Design In XAML Toolkit. James gets the credit for this.
        /// </summary>
        /// <param name="entryName">The entry to replace</param>
        /// <param name="newValue">The new entry value</param>
        /// <param name="parentDictionary">
        ///     The root dictionary to start searching at. Null means using
        ///     Application.Current.Resources
        /// </param>
        public static void ReplaceEntry(object entryName, object newValue, ResourceDictionary parentDictionary = null)
        {
            if (parentDictionary == null)
                parentDictionary = Application.Current.Resources;

            if (parentDictionary.Contains(entryName))
            {
                var brush = parentDictionary[entryName] as SolidColorBrush;
                if (brush != null && !brush.IsFrozen)
                {
                    var animation = new ColorAnimation
                    {
                        From = ((SolidColorBrush) parentDictionary[entryName]).Color,
                        To = ((SolidColorBrush) newValue).Color,
                        Duration = new Duration(TimeSpan.FromMilliseconds(300))
                    };
                    brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                }
                else
                {
                    parentDictionary[entryName] = newValue;
                }
            }

            foreach (var dictionary in parentDictionary.MergedDictionaries)
                ReplaceEntry(entryName, newValue, dictionary);
        }

        #endregion Helpers

        #region Dependency Properties

        /// <summary>
        ///     The selector color property
        /// </summary>
        public static readonly DependencyProperty SelectorColorProperty = DependencyProperty.Register(
            "SelectorColor", typeof(SolidColorBrush), typeof(MaterialColorWheel),
            new PropertyMetadata(new SolidColorBrush(Color.FromRgb(158, 158, 158))));

        /// <summary>
        ///     Gets or sets the color of the selector.
        /// </summary>
        /// <value>The color of the selector.</value>
        public SolidColorBrush SelectorColor
        {
            get => (SolidColorBrush) GetValue(SelectorColorProperty);
            set => SetValue(SelectorColorProperty, value);
        }

        /// <summary>
        ///     The selector foreground color property
        /// </summary>
        public static readonly DependencyProperty SelectorForegroundColorProperty = DependencyProperty.Register(
            "SelectorForegroundColor", typeof(SolidColorBrush), typeof(MaterialColorWheel),
            new PropertyMetadata(new SolidColorBrush(Color.FromRgb(255, 255, 255))));

        /// <summary>
        ///     Gets or sets the color of the selector foreground.
        /// </summary>
        /// <value>The color of the selector foreground.</value>
        public SolidColorBrush SelectorForegroundColor
        {
            get => (SolidColorBrush) GetValue(SelectorForegroundColorProperty);
            set => SetValue(SelectorForegroundColorProperty, value);
        }

        /// <summary>
        ///     The stretch property
        /// </summary>
        public static readonly DependencyProperty StretchProperty = DependencyProperty.Register(
            "Stretch", typeof(Stretch), typeof(MaterialColorWheel), new PropertyMetadata(default(Stretch)));

        /// <summary>
        ///     Gets or sets the stretch.
        /// </summary>
        /// <value>The stretch.</value>
        public Stretch Stretch
        {
            get => (Stretch) GetValue(StretchProperty);
            set => SetValue(StretchProperty, value);
        }

        /// <summary>
        ///     The center button text property
        /// </summary>
        public static readonly DependencyProperty CenterButtonTextProperty = DependencyProperty.Register(
            "CenterButtonText", typeof(string), typeof(MaterialColorWheel), new FrameworkPropertyMetadata("Light"));

        /// <summary>
        ///     Gets or sets the center button text.
        /// </summary>
        /// <value>The center button text.</value>
        public string CenterButtonText
        {
            get => (string) GetValue(CenterButtonTextProperty);
            set => SetValue(CenterButtonTextProperty, value);
        }

        /// <summary>
        ///     The foreground color button text property
        /// </summary>
        public static readonly DependencyProperty ForegroundColorButtonTextProperty = DependencyProperty.Register(
            "ForegroundColorButtonText", typeof(string), typeof(MaterialColorWheel),
            new FrameworkPropertyMetadata("Light"));

        /// <summary>
        ///     Gets or sets the foreground color button text.
        /// </summary>
        /// <value>The foreground color button text.</value>
        public string ForegroundColorButtonText
        {
            get => (string) GetValue(ForegroundColorButtonTextProperty);
            set => SetValue(ForegroundColorButtonTextProperty, value);
        }

        /// <summary>
        ///     The background color button text property
        /// </summary>
        public static readonly DependencyProperty BackgroundColorButtonTextProperty = DependencyProperty.Register(
            "BackgroundColorButtonText", typeof(string), typeof(MaterialColorWheel),
            new FrameworkPropertyMetadata("Light"));

        /// <summary>
        ///     Gets or sets the background color button text.
        /// </summary>
        /// <value>The background color button text.</value>
        public string BackgroundColorButtonText
        {
            get => (string) GetValue(BackgroundColorButtonTextProperty);
            set => SetValue(BackgroundColorButtonTextProperty, value);
        }

        /// <summary>
        ///     The button width property
        /// </summary>
        public static readonly DependencyProperty ButtonWidthProperty = DependencyProperty.Register(
            "ButtonWidth", typeof(double), typeof(MaterialColorWheel), new PropertyMetadata(default(double)));

        /// <summary>
        ///     Gets or sets the width of the button.
        /// </summary>
        /// <value>The width of the button.</value>
        public double ButtonWidth
        {
            get => (double) GetValue(ButtonWidthProperty);
            set => SetValue(ButtonWidthProperty, value);
        }

        /// <summary>
        ///     The button height property
        /// </summary>
        public static readonly DependencyProperty ButtonHeightProperty = DependencyProperty.Register(
            "ButtonHeight", typeof(double), typeof(MaterialColorWheel), new PropertyMetadata(default(double)));

        /// <summary>
        ///     Gets or sets the height of the button.
        /// </summary>
        /// <value>The height of the button.</value>
        public double ButtonHeight
        {
            get => (double) GetValue(ButtonHeightProperty);
            set => SetValue(ButtonHeightProperty, value);
        }

        /// <summary>
        ///     The center button font color property
        /// </summary>
        public static readonly DependencyProperty CenterButtonFontColorProperty = DependencyProperty.Register(
            "CenterButtonFontColor", typeof(SolidColorBrush), typeof(MaterialColorWheel),
            new PropertyMetadata(new SolidColorBrush(Color.FromArgb(221, 0, 0, 0))));

        /// <summary>
        ///     Gets or sets the color of the center button font.
        /// </summary>
        /// <value>The color of the center button font.</value>
        public SolidColorBrush CenterButtonFontColor
        {
            get => (SolidColorBrush) GetValue(CenterButtonFontColorProperty);
            set => SetValue(CenterButtonFontColorProperty, value);
        }

        /// <summary>
        ///     The foreground button background color property
        /// </summary>
        public static readonly DependencyProperty ForegroundButtonBackgroundColorProperty = DependencyProperty.Register(
            "ForegroundButtonBackgroundColor", typeof(SolidColorBrush), typeof(MaterialColorWheel),
            new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 0, 0, 0))));

        /// <summary>
        ///     Gets or sets the color of the foreground button background.
        /// </summary>
        /// <value>The color of the foreground button background.</value>
        public SolidColorBrush ForegroundButtonBackgroundColor
        {
            get => (SolidColorBrush) GetValue(ForegroundButtonBackgroundColorProperty);
            set => SetValue(ForegroundButtonBackgroundColorProperty, value);
        }

        /// <summary>
        ///     The foreground button foreground color property
        /// </summary>
        public static readonly DependencyProperty ForegroundButtonForegroundColorProperty = DependencyProperty.Register(
            "ForegroundButtonForegroundColor", typeof(SolidColorBrush), typeof(MaterialColorWheel),
            new PropertyMetadata(new SolidColorBrush(Color.FromArgb(255, 255, 255, 255))));

        /// <summary>
        ///     Gets or sets the color of the foreground button foreground.
        /// </summary>
        /// <value>The color of the foreground button foreground.</value>
        public SolidColorBrush ForegroundButtonForegroundColor
        {
            get => (SolidColorBrush) GetValue(ForegroundButtonForegroundColorProperty);
            set => SetValue(ForegroundButtonForegroundColorProperty, value);
        }

        #endregion Dependency Properties

        #region Template Properties

        // ReSharper disable InconsistentNaming
        private const string PART_DarkLightButton = "PART_DarkLightButton";
        private const string PART_ForegroundColorButton = "PART_ForegroundColorButton";
        private const string PART_CyanCanvas = "PART_CyanCanvas";
        private const string PART_TealCanvas = "PART_TealCanvas";
        private const string PART_GreenCanvas = "PART_GreenCanvas";
        private const string PART_LightGreenCanvas = "PART_LightGreenCanvas";
        private const string PART_LimeCanvas = "PART_LimeCanvas";
        private const string PART_YellowCanvas = "PART_YellowCanvas";
        private const string PART_AmberCanvas = "PART_AmberCanvas";
        private const string PART_OrangeCanvas = "PART_OrangeCanvas";
        private const string PART_BrownCanvas = "PART_BrownCanvas";
        private const string PART_BlueGreyCanvas = "PART_BlueGreyCanvas";
        private const string PART_GreyCanvas = "PART_GreyCanvas";
        private const string PART_DeepOrangeCanvas = "PART_DeepOrangeCanvas";
        private const string PART_RedCanvas = "PART_RedCanvas";
        private const string PART_PurpleCanvas = "PART_PurpleCanvas";
        private const string PART_DeepPurpleCanvas = "PART_DeepPurpleCanvas";
        private const string PART_BlueCanvas = "PART_BlueCanvas";
        private const string PART_LightBlueCanvas = "PART_LightBlueCanvas";
        private const string PART_IndigoCanvas = "PART_IndigoCanvas";
        private const string PART_PinkCanvas = "PART_PinkCanvas";
        // ReSharper restore InconsistentNaming
        private Button _foregroundColorButton;
        private Button _darkLightButton;
        private Canvas _cyanCanvas;
        private Canvas _tealCanvas;
        private Canvas _greenCanvas;
        private Canvas _lightGreenCanvas;
        private Canvas _limeCanvas;
        private Canvas _yellowCanvas;
        private Canvas _amberCanvas;
        private Canvas _orangeCanvas;
        private Canvas _brownCanvas;
        private Canvas _blueGreyCanvas;
        private Canvas _greyCanvas;
        private Canvas _deepOrangeCanvas;
        private Canvas _redCanvas;
        private Canvas _purpleCanvas;
        private Canvas _deepPurpleCanvas;
        private Canvas _blueCanvas;
        private Canvas _lightBlueCanvas;
        private Canvas _indigoCanvas;
        private Canvas _pinkCanvas;

        // ReSharper disable InconsistentNaming
        private const string PART_CyanSelector = "PART_CyanSelector";
        private const string PART_TealSelector = "PART_TealSelector";
        private const string PART_GreenSelector = "PART_GreenSelector";
        private const string PART_LightGreenSelector = "PART_LightGreenSelector";
        private const string PART_LimeSelector = "PART_LimeSelector";
        private const string PART_YellowSelector = "PART_YellowSelector";
        private const string PART_AmberSelector = "PART_AmberSelector";
        private const string PART_OrangeSelector = "PART_OrangeSelector";
        private const string PART_BrownSelector = "PART_BrownSelector";
        private const string PART_BlueGreySelector = "PART_BlueGreySelector";
        private const string PART_GreySelector = "PART_GreySelector";
        private const string PART_DeepOrangeSelector = "PART_DeepOrangeSelector";
        private const string PART_RedSelector = "PART_RedSelector";
        private const string PART_PurpleSelector = "PART_PurpleSelector";
        private const string PART_DeepPurpleSelector = "PART_DeepPurpleSelector";
        private const string PART_BlueSelector = "PART_BlueSelector";
        private const string PART_LightBlueSelector = "PART_LightBlueSelector";
        private const string PART_IndigoSelector = "PART_IndigoSelector";

        private const string PART_PinkSelector = "PART_PinkSelector";
        // ReSharper restore InconsistentNaming

        private Path _cyanSelector;
        private Path _tealSelector;
        private Path _greenSelector;
        private Path _lightGreenSelector;
        private Path _limeSelector;
        private Path _yellowSelector;
        private Path _amberSelector;
        private Path _orangeSelector;
        private Path _brownSelector;
        private Path _blueGreySelector;
        private Path _greySelector;
        private Path _deepOrangeSelector;
        private Path _redSelector;
        private Path _purpleSelector;
        private Path _deepPurpleSelector;
        private Path _blueSelector;
        private Path _lightBlueSelector;
        private Path _indigoSelector;
        private Path _pinkSelector;

        // ReSharper disable InconsistentNaming
        private const string PART_Cyan1Canvas = "PART_Cyan1Canvas";
        private const string PART_Teal1Canvas = "PART_Teal1Canvas";
        private const string PART_Green1Canvas = "PART_Green1Canvas";
        private const string PART_LightGreen1Canvas = "PART_LightGreen1Canvas";
        private const string PART_Lime1Canvas = "PART_Lime1Canvas";
        private const string PART_Yellow1Canvas = "PART_Yellow1Canvas";
        private const string PART_Amber1Canvas = "PART_Amber1Canvas";
        private const string PART_Orange1Canvas = "PART_Orange1Canvas";
        private const string PART_Brown1Canvas = "PART_Brown1Canvas";
        private const string PART_BlueGrey1Canvas = "PART_BlueGrey1Canvas";
        private const string PART_Grey1Canvas = "PART_Grey1Canvas";
        private const string PART_DeepOrange1Canvas = "PART_DeepOrange1Canvas";
        private const string PART_Red1Canvas = "PART_Red1Canvas";
        private const string PART_Purple1Canvas = "PART_Purple1Canvas";
        private const string PART_DeepPurple1Canvas = "PART_DeepPurple1Canvas";
        private const string PART_Blue1Canvas = "PART_Blue1Canvas";
        private const string PART_LightBlue1Canvas = "PART_LightBlue1Canvas";
        private const string PART_Indigo1Canvas = "PART_Indigo1Canvas";
        private const string PART_Pink1Canvas = "PART_Pink1Canvas";
        private const string PART_Cyan2Canvas = "PART_Cyan2Canvas";
        private const string PART_Teal2Canvas = "PART_Teal2Canvas";
        private const string PART_Green2Canvas = "PART_Green2Canvas";
        private const string PART_LightGreen2Canvas = "PART_LightGreen2Canvas";
        private const string PART_Lime2Canvas = "PART_Lime2Canvas";
        private const string PART_Yellow2Canvas = "PART_Yellow2Canvas";
        private const string PART_Amber2Canvas = "PART_Amber2Canvas";
        private const string PART_Orange2Canvas = "PART_Orange2Canvas";
        private const string PART_Brown2Canvas = "PART_Brown2Canvas";
        private const string PART_BlueGrey2Canvas = "PART_BlueGrey2Canvas";
        private const string PART_Grey2Canvas = "PART_Grey2Canvas";
        private const string PART_DeepOrange2Canvas = "PART_DeepOrange2Canvas";
        private const string PART_Red2Canvas = "PART_Red2Canvas";
        private const string PART_Purple2Canvas = "PART_Purple2Canvas";
        private const string PART_DeepPurple2Canvas = "PART_DeepPurple2Canvas";
        private const string PART_Blue2Canvas = "PART_Blue2Canvas";
        private const string PART_LightBlue2Canvas = "PART_LightBlue2Canvas";
        private const string PART_Indigo2Canvas = "PART_Indigo2Canvas";
        private const string PART_Pink2Canvas = "PART_Pink2Canvas";
        // ReSharper restore InconsistentNaming

        private Canvas _cyan1Canvas;
        private Canvas _teal1Canvas;
        private Canvas _green1Canvas;
        private Canvas _lightGreen1Canvas;
        private Canvas _lime1Canvas;
        private Canvas _yellow1Canvas;
        private Canvas _amber1Canvas;
        private Canvas _orange1Canvas;
        private Canvas _brown1Canvas;
        private Canvas _blueGrey1Canvas;
        private Canvas _grey1Canvas;
        private Canvas _deepOrange1Canvas;
        private Canvas _red1Canvas;
        private Canvas _purple1Canvas;
        private Canvas _deepPurple1Canvas;
        private Canvas _blue1Canvas;
        private Canvas _lightBlue1Canvas;
        private Canvas _indigo1Canvas;
        private Canvas _pink1Canvas;
        private Canvas _cyan2Canvas;
        private Canvas _teal2Canvas;
        private Canvas _green2Canvas;
        private Canvas _lightGreen2Canvas;
        private Canvas _lime2Canvas;
        private Canvas _yellow2Canvas;
        private Canvas _amber2Canvas;
        private Canvas _orange2Canvas;
        private Canvas _brown2Canvas;
        private Canvas _blueGrey2Canvas;
        private Canvas _grey2Canvas;
        private Canvas _deepOrange2Canvas;
        private Canvas _red2Canvas;
        private Canvas _purple2Canvas;
        private Canvas _deepPurple2Canvas;
        private Canvas _blue2Canvas;
        private Canvas _lightBlue2Canvas;
        private Canvas _indigo2Canvas;
        private Canvas _pink2Canvas;
        private bool _isFirstColorSelected;
        private bool _isSecondColorSelected;
        private bool _brownSelected;
        private bool _greySelected;
        private bool _blueGreySelected;
        public IEnumerable<Swatch> Swatches { get; }
        private Dictionary<string, Canvas> _colorCanvases;
        private Dictionary<string, Path> _selectors;
        private Dictionary<string, Canvas> _polygons;

        // ReSharper disable InconsistentNaming
        private const string PART_CyanPolys = "PART_CyanPolys";
        private const string PART_TealPolys = "PART_TealPolys";
        private const string PART_GreenPolys = "PART_GreenPolys";
        private const string PART_LightGreenPolys = "PART_LightGreenPolys";
        private const string PART_LimePolys = "PART_LimePolys";
        private const string PART_YellowPolys = "PART_YellowPolys";
        private const string PART_AmberPolys = "PART_AmberPolys";
        private const string PART_OrangePolys = "PART_OrangePolys";
        private const string PART_BrownPolys = "PART_BrownPolys";
        private const string PART_BlueGreyPolys = "PART_BlueGreyPolys";
        private const string PART_GreyPolys = "PART_GreyPolys";
        private const string PART_DeepOrangePolys = "PART_DeepOrangePolys";
        private const string PART_RedPolys = "PART_RedPolys";
        private const string PART_PurplePolys = "PART_PurplePolys";
        private const string PART_DeepPurplePolys = "PART_DeepPurplePolys";
        private const string PART_BluePolys = "PART_BluePolys";
        private const string PART_LightBluePolys = "PART_LightBluePolys";
        private const string PART_IndigoPolys = "PART_IndigoPolys";
        private const string PART_PinkPolys = "PART_PinkPolys";
        // ReSharper restore InconsistentNaming

        private Canvas _cyanPolys;
        private Canvas _tealPolys;
        private Canvas _greenPolys;
        private Canvas _lightGreenPolys;
        private Canvas _limePolys;
        private Canvas _yellowPolys;
        private Canvas _amberPolys;
        private Canvas _orangePolys;
        private Canvas _brownPolys;
        private Canvas _blueGreyPolys;
        private Canvas _greyPolys;
        private Canvas _deepOrangePolys;
        private Canvas _redPolys;
        private Canvas _purplePolys;
        private Canvas _deepPurplePolys;
        private Canvas _bluePolys;
        private Canvas _lightBluePolys;
        private Canvas _indigoPolys;
        private Canvas _pinkPolys;

        /// <summary>
        ///     Gets or sets the name of the primary color.
        /// </summary>
        /// <value>The name of the primary color.</value>
        public string PrimaryName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the accent color.
        /// </summary>
        /// <value>The name of the accent color.</value>
        public string AccentName { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is dark.
        /// </summary>
        /// <value><c>true</c> if this instance is dark; otherwise, <c>false</c>.</value>
        public bool IsDark { get; set; }

        public bool ForegroundIsDark { get; set; }

        #endregion Template Properties
    }
}