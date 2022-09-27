using StretchCeiling.Service;
using StretchCeiling.View.Pages;

namespace StretchCeiling;

public partial class AppShell : Shell
{
    // instead of DB
    private static OrderService orderService;

    public AppShell()
	{
		InitializeComponent();
        InitiaalizeOrders();

        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(ListComponentsPage), typeof(ListComponentsPage));
        Routing.RegisterRoute(nameof(ListOrdersPage), typeof(ListOrdersPage));
        Routing.RegisterRoute(nameof(OrderPage), typeof(OrderPage));
        Routing.RegisterRoute(nameof(ComponentPage), typeof(ComponentPage));
        Routing.RegisterRoute(nameof(BuilderPage), typeof(BuilderPage));
        Routing.RegisterRoute(nameof(EditorSegmentPage), typeof(EditorSegmentPage));
        Routing.RegisterRoute(nameof(InfoPage), typeof(InfoPage));
    }

    public static OrderService OrderService { get => orderService; set => orderService = value; }

    private void InitiaalizeOrders()
    {
        OrderService = new OrderService();
        //Orders = new ObservableCollection<Order>
        //{
        //    new Order
        //    {
        //        Address = "Samara",
        //        CallNumber = 789654321,
        //        DateTime = DateTime.Now,
        //        Cillings = new ObservableCollection<Ceiling>
        //        {
        //            new Ceiling
        //            {
        //                Price = 1000
        //            }

        //        }
        //    }
        //};
    }
}
