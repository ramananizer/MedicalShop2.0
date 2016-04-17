using DataContracts;
using PharmacyService;
using StockTraderRI.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace StockTraderRI.DataService
{
    [Export(typeof(IDataService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class DataService : IDataService
    {
        public T GetResult<T>(string methodName, object[] inputParams)
        {
            T result = default(T);
            Thread th = new Thread(
                () =>
                {
                    ChannelFactory<IPharmacyService> factory = CreateChannelFactory();
                    IPharmacyService proxy = factory.CreateChannel();
                    List<Type> inputTypes = new List<Type>();
                    if (inputParams != null && inputParams.Count() > 0)
                    {
                        inputParams.ToList().ForEach(x => inputTypes.Add(x.GetType()));
                        result = (T)proxy.GetType().GetMethod(methodName).Invoke(proxy, inputTypes.ToArray());
                    }
                    else
                    {
                        result = (T)proxy.GetType().GetMethod(methodName).Invoke(proxy, null);
                        
                    }

                    factory.Close();
                });
            th.IsBackground = true;
            th.Start();
            th.Join();
            return result;
        }

        private ChannelFactory<IPharmacyService> CreateChannelFactory()
        {
            ChannelFactory<IPharmacyService> factory = null;
            EndpointAddress address = new EndpointAddress("net.pipe://localhost/PharmacyService");
            Binding binding = new NetNamedPipeBinding();
            factory = new ChannelFactory<IPharmacyService>(binding, address);
            return factory;
        }
    }
}
