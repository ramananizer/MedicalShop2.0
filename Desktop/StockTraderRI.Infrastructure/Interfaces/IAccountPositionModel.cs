// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StockTraderRI.Infrastructure.Models;
using DataContracts;

namespace StockTraderRI.Infrastructure.Interfaces
{
    public interface IAccountPositionService
    {
        event EventHandler<AccountPositionModelEventArgs> Updated;
        IList<AccountPosition> GetAccountPositions();
        IList<Medicine> GetMedicines();
    }
}
