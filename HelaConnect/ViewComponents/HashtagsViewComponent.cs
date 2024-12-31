using Microsoft.AspNetCore.Mvc;

namespace HelaConnect.ViewComponents
{
    public class HashtagsViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
