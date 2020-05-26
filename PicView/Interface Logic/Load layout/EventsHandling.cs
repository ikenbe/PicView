﻿using System;
using System.ComponentModel;
using System.Windows;
using static PicView.Copy_Paste;
using static PicView.DeleteFiles;
using static PicView.DragAndDrop;
using static PicView.Fields;
using static PicView.Utilities;
using static PicView.HideInterfaceLogic;
using static PicView.LoadWindows;
using static PicView.MouseOverAnimations;
using static PicView.Navigation;
using static PicView.Open_Save;
using static PicView.Resize_and_Zoom;
using static PicView.Rotate_and_Flip;
using static PicView.Scroll;
using static PicView.Shortcuts;
using static PicView.ToggleMenus;
using static PicView.WindowLogic;

namespace PicView
{
    internal static class Eventshandling
    {
        internal static void Go()
        {
            // keyboard and Mouse_Keys Keys
            mainWindow.KeyDown += MainWindow_KeysDown;
            mainWindow.KeyUp += MainWindow_KeysUp;
            mainWindow.MouseDown += MainWindow_MouseDown;

            // MinButton
            mainWindow.MinButton.TheButton.Click += (s, x) => SystemCommands.MinimizeWindow(mainWindow);

            // MaxButton
            mainWindow.FullscreenButton.TheButton.Click += (s, x) => Fullscreen_Restore();

            // CloseButton
            mainWindow.CloseButton.TheButton.Click += (s, x) => SystemCommands.CloseWindow(mainWindow);

            // FileMenuButton
            mainWindow.FileMenuButton.PreviewMouseLeftButtonDown += (s, x) => PreviewMouseButtonDownAnim(mainWindow.FolderFill);
            mainWindow.FileMenuButton.MouseEnter += (s, x) => ButtonMouseOverAnim(mainWindow.FolderFill);
            mainWindow.FileMenuButton.MouseLeave += (s, x) => ButtonMouseLeaveAnim(mainWindow.FolderFill);
            mainWindow.FileMenuButton.Click += Toggle_open_menu;

            fileMenu.Open.Click += (s, x) => Open();
            fileMenu.Open_File_Location.Click += (s, x) => Open_In_Explorer();
            fileMenu.Print.Click += (s, x) => Print(Pics[FolderIndex]);
            fileMenu.Save_File.Click += (s, x) => SaveFiles();

            fileMenu.Open_Border.MouseLeftButtonUp += (s, x) => Open();
            fileMenu.Open_File_Location_Border.MouseLeftButtonUp += (s, x) => Open_In_Explorer();
            fileMenu.Print_Border.MouseLeftButtonUp += (s, x) => Print(Pics[FolderIndex]);
            fileMenu.Save_File_Location_Border.MouseLeftButtonUp += (s, x) => SaveFiles();

            fileMenu.CloseButton.Click += Close_UserControls;
            fileMenu.PasteButton.Click += (s, x) => Paste();
            fileMenu.CopyButton.Click += (s, x) => CopyPic();

            // image_button
            mainWindow.image_button.PreviewMouseLeftButtonDown += (s, x) => PreviewMouseButtonDownAnim(mainWindow.ImagePath1Fill, mainWindow.ImagePath2Fill, mainWindow.ImagePath3Fill);
            mainWindow.image_button.MouseEnter += (s, x) => ButtonMouseOverAnim(mainWindow.ImagePath1Fill, mainWindow.ImagePath2Fill, mainWindow.ImagePath3Fill);
            mainWindow.image_button.MouseLeave += (s, x) => ButtonMouseLeaveAnim(mainWindow.ImagePath1Fill, mainWindow.ImagePath2Fill, mainWindow.ImagePath3Fill);
            mainWindow.image_button.Click += Toggle_image_menu;

            // imageSettingsMenu Buttons
            imageSettingsMenu.CloseButton.Click += Close_UserControls;
            imageSettingsMenu.Rotation0Button.Click += (s, x) => Rotate(0);
            imageSettingsMenu.Rotation90Button.Click += (s, x) => Rotate(90);
            imageSettingsMenu.Rotation180Button.Click += (s, x) => Rotate(180);
            imageSettingsMenu.Rotation270Button.Click += (s, x) => Rotate(270);
            imageSettingsMenu.Rotation0Border.MouseLeftButtonUp += (s, x) => Rotate(0);
            imageSettingsMenu.Rotation90Border.MouseLeftButtonUp += (s, x) => Rotate(90);
            imageSettingsMenu.Rotation180Border.MouseLeftButtonUp += (s, x) => Rotate(180);
            imageSettingsMenu.Rotation270Border.MouseLeftButtonUp += (s, x) => Rotate(270);
            imageSettingsMenu.BgButton.Click += ChangeBackground;
            imageSettingsMenu.GalleryButton1.Click += delegate {
                Close_UserControls();
                ToggleGallery.OpenPicGalleryOne();
            };
            imageSettingsMenu.GalleryButton2.Click += delegate {
                Close_UserControls();
                ToggleGallery.OpenPicGalleryTwo();
            };
            quickSettingsMenu.ToggleScroll.Checked += (s, x) => IsScrollEnabled = true;
            quickSettingsMenu.ToggleScroll.Unchecked += (s, x) => IsScrollEnabled = false;
            quickSettingsMenu.ToggleScroll.Click += Toggle_quick_settings_menu;

            quickSettingsMenu.SetFit.Click += (s, x) => { FitToWindow = true; };
            quickSettingsMenu.SetCenter.Click += (s, x) => { FitToWindow = false; };
            quickSettingsMenu.SettingsButton.Click += (s, x) => AllSettingsWindow();

            // LeftButton
            mainWindow.LeftButton.PreviewMouseLeftButtonDown += (s, x) => PreviewMouseButtonDownAnim(mainWindow.LeftArrowFill);
            mainWindow.LeftButton.MouseEnter += (s, x) => ButtonMouseOverAnim(mainWindow.LeftArrowFill);
            mainWindow.LeftButton.MouseLeave += (s, x) => ButtonMouseLeaveAnim(mainWindow.LeftArrowFill);
            mainWindow.LeftButton.Click += (s, x) => { LeftbuttonClicked = true; Pic(false, false); };

            // RightButton
            mainWindow.RightButton.PreviewMouseLeftButtonDown += (s, x) => PreviewMouseButtonDownAnim(mainWindow.RightArrowFill);
            mainWindow.RightButton.MouseEnter += (s, x) => ButtonMouseOverAnim(mainWindow.RightArrowFill);
            mainWindow.RightButton.MouseLeave += (s, x) => ButtonMouseLeaveAnim(mainWindow.RightArrowFill);
            mainWindow.RightButton.Click += (s, x) => { RightbuttonClicked = true; Pic(); };

            // SettingsButton
            mainWindow.SettingsButton.PreviewMouseLeftButtonDown += (s, x) => PreviewMouseButtonDownAnim(mainWindow.SettingsButtonFill);
            mainWindow.SettingsButton.MouseEnter += (s, x) => ButtonMouseOverAnim(mainWindow.SettingsButtonFill);
            mainWindow.SettingsButton.MouseLeave += (s, x) => ButtonMouseLeaveAnim(mainWindow.SettingsButtonFill);
            mainWindow.SettingsButton.Click += Toggle_quick_settings_menu;

            //FunctionButton
            mainWindow.FunctionMenuButton.PreviewMouseLeftButtonDown += (s, x) => PreviewMouseButtonDownAnim(mainWindow.FunctionButtonFill);
            mainWindow.FunctionMenuButton.MouseEnter += (s, x) => ButtonMouseOverAnim(mainWindow.FunctionButtonFill);
            mainWindow.FunctionMenuButton.MouseLeave += (s, x) => ButtonMouseLeaveAnim(mainWindow.FunctionButtonFill);
            mainWindow.FunctionMenuButton.Click += Toggle_Functions_menu;
            functionsMenu.FileDetailsButton.Click += (s, x) => NativeMethods.ShowFileProperties(Pics[FolderIndex]);
            functionsMenu.DeleteButton.Click += (s, x) => DeleteFile(Pics[FolderIndex], true);
            functionsMenu.DeletePermButton.Click += (s, x) => DeleteFile(Pics[FolderIndex], false);
            functionsMenu.ReloadButton.Click += (s, x) => Error_Handling.Reload();
            functionsMenu.ResetZoomButton.Click += (s, x) => ResetZoom();
            functionsMenu.ClearButton.Click += (s, x) => Error_Handling.Unload();
            //functionsMenu.SlideshowButton.Click += (s, x) => LoadSlideshow();
            functionsMenu.BgButton.Click += ChangeBackground;

            // FlipButton
            imageSettingsMenu.FlipButton.Click += (s, x) => Flip();

            // ClickArrows
            clickArrowLeft.MouseLeftButtonUp += (s, x) =>
            {
                clickArrowLeftClicked = true;
                Pic(false, false);
            };
            clickArrowLeft.MouseEnter += Interface_MouseEnter_Negative;

            clickArrowRight.MouseLeftButtonUp += (s, x) =>
            {
                clickArrowRightClicked = true;
                Pic();
            };
            clickArrowRight.MouseEnter += Interface_MouseEnter_Negative;

            // x2
            x2.MouseLeftButtonUp += (x, xx) => SystemCommands.CloseWindow(mainWindow);
            x2.MouseEnter += Interface_MouseEnter_Negative;

            // Minus
            minus.MouseLeftButtonUp += (s, x) => SystemCommands.MinimizeWindow(mainWindow);
            minus.MouseEnter += Interface_MouseEnter_Negative;

            // GalleryShortcut
            galleryShortcut.MouseLeftButtonUp += (s, x) => ToggleGallery.Toggle();
            galleryShortcut.MouseEnter += Interface_MouseEnter_Negative;

            // Bar
            mainWindow.Bar.MouseLeftButtonDown += Move;
            mainWindow.Bar.GotKeyboardFocus += EditTitleBar.EditTitleBar_Text;
            mainWindow.Bar.Bar.PreviewKeyDown += CustomTextBox_KeyDown;
            mainWindow.Bar.PreviewMouseLeftButtonDown += EditTitleBar.Bar_PreviewMouseLeftButtonDown;

            // img
            mainWindow.img.MouseLeftButtonDown += Zoom_img_MouseLeftButtonDown;
            mainWindow.img.MouseLeftButtonUp += Zoom_img_MouseLeftButtonUp;
            mainWindow.img.MouseMove += Zoom_img_MouseMove;
            mainWindow.img.MouseWheel += Zoom_img_MouseWheel;

            // bg
            mainWindow.bg.MouseLeftButtonDown += Bg_MouseLeftButtonDown;
            mainWindow.bg.Drop += Image_Drop;
            mainWindow.bg.DragEnter += Image_DragEnter;
            mainWindow.bg.DragLeave += Image_DragLeave;
            mainWindow.bg.MouseEnter += Interface_MouseEnter;
            mainWindow.bg.MouseMove += Interface_MouseMove;
            mainWindow.bg.MouseLeave += Interface_MouseLeave;

            // TooltipStyle
            sexyToolTip.MouseWheel += Zoom_img_MouseWheel;

            // TitleBar
            mainWindow.TitleBar.MouseLeftButtonDown += Move;
            mainWindow.TitleBar.MouseLeave += Restore_From_Move;

            // Logobg
            //Logobg.MouseEnter += LogoMouseOver;
            //Logobg.MouseLeave += LogoMouseLeave;
            //Logobg.PreviewMouseLeftButtonDown += LogoMouseButtonDown;

            // Lower Bar
            mainWindow.LowerBar.Drop += Image_Drop;

            // This
            mainWindow.Closing += Window_Closing;
            mainWindow.StateChanged += MainWindow_StateChanged;
            //Activated += delegate
            //{
            //    if (Properties.Settings.Default.PicGallery == 2)
            //    {
            //        fake.Focus();
            //        Focus();
            //    }
            //};

            //LocationChanged += MainWindow_LocationChanged;
            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
        }

        #region Changed Events

        private static void MainWindow_StateChanged(object sender, EventArgs e)
        {
            switch (mainWindow.WindowState)
            {
                case WindowState.Maximized:
                    FitToWindow = false;
                    break;
                case WindowState.Normal:
                    break;
                case WindowState.Minimized:
                    break;
            }
        }

        private static void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            // Update size when screen resulution changes

            MonitorInfo = MonitorSize.GetMonitorSize();
            TryZoomFit();
        }

        #endregion Changed Events

        /// <summary>
        /// Save settings when closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Window_Closing(object sender, CancelEventArgs e)
        {
            // Close Extra windows when closing
            if (fake != null)
            {
                fake.Close();
            }

            mainWindow.Hide(); // Make it feel faster

            if (!Properties.Settings.Default.FitToWindow && !Properties.Settings.Default.Fullscreen)
            {
                Properties.Settings.Default.Top = mainWindow.Top;
                Properties.Settings.Default.Left = mainWindow.Left;
                Properties.Settings.Default.Height = mainWindow.Height;
                Properties.Settings.Default.Width = mainWindow.Width;
                Properties.Settings.Default.Maximized = mainWindow.WindowState == WindowState.Maximized;
            }

            Properties.Settings.Default.Save();
            DeleteTempFiles();
            RecentFiles.WriteToFile();
            Environment.Exit(0);
        }

    }
}