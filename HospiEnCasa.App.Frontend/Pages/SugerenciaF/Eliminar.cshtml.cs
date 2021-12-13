using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Frontend.Pages.SugerenciaF
{
    public class EliminarModel : PageModel
    {
        private readonly IRepositorioSugerenciaCuidado _repoSugerencia;
        public SugerenciaCuidado sugerencia {get; set;}
        public  EliminarModel (IRepositorioSugerenciaCuidado repoSugerencia)
        {
            this._repoSugerencia=repoSugerencia;
        }
        public IActionResult OnGet(int id)
        {
            sugerencia=_repoSugerencia.GetSugerenciaCuidado(id);
            if(sugerencia==null)
            {
                return NotFound();
            }else{
                return Page();
            }
        }
        public IActionResult OnPost(int id)
        {
            _repoSugerencia.DeleteSugerenciaCuidado(id);
            return RedirectToPage ("ListaSugerencia");
        }
    }
}
