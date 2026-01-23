using Microsoft.AspNetCore.Components;
using WebPOS.Models;
using WebPOS.Services;

namespace WebPOS.Pages
{
    public partial class Customers
    {
        private enum CustomerView { List, Form }
        private CustomerView currentView = CustomerView.List;

        private List<Customer> customers;
        private Customer customer = new Customer();
        private bool isLoading = false;

        [Parameter] public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            customers = null;
            await LoadCustomers();
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Id > 0)
            {
                customer = await CustomerService.GetCustomer(Id) ?? new Customer();
                currentView = CustomerView.Form;
            }
        }

        private async Task LoadCustomers()
        {
            customers = await CustomerService.GetCustomers();
            StateHasChanged();
            await Task.Delay(100);
            // await JS.InvokeVoidAsync("initializeDataTable", "#customersTable");
        }

        private void ShowAddForm()
        {
            customer = new Customer();
            currentView = CustomerView.Form;
            NavigationManager.NavigateTo("/customers/new");
        }

        private void ShowEditForm(int id)
        {
            Id = id;
            NavigationManager.NavigateTo($"/customers/edit/{id}");
        }

        private void ShowList()
        {
            currentView = CustomerView.List;
            NavigationManager.NavigateTo("/customers");
        }

        private async Task HandleValidSubmit()
        {
            isLoading = true;
            try
            {
                if (customer.Id == 0)
                {
                    bool status = await CustomerService.AddCustomer(customer);
                    if (status == true)
                    {
                        await ToastService.Success("Customer added successfully.");
                        await LoadCustomers();

                        ShowList();
                    }
                    else
                    {

                        await ToastService.Warning("Customer already exists.");
                        ShowAddForm();
                    }
                }

                else
                {
                    bool status = await CustomerService.UpdateCustomer(customer);
                    if (status == true)
                    {

                        await ToastService.Success("Customer updated successfully.");
                        await LoadCustomers();

                        ShowList();
                    }
                    else
                    {

                        await ToastService.Warning("Customer already exists.");
                        ShowAddForm();
                    }
                }


            }
            catch (Exception ex)
            {
                await ErrorLogger.LogAsync(ex.Message + "-" + ex.InnerException?.Message);
            }
            finally
            {
                isLoading = false;
            }
        }

        private async Task DeleteCustomer(int id)
        {
            bool confirmed = await DialogService.ConfirmAsync("Confirm Delete", "Are you sure you want to delete this customer?");
            if (confirmed)
            {
                await CustomerService.DeleteCustomer(id);

                await ToastService.Success("Customer deleted successfully.");
                await LoadCustomers();
            }
        }
    }
}