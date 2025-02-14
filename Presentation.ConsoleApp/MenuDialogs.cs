using Business.Services;

namespace Presentation.ConsoleApp;

public class MenuDialogs(CustomerService customerService, UserService userService, ProjectService projectService, ProductService productService, StatusTypeService statusTypeService)
{
    private readonly CustomerService _customerService = customerService;
    private readonly UserService _userService = userService;
    private readonly ProjectService _projectService = projectService;
    private readonly ProductService _productService = productService;
    private readonly StatusTypeService _statusTypeService = statusTypeService;

    public Task MenuOptions()
    {
        while (true)
        {
            Console.WriteLine("MENU OPTIONS");
            Console.ReadKey();
        }
    }
}
