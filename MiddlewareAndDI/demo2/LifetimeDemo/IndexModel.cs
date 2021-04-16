using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifetimeDemo
{
    public class IndexModel:PageModel
    {
        private readonly ILogger _logger;
        private readonly IOperationTransient _transientOperation;
        private readonly IOperationSingleton _singletonOperation;
        private readonly IOperationScoped _scopedOperation;

        public IndexModel(ILogger<IndexModel> logger,
                          IOperationTransient transientOperation,
                          IOperationSingleton singletonOperation,
                          IOperationScoped scopedOperation)
        {
            _logger = logger;
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;

        }

        public void OnGet()
        {
            _logger.LogInformation("Transient" + _transientOperation.OperationId);
            _logger.LogInformation("Scoped" + _scopedOperation.OperationId);
            _logger.LogInformation("Singletion" + _singletonOperation.OperationId);
        }
    }
}
