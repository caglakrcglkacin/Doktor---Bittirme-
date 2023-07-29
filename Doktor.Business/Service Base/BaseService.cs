using DoktorKlinik.Bussiness;
using DoktorKlinik.DataAccess;
using DoktorKlinik.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DoktorKlinik.Business.Service_Base
{
    public abstract class BaseService<TDto, TSummary, TEntity> : IBaseService<TDto, TSummary>
        where TEntity : class, IEntity, new()
    {
        protected readonly TourContext _tourContext;
        public BaseService(TourContext tourContext)
        {
            _tourContext = tourContext;
        }
        protected abstract TEntity MapEntity(TDto model);
        protected abstract Expression<Func<TEntity, TDto>> DtoMapper { get; }
        protected abstract Expression<Func<TEntity, TSummary>> SummaryMapper { get; }
        public CommadResult Create(TDto model)
        {
            try
            {
                var entity = MapEntity(model);
                _tourContext.Set<TEntity>().Add(entity);
                _tourContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return CommadResult.Failure();

            }
        }

        public CommadResult Delete(TDto model)
        {
            try
            {
                var entity = MapEntity(model);
                _tourContext.Set<TEntity>().Remove(entity);
                _tourContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return CommadResult.Failure();

            }
        }

        public CommadResult Delete(int Id)
        {
           
            try
            {
                var entity = new TEntity()
                {Id = Id};
                if (entity != null)
                {
                    _tourContext.Set<TEntity>().Remove(entity);
                    _tourContext.SaveChanges();
                    return CommadResult.Success();
                }
                else
                {
                    return CommadResult.Failure("Kayıt bulunamadı.");
                }
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return CommadResult.Failure();

            }

        }

        public IEnumerable<TDto> GetAll()
        {
            try
            {
                return _tourContext.Set<TEntity>()
                    .Select(DtoMapper)
                    .ToList();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<TDto>();
            }
        }

        public TDto? GetById(int Id)
        {
            try
            {
                //var dtoMapper = new Func<TEntity, TDto>(MapToDto);

                return _tourContext.Set<TEntity>()
                    .Where(entity => entity.Id == Id)
                    .Select(DtoMapper)
                    .SingleOrDefault();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return default;
            }
        }

        public IEnumerable<TSummary> GetSummary()
        {
            try
            {
                //var summaryMapper = new Func<TEntity, TSummary>(MapToSummary);

                return _tourContext.Set<TEntity>()
                    .Select(SummaryMapper)
                    .ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<TSummary>();
            }
        }

        public TSummary? GetSummaryById(int id)
        {
            try
            {
                return _tourContext.Set<TEntity>()
                    .Where(entity => entity.Id == id)
                    .Select(SummaryMapper)
                    .SingleOrDefault();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return default;
            }
        }

        public CommadResult Update(TDto model)
        {
            try
            {
                var entity = MapEntity(model);
                _tourContext.Set<TEntity>().Attach(entity);
                _tourContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return CommadResult.Failure();

            }
        }

     
    }
}
