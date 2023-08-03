using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM.application.Contracts.InventoryApp
{
    public class IncreaseInventory
    {
        public int InventoryId { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
    }

    public class DecreaseInventory
    {
        public int ProdictId { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public int OrderId { get; set; }
    }


    public class CreateInventory
    {
        public int ProductId { get; set; }
        public int UnitPrice { get; set; }
    }

    public class EditInventory : CreateInventory
    {
        public int InventoryId { get; set; }
    }

    public class InventoryViewModel
    {
        public int InventoryId { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int UnitPrice { get; set; }
        public bool InStock { get; set; }
        public int CorrentCount { get; set; }
    }

    public class InventorySearchModel

    {
        public int ProductId { get; set; }
        public bool InStock { get; set; }

    }
}
