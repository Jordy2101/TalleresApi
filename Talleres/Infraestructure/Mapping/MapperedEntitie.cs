using AutoMapper;
using TALLER.ENTITY.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TALLER.ENTITY.Dto;
using Talleres.Controllers;

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

                //Mapeo entidad Automovil
                cfg.CreateMap<AUTOMOVIL, AUTOMOVILDto>().ReverseMap();

                //Mapeo entidad Cliente
                cfg.CreateMap<CLIENT, CLIENTDto>().ReverseMap();

                cfg.CreateMap<CLIENT, CLIENTDto>()
                .ForMember(t => t.ID_AUTOMOVIL, opt => opt.MapFrom(v => v.AUTOMOVIL.Id))
                .ForMember(t => t.Modelo, opt => opt.MapFrom(v => v.AUTOMOVIL.Modelo));

                //Mapeo Entidad Mecanico
                cfg.CreateMap<MECANICO, MECANICODto>().ReverseMap();

                //Mapeo Entidad Solicitud
                cfg.CreateMap<SOLICITUD, SOLICITUDDto>().ReverseMap();

                cfg.CreateMap<SOLICITUD, SOLICITUDDto>()
                .ForMember(t => t.ID_MECANICO, opt => opt.MapFrom(v => v.MECANICO.Id))
                .ForMember(t => t.Nombre_Mecanico, opt => opt.MapFrom(v => v.MECANICO.Nombre))
                .ForMember(t => t.Especialidad, opt => opt.MapFrom(v => v.MECANICO.Especialidad))
                .ForMember(t => t.ID_CLIENTE, opt => opt.MapFrom(v => v.CLIENT.Id))
                .ForMember(t => t.Nombre_Cliente, opt => opt.MapFrom(v => v.CLIENT.Nombre))
                .ForMember(t => t.Cedula, opt => opt.MapFrom(v => v.CLIENT.Cedula));


                cfg.CreateMap<RECIBO, RECIBODto>().ReverseMap();
                cfg.CreateMap<RECIBO, RECIBODto>()
               
                .ForMember(t => t.ID_SOLICITUD, opt => opt.MapFrom(v => v.SOLICITUD.MECANICO.Id))
                 .ForMember(t => t.ID_SOLICITUD, opt => opt.MapFrom(v => v.SOLICITUD.CLIENT.Id))
                 .ForMember(t => t.ID_SOLICITUD, opt => opt.MapFrom(v => v.SOLICITUD.Id))
               .ForMember(t => t.Nombre_mecanico, opt => opt.MapFrom(v => v.SOLICITUD.MECANICO.Nombre))
               .ForMember(t => t.Especialidad, opt => opt.MapFrom(v => v.SOLICITUD.MECANICO.Especialidad))
                .ForMember(t => t.Nombre_cliente, opt => opt.MapFrom(v => v.SOLICITUD.CLIENT.Nombre))
                 .ForMember(t => t.Cedula, opt => opt.MapFrom(v => v.SOLICITUD.CLIENT.Cedula));



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
