using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosque.Modelos.ViewModels
{
    public class ZoologoVM
    {
        public Zoologo Zoologo { get; set; }

        public IEnumerable<SelectListItem> PersonalLista { get; set; }
        
    }
}
