using _0_FrameWork.Application;
using _0_FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.application.Contracts.InventoryApp
{
    public interface IInventoryApplication
    {
        OperationResult Crete(CreateInventory command);
        OperationResult Edit(EditInventory command);
        OperationResult Increase(IncreaseInventory command);
        OperationResult Decrease(List<DecreaseInventory> command);
        EditInventory GetDetails(int id);
        List<InventoryViewModel> Search(InventorySearchModel command);
    }
}
