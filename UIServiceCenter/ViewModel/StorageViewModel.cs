using DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UIServiceCenter.Model;

namespace UIServiceCenter.ViewModel
{
    public class StorageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private IMainWindowsCodeBehind _MainCodeBehind;

        public StorageViewModel(IMainWindowsCodeBehind codeBehind)
        {
            if (codeBehind == null) throw new ArgumentNullException(nameof(codeBehind));

            _MainCodeBehind = codeBehind;
        }
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        /// <summary>
        /// Все клиенты
        /// </summary>
        private List<StorageModel> allSpareParts = DataWorker.GetStorage();
        public List<StorageModel> AllSpareParts
        {
            get { return allSpareParts; }
            set
            {
                allSpareParts = value;
                NotifyPropertyChanged("AllSpareParts");
            }
        }

        /// <summary>
        /// Все типы запчастей
        /// </summary>       
        private List<TypeSparePart> allTypes = DataWorker.GetAllTypeSPWithAll();
        public List<TypeSparePart> AllTypes
        {
            get { return allTypes; }
            set
            {
                allTypes = value;
                NotifyPropertyChanged("AllTypes");
            }
        }
    }
}
