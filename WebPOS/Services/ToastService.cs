using WebPOS.Helpers;

namespace WebPOS.Services
{
    public class ToastService
    {
        public AppToast? Toast { get; set; }

        public async Task Success(string message)
            => await Toast!.ShowSuccess(message);

        public async Task Error(string message)
            => await Toast!.ShowError(message);

        public async Task Warning(string message)
            => await Toast!.ShowWarning(message);
    }
}
