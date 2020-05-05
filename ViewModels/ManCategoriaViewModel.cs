using Entity;
using Semana6_.Net.Models;
using Semana6_.Net.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Semana6_.Net.ViewModels
{
    public class ManCategoriaViewModel : ViewModelBase
    {
		#region propiedades
		int _ID;

		public int ID
		{
			get { return _ID; }
			set
			{
				if (_ID != value)
				{
					_ID = value;
					OnPropertyChanged();
				}
			}
		}

		string _Nombre;

		public string Nombre
		{
			get { return _Nombre; }
			set
			{
				if (_Nombre != value)
				{
					_Nombre = value;
					OnPropertyChanged();
				}
			}
		}

		string _Descripcion;

		public string Descripcion
		{
			get { return _Descripcion; }
			set
			{
				if (_Descripcion != value)
				{
					_Descripcion = value;
					OnPropertyChanged();
				}
			}
		}
		#endregion

		public ICommand GrabarCommand { get; set; }
		public ICommand CerrarCommand { get; set; }
		public ICommand EliminarCommand { get; set; }


		public ManCategoriaViewModel(Categoria categoria)
		{
			if (categoria != null){
				ID = categoria.IdCategoria;
				Nombre = categoria.NombreCategoria;
				Descripcion = categoria.Descripcion;
			}

			EliminarCommand = new RelayCommand<Window>(o =>
			{
				if (ID > 0)
				{
					new CategoriaModel().Eliminar(ID);
				}
				Cerrar(o);
			});

			GrabarCommand = new RelayCommand<Window>(
				o =>
				{
					if (ID > 0)
					{
						new CategoriaModel().Actualizar(new Entity.Categoria
						{
							IdCategoria = ID,
							NombreCategoria = Nombre,
							Descripcion = Descripcion
						});
						
					} else
					{
						new CategoriaModel().Insertar(new Entity.Categoria
						{
							NombreCategoria = Nombre,
							Descripcion = Descripcion
						});
					}

					Cerrar(o);

				});

			CerrarCommand = new RelayCommand<Window>(param =>
		   {
			   Cerrar(param);
		   });
		}

		void Cerrar (Window window)
		{
			window.Close();
		}

	}
}
