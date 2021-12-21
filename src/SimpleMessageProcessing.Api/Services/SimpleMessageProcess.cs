using SimpleMessageProcessing.Library.Abstractions;
using SimpleMessageProcessing.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleMessageProcessing.Api.Services {
    public class SimpleMessageProcess : ISimpleMessageProcess {
        private readonly SystemSettings _systemSettings;
        private readonly IParseService _parseService;
        private readonly INormalizeService _normalizeService;
        private readonly ISimpleMessageRepositories _repositories;

        public SimpleMessageProcess(SystemSettings systemSettings, IParseService parseService, INormalizeService normalizeService, ISimpleMessageRepositories repositories)
        {

            _systemSettings = systemSettings;
            _parseService = parseService;
            _normalizeService = normalizeService;
            _repositories = repositories;
        }

        public async Task<bool> ProcessMessage(string message)
        {
            try
            {
                JsonDocument jsonDocument = JsonDocument.Parse(message);
                var result = await _parseService.ParseMessage(jsonDocument);
                if (!result.IsValid)
                {
                    return false;
                }
                var simpleMessage = await _normalizeService.NormalizeMessage(result.Result);
                return await _repositories.SaveSimpleMessage(simpleMessage);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
