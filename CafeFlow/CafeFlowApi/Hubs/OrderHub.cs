using Microsoft.AspNetCore.SignalR;

namespace CafeFlowApi.Hubs
{
    public class OrderHub : Hub
    {
        public async Task SendOrderUpdate(int orderId, string isim, int masaNo, string telefon, string aciklama, decimal toplamTutar, DateTime siparisTarihi, string durum)
        {
            await Clients.All.SendAsync("ReceiveOrderUpdate", orderId, isim, masaNo, telefon, aciklama, toplamTutar, siparisTarihi, durum);
        }
    }
}