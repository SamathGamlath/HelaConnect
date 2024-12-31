using HelaConnectApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace HelaConnect.ViewComponents
{
    public class StoriesViewComponents : ViewComponent
    {

        private readonly AppDbContext _context;
        public StoriesViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var allStories = await _context.Stories.Include(s => s.User).ToListAsync();
            return View(allStories);
        }
    }
}
