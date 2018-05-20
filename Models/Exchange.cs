using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiningPredictionAPI.Models
{
    public class Exchange
    {
        public bool Success { get; set; }
        public string Message{ get; set; }
        public IEnumerable<Result> Result{ get; set; }
    }

    public class Result
    {
        public string MarketCurrency { get; set; }
        public string BaseCurrency { get; set; }
        public string MarketCurrencyLong { get; set; }
        public string BaseCurrencyLong { get; set; }
        public string MinTradeSize { get; set; }
        public string MarketName { get; set; }
        public string Created { get; set; }
    }
}
