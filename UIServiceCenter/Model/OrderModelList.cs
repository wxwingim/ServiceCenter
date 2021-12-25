using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace UIServiceCenter.Model
{
    public class OrderModelList
    {
        public OrderModelList(Work_order work_Order)
        {
            numOrder = work_Order.numOrder;
            durationQuarantee = work_Order.durationQuarantee;
            statusRepair = work_Order.statusRepair;
            statusPaymnt = work_Order.statusPaymnt;
            statusDelivery = work_Order.statusDelivery;
            quarantee = DataWorker.GetAdmission_For_Repair(work_Order.num_admission).quarantee;
            date_admission = DataWorker.GetAdmission_For_Repair(work_Order.num_admission).date_admission;
            defect = DataWorker.GetCustomer_device(DataWorker.GetAdmission_For_Repair(work_Order.num_admission).idCustDev).defect;
            nameModel = DataWorker.GetDevice_model(DataWorker.GetCustomer_device(DataWorker.GetAdmission_For_Repair(work_Order.num_admission).idCustDev).keyModel).nameModel;
        }

        public int numOrder { get; set; }

        public int durationQuarantee { get; set; }

        public string statusRepair { get; set; }

        public bool statusPaymnt { get; set; }

        public bool statusDelivery { get; set; }

        public bool quarantee { get; set; }

        public DateTime date_admission { get; set; }

        public string defect { get; set; }

        public string nameModel { get; set; }

    }
}
