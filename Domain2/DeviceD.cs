namespace Domain2
{
    public class DeviceD
    {
        string model;
        string defect;
        string equipment;
        string mechanicalDamage;
        string type;
        PersonD CustomerD;

        public string Model { get { return model; } set { model = value; } }
        public string Defect { get { return defect; } set { defect = value; } }
        public string Equipment { get { return equipment; } set { equipment = value; } }
        public string MechanicalDamage { get { return mechanicalDamage; } set { mechanicalDamage = value; } }
        public string Type { get { return type; } set { type = value; } }

        public DeviceD(string model, string defect, string equipment, string mechanicalDamage, string type, PersonD customerD)
        {
            this.model = model;
            this.defect = defect;
            this.equipment = equipment;
            this.mechanicalDamage = mechanicalDamage;
            this.type = type;
            this.CustomerD = customerD;
        }

        public bool CheckInput()
        {
            bool result = false;
            if (model != "" && defect != "" && type != "") result = true;
            return result;
        }
    }
}
