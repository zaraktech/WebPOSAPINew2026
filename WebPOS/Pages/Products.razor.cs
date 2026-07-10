using Microsoft.AspNetCore.Components;
using Shared.Models;
using WebPOS.ColumnDefinations;
using WebPOS.Components;
using WebPOS.Services;

namespace WebPOS.Pages;

public partial class Products
{
    [Inject]
    public ItemMasterService ProductService { get; set; } = default!;

    private CrudPage<ItemMaster>? crudPage;

    private List<ItemMaster> itemMasters = new();

    private ItemMaster itemMaster = new();
    private int TotalRecords;
    private List<GridColumnDefinition> columns = new()
    {
        new()
        {
            Field = nameof(itemMaster.Item),
            Header = "Product Name",
            Width = "250"
        },
        new()
        {
            Field = nameof(ItemMaster.DisPercent),
            Header = "Discount",
            Width = "120"
        },
        new()
        {
            Field = nameof(ItemMaster.ReOrder),
            Header = "Reorder",
            Width = "120"
        }
    };



    protected override async Task OnInitializedAsync()
    {
       

       var items=   await ProductService.GetProducts();
        itemMasters=items.OrderByDescending(x => x.ItemId).ToList();
        StateHasChanged();
     
    }

    private Task OnCurrentItemChanged(ItemMaster item)
    {
        itemMaster = item;
        return Task.CompletedTask;
    }

    private async Task DeleteProduct(int id)
    {
        await ProductService.DeleteProduct(id);

        var response = await ProductService.GetProduct(id);
       
    }

    private async Task HandleValidSubmit(ItemMaster item)

    {
        if (item.ItemId == 0)
            await ProductService.AddProduct(item);
        else
            await ProductService.UpdateProduct(item);

        var response = await ProductService.GetProducts();
     

        crudPage?.Refresh();
    }
}