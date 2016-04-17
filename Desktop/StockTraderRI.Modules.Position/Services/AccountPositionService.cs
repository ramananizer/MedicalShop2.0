// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using StockTraderRI.Infrastructure.Interfaces;
using StockTraderRI.Infrastructure.Models;
using StockTraderRI.Modules.Position.Properties;
using System.ComponentModel.Composition;
using System.ServiceModel;
using PharmacyService;
using System.ServiceModel.Channels;
using System.Threading;
using DataContracts;
using Microsoft.Practices.ServiceLocation;

namespace StockTraderRI.Modules.Position.Services
{
    [Export(typeof(IAccountPositionService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class AccountPositionService : IAccountPositionService
    {
        List<AccountPosition> _positions = new List<AccountPosition>();
        List<Medicine> _medicines = new List<Medicine>();
        public AccountPositionService()
        {
            //ServiceHost host = new ServiceHost(typeof(PharmacyService.PharmacyService));
            //host.Open();
            InitializePositions();
        }

        #region IAccountPositionService Members

        public event EventHandler<AccountPositionModelEventArgs> Updated = delegate { };

        public IList<AccountPosition> GetAccountPositions()
        {
            return _positions;
        }

        public IList<Medicine> GetMedicines()
        {
            return _medicines;
        }
        #endregion

        private void InitializePositions()
        {
            //using (var sr = new StringReader(Resources.AccountPositions))
            //{
            //    XDocument document = XDocument.Load(sr);
            //    _positions = document.Descendants("AccountPosition")
            //        .Select(
            //        x => new AccountPosition(x.Element("TickerSymbol").Value,
            //                                 decimal.Parse(x.Element("CostBasis").Value, CultureInfo.InvariantCulture),
            //                                 long.Parse(x.Element("Shares").Value, CultureInfo.InvariantCulture)))
            //        .ToList();
            //}
            //Thread th = new Thread(() =>
            //{
            //    EndpointAddress address = new EndpointAddress("net.pipe://localhost/PharmacyService");
            //    Binding binding = new BasicHttpBinding();

            //    ChannelFactory<IPharmacyService> factory = new ChannelFactory<IPharmacyService>(binding, address);

            //    IPharmacyService proxy = factory.CreateChannel();
            //    List<Medicine> medicines = proxy.GetMedicinesList();
            //    factory.Close();
            //});
            //th.IsBackground = true;
            //th.Start();
            //th.Join();
            _medicines = ServiceLocator.Current.GetInstance<IDataService>().GetResult<List<Medicine>>("GetMedicinesList", null);
        }
    }
}
