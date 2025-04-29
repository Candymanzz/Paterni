using System;

namespace z2code
{
    // Абстрактная фабрика лекарственных препаратов
    public abstract class MedicineFactory
    {
        public abstract Medicine CreateMedicine();
    }

    // Конкретные фабрики для каждого типа лекарств
    public class AntibioticFactory : MedicineFactory
    {
        public override Medicine CreateMedicine()
        {
            return new Antibiotic();
        }
    }

    public class PainkillerFactory : MedicineFactory
    {
        public override Medicine CreateMedicine()
        {
            return new Painkiller();
        }
    }

    public class VitaminFactory : MedicineFactory
    {
        public override Medicine CreateMedicine()
        {
            return new Vitamin();
        }
    }
}
