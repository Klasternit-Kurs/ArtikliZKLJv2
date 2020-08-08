using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArtikliZKLJv2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ObservableCollection<Artikal> Art = new ObservableCollection<Artikal>();
		public MainWindow()
		{
			InitializeComponent();
			Artikal a = new Artikal();
			a.Naziv = "Prvi";
			a.Ucena = 20;
			a.Marza = 50;
			Art.Add(a);
			a = new Artikal();
			a.Naziv = "Drugi";
			a.Ucena = 100;
			a.Marza = 25;
			Art.Add(a);

			dg.ItemsSource = Art;
		}

		private void Promena(object sender, SelectionChangedEventArgs e)
		{
			DataContext = dg.SelectedItem;
		}
	}

	public class Artikal : INotifyPropertyChanged
	{
		private string _naziv;
		public string Naziv 
		{ 
			get => _naziv; 
			set
			{
				_naziv = value;
				string[] arg = { "Naziv" };
				OnChange(arg);
			}
		}
		private decimal _ucena;
		public decimal Ucena 
		{ 
			get => _ucena; 
			set
			{
				_ucena = value;
				string[] arg = { "Ucena", "IzlCena" };
				OnChange(arg);
			}
		}
		private int _marza;
		public int Marza 
		{ 
			get => _marza; 
			set
			{
				_marza = value;

				string[] arg = { "Marza", "IzlCena" };
				OnChange(arg);
			}
		}

		public decimal IzlCena
		{
			get => Ucena * ((decimal)Marza / 100 + 1);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnChange(string[] SveStoSeMenja)
		{
			foreach (string prop in SveStoSeMenja)
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}
	}
}
