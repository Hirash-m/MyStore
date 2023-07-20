using _0_FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBase
    {
        public int ProductId { get; private set; }
        public int UnitPrice { get; private set; }
        public bool InStock { get; private set; }

        public List<OperationInventory> OperationInventory { get; private set; }


        public Inventory(int productId, int unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;

        }
        public int CalculateCurrentStock()
        {
            var plus = OperationInventory.Where(x => x.Operation).Count();
            var minus = OperationInventory.Where(x => !x.Operation).Count();
            return plus - minus;

        }
        public void Incrase(int count, int operatorId, string description)
        {
            var currentCount = CalculateCurrentStock() + count;
            var operation = new OperationInventory(this.ProductId, count, true,
                                            operatorId, currentCount, description, 0, this.Id);
            OperationInventory.Add(operation);
            InStock = currentCount > 0;
        }

        public void Reduce(int count, int operatorId, string description,int orderId)
        {
            var currentCount = CalculateCurrentStock() - count;
            var operation = new OperationInventory(this.ProductId, count, false, operatorId,
                                                    currentCount, description, orderId, this.Id);
            OperationInventory.Add(operation);  
            InStock = currentCount > 0;
        }
    }

    public class OperationInventory
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int Count { get; private set; }
        public bool Operation { get; private set; }
        public int OperatorId { get; private set; }
        public DateTime OperationDate { get; private set; }
        public int CurrentCount { get; private set; }
        public string? Description { get; private set; }
        public int OrderId { get; private set; }
        public Inventory Inventory { get; private set; }
        public int InventoryId { get; private set; }

        public OperationInventory(int productId, int count, bool operation, int operatorId,
                                    int currentCount, string? description,
                                    int orderId, int inventoryId)
        {
            ProductId = productId;
            Count = count;
            Operation = operation;
            OperatorId = operatorId;
            CurrentCount = currentCount;
            Description = description;
            OrderId = orderId;
            InventoryId = inventoryId;
        }
    }
}
