using System.Collections.Generic;
using System.Diagnostics;
using taskManager2._0.Module;
using taskManager2._0.View;


namespace taskManager2._0
{
    public partial class MainPage : ContentPage
    {
        LoginManagerList loginManager = LoginManagerList.LoginManager;
        public MainPage()
        {
            InitializeComponent();


        }

        //tar in all info och skickar till den shared listan som de har gemensamt
        public void OnLoginButtonClicked(object sender, EventArgs e)
        {
          
            string username = userName.Text;
            string password = userPassword.Text;
            string accessLevel = AccountTypePicker.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(accessLevel))
            {

                if (accessLevel == "Costumer")
                {
                    // skapa en ny instans av Customer klassen och skicka in användarnamn och lösenord
                    Costumers customer = new Costumers(username, password, 1);
                    loginManager.AddUser(customer);

                    customer.Login(username, password);
                    customer.Price(1); // 25% moms
                    DisplayAlert("Login", "Login successful", "OK");


                    Entrylock();

                }
                else if (accessLevel == "Staff")
                {
                    // skapa en ny instans av Staff klassen och skicka in användarnamn och lösenord
                    Staff staff = new Staff(username, password, 0);

                    loginManager.AddUser(staff);
                    staff.Login(username, password);
                    staff.Price(0); // 0% moms
                    DisplayAlert("Login", "Login successful", "OK");
                    Debug.WriteLine(staff.Name, staff.password);
                    Entrylock();

                }
                else
                {
                    DisplayAlert("Error", "Please select an account type", "OK");


                    Debug.WriteLine("clicked");

                }
            }
            else
            {
                DisplayAlert("Error", "Please fill the  all the entries below", "OK");

            }


            clear();
           

        }


        // behöver jag ens förklara den här metoden?
        public void clear()
        {
            userPassword.Text = string.Empty;
            userName.Text = string.Empty;
            AccountTypePicker.SelectedItem = null;
        }

        // om du inte förstår den här metoden så är det nog bäst att du slutar läsa här
        public void Entrylock()
        {
            userPassword.IsEnabled = false;
            userName.IsEnabled = false;
            AccountTypePicker.IsEnabled = false;
        }

    }


}
