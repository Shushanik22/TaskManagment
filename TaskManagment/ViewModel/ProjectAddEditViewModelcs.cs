﻿using TaskManagment.Data.Entities;

namespace TaskManagment.ViewModel
{
    public class ProjectAddEditViewModelcs
    {
      
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        public decimal TotalPercentage { get; set; }
    }
}
