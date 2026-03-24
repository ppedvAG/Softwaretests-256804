using System.Windows;

namespace M009_WPF;

public partial class MainWindow : Window
{
	public int Counter = 0;

	public MainWindow()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Counter++;
		Output.Text = $"Counter: {Counter}";
	}
}