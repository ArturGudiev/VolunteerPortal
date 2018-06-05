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
        private static LoginController instance ;
        public static LoginController getInstance(Application0 app)
        {
            if (instance == null)
                instance = new LoginController(app);
            return instance;
        }
        
        Button loginButton;
        TextBlock volunteerId;
        TextBlock password;
        Input volunteerIdInput;
        Input passwordInput;        
        
        enum LoginControllerState
        {
            State1,
        }
        TextBlock getTextBlock(string str, double fsize = 0)
        {
            
            return new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,                   // Vertical alignment within the parent control
                HorizontalAlignment = HorizontalAlignment.Center,               // Horizontal alignment within the parent control
                WrapContent = true,                                             // If we don't set WrapContent attribute, the text block will 
                Font = new Font(new FontFamily("Arial"), fsize == 0 ? Screen.LargeFontSize : fsize ), // Font for drawing text. LargeFontSize is a predefined constant
                Text = str
            };
        }
        
        private LoginController(Application0 app) : base(app){}
        
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

          
            #endregion
            loginButton.Pressed += (s, e) => { controllerState = LoginControllerState.State1;};
            DropBox dropBox = new DropBox { };

            volunteerId = getTextBlock("Volunteer ID", 16);
            password = getTextBlock("Password", 16);
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
            passwordInput  = new Input
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
        
        private void showState11()
        {

            
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
            //todo Change controller
//           loginButton.Pressed += (s, e) => { this.app = AppState.State2;};
            DropBox dropBox = new DropBox { };

            volunteerId = getTextBlock("Volunteer ID", Screen.LargeBasicFontSize);
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
                Width = 150,
                Text = ""      
            };
            passwordInput = new Input
            {
                VerticalAlignment = VerticalAlignment.Center,           // Vertical alignment within the parent control
                HorizontalAlignment = HorizontalAlignment.Center,       // Horizontal alignment within the parent control
                Background = new SolidColorBrush(Colors.Gray),         // Color of button
                Foreground = new SolidColorBrush(Colors.Black),        // Color of text written on button   
                Padding = new Thickness(Screen.NormalFontSize),        // Padding is using predefined constant NormalFontSize that depends
                // on client device screen size
                WrapContent = true,
                Width = 150,
                Text = ""      
            };
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
        
    }
}