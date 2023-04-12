using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace UTFPR_Gamificacao_V1.RazorPages.Pages.Mesas
{
    public class Delete : PageModel
    {
        private readonly ILogger<Delete> _logger;

        public Delete(ILogger<Delete> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}