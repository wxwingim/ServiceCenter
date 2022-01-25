using DataBase;
using System.Collections.Generic;
using System.Linq;

namespace Domain2
{
    public class OrderD
    {
        List<ResourceD> resources;
        List<Purchase> actualPurchase;
        AdmissionD admission;
        string statusRepair;
        bool statusPayment;
        //bool statusDelivery;

        //public AdmissionD Admission { get; set; }
        public string StatusRepair { get { return statusRepair; } set { statusRepair = value; } }

        public OrderD(List<ResourceD> resources, List<Purchase> purchases)
        {
            this.resources = resources;
            actualPurchase = purchases;
        }
        public OrderD(List<ResourceD> resources, List<Purchase> purchases, string statusRepair, bool statusPayment)
        {
            actualPurchase = purchases;
            this.resources = resources;
            this.statusRepair = statusRepair;
            this.statusPayment = statusPayment;
        }

        public List<ResourceD> Resources
        {
            get { return this.resources; }
            set { this.resources = value; }
        }

        public List<Purchase> ActualPurchase
        {
            get { return this.actualPurchase; }
            set { this.actualPurchase = value; }
        }

        public List<ServiceD> Services()
        {
            List<ServiceD> result = new List<ServiceD>();
            foreach (ResourceD resource in this.resources)
            {
                if (resource is ServiceD)
                {
                    result.Add((ServiceD)resource);
                }
            }
            return result;
        }

        public void AddConsumption(ConsumptionD consumptionD)
        {
            UpdatePurchase(consumptionD);
            resources.Add(consumptionD);
        }

        public bool CheckResource(ConsumptionD consumptionD)
        {
            bool result = false;
            foreach (Purchase purchase in this.actualPurchase)
            {
                if (purchase.idSpare == consumptionD.SparePart.idSpare)
                {
                    if (purchase.amount - consumptionD.Amount >= 0)
                    {
                        result = true;
                    }
                    break;
                }
            }
            return result;
        }

        private void UpdatePurchase(ConsumptionD consumptionD)
        {
            actualPurchase.Where(x => x.idSpare == consumptionD.SparePart.idSpare).ToList().ForEach(x => x.amount -= consumptionD.Amount);
        }

        public List<ConsumptionD> Consumptions()
        {
            List<ConsumptionD> result = new List<ConsumptionD>();
            foreach (ResourceD resource in this.resources)
            {
                if (resource is ConsumptionD)
                {
                    result.Add((ConsumptionD)resource);
                }
            }
            return result;
        }

        public string SummOrder()
        {
            int result = 0;

            foreach (ResourceD resource in resources)
            {
                result += resource.Price();
            }
            Money money = new Money();

            return money.IntMoneyToString(result);
        }

        public bool CheckStatuses()
        {
            bool result = false;
            if ((statusRepair == "Готов" || statusRepair == "Выдан") && statusPayment) result = true;
            return result;
        }

        public int GuaranteeOrder()
        {
            int result = 0;

            List<ServiceD> services = Services();
            foreach (ServiceD service in services)
            {
                if (service.Service.guarantee > result)
                {
                    result = service.Service.guarantee;
                }
            }
            return result;
        }
    }
}
