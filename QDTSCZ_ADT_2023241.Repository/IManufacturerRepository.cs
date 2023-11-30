﻿using QDTSCZ_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDTSCZ_ADT_2023241.Repository
{
    public interface IManufacturerRepository: IRepository<Manufacturer>
    {
        public void UpdateName(int Id, string name);
    }
}