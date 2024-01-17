using Microsoft.AspNetCore.Mvc;
using BanVali.Models.FE; // Namespace của model
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

public class MenuViewComponent : ViewComponent
{
    private readonly QlbanVaLiContext _context; // Thay thế YourDbContext bằng tên DbContext của bạn

    public MenuViewComponent(QlbanVaLiContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = _context.TLoaiSps.ToList();
        return View(categories);
    }
}
