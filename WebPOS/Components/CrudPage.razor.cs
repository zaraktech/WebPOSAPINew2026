using Microsoft.AspNetCore.Components;
using WebPOS.ColumnDefinations;

namespace WebPOS.Components;

public partial class CrudPage<TEntity>
    where TEntity : class, new()
{
    private enum ViewMode
    {
        List,
        Form
    }

    private ViewMode CurrentView = ViewMode.List;

    [Parameter]
    public string Title { get; set; } = string.Empty;

    [Parameter]
    public List<GridColumnDefinition> Columns { get; set; } = new();

    [Parameter]
    public List<TEntity> Items { get; set; } = new();

    [Parameter]
    public TEntity CurrentItem { get; set; } = new();

    [Parameter]
    public EventCallback<TEntity> CurrentItemChanged { get; set; }

    [Parameter]
    public Func<TEntity, int> GetId { get; set; } = default!;

    [Parameter]
    public EventCallback<int> OnDelete { get; set; }

    [Parameter]
    public RenderFragment<TEntity> FormTemplate { get; set; } = default!;

    private async Task ShowAdd()
    {
        CurrentItem = new TEntity();

        await CurrentItemChanged.InvokeAsync(CurrentItem);

        CurrentView = ViewMode.Form;
    }

    private async Task EditItem(TEntity item)
    {
        CurrentItem = item;

        await CurrentItemChanged.InvokeAsync(CurrentItem);

        CurrentView = ViewMode.Form;
    }

    private async Task DeleteItem(TEntity item)
    {
        await OnDelete.InvokeAsync(GetId(item));
    }

    private void BackToList()
    {
        CurrentView = ViewMode.List;
    }

    public void Refresh()
    {
        CurrentView = ViewMode.List;

        StateHasChanged();
    }
}