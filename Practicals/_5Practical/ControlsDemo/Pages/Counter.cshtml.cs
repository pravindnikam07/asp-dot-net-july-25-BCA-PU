using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ControlsDemo.Pages
{
  public class CounterModel : PageModel
  {
    [TempData]
    public int Count { get; set; }

    public void OnGet()
    {
      Count = 0;
    }

    public void OnPost(string action)
    {
      if (action == "increment")
        Count++;
      if (action == "decrement")
        Count--;
    }
  }
}
