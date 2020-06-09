﻿using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface IRepository<T>
    {
        T Create(T entity);
        T Update(T entity);
        IEnumerable<T> GetAll();
        bool Delete(T entity);
        T GetById(int id);
    }
}
