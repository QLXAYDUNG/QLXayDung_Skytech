using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhanMemQuanLyCongTrinh.BUS
{
    class buildingContractorBus
    {
        DAO.buildingContractorDao buildingContractorDao = new DAO.buildingContractorDao();

        public object loadAllBuildingContractor()
        {
            return buildingContractorDao.loadAllBuildingContractor();
        }
        public bool deleteBuildingContractor(Int64 buildingContractorId)
        {
            return buildingContractorDao.deleteBuildingContractor(buildingContractorId);
        }
        public object loadBuildingContractor(Int64 buildingContractorId)
        {
            return buildingContractorDao.loadBuildingContractor(buildingContractorId);

        }
        public bool insertBuildingContractor(DTO.ST_building_contractor buildingContractor)
        {
            return buildingContractorDao.insertBuildingContractor(buildingContractor);
        }
        public bool updateBuildingContractor(DTO.ST_building_contractor buildingContractor)
        {
            return buildingContractorDao.updateBuildingContractor(buildingContractor);
        }
    }
}
