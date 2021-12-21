using AutoMapper;
using SimpleMessageProcessing.Library.Extensions;
using SimpleMessageProcessing.Library.Models;
using SimpleMessageProcessing.Library.Models.FormatAAggregate;
using SimpleMessageProcessing.Library.Models.FormatBAggregate;
using SimpleMessageProcessing.Library.Models.FormatCAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessageProcessing.Api.Profiles {
    public class SimpleMessageProfile : Profile {
        public SimpleMessageProfile()
        {
            CreateMap<FormatA, SimpleMessage>()
                .ForMember(dest => dest.Format, act => act.MapFrom(src => nameof(FormatA)))
                .ReverseMap();
            CreateMap<FormatB, SimpleMessage>()
                .ForMember(dest => dest.Format, act => act.MapFrom(src => nameof(FormatB)))
                .ForMember(dest => dest.From, act=>act.MapFrom(src => src.Source.UserId))
                .ForMember(dest => dest.Type, act => act.MapFrom(src => src.Message.Type))
                .ForMember(dest => dest.Text, act => act.MapFrom(src => src.Message.Text))
                .ForMember(dest => dest.MessageId, act => act.MapFrom(src => src.Message.Id))
                .ForMember(dest => dest.SourceType, act => act.MapFrom(src => src.Source.Type))
                .ForMember(dest => dest.SendTime, act => act.MapFrom(src => src.TimeStamp.FromEpochStringToDateTime().ToIso8601DateTime()))
                .ReverseMap();
            CreateMap<FormatC, SimpleMessage>()
                .ForMember(dest => dest.Format, act => act.MapFrom(src => nameof(FormatC)))
                .ForMember(dest => dest.From, act => act.MapFrom(src => src.Msisdn))
                .ForMember(dest => dest.Text, act => act.MapFrom(src => src.Message.MsgText))
                .ForMember(dest => dest.SendTime, act => act.MapFrom(src => src.Message.MsgTime))
                .ReverseMap();
        }
    }
}
