using AutoMapper;
using TALLER.ENTITY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Talleres.Infraestructure.Mapping
{

    public class MapperedEntities
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
               // cfg.CreateMap<CancellationReason, ReasonCancellationDto>().ReverseMap();

               // cfg.CreateMap<Company, CompanyDto>().ReverseMap();
               // cfg.CreateMap<BankFile, BankFileDto>().ReverseMap();
               // cfg.CreateMap<ExportBankFile, ExportFileDto>().ReverseMap();
               // cfg.CreateMap<ExportBankFileDetail, ExportBankFileDetailDto>().ReverseMap();
               // cfg.CreateMap<BankFileDetail, ArchiveFileDto>().ReverseMap();
               // cfg.CreateMap<BankFileDetail, BankFilesDetailForUploadFileDto>().ReverseMap();
               // cfg.CreateMap<ExportBankFileDetail, ExportArchive>().ReverseMap();
               // cfg.CreateMap<ExportBankFileDetail, ExportFileDetailForExportFileDto>().ReverseMap();



               // cfg.CreateMap<ExportBankFile, ExportFileDto>()
               // .ForMember(t => t.CurrencyName, opt => opt.MapFrom(v => v.Currency.Name))
               // .ForMember(t => t.CompanyName, opt => opt.MapFrom(v => v.Company.Name))
               // .ForMember(t => t.BankName, opt => opt.MapFrom(v => v.Bank.Name))
               // .ForMember(t => t.Id_BankFilesDetail, opt => opt.MapFrom(v => v.BankFileDetail.Id));

               // cfg.CreateMap<BankFile, BankFileDto>()
               // .ForMember(t => t.CurrencyName, opt => opt.MapFrom(v => v.Currency.Name))
               // .ForMember(t => t.Bankname, opt => opt.MapFrom(v => v.Bank.Name));

               // cfg.CreateMap<BankFileDetail, BankFilesDetailDto>()
               //.ForMember(t => t.Currency, opt => opt.MapFrom(v => v.BankFile.Currency.Code))
               //.ForMember(t => t.CompanyName, opt => opt.MapFrom(v => v.BankFile.Company.Name))
               //.ForMember(t => t.BankName, opt => opt.MapFrom(v => v.BankFile.Bank.Name));



               // cfg.CreateMap<UserSignUpDto, User>()
               //     .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));

               // cfg.CreateMap<UserDto, User>()
               //     .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));

            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }

    }
}
