using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Repository
{
    interface ITodoRepositories
    {
        Task<IEnumerable<Todo>> GetTaskList();

    }
}
