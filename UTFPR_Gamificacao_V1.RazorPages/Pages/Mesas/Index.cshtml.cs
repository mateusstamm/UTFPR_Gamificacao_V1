using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using UTFPR_Gamificacao_V1.RazorPages.Models;
using UTFPR_Gamificacao_V1.RazorPages.Data;
using Microsoft.EntityFrameworkCore;

namespace UTFPR_Gamificacao_V1.RazorPages.Pages.Mesas
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly AppDbContext _context;

        public Index(ILogger<Index> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<MesaModel>? Mesas { get; set; }

        /*public async Task OnGetAsync()
        {
            Mesas = await _context.Mesas.ToListAsync();
        }*/
    }
}