using Microsoft.AspNetCore.Mvc;

namespace TextFilesMvc;

public class FileController : Controller
{
  private readonly ILogger<FileController> _logger;
  private readonly IWebHostEnvironment _env;

  public FileController(ILogger<FileController> logger, IWebHostEnvironment env)
  {
      _logger = logger;
      _env = env;
  }

  public IActionResult Index()
  {
    var path = Path.Combine(_env.ContentRootPath, "TextFiles");
    string[] files = Directory.GetFiles(path);
    ViewBag.FileName = files.Select(f => Path.GetFileNameWithoutExtension(f)).ToArray();
    //without extention

    return View();
  }
  
  public IActionResult Content(string id)
  {
    var path = Path.Combine(_env.ContentRootPath, "TextFiles", id + ".txt");
    ViewBag.Content = System.IO.File.ReadAllText(path);

    return View();
  }
}
