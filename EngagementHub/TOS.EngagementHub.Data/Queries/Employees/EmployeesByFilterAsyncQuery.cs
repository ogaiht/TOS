using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOS.Common.DataModel;
using TOS.Data.MongoDB;
using TOS.EngagementHub.Models;
using TOS.EngagementHub.Models.Filters;
using TOS.EngagementHub.Models.Projections;

namespace TOS.EngagementHub.Data.Queries.Employees
{
    public class EmployeesByFilterAsyncQuery : IEmployeesByFilterAsyncQuery
    {
        private readonly IMongoCollectionProvider _mongoCollectionProvider;
        private readonly IEmployeeDetailComposer _employeeDetailComposer;

        public EmployeesByFilterAsyncQuery(IMongoCollectionProvider mongoCollectionProvider, IEmployeeDetailComposer employeeDetailComposer)
        {
            _mongoCollectionProvider = mongoCollectionProvider;
            _employeeDetailComposer = employeeDetailComposer;
        }

        public async Task<IPagedResult<EmployeeDetail>> FindEmployeesAsync(EmployeeFilter filter)
        {
            IPagedResult<Employee> employees = await LoadEmployeesAsync(filter);
            IReadOnlyCollection<EmployeeDetail> employeeDetails = await _employeeDetailComposer.LoadEmployeeDetailsAsync(employees.Items.ToArray());
            return new PagedResult<EmployeeDetail>(employeeDetails, employees.Total, employees.Offset, employees.Limit);
        }

        private async Task<IPagedResult<Employee>> LoadEmployeesAsync(EmployeeFilter filter)
        {
            FilterDefinitionBuilder<Employee> filterBuilder = Builders<Employee>.Filter;
            FilterDefinition<Employee> queryFilter;
            if (!string.IsNullOrWhiteSpace(filter.NameContains))
            {
                queryFilter = filterBuilder.Where(e => string.IsNullOrWhiteSpace(filter.NameContains) ||
                        e.Name.FirstName.Contains(filter.NameContains) ||
                        e.Name.MiddleName.Contains(filter.NameContains) ||
                        e.Name.LastName.Contains(filter.NameContains));
            }
            else
            {
                queryFilter = filterBuilder.Where(e => true);
            }


            return await _mongoCollectionProvider.GetCollection<Employee>()
                .FindPagedResultAsync(queryFilter, filter.Paging.Offset, filter.Paging.Limit == -1 ? 100 : filter.Paging.Limit);
        }
    }
}
