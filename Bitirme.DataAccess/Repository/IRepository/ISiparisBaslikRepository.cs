﻿using Bitirme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme.DataAccess.Repository.IRepository
{
    public interface ISiparisBaslikRepository : IRepository<SiparisBaslik>
    {
        void Update(SiparisBaslik obj);
        
    }
}
