﻿using BlogAppCore.Core.IRepositories;
using BlogAppCore.Data;
using BlogAppCore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogAppCore.Core.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(BlogDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<Blog> GetByIdAsync(long id)
        {
            return await _context.Blogs.Include(i => i.Comments).Include(i => i.Category).Include(i => i.AppUser).FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted);
        }

        public virtual async Task<IEnumerable<Blog>> GetByCategoryIdAsync(long id)
        {
            return await dbSet.Include(i => i.Category).Include(i => i.AppUser).Where(i =>
                i.CategoryId == id && !i.IsDeleted).ToListAsync();
        }

        public virtual async Task<IEnumerable<Blog>> GetByUserIdAsync(string id)
        {
            return await dbSet.Include(i => i.Category).Include(i => i.AppUser).Where(i =>
                i.AppUserId == id && !i.IsDeleted).ToListAsync();
        }

        public virtual async Task<IEnumerable<Blog>> GetDeletedBlogsByUserIdAsync(string id)
        {
            return await dbSet.Include(i => i.Category).Include(i => i.AppUser).Where(i =>
                i.AppUserId == id && i.IsDeleted).ToListAsync();
        }
    }
}
