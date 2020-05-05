using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana6_.Net.Models
{
    public class CategoriaModel
    {
        public ObservableCollection<Categoria> Categorias { get; set; }

        public CategoriaModel()
        {
            var lista = (new BCategoria()).Get(0);
            Categorias = new ObservableCollection<Categoria>(lista);
        }

        public bool Insertar(Categoria categoria)
        {
            return (new BCategoria()).Insert(categoria);
        }

        public bool Actualizar(Categoria categoria)
        {
            return (new BCategoria()).Update(categoria);
        }

    }
}
