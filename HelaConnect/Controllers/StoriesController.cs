using HelaConnectApp.Data.Models;
using HelaConnectApp.Data;
using Microsoft.AspNetCore.Mvc;
using HelaConnect.ViewModels.Stories;
using Microsoft.EntityFrameworkCore;

namespace HelaConnect.Controllers
{
    public class StoriesController : Controller
    {
        private readonly AppDbContext _context;
        public StoriesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index()
        {
            var allStories = await _context.Stories.Include(s => s.User).ToListAsync();
            return View(allStories);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStory(StoryVM storyVM)
        {
            int loggedInUserId = 1;
            var newStory = new Story
            {
                DateCreated = DateTime.UtcNow,
                IsDeleted = false,
                UserId = loggedInUserId
            };
            //Check and save the image
            if (storyVM.Image != null && storyVM.Image.Length > 0)
            {
                string rootFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                if (storyVM.Image.ContentType.Contains("image"))
                {
                    string rootFolderPathImages = Path.Combine(rootFolderPath, "images/stories");
                    Directory.CreateDirectory(rootFolderPathImages);
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(storyVM.Image.FileName);
                    string filePath = Path.Combine(rootFolderPathImages, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                        await storyVM.Image.CopyToAsync(stream);
                    //Set the URL to the newPost object
                    newStory.ImageUrl = "/images/stories/" + fileName;
                }
            }
            await _context.Stories.AddAsync(newStory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
