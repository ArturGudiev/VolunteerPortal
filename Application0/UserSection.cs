//-----------------------------User-section----------------------------------------------------
//  <User-defined part of application>
//
//      This is partial class that can be invoked from main entry point
//      This class is purposed for user-defined bussines logic of the application
//      The user should add proprietary code.
//      All modifications will be preserved during all automatic re-generations of the project
//  </User-defined part of application>
//----------------------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using Ubiq.Graphics;
using System.Threading.Tasks;

namespace Application0
{
    partial class Application0
    {
        int _count = 0;
        Input input;
        string name = "";
        bool flag = true;
        Button loginButton;
        TextBlock result;
        StackPanel sp;
        TextBlock source;
        TextBlock target;
        DropBox dropBox1;
        DropBox dropBox2;
        StackPanel mainPanel;
        ListBox listBox;
        Button checkinButton;
        Button logoutButton;
        TextBlock volunteerId;
        TextBlock password;
        TextBlock key;
        TextBlock generatedKey;
        Input volunteerIdInput;
        Input passwordInput;
        Button backButton;
        private Controller currentController;

        private AppState appState = AppState.State1;
        enum AppState
        {
            State1,
            State2,
            State3
        };

        Button getButton(string str)
        {
            return new Button
            {
                VerticalAlignment = VerticalAlignment.Center, // Vertical alignment within the parent control
                HorizontalAlignment = HorizontalAlignment.Center, // Horizontal alignment within the parent control
                Background = new SolidColorBrush(Colors.Gray), // Color of button
                Foreground = new SolidColorBrush(Colors.Black), // Color of text written on button   
                Padding =
                    new Thickness(Screen
                        .NormalFontSize), // Padding is using predefined constant NormalFontSize that depends
                // on client device screen size
                WrapContent = true, // The button "wraps" its text with given padding
                Font = new Font(new FontFamily("Arial"), // Font for drawing text
                    0.5 * Screen
                        .LargeFontSize), // LargeFontSize is a predefined constant that depends on client device screen size  
                Text = str
            };
        }

        DropBox getDropBox(List<string> list)
        {
            return new DropBox
            {
                VerticalAlignment = VerticalAlignment.Center, // Vertical alignment within the parent control
                HorizontalAlignment = HorizontalAlignment.Center, // Horizontal alignment within the parent control
                //Background = new SolidColorBrush(Colors.White),         // Color of button
                //Foreground = new SolidColorBrush(Colors.White),        // Color of text written on button   
                Padding =
                    new Thickness(Screen
                        .NormalFontSize), // Padding is using predefined constant NormalFontSize that depends
                // on client device screen size
                WrapContent = true, // The button "wraps" its text with given padding
                Font = new Font(new FontFamily("Arial"), // Font for drawing text
                    0.5 * Screen
                        .LargeFontSize), // LargeFontSize is a predefined constant that depends on client device screen size  
                ItemList = list
            };
        }

        StackPanel getStackPanel(List<string> list)
        {
            List<Cell> listCell = list.Select(a => new Cell {Content = getTextBlock(a)}).ToList();
            var sp = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
            listCell.ForEach(e => sp.Children.Add(e));
            return sp;
        }

        StackPanel getStackPanel(List<VisualElement> list, Orientation or)
        {
            StackPanel sp = new StackPanel
            {
                Orientation = or,
                Children = { },
            };
            //list.ForEach(el => sp.Children.Add(el));
            for (int i = 0; i < list.Count; i++)
            {
                sp.Children.Add(list[i]);
            }

            return sp;
        }
        
        TextBlock getTextBlock(string str, double fsize = 0)
        {
            if (fsize == 0)
            {
                fsize = Screen.LargeBasicFontSize;
            }
            return new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,                   // Vertical alignment within the parent control
                HorizontalAlignment = HorizontalAlignment.Center,               // Horizontal alignment within the parent control
                WrapContent = true,                                             // If we don't set WrapContent attribute, the text block will 
                Font = new Font(new FontFamily("Arial"), fsize ), // Font for drawing text. LargeFontSize is a predefined constant
                Text = str
            };
        }

       
        
        //User section for bussines logic
        //Your code should be inserted here
        protected async Task UserSection()
        {
            currentController = LoginController.getInstance(this);
            
            for (; ; )
            {
                currentController.action();
//                switch (appState)
//                {
//                    case AppState.State1:
//                        showState1();
//                        break;
//                    case AppState.State2:
//                        showState2();
//                        break;
//                    case AppState.State3:
//                        showState3();
//                        break;
//                }
                // Wait for user action or dispatcher event
                await Wait();
            }
        }

        private void showState1()
        {
            #region stat1
            loginButton = new Button
            {
                VerticalAlignment = VerticalAlignment.Center,           // Vertical alignment within the parent control
                HorizontalAlignment = HorizontalAlignment.Center,       // Horizontal alignment within the parent control
                Background = new SolidColorBrush(Colors.Gray),         // Color of button
                Foreground = new SolidColorBrush(Colors.Black),        // Color of text written on button   
                Padding = new Thickness(Screen.NormalFontSize),        // Padding is using predefined constant NormalFontSize that depends
                // on client device screen size
                WrapContent = true,                                     // The button "wraps" its text with given padding
                Font = new Font(new FontFamily("Arial"),               // Font for drawing text
                                 0.5 * Screen.LargeFontSize),           // LargeFontSize is a predefined constant that depends on client device screen size         
                Text = "Log in",
            };

            source = new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,                   // Vertical alignment within the parent control
                HorizontalAlignment = HorizontalAlignment.Center,               // Horizontal alignment within the parent control
                WrapContent = true,                                             // If we don't set WrapContent attribute, the text block will 
                Font = new Font(new FontFamily("Arial"), Screen.LargeFontSize), // Font for drawing text. LargeFontSize is a predefined constant
                Text = "Откуда",
            };

            target = new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,                   // Vertical alignment within the parent control
                HorizontalAlignment = HorizontalAlignment.Center,               // Horizontal alignment within the parent control
                WrapContent = true,                                             // If we don't set WrapContent attribute, the text block will 
                Font = new Font(new FontFamily("Arial"), Screen.LargeFontSize), // Font for drawing text. LargeFontSize is a predefined constant
                Text = "Куда",
            }; 
            dropBox1 = new DropBox
            {
                VerticalAlignment = VerticalAlignment.Center,           // Vertical alignment within the parent control
                HorizontalAlignment = HorizontalAlignment.Center,       // Horizontal alignment within the parent control
                //Background = new SolidColorBrush(Colors.White),         // Color of button
                //Foreground = new SolidColorBrush(Colors.White),        // Color of text written on button   
                Padding = new Thickness(Screen.NormalFontSize),        // Padding is using predefined constant NormalFontSize that depends
                // on client device screen size
                WrapContent = true,                                     // The button "wraps" its text with given padding
                Font = new Font(new FontFamily("Arial"),               // Font for drawing text
                                 0.5 * Screen.LargeFontSize),           // LargeFontSize is a predefined constant that depends on client device screen size                      
                ItemList = new List<string>(new string[] { "Мартышкино", "Университет", "Старый Петергоф", "Новый Петергоф",
                "Стрельна", "Сергиево", "Сосновая Полняна", "Лигово", "Ульянка", "Дачное", "Ленинский Проспект", "Санкт-Петербург"}),
            };

            dropBox2 = new DropBox
            {
                VerticalAlignment = VerticalAlignment.Center,           // Vertical alignment within the parent control
                HorizontalAlignment = HorizontalAlignment.Center,       // Horizontal alignment within the parent control
                //Background = new SolidColorBrush(Colors.White),         // Color of button
                //Foreground = new SolidColorBrush(Colors.White),        // Color of text written on button   
                Padding = new Thickness(Screen.NormalFontSize),        // Padding is using predefined constant NormalFontSize that depends
                // on client device screen size
                WrapContent = true,                                     // The button "wraps" its text with given padding
                Font = new Font(new FontFamily("Arial"),               // Font for drawing text
                                 0.5 * Screen.LargeFontSize),           // LargeFontSize is a predefined constant that depends on client device screen size  
                ItemList = new List<string>(new string[] { "Мартышкино", "Университет", "Старый Петергоф", "Новый Петергоф",
                "Стрельна", "Сергиево", "Сосновая Полняна", "Лигово", "Ульянка", "Дачное", "Ленинский Проспект", "Санкт-Петербург"}),
            };
            #endregion
            loginButton.Pressed += (s, e) => { appState = AppState.State2;};
            DropBox dropBox = new DropBox { };

            volunteerId = getTextBlock("Volunteer ID", Screen.SmallBasicFontSize);
            password = getTextBlock("Password", Screen.SmallBasicFontSize);
            volunteerIdInput = new Input
            {
                VerticalAlignment = VerticalAlignment.Center,           // Vertical alignment within the parent control
                HorizontalAlignment = HorizontalAlignment.Center,       // Horizontal alignment within the parent control
                Background = new SolidColorBrush(Colors.Gray),         // Color of button
                Foreground = new SolidColorBrush(Colors.Black),        // Color of text written on button   
                Padding = new Thickness(Screen.NormalFontSize),        // Padding is using predefined constant NormalFontSize that depends
                // on client device screen size
                WrapContent = true,
                Width = 200,
                Text = ""      
            };
            passwordInput = input = new Input
            {
                VerticalAlignment = VerticalAlignment.Center,           // Vertical alignment within the parent control
                HorizontalAlignment = HorizontalAlignment.Center,       // Horizontal alignment within the parent control
                Background = new SolidColorBrush(Colors.Gray),         // Color of button
                Foreground = new SolidColorBrush(Colors.Black),        // Color of text written on button   
                Padding = new Thickness(Screen.NormalFontSize),        // Padding is using predefined constant NormalFontSize that depends
                // on client device screen size
                WrapContent = true,
                Width = 200,
                Text = ""      
            };
         
            var textState1 = getTextBlock("State1");
            var panel = new StackPanel
            {
                Children =  
                {
                    new Cell{Content = new StackPanel{ Children =
                    {
                        new Cell {Content = volunteerId},
                        new Cell {Content = volunteerIdInput},   
                    }, Orientation = Orientation.Horizontal}},
                   
                    new Cell{Content = new StackPanel{ Children =
                    {
                        new Cell {Content = password},
                        new Cell {Content = passwordInput},
                    }, Orientation = Orientation.Horizontal}},
                    new Cell {Content = loginButton},
                },

                
            };
            Screen.Content = panel;
        }
        
        
        
        private void showState2()
        {
            checkinButton = getButton("Check in");
            logoutButton = getButton("Log out");
            
            
            var source = dropBox1.ItemList[dropBox1.Index];
            var target = dropBox2.ItemList[dropBox2.Index];
            //var textBlock = getTextBlock(source + " -> " + target);
            var textBlock = new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,                   // Vertical alignment within the parent control
                HorizontalAlignment = HorizontalAlignment.Center,               // Horizontal alignment within the parent control
                WrapContent = true,                                             // If we don't set WrapContent attribute, the text block will 
                Height = 50,
                Font = new Font(new FontFamily("Arial"), Screen.LargeBasicFontSize), // Font for drawing text. LargeFontSize is a predefined constant
                Text = source + " : " + target,
                Foreground = new SolidColorBrush(Colors.Black),
            };
            checkinButton.Pressed += (s, e) => { appState = AppState.State3;};
            logoutButton.Pressed += (s, e) => { appState = AppState.State1;};
          
            //var target = getTextBlock("Target");
            var panel = new StackPanel
            {
                Children =  
                {
                    new Cell {Content = checkinButton, Height = 70},
                    new Cell {Content = logoutButton, Height = 70},
                },
                Background = new SolidColorBrush(Colors.LightBlue),
            };
            Screen.Content = panel;
        }
        
         private void showState3()
        {
            #region stat1
         
            #endregion

            generatedKey = getTextBlock("Generated key", Screen.SmallBasicFontSize);
            Random rnd = new Random();
            
            
            key = getTextBlock( rnd.Next(1000, 9999).ToString() ,  Screen.SmallBasicFontSize);
            DropBox dropBox = new DropBox { };
         
            
            backButton = getButton("Back");
            backButton.Pressed += (e, v) => { appState = AppState.State2; };
            var panel = new StackPanel
            {
                Children =  
                {
                    new Cell{Content = generatedKey},
                    new Cell{Content = key},
                    new Cell {Content = backButton},
                },

                
            };
            Screen.Content = panel;
        }
        
    }
    
}