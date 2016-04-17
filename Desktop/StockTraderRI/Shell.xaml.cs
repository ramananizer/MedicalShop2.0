// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Windows;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.ServiceModel;
using System.ServiceModel.Channels;
using PharmacyService;
using DataContracts;
using StockTraderRI.Infrastructure.Interfaces;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;

namespace StockTraderRI
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>   
    [Export]
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the ViewModel.
        /// </summary>
        /// <remarks>
        /// This set-only property is annotated with the <see cref="ImportAttribute"/> so it is injected by MEF with
        /// the appropriate view model.
        /// </remarks>
        [Import]
        [SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly", Justification = "Needs to be a property to be composed by MEF")]
        ShellViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }

        private void Window_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Thread th = new Thread(() =>
            //{
            //    EndpointAddress address = new EndpointAddress("net.pipe://localhost/PharmacyService");
            //    Binding binding = new NetNamedPipeBinding();

            //    ChannelFactory<IPharmacyService> factory = new ChannelFactory<IPharmacyService>("");

            //    IPharmacyService proxy = factory.CreateChannel();
            //    List<Medicine> medicines = proxy.GetMedicinesList();
            //    factory.Close();
            //});
            //th.IsBackground = true;
            //th.Start();
            //th.Join();
            //object obj = ServiceLocator.Current.GetInstance<IDataService>().GetResult<List<Medicine>>("GetMedicinesList", null);
        }
    }
}
