using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SimpleMessageProcessing.Library.Abstractions;
using SimpleMessageProcessing.Library.Models;
using SimpleMessageProcessing.Library.Models.FormatAAggregate;
using SimpleMessageProcessing.Library.Models.FormatBAggregate;
using SimpleMessageProcessing.Library.Models.FormatCAggregate;

namespace SimpleMessageProcessing.Api.Services {
    public class ParseService : IParseService {

        private static ValidateResult InvalidResult = new(false, null);
        private readonly SystemSettings _systemSettings;

        public ParseService(SystemSettings systemSettings)
        {
            _systemSettings = systemSettings;
        }

        /// <summary>
        /// Validate the request message and return which kind of message it belong to
        /// </summary>
        /// <param name="jsonDocument"></param>
        /// <returns></returns>
        public async Task<ValidateResult> ParseMessage(JsonDocument jsonDocument)
        {
            var getMessageATask = IsMessageA(jsonDocument);
            var getMessageBTask = IsMessageB(jsonDocument);
            var getMessageCTask = IsMessageC(jsonDocument);

            var result = await Task.WhenAll(getMessageATask, getMessageBTask, getMessageCTask);
            if (result.Any(x => x.IsValid == true))
            {
                return result.First(x => x.IsValid);
            }

            return InvalidResult;
        }

        private async Task<ValidateResult> IsMessageA(JsonDocument jsonDocument)
        {
            try
            {
                var root = jsonDocument.RootElement;
                var jsonObjects = root.EnumerateObject();
                var fieldCount = jsonObjects.Count();
                if (_systemSettings.FormatAFieldCount != fieldCount)
                {
                    return InvalidResult;
                }

                var formatA = jsonDocument.Deserialize<FormatA>(Configurations.GetJsonSerializerOption());
                return new(true, formatA);
            }
            catch (Exception ex)
            {
                return InvalidResult;
            }

        }

        private async Task<ValidateResult> IsMessageB(JsonDocument jsonDocument)
        {
            try
            {
                var root = jsonDocument.RootElement;
                var jsonObjects = root.EnumerateObject();
                var fieldCount = jsonObjects.Count();
                if (_systemSettings.FormatBFieldCount != fieldCount)
                {
                    return InvalidResult;
                }

                var formatB = jsonDocument.Deserialize<FormatB>(Configurations.GetJsonSerializerOption());
                return new(true, formatB);
            }
            catch (Exception ex)
            {
                return InvalidResult;
            }

        }

        private async Task<ValidateResult> IsMessageC(JsonDocument jsonDocument)
        {
            try
            {
                var root = jsonDocument.RootElement;
                var jsonObjects = root.EnumerateObject();
                var fieldCount = jsonObjects.Count();
                if (_systemSettings.FormatCFieldCount != fieldCount)
                {
                    return InvalidResult;
                }

                var formatC = jsonDocument.Deserialize<FormatC>(Configurations.GetJsonSerializerOption());
                return new(true, formatC);
            }
            catch (Exception ex)
            {
                return InvalidResult;
            }

        }

    }
}
