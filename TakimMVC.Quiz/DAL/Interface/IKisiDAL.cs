﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakimMVC.Quiz.DTO;
using TakimMVC.Quiz.Entities;

namespace TakimMVC.Quiz.DAL.Interface
{
    public interface IKisiDAL
    {
        List<KisiDTO> GetAll();
        void Add(Kisi kisi);
    }
}
