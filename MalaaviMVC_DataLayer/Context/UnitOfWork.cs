using System;
using MalaaviMVC_DataLayer.Repositories;
using MalaaviMVC_DataLayer.Services;
using MalaaviMVC_DomainClasses.Users;

namespace MalaaviMVC_DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        private readonly DataContext _context = new DataContext();

        private IProductRepository _productRepository;
        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_context);
                }
                return _productRepository;
            }
        }

        private ICategoryRepository _categoryRepository;
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_context);
                }
                return _categoryRepository;
            }
        }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        private IGenericRepository<Role> _roleRepository;
        public IGenericRepository<Role> RoleRepository
        {
            get
            {
                if (_roleRepository == null)
                {
                    _roleRepository = new GenericRepository<Role>(_context);
                }
                return _roleRepository;
            }
        }

        private IProductCategoryRepository _productCategoryRepository;
        public IProductCategoryRepository ProductCategoryRepository
        {
            get
            {
                if (_productCategoryRepository == null)
                {
                    _productCategoryRepository = new ProductCategoryRepository(_context);
                }

                return _productCategoryRepository;
            }
        }

        private IProductTagRepository _productTagRepository;
        public IProductTagRepository ProductTagRepository
        {
            get
            {
                if (_productTagRepository == null)
                {
                    _productTagRepository = new ProductTagRepository(_context);
                }

                return _productTagRepository;
            }
        }

        private IProductGalleryRepository _productGalleryRepository;
        public IProductGalleryRepository ProductGalleryRepository
        {
            get
            {
                if (_productGalleryRepository == null)
                {
                    _productGalleryRepository = new ProductGalleryRepository(_context);
                }
                return _productGalleryRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
