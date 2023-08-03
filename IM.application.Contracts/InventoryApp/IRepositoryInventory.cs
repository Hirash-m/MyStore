using _0_FrameWork.Domain;
using IM.application.Contracts.InventoryApp;
using InventoryManagement.Domain.InventoryAgg;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.application.Contracts.Inventory
{
    public interface IRepositoryInventory :IRepository<Inventory, int>
    {
        EditInventory GetDetails(int id);
        In
    }
}
