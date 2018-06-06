using System;
using Ubiq.Graphics;

namespace Application0
{
    public abstract class Controller
    {
        protected Screen Screen;
        protected Application0 app;

        public Controller(Application0 app)
        {
            this.app = app;
            this.Screen = app.Screen;
        }

        public abstract void action();

        protected Button getButton(string str)
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

        protected TextBlock getTextBlock(string str, double fsize = 0)
        {
            return new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center, // Vertical alignment within the parent control
                HorizontalAlignment = HorizontalAlignment.Center, // Horizontal alignment within the parent control
                WrapContent = true, // If we don't set WrapContent attribute, the text block will 
                Font =
                    new Font(new FontFamily("Arial"),
                        fsize == 0
                            ? Screen.LargeFontSize
                            : fsize), // Font for drawing text. LargeFontSize is a predefined constant
                Foreground = new SolidColorBrush(Colors.Black),
                Text = str
            };
        }
    }

    public class LoginController : Controller
    {
        Button loginButton;
        TextBlock volunteerId;
        TextBlock password;
        Input volunteerIdInput;
        Input passwordInput;
        private static LoginController instance;

        public static LoginController getInstance(Application0 app)
        {
            if (instance == null)
                instance = new LoginController(app);
            return instance;
        }

        

        enum LoginControllerState
        {
            State1,
        }

        private LoginController(Application0 app) : base(app)
        {
        }

        private LoginControllerState controllerState = LoginControllerState.State1;


        public override void action()
        {
            switch (controllerState)
            {
                case LoginControllerState.State1:
                    showState1();
                    break;
            }
        }

        private void showState1()
        {
            #region stat1

            loginButton = new Button
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
                Text = "Log in",
            };

            #endregion

            loginButton.Pressed += (s, e) => { this.app.currentController = MainController.getInstance(this.app); };
            DropBox dropBox = new DropBox { };

            volunteerId = getTextBlock("Volunteer ID", 16);
            password = getTextBlock("Password", 16);
            volunteerIdInput = new Input
            {
                VerticalAlignment = VerticalAlignment.Center, // Vertical alignment within the parent control
                HorizontalAlignment = HorizontalAlignment.Center, // Horizontal alignment within the parent control
                Background = new SolidColorBrush(Colors.White), // Color of button
                Foreground = new SolidColorBrush(Colors.Black), // Color of text written on button   
                Padding =
                    new Thickness(Screen
                        .NormalFontSize), // Padding is using predefined constant NormalFontSize that depends
                // on client device screen size
                WrapContent = true,
                Width = 150,
                Font = new Font(new FontFamily("Arial"), 12),
                Text = ""
            };
            passwordInput = new Input
            {
                VerticalAlignment = VerticalAlignment.Center, // Vertical alignment within the parent control
                HorizontalAlignment = HorizontalAlignment.Center, // Horizontal alignment within the parent control
                Background = new SolidColorBrush(Colors.White), // Color of button
                Foreground = new SolidColorBrush(Colors.Black), // Color of text written on button   
                Padding =
                    new Thickness(Screen
                        .NormalFontSize), // Padding is using predefined constant NormalFontSize that depends
                // on client device screen size
                WrapContent = true,
                Width = 150,
                Font = new Font(new FontFamily("Arial"), 12),
                InputMode = Ubiq.Graphics.InputMode.SecureText,
                Text = ""
            };

            var textState1 = getTextBlock("State1");
            var panel = new StackPanel
            {
                Children =
                {
                    new Cell
                    {
                        Content = new StackPanel
                        {
                            Children =
                            {
                                new Cell {Content = volunteerId},
                                new Cell {Content = volunteerIdInput},
                            },
                            Orientation = Orientation.Horizontal
                        }
                    },

                    new Cell
                    {
                        Content = new StackPanel
                        {
                            Children =
                            {
                                new Cell {Content = password},
                                new Cell {Content = passwordInput},
                            },
                            Orientation = Orientation.Horizontal
                        }
                    },
                    new Cell {Content = loginButton},
                },
                Background = new SolidColorBrush(Colors.LightBlue),
            };
            Screen.Content = panel;
        }
    }

    public class MainController : Controller
    {
        private static MainController instance;

        public static MainController getInstance(Application0 app)
        {
            if (instance == null)
                instance = new MainController(app);
            return instance;
        }

        private MainController(Application0 app) : base(app)
        {
        }

        Button checkinButton;
        Button logoutButton;
        Button backButton;
        TextBlock generatedKey;
        TextBlock key;

        enum MainControllerState
        {
            State1,
            State2,
        }


        private MainControllerState controllerState = MainControllerState.State1;


        public override void action()
        {
            switch (controllerState)
            {
                case MainControllerState.State1:
                    showState1();
                    break;
                case MainControllerState.State2:
                    showState2();
                    break;
            }
        }

        private void showState1()
        {
            checkinButton = getButton("Check in");
//            checkinButton.Padding = new Thickness(120);
            logoutButton = getButton("Log out");
//            logoutButton.Padding = new Thickness(60);
            checkinButton.Pressed += (s, e) => { controllerState = MainControllerState.State2; };
            logoutButton.Pressed += (s, e) => { this.app.currentController = LoginController.getInstance(this.app); };

            //var target = getTextBlock("Target");
            var panel = new StackPanel
            {
                Children =
                {
                    new Cell {Content = checkinButton, Height = 70, Margin = new Thickness(80),},
                    new Cell {Content = logoutButton, Height = 70},
                },
                Background = new SolidColorBrush(Colors.LightBlue),
            };
            Screen.Content = panel;
        }

        private void showState2()
        {
            generatedKey = getTextBlock("Generated key", 16);

            Random rnd = new Random();
            key = getTextBlock(rnd.Next(1000, 9999).ToString(), Screen.SmallBasicFontSize);
            DropBox dropBox = new DropBox { };


            backButton = getButton("Back");
            backButton.Pressed += (e, v) => { controllerState = MainControllerState.State1; };
            var panel = new StackPanel
            {
                Children =
                {
                    new Cell {Content = generatedKey, Margin = new Thickness(32),},
                    new Cell {Content = key},
                    new Cell {Content = backButton},
                },
                Background = new SolidColorBrush(Colors.LightBlue),
            };
            Screen.Content = panel;
        }
    }
}