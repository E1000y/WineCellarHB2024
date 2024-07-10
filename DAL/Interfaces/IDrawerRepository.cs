﻿using Microsoft.Identity.Client;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDrawerRepository
    {
        public List<Drawer> GetAll();

        public Drawer GetById(int id);

        public void Create(Drawer drawer);

        public void Update(Drawer drawer);

        public void Delete(int id);

    }
}