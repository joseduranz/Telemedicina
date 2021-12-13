using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Persistencia;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Frontend.Pages.SignoVitalF
{
    public class ActualizarModel : PageModel
    {
        private readonly IRepositorioSignoVital _repoSigno;

        public SignoVital signo {get; set;}

        public  ActualizarModel (IRepositorioSignoVital repoSigno)
        {
            this._repoSigno=repoSigno;
        }
        public IActionResult OnGet(int id)
        {
            signo=_repoSigno.GetSignoVital(id);
            if(signo==null)
            {
                return NotFound();
            }else{
                return Page();
            }
        }
        public IActionResult OnPost(SignoVital signo)
        {
            _repoSigno.UpdateSignoVital(signo);
            return RedirectToPage ("ListaSignosVitales");
        }
    }
}
