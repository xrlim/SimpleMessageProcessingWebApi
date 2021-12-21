using AutoMapper;
using SimpleMessageProcessing.Library.Abstractions;
using SimpleMessageProcessing.Library.Models;
using SimpleMessageProcessing.Library.Models.FormatAAggregate;
using SimpleMessageProcessing.Library.Models.FormatBAggregate;
using SimpleMessageProcessing.Library.Models.FormatCAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessageProcessing.Api.Services {
    public class NormalizeService : INormalizeService {
        private readonly IMapper _mapper;
        public NormalizeService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<SimpleMessage> NormalizeMessage(IMessage message)
        {
            if (message is FormatA formatA)
            {
                //Using automapper
                return await Task.FromResult(_mapper.Map<SimpleMessage>(formatA));
            }

            if (message is FormatB formatB)
            {
                //Using automapper
                return await Task.FromResult(_mapper.Map<SimpleMessage>(formatB));
            }

            if (message is FormatC formatC)
            {
                //Using automapper
                return await Task.FromResult(_mapper.Map<SimpleMessage>(formatC));
            }

            throw new InvalidOperationException($"Source {nameof(NormalizeMessage)}: Unknown Format!");
        }

    }
}
