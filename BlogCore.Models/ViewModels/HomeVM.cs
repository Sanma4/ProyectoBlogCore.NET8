using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> slider { get; set; }

        public IEnumerable<Articulo> listArticulo { get; set; }

        //Pagina inicio

        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
    }
}
