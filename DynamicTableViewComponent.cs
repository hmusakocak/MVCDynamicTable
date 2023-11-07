
public class DynamicTableViewComponent : ViewComponent
{       
    public IViewComponentResult Invoke(Tuple<object, List<object>> tuple)
    {
        return View(tuple);
    }
}
