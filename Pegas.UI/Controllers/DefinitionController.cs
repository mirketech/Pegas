using Pegas.Data;
using Pegas.Data.Repository;
using Pegas.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Pegas.UI.Controllers
{
    public class DefinitionController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IContractRepository _contractRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly IFlightCodeRepository _flightCodeRepository;
        private readonly IJobDetailRepository _jobDetailRepository;
        private readonly IJobTypeRepository _jobTypeRepository;
        private readonly IMeetingPointRepository _meetingPointRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleTypeRepository _vehicleTypeRepository;


        // GET: Account
        public DefinitionController(IUserRepository userRepository,
        ICompanyRepository companyRepository,
        IContractRepository contractRepository,
        IDriverRepository driverRepository,
        IFlightCodeRepository flightCodeRepository,
        IJobDetailRepository jobDetailRepository,
        IJobTypeRepository jobTypeRepository,
        IMeetingPointRepository meetingPointRepository,
        IVehicleRepository vehicleRepository,
        IVehicleTypeRepository vehicleTypeRepository
            )
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _contractRepository = contractRepository;
            _driverRepository = driverRepository;
            _flightCodeRepository = flightCodeRepository;
            _jobDetailRepository = jobDetailRepository;
            _jobTypeRepository = jobTypeRepository;
            _meetingPointRepository = meetingPointRepository;
            _vehicleRepository = vehicleRepository;
            _vehicleTypeRepository = vehicleTypeRepository;
        }

        public DefinitionController()
        {
        }

        // GET: Definition
        public ActionResult JobType()
        {
            return View();
        }
    }
}