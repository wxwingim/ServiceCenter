using DataBase;
using System;

namespace UIServiceCenter.Model
{
    public class OrderModel
    {
        public OrderModel(WorkOrder work_Order)
        {
            numOrder = work_Order.numOrder;
            statusRepair = DataWorker.GetStatusRepair(work_Order.StatusId).StatusName;
            statusPaymnt = work_Order.statusPaymnt;
            statusDelivery = work_Order.statusDelivery;
            quarantee = DataWorker.GetAdmission_For_Repair(work_Order.num_admission).quarantee;
            date_admission = DataWorker.GetAdmission_For_Repair(work_Order.num_admission).date_admission;
            defect = DataWorker.GetCustomer_device(DataWorker.GetAdmission_For_Repair(work_Order.num_admission).idCustDev).defect;
            nameModel = DataWorker.GetCustomer_device(DataWorker.GetAdmission_For_Repair(work_Order.num_admission).idCustDev).model;
            idCustom = DataWorker.GetCustomer_device(DataWorker.GetAdmission_For_Repair(work_Order.num_admission).idCustDev).idCustom;
        }

        public int idCustom { get; set; }

        public int numOrder { get; set; }

        public string statusRepair { get; set; }

        public bool statusPaymnt { get; set; }

        public bool statusDelivery { get; set; }

        public bool quarantee { get; set; }

        public DateTime date_admission { get; set; }

        public string defect { get; set; }

        public string nameModel { get; set; }

    }
}
