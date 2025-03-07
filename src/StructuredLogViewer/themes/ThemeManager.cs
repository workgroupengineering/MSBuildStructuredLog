﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
//using AdonisUI;
using ResourceLocator = AdonisUI.ResourceLocator;

namespace StructuredLogViewer
{
    public class ThemeManager
    {
        static ThemeManager()
        {
            SystemParameters.StaticPropertyChanged += SystemParameters_StaticPropertyChanged;
        }

        public static bool UseDarkTheme { get; set; }

        private static void SystemParameters_StaticPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SystemParameters.HighContrast))
            {
                UpdateTheme();
            }
        }

        private static bool useAdonisDarkTheme;
        public static bool UseAdonisDarkTheme
        {
            get => useAdonisDarkTheme;

            set
            {
                if (useAdonisDarkTheme == value)
                {
                    return;
                }

                useAdonisDarkTheme = value;
                var appResources = Application.Current.Resources;
                if (value)
                {
                    ResourceLocator.SetColorScheme(appResources, ResourceLocator.DarkColorScheme);

                    appResources.MergedDictionaries.Add(
                        new ResourceDictionary()
                        {
                            Source = new Uri("pack://application:,,,/AdonisUI;component/ColorSchemes/dark.xaml")
                        });
                    appResources.MergedDictionaries.Add(
                        new ResourceDictionary()
                        {
                            Source = new Uri("pack://application:,,,/AdonisUI.ClassicTheme;component/Resources.xaml")
                        });

                    appResources[AdonisUI.Colors.Layer0BackgroundColor] = GetColor("#2A2B2F");
                    appResources[AdonisUI.Colors.Layer0BorderColor] = GetColor("#2A2B2F");
                    appResources[AdonisUI.Colors.Layer1BackgroundColor] = GetColor("#3D3D3D");
                    appResources[AdonisUI.Colors.Layer2HighlightColor] = GetColor("#3D3D3D");
                }
                else
                {
                    ResourceLocator.RemoveAdonisResources(appResources);
                }
            }
        }

        public static readonly Color Background = GetColor("#3D3D3D");
        public static readonly Brush BackgroundBrush = new SolidColorBrush(Background);
        public static readonly Color LighterBackground = GetColor("#454545");
        public static readonly Brush LighterBackgroundBrush = new SolidColorBrush(LighterBackground);
        public static readonly Color ControlText = Color.FromRgb(200, 200, 200);
        public static readonly Brush ControlTextBrush = new SolidColorBrush(ControlText);

        private static readonly BrushConverter brushConverter = new BrushConverter();
        public static Brush GetBrush(string hex) => (Brush)brushConverter.ConvertFromString(hex);
        public static Color GetColor(string hex) => (Color)ColorConverter.ConvertFromString(hex);

        public static void UpdateTheme()
        {
            var groupBoxOuterBorder = "White";
            var groupBoxMiddleBorder = "#D5DFD5";
            var groupBoxInnerBorder = "White";

            var menuStaticBackground = "#FFF0F0F0";
            var menuStaticBorder = "#FF999999";
            var menuStaticForeground = "#FF212121";
            var menuStaticSeparator = "#FFD7D7D7";
            var menuDisabledBackground = "#3DDADADA";
            var menuDisabledBorder = "#FFDADADA";
            var menuDisabledForeground = "#FF707070";
            var menuItemSelectedBackground = "#3D26A0DA";
            var menuItemSelectedBorder = "#FF26A0DA";
            var menuItemHighlightBackground = "#3D26A0DA";
            var menuItemHighlightBorder = "#FF26A0DA";
            var menuItemHighlightDisabledBackground = "#0A000000";
            var menuItemHighlightDisabledBorder = "#21000000";

            var scrollBarStaticBackground = "#F0F0F0";
            var scrollBarStaticBorder = "#F0F0F0";
            var scrollBarStaticGlyph = "#606060";
            var scrollBarStaticThumb = "#CDCDCD";
            var scrollBarMouseOverBackground = "#DADADA";
            var scrollBarMouseOverBorder = "#DADADA";
            var scrollBarMouseOverGlyph = "#000000";
            var scrollBarMouseOverThumb = "#A6A6A6";
            var scrollBarPressedBackground = "#606060";
            var scrollBarPressedBorder = "#606060";
            var scrollBarPressedThumb = "#606060";
            var scrollBarPressedGlyph = "#FFFFFF";
            var scrollBarDisabledBackground = "#F0F0F0";
            var scrollBarDisabledBorder = "#F0F0F0";
            var scrollBarDisabledGlyph = "#BFBFBF";
            var scrollBarDisabledThumb = "#F0F0F0";

            var tabItemStaticBackground = "Transparent";
            var tabItemStaticBorder = "#ACACAC";
            var tabItemSelectedBackground = "#FFFFFF";
            var tabItemSelectedBorder = "#ACACAC";
            var tabItemMouseOverBackground = "#ECF4FC";
            var tabItemMouseOverBorder = "#7EB4EA";
            var tabItemDisabledBackground = "#F0F0F0";
            var tabItemDisabledBorder = "#D9D9D9";

            if (SystemParameters.HighContrast)
            {
                UseAdonisDarkTheme = false;
                SetResource("Theme_Background", SystemColors.AppWorkspaceBrush);
                SetResource("Theme_WhiteBackground", SystemColors.ControlBrush);
                SetResource("Theme_ToolWindowBackground", SystemColors.ControlBrush);
                SetResource("ImportStroke", Brushes.Sienna);
                SetResource("NoImportStroke", GetBrush("#FF0000"));
                SetResource("NoImportFill", Brushes.BlanchedAlmond);
                SetResource("NuGet", Brushes.DeepSkyBlue);
                SetResource(SystemColors.MenuBarBrushKey, SystemColors.MenuBarBrush);

                SetDefaultSystemColors();
            }
            else if (UseDarkTheme)
            {
                var color500 = "#9E9E9E";
                var color600 = "#757575";
                var color700 = "#616161";
                var color800 = "#424242";
                var color850 = "#303030";
                var color900 = "#212121";
                var foregroundColor = "#e5ffffff";
                var foregroundDisabledColor = "#50ffffff";
                var selectionColor1 = "#3b5464";
                var selectionColor1Opacity05 = "#803b5464";
                var selectionColor2 = "#36A2DB";

                SetResource("Theme_Background", LighterBackgroundBrush);
                SetResource("Theme_WhiteBackground", BackgroundBrush);
                SetResource("Theme_ToolWindowBackground", LighterBackgroundBrush);
                SetResource("Theme_InfoBarBackground", GetBrush("#202040"));

                UseAdonisDarkTheme = false;

                SetResource(SystemColors.ControlBrushKey, LighterBackgroundBrush);
                SetResource(SystemColors.ControlTextBrushKey, ControlTextBrush);
                SetResource(SystemColors.HighlightBrushKey, Brushes.SlateBlue);
                SetResource(SystemColors.InactiveSelectionHighlightBrushKey, Brushes.DimGray);
                SetResource(SystemColors.WindowBrushKey, BackgroundBrush);

                SetResource(SystemColors.MenuBarBrushKey, LighterBackgroundBrush);
                SetResource(SystemColors.MenuHighlightBrushKey, LighterBackgroundBrush);
                SetResource(SystemColors.MenuTextBrushKey, ControlTextBrush);
                SetResource(SystemColors.MenuBrushKey, BackgroundBrush);
                SetResource(SystemColors.MenuBarColorKey, Background);
                SetResource(SystemColors.MenuHighlightColorKey, LighterBackground);
                SetResource(SystemColors.MenuTextColorKey, ControlText);
                SetResource(SystemColors.MenuColorKey, Background);

                SetResource("ImportStroke", GetBrush("#F08244"));
                SetResource("NoImportStroke", GetBrush("#FFCCCC"));
                SetResource("NoImportFill", GetBrush("#474138"));
                SetResource("TargetStroke", GetBrush("#C0A0F0"));
                SetResource("AddItemStroke", GetBrush("#40B0B0"));
                SetResource("NuGet", Brushes.DeepSkyBlue);
                SetResource("\u01D6", GetBrush("#C0C0C0"));

                groupBoxOuterBorder = color850;
                groupBoxMiddleBorder = color700;
                groupBoxInnerBorder = color850;

                menuStaticBackground = color800;
                menuStaticBorder = color700;
                menuStaticForeground = foregroundColor;
                menuStaticSeparator = color500;
                menuDisabledBackground = color850;
                menuDisabledBorder = color800;
                menuDisabledForeground = foregroundDisabledColor;
                menuItemSelectedBackground = selectionColor1;
                menuItemSelectedBorder = selectionColor2;
                menuItemHighlightBackground = selectionColor1Opacity05;
                menuItemHighlightBorder = selectionColor2;
                menuItemHighlightDisabledBackground = color850;
                menuItemHighlightDisabledBorder = color800;

                scrollBarStaticBackground = color800;
                scrollBarStaticBorder = color800;
                scrollBarStaticGlyph = foregroundColor;
                scrollBarStaticThumb = color700;
                scrollBarMouseOverBackground = color700;
                scrollBarMouseOverBorder = color700;
                scrollBarMouseOverGlyph = foregroundColor;
                scrollBarMouseOverThumb = color600;
                scrollBarPressedBackground = color600;
                scrollBarPressedBorder = color600;
                scrollBarPressedThumb = color500;
                scrollBarPressedGlyph = foregroundColor;
                scrollBarDisabledBackground = color800;
                scrollBarDisabledBorder = color800;
                scrollBarDisabledGlyph = foregroundDisabledColor;
                scrollBarDisabledThumb = color700;

                tabItemStaticBackground = color850;
                tabItemStaticBorder = color700;
                tabItemSelectedBackground = color900;
                tabItemSelectedBorder = color800;
                tabItemMouseOverBackground = color700;
                tabItemMouseOverBorder = color600;
                tabItemDisabledBackground = color850;
                tabItemDisabledBorder = color800;
            }
            else
            {
                UseAdonisDarkTheme = false;
                SetResource("Theme_Background", new SolidColorBrush(Color.FromRgb(238, 238, 242)));
                SetResource("Theme_WhiteBackground", Brushes.White);
                SetResource("Theme_ToolWindowBackground", Brushes.WhiteSmoke);
                SetResource("ImportStroke", Brushes.Sienna);
                SetResource("NoImportStroke", GetBrush("#FF0000"));
                SetResource("NoImportFill", Brushes.BlanchedAlmond);
                SetResource("TargetStroke", Brushes.MediumPurple);
                SetResource("AddItemStroke", Brushes.Teal);
                SetResource("NuGet", GetBrush("#004880"));
                SetResource("\u01D6", GetBrush("#595959"));
                SetResource(SystemColors.MenuBarBrushKey, "#F5F5F5");

                SetDefaultSystemColors();
            }

            SetResource("GroupBox.Static.OuterBorder", GetBrush(groupBoxOuterBorder));
            SetResource("GroupBox.Static.MiddleBorder", GetBrush(groupBoxMiddleBorder));
            SetResource("GroupBox.Static.InnerBorder", GetBrush(groupBoxInnerBorder));

            SetResource("Menu.Static.Background", GetBrush(menuStaticBackground));
            SetResource("Menu.Static.Border", GetBrush(menuStaticBorder));
            SetResource("Menu.Static.Foreground", GetBrush(menuStaticForeground));
            SetResource("Menu.Static.Separator", GetBrush(menuStaticSeparator));
            SetResource("Menu.Disabled.Background", GetBrush(menuDisabledBackground));
            SetResource("Menu.Disabled.Border", GetBrush(menuDisabledBorder));
            SetResource("Menu.Disabled.Foreground", GetBrush(menuDisabledForeground));
            SetResource("MenuItem.Selected.Background", GetBrush(menuItemSelectedBackground));
            SetResource("MenuItem.Selected.Border", GetBrush(menuItemSelectedBorder));
            SetResource("MenuItem.Highlight.Background", GetBrush(menuItemHighlightBackground));
            SetResource("MenuItem.Highlight.Border", GetBrush(menuItemHighlightBorder));
            SetResource("MenuItem.Highlight.Disabled.Background", GetBrush(menuItemHighlightDisabledBackground));
            SetResource("MenuItem.Highlight.Disabled.Border", GetBrush(menuItemHighlightDisabledBorder));

            SetResource("ScrollBar.Static.Background", GetBrush(scrollBarStaticBackground));
            SetResource("ScrollBar.Static.Border", GetBrush(scrollBarStaticBorder));
            SetResource("ScrollBar.Static.Glyph", GetBrush(scrollBarStaticGlyph));
            SetResource("ScrollBar.Static.Thumb", GetBrush(scrollBarStaticThumb));
            SetResource("ScrollBar.MouseOver.Background", GetBrush(scrollBarMouseOverBackground));
            SetResource("ScrollBar.MouseOver.Border", GetBrush(scrollBarMouseOverBorder));
            SetResource("ScrollBar.MouseOver.Glyph", GetBrush(scrollBarMouseOverGlyph));
            SetResource("ScrollBar.MouseOver.Thumb", GetBrush(scrollBarMouseOverThumb));
            SetResource("ScrollBar.Pressed.Background", GetBrush(scrollBarPressedBackground));
            SetResource("ScrollBar.Pressed.Border", GetBrush(scrollBarPressedBorder));
            SetResource("ScrollBar.Pressed.Thumb", GetBrush(scrollBarPressedThumb));
            SetResource("ScrollBar.Pressed.Glyph", GetBrush(scrollBarPressedGlyph));
            SetResource("ScrollBar.Disabled.Background", GetBrush(scrollBarDisabledBackground));
            SetResource("ScrollBar.Disabled.Border", GetBrush(scrollBarDisabledBorder));
            SetResource("ScrollBar.Disabled.Glyph", GetBrush(scrollBarDisabledGlyph));
            SetResource("ScrollBar.Disabled.Thumb", GetBrush(scrollBarDisabledThumb));

            SetResource("TabItem.Static.Background", GetBrush(tabItemStaticBackground));
            SetResource("TabItem.Static.Border", GetBrush(tabItemStaticBorder));
            SetResource("TabItem.Selected.Background", GetBrush(tabItemSelectedBackground));
            SetResource("TabItem.Selected.Border", GetBrush(tabItemSelectedBorder));
            SetResource("TabItem.MouseOver.Background", GetBrush(tabItemMouseOverBackground));
            SetResource("TabItem.MouseOver.Border", GetBrush(tabItemMouseOverBorder));
            SetResource("TabItem.MouseOver.Background", GetBrush(tabItemMouseOverBackground));
            SetResource("TabItem.MouseOver.Border", GetBrush(tabItemMouseOverBorder));
        }

        private static void SetDefaultSystemColors()
        {
            SetResource(SystemColors.ControlBrushKey, SystemColors.ControlBrush);
            SetResource(SystemColors.ControlTextBrushKey, SystemColors.ControlTextBrush);
            SetResource(SystemColors.WindowBrushKey, SystemColors.WindowBrush);
            SetResource(SystemColors.HighlightBrushKey, Brushes.LightSkyBlue);
            SetResource(SystemColors.InactiveSelectionHighlightBrushKey, SystemColors.InactiveSelectionHighlightBrush);
            SetResource(SystemColors.MenuHighlightBrushKey, SystemColors.MenuHighlightBrush);
            SetResource(SystemColors.MenuTextBrushKey, SystemColors.MenuTextBrush);
            SetResource(SystemColors.MenuBrushKey, SystemColors.MenuBrush);
            SetResource(SystemColors.MenuBarColorKey, SystemColors.MenuBarColor);
            SetResource(SystemColors.MenuHighlightColorKey, SystemColors.MenuHighlightColor);
            SetResource(SystemColors.MenuTextColorKey, SystemColors.MenuTextColor);
            SetResource(SystemColors.MenuColorKey, SystemColors.MenuColor);
            SetResource("Theme_InfoBarBackground", SystemColors.InfoBrush);
        }

        private static void SetResource(object key, object value)
        {
            Application.Current.Resources[key] = value;
        }
    }
}