using Entity;
using Semana6_.Net.Models;
using Semana6_.Net.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Semana6_.Net.ViewModels
{
    public class ListaCategoriaViewModel : ViewModelBase
    {
        
        private readonly static ListaCategoriaViewModel _instance = new ListaCategoriaViewModel();
        public static ListaCategoriaViewModel Instance
        {
            get
            {
                return _instance;
            }
        }

        public Categoria _SelectedCategoria;
        public Categoria SelectedCategoria
        {
            get { return _SelectedCategoria; }
            set
            {
                if (_SelectedCategoria != value)
                {
                    _SelectedCategoria = value;

                    //Console.WriteLine(_SelectedCategoria);
                    
                    if (_SelectedCategoria != null)
                    {
                        ManCategoria window = new ManCategoria(_SelectedCategoria);
                        window.ShowDialog();
                    }

                    OnPropertyChanged();
                }
            }
        }

    public ObservableCollection<Categoria> _Categorias;
        public ObservableCollection<Categoria> Categorias
        {
            get { return _Categorias; }
            set
            {
                if (Categorias != value)
                {
                    _Categorias = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand NuevoCommand { get; set; }
        public ICommand ConsultarCommand { get; set; }

        public ListaCategoriaViewModel()
        {
            Categorias = new CategoriaModel().Categorias;
            NuevoCommand = new RelayCommand<Window>(param => Abrir());
            ConsultarCommand = new RelayCommand<object>(o => { Categorias = (new CategoriaModel()).Categorias; });
        }
        
        void Abrir()
        {
            ManCategoria window = new ManCategoria(new Categoria());
            window.Show();
        }
    }
}
