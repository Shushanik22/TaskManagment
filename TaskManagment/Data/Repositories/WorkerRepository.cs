﻿using TaskManagment.Data.Entities;
using TaskManagment.Data.Repositories.Interfaces;

namespace TaskManagment.Data.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly TaskContext _context;
        public WorkerRepository(TaskContext context)
        {
            _context = context;
        }
        public void Add(Worker worker)
        {
            _context.Workers.Add(worker);
        }

        public void Delete(Worker worker)
        {
            _context.Workers.Remove(worker);
        }

        public List<Worker> GetAll()
        {
            return _context.Workers.ToList();
        }

        public Worker GetById(int id)
        {
            return _context.Workers.Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
