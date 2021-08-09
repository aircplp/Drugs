using System;
using DrugManagementSystem.Entities;
using DrugManagementSystem.Models;

using AutoMapper;

namespace DrugManagementSystem
{
    public class DrugProfiles: Profile
    {
        public DrugProfiles()
        {
            CreateMap<DrugModel, Drug>().ReverseMap();
        }
    }
}
