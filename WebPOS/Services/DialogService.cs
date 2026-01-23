using MudBlazor;

namespace WebPOS.Services
{
    public class DialogService 
    {
        private TaskCompletionSource<bool>? _tcs;

        // __define-ocg__
        public Task<bool> ConfirmAsync(string title, string message)
        {
            _tcs = new TaskCompletionSource<bool>();
            OnShow?.Invoke(title, message);
            return _tcs.Task;
        }

        public void Confirm()
            => _tcs?.TrySetResult(true);

        public void Cancel()
            => _tcs?.TrySetResult(false);

        public event Action<string, string>? OnShow;
    }

}
