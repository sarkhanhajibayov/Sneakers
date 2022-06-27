﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sneakers.DTO.HelperModels.Const;
using Sneakers.DTO.RequestModel;
using Sneakers.Infrastructure.Repository;
using Sneakers.Logging;
using Sneakers.Models;
using Sneakers.Services.Interface;
using System;
using System.Linq;

namespace Sneakers.Services.Implementation
{
    public class BrandService : IBrandService
    {

        private AppDbContext _context;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IRepository<SNEAKERS_BRAND> _brands;
        public BrandService(AppDbContext context, ILoggerManager logger, IMapper mapper, IRepository<SNEAKERS_BRAND> brands)
        {
            _context = context;
            _logger = logger;
            _brands = brands;
            _mapper = mapper;
        }

        public void AddBrand(BrandVM model, ref int errorCode, ref string message, string traceId)
        {
            try
            {
                SNEAKERS_BRAND pos = _mapper.Map<SNEAKERS_BRAND>(model);
                _brands.Insert(pos);
                _brands.Save();
            }
            catch (Exception ex)
            {
                errorCode = ErrorCode.DB;
                message = "DB create brand error";
                _logger.LogError($"BrandService AddPosition : {traceId}" + $"{ex}");
            }
        }
        public void UpdateBrand(BrandVM model, int id, ref int errorCode, ref string message, string traceId)
        {
            try
            {
                SNEAKERS_BRAND oldData = _brands.AllQuery.AsNoTracking().FirstOrDefault(x => x.Id == id);
                SNEAKERS_BRAND newData = _mapper.Map<SNEAKERS_BRAND>(model);
                newData.Id = id;
                oldData = newData;
                _brands.Update(oldData);
                _brands.Save();
            }
            catch (Exception ex)
            {
                errorCode = ErrorCode.DB;
                message = ex.Message;
                _logger.LogError($"PositionService UpdatePosition : {traceId}" + $"{ex}");
            }
        }

        public void DeleteBrand(int id, ref int errorCode, ref bool brandExists, ref string message, string traceId)
        {

            SNEAKERS_BRAND brand = _brands.AllQuery.FirstOrDefault(n => n.Id == id);

            try
            {
                if (brand != null)
                {

                    _brands.Remove(brand);
                    _brands.Save();
                    message = "Bu brand uğurla silindi.";

                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                errorCode = ErrorCode.DB;
                message = "DB delete position error";
                _logger.LogError($"PositionService DeletePosition : {traceId}" + $"{ex}");
            }
        }

    }
}
