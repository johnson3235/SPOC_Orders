using AutoMapper;
using DB_Layer.Models;
using Repo_Layer.UnitOfWork;

namespace Services_Layer.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IUnitOFWork _unitofwork;
        private readonly IMapper _mapper;

        public string ServiceId { get; set; }
        public Service(IUnitOFWork _unitofwork ,  IMapper _mapper)
        {
            this._unitofwork = _unitofwork;
            this._mapper=_mapper;
    }

       
    }
}
