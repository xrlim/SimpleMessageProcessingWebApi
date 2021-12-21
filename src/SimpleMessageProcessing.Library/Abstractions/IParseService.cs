using SimpleMessageProcessing.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleMessageProcessing.Library.Abstractions {
    public interface IParseService {
        Task<ValidateResult> ParseMessage(JsonDocument jsonDocument);
    }
}
