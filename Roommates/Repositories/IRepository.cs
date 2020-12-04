using System;
using System.Collections.Generic;
using System.Text;
using Roommates.Models;

namespace Roommates.Repositories
{
    public interface IRepository
    {
        IModel GetById(int id);
    }
}
