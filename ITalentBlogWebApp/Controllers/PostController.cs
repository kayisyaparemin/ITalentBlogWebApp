using AutoMapper;
using ITalentBlogWebApp.Models.Entities;
using ITalentBlogWebApp.Models.ViewModels.Posts;
using ITalentBlogWebApp.Repositories.PostRepos;
using ITalentITalentBlogWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace ITalentBlogWebApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IFileProvider _fileProvider;
        private readonly IMapper _mapper;

        public PostController(IPostRepository postRepository,IFileProvider fileProvider,IMapper mapper)
        {
            _postRepository = postRepository;
            _fileProvider = fileProvider;
            _mapper = mapper;
        }
        public IActionResult Index(PostIndexViewModel request = null)
        {
            LoadCategoryNames();

            var (posts, totalCount) = FilteredAndPagedPosts(new PostFilterViewModel()
            {
                categoryName = request.categoryName,
                page = request.page,
                pageSize = request.pageSize,
                query = request.query
            });

            var postList = _mapper.Map<List<PostViewModel>>(posts);
            int totalPage = (int)Math.Ceiling((decimal)totalCount / request.pageSize);
 
            return View(new PostIndexViewModel() { Posts=postList , totalPage = totalPage,page=request.page});
        }

        private (List<Post>, int) FilteredAndPagedPosts(PostFilterViewModel request)
        {
            if (request.categoryName == null && request.query == null)
            {
                var posts = _postRepository.GetPostsWithPaged(request.page, request.pageSize).Item1;
                var totalCount = _postRepository.GetPostsWithPaged(request.page, request.pageSize).Item2;

                return (posts, totalCount);
            }
            if (request.categoryName != null && request.query == null)
            {
                var posts = _postRepository.GetPostsWithPagedFilteredByCategory(request.page, request.pageSize, request.categoryName).Item1;
                var totalCount = _postRepository.GetPostsWithPagedFilteredByCategory(request.page, request.pageSize, request.categoryName).Item2;

                return (posts, totalCount);
            }

            
            if (request.query != null)
            {
                var posts = _postRepository.GetPostsWithPagedFilteredByQuery(request.page, request.pageSize, request.query).Item1;
                var totalCount = _postRepository.GetPostsWithPagedFilteredByQuery(request.page, request.pageSize, request.query).Item2;
                return (posts, totalCount);
            }

            return (null, 0);
        }
        private void LoadCategoryNames()
        {
            var categoryNames = new HashSet<string>();
            _postRepository.GetCategories().ForEach(x=>categoryNames.Add(x.Name));
            ViewBag.categoryNames = categoryNames;  
        }

        public async void SaveImage(IFormFile image,string fileName)
        {
            if (image != null && image.Length > 0)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var imagesDirectory = root.Single(x => x.Name == "pictures");
                var ext = Path.GetExtension(image.FileName);
                var path = Path.Combine(imagesDirectory.PhysicalPath,fileName+ext);
                using var stream = new FileStream(path, FileMode.Create);
                await image.CopyToAsync(stream);
               
            }  
        }

        public IActionResult AnyPostTitle(string Title)
        {
            if (_postRepository.ExistsTitle(Title))
            {
               return Json("This title is already exists");
            }

            return Json(true);        
        }

        public IActionResult CreatePost()
        {
            var categories = _postRepository.GetCategories();
            ViewBag.selectList = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(PostCreateViewModel request)
        {
            if (!ModelState.IsValid)
            {
                var categories = _postRepository.GetCategories();
                ViewBag.selectList = new SelectList(categories, "Id", "Name");
                return View(request);
            }

            var fileName = Guid.NewGuid().ToString();
            SaveImage(request.Image, fileName);
            var post = _mapper.Map<Post>(request);
            post.ImageName = $"{fileName}{Path.GetExtension(request.Image.FileName)}";
            _postRepository.CreatePost(post);
            
            return RedirectToAction("Index");
        }
        public IActionResult DeletePost(int id)
        {
           
                _postRepository.DeletePost(id);
                return RedirectToAction("Index");
        }

        public IActionResult UpdatePost(int id)
        {
            var categories = _postRepository.GetCategories();
            ViewBag.selectList = new SelectList(categories, "Id", "Name");
            var updatePostView = _mapper.Map<PostUpdateViewModel>(_postRepository.GetById(id));
            return View(updatePostView);
        }
        [HttpPost]
        public IActionResult UpdatePost(PostUpdateViewModel request)
        {
            var updatedPost = _mapper.Map<Post>(request);

            if (request.Image != null)
            {
                var fileName = Guid.NewGuid().ToString();
                SaveImage(request.Image, fileName);
                updatedPost.ImageName = $"{fileName}{Path.GetExtension(request.Image.FileName)}";
            }
            _postRepository.UpdatePost(updatedPost);
            return RedirectToAction("Index");
        }
        [Route("Posts/{categoryName}/{id}")]
        public IActionResult PostDeneme(int id,string categoryName)
        {
            var postDeneme = _postRepository.PostsWithCategory().FirstOrDefault(x=>x.Id == id);

            return View(_mapper.Map<PostViewModel>(postDeneme));
        }
    }
}

