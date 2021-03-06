﻿using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IMapper _mapper;

        public BrandManager(IBrandDal brandDal, IMapper mapper)
        {
            _brandDal = brandDal;
            _mapper = mapper;
        }

        #region Listeleme Metotları
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.Id == brandId));
        }

        public IDataResult<List<Brand>> GetAllWithCars()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAllWithCars());
        }

        #endregion

        #region Temel Ekleme-Silme-Güncelleme
        public IResult Add(BrandAddDto brandAddDto)
        {
            //mapping
            Brand brand = _mapper.Map<Brand>(brandAddDto);
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IResult Update(BrandUpdateDto brandUpdateDto)
        {
            //mapping
            Brand brand = _mapper.Map<Brand>(brandUpdateDto);
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        
        #endregion

    }
}
