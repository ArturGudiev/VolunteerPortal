//Generated material. Generating code in C#.

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
    }


    public class LoginController : Controller
    {
        StackPanel volunteerIdInput;
        StackPanel passwordInput;
        Button loginButton;
        private bool sw1;
        private static LoginController instance;

        private LoginController(Application0 app) : base(app)
        {
        }

        public static LoginController getInstance(Application0 app)
        {
            if (instance == null)
                instance = new LoginController(app);
            return instance;
        }

        enum LoginControllerState
        {
            LoginState,
        }

        private LoginControllerState controllerState = LoginControllerState.LoginState;

        public override void action()
        {
            switch (controllerState)
            {
                case LoginControllerState.LoginState:
                    showLoginState();

                    if (sw1)
                    {
                        this.app.currentController = MainController.getInstance(this.app);
                        this.app.changed = true;
                        sw1 = false;
                    }


                    break;
            }
        }

        private void showLoginState()
        {
            var volunteerIdInputLeft = new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                WrapContent = true,
                Font = new Font(new FontFamily("Arial"), 16),
                Foreground = new SolidColorBrush(Colors.Black),
                Text = "Volunteer Id"
            };
            var volunteerIdInputRight = new Input
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Background = new SolidColorBrush(Colors.White),
                Foreground = new SolidColorBrush(Colors.Black),
                Padding = new Thickness(Screen.NormalFontSize),
                WrapContent = true,
                Width = 150,
                Font = new Font(new FontFamily("Arial"), 12),
                InputMode = Ubiq.Graphics.InputMode.Text,
                Text = ""
            };
            volunteerIdInput = new StackPanel
            {
                Children = {new Cell {Content = volunteerIdInputLeft}, new Cell {Content = volunteerIdInputRight},},
                Orientation = Orientation.Horizontal
            };

            var passwordInputLeft = new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                WrapContent = true,
                Font = new Font(new FontFamily("Arial"), 16),
                Foreground = new SolidColorBrush(Colors.Black),
                Text = "Password"
            };
            var passwordInputRight = new Input
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Background = new SolidColorBrush(Colors.White),
                Foreground = new SolidColorBrush(Colors.Black),
                Padding = new Thickness(Screen.NormalFontSize),
                WrapContent = true,
                Width = 150,
                Font = new Font(new FontFamily("Arial"), 12),
                InputMode = Ubiq.Graphics.InputMode.SecureText,
                Text = ""
            };
            passwordInput = new StackPanel
            {
                Children = {new Cell {Content = passwordInputLeft}, new Cell {Content = passwordInputRight},},
                Orientation = Orientation.Horizontal
            };

            loginButton = new Button
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Background = new SolidColorBrush(Colors.Gray),
                Foreground = new SolidColorBrush(Colors.Black),
                Padding = new Thickness(Screen.NormalFontSize),
                WrapContent = true,
                Font = new Font(new FontFamily("Arial"), 0.5 * Screen.LargeFontSize),
                Text = "Log in"
            };
            loginButton.Pressed += (x, y) => { sw1 = true;};
            var panel = new StackPanel
            {
                Children =
                {
                    new Cell {Content = volunteerIdInput},
                    new Cell {Content = passwordInput},
                    new Cell {Content = loginButton},
                },
                Background = new SolidColorBrush(Colors.LightBlue),
            };
            Screen.Content = panel;
        }
    }

    public class MainController : Controller
    {
        Button checkinButton;
        Button LogoutButton;
        TextBlock generatedKeyLabel;
        TextBlock KeyLabel;
        Button BackButton;
        private bool sw1;
        private bool sw2;
        private bool sw3;
        private static MainController instance;

        private MainController(Application0 app) : base(app)
        {
        }

        public static MainController getInstance(Application0 app)
        {
            if (instance == null)
                instance = new MainController(app);
            return instance;
        }

        enum MainControllerState
        {
            StartState,
            CheckinState,
        }

        private MainControllerState controllerState = MainControllerState.StartState;

        public override void action()
        {
            switch (controllerState)
            {
                case MainControllerState.StartState:
                    showStartState();

                    if (sw2)
                    {
                        this.app.currentController = LoginController.getInstance(this.app);
                        this.app.changed = true;
                        sw2 = false;
                    }


                    if (sw1)
                    {
                        controllerState = MainControllerState.CheckinState;
                        this.app.changed = true;
                        sw1 = false;
                    }

                    break;

                case MainControllerState.CheckinState:
                    showCheckinState();


                    if (sw3)
                    {
                        controllerState = MainControllerState.StartState;
                        this.app.changed = true;
                        sw3 = false;
                    }

                    break;
            }
        }

        private void showStartState()
        {
            checkinButton = new Button
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Background = new SolidColorBrush(Colors.Gray),
                Foreground = new SolidColorBrush(Colors.Black),
                Padding = new Thickness(Screen.NormalFontSize),
                WrapContent = true,
                Font = new Font(new FontFamily("Arial"), 0.5 * Screen.LargeFontSize),
                Text = "Check in"
            };
            checkinButton.Pressed += (x, y) => { sw1 = true;};
            LogoutButton = new Button
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Background = new SolidColorBrush(Colors.Gray),
                Foreground = new SolidColorBrush(Colors.Black),
                Padding = new Thickness(Screen.NormalFontSize),
                WrapContent = true,
                Font = new Font(new FontFamily("Arial"), 0.5 * Screen.LargeFontSize),
                Text = "Log Out"
            };
            LogoutButton.Pressed += (x, y) => { sw2 = true;};
            var panel = new StackPanel
            {
                Children =
                {
                    new Cell {Content = checkinButton},
                    new Cell {Content = LogoutButton},
                },
                Background = new SolidColorBrush(Colors.LightBlue),
            };
            Screen.Content = panel;
        }

        private void showCheckinState()
        {
            generatedKeyLabel = new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                WrapContent = true,
                Font = new Font(new FontFamily("Arial"), 16),
                Foreground = new SolidColorBrush(Colors.Black),
                Text = "Generated key:"
            };
            KeyLabel = new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                WrapContent = true,
                Font = new Font(new FontFamily("Arial"), 16),
                Foreground = new SolidColorBrush(Colors.Black),
                Text = ""
            };
            BackButton = new Button
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Background = new SolidColorBrush(Colors.Gray),
                Foreground = new SolidColorBrush(Colors.Black),
                Padding = new Thickness(Screen.NormalFontSize),
                WrapContent = true,
                Font = new Font(new FontFamily("Arial"), 0.5 * Screen.LargeFontSize),
                Text = "Back"
            };
            BackButton.Pressed += (x, y) => { sw3 = true;};
            var panel = new StackPanel
            {
                Children =
                {
                    new Cell {Content = generatedKeyLabel},
                    new Cell {Content = KeyLabel},
                    new Cell {Content = BackButton},
                },
                Background = new SolidColorBrush(Colors.LightBlue),
            };
            Screen.Content = panel;
        }
    }
}