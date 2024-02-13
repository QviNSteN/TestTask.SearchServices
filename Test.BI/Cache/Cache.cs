using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Entities;

namespace Test.BI.Cache
{
    public class Cache<T> where T : Base
    {
        private readonly ConcurrentHashSet<T> _cache = new ConcurrentHashSet<T>();

        public void AddOrUpdate(ICollection<T> entities)
        {
            if(entities is null ||  entities.Count == 0)
                return;

            _cache.AddOrUpdate(entities);
        }

        public void AddOrUpdate(T entity)
        {
            if (entity is null)
                return;

            _cache.AddOrUpdate(entity);
        }


        public T Get(Guid id) => _cache.Get(x => x.Id == id);

        public IEnumerable<T> GetAll(Func<T, bool> func) => _cache.GetAll(func);

        public bool Remove(T entity)
        {
            if (entity is null)
                return false;

            return _cache.Remove(entity);
        }
    }

    public class ConcurrentHashSet<T> : IDisposable where T : class
    {
        private readonly HashSet<T> _cache = new HashSet<T>();
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        public void AddOrUpdate(ICollection<T> entities)
        {
            _lock.EnterWriteLock();
            try
            {
                foreach (var entity in entities)
                {
                    if (Contains(entity))
                        _cache.Remove(entity);
                    _cache.Add(entity);
                }
            }
            finally
            {
                if (_lock.IsWriteLockHeld)
                    _lock.ExitWriteLock();
            }
        }

        public void AddOrUpdate(T entity)
        {
            _lock.EnterWriteLock();
            try
            {
                if (Contains(entity))
                    Remove(entity);
                Add(entity);
            }
            finally
            {
                if (_lock.IsWriteLockHeld)
                    _lock.ExitWriteLock();
            }
        }

        public bool Contains(T entity)
        {
            _lock.EnterReadLock();
            try
            {
                return _cache.Contains(entity);
            }
            finally
            {
                if (_lock.IsReadLockHeld)
                    _lock.ExitReadLock();
            }
        }

        public T Get(Func<T, bool> get)
        {
            _lock.EnterReadLock();
            try
            {
                return _cache.FirstOrDefault(get);
            }
            finally
            {
                if (_lock.IsReadLockHeld)
                    _lock.ExitReadLock();
            }
        }

        public IEnumerable<T> GetAll(Func<T, bool> get)
        {
            _lock.EnterReadLock();
            try
            {
                return _cache.Where(get);
            }
            finally
            {
                if (_lock.IsReadLockHeld)
                    _lock.ExitReadLock();
            }
        }

        public void Add(T entity)
        {
            _lock.EnterWriteLock();
            try
            {
                _cache.Add(entity);
            }
            finally
            {
                if (_lock.IsWriteLockHeld)
                    _lock.ExitWriteLock();
            }
        }

        public bool Remove(T entity)
        {
            _lock.EnterWriteLock();
            try
            {
                return _cache.Remove(entity);
            }
            finally
            {
                if (_lock.IsWriteLockHeld)
                    _lock.ExitWriteLock();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (_lock != null)
                    _lock.Dispose();
        }
        ~ConcurrentHashSet()
        {
            Dispose(false);
        }
    }
}
