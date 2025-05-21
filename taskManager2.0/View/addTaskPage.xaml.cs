using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using taskManager2._0.Module;
using MyTask = taskManager2._0.Module.Task;
namespace taskManager2._0.View;



public partial class addTaskPage : ContentPage
{
	  public TaskManagerList list ;
	public addTaskPage()
	{
		InitializeComponent();
		list = new TaskManagerList();
	}



    // den här tar in användarens inmatning och skapar en ny task
    public void OnSaveSubmitClicked(object sender, EventArgs e)

    {
        string headline = HeadlineEntry.Text;
		string content = contentEntry.Text;

		if (!string.IsNullOrEmpty(headline) && !string.IsNullOrEmpty(content)) {

            Debug.WriteLine("succesfull" + " " +  headline + " " + content );
            MyTask? newTask = list.CreateTask(headline, content);  

			if (newTask is null) {
                DisplayAlert("Error", "task could not be created", "OK");

            }

            LoadTaskListItem();
            clear();
        }
        else
		{
			DisplayAlert("Error", "please fill in the Entrys", "OK");
        }
        Debug.WriteLine("clicked");
		return;
    }

    // den här metoden tar bort den markerade tasken som användaren vill ta bort
    public void OnDeleteClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var task = button?.BindingContext as MyTask; 

        if (task != null)
        {
            list.taskList.Remove(task);
            LoadTaskListItem();
        }
    }

    // den här metoden tar in användarens inmatning och redigerar tasken
    public async void OnEditClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var task = button?.BindingContext as MyTask;

        if (task != null)
        {
            
            string newHeadline = await DisplayPromptAsync("Edit Headline", "Enter new headline:", initialValue: task.headline);
            string newContent = await DisplayPromptAsync("Edit Content", "Enter new task content:", initialValue: task.content);

            if (!string.IsNullOrWhiteSpace(newHeadline) && !string.IsNullOrWhiteSpace(newContent))
            {
                task.headline = newHeadline;
                task.content = newContent;
                LoadTaskListItem(); 
            }
            else
            {
                await DisplayAlert("Error", "Headline and Content cannot be empty.", "OK");
            }
        }
    }


    // den här metoden laddar tasklistan och visar den i listviewen
    public void LoadTaskListItem()
	{

        TaskListView.ItemsSource = null;
        TaskListView.ItemsSource = list.taskList;

    }

    // den här metoden tar bort texten i inmatningsfälten
    public void clear()
    {
        HeadlineEntry.Text = string.Empty;
        contentEntry.Text = string.Empty;
    }
}